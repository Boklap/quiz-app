using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Mappers;

public static class QuestionRequestMapper
{
    public static QuestionRequestDto ToDto(Question question)
    {
        return new QuestionRequestDto()
        {
            Id = question.Id.ToString(),
            AnswerType = question.AnswerType,
            Point = question.Point.Value,
            QuestionText = question.QuestionText,
            QuestionImage = question.QuestionImage,
            Answer = question.Answer,
            CorrectAnswerIdx = question.CorrectAnswerIndex
        };
    }
}