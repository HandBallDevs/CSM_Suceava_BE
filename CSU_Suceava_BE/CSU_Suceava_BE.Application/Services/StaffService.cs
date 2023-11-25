using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Interfaces;

namespace CSU_Suceava_BE.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository staffRepository;
        private readonly IMapper mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper)
        {
            this.staffRepository = staffRepository;
            this.mapper = mapper;
        }

        public async Task<StaffDto> CreateStaffAsync(StaffDto staff)
        {
            var createdStaff = await staffRepository
                .CreateStaffAsync(mapper.Map<Staff>(staff));

            return mapper.Map<StaffDto>(createdStaff);
        }

        public async Task DeleteStaffAsync(Guid staffId)
        {
            var staff = await staffRepository.GetStaffAsync(staffId);

            await staffRepository.DeleteStaffAsync(staff);
        }

        public async  Task<StaffDto> GetStaffAsync(Guid staffId)
        {
            var staff = await staffRepository.GetStaffAsync(staffId);

            return mapper.Map<StaffDto>(staff);
        }

        public async Task<StaffDto> UpdateStaffAsync(StaffDto staff)
        {
            var updatedStaff = await staffRepository
                .UpdateStaffAsync(mapper.Map<Staff>(staff));

            return mapper.Map<StaffDto>(updatedStaff);
        }
    }
}
