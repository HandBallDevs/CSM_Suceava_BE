using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IStireRepository
    {
        Task<Stire> CreateStireAsync(Stire stire);
        Task<Stire> UpdateStireAsync(Stire stire);
        Task DeleteStireAsync(Stire stire);
        Task<Stire> GetStireByIdAsync(Guid id);
        Task<List<Stire>> GettAllStiriAsync();
    }
}
