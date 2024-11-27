using FluentValidation;
using Model;

namespace Homework19_EFcore.Validation
{
    public class TaskAddValidation: AbstractValidator<Tasks>
    {
        public TaskAddValidation()
        {
            RuleFor(r => r.TaskName)
                .NotEmpty()
                .Length(5, 1000).WithMessage("not within length limit");

            RuleFor(r => r.completed)
                .NotEmpty();
     
        }
    }
}
