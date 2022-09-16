using Application.DTOs.AuthenticateDto;
using Application.DTOs.ResultDto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Users.Commands.Create
{
    public class RegisterAdminCommand : IRequest<HandlerResult<RegisterResponse>>
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required!")]
        public string PhoneNumber { get; set; }
    }
}
