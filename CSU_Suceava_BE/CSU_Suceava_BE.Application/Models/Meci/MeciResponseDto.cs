using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Models.Meci
{
    public class MeciResponseDto
    {
        public TipCampionat TipCampionat { get; set; }
        public string Editia { get; set; } = null!;
        public StatusMeci StatusMeci { get; set; }
        public DateTime Data { get; set; }
        public string URLPoza { get; set; } = null!;
        public string NumeAdversar { get; set; } = null!;
        public string Locatia { get; set; } = null!;
        public string LinkLive { get; set; } = null!;
        public bool Acasa { get; set; }
        public int ScorCSUSV { get; set; }
        public int ScorAdversar { get; set; }
    }
}
