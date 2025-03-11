using AutoMapper;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Application.Services.Interfaces.Cart;
using EcommerceApp.Domain.Interfaces.Cart;

namespace EcommerceApp.Application.Services.Implementations.Cart;

public class PaymentMethodService (IPaymentMethod paymentMethod,IMapper mapper):IPaymentMethodService
{
    public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethodsAsync()
    {
        var methods = await paymentMethod.GetAllPaymentMethods();
        if (!methods.Any()) return [];
        return mapper.Map<IEnumerable<GetPaymentMethod>>(methods);


    }
}