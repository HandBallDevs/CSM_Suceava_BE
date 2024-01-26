using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class StireRepository : IStireRepository
    {
        private readonly EFContext eFContext;

        public StireRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<Stire> CreateStireAsync(Stire stire)
        {
            await eFContext.AddAsync(stire);

            await eFContext.SaveChangesAsync();

            return stire;
        }

        public async Task DeleteStireAsync(Stire stire)
        {
            eFContext.Remove(stire);

            await eFContext.SaveChangesAsync();
        }

        public async Task<Stire> GetStireByIdAsync(Guid id)
        {
            return await eFContext.Stire.FirstAsync(s => s.Id.Equals(id));
        }

        public async Task<List<Stire>> GettAllStiriAsync()
        {
            return await eFContext.Stire.AsNoTracking().ToListAsync();
        }

        public async Task<Stire> UpdateStireAsync(Stire stire)
        {
            eFContext.Update(stire);

            await eFContext.SaveChangesAsync();

            return stire;
        }
    }
}
