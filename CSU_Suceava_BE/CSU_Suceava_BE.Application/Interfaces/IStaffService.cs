using CSU_Suceava_BE.Application.Models;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IStaffService
    {
        Task<StaffDto> CreateStaffAsync(StaffDto staff);
        Task<StaffDto> GetStaffAsync(Guid staffId);
        Task<StaffDto> UpdateStaffAsync(StaffDto staff);
        Task DeleteStaffAsync(Guid staffId);
    }
}
