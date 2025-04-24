using MongoDB.Bson;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IFinalizeQuestionUseCase
{
    Task Execute(string questionId);
    Task<Question?> IsQuestionExist(ObjectId questionId);
    Task FinalizeQuestion(Question question);
}