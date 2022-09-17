using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Application.Features.Employee.Commands.Update;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Handlers.Update
{
    public class UpdateImageEmployeeHandler : IRequestHandler<UpdateImageEmployee, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IMapper _mapper;

        public UpdateImageEmployeeHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
                                        IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository,
                                        IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(UpdateImageEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            if (employee == null)
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.NOTFOUND);

            try
            {
                string srcDestination = Constant.Path.ImageSavePath;
                string[] fileNameSplit = request.Image.FileName.Trim().Split(".");
                string fileName = null;
                for (var i = 0; i < fileNameSplit.Length - 1; i++)
                {
                    fileName += fileNameSplit[i];
                }
                string fileExtension = fileNameSplit[fileNameSplit.Length - 1];
                string path = Path.Combine(srcDestination, fileName + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + fileExtension);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }

                // mapping
                employee.ImagePath = path;

                var result = await _employeeRepository.UpdateAsync(employee);

                if (result != null)
                {
                    var _department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
                    var _title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
                    var _mode = await _modeRepository.GetByIdAsync(employee.ModeId);

                    // mapper from entity to response model
                    var employeeResponse = _mapper.Map<EmployeeResponse>(employee);
                    employeeResponse.TName = _title.TName;
                    employeeResponse.DName = _department.DName;
                    employeeResponse.MName = _mode.Value;
                    employeeResponse.Path = path;

                    return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.UPDATE_SUCCESSES, employeeResponse);
                }

                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.FAILURE);
            }
            catch (Exception ex)
            {
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.EXCEPTIONS + ex.Message);
            }

        }
    }
}
