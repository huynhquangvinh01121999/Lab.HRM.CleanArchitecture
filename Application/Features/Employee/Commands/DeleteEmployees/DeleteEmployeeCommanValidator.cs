using FluentValidation;

namespace Application.Features.Employee.Commands.DeleteEmployees
{
    public class DeleteEmployeeCommanValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommanValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
