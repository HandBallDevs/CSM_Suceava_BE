namespace CSU_Suceava_BE.Models
{
    using CSU_Suceava_BE.Domain.Entities;

    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Utilizator user, string token)
        {
            Id = user.Id;
            FirstName = user.Nume;
            LastName = user.Prenume;
            Username = user.Email;
            Token = token;
        }
    }

}