using AutoMapper;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class IstoricPremiiProfile:Profile
    {
        public IstoricPremiiProfile()
        {
            CreateMap<IstoricPremiiCreateDto, IstoricPremii>();

            CreateMap<IstoricPremii, IstoricPremiiResponseDto>();
        }
    }
}
