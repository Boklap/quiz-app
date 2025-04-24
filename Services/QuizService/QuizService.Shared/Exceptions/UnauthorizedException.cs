using QuizService.Shared.Abstracts;
using QuizService.Shared.Enums;

namespace QuizService.Shared.Exceptions;

public class UnAuthorizedException(string message) : Error(message, statusCode: (int) HttpResponseEnum.Unauthorized);