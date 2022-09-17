using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Application.Features.Employee.Queries;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetEmployeeByIdFromAdminHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
            IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(GetEmployeeByIdFromAdminQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.NOTFOUND);

            var _department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
            var _title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
            var _mode = await _modeRepository.GetByIdAsync(employee.ModeId);

            var employResponse = _mapper.Map<EmployeeResponse>(employee);
            employResponse.TName = _title.TName;
            employResponse.DName = _department.DName;
            employResponse.MName = _mode.Value;

            return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.FETCHING_DATA_SUCCESSES, employResponse);
        }
    }
}
