using QuizService.Domain.Entities;

namespace QuizService.Domain.Services.Interfaces;

public interface IQuizService
{
    Quiz CreateQuiz(
        string createdBy,
        string difficultyId,
        string tagId,
        string name, 
        string description,
        int minimumGrade,
        int testDuration,
        int totalQuestion);
    
    Quiz CreateQuiz(
        string id,
        string createdBy,
        string difficultyId,
        string tagId,
        string name, 
        string description,
        int minimumGrade,
        int testDuration,
        int totalQuestion);
    
    string GenerateQuizId();
}