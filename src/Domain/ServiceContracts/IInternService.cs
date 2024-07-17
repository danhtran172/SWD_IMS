using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO.InternDTOs;

namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface IInternService
    {
        public Task<ResponseDTO> GetInternById(int id);
        public Task<ResponseDTO> GetAllInterns();
        public Task<ResponseDTO> CreateIntern(InternCreateDTO req);
        public Task<ResponseDTO> UpdateIntern(InternUpdateDTO req, int id);
        public Task<ResponseDTO> DeleteIntern(int id);
        public Task<ResponseDTO> GetInternsByFilter(InternFilterDTO internFilter);
        public Task<ResponseDTO> GetInternByEmail(string email);
    }
}