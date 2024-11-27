using FluentValidation;
using Model;

namespace Homework19_EFcore.Validation
{
    public class TaskEditValidationcs: AbstractValidator<Tasks>
    {
        public TaskEditValidationcs()
        {
            RuleFor(r => r.completed || r.completed)
                .NotEmpty().WithMessage("You should edit at least one field");
        }
    }
}
