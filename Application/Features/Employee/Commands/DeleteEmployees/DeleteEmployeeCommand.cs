using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System;

namespace Application.Features.Employee.Commands.DeleteEmployees
{
    public class DeleteEmployeeCommand : IRequest<HandlerResult<EmployeeResponse>>
    {
        public int Id { get; set; }
    }
}
