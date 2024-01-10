using CSU_Suceava_BE.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CSU_Suceava_BE.Application.JwtUtils
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUtilizatorService utilizatorService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userValidationDto = jwtUtils.ValidateToken(token!);
            if (userValidationDto != null)
            {
                context.Items["User"] = await utilizatorService.GetUtilizatorByIdAsync(userValidationDto.Id);
            }

            await _next(context);
        }
    }
}
