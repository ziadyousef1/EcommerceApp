using System.Diagnostics;
using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Services.Interfaces.Cart;

public interface IPaymentService
{
    Task<ServiceResponse> ProcessPaymentAsync(decimal totalPrice, IEnumerable<Product> products, 
        IEnumerable<ProcessCart> cartItems);
}