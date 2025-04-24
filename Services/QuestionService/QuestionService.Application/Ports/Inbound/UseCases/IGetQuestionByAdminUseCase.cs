using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetQuestionByAdminUseCase
{
    public Task<List<QuestionDto>> Execute(string userId, int page, int pageSize);
    public Task<List<Question>> GetQuestionByUserId(string userId, int page, int pageSize);
}