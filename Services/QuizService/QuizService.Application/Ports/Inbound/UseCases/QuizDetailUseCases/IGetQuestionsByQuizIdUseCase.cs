using QuizService.Application.Dtos;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;

public interface IGetQuestionsByQuizIdUseCase
{
    Task<List<QuestionDto>> Execute(string quizId);
    Task<List<string>?> GetQuestionIdsByQuizId(string quizId);
    Task<List<Question>?> GetQuestionByids(List<string> questionId);
}