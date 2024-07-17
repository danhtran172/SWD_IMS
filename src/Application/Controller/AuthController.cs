using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWD_IMS.src.Application.Jwt;
using SWD_IMS.src.Domain.RepositoryContracts;

namespace SWD_IMS.src.Application.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    { 
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public AuthController(ILogger<AuthController> logger, IJwtService jwtService, IUserRepository userRepository)
        {
            _logger = logger;
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword()
        {
            return Ok();
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}