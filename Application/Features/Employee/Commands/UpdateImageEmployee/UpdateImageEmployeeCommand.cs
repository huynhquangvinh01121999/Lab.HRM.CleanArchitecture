using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Employee.Commands.UpdateImageEmployee
{
    public class UpdateImageEmployeeCommand : IRequest<HandlerResult<EmployeeResponse>>
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }
    }
}
