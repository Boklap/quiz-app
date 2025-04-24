using QuizResultService.Shared.Abstracts;
using QuizResultService.Shared.Enums;

namespace QuizResultService.Shared.Exceptions;

public class InvalidAttributeException(string message) : Error(message, statusCode: (int)HttpResponseEnum.UnprocessableEntity);