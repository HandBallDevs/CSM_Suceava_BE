using AutoMapper;
using CSU_Suceava_BE.Application.Models;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class StaffProfile:Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffDto, Staff>();

            CreateMap<Staff, StaffDto>();
        }
    }
}
