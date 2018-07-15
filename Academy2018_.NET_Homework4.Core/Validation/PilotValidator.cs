using System;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class PilotValidator: AbstractValidator<Pilot>
    {
        public PilotValidator()
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(p => p.Birthdate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
            RuleFor(p => p.Experience)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
