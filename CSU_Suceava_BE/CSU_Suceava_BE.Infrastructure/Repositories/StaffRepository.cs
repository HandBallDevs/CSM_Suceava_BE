using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly EFContext eFContext;

        public StaffRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            await eFContext.AddAsync(staff);
            await eFContext.SaveChangesAsync();

            return staff;
        }

        public async Task DeleteStaffAsync(Staff staff)
        {
            eFContext.Remove(staff);
            await eFContext.SaveChangesAsync();
        }

        public async Task<Staff> GetStaffAsync(Guid staffId)
        {
          return await eFContext
                .Staff
                .AsNoTracking()
                .FirstAsync(s => s.Id.Equals(staffId));
        }

        public async Task<Staff> UpdateStaffAsync(Staff staff)
        {
            eFContext.Update(staff);
            await eFContext.SaveChangesAsync();

            return staff;
        }
    }
}
