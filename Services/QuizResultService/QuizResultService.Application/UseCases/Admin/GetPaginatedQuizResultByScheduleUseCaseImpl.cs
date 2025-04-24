using QuizResultService.Application.Dtos;
using QuizResultService.Application.Mappers;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;

namespace QuizResultService.Application.UseCases.Admin;

public class GetPaginatedQuizResultByScheduleUseCaseImpl : IGetPaginatedQuizResultByScheduleUseCase
{
    private readonly IQuizResultRepository  _quizResultRepository;

    public GetPaginatedQuizResultByScheduleUseCaseImpl(IQuizResultRepository quizResultRepository)
    {
        _quizResultRepository = quizResultRepository;
    }
    
    public async Task<List<QuizResultDto>> Execute(string quizId, int page, int pageSize)
    {
        List<QuizResult>? quizResults = await GetQuizResultBySchedule(quizId, page, pageSize);
        if(quizResults == null) return new List<QuizResultDto>();

        return quizResults.Select(QuizResultMapper.ToDto).ToList();
    }

    public async Task<List<QuizResult>?> GetQuizResultBySchedule(string scheduleId, int page, int pageSize)
    {
        return await _quizResultRepository.FindQuizResultByScheduleId(scheduleId, page, pageSize);
    }
}