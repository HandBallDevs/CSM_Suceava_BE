using CSU_Suceava_BE.Application.Models.Utilizator;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IUtilizatorService
    {
        Task<string> LoginAsync(AuthenticationDto authentication);
        Task<UtilizatorResponseDto> GetUtilizatorByIdAsync(Guid id);
    }
}
