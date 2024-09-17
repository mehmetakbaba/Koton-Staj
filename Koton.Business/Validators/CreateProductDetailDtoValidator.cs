using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;

namespace Koton.Business.Validators
{
    public class CreateProductDetailDtoValidator : AbstractValidator<CreateProductDetailDto>
    {
        public CreateProductDetailDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Product ID cannot be null or empty.");
            RuleFor(x => x.ProductDetailDescription).NotNull().NotEmpty().WithMessage("Product Detail Description cannot be null or empty.");
        }
    }
}
