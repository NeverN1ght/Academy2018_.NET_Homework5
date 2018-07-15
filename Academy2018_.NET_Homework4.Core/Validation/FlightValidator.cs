using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class FlightValidator: AbstractValidator<Flight>
    {
        public FlightValidator()
        {
            RuleFor(f => f.Number)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleForEach(f => f.Tickets)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.ArrivalTime)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.DeparturePoint)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.DestinationPoint)
                .NotNull()
                .NotEmpty();
        }
    }
}
