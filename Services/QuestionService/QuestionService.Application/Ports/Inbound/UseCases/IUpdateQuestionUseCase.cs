using MongoDB.Bson;
using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IUpdateQuestionUseCase
{
    public Task Execute(UpdateQuestionDto questionDto);
    public Task<Question?> IsQuestionExist(ObjectId questionId);
    public Task<Answer> DeserializeAnswer(UpdateQuestionDto createQuestionDto);
    public Task UpdateQuestion(Question question);

}