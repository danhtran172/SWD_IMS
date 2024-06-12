using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO;

namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface ITrainingProgramService
    {
        public Task<ResponseDTO> GetAllTrainingPrograms();
        public Task<ResponseDTO> GetTrainingProgramById(int id);
        public Task<ResponseDTO> CreateTrainingProgram(TrainingProgramCreateReqModel trainingProgram);
        public Task<ResponseDTO> UpdateTrainingProgram(TrainingProgramUpdateReqModel trainingProgram, int id);
        public Task<ResponseDTO> DeleteTrainingProgram(int id);
    }
}