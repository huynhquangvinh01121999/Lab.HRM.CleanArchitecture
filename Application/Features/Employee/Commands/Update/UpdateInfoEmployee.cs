using Application.DTOs.EmployeeDto;
using Application.DTOs.ResultDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Employee.Commands.Update
{
    public class UpdateInfoEmployee : IRequest<HandlerResult<EmployeeResponse>>
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "DoB is required")]
        public DateTime DoB { get; set; }

        public string PoB { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "TID is required")]
        public int TID { get; set; }


        [Required(ErrorMessage = "DID is required")]
        public int DID { get; set; }


        [Required(ErrorMessage = "MID is required")]
        public int MID { get; set; }
    }
}
