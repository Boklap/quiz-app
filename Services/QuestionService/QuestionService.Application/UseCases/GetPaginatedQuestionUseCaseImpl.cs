using QuestionService.Application.Dtos;
using QuestionService.Application.Mappers;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetPaginatedQuestionUseCaseImpl : IGetPaginatedQuestionUseCase
{
    private readonly IQuestionRepository _questionRepository;

    public GetPaginatedQuestionUseCaseImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<List<QuestionDto>> Execute(int page, int pageSize)
    {
        List<Question> questions =  await GetPaginatedQuestions(page, pageSize);
        if(!questions.Any()) return new List<QuestionDto>();
     
        return questions.Select(QuestionMapper.ToDto).ToList();
    }

    public async Task<List<Question>> GetPaginatedQuestions(int page, int pageSize)
    {
        return await _questionRepository.GetAllQuestions(page, pageSize);
    }
}