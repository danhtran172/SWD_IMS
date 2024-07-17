using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SWD_IMS.src.Application.Jwt;

namespace SWD_IMS.src.Application.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ProtectedAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;
        public ProtectedAttribute()
        {
            _jwtService = new JwtService();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = 401 };
                return;
            }

            var token = authHeader.Substring("Bearer ".Length);

            try
            {
                var payload = _jwtService.ValidateToken(token);

                // add payload to context
                context.HttpContext.Items["payload"] = payload;
            }
            catch
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = 401 };
                return;
            }
        }
    }
}