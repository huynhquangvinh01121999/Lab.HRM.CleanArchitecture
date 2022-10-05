using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Commands.CreateEmployees
{
    public class CreateNewEmployeeCommand : IRequest<HandlerResult<EmployeeResponse>>
    {
        public EmployeeRequest EmployeeInfo { get; set; }
        public IFormFile Image { get; set; }
    }

    public class CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, HandlerResult<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CreateNewEmployeeCommandHandler(IEmployeeRepository employeeRepository, IModeRepository modeRepository,
                                        IDepartmentRepository departmentRepository, ITitleNameRepository titleNameRepository,
                                        IConfiguration configuration, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<HandlerResult<EmployeeResponse>> Handle(CreateNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            // validation
            //var isPhoneNumber = RegexHandle.IsPhoneNumber(request.EmployeeInfo.PhoneNumber);
            //if (!isPhoneNumber)
            //    return new HandlerResult<EmployeeResponse>().Failed("Invalid phone number!");

            //var isEmail = RegexHandle.IsEmail(request.EmployeeInfo.Email);
            //if (!isEmail)
            //    return new HandlerResult<EmployeeResponse>().Failed("Invalid email!");

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
                var employee = _mapper.Map<Employees>(request.EmployeeInfo);
                employee.ImagePath = path;

                var result = await _employeeRepository.CreateAsync(employee);

                if (result != null)
                {
                    var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
                    var title = await _titleNameRepository.GetByIdAsync(employee.TitleId);
                    var mode = await _modeRepository.GetByIdAsync(employee.ModeId);

                    // mapper from entity to response model
                    var employeeResponse = _mapper.Map<EmployeeResponse>(employee);
                    employeeResponse.TName = title.TName;
                    employeeResponse.DName = department.DName;
                    employeeResponse.MName = mode.Value;

                    return new HandlerResult<EmployeeResponse>().Successed(Constant.Message.CREATED_SUCCESSES, employeeResponse);
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
