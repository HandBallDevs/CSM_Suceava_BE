using Azure.Security.KeyVault.Secrets;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Utilizator;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;
using CSU_Suceava_BE.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSU_Suceava_BE.Application.JwtUtils
{
    public class JwtUtils : IJwtUtils
    {
        private readonly SecretClient secretClient;

        public JwtUtils(SecretClient secretClient)
        {
            this.secretClient = secretClient;
        }

        public string GenerateToken(Utilizator utilizator)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII
                .GetBytes(secretClient.GetSecret(Environment.GetEnvironmentVariable("TOKEN_SECRET")).Value.Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(Constants.JWTClaims.Id, utilizator.Id.ToString()),
                    new Claim(Constants.JWTClaims.Email, utilizator.Email),
                    new Claim(Constants.JWTClaims.Role, utilizator.Rol.ToString()!)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ValidationDto? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII
                .GetBytes(secretClient.GetSecret(Environment.GetEnvironmentVariable("TOKEN_SECRET")).Value.Value);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == Constants.JWTClaims.Id).Value);
                var email = jwtToken.Claims.First(x => x.Type == Constants.JWTClaims.Email).Value;
                var role = Enum.Parse<Rol>(jwtToken.Claims.First(x => x.Type == Constants.JWTClaims.Role).Value);
                return new ValidationDto { Id = userId, Email = email, Role = role };

            }
            catch
            {
                return null;
            }
        }
    }
}
