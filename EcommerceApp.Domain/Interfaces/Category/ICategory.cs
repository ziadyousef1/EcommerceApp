﻿using EcommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Interfaces.Category
{
    public interface ICategory
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
