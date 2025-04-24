using Microsoft.AspNetCore.Http;
using QuizService.Application.Dtos;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Domain.Services.Interfaces;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class CreateQuizUseCaseImpl : ICreateQuizUseCase
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuizService _quizService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateQuizUseCaseImpl(
        IQuizRepository quizRepository,
        IQuizService quizService,
        IHttpContextAccessor httpContextAccessor)
    {
        _quizRepository = quizRepository;
        _quizService = quizService;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<string> Execute(CreateQuizDto createQuizDto)
    {
        Quiz quiz = CreateQuiz(createQuizDto);
        await InsertQuiz(quiz);
        return quiz.Id;
    }

    public Quiz CreateQuiz(CreateQuizDto createQuizDto)
    {
        string? userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("UserId is not provided");
        }
        
        Quiz quiz = _quizService.CreateQuiz(
            userId,
            createQuizDto.DifficultyId,
            createQuizDto.TagId,
            createQuizDto.Name,
            createQuizDto.Description,
            createQuizDto.MinimumGrade,
            createQuizDto.TestDuration,
            createQuizDto.TotalQuestion
        );

        return quiz;
    }
    
    public async Task InsertQuiz(Quiz quiz)
    {
        await _quizRepository.InsertQuiz(quiz);
    }
}