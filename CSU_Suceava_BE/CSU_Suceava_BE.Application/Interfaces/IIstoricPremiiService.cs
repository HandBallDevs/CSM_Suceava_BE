using CSU_Suceava_BE.Application.Models;
using CSU_Suceava_BE.Application.Models.IstoricPremii;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IIstoricPremiiService
    {
        Task<IstoricPremiiResponseDto> CreateIstoricPremiiAsync(IstoricPremiiCreateDto IstoricPremii, Guid staffId);
        Task<List<IstoricPremiiResponseDto>> GetIstoricPremiiByStaffIdAsync(Guid staffId);
        Task<IstoricPremiiResponseDto> UpdateIstoricPremiiByIdAsync(Guid istoricPremiiId, IstoricPremiiCreateDto istoricPremii);
        Task DeleteIstoricPremiiByIdAsync(Guid istoricPremiiId);
    }
}
