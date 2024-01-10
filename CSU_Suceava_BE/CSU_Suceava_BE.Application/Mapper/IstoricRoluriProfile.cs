using AutoMapper;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class IstoricRoluriProfile : Profile
    {
        public IstoricRoluriProfile()
        {
            CreateMap<IstoricRoluriCreateDto, IstoricRoluri>();

            CreateMap<IstoricRoluri, IstoricRoluriResponseDto>();
        }
    }
}
