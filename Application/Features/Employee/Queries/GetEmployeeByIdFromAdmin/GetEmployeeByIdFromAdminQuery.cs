using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;

namespace Application.Features.Employee.Queries.GetEmployeeByIdFromAdmin
{
    public class GetEmployeeByIdFromAdminQuery : IRequest<HandlerResult<EmployeeResponse>>
    {
        public int Id { get; set; }
    }
}
