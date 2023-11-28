using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;

namespace CSU_Suceava_BE.Application.Services
{
    public class IstoricRoluriService : IIstoricRoluriService
    {
        private readonly IIstoricRoluriRepository istoricRoluriRepository;
        private readonly IMapper mapper;

        public IstoricRoluriService(IIstoricRoluriRepository istoricRoluriRepository, IMapper mapper)
        {
            this.istoricRoluriRepository = istoricRoluriRepository;
            this.mapper = mapper;
        }

        public async Task<IstoricRoluriResponseDto> CreateIstoricRoluriAsync(IstoricRoluriCreateDto istoricRoluri, Guid staffId)
        {
            var istoricRoluriToCreate = mapper.Map<IstoricRoluri>(istoricRoluri);
            istoricRoluriToCreate.StaffId = staffId;

            var createdIstoricRoluri = await istoricRoluriRepository
                .CreateIstoricRoluriAsync(istoricRoluriToCreate);

            return mapper.Map<IstoricRoluriResponseDto>(createdIstoricRoluri);
        }

        public async Task DeleteIstoricRoluriByIdAsync(Guid istoricRoluriId)
        {
            var istoricRoluri = await istoricRoluriRepository
                .GetIstoricRoluriByIdAsync(istoricRoluriId);

            await istoricRoluriRepository.DeleteIstoricRoluriByIdAsync(istoricRoluri);
        }

        public async Task<List<IstoricRoluriResponseDto>> GetIstoricRoluriByStaffIdAsync(Guid staffId)
        {
            var istoricRoluri = await istoricRoluriRepository
                .GetIstoricRoluriByStaffIdAsync(staffId);

            return mapper.Map<List<IstoricRoluriResponseDto>>(istoricRoluri);
        }

        public async Task<IstoricRoluriResponseDto> UpdateIstoricRoluriByIdAsync(Guid istoricRoluriId, 
                                                                           IstoricRoluriCreateDto istoricRoluri)
        {
            var existingIstoricRoluri = await istoricRoluriRepository.GetIstoricRoluriByIdAsync(istoricRoluriId);

            var updatedIstoricPremii = await istoricRoluriRepository
                .UpdateIstoricRoluri(mapper.Map(istoricRoluri, existingIstoricRoluri));

            return mapper.Map<IstoricRoluriResponseDto>(updatedIstoricPremii);
        }
    }
}
