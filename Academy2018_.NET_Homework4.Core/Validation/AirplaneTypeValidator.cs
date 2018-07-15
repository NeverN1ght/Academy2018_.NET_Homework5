using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class AirplaneTypeValidator: AbstractValidator<AirplaneType>
    {
        public AirplaneTypeValidator()
        {
            RuleFor(a => a.AirplaneModel)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(a => a.CarryingCapacity)
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.SeatsCount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
