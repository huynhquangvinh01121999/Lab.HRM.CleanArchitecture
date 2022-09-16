using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Application.Features.Employee.Queries;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Handlers.Get
{
    public class GetEmployeeByIdFromAdminHandler : IRequestHandler<GetEmployeeByIdFromAdminQuery, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;

        public GetEmployeeByIdFromAdminHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
            IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(GetEmployeeByIdFromAdminQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.NOTFOUND);

            var _department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
            var _title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
            var _mode = await _modeRepository.GetByIdAsync(employee.ModeId);

            return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.FETCHING_DATA_SUCCESSES,
                new EmployeeResponse
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    DoB = employee.DoB,
                    PoB = employee.PoB,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    TName = _title.TName,
                    DName = _department.DName,
                    MName = _mode.MName,
                    Path = employee.ImagePath
                });
        }
    }
}
