using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IMeciRepository
    {
        Task<Meci> CreateMeciAsync(Meci meci);
        Task<Meci> UpdateMeciAsync(Meci meci);
        Task<List<Meci>> GetMeciuriAsync();
        Task<Meci> GetMeciByIdAsync(Guid id);
        Task DeleteMeciByIdAsync(Meci meci);
        Task<List<Meci>> GetMeciuriDupaCampionatAsync(TipCampionat tipCampionat);
        Task<List<Meci>> GetMeciuriDupaEditieAsync(string editie);
        Task<List<Meci>> GetMeciuriDupaStatusAsync(StatusMeci statusMeci);
    }
}
