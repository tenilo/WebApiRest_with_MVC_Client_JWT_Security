using FluentValidation;
using MyMusic.API.Resources;

namespace MyMusic.API.Validation
{
    public class saveUserResourceValidation : AbstractValidator<UserResource>
    {
        public saveUserResourceValidation()
        {
            RuleFor(m => m.FirstName)
             .NotEmpty()
             .MaximumLength(50);
            RuleFor(m => m.LastName)
             .NotEmpty()
             .MaximumLength(50);
            RuleFor(m => m.Username)
             .NotEmpty()
             .MaximumLength(50);
            RuleFor(m => m.Password)
             .NotEmpty()
             .MaximumLength(50);
        }
    }
}
