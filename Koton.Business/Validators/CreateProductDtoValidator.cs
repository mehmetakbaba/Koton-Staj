using FluentValidation;
using Koton.Core.Dtos.Concrete.ProductDtos;

namespace Koton.Catalog.Business.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Product name cannot be null or empty.");

            RuleFor(x => x.ProductName).Length(1, 30)
                .WithMessage("Product name must be between 1 and 30 characters long");

            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Category ID  cannot be null or empty.");

            RuleFor(x => x.ProductPrice).GreaterThan(0).WithMessage("Product price must be greater than 0.");

            RuleFor(x => x).Must(HaveMatchingStockTotal)
                .WithMessage("The total stock quantity of all sizes must match the product quantity.");

            RuleFor(x => x.ProductColor).NotNull().NotEmpty().WithMessage("Product Color  cannot be null or empty.");

            RuleFor(x => x.ProductImageUrl)
                .NotEmpty().WithMessage("The list of image URLs cannot be empty.")
                .Must(urls => urls.All(url => !string.IsNullOrWhiteSpace(url)))
                .WithMessage("All image URLs must be non-empty and non-whitespace.");
            RuleFor(x => x.ProductDespriction).NotNull().NotEmpty()
                .WithMessage("Product Despriction cannot be null or empty.");
        }
        private bool HaveMatchingStockTotal(CreateProductDto dto)
        {
            if (dto.ProductSizeQuantity == null || !dto.ProductSizeQuantity.Any())
            {
                return dto.ProductAllQuantity == 0;
            }

            int totalStock = dto.ProductSizeQuantity.Values.Sum();
            return totalStock == dto.ProductAllQuantity;
        }
    }
}
