using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using Application.Features.Employee.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Employee.Handlers.Get
{
    public class GetListEmployeeHandler : IRequestHandler<GetListEmployeeQuery, HandlerResult<List<EmployeeResponse>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IModeRepository _modeRepository;
        private readonly IRoleModeRepository _roleModeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleNameRepository _titleNameRepository;
        private readonly IMapper _mapper;

        public GetListEmployeeHandler(ITitleNameRepository titleNameRepository, IDepartmentRepository departmentRepository,
                                    IRoleModeRepository roleModeRepository, IModeRepository modeRepository, 
                                    IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _modeRepository = modeRepository;
            _roleModeRepository = roleModeRepository;
            _departmentRepository = departmentRepository;
            _titleNameRepository = titleNameRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<List<EmployeeResponse>>> Handle(GetListEmployeeQuery request, CancellationToken cancellationToken)
        {
            var listEmployees = await _employeeRepository.GetAllAsync();

            //try
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            //    tokenHandler.ValidateToken(request.token, new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    }, out SecurityToken validatedToken);

            //    var jwtToken = (JwtSecurityToken)validatedToken;
            //    var username = jwtToken.Claims.First(x => x.Type == Constant.JWT.CLAIM_TYPE).Value;

            //    // lấy ra user thông qua username
            //    var user = await _userManager.FindByNameAsync(username);

            //    // lấy ra quyền tương ứng của user trong table Role
            //    var userRoles = await _userManager.GetRolesAsync(user);
            //    var role = await _roleManager.FindByNameAsync(userRoles[0]);

            //    // lấy ra các mode của role thuộc user
            //    List<int> listModeRoleOfUser = new List<int>();
            //    var roleModes = await _roleModeRepository.GetAllAsync();

            //    foreach (var roleMode in roleModes)
            //    {
            //        if (role.Id.Equals(roleMode.RoleId))
            //            listModeRoleOfUser.Add(roleMode.ModeId);
            //    }

            //    // duyệt list moderole của user so với thông tin ns được public hay private
            //    // lấy ra ds nhân sự tương ứng
            //    List<EmployeeResponse> results = new List<EmployeeResponse>();
            //    foreach (var mode in listModeRoleOfUser)
            //    {
            //        foreach (var person in listEmployees)
            //        {
            //            if (mode.Equals(person.ModeId))
            //            {
            //                var _department = await _departmentRepository.GetByIdAsync(person.DepartmentId);
            //                var _title = await _titleNameRepository.GetByIdAsync(person.TitleId);
            //                var _mode = await _modeRepository.GetByIdAsync(person.ModeId);

            //                results.Add(
            //                    new EmployeeResponse
            //                    {
            //                        Id = person.Id,
            //                        FullName = person.FullName,
            //                        DoB = person.DoB,
            //                        PoB = person.PoB,
            //                        PhoneNumber = person.PhoneNumber,
            //                        Email = person.Email,
            //                        TName = _title.TName,
            //                        DName = _department.DName,
            //                        MName = _mode.Value,
            //                        Path = person.ImagePath
            //                    });
            //            }
            //        }
            //    }
            //    return new HandlerResult<List<EmployeeResponse>>().Successed(Constant.Message.FETCHING_DATA_SUCCESSES, results);
            //}
            //catch (Exception ex)
            //{
            //    return new HandlerResult<List<EmployeeResponse>>().Failed(Constant.Message.EXCEPTIONS + ex.Message);
            //}

            List<EmployeeResponse> results = new List<EmployeeResponse>();
            foreach (var person in listEmployees)
            {
                var _department = await _departmentRepository.GetByIdAsync(person.DepartmentId);
                var _title = await _titleNameRepository.GetByIdAsync(person.TitleId);
                var _mode = await _modeRepository.GetByIdAsync(person.ModeId);

                var employResponse = _mapper.Map<EmployeeResponse>(person);
                employResponse.TName = _title.TName;
                employResponse.DName = _department.DName;
                employResponse.MName = _mode.Value;

                results.Add(employResponse);
            }

            return new HandlerResult<List<EmployeeResponse>>()
                .Successed(Constant.Message.FETCHING_DATA_SUCCESSES, results);
        }
    }
}
