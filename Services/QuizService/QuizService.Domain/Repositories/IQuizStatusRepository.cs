namespace QuizService.Domain.Repositories;

public interface IQuizStatusRepository
{
    Task<string?> FindQuizStatusNameById(string quizStatusId);
}