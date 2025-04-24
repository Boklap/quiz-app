using QuizService.Application.Dtos;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;

namespace QuizService.Application.Mappers;

public static class QuestionMapper
{
    public static QuestionDto ToDto(Question question)
    {
        return new QuestionDto()
        {
            Id = question.Id,
            Status = "",
            AnswerType = question.AnswerType,
            Point = question.Point,
            QuestionText = question.QuestionText,
            QuestionImage = question.QuestionImages,
            Answers = question.Answer.AnswerList,
            AnswerImages = question.Answer.ImagePath,
            CorrectAnswerIndex = question.CorrectAnswerIdx
        };
    }
}