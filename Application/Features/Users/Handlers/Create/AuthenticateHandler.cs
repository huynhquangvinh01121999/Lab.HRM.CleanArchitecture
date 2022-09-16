using Application.DTOs.AuthenticateDto;
using Application.DTOs.ResultDto;
using Application.Features.Users.Commands.Create;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Users.Handlers.Create
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, HandlerResult<LoginResponse>>
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticateHandler(UserManager<AppUsers> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<HandlerResult<LoginResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            // kiểm tra tài khoản có tồn tại hay không?
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                return new HandlerResult<LoginResponse>().Failed(Constant.Message.USER_NOT_EXIST);

            // kiểm tra mật khẩu có chính xác hay không
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
                return new HandlerResult<LoginResponse>().Failed(Constant.Message.PWD_NOT_CORRECT);

            // lấy ra các quyền của user
            var userRoles = await _userManager.GetRolesAsync(user);

            // khởi tạo danh sách chứa các claim
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            // thêm claim vào danh sách
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            // generate access token
            var accessToken = generateAccessToken(authClaims);

            return new HandlerResult<LoginResponse>().Successed(Constant.Message.AUTHENTICATE_OK, new LoginResponse
            {
                UserId = user.Id,
                Username = request.Username,
                Phone = user.PhoneNumber,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                Expiration = accessToken.ValidTo
            });
        }

        // generate token
        private JwtSecurityToken generateAccessToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Constant.JWT.SECRET]));

            var token = new JwtSecurityToken(
                issuer: _configuration[Constant.JWT.VALID_ISSUER],
                audience: _configuration[Constant.JWT.VALID_AUDIENCE],
                expires: DateTime.Now.AddHours(Constant.JWT.EXPIRES_TOKEN),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
