using QuestionService.Domain.Entities;
using QuestionService.Domain.Services.Interfaces;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Domain.Services.Impl;

public class QuestionServiceImpl : IQuestionService
{
    public Question CreateQuestion(string createdBy, string answerType,  double point, Answer answer, List<int>? correctAnswerIndex, string questionImage, string questionText)
    {
        return new Question(
            createdBy,
            answerType,
            point,
            answer,
            correctAnswerIndex,
            questionImage,
            questionText: questionText
        );
    }
}