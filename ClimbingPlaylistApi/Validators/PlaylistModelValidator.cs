using ClimbingPlaylistApi.Models;
using FluentValidation;

namespace ClimbingPlaylistApi.Validators
{
    public class PlaylistModelValidator : AbstractValidator<PlaylistModel>
    {
        public PlaylistModelValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Continue)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(256).WithMessage("{PropertyName} cannot be longer than 256 characters.");
        }
    }
}
