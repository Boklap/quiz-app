using Microsoft.AspNetCore.Mvc.Filters;
using QuizResultService.Shared.Exceptions;

namespace QuizResultService.Interface.Middlewares;

public class UserAuthorizationAttribute : Attribute, IAuthorizationFilter
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
                r.Equals("participant", StringComparison.OrdinalIgnoreCase) ||
                r.Equals("super_admin", StringComparison.OrdinalIgnoreCase)))
        {
            throw new UnAuthorizedException("Unauthorized");
        }
    }
}