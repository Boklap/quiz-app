using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetPaginatedQuizByCreatorUseCaseImpl : IGetPaginatedQuizByCreatorUseCase
{
    private readonly IQuizRepository _quizRepository;

    public GetPaginatedQuizByCreatorUseCaseImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<List<QuizDto>> Execute(string userId, int page, int pageSize)
    {
        List<Quiz> quizList = await GetPaginatedQuizByCreator(userId, page, pageSize);
        if(!quizList.Any()) return new List<QuizDto>();

        return quizList.Select(QuizMapper.ToDto).ToList();
    }

    public async Task<List<Quiz>> GetPaginatedQuizByCreator(string userId, int page, int pageSize)
    {
        return await _quizRepository.FindQuizzezByCreator(userId, page, pageSize);
    }
}