using QuestionService.Shared.Abstracts;
using QuestionService.Shared.Enums;

namespace QuestionService.Shared.Exceptions;

public class EnvVariableEmptyException(string message) : Error(message, statusCode: (int)HttpResponseEnum.NotFound);