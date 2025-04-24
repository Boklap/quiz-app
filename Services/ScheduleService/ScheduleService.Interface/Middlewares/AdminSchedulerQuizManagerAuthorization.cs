using Microsoft.AspNetCore.Mvc.Filters;
using ScheduleService.Shared.Exceptions;

namespace ScheduleService.Interface.Middlewares;

public class AdminSchedulerQuizManagerAuthorization : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var role = context.HttpContext.Items["Role"]?.ToString();
        
        if (string.IsNullOrEmpty(role))
        {
            throw new UnAuthorizedException("Unauthorized");
        }
        
        var roles = role.Split(",");

        if (!roles.Any(r =>
                r.Equals("admin_schedule", StringComparison.OrdinalIgnoreCase) ||
                r.Equals("admin_quiz_manager") ||
                r.Equals("super_admin", StringComparison.OrdinalIgnoreCase)))
        {
            throw new UnAuthorizedException("Unauthorized");
        }
    }
}