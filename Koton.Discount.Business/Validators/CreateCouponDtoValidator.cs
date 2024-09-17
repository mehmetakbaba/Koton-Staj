using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Koton.Discount.Core.Dtos.Concrete;


namespace Koton.Discount.Business.Validators
{
    public class CreateCouponDtoValidator : AbstractValidator<CreateCouponDto>
    {
        public CreateCouponDtoValidator()
        {

            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(3, 50).WithMessage("Code must be between 3 and 50 characters.");

            RuleFor(c => c.Rate)
                .InclusiveBetween(0, 100).WithMessage("Rate must be between 0 and 100.");

            RuleFor(c => c.IsActive)
                .NotNull().WithMessage("IsActive is required.");

            RuleFor(c => c.ValidDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("ValidDate must be in the future.");
        }
    }
}
