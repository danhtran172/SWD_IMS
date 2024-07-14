using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWD_IMS.src.Application.DTO.InternDTOs;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/interns")]
    public class InternController : ControllerBase
    {
        private readonly ILogger<InternController> _logger;
        private readonly IInternService _internService;
        public InternController(ILogger<InternController> logger, IInternService internService)
        {
            _logger = logger;
            _internService = internService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllInterns()
        {
            try
            {
                var response = await _internService.GetAllInterns();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateIntern(InternCreateDTO req)
        {
            try
            {
                var response = await _internService.CreateIntern(req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInternById(int id)
        {
            try
            {
                var response = await _internService.GetInternById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            try
            {
                var response = await _internService.DeleteIntern(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateIntern(InternUpdateDTO req, int id)
        {
            try
            {
                var response = await _internService.UpdateIntern(req, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetInternsByFilter(InternFilterDTO internFilter)
        {
            try
            {
                var response = await _internService.GetInternsByFilter(internFilter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}