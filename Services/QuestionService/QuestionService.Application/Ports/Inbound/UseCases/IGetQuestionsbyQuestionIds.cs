using QuestionService.Application.Dtos;
using QuestionService.Domain.Entities;

namespace QuestionService.Application.Ports.Inbound.UseCases;

public interface IGetQuestionsbyQuestionIds
{
    public Task<List<QuestionRequestDto>> GetQuestionsByIds(List<string> questionIds);
}