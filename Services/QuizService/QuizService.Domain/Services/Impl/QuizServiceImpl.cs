using QuizService.Domain.Entities;
using QuizService.Domain.Services.Interfaces;
using QuizService.Domain.ValueObjects.Quiz;

namespace QuizService.Domain.Services.Impl;

public class QuizServiceImpl : IQuizService
{
    public Quiz CreateQuiz(
        string createdBy, 
        string difficultyId,
        string tagId,
        string name, 
        string description,
        int minimumGrade,
        int testDuration,
        int totalQuestion
        )
    {
        var quiz = new Quiz(
            id: GenerateQuizId(),
            createdBy: createdBy,
            difficultyId: difficultyId,
            tagId: tagId,
            name: new Name(name),
            description: new Description(description),
            minimumGrade: new MinimumGrade(minimumGrade),
            testDuration: new TestDuration(testDuration),
            totalQuestion: new TotalQuestion(totalQuestion)
        );
            
        return quiz;
    }
    
    public Quiz CreateQuiz(
        string id,
        string createdBy, 
        string difficultyId,
        string tagId,
        string name, 
        string description,
        int minimumGrade,
        int testDuration,
        int totalQuestion
    )
    {
        var quiz = new Quiz(
            id: id,
            createdBy: createdBy,
            difficultyId: difficultyId,
            tagId: tagId,
            name: new Name(name),
            description: new Description(description),
            minimumGrade: new MinimumGrade(minimumGrade),
            testDuration: new TestDuration(testDuration),
            totalQuestion: new TotalQuestion(totalQuestion)
        );
            
        return quiz;
    }

    public string GenerateQuizId()
    {
        return Guid.NewGuid().ToString();
    }
}