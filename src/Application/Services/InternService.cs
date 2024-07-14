using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog.Targets;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO.InternDTOs;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;
using SWD_IMS.src.Infrastructure.Repository;

namespace SWD_IMS.src.Application.Services
{
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;
        private readonly IMapper _mapper;
        public InternService(IInternRepository internRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _mapper = mapper;
        }
        public async Task<ResponseDTO> CreateIntern(InternCreateDTO req)
        {
            var response = new ResponseDTO();
            try
            {
                var mappedIntern = _mapper.Map<Intern>(req);
                var result = await _internRepository.CreateIntern(mappedIntern);
                if (result)
                {
                    response.StatusCode = 200;
                    response.Message = "Intern created successfully";
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Intern creation failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;

            }
        }

        public async Task<ResponseDTO> DeleteIntern(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var intern = await _internRepository.GetInternById(id);
                var result = await _internRepository.DeleteIntern(intern);
                if (result)
                {
                    response.StatusCode = 200;
                    response.Message = "Intern deleted successfully";
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Intern deletion failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetAllInterns()
        {
            var response = new ResponseDTO();
            try
            {
                var listIntern = await _internRepository.GetAllInterns();
                var mappedIntern = _mapper.Map<List<InternDTO>>(listIntern);
                if (mappedIntern != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Interns fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedIntern,
                        PageInfo = new PageInfo
                        {
                            Total = mappedIntern.Count
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Intern fetched failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetInternById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var intern = await _internRepository.GetInternById(id);
                var mappedIntern = _mapper.Map<InternDTO>(intern);
                if (mappedIntern != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Intern fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedIntern,
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Intern fetched failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetInternsByFilter(InternFilterDTO filter)
        {
            var response = new ResponseDTO();
            try
            {
                var listIntern = await _internRepository.GetInternsByFilter(filter);
                var mappedIntern = _mapper.Map<List<InternDTO>>(listIntern.Interns);
                if (mappedIntern != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Interns fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedIntern,
                        PageInfo = new PageInfo
                        {
                            Page = filter.Page,
                            PageSize = filter.PageSize,
                            HasNextPage = filter.Page * filter.PageSize < listIntern.TotalCount,
                            Total = listIntern.TotalCount
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Intern fetched failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> UpdateIntern(InternUpdateDTO req, int id)
        {
            var response = new ResponseDTO();
            try
            {
                var internToUpdate = await _internRepository.GetInternById(id);
                var mappedIntern = _mapper.Map(req, internToUpdate);
                var result = await _internRepository.UpdateIntern(mappedIntern);
                if (result)
                {
                    response.StatusCode = 200;
                    response.Message = "Intern updated successfully";
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Intern update failed";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}