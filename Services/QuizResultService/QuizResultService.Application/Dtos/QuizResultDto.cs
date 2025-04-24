using QuizResultService.Domain.Entities;
using QuizResultService.Domain.ValueObjects.QuizResult;

namespace QuizResultService.Application.Dtos;

public class QuizResultDto
{
    public Schedule Schedule;
    public Quiz Quiz;
    public string QuizResultStatus;
    public double Score;
    public string Reason;
}