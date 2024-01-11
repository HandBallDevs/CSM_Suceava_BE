using CSU_Suceava_BE.Application.Models.Meci;
using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IMeciService
    {
        Task<MeciResponseDto> CreateMeciAsync(MeciCreateDto meci);
        Task<MeciResponseDto> UpdateMeciAsync(Guid id, MeciCreateDto meci);
        Task<List<MeciResponseDto>> GetMeciuriAsync();
        Task<MeciResponseDto> GetMeciByIdAsync(Guid id);
        Task DeleteMeciByIdAsync(Guid id);
        Task<List<MeciResponseDto>> GetFilteredMeciuri(StatusMeci? statusMeci, TipCampionat? tipCampionat, string? editie);
    }
}
