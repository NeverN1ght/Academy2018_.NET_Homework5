﻿using System;
using Academy2018_.NET_Homework5.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Validation
{
    public class StewardesseDtoValidator: AbstractValidator<StewardesseDto>
    {
        public StewardesseDtoValidator()
        {
            RuleFor(s => s.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(s => s.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(s => s.Birthdate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
        }
    }
}
