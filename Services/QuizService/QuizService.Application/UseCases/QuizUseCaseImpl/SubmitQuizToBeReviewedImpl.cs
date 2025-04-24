using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class SubmitQuizToBeReviewedImpl : ISubmitQuizToBeReviewed
{
    private readonly IQuizRepository _quizRepository;

    public SubmitQuizToBeReviewedImpl(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task Execute(string quizId)
    {
        Quiz? quiz = await IsQuizExist(quizId);
        if (quiz == null)
        {
            throw new EntityNotFoundException("Quiz not found");
        }

        await SubmitQuiz(quiz);
    }

    public async Task<Quiz?> IsQuizExist(string quizId)
    {
        return await _quizRepository.FindQuizById(quizId);
    }

    public async Task SubmitQuiz(Quiz quiz)
    {
        quiz.QuizStatusId = "2";
        await _quizRepository.UpdateQuiz(quiz);
    }
}