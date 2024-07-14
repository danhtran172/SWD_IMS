using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO.TrainingProgramDTOs;

namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface ITrainingProgramService
    {
        public Task<ResponseDTO> GetAllTrainingPrograms();
        public Task<ResponseDTO> GetTrainingProgramById(int id);
        public Task<ResponseDTO> CreateTrainingProgram(TrainingProgramCreateDTO trainingProgram);
        public Task<ResponseDTO> UpdateTrainingProgram(TrainingProgramUpdateDTO trainingProgram, int id);
        public Task<ResponseDTO> DeleteTrainingProgram(int id);
        public Task<ResponseDTO> GetTrainingProgramsByFilter(TrainingProgramFilterDTO filter);
    }
}