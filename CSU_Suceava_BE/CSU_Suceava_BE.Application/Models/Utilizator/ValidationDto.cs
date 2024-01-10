using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Models.Utilizator
{
    public class ValidationDto
    {
        public string Email { get; set; } = null!;
        public Rol Role { get; set; }
        public Guid Id { get; set; }
    }
}
