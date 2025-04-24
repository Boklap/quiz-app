using QuizService.Application.Dtos;
using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class UpdateQuizUseCaseImpl : IUpdateQuizUseCase
{
    private readonly IQuizRepository _quizRepository;
    
    public UpdateQuizUseCaseImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task Execute(UpdateQuizDto quizDto)
    {
        Quiz? quiz = await IsQuizExist(quizDto.Id);
        if (quiz == null)
        {
            throw new EntityNotFoundException("Quiz not found");
        }

        quiz.UpdateQuiz(
            quizDto.DifficultyId,
            quizDto.TagId,
            quizDto.Name,
            quizDto.Description,
            quizDto.MinimumGrade,
            quizDto.TestDuration,
            quizDto.TotalQuestion
            );
        
        await UpdateQuiz(quiz);
    }

    public async Task<Quiz?> IsQuizExist(string quizId)
    {
        return await _quizRepository.FindQuizById(quizId);
    }

    public async Task UpdateQuiz(Quiz quiz)
    {
        await _quizRepository.UpdateQuiz(quiz);
    }
}