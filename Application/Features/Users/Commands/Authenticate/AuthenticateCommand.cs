using Application.DTOs.AuthenticateDto;
using Application.DTOs.ResultDto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Users.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<HandlerResult<LoginResponse>>
    {

        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
