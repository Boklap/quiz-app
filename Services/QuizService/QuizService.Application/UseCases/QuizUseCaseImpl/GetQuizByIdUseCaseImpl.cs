using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class GetQuizByIdUseCaseImpl : IGetQuizByIdUseCase
{
    private readonly IQuizRepository _repository;

    public GetQuizByIdUseCaseImpl(IQuizRepository repository)
    {
        _repository = repository;
    }

    public async Task<QuizDto> Execute(string quizId)
    {
        Quiz? quiz = await _repository.FindQuizById(quizId);
        if (quiz == null)
        {
            throw new EntityNotFoundException("Quiz is not found");
        }

        QuizDto quizDto = QuizMapper.ToDto(quiz);
        return quizDto;
    }
}