using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;
using QuestionService.Domain.ValueObjects.Question;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface ICreateQuestionUseCase
{
    Task Execute(CreateQuestionDto createQuestionDto);
    Task<Question> CreateQuestion(CreateQuestionDto createQuestionDto);
    Task InsertQuestion(Question question);
    Task<Answer> DeserializeAnswer(CreateQuestionDto createQuestionDto);
}