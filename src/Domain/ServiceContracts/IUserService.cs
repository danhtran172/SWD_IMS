using SWD_IMS.Entities.DTO;

namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface IUserService
    {
        public Task<ResponseDTO> Login(string email, string password);
    }
}
