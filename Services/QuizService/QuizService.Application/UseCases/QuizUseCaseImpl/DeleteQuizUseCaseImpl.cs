using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class DeleteQuizUseCaseImpl : IDeleteQuizUseCase
{

    private readonly IQuizRepository _quizRepository;

    public DeleteQuizUseCaseImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task Execute(string quizId)
    {
        Quiz? quiz = await IsQuizExist(quizId);
        if (quiz == null)
        {
            throw new EntityNotFoundException("Quiz is not exist");
        }

        await DeleteQuiz(quiz);
    }

    public async Task<Quiz?> IsQuizExist(string quizId)
    {
        return await _quizRepository.FindQuizById(quizId);
        
    }

    public async Task DeleteQuiz(Quiz quiz)
    {
        quiz.IsDeleted = true;
        quiz.DeletedAt = DateTime.UtcNow;
        await _quizRepository.UpdateQuiz(quiz);
    }
}