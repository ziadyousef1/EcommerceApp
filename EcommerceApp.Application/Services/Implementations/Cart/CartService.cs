using AutoMapper;
using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Application.Services.Interfaces.Cart;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Entities.Cart;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.Interfaces.Cart;

namespace EcommerceApp.Application.Services.Implementations.Cart;

public class CartService(ICart cart,IMapper mapper,IGeneric<Product> productInterface ,
    IPaymentMethodService paymentMethodService,IPaymentService paymentService):ICartService
{
    public async Task<ServiceResponse> SaveCheckOutHistoryAsync(IEnumerable<CreateCartItem> checkOuts)
    {
        var mappedData = mapper.Map<IEnumerable<CartItem>>(checkOuts);
        var response = await cart.SaveCheckOutHistoryAsync(mappedData);
        return response == 1 ? new ServiceResponse { IsSuccess = true, Message = "CheckOut history saved" } : 
            new ServiceResponse { IsSuccess = false, Message = "CheckOut history not saved" };
    }

    public async Task<ServiceResponse> CheckOutAsync(CheckOut checkOut)
    {
       var (products,totalAmount) = await GetTotalAmountAsync(checkOut.CartItems);
        var paymentMethod = await paymentMethodService.GetPaymentMethodsAsync();

           if (checkOut.PaymentMethodId == paymentMethod.FirstOrDefault().Id)

               return await paymentService.ProcessPaymentAsync(totalAmount, products, checkOut.CartItems);

           return new ServiceResponse { IsSuccess = false, Message = "Payment method not found" };

    }
    public async Task<(IEnumerable<Product>,decimal)> GetTotalAmountAsync(IEnumerable<ProcessCart> carts)
    {
        if(!carts.Any()) return ([],0);
        var products = await productInterface.GetAllAsync();
        var cartProducts= carts.
            Select(cartItem=>products.FirstOrDefault(p=>p.Id==cartItem.ProductId))
            .Where(product => product != null)
            .ToList();
        
        var totalAmount = carts
            .Where((CartItem=>cartProducts.Any(p=>p.Id==CartItem.ProductId)))
            .Sum(cartItem=>cartItem.Quantity*cartProducts.FirstOrDefault(p=>p.Id==cartItem.ProductId).Price);
        return (cartProducts,totalAmount);

    }
}