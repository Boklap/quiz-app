using Microsoft.AspNetCore.Http;
using QuizResultService.Application.Ports.Inbound.Participant;
using QuizResultService.Domain.Repositories;
using QuizResultService.Domain.ValueObjects.QuizResultAnswer;
using QuizResultService.Shared.Exceptions;

namespace QuizResultService.Application.UseCases.Participant;

public class GetPaginatedQuestionByQuizUseCaseImpl : IGetPaginatedQuestionByQuizUseCase
{
    private readonly IQuizResultQuestionRepository _quizResultQuestionRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetPaginatedQuestionByQuizUseCaseImpl(
        IQuizResultQuestionRepository quizResultQuestionRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _quizResultQuestionRepository = quizResultQuestionRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<List<Question>> Execute(string quizId, int page, int pageSize)
    {
        var participantId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();

        if (string.IsNullOrEmpty(participantId))
        {
            throw new UnAuthorizedException("User is not authenticated");
        }
        
        List<Question>? questions = await GetPaginatedQuestionByQuiz(participantId, quizId, page, pageSize);
        if(questions == null) return new List<Question>();
        
        return questions;
    }

    public async Task<List<Question>?> GetPaginatedQuestionByQuiz(string participantId, string quizId, int page, int pageSize)
    {
        return await _quizResultQuestionRepository.GetParticipantQuizByQuizId(participantId, quizId, page, pageSize);
    }
}