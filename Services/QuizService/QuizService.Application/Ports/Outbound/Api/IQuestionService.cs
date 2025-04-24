using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Application.Ports.Outbound.Api;

public interface IQuestionService
{
    Task<List<Question>?> GetQuestionsByids(List<string> questionIds);
}