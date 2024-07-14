using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SWD_IMS.src.Application.DTO.TrainingProgramDTOs;
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
        public async Task<IActionResult> CreteTrainingProgram(TrainingProgramCreateDTO req)
        {
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingProgramById(int id)
        {
            try
            {
                var response = await _trainingProgramService.GetTrainingProgramById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingProgram(int id)
        {
            try
            {
                var response = await _trainingProgramService.DeleteTrainingProgram(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateTrainingProgram(int id, TrainingProgramUpdateDTO req)
        {
            try
            {
                var response = await _trainingProgramService.UpdateTrainingProgram(req, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetTrainingProgramsByFilter(TrainingProgramFilterDTO req)
        {
            try
            {
                var response = await _trainingProgramService.GetTrainingProgramsByFilter(req);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}