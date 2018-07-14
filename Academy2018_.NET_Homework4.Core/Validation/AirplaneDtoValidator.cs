﻿using System;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class AirplaneDtoValidator: AbstractValidator<AirplaneDto>
    {
        public AirplaneDtoValidator()
        {
            RuleFor(a => a.ExploitationTerm)
                .NotNull()
                .GreaterThan(TimeSpan.Zero);
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);
            RuleFor(a => a.ReleaseDate)
                .NotNull()
                .LessThan(DateTime.Now);
            RuleFor(a => a.Type)
                .NotNull();
        }
    }
}
