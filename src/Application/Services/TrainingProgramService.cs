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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public TrainingProgramService(ITrainingProgramRepository trainingProgramRepository, IMapper mapper, IUserRepository userRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseDTO> CreateTrainingProgram(TrainingProgramCreateReqModel trainingProgramCreateReq)
        {
            var response = new ResponseDTO();
            try
            {
                var mappedTrainingProgram = _mapper.Map<TrainingProgram>(trainingProgramCreateReq);
                if (trainingProgramCreateReq.MentorId != null)
                {
                    var mentor = await _userRepository.GetUserById(trainingProgramCreateReq.MentorId.Value);
                    if (mentor != null)
                    {
                        mappedTrainingProgram.Mentor = mentor;
                    }
                }
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

        public async Task<ResponseDTO> DeleteTrainingProgram(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var trainingProgram = await _trainingProgramRepository.GetTrainingProgramById(id);
                var result = await _trainingProgramRepository.DeleteTrainingProgram(trainingProgram);
                if (result)
                {
                    response.StatusCode = 200;
                    response.Message = "Training program deleted successfully";
                    response.IsSuccess = true;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Training program deletion failed";
                    response.IsSuccess = false;
                }
            }
            catch
            {
                throw;
            }
            return response;
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

        public async Task<ResponseDTO> GetTrainingProgramById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var trainingProgram = await _trainingProgramRepository.GetTrainingProgramById(id);
                var mappedTrainingProgram = _mapper.Map<TrainingProgramDTO>(trainingProgram);
                if (mappedTrainingProgram != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Training program fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedTrainingProgram,
                    };
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Training program fetched faild";
                    response.IsSuccess = false;
                }
            }
            catch
            {
                throw;
            }
            return response;
        }


        public async Task<ResponseDTO> UpdateTrainingProgram(TrainingProgramUpdateReqModel req, int id)
        {
            var response = new ResponseDTO();
            try
            {
                var trainingProgramToUpdate = await _trainingProgramRepository.GetTrainingProgramById(id);
                if (trainingProgramToUpdate != null)
                {
                    var mappedTrainingProgram = _mapper.Map(req, trainingProgramToUpdate);
                    var result = await _trainingProgramRepository.UpdateTrainingProgram(mappedTrainingProgram);
                    if (result)
                    {
                        response.StatusCode = 200;
                        response.Message = "Training program updated successfully";
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.Message = "Training program update failed";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Training program not found";
                    response.IsSuccess = false;
                }
            }
            catch
            {
                throw;
            }
            return response;
        }
    }
}
