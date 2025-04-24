using QuizService.Application.Dtos;
using QuizService.Application.Mappers;
using QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;
using QuizService.Application.Ports.Outbound.Api;
using QuizService.Domain.Repositories;
using QuizService.Domain.ValueObjects.FinalizedQuizDetail;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizDetailUseCaseImpl;

public class GetQuestionsByQuizIdUseCaseImpl : IGetQuestionsByQuizIdUseCase
{
    private readonly IQuizDetailRepository _quizDetailRepository;
    private readonly IQuestionService _questionService;

    public GetQuestionsByQuizIdUseCaseImpl(IQuizDetailRepository quizDetailRepository, IQuestionService questionService)
    {
        _quizDetailRepository = quizDetailRepository;
        _questionService = questionService;
    }

    public async Task<List<QuestionDto>> Execute(string quizId)
    {
        List<string>? questionIds = await GetQuestionIdsByQuizId(quizId);

        if (questionIds is null)
        {
            throw new EntityNotFoundException("No question found");
        }

        List<Question>? questions = await GetQuestionByids(questionIds);

        if (questions is null)
        {
            return new List<QuestionDto>();
        }
        
        List<QuestionDto> questionDtos = questions.Select(q => QuestionMapper.ToDto(q)).ToList();
        
        return questionDtos;
    }

    public async Task<List<string>?> GetQuestionIdsByQuizId(string quizId)
    {
        var result =  await _quizDetailRepository.GetQuestionIdsByQuizId(quizId);
        return result;
    }

    public async Task<List<Question>?> GetQuestionByids(List<string> questionId)
    {
        return await _questionService.GetQuestionsByids(questionId);
    }
}