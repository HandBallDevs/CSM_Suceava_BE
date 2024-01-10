using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class UtilizatorRepository : IUtilizatorRepository
    {
        private readonly EFContext eFContext;

        public UtilizatorRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<Utilizator> GetUtilizatorByEmailAsync(string email)
        {
            return await eFContext.Utilizator.FirstAsync(u => u.Email.Equals(email));
        }

        public async Task<Utilizator> GetUtilizatorByIdAsync(Guid id)
        {
            return await eFContext.Utilizator.FirstAsync(u => u.Id.Equals(id));
        }
    }
}
