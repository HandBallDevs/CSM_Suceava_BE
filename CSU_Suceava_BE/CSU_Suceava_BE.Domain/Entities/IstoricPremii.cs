﻿namespace CSU_Suceava_BE.Domain.Entities
{
    public class IstoricPremii
    {
        public Guid Id { get; set; }
        public string NumePremiu { get; set; } = null!;
        public DateTime DataPrimire { get; set; }

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
    }
}
