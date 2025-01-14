﻿using AutoMapper;
using Koton.Business.Services.ProductServices.Abstract;
using Koton.Catalog.DataAccess.Repositories.MongoDb.ProductRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;
using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Shared.Response;

namespace Koton.Catalog.Business.Services.ProductServices.Concrete
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        
        public async Task<Response<ResultProductDto>> GetProductByIdAsync(string id)
        {
            var productEntity = await productRepository.GetByIdAsync(id);

            if (productEntity == null)
            {
                return Response<ResultProductDto>.Fail("Product not found", 404);
            }

            var productDto = mapper.Map<ResultProductDto>(productEntity);
            return Response<ResultProductDto>.Succes(productDto, 200);
        }

        public async Task<Response<IEnumerable<ResultProductDto>>> GetAllProductsAsync()
        {
            var productEntitiy = await productRepository.GetAllAsync();
            var productDto = mapper.Map<IEnumerable<ResultProductDto>>(productEntitiy);

            return Response<IEnumerable<ResultProductDto>>.Succes(productDto, 200);
        }

        public async Task<Response<bool>> AddProductAsync(CreateProductDto productDto)
        {
            try
            {
                var productEntity = mapper.Map<Product>(productDto);
                await productRepository.AddAsync(productEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {

                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateProductAsync(string id, UpdateProductDto productDto)
        {
            var existingProduct = await productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return Response<bool>.Fail("Product not found", 404);
            }

            try
            {
                var productEntity = mapper.Map<Product>(productDto);


                await productRepository.UpdateAsync(id, productEntity);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteProductAsync(string id)
        {
            var existingProduct = await productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return Response<bool>.Fail("Product not found", 404);
            }

            try
            {
                await productRepository.DeleteAsync(id);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<IEnumerable<ResultProductDto>>> GetProductsByCategoryIdAsync(string categoryName)
        {
            try
            {
                var products = await productRepository.getProductsByCategoryId(categoryName);

                if (products == null || !products.Any())
                {
                    return Response<IEnumerable<ResultProductDto>>.Fail("No products found for the specified category.", 404);
                }

                var productDtos = mapper.Map<IEnumerable<ResultProductDto>>(products);

                return Response<IEnumerable<ResultProductDto>>.Succes(productDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<ResultProductDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

    }
}
