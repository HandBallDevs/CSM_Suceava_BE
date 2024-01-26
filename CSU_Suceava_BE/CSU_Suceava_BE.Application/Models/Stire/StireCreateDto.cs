namespace CSU_Suceava_BE.Application.Models.Stire
{
    public class StireCreateDto
    {
        public string Titlu { get; set; } = null!;
        public string Continut { get; set; } = null!;
        public string URLPoza { get; set; } = null!;
        public string HashTaguri { get; set; } = null!;
    }
}
