using SWD_IMS.src.Domain.ServiceContracts;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SWD_IMS.src.Application.Services
{
    public class BCryptService : IBCryptService
    {
        private const int SaltByteSize = 12;  // Adjust based on security requirements
        private const int KeyDerivationIterations = 10;  // Adjust based on security requirements

        string IBCryptService.HashPassword(string password)
        {
            byte[] salt = BCryptGenerateSalt(SaltByteSize);

            // Hash the password with the salt
            return BCryptHashPassword(password, salt);
        }

        bool IBCryptService.VerifyPassword(string password, string hashedPassword)
        {
            // Convert the hashed password from Base64 string to byte array
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Verify the password with the hashed password and extracted salt
            return BCryptVerifyPassword(password, hashBytes);
        }

        private static byte[] BCryptGenerateSalt(int saltByteSize)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[saltByteSize];
                rng.GetBytes(salt);
                return salt;
            }
        }
        private static string BCryptHashPassword(string password, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, KeyDerivationIterations))
            {
                // Derive the key from the password and salt
                byte[] key = deriveBytes.GetBytes(24);

                // Hash the password with the derived key using BCrypt
                //byte[] hash = BCrypt.Net.BCrypt.EnhancedHashPassword(key);

                // Convert the hash to Base64 string for easier storage/transmission
                return null;/*Convert.ToBase64String(hash);*/
            }
        }

        private static bool BCryptVerifyPassword(string password, byte[] hashedPassword)
        {
            // Extract the salt from the beginning of the hashed password (assuming BCrypt's standard format)
            byte[] salt = new byte[SaltByteSize];
            Array.Copy(hashedPassword, 16, salt, 0, SaltByteSize);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, KeyDerivationIterations))
            {
                // Derive the key from the password and extracted salt
                byte[] key = deriveBytes.GetBytes(24);

                // Verify the password with the derived key and the provided hash
                return BCrypt.Net.BCrypt.Verify(key.ToString(), Convert.ToBase64String(hashedPassword));
            }
        }
    }
}
