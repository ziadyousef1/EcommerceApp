using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Application.Services.Interfaces.Cart;
using EcommerceApp.Domain.Entities;
using Stripe.Checkout;

namespace EcommerceApp.Infrastructure.Services;

public class StripePaymentService : IPaymentService
{
    public async Task<ServiceResponse> ProcessPaymentAsync(decimal totalPrice, IEnumerable<Product> products,
        IEnumerable<ProcessCart> cartItems)
    {


        try
        {

            var lineItems = new List<SessionLineItemOptions>();
            foreach (var item in cartItems)
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product is not null)
                {
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Description = product.Description,

                            },
                            UnitAmount = (long)product.Price * 100
                        },
                        Quantity = item.Quantity
                    });
                }
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = ["card"],
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:5222/payment-success",
                CancelUrl = "https://localhost:5222/payment-cancel"
            };
            var serviceResponse = new ServiceResponse();


            var sessionService = new SessionService();
            var session = await sessionService.CreateAsync(options);

            return new ServiceResponse(session.Url, true);
        }
        catch (Exception e)
        {
            return new ServiceResponse(e.Message, false);
        }

    }
}

