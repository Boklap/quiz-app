using UserService.Shared.Abstracts;
using UserService.Shared.Enums;

namespace UserService.Shared.Exceptions;

public class EnvVariableEmptyException(string message) : Error(message, statusCode: (int)HttpResponseEnum.NotFound);