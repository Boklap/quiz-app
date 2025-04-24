using MongoDB.Bson;
using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface ISubmitQuestionToBeReviewed
{
    public Task Execute(string questionId);
    public Task<Question?> IsQuestionExist(ObjectId questionId);
    public Task UpdateQuestionStatus(Question question);
}