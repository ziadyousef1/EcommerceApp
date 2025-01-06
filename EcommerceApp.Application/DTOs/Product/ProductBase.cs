﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Application.DTOs.Product
{
    public class ProductBase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;
        [Required]
        public string? Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

    }
}
