using EcommerceApp.Application.DTOs.Cart;

namespace EcommerceApp.Domain.Entities.Cart;

public class CheckOut
{
    public Guid PaymentMethodId { get; set; }
    public IEnumerable<ProcessCart> CartItems { get; set; }
}