using System.Net.Http.Headers;
using Frontend.Dto;
using Frontend.Models;

namespace Frontend.Services;

public class QuestionService
{
    private readonly HttpClient _client;

    public QuestionService(IHttpClientFactory clientFactory)
    {
        
        _client = clientFactory.CreateClient("QuestionAPI");
    }

    public async Task<HttpResponseMessage> CreateQuestion(List<CreateQuestionModel> dtoList)
    {
        var content = new MultipartFormDataContent();
        HttpResponseMessage response = new HttpResponseMessage();
        
        for (int i = 0; i < dtoList.Count; i++)
        {
            var dto = dtoList[i];

            content.Add(new StringContent(dto.AnswerType), $"AnswerType");
            content.Add(new StringContent(dto.QuestionText), $"QuestionText");
            content.Add(new StringContent(dto.Point.ToString()), $"Point");
            foreach (var index in dto.CorrectAnswerIndex)
            {
                content.Add(new StringContent(index.ToString()), "CorrectAnswerIndex");
            }

            foreach (var answer in dto.Answers)
            {
                content.Add(new StringContent(answer.Text), "Answers");
                content.Add(new StringContent(answer.ImageFile == null ? "" : answer.ImageFile.Name), "ImageNames");

                if (answer.ImageFile != null)
                {
                    var streamContent = new StreamContent(answer.ImageFile.OpenReadStream());
                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(answer.ImageFile.ContentType);
                    content.Add(streamContent, $"AnswerImages", answer.ImageFile.Name);
                }
            }

            if (dto.QuestionImage != null)
            {
                var streamContent = new StreamContent(dto.QuestionImage.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(dto.QuestionImage.ContentType);
                Console.WriteLine($"Question image name: {dto.QuestionImage.Name}");
                content.Add(streamContent, $"QuestionImage", dto.QuestionImage.Name);
            }
            
            foreach (var item in content)
            {
                if (item is StringContent stringContent)
                {
                    Console.WriteLine($"Name: {item.Headers.ContentDisposition.Name}, Value: {stringContent.ReadAsStringAsync().Result}");
                }
            }
            
            response = await _client.PostAsync("/api/question/create", content);
        }

        return response;
    }

    public async Task<HttpResponseMessage> GetQuestionAnswerTypes()
    {
        return await _client.GetAsync("/api/answertype/get");
    }

    public async Task<HttpResponseMessage> GetQuestionStatus()
    {
        return await _client.GetAsync("/api/questionstatus/get");
    }
    
    public async Task<HttpResponseMessage> GetPaginatedQuestion(int page, int pageSize)
    {
        return await _client.GetAsync($"/api/question/get/{page}/{pageSize}");
    }

    public async Task<HttpResponseMessage> GetQuestionById(string questionId)
    {
        return await _client.GetAsync($"/api/question/get/{questionId}");
    }

    public async Task<HttpResponseMessage> UpdateQuestion(QuestionDto questionDto)
    {
        var content = new MultipartFormDataContent();
        var dto = questionDto;
        
        content.Add(new StringContent(dto.AnswerType), $"AnswerType");
        content.Add(new StringContent(dto.QuestionText), $"QuestionText");
        content.Add(new StringContent(dto.Point.ToString()), $"Point");
        content.Add(new StringContent(dto.Id), $"Id");
        content.Add(new StringContent(dto.Status), "QuestionStatus");
        content.Add(new StringContent(dto.QuestionImage), "QuestionImage");
        foreach (var index in dto.CorrectAnswerIndex)
        {
            content.Add(new StringContent(index.ToString()), "CorrectAnswerIndex");
        }

        for (int i = 0; i < dto.AnswerList.Count; i++)
        {
            var imageName = "";
            if (dto.AnswerList[i].ImageFile != null)
            {
                imageName = dto.AnswerList[i].ImageFile.Name;
                var streamContent = new StreamContent(dto.AnswerList[i].ImageFile.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(dto.AnswerList[i].ImageFile.ContentType);
                Console.WriteLine("HOIYEAHHH");
                content.Add(streamContent, $"AnswerImages[{i}]", dto.AnswerList[i].ImageFile.Name);
            }

            else imageName = dto.AnswerImages[i];
            
            content.Add(new StringContent(dto.AnswerList[i].Text), "Answers");
            content.Add(new StringContent(imageName), "ImageNames");
        }

        if (dto.QuestionImageFile != null)
        {
            var streamContent = new StreamContent(dto.QuestionImageFile.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(dto.QuestionImageFile.ContentType);
            content.Add(streamContent, $"QuestionImage", dto.QuestionImageFile.Name);
        }
        //     
        // foreach (var item in content)
        // {
        //     var name = item.Headers.ContentDisposition?.Name?.Trim('"'); // remove the quotes
        //     var fileName = item.Headers.ContentDisposition?.FileName?.Trim('"'); // for file parts
        //
        //     if (item is StringContent stringContent)
        //     {
        //         Console.WriteLine($"String - Name: {name}, Value: {await stringContent.ReadAsStringAsync()}");
        //     }
        //     else if (item is StreamContent)
        //     {
        //         Console.WriteLine($"File - Name: {name}, FileName: {fileName}, ContentType: {item.Headers.ContentType}");
        //     }
        // }

        
        return await _client.PatchAsync("/api/question/update", content);
    }

    public async Task<HttpResponseMessage> DeleteQuestion(string questionId)
    {
        return await _client.PatchAsync($"/api/question/delete/{questionId}", null);
    }

    public async Task<HttpResponseMessage> SubmitQuestion(string questionId)
    {
        return await _client.PatchAsync($"api/question/submit/{questionId}", null);
    }
    
}

