using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetPaginatedQuizByTagUseCaseImpl : IGetPaginatedQuizByTagUseCase
{
    private readonly IQuizRepository _quizRepository;

    public GetPaginatedQuizByTagUseCaseImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<List<QuizDto>> Execute(string tag, int page, int pageSize)
    {
        List<Quiz> quizList = await GetPaginatedQuizByTag(tag, page, pageSize);
        if(!quizList.Any()) return new List<QuizDto>();

        return quizList.Select(QuizMapper.ToDto).ToList();
    }

    public async Task<List<Quiz>> GetPaginatedQuizByTag(string tag, int page, int pageSize)
    {
        return await _quizRepository.FindQuizzezByTag(tag, page, pageSize);
    }
}