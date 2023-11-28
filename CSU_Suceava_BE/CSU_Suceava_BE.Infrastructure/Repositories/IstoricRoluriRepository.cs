using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class IstoricRoluriRepository : IIstoricRoluriRepository
    {
        private readonly EFContext eFContext;

        public IstoricRoluriRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<IstoricRoluri> CreateIstoricRoluriAsync(IstoricRoluri istoricRoluri)
        {
            await eFContext.AddAsync(istoricRoluri);

            await eFContext.SaveChangesAsync();

            return istoricRoluri;
        }

        public async Task DeleteIstoricRoluriByIdAsync(IstoricRoluri istoricRoluri)
        {
            eFContext.Remove(istoricRoluri);

            await eFContext.SaveChangesAsync();
        }

        public async Task<IstoricRoluri> GetIstoricRoluriByIdAsync(Guid istoricRoluriId)
        {
            return await eFContext
               .IstoricRoluri
               .FirstAsync(ip => ip.Id.Equals(istoricRoluriId));
        }

        public Task<List<IstoricRoluri>> GetIstoricRoluriByStaffIdAsync(Guid staffId)
        {
            return eFContext
                .IstoricRoluri
                .AsNoTracking()
                .Where(ir => ir.StaffId.Equals(staffId))
                .ToListAsync();
        }

        public async Task<IstoricRoluri> UpdateIstoricRoluri(IstoricRoluri istoricRoluri)
        {
            eFContext.Update(istoricRoluri);

            await eFContext.SaveChangesAsync();

            return istoricRoluri;
        }
    }
}
