using CSM_Suceava_BE.Domain.Enums;

namespace CSM_Suceava_BE.Domain.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Nationalitate { get; set; } = null!;
        public TipLot TipLot { get; set; }
        public string Post { get; set; } = null!;
        public string URLPoza { get; set; } = null!;
        public DateTime DataNastere { get; set; }
        public float Inaltime { get; set; }
        public string Descriere { get; set; } = null!;
    }
}
