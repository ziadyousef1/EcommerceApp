using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Category;
using EcommerceApp.Application.DTOs.Product;

namespace EcommerceApp.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId);
    }
}
