namespace EcommerceApp.Domain.Entities.Cart;

public class CartItem
{
    public Guid Id { get; set; }= Guid.NewGuid();   
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
}