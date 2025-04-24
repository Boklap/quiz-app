using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class RejectQuizUseCaseImpl : IRejectQuizUseCase
{
    private readonly IQuizRepository _quizRepository;

    public RejectQuizUseCaseImpl(IQuizRepository quizRepository)
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

        await RejectQuiz(quiz);
    }

    public async Task<Quiz?> IsQuizExist(string quizId)
    {
        return await _quizRepository.FindQuizById(quizId);
    }

    public async Task RejectQuiz(Quiz quiz)
    {
        quiz.QuizStatusId = "1";
        await _quizRepository.UpdateQuiz(quiz);
    }
}