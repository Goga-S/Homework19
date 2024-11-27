using FluentValidation;
using Model;

namespace Homework19_EFcore.Validation
{
    public class PersonAddValidation: AbstractValidator<Person>
    {
        public PersonAddValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.CreateDate)
                .NotEmpty()
                .LessThan(DateTime.Now).WithMessage("Date should not be less than current date");
        }
    }
}
