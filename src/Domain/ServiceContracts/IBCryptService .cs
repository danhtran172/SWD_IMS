namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface IBCryptService
    {
       string HashPassword(string password);
       bool VerifyPassword(string password, string storedHash);
    }
}
