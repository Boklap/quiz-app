using QuizService.Application.Ports.Inbound.UseCases.TagUseCases;
using QuizService.Domain.Entities;
using QuizService.Domain.Repositories;

namespace QuizService.Application.UseCases.TagUseCaseImpl;

public class GetTagUseCaseImpl : IGetTagUseCase
{
    private readonly ITagRepository _tagRepository;

    public GetTagUseCaseImpl(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public async Task<List<Tag>> Execute()
    {
        List<Tag>? tags = await _tagRepository.FindTag();
        if(tags == null) return new List<Tag>();

        return tags;
    }
}