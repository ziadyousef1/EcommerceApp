namespace EcommerceApp.Domain.Entities.Cart;

public class CreateCartItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string? UserId { get; set; }
}