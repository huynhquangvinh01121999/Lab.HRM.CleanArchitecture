using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Employee.Commands.Create
{
    public class CreateNewEmployee : IRequest<HandlerResult<EmployeeResponse>>
    {
        public EmployeeRequest EmployeeInfo { get; set; }
        public IFormFile Image { get; set; }
    }
}
