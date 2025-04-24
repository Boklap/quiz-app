using QuizService.Application.Ports.Inbound.UseCases;
using QuizService.Application.Ports.Inbound.UseCases.QuizUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizUseCaseImpl;

public class FinalizeQuizUseCaseImpl : IFinalizeQuizUseCase
{
    private readonly IQuizRepository _quizRepository;
    // private readonly IFinalizedQuizRepository _finalizedQuizRepository;
    

    public FinalizeQuizUseCaseImpl(IQuizRepository quizRepository
        // IFinalizedQuizRepository finalizedQuizRepository
        )
    {
        _quizRepository = quizRepository;
        // _finalizedQuizRepository = finalizedQuizRepository;
    }
    
    public async Task Execute(string quizId)
    {
        Quiz? quiz = await IsQuizExist(quizId);
        if (quiz == null)
        {
            throw new EntityNotFoundException("Quiz not found");
        }

        await FinalizeQuiz(quiz);
    }

    public async Task<Quiz?> IsQuizExist(string quizId)
    {
        return await _quizRepository.FindQuizById(quizId);
    }

    public async Task FinalizeQuiz(Quiz quiz)
    {
        try
        {
            quiz.QuizStatusId = "3";
            await _quizRepository.UpdateQuiz(quiz);
        }

        catch (Exception)
        {
            quiz.QuizStatusId = "2";
            await _quizRepository.UpdateQuiz(quiz);
        }
    }
}