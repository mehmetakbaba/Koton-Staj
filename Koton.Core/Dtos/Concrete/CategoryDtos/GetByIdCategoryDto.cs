using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.CategoryDtos;

    public class GetByIdCategoryDto : IDto
{
        public string Id { get; set; } = default!;

        public String CategoryName { get; set; } = default!;
    }

