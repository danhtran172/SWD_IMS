using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.TrainingProgramDTOs;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Domain.RepositoryContracts
{
    public interface ITrainingProgramRepository
    {
        public Task<IEnumerable<TrainingProgram>> GetAllTrainingPrograms();
        public Task<TrainingProgram> GetTrainingProgramById(int id);
        public Task<bool> CreateTrainingProgram(TrainingProgram trainingProgram);
        public Task<bool> UpdateTrainingProgram(TrainingProgram trainingProgram);
        public Task<bool> DeleteTrainingProgram(TrainingProgram trainingProgram);
        public Task<TrainingProgramList> GetTrainingProgramsByFilter(TrainingProgramFilterDTO filter);

    }
}