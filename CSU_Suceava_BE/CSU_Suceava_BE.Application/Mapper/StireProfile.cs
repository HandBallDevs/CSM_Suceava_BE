using AutoMapper;
using CSU_Suceava_BE.Application.Models.Stire;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class StireProfile:Profile
    {
        public StireProfile()
        {
            CreateMap<StireCreateDto, Stire>();

            CreateMap<Stire, StireResponseDto>();
        }
    }
}
