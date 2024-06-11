using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Services
{
    public class TrainingProgramService : ITrainingProgramService
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        private readonly IMapper _mapper;
        public TrainingProgramService(ITrainingProgramRepository trainingProgramRepository, IMapper mapper)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> CreateTrainingProgram(TrainingProgramCreateReqModel trainingProgramCreateReq)
        {
            var response = new ResponseDTO();
            try
            {
                var mappedTrainingProgram = _mapper.Map<TrainingProgram>(trainingProgramCreateReq);
                var result = await _trainingProgramRepository.CreateTrainingProgram(mappedTrainingProgram);
                if (result)
                {
                    response.StatusCode = 201;
                    response.Message = "Training program created successfully";
                    response.IsSuccess = true;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Training program creation failed";
                    response.IsSuccess = false;
                }
            }
            catch
            {
                throw;
            }

            return response;
        }

        public Task<ResponseDTO> DeleteTrainingProgram(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> GetAllTrainingPrograms()
        {
            var response = new ResponseDTO();
            try
            {
                var listTrainingProgram = await _trainingProgramRepository.GetAllTrainingPrograms();
                var mappedTrainingProgram = _mapper.Map<IEnumerable<TrainingProgramDTO>>(listTrainingProgram);
                if (mappedTrainingProgram != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Training programs fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedTrainingProgram,
                        Total = mappedTrainingProgram.Count()
                    };
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Training programs fetched faild";
                    response.IsSuccess = false;
                }
            }
            catch
            {
                throw;
            }
            return response;
        }

    public Task<ResponseDTO> GetTrainingProgramById(int id)
    {
        throw new NotImplementedException();
    }


    public Task<ResponseDTO> UpdateTrainingProgram(TrainingProgramUpdateReqModel trainingProgram, int id)
    {
        throw new NotImplementedException();
    }
}
}
