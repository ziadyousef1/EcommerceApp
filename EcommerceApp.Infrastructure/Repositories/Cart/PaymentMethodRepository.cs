using EcommerceApp.Domain.Entities.Cart;
using EcommerceApp.Domain.Interfaces.Cart;
using EcommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repositories.Cart;

public class PaymentMethodRepository(AppDbContext context):IPaymentMethod
{
    public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
    {
        return await context.PaymentMethods.AsNoTracking().ToListAsync();
    }
}