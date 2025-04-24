using QuestionService.Application.Dtos;
using QuestionService.Application.Mappers;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetQuestionByAdminUseCaseImpl : IGetQuestionByAdminUseCase
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionByAdminUseCaseImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<List<QuestionDto>> Execute(string userId, int page, int pageSize)
    {
        List<Question> questions =  await GetQuestionByUserId(userId, page, pageSize);
        if(!questions.Any()) return new List<QuestionDto>();
     
        return questions.Select(QuestionMapper.ToDto).ToList();
    }

    public async Task<List<Question>> GetQuestionByUserId(string userId, int page, int pageSize)
    {
        return await _questionRepository.FindQuestionByUserId(userId, page, pageSize);
    }
}