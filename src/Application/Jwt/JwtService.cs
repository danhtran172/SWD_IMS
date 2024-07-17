using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NLog.LayoutRenderers;

namespace SWD_IMS.src.Application.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(int userId, Guid sessionId, int roleId, int exp);
        Payload? ValidateToken(string token);
    }
    public class JwtService : IJwtService
    {
        private readonly byte[] _key;
        private readonly JwtSecurityTokenHandler _handler;
        public JwtService()
        {
            var SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "@SWD_IMS";
            _key = Encoding.ASCII.GetBytes(SecretKey);
            _handler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(int userId, Guid sessionId, int roleId, int exp)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, roleId.ToString()),
                new Claim(ClaimTypes.Sid, sessionId.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exp),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return _handler.WriteToken(token);
        }

        public Payload? ValidateToken(string token)
        {
            try
            {
                var principal = _handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                }, out var validatedToken);

                var result = (JwtSecurityToken)validatedToken;

                var Payload = new Payload()
                {
                    UserId = int.Parse(result.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value),
                    RoleId = int.Parse(result.Claims.First(x => x.Type == ClaimTypes.Role).Value),
                    SessionId = Guid.Parse(result.Claims.First(x => x.Type == ClaimTypes.Sid).Value)
                };
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }
    }

}