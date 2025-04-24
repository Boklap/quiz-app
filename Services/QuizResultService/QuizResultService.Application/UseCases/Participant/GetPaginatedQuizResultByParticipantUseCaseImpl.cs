using Microsoft.AspNetCore.Http;
using QuizResultService.Application.Dtos;
using QuizResultService.Application.Mappers;
using QuizResultService.Application.Ports.Inbound.Participant;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;
using QuizResultService.Shared.Exceptions;

namespace QuizResultService.Application.UseCases.Participant;

public class GetPaginatedQuizResultByParticipantUseCaseImpl : IGetPaginatedQuizResultByParticipantUseCase
{
    private readonly IQuizResultRepository  _quizResultRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetPaginatedQuizResultByParticipantUseCaseImpl(
        IQuizResultRepository quizResultRepository,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _quizResultRepository = quizResultRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<List<QuizResultDto>> Execute(int page, int pageSize)
    {
        var participantId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();

        if (string.IsNullOrEmpty(participantId))
        {
            throw new UnAuthorizedException("User is not authenticated");
        }
        
        List<QuizResult>? quizResults = await GetQuizResultByParticipant(participantId, page, pageSize);
        if(quizResults == null) return new List<QuizResultDto>();

        return quizResults.Select(QuizResultMapper.ToDto).ToList();
    }

    public async Task<List<QuizResult>?> GetQuizResultByParticipant(string participantId, int page, int pageSize)
    {
        return await _quizResultRepository.FindQuizResultByParticipantId(participantId, page, pageSize);
    }
}