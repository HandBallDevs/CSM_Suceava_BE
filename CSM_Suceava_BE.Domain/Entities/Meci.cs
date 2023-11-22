﻿using CSM_Suceava_BE.Domain.Enums;

namespace CSM_Suceava_BE.Domain.Entities
{
    public class Meci
    {
        public Guid Id { get; set; }
        public TipCampionat TipCampionat { get; set; }
        public string Editia { get; set; } = null!;
        public StatusMeci StatusMeci { get; set; }
        public DateTime Data { get; set; }
        public string NumeAdversar { get; set; } = null!;
        public string Locatia { get; set; } = null!;
        public string LinkLive { get; set; } = null!;
        public bool Acasa { get; set; }
        public int ScorCSUSV { get; set; }
        public int ScorAdversar { get; set; }
    }
}
