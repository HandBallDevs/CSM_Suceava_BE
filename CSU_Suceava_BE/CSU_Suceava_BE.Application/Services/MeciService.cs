using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Meci;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Domain.Enums;
using CSU_Suceava_BE.Infrastructure.Interfaces;

namespace CSU_Suceava_BE.Application.Services
{
    public class MeciService : IMeciService
    {
        private readonly IMeciRepository meciRepository;
        private readonly IMapper mapper;
        private readonly BlobStorageService blobStorageService;

        public MeciService(IMeciRepository meciRepository, IMapper mapper, BlobStorageService blobStorageService)
        {
            this.meciRepository = meciRepository;
            this.mapper = mapper;
            this.blobStorageService = blobStorageService;
        }

        public async Task<MeciResponseDto> CreateMeciAsync(MeciCreateDto meci)
        {
            meci.URLPoza = await blobStorageService.UploadImageAsync(meci.URLPoza, nameof(Meci));

            var meciToCreate = mapper.Map<Meci>(meci);

            var createdMeci = await meciRepository.CreateMeciAsync(meciToCreate);

            return mapper.Map<MeciResponseDto>(createdMeci);
        }

        public async Task DeleteMeciByIdAsync(Guid id)
        {
            var meci = await meciRepository.GetMeciByIdAsync(id);

            await meciRepository.DeleteMeciByIdAsync(meci);
        }

        public async Task<List<MeciResponseDto>> GetFilteredMeciuri(StatusMeci? statusMeci, TipCampionat? tipCampionat, string? editie)
        {
            var meciuri = new List<Meci>();
            if (statusMeci is not null)
            {
                meciuri = await meciRepository.GetMeciuriDupaStatusAsync(statusMeci.Value);
            }
            else if (tipCampionat is not null)
                meciuri = await meciRepository.GetMeciuriDupaCampionatAsync(tipCampionat.Value);
            else meciuri = await meciRepository.GetMeciuriDupaEditieAsync(editie!);

            return mapper.Map<List<MeciResponseDto>>(meciuri);
        }

        public async Task<MeciResponseDto> GetMeciByIdAsync(Guid id)
        {
            var meci = await meciRepository.GetMeciByIdAsync(id);

            return mapper.Map<MeciResponseDto>(meci);
        }

        public async Task<List<MeciResponseDto>> GetMeciuriAsync()
        {
            var meciuri = await meciRepository.GetMeciuriAsync();

            return mapper.Map<List<MeciResponseDto>>(meciuri);
        }

    
        

        public async Task<MeciResponseDto> UpdateMeciAsync(Guid id, MeciCreateDto meci)
        {
            meci.URLPoza = await blobStorageService.UploadImageAsync(meci.URLPoza, nameof(Staff));
            var existingMeci = await meciRepository.GetMeciByIdAsync(id);

            var updatedMeci = await meciRepository
                .UpdateMeciAsync(mapper.Map(meci, existingMeci));

            return mapper.Map<MeciResponseDto>(updatedMeci);
        }
    }
}
