using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff staff);
        Task<Staff> GetStaffByIdAsync(Guid staffId);
        Task<Staff> UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(Staff staff);
        Task<List<Staff>> GetStaffByTypeAsync(TipLot tipLot);
    }
}
