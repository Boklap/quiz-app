using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetQuizByQuizIdsUseCaseImpl : IGetQuizByQuizIds
{
    private readonly IQuizRepository _repository;

    public GetQuizByQuizIdsUseCaseImpl(IQuizRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<QuizDto>> Execute(List<string> quizIds)
    {
        List<Quiz>? quizzes = await _repository.FindQuizzesByIds(quizIds);
        if(quizzes == null) return new List<QuizDto>();
        
        List<QuizDto> quizDtos = quizzes.Select(QuizMapper.ToDto).ToList();
        return quizDtos;
    }
}