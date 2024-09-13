using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.CategoryDtos;

    public class ResultCategoryDto : IDto
{
        public string Id { get; set; } = default!;

        public String CategoryName { get; set; } = default!;
    }

