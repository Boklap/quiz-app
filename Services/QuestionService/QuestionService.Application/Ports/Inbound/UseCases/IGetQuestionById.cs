using MongoDB.Bson;
using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetQuestionById
{
    Task<QuestionDto?> Execute(string questionId);
    Task<Question?> GetQuestionById(ObjectId questionId);
}