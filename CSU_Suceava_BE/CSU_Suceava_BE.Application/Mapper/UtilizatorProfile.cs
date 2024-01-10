using AutoMapper;
using CSU_Suceava_BE.Application.Models.Utilizator;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class UtilizatorProfile : Profile
    {
        public UtilizatorProfile()
        {
            CreateMap<Utilizator, UtilizatorResponseDto>();
        }
    }
}
