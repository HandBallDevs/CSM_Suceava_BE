﻿using AutoMapper;
using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Domain.Entities;

namespace CSU_Suceava_BE.Application.Mapper
{
    public class StaffProfile:Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffCreateDto, Staff>();

            CreateMap<Staff, StaffResponseDto>();
        }
    }
}
