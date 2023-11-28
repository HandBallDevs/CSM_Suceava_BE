using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class IstoricPremiiRepository : IIstoricPremiiRepository
    {
        private readonly EFContext eFContext;

        public IstoricPremiiRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<IstoricPremii> CreateIstoricPremiiAsync(IstoricPremii istoricPremii)
        {
            await eFContext.AddAsync(istoricPremii);

            await eFContext.SaveChangesAsync();

            return istoricPremii;
        }

        public async Task DeleteIstoricPremiiByIdAsync(IstoricPremii istoricPremii)
        {
            eFContext.Remove(istoricPremii);

            await eFContext.SaveChangesAsync();
        }

        public async Task<IstoricPremii> GetIstoricPremiiByIdAsync(Guid istoricPremiiId)
        {
            return await eFContext
                .IstoricPremii
                .FirstAsync(ip => ip.Id.Equals(istoricPremiiId));
        }

        public Task<List<IstoricPremii>> GetIstoricPremiiByStaffIdAsync(Guid staffId)
        {
           return eFContext
                .IstoricPremii
                .AsNoTracking()
                .Where(ip => ip.StaffId.Equals(staffId))
                .ToListAsync();
        }

        public async Task<IstoricPremii> UpdateIstoricPremii(IstoricPremii istoricPremii)
        {
            eFContext.Update(istoricPremii);

            await eFContext.SaveChangesAsync();

            return istoricPremii;
        }
    }
}
