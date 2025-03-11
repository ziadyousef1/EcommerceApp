using EcommerceApp.Domain.Entities.Cart;
using EcommerceApp.Domain.Interfaces.Cart;
using EcommerceApp.Infrastructure.Data;

namespace EcommerceApp.Infrastructure.Repositories.Cart;

public class CartRepository(AppDbContext context):ICart
{
    public async Task<int> SaveCheckOutHistoryAsync(IEnumerable<CartItem> checkOuts)
    {
         await context.CartItems.AddRangeAsync(checkOuts);
            return await context.SaveChangesAsync();
    }
}