using MongoDB.Bson;
using QuestionService.Application.Dtos;
using QuestionService.Application.Mappers;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Shared.Abstracts;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Application.UseCases;

public class GetQuestionByIdUseCaseImpl : IGetQuestionById
{
    private IQuestionRepository _repository;

    public GetQuestionByIdUseCaseImpl(IQuestionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<QuestionDto?> Execute(string questionId)
    {
        ObjectId id;
        try
        {
            id = ObjectId.Parse(questionId);
        }

        catch (Exception)
        {
            throw new InvalidAttributeException("QuestionId is invalid");
        }
        
        Question? question = await GetQuestionById(id);
        if (question is null) return null!;

        return QuestionMapper.ToDto(question);
    }

    public async Task<Question?> GetQuestionById(ObjectId questionId)
    {
        return await _repository.FindQuestionById(questionId);
    }
}