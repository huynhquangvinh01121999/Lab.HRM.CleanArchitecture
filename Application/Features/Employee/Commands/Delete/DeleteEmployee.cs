using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System;

namespace Application.Features.Employee.Commands.Delete
{
    public class DeleteEmployee : IRequest<HandlerResult<EmployeeResponse>>
    {
        public int Id { get; set; }
    }
}
