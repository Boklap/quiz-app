using QuizResultService.Application.Dtos;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Application.Ports.Inbound.Participant;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;
using QuizResultService.Domain.Services.Interfaces;

namespace QuizResultService.Application.UseCases.Participant;

public class CreateQuizResultUseCaseImpl : ICreateQuizResultUseCase
{
    private readonly IQuizResultRepository _quizResultRepository;
    private readonly IQuizResultService _quizResultService;

    public CreateQuizResultUseCaseImpl(IQuizResultRepository quizResultRepository, IQuizResultService quizResultService)
    {
        _quizResultRepository = quizResultRepository;
        _quizResultService = quizResultService;
    }
    
    public async Task Execute(CreateQuizResultDto createQuizResultDto)
    {
        QuizResult quizResult = CreateQuizResult(createQuizResultDto);
        await InsertQuizResult(quizResult);
    }

    public QuizResult CreateQuizResult(CreateQuizResultDto createQuizResultDto)
    {
        return _quizResultService.CreateQuizResult(
            createQuizResultDto.ParticipantId,
            createQuizResultDto.Schedule,
            createQuizResultDto.Quiz,
            createQuizResultDto.Score);
    }

    public async Task InsertQuizResult(QuizResult quizResult)
    {
        await _quizResultRepository.InsertQuizResult(quizResult);
    }
}