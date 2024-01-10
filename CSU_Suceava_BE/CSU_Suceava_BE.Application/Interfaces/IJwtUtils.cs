using CSU_Suceava_BE.Application.Models.Utilizator;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(Utilizator utilizator);
        public ValidationDto? ValidateToken(string token);
    }
}
