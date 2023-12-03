using AutoMapper;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using CSU_Suceava_BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
