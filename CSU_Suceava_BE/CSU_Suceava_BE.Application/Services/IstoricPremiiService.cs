using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Domain.Entities;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;

namespace CSU_Suceava_BE.Application.Services
{
    public class IstoricPremiiService : IIstoricPremiiService
    {
        private readonly IIstoricPremiiRepository istoricPremiiRepository;
        private readonly IMapper mapper;

        public IstoricPremiiService(IIstoricPremiiRepository istoricPremiiRepository, IMapper mapper)
        {
            this.istoricPremiiRepository = istoricPremiiRepository;
            this.mapper = mapper;
        }

        public async Task<IstoricPremiiResponseDto> CreateIstoricPremiiAsync(IstoricPremiiCreateDto istoricPremii, Guid staffId)
        {
            var istoricPremiiToCreate = mapper.Map<IstoricPremii>(istoricPremii);
            istoricPremiiToCreate.StaffId = staffId;

            var createdIstoricPremii = await istoricPremiiRepository
                .CreateIstoricPremiiAsync(istoricPremiiToCreate);

            return mapper.Map<IstoricPremiiResponseDto>(createdIstoricPremii);
        }

        public async Task DeleteIstoricPremiiByIdAsync(Guid istoricPremiiId)
        {
            var istoricPremii = await istoricPremiiRepository
                .GetIstoricPremiiByIdAsync(istoricPremiiId);

            await istoricPremiiRepository.DeleteIstoricPremiiByIdAsync(istoricPremii);
        }

        public async Task<List<IstoricPremiiResponseDto>> GetIstoricPremiiByStaffIdAsync(Guid staffId)
        {
           var istoricPremii = await istoricPremiiRepository
                .GetIstoricPremiiByStaffIdAsync(staffId);

            return mapper.Map<List<IstoricPremiiResponseDto>>(istoricPremii);
        }

        public async Task<IstoricPremiiResponseDto> UpdateIstoricPremiiByIdAsync(Guid istoricPremiiId, 
                                                                     IstoricPremiiCreateDto istoricPremii)
        {
            var existingIstoricPremii = await istoricPremiiRepository.GetIstoricPremiiByIdAsync(istoricPremiiId);

            var updatedIstoricPremii = await istoricPremiiRepository
                .UpdateIstoricPremii(mapper.Map(istoricPremii, existingIstoricPremii));

            return mapper.Map<IstoricPremiiResponseDto>(updatedIstoricPremii);
        }
    }
}
