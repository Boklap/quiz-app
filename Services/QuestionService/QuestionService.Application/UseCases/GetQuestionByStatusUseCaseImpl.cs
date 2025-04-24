using QuestionService.Application.Dtos;
using QuestionService.Application.Mappers;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetQuestionByStatusUseCaseImpl : IGetQuestionByStatusUseCase
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionByStatusUseCaseImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<List<QuestionDto>> Execute(string status, int page, int pageSize)
    {
        List<Question> questions = await GetQuestionByStatus(status, page, pageSize);
        if(!questions.Any()) return new List<QuestionDto>();
     
        return questions.Select(QuestionMapper.ToDto).ToList();
    }

    public async Task<List<Question>> GetQuestionByStatus(string status, int page, int pageSize)
    {
        string statusLower = status.ToLower();
        return await _questionRepository.FindQuestionByStatus(status, page, pageSize);
    }
}