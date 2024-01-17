using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Domain.Enums;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IStaffService
    {
        Task<StaffResponseDto> CreateStaffAsync(StaffCreateDto staff);
        Task<StaffResponseDto> GetStaffAsync(Guid staffId);
        Task<StaffResponseDto> UpdateStaffAsync(StaffCreateDto staff);
        Task DeleteStaffAsync(Guid staffId);
        Task<List<StaffResponseDto>> GetStaffByType(TipLot tipLot);
    }
}
