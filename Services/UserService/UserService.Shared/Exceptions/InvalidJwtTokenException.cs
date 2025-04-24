using UserService.Shared.Abstracts;
using UserService.Shared.Enums;

namespace UserService.Shared.Exceptions;

public class InvalidJwtTokenException(string message) : Error(message, statusCode: (int)HttpResponseEnum.UnprocessableEntity);