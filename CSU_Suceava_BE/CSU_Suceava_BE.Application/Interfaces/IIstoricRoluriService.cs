using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IIstoricRoluriService
    {
        Task<IstoricRoluriResponseDto> CreateIstoricRoluriAsync(IstoricRoluriCreateDto istoricRoluri, Guid staffId);
        Task<List<IstoricRoluriResponseDto>> GetIstoricRoluriByStaffIdAsync(Guid staffId);
        Task<IstoricRoluriResponseDto> UpdateIstoricRoluriByIdAsync(Guid istoricRoluriId, IstoricRoluriCreateDto istoricRoluri);
        Task DeleteIstoricRoluriByIdAsync(Guid istoricRoluriId);
    }
}
