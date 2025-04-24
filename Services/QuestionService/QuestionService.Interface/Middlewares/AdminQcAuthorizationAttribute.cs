using Microsoft.AspNetCore.Mvc.Filters;
using QuestionService.Shared.Exceptions;

namespace QuestionService.Interface.Middlewares;

public class AdminQcAuthorizationAttribute : Attribute, IAuthorizationFilter
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
                r.Equals("admin_qc", StringComparison.OrdinalIgnoreCase) ||
                r.Equals("super_admin", StringComparison.OrdinalIgnoreCase)))
        {
            throw new UnAuthorizedException("Unauthorized");
        }
    }
}