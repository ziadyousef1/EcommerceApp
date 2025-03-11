using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Domain.Entities.Cart;

namespace EcommerceApp.Application.Services.Interfaces.Cart;

public interface ICartService
{
    Task<ServiceResponse> SaveCheckOutHistoryAsync(IEnumerable<CreateCartItem> checkOuts);
    Task<ServiceResponse> CheckOutAsync(CheckOut checkOut );
}