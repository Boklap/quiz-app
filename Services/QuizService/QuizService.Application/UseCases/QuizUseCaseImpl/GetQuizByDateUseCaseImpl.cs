using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetQuizByDateUseCaseImpl : IGetQuizByDateUseCase
{
    private readonly IQuizRepository _repository;

    public GetQuizByDateUseCaseImpl(IQuizRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<QuizDto>> Execute(DateTime startAt, DateTime endAt)
    {
        List<Quiz>? quizzes = await _repository.FindQuizzesByDate(startAt, endAt);
        
        if (quizzes == null)
            return new List<QuizDto>();

        List<QuizDto> quizDtos = quizzes.Select(quiz => QuizMapper.ToDto(quiz)).ToList();
        return quizDtos;
    }
}