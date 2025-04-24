using QuizResultService.Application.Dtos;
using QuizResultService.Application.Mappers;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;

namespace QuizResultService.Application.UseCases.Admin;

public class GetPaginatedQuizResultByQuizUseCaseImpl : IGetPaginatedQuizResultByQuizUseCase
{
    private readonly IQuizResultRepository  _quizResultRepository;

    public GetPaginatedQuizResultByQuizUseCaseImpl(IQuizResultRepository quizResultRepository)
    {
        _quizResultRepository = quizResultRepository;
    }
    
    public async Task<List<QuizResultDto>> Execute(string quizId, int page, int pageSize)
    {
        List<QuizResult>? quizResults = await GetQuizResultByQuiz(quizId, page, pageSize);
        if(quizResults == null) return new List<QuizResultDto>();

        return quizResults.Select(QuizResultMapper.ToDto).ToList();
    }

    public async Task<List<QuizResult>?> GetQuizResultByQuiz(string quizId, int page, int pageSize)
    {
        return await _quizResultRepository.FindQuizResultByQuizId(quizId, page, pageSize);
    }
}