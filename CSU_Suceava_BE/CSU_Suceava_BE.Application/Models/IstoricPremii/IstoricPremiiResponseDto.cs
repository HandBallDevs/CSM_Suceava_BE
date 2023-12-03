namespace CSU_Suceava_BE.Application.Models.IstoricPremii
{
    public class IstoricPremiiResponseDto
    {
        public Guid Id { get; set; }
        public string NumePremiu { get; set; } = null!;
        public DateTime DataPrimire { get; set; }
    }
}
