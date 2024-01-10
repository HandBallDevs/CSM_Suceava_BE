using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IStaffService
    {
        Task<StaffDto> CreateStaffAsync(StaffDto staff);
        Task<StaffDto> GetStaffAsync(Guid staffId);
        Task<StaffDto> UpdateStaffAsync(StaffDto staff);
        Task DeleteStaffAsync(Guid staffId);
        Task<List<StaffDto>> GetStaffByType(TipLot tipLot);
    }
}
