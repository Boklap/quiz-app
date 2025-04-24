using MongoDB.Bson;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Application.UseCases;

public class SubmitQuestionToBeReviewedImpl : ISubmitQuestionToBeReviewed
{
    private readonly IQuestionRepository _questionRepository;

    public SubmitQuestionToBeReviewedImpl(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task Execute(string questionId)
    {
        ObjectId id = ObjectId.Parse(questionId);
        Question? question = await IsQuestionExist(id);

        if (question == null)
        {
            throw new EntityNotFoundException("Question not found");
        }
        
        await UpdateQuestionStatus(question);
    }

    public async Task<Question?> IsQuestionExist(ObjectId questionId)
    {
        Question? question = await _questionRepository.FindQuestionById(questionId);
        return question;
    }

    public async Task UpdateQuestionStatus(Question question)
    {
        question.Status = "Review";
        question.UpdatedAt = DateTime.Now;
        await _questionRepository.UpdateQuestion(question);
    }
}