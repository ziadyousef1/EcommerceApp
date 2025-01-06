using AutoMapper;
using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Category;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.Services;

namespace EcommerceApp.Application.Services.Implementations
{
    public class CategoryService(IGeneric<Category> categoryRepository, IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var mappedCategory = mapper.Map<Category>(category);
            var result = await categoryRepository.AddAsync(mappedCategory);
            return result > 0 ? new ServiceResponse("Category added", true)
                              : new ServiceResponse("Category failed to be added", false);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var result = await categoryRepository.DeleteAsync(id);
            return result > 0 ? new ServiceResponse("Category deleted", true)
                              : new ServiceResponse("Category failed to be deleted", false);
        }

        public async Task<List<GetCategory>> GetAllAsync()
        {
            var data = await categoryRepository.GetAllAsync();
            if (data.Count == 0)
                return new List<GetCategory>();
            return mapper.Map<List<GetCategory>>(data);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var data = await categoryRepository.GetByIdAsync(id);
            if (data is null) return new GetCategory();

            return mapper.Map<GetCategory>(data);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var mappedCategory = mapper.Map<Category>(category);
            var result = await categoryRepository.UpdateAsync(mappedCategory);
            return result > 0 ? new ServiceResponse("Category updated", true)
                              : new ServiceResponse("Category failed to be updated", false);
        }
    }
}
