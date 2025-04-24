using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetAnswerTypeUseCaseImpl : IGetAnswerTypesUseCase
{
    private readonly IAnswerTypeRepository _answerTypeRepository;

    public GetAnswerTypeUseCaseImpl(IAnswerTypeRepository answerTypeRepository)
    {
        _answerTypeRepository = answerTypeRepository;
    }
    
    public async Task<List<string>> Execute()
    {
        List<AnswerType>? answerTypes = await FetchAnswerTypes();
        if(answerTypes == null) return new List<string>();
        
        return answerTypes.Select(answerType => answerType.Name).ToList();
    }

    public async Task<List<AnswerType>?> FetchAnswerTypes()
    {
        return await _answerTypeRepository.FetchAnswerType();
    }
}