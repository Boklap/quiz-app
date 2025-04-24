using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Services.Interfaces;
using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Domain.Services.Impl;

public class QuizResultServiceImpl : IQuizResultService
{
    public QuizResult CreateQuizResult(string participantId, Schedule schedule, Quiz quiz, Score score)
    {
        return new QuizResult()
        {
            ParticipantId = participantId,
            Schedule = schedule,
            Score = score,
            Quiz = quiz,
        };
    }
}