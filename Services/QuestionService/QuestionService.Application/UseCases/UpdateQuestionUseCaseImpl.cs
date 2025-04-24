using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Newtonsoft.Json;
using QuestionService.Application.Dtos;
using QuestionService.Application.Ports.Inbound.UseCases;
using QuestionService.Domain.Entities;
using QuestionService.Domain.Repositories;
using QuestionService.Domain.ValueObjects.Question;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Application.UseCases;

public class UpdateQuestionUseCaseImpl : IUpdateQuestionUseCase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateQuestionUseCaseImpl(IQuestionRepository questionRepository, IHttpContextAccessor httpContextAccessor)
    {
        _questionRepository = questionRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task Execute(UpdateQuestionDto questionDto)
    {
        ObjectId questionId;
        try
        {
            questionId = ObjectId.Parse(questionDto.Id);
        }
        
        catch (FormatException)
        {
            throw new InvalidAttributeException("Invalid Id format");
        }
        
        Question? question = await IsQuestionExist(questionId);

        if (question == null)
        {
            throw new EntityNotFoundException("Question not found");
        }
        
        Answer answer = await DeserializeAnswer(questionDto);
        string questionImage = "";
        string imagePath = Environment.GetEnvironmentVariable("QUESTION_IMAGE_PATH");

        if (questionDto.QuestionImage != null)
        {
                var imageName = $"{Guid.NewGuid()}_{questionDto.QuestionImage.FileName}";
                var filePath = Path.Combine(imagePath, imageName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await questionDto.QuestionImage.CopyToAsync(stream);
                }
                
                questionImage = $"{filePath}";
        }
        
        question.UpdateQuestion(
            questionDto.QuestionText,
            questionDto.AnswerType,
            questionDto.QuestionStatus,
            questionDto.Point,
            answer,
            questionDto.CorrectAnswerIndex,
            questionImage
        );
        
        await UpdateQuestion(question);
    }

    public async Task<Question?> IsQuestionExist(ObjectId questionId)
    {
        Question? question = await _questionRepository.FindQuestionById(questionId);
        return question;
    }

    public async Task<Answer> DeserializeAnswer(UpdateQuestionDto updateQuestionDto)
    {
        var form = _httpContextAccessor.HttpContext?.Request.Form;
        
        if (updateQuestionDto.AnswerType != "essay" && updateQuestionDto.Answers?.Count == 0)
        {
            throw new InvalidAttributeException("Answers cannot be empty");
        }
        
        if (updateQuestionDto.AnswerType != "essay")
        {
            List<string>? imageNames = updateQuestionDto.ImageNames;
            var answerImages = new Dictionary<int, IFormFile>();

            foreach (var file in form.Files)
            {
                var match = Regex.Match(file.Name, @"AnswerImages\[(\d+)\]");
                if (match.Success)
                {
                    int index = int.Parse(match.Groups[1].Value);
                    answerImages[index] = file;
                    Console.WriteLine(file.FileName);
                }
            }
            
            List<string> imagePaths = new List<string>();
            
            if(updateQuestionDto.ImageNames != null) imagePaths.AddRange(imageNames);
            
            string imagePath = Environment.GetEnvironmentVariable("ANSWER_IMAGE_PATH");

            if (answerImages != null)
            {
                foreach (var entry in answerImages)
                {
                    int index = entry.Key;
                    IFormFile file = entry.Value;
                    
                    var name = $"{Guid.NewGuid()}_{file.FileName}";
                    var filePath = Path.Combine(imagePath, name);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    
                    imagePaths[index] = filePath;
                }
            }   

            foreach (var path in imagePaths)
            {
                Console.WriteLine(path);
            }
            
            return new Answer
            {
                AnswerList = updateQuestionDto.Answers!,
                ImagePath = imagePaths
            };
        }

        return new Answer
        {
            AnswerList = new List<string>(),
            ImagePath = new List<string>()
        };
    }

    public async Task UpdateQuestion(Question question)
    {
        await _questionRepository.UpdateQuestion(question);
    }
}