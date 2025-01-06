using EcommerceApp.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.DTOs.Category
{
    public class GetCategory:CategoryBase
    {
        [Required]
        public Guid Id { get; set; }

        public ICollection<GetProduct>? Products { get; set; }
    }
}
