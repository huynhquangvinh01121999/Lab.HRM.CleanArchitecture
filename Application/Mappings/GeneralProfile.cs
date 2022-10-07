using Application.DTOs.AuthenticateDto;
using Application.DTOs.EmployeeDto;
using Application.Features.Notifications.Commands.CreatePushNotify;
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
                .ForMember(res => res.Path , map => map.MapFrom(entity => entity.ImagePath))
                .ForMember(res => res.TName, map => map.MapFrom(entity => entity.TitleName.TName))
                .ForMember(res => res.DName, map => map.MapFrom(entity => entity.Department.DName))
                .ForMember(res => res.MName, map => map.MapFrom(entity => entity.Mode.Value));

            CreateMap<Employees, EmployeeLimitResponse>();

            CreateMap<EmployeeRequest, Employees>();

            CreateMap<PushNotifyCommand, Notify>();
        }
    }
}
