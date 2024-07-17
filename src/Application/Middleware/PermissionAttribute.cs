using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SWD_IMS.src.Application.Jwt;
using SWD_IMS.src.Domain.RepositoryContracts;

namespace SWD_IMS.src.Application.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _roleName;
        public PermissionAttribute(string roleName)
        {
            _roleName = roleName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Task.Run(async () => await OnAuthorizationAsync(context)).Wait();
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            var repo = serviceProvider.GetService<IRoleRepository>();
            try
            {
                var isForbidden = true;
                var payload = context.HttpContext.Items["Payload"] as Payload;
                if (payload != null && repo != null)
                {
                    var role = await repo.GetRoleById(payload.RoleId);
                    if (role != null)
                    {
                        if (role.Name == _roleName)
                        {
                            isForbidden = false;
                        }
                    }
                    else
                    {
                        isForbidden = true;
                    }
                }
                else
                {
                    isForbidden = true;
                }
                if (isForbidden)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = 403 };
                    return;
                }
            }
            catch (Exception ex)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new JsonResult(new { message = ex.Message }) { StatusCode = 500 };
                return;
            }
        }
    }
}