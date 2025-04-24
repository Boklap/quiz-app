using QuestionService.Domain.Entities;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Domain.Services.Interfaces;

public interface IQuestionService
{
    Question CreateQuestion(string createdBy, string answerType,  double point, Answer answer, List<int>? correctAnswerIndex, string questionImages, string questionText);
}