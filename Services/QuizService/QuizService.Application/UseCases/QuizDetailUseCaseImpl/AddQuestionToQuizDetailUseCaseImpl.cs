using QuizService.Application.Dtos;
using QuizService.Application.Ports.Inbound.UseCases.QuizDetailUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;
using QuizService.Shared.Exceptions;

namespace QuizService.Application.UseCases.QuizDetailUseCaseImpl;

public class AddQuestionToQuizDetailUseCaseImpl : IAddQuestionToQuizDetailUseCase
{
    private readonly IQuizDetailRepository _quizDetailrepository;
    private readonly IQuizRepository _quizRepository;

    public AddQuestionToQuizDetailUseCaseImpl(
        IQuizDetailRepository quizDetailrepository,
        IQuizRepository quizRepository)
    {
        _quizDetailrepository = quizDetailrepository;
        _quizRepository = quizRepository;
    }


    public async Task Execute(AddQuestionToQuizDto addQuestionToQuizDto)
    {
        if (!await IsQuizExist(addQuestionToQuizDto.QuizId))
        {
            throw new EntityNotFoundException("Quiz is not found");
        }

        List<string>? invalidQuestionIds =
            await IsQuestionExistInQuiz(addQuestionToQuizDto.QuizId, addQuestionToQuizDto.Questions);
        
        if (invalidQuestionIds != null && invalidQuestionIds.Count > 0)
        {
            throw new EntityExistException($"Question with id {invalidQuestionIds} already exists");
        }
        
        await InsertQuestionToQuizDetail(addQuestionToQuizDto.QuizId, addQuestionToQuizDto.Questions);
    }

    public async Task<bool> IsQuizExist(string quizId)
    {
        Quiz? quiz = await _quizRepository.FindQuizById(quizId);
        if (quiz is null) return false;

        return true;
    }

    public async Task<List<string>?> IsQuestionExistInQuiz(string quizId, List<string> questionIds)
    {
        return await _quizDetailrepository.GetInvalidQuestionIds(quizId, questionIds);
    }

    public async Task InsertQuestionToQuizDetail(string quizId, List<string> questions)
    {
        await _quizDetailrepository.InsertQuestion(quizId, questions);
    }
}