using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetPaginatedQuizUseCaseImpl : IGetPaginatedQuizUseCase
{
    private readonly IQuizRepository _quizRepository;

    public GetPaginatedQuizUseCaseImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<List<QuizDto>> Execute(int page, int pageSize)
    {
        List<Quiz> quizList = await GetPaginatedQuiz(page, pageSize);
        if(!quizList.Any()) return new List<QuizDto>();

        return quizList.Select(QuizMapper.ToDto).ToList();
    }

    public async Task<List<Quiz>> GetPaginatedQuiz(int page, int pageSize)
    {
        return await _quizRepository.FindPaginatedQuizzez(page, pageSize);
    }
}