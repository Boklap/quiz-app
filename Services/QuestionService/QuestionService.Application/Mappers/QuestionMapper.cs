using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Mappers;

public static class QuestionMapper
{
    public static QuestionDto ToDto(Question question)
    {
        return new QuestionDto()
        {
            Id = question.Id.ToString(),
            Status = question.Status,
            AnswerType = question.AnswerType,
            Point = question.Point.Value,
            QuestionText = question.QuestionText,
            QuestionImage = question.QuestionImage,
            AnswerImages = question.Answer.ImagePath,
            Answers = question.Answer.AnswerList,
            CorrectAnswerIndex = question.CorrectAnswerIndex
        };
    }
}