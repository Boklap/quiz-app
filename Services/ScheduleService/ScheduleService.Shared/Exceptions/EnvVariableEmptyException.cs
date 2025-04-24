using ScheduleService.Shared.Abstracts;
using ScheduleService.Shared.Enums;

namespace ScheduleService.Shared.Exceptions;

public class EnvVariableEmptyException(string message) : Error(message, statusCode: (int)HttpResponseEnum.NotFound);