using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Infrastructure.Interfaces
{
    public interface IUtilizatorRepository
    {
        public Task<Utilizator> GetUtilizatorByEmailAsync(string email);
        public Task<Utilizator> GetUtilizatorByIdAsync(Guid id);
    }
}
