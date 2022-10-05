using FluentValidation;

namespace Application.Features.Employee.Commands.CreateEmployees
{
    public class CreateNewEmployeeValidator : AbstractValidator<CreateNewEmployeeCommand>
    {
        public CreateNewEmployeeValidator()
        {
            RuleFor(p => p.Image)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty();

            RuleFor(p => p.EmployeeInfo.DoB)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty();

            RuleFor(p => p.EmployeeInfo.Email)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty()
               .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            RuleFor(p => p.EmployeeInfo.FullName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty();

            RuleFor(p => p.EmployeeInfo.ModeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty();

            RuleFor(p => p.EmployeeInfo.PhoneNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEmpty()
               .Matches(@"(84|0[3|5|7|8|9])+([0-9]{8})\b");
        }
    }
}
