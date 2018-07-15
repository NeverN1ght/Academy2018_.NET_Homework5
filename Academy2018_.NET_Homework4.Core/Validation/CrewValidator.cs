using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class CrewValidator: AbstractValidator<Crew>
    {
        public CrewValidator()
        {
            RuleFor(c => c.Pilot)
                .NotNull();
            RuleForEach(c => c.Stewardesses)
                .NotNull();
        }
    }
}
