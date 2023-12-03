namespace CSU_Suceava_BE.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}
