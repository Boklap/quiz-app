using MongoDB.Bson;
using QuizResultService.Application.Dtos;
using QuizResultService.Application.Ports.Inbound.Admin;
using QuizResultService.Domain.Entities;
using QuizResultService.Domain.Repositories;
using QuizResultService.Shared.Exceptions;

namespace QuizResultService.Application.UseCases.Admin;

public class GradeQuizResultUseCaseImpl : IGradeQuizResultUseCase
{
    private readonly IQuizResultRepository  _quizResultRepository;

    public GradeQuizResultUseCaseImpl(IQuizResultRepository quizResultRepository)
    {
        _quizResultRepository = quizResultRepository;
    }
    
    public async Task Execute(UpdateQuizResultDto updateQuizResultDto)
    {
        QuizResult? quizResult = await IsQuizExist(updateQuizResultDto.QuizResultId);
        if (quizResult == null)
        {
            throw new EntityNotFoundException("Quiz result not found");
        }
        
        quizResult.Update(updateQuizResultDto.Score, updateQuizResultDto.Reason);
        await UpdateQuizResult(quizResult);
    }

    public async Task<QuizResult?> IsQuizExist(string quizId)
    {
        ObjectId id;
        try
        {
            id = new ObjectId(quizId);
        }

        catch (Exception)
        {
            throw new InvalidAttributeException("Quiz result id is invalid");
        }
        
        return await _quizResultRepository.FindQuizResultByQuizResultId(id);
    }

    public async Task UpdateQuizResult(QuizResult quizResult)
    {
        await _quizResultRepository.UpdateQuizResult(quizResult);
    }
}