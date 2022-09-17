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
    public class UpdateInfoEmployeeHandler : IRequestHandler<UpdateInfoEmployee, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IMapper _mapper;

        public UpdateInfoEmployeeHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
                                        IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository,
                                        IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(UpdateInfoEmployee request, CancellationToken cancellationToken)
        {
            var isValidREquest = UpdateInfoEmployeeValidator.ValidUpdateInfoEmployeeRequest(request);
            if (!isValidREquest.isValid)
                return new HandlerResult<EmployeeResponse>().Failed(isValidREquest.Message);

            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            if (employee == null)
                return new HandlerResult<EmployeeResponse>().Failed(Constant.Message.NOTFOUND);

            // validation
            var isPhoneNumber = RegexHandle.IsPhoneNumber(request.PhoneNumber);
            if (!isPhoneNumber)
                return new HandlerResult<EmployeeResponse>().Failed("Invalid phone number!");

            var isEmail = RegexHandle.IsEmail(request.Email);
            if (!isEmail)
                return new HandlerResult<EmployeeResponse>().Failed("Invalid email!");

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
                employee.FullName = request.FullName;
                employee.DoB = request.DoB;
                employee.PoB = request.PoB;
                employee.Email = request.Email;
                employee.PhoneNumber = request.PhoneNumber;
                employee.ImagePath = path;
                employee.TitleId = request.TID;
                employee.DepartmentId = request.DID;
                employee.ModeId = request.MID;


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
