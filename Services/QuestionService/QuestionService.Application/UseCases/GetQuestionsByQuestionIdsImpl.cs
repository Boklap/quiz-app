using QuestionService.Application.Dtos;
using QuestionService.Application.Mappers;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;

namespace QuestionService.Application.UseCases;

public class GetQuestionsByQuestionIdsImpl : IGetQuestionsbyQuestionIds
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionsByQuestionIdsImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<List<QuestionRequestDto>> GetQuestionsByIds(List<string> questionIds)
    {
        List<Question>? questions = await _questionRepository.FindQuestionByQuestionIds(questionIds);
        if(questions == null) return new List<QuestionRequestDto>();
        
        List<QuestionRequestDto> questionRequestDtos = questions
            .Select(QuestionRequestMapper.ToDto)
            .ToList();
        
        return questionRequestDtos;
    }
}