namespace EcommerceApp.Infrastructure.Exceptions
{
    public class ItemNotFoundException(string message) : Exception(message)
    {
    }
}
