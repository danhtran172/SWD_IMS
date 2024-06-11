using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SWD_IMS.src.Application.DTO;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/trainingprograms")]
    public class TrainingProgramController : ControllerBase
    {
        private readonly ITrainingProgramService _trainingProgramService;
        public TrainingProgramController(ITrainingProgramService trainingProgramService)
        {
            _trainingProgramService = trainingProgramService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTrainingPrograms()
        {
            try
            {
                var response = await _trainingProgramService.GetAllTrainingPrograms();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreteTrainingProgram(TrainingProgramCreateReqModel req){
            try
            {
                var response = await _trainingProgramService.CreateTrainingProgram(req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}