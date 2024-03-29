﻿using AutoMapper;
using Domain.Dtos.User;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();            

            CreateMap<UserModel, UserCreateDto>()
                .ReverseMap();            

            CreateMap<UserModel, UserUpdateDto>()
                .ReverseMap();
        }
    }
}
