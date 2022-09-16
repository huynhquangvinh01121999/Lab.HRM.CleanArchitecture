using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System;

namespace Application.Features.Employee.Queries
{
    public class GetEmployeeByIdFromAdminQuery : IRequest<HandlerResult<EmployeeResponse>>
    {
        public int Id { get; set; }
    }
}
