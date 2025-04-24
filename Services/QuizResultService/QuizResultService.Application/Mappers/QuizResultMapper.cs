using QuizResultService.Application.Dtos;
using QuizResultService.Domain.Entities;

namespace QuizResultService.Application.Mappers;

public static class QuizResultMapper
{
    public static QuizResultDto ToDto(QuizResult quizResult)
    {
        return new QuizResultDto()
        {
            Quiz = quizResult.Quiz,
            QuizResultStatus = quizResult.Status,
            Reason = quizResult.Reason,
            Schedule = quizResult.Schedule,
            Score = quizResult.Score.Value
        };
    }
}