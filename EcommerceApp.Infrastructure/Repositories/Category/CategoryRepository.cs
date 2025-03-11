using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces.Category;
using EcommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Infrastructure.Repositories.Category
{
    internal class CategoryRepository(AppDbContext context) : ICategory
    {
        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            var products =  await context.Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
            return products.Any() ? products : [];
        }
    }
}
