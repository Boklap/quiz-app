using QuizService.Application.Dtos;
using QuizService.Domain.Entities;

namespace QuizService.Application.Mappers;

public static class QuizMapper
{
    public static QuizDto ToDto(Quiz quiz)
    {
        return new QuizDto
        {
            Id = quiz.Id,
            Name = quiz.Name.Value,
            Description = quiz.Description.Value,
            MinimumGrade = quiz.MinimumGrade.Value,
            TestDuration = quiz.TestDuration.Value,
            TotalQuestion = quiz.TotalQuestion.Value
        };
    }
        
}