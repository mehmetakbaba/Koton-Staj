using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Koton.Core.Dtos.Concrete.CategoryDtos;

namespace Koton.Business.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty().WithMessage("Category name cannot be null or empty.");
        }
    }
}
