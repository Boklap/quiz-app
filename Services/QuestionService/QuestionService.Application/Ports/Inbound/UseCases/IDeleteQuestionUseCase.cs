using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IDeleteQuestionUseCase
{
    public Task Execute(string questionId);
    public Task<Question?> IsQuestionExist(string questionId);
    public Task DeleteQuestion(Question question);
}