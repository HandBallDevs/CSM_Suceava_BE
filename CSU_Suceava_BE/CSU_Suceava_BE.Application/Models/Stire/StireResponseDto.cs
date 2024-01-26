namespace CSU_Suceava_BE.Application.Models.Stire
{
    public class StireResponseDto
    {
        public Guid Id { get; set; }
        public string Titlu { get; set; } = null!;
        public string Continut { get; set; } = null!;
        public string URLPoza { get; set; } = null!;
        public string HashTaguri { get; set; } = null!;
        public DateTime DataPostare { get; set; }
        public Guid UtilizatorId { get; set; }
    }
}
