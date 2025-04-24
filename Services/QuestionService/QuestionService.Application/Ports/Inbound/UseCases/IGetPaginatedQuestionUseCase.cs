using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetPaginatedQuestionUseCase
{
    public Task<List<QuestionDto>> Execute(int page, int pageSize);
    public Task<List<Question>> GetPaginatedQuestions(int page, int pageSize);
}