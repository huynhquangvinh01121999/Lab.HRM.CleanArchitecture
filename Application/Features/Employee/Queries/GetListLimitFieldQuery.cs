using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Employee.Queries
{
    public class GetListLimitFieldQuery : IRequest<HandlerResult<List<EmployeeLimitResponse>>>
    {
        public string token { get; set; }
    }
}
