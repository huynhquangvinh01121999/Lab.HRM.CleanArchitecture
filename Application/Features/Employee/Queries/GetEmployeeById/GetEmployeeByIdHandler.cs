using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, HandlerResult<EmployeeLimitResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
            IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<EmployeeLimitResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                return new HandlerResult<EmployeeLimitResponse>().Failed(Constant.Message.NOTFOUND);

            var _department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
            var _title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
            var _mode = await _modeRepository.GetByIdAsync(employee.ModeId);

            var employResponse = _mapper.Map<EmployeeLimitResponse>(employee);
            employResponse.TName = _title.TName;
            employResponse.DName = _department.DName;
            employResponse.MName = _mode.Value;

            return new HandlerResult<EmployeeLimitResponse>().Successed(Constant.Message.FETCHING_DATA_SUCCESSES, employResponse);
        }
    }
}
