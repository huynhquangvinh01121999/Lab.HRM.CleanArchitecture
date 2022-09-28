using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System;

namespace Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<HandlerResult<EmployeeLimitResponse>>
    {
        public int Id { get; set; }
    }
}
