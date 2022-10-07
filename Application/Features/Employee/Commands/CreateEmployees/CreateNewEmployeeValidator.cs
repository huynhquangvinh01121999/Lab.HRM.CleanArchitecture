using FluentValidation;

namespace Application.Features.Employee.Commands.CreateEmployees
{
    public class CreateNewEmployeeValidator : AbstractValidator<CreateNewEmployeeCommand>
    {
        public CreateNewEmployeeValidator()
        {
            RuleFor(p => p.Image).SetValidator(new FileValidator());

            RuleFor(p => p.EmployeeInfo.DoB)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.EmployeeInfo.Email)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
               //.Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
               //.When(p => p.EmployeeInfo.Email != null);

            RuleFor(p => p.EmployeeInfo.FullName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.EmployeeInfo.ModeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.EmployeeInfo.PhoneNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
               //.Matches(@"(84|0[3|5|7|8|9])+([0-9]{8})\b")
               //.When(p => p.EmployeeInfo.PhoneNumber != null);
        }
    }
}
