namespace CSU_Suceava_BE.Application.Models.IstoricRoluri
{
    public class IstoricRoluriCreateDto
    {
        public string NumeRol { get; set; } = null!;
        public DateTime DataIncepere { get; set; }
        public DateTime DataFinalizare { get; set; }
    }
}
