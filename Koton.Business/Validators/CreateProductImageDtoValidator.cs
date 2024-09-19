using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Koton.Core.Dtos.Concrete.ProductImageDtos;

namespace Koton.Business.Validators
{
    public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Product ID cannot be null or empty.");
            RuleFor(x => x.ProductImageUrl).NotEmpty().WithMessage("The list of image URLs cannot be empty.")
                .Must(urls => urls.All(url => !string.IsNullOrWhiteSpace(url)))
                .WithMessage("All image URLs must be non-empty and non-whitespace.");
        }
    }
}
