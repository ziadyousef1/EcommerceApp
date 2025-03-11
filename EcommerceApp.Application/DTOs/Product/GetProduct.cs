using EcommerceApp.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.DTOs.Product
{
    public class GetProduct:ProductBase
    {
        [Required]

        public Guid Id { get; set; }
        public GetCategory? Category { get; set; }

    }
}
