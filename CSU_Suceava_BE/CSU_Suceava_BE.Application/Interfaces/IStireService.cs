using CSU_Suceava_BE.Application.Models.Stire;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IStireService
    {
        Task<StireResponseDto> CreateStireAsync(Guid creatorId, StireCreateDto stire);
        Task<StireResponseDto> UpdateStireAsync(Guid id, StireCreateDto stire);
        Task DeleteStireAsync(Guid id);
        Task<StireResponseDto> GetStireByIdAsync(Guid id);
        Task<List<StireResponseDto>> GettAllStiriAsync();
    }
}
