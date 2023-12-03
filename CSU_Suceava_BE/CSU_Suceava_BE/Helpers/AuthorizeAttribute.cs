namespace CSU_Suceava_BE.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CSU_Suceava_BE.Domain.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (Utilizator)context.HttpContext.Items["Utilizator"];
        if (user == null)
        {
            
            context.Result = new JsonResult(new { message = "Neautorizat" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}