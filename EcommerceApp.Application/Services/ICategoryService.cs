using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Category;

namespace EcommerceApp.Domain.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
