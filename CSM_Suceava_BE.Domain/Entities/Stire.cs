using CSM_Suceava_BE.Domain.Enums;

namespace CSM_Suceava_BE.Domain.Entities
{
    public class Stire
    {
        public Guid Id { get; set; }
        public string Titlu { get; set; } = null!;
        public string Continut { get; set; } = null!;
        public string HashTaguri { get; set; } = null!;
        public StatusStire StatusStire { get; set; }
        public DateTime DataAutopostare { get; set; }
        public DateTime DataPostare { get; set; }
    }
}