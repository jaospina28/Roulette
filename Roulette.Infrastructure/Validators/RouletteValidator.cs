using FluentValidation;
using Roulette.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Infrastructure.Validators
{
    public class RouletteValidator : AbstractValidator<RouletteDto>
    {
        public RouletteValidator()
        {
            RuleFor(roulette => roulette.Name)
                .NotNull();
        }
    }
}
