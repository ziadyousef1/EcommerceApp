namespace EcommerceApp.Application.DTOs.Cart;

public class ProcessCart
{
 
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string? UserId { get; set; }
}