using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Product;

namespace EcommerceApp.Domain.Services
{
    public interface IProductService
    {
        Task<List<GetProduct>> GetAllAsync();
        Task<GetProduct> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateProduct product);
        Task<ServiceResponse> UpdateAsync(UpdateProduct product);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
