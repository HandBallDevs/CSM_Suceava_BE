namespace CSU_Suceava_BE.Application.Models.IstoricRoluri
{
    public class IstoricRoluriResponseDto
    {
        public Guid Id { get; set; }
        public string NumeRol { get; set; } = null!;
        public DateTime DataIncepere { get; set; }
        public DateTime DataFinalizare { get; set; }
    }
}
