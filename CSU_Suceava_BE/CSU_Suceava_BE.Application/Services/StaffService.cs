using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;
using CSU_Suceava_BE.Infrastructure.Interfaces;

namespace CSU_Suceava_BE.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly BlobStorageService blobStorageService;
        private readonly IStaffRepository staffRepository;
        private readonly IMapper mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper, BlobStorageService blobServiceClient)
        {
            this.blobStorageService = blobServiceClient;
            this.staffRepository = staffRepository;
            this.mapper = mapper;
        }

        public async Task<StaffResponseDto> CreateStaffAsync(StaffCreateDto staff)
        {
            staff.URLPoza = await blobStorageService.UploadImageAsync(staff.URLPoza, nameof(Staff));

            var createdStaff = await staffRepository.CreateStaffAsync(mapper.Map<Staff>(staff));

            return mapper.Map<StaffResponseDto>(createdStaff);
        }

        public async Task DeleteStaffAsync(Guid staffId)
        {
            var staff = await staffRepository.GetStaffAsync(staffId);

            await staffRepository.DeleteStaffAsync(staff);
        }

        public async Task<StaffResponseDto> GetStaffAsync(Guid staffId)
        {
            var staff = await staffRepository.GetStaffAsync(staffId);

            return mapper.Map<StaffResponseDto>(staff);
        }

        public async Task<List<StaffResponseDto>> GetStaffByType(TipLot tipLot)
        {
            var staff = await staffRepository.GetStaffByTypeAsync(tipLot);

            return mapper.Map<List<StaffResponseDto>>(staff);        }

        public async Task<StaffResponseDto> UpdateStaffAsync(StaffCreateDto staff)
        {
            var updatedStaff = await staffRepository
                .UpdateStaffAsync(mapper.Map<Staff>(staff));

            return mapper.Map<StaffResponseDto>(updatedStaff);
        }
    }
}
