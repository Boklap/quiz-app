namespace QuizService.Shared.Enums;

public enum HttpResponseEnum
{
    UnprocessableEntity = 422,
    BadRequest = 400,
    NotFound = 404,
    Unauthorized = 401,
    Conflict = 409,
}