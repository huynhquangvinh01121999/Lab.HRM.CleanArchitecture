using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Application.Features.Employee.Commands.Create;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Handlers.Create
{
    public class CreateNewEmployeeHandler : IRequestHandler<CreateNewEmployee, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IConfiguration _configuration;

        public CreateNewEmployeeHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
                                        IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository,
                                        IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _configuration = configuration;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(CreateNewEmployee request, CancellationToken cancellationToken)
        {
            var isValidREquest = CreateNewEmployeeValidator.ValidCreateNewEmployeeRequest(request);
            if (!isValidREquest.isValid)
                return new HandlerResult<EmployeeResponse>().Failed(isValidREquest.Message);

            // validation
            var isPhoneNumber = RegexHandle.IsPhoneNumber(request.EmployeeInfo.PhoneNumber);
            if (!isPhoneNumber)
                return new HandlerResult<EmployeeResponse>().Failed("Invalid phone number!");

            var isEmail = RegexHandle.IsEmail(request.EmployeeInfo.Email);
            if (!isEmail)
                return new HandlerResult<EmployeeResponse>().Failed("Invalid email!");

            // pass OK
            // save file
            try
            {
                string srcDestination = _configuration["ImageSavePath"];
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

                // mapping dto to entity
                var employee = new Employees
                {
                    FullName = request.EmployeeInfo.FullName,
                    DoB = request.EmployeeInfo.DoB,
                    PoB = request.EmployeeInfo.PoB,
                    PhoneNumber = request.EmployeeInfo.PhoneNumber,
                    Email = request.EmployeeInfo.Email,
                    TitleId = request.EmployeeInfo.TitleId,
                    DepartmentId = request.EmployeeInfo.DepartmentId,
                    ModeId = request.EmployeeInfo.ModeId,
                    ImagePath = path
                };

                var result = await _employeeRepository.CreateAsync(employee);

                if (result != null)
                {
                    var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
                    var title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
                    var mode = await _modeRepository.GetByIdAsync(employee.ModeId);

                    return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.CREATED_SUCCESSES,
                        new EmployeeResponse
                        {
                            Id = employee.Id,
                            FullName = request.EmployeeInfo.FullName,
                            DoB = request.EmployeeInfo.DoB,
                            PoB = request.EmployeeInfo.PoB,
                            PhoneNumber = request.EmployeeInfo.PhoneNumber,
                            Email = request.EmployeeInfo.Email,
                            TName = title.TName,
                            DName = department.DName,
                            MName = mode.Value,
                            Path = path
                        });
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
