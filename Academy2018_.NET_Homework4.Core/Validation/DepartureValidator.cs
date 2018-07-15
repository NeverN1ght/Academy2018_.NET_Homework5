using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class DepartureValidator: AbstractValidator<Departure>
    {
        public DepartureValidator()
        {
            RuleFor(d => d.Airplane)
                .NotNull();
            RuleFor(d => d.Crew)
                .NotNull();
            RuleFor(d => d.DepartureTime)
                .NotNull();
            RuleFor(d => d.FlightNumber)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
