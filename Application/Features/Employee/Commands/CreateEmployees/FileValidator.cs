using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Employee.Commands.CreateEmployees
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.Length)
                .NotNull()
                .LessThanOrEqualTo(100)
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.ContentType)
                .NotNull()
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");
        }
    }
}
