using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class MeciRepository : IMeciRepository
    {
        private readonly EFContext eFContext;

        public MeciRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<Meci> CreateMeciAsync(Meci meci)
        {
            await eFContext.AddAsync(meci);
            await eFContext.SaveChangesAsync();

            return meci;
        }

        public async Task DeleteMeciByIdAsync(Meci meci)
        {
            eFContext.Remove(meci);
            await eFContext.SaveChangesAsync();
        }

        public async Task<Meci> GetMeciByIdAsync(Guid id)
        {
            return await eFContext.Meci.FirstAsync(m => m.Id.Equals(id));
        }

        public async Task<List<Meci>> GetMeciuriAsync()
        {
            return await eFContext.Meci.ToListAsync();
        }

        public async Task<List<Meci>> GetMeciuriDupaCampionatAsync(TipCampionat tipCampionat)
        {
            return await eFContext.Meci.Where(m => m.TipCampionat.Equals(tipCampionat)).ToListAsync();
        }

        public async Task<List<Meci>> GetMeciuriDupaEditieAsync(string editie)
        {
            return await eFContext.Meci.Where(m=>m.Editia.Equals(editie)).ToListAsync();
        }

        public async Task<List<Meci>> GetMeciuriDupaStatusAsync(StatusMeci statusMeci)
        {
            return await eFContext.Meci.Where(m => m.StatusMeci.Equals(statusMeci)).ToListAsync();
        }

        public async Task<Meci> UpdateMeciAsync(Meci meci)
        {
            eFContext.Update(meci);
            await eFContext.SaveChangesAsync();

            return meci;
        }
    }
}
