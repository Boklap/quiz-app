using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using QuestionService.Application.Dtos;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Domain.Services.Interfaces;
using QuestionService.Domain.ValueObjects.Question;
using QuestionService.Shared.Exceptions;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace QuestionService.Application.UseCases;

public class CreateQuestionUseCaseImpl : ICreateQuestionUseCase
{
    private readonly IQuestionRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IQuestionService _questionService;

    public CreateQuestionUseCaseImpl(
        IQuestionRepository repository, 
        IHttpContextAccessor httpContextAccessor,
        IQuestionService questionService)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        _questionService = questionService;
    }
    
    public async Task Execute(CreateQuestionDto createQuestionDto)
    {
        Question question = await CreateQuestion(createQuestionDto);
        await InsertQuestion(question);
    }

    public async Task<Question> CreateQuestion(CreateQuestionDto createQuestionDto)
    {
        string? userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();

        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("UserId is not provided");
        }

        if (string.IsNullOrEmpty(createQuestionDto.QuestionText) && createQuestionDto.QuestionImage == null)
        {
            throw new InvalidAttributeException("Question cannot be empty");
        }
        
        Answer answer = await DeserializeAnswer(createQuestionDto);
        string questionImage = "";
        string imagePath = Environment.GetEnvironmentVariable("QUESTION_IMAGE_PATH");

        if (createQuestionDto.QuestionImage != null)
        {
            var imageName = $"{Guid.NewGuid()}_{createQuestionDto.QuestionImage.FileName}";
            var filePath = Path.Combine(imagePath, imageName);
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await createQuestionDto.QuestionImage.CopyToAsync(stream);
            }
                
            questionImage = $"{filePath}";
        }
        
        Question question = _questionService.CreateQuestion(
        userId,
            createQuestionDto.AnswerType,
            createQuestionDto.Point,
            answer,
            createQuestionDto.CorrectAnswerIndex,
            questionImage,
            createQuestionDto.QuestionText
        );

        return question;
    }

    public async Task<Answer> DeserializeAnswer(CreateQuestionDto createQuestionDto)
    {
        if (createQuestionDto.AnswerType != "essay" && createQuestionDto.Answers.Count == 0)
        {
            throw new InvalidAttributeException("Answers cannot be empty");
        }
        
        if (createQuestionDto.AnswerType != "essay")
        {
            List<string> imageNames = createQuestionDto.ImageNames;
            List<IFormFile>? answerImages = createQuestionDto.AnswerImages;
            
            List<string> imagePaths = new List<string>();
            string imagePath = Environment.GetEnvironmentVariable("ANSWER_IMAGE_PATH");

            if (imageNames.Count > 0)
            {
                for(int i = 0; i < imageNames.Count; i++)
                {
                    string? filePath = null;
                    if (!string.IsNullOrEmpty(imageNames[i]))
                    {
                        var name = $"{Guid.NewGuid()}_{imageNames[i]}";
                        filePath = Path.Combine(imagePath, name);

                        if (answerImages != null && i > createQuestionDto.Answers.Count && answerImages.Count > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await answerImages[i].CopyToAsync(stream);
                            }
                        }
                    }
                    
                    imagePaths.Add(filePath);
                }
            }

            foreach (var path in imagePaths)
            {
                Console.WriteLine(path);
            }
            
            return new Answer
            {
                AnswerList = createQuestionDto.Answers,
                ImagePath = imagePaths
            };
        }

        return new Answer
        {
            AnswerList = new List<string>(),
            ImagePath = new List<string>()
        };
    }

    public async Task InsertQuestion(Question question)
    {
        await _repository.InsertQuestion(question);
    }
}