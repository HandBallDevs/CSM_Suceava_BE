using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff staff);
        Task<Staff> GetStaffAsync(Guid staffId);
        Task<Staff> UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(Staff staff);
    }
}
