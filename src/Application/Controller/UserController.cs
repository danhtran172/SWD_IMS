using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userService.GetAllUsers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserCreateDTO req)
        {
            try
            {
                var response = await _userService.CreateUser(req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var response = await _userService.GetUserById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var response = await _userService.DeleteUser(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetUsersByFilter(UserFilterDTO filter)
        {
            try
            {
                var response = await _userService.GetUsersByFilter(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO req, int id)
        {
            try
            {
                var response = await _userService.UpdateUser(req, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update-password/{id}")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordReq req, int id)
        {
            try
            {
                var response = await _userService.UpdatePassword(id, req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}