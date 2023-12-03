using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Models.Staff
{
    public class StaffDto
    {
        public Guid Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Nationalitate { get; set; } = null!;
        public TipLot TipLot { get; set; }
        public string Post { get; set; } = null!;
        public string URLPoza { get; set; } = null!;
        public DateTime DataNastere { get; set; }
        public double Inaltime { get; set; }
        public string? Descriere { get; set; }
    }
}
