using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Employee.Queries
{
    public class GetListEmployeeQuery : IRequest<HandlerResult<List<EmployeeResponse>>>
    {
        public string token { get; set; }
    }
}
