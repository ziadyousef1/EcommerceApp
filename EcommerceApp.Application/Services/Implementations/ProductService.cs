using AutoMapper;
using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Product;
using EcommerceApp.Application.Services.Interfaces;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;

namespace EcommerceApp.Application.Services.Implementations
{
    public class ProductService(IGeneric<Product> productRepository, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var result = await productRepository.AddAsync(mappedProduct);
            return result > 0 ? new ServiceResponse("product added", true)
                         : new ServiceResponse("product failed to be added", false);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var result = await productRepository.DeleteAsync(id);
            return result > 0 ?
                new ServiceResponse("product not found or failed to be deleted", false):
              new ServiceResponse("product deleted", true); 
        }

        public async Task<List<GetProduct>> GetAllAsync()
        {
            var data = await productRepository.GetAllAsync();
            if (data.Count == 0)
                return [];
            return mapper.Map<List<GetProduct>>(data);

        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var data = await productRepository.GetByIdAsync(id);
            if (data is null) return new GetProduct();

            return mapper.Map<GetProduct>(data);

        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var result = await productRepository.UpdateAsync(mappedProduct);
            return result > 0 ? new ServiceResponse("product Updated", true)
                         : new ServiceResponse("product failed to be Updated", false);
        }
    }
}
