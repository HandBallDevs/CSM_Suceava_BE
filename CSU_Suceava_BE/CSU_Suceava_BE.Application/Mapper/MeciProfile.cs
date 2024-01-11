using AutoMapper;
using CSU_Suceava_BE.Application.Models.Meci;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class MeciProfile:Profile
    {
        public MeciProfile()
        {
            CreateMap<MeciCreateDto, Meci>();

            CreateMap<Meci, MeciResponseDto>();
        }
    }
}
