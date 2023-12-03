using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Domain.Entities
{
    public class Utilizator
    {
        public Guid Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public Rol Rol { get; set; }
        public string Email { get; set; } = null!;
        public string Parola { get; set; } = null!;

        public List<Stire> Stiri { get; set; } = null!;
    }
}
