using AutoMapper;
using Koton.Core.Dtos.Concrete.CategoryDtos;
using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Core.Dtos.Concrete.ProductImageDtos;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;
using Koton.Entity.Entities.Concrete;

namespace Koton.Business.Mappings
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<Category,CreateCategoryDto >().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImage>().ReverseMap();

            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        }
    }
}
