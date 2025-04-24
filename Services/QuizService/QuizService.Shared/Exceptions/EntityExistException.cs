using QuizService.Shared.Abstracts;
using QuizService.Shared.Enums;

namespace QuizService.Shared.Exceptions;

public class EntityExistException (string message) : Error(message, statusCode: (int)HttpResponseEnum.Conflict);