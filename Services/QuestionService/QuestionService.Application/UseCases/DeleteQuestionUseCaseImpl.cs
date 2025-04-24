using MongoDB.Bson;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Application.UseCases;

public class DeleteQuestionUseCaseImpl : IDeleteQuestionUseCase
{
    private readonly IQuestionRepository _questionRepository;

    public DeleteQuestionUseCaseImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task Execute(string questionId)
    {
        Question? question = await IsQuestionExist(questionId);
        if (question == null)
        {
            throw new EntityNotFoundException("Question not found");
        }

        await DeleteQuestion(question);
    }

    public async Task<Question?> IsQuestionExist(string questionId)
    {
        ObjectId id = new ObjectId(questionId);
        Question? question = await _questionRepository.FindQuestionById(id);
        return question;
    }

    public async Task DeleteQuestion(Question question)
    {
        question.IsDeleted = true;
        question.DeletedAt = DateTime.Now;

        await _questionRepository.UpdateQuestion(question);
    }
}