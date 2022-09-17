﻿using Application.DTOs.AuthenticateDto;
using Application.DTOs.EmployeeDto;
using Application.Features.Employee.Commands.Create;
using Application.Features.Notifications.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AppUsers, RegisterResponse>()
                .ForMember(res => res.UserId , map => map.MapFrom(entity => entity.Id));
            
            CreateMap<Employees, EmployeeResponse>()
                .ForMember(res => res.Path , map => map.MapFrom(entity => entity.ImagePath));

            CreateMap<Employees, EmployeeLimitResponse>();

            CreateMap<EmployeeRequest, Employees>();

            CreateMap<PushNotify, Notify>();
        }
    }
}