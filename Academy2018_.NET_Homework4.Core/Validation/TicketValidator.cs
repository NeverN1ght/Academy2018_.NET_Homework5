using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class TicketValidator: AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.FlightNumber)
                .NotNull()
                .NotEmpty();
            RuleFor(t => t.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
