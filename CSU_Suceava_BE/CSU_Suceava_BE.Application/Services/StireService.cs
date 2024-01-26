using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Application.Models.Stire;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;

namespace CSU_Suceava_BE.Application.Services
{
    public class StireService : IStireService
    {
        private readonly IStireRepository stireRepository;
        private readonly IMapper mapper;
        private readonly BlobStorageService blobStorageService;

        public StireService(IStireRepository stireRepository, IMapper mapper, BlobStorageService blobStorageService)
        {
            this.stireRepository = stireRepository;
            this.mapper = mapper;
            this.blobStorageService = blobStorageService;

        }

        public async Task<StireResponseDto> CreateStireAsync(Guid creatorId, StireCreateDto stire)
        {
            stire.URLPoza = await blobStorageService.UploadImageAsync(stire.URLPoza, nameof(Stire));
            var stireToCreate = mapper.Map<Stire>(stire);
            stireToCreate.UtilizatorId = creatorId;
            stireToCreate.DataPostare = DateTime.UtcNow;

            var createdStire = await stireRepository.CreateStireAsync(stireToCreate);

            return mapper.Map<StireResponseDto>(createdStire);
        }

        public async Task DeleteStireAsync(Guid id)
        {
            var stire = await stireRepository.GetStireByIdAsync(id);

            await stireRepository.DeleteStireAsync(stire);
        }

        public async Task<StireResponseDto> GetStireByIdAsync(Guid id)
        {
            var stire = await stireRepository.GetStireByIdAsync(id);

            return mapper.Map<StireResponseDto>(stire);
        }

        public async Task<List<StireResponseDto>> GettAllStiriAsync()
        {
            var stiri = await stireRepository.GettAllStiriAsync();

            return mapper.Map<List<StireResponseDto>>(stiri);
        }

        public async Task<StireResponseDto> UpdateStireAsync(Guid id, StireCreateDto stire)
        {
            stire.URLPoza = await blobStorageService.UploadImageAsync(stire.URLPoza, nameof(Stire));
            var existingStire = await stireRepository.GetStireByIdAsync(id);

            var updatedStire = await stireRepository
                .UpdateStireAsync(mapper.Map(stire, existingStire));

            return mapper.Map<StireResponseDto>(updatedStire);
        }
    }
}
