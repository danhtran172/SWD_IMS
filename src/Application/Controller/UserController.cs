using Microsoft.AspNetCore.Mvc;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO;
using SWD_IMS.src.Application.Services;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("{email},{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var response = await _userService.Login( email,  password);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
