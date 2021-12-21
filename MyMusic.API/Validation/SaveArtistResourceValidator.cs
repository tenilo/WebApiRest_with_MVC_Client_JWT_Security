using FluentValidation;
using MyMusic.API.Resources;

namespace MyMusic.API.Validation
{
    public class SaveArtistResourceValidator : AbstractValidator<SaveArtistResource>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);
        }

    }
}
