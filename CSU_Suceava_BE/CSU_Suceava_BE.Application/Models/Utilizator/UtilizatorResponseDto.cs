using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Models.Utilizator
{
    public class UtilizatorResponseDto
    {
        public Guid Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public Rol Rol { get; set; }
        public string Email { get; set; } = null!;
    }
}
