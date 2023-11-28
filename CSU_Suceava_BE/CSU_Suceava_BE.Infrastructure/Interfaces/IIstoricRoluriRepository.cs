using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IIstoricRoluriRepository
    {
        Task<IstoricRoluri> CreateIstoricRoluriAsync(IstoricRoluri istoricRoluri);
        Task<List<IstoricRoluri>> GetIstoricRoluriByStaffIdAsync(Guid staffId);
        Task<IstoricRoluri> GetIstoricRoluriByIdAsync(Guid istoricRoluriId);
        Task<IstoricRoluri> UpdateIstoricRoluri(IstoricRoluri istoricRoluri);
        Task DeleteIstoricRoluriByIdAsync(IstoricRoluri istoricRoluri);
    }
}
