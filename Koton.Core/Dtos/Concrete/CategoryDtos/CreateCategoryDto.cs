using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.CategoryDtos;

    public class CreateCategoryDto : IDto
    {
        public String CategoryName { get; set; } = default!;
}

