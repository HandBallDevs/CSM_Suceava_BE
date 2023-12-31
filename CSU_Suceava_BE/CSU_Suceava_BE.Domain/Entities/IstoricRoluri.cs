﻿namespace CSU_Suceava_BE.Domain.Entities
{
    public class IstoricRoluri
    {
        public Guid Id { get; set; }
        public string NumeRol { get; set; } = null!;
        public DateTime DataIncepere { get; set; }
        public DateTime DataFinalizare { get; set; }

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
    }
}
