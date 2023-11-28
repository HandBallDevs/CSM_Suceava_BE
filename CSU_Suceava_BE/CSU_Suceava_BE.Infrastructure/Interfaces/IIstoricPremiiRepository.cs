using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IIstoricPremiiRepository
    {
        Task<IstoricPremii> CreateIstoricPremiiAsync(IstoricPremii IstoricPremii);
        Task<List<IstoricPremii>> GetIstoricPremiiByStaffIdAsync(Guid staffId);
        Task<IstoricPremii> GetIstoricPremiiByIdAsync(Guid istoricPremiiId);
        Task<IstoricPremii> UpdateIstoricPremii(IstoricPremii istoricPremii);
        Task DeleteIstoricPremiiByIdAsync(IstoricPremii istoricPremii);
    }
}
