using SWD_IMS.src.Domain.ServiceContracts;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace SWD_IMS.src.Application.Services
{
    public class BCryptService : IBCryptService
    {

        string IBCryptService.HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        bool IBCryptService.VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
  
