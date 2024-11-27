using FluentValidation;
using Model;

namespace Homework19_EFcore.Validation
{
    public class validationForGet: AbstractValidator<Tasks>
    {
        public validationForGet()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
