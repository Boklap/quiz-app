using QuizService.Application.Dtos;

namespace QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;

public interface IAddQuestionToQuizDetailUseCase
{
    Task Execute(AddQuestionToQuizDto addQuestionToQuizDto);
    Task<bool> IsQuizExist(string quizId);
    Task<List<string>?> IsQuestionExistInQuiz(string quizId, List<string> questionIds);
    Task InsertQuestionToQuizDetail(string quizId, List<string> questions);
}