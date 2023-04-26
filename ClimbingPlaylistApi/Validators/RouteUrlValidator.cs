using ClimbingPlaylistApi.Domain;
using FluentValidation;

namespace ClimbingPlaylistApi.Validators
{
    public class RouteUrlValidator : AbstractValidator<RouteUrl>
    {
        public RouteUrlValidator()
        {
            //RuleFor(u => u.)
        }
    }
}
