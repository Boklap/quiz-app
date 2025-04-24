using QuizResultService.Shared.Abstracts;
using QuizResultService.Shared.Enums;

namespace QuizResultService.Shared.Exceptions;

public class EntityNotFoundException(string message)
    : Error(message, statusCode: (int)HttpResponseEnum.NotFound);