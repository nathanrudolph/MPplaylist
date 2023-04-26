using ClimbingPlaylistApi.Models;
using FluentValidation;

namespace ClimbingPlaylistApi.Validators
{
    public class RouteModelValidator : AbstractValidator<RouteModel>
    {
        public RouteModelValidator()
        {
            //RuleFor(r => r.Url).Must(/*contain MpId*/).Must(/*contain Name*/); 
        }
    }
}
