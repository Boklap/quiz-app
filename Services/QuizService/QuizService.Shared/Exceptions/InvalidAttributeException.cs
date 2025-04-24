using QuizService.Shared.Abstracts;
using QuizService.Shared.Enums;

namespace QuizService.Shared.Exceptions;

public class InvalidAttributeException(string message) : Error(message, statusCode: (int)HttpResponseEnum.UnprocessableEntity);