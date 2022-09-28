using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Employee.Queries.GetListEmployees
{
    public class GetListEmployeeQuery : IRequest<HandlerResult<List<EmployeeResponse>>>
    {
        public string token { get; set; }
    }
}
