using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Commands.DeleteEmployees
{
    public class DeleteEmployeeCommand : IRequest<HandlerResult<EmployeeResponse>>
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var personnel = await _employeeRepository.GetByIdAsync(request.Id);

            if (personnel == null)
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.NOTFOUND);

            var result = await _employeeRepository.DeleteAsync(request.Id);

            if (result)
                return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.DELETE_SUCCESSES);

            return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.FAILURE);
        }
    }
}
