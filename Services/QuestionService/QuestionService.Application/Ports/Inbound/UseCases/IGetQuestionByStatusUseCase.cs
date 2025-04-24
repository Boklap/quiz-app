using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetQuestionByStatusUseCase
{
    public Task<List<QuestionDto>> Execute(string status, int page, int pageSize);
    public Task<List<Question>> GetQuestionByStatus(string status, int page, int pageSize);
}