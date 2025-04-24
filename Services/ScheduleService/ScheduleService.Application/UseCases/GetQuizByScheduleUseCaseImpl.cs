using ScheduleService.Application.Dtos;
using ScheduleService.Application.Ports.Inbound;
using ScheduleService.Application.Ports.Outbound;
using ScheduleService.Domain.Repositories;

namespace ScheduleService.Application.UseCases;

public class GetQuizByScheduleUseCaseImpl : IGetQuizByScheduleUseCase
{
    private readonly IQuizService _quizService;
    private readonly IScheduleRepository _repository;

    public GetQuizByScheduleUseCaseImpl(IQuizService quizService, IScheduleRepository repository)
    {
        _quizService = quizService;
        _repository = repository;
    }
    
    public async Task<List<QuizDto>> Execute(DateTime startDate, DateTime endDate)
    {
        List<string>? quizIds = await _repository.GetQuizIdBySchedule(startDate, endDate);
        
        if (quizIds is null || quizIds.Count == 0)
        {
            return new List<QuizDto>();
        }
        
        List<QuizDto> quizDtos = await _quizService.GetQuizByIds(quizIds);
        return quizDtos!;
    }
}