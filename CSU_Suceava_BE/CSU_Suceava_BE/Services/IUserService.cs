namespace CSU_Suceava_BE.Services;

using CSU_Suceava_BE.Helpers;
using CSU_Suceava_BE.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Helpers;
using CSU_Suceava_BE.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Utilizator> GetAll();
    Utilizator GetById(Guid id);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<Utilizator> _Utilizatori = new List<Utilizator>
    {

        new Utilizator { Nume = "Test", Prenume = "User", Email = "test", Parola = "test" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var Utilizator = _Utilizatori.SingleOrDefault(x => x.Email == model.Email && x.Parola == model.Parola);

        // return null if user not found
        if (Utilizator == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(Utilizator);

        return new AuthenticateResponse(Utilizator, token);
    }

    public IEnumerable<Utilizator> GetAll()
    {
        return _Utilizatori;
    }

    public Utilizator GetById(Guid id)
    {
        return _Utilizatori.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(Utilizator Utilizator)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", Utilizator.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}