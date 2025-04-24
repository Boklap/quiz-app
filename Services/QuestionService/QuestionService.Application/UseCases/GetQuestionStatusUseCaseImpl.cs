using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetQuestionStatusUseCaseImpl : IGetQuestionStatusUseCase
{
    private readonly IQuestionStatusRepository _repository;

    public GetQuestionStatusUseCaseImpl(IQuestionStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<string>> Execute()
    {
        List<QuestionStatus>? questionStatus = await FetchQuestionStatus();
        if(questionStatus == null) return new List<string>();
        
        return questionStatus.Select(qs => qs.Name).ToList();
    }

    public async Task<List<QuestionStatus>?> FetchQuestionStatus()
    {
        return await _repository.FetchQuestionStatus();
    }
}