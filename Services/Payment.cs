using ProvaPub.Models;

namespace ProvaPub.Services
{
    public abstract class Payment
    {
        public abstract Task<Order> ProcessPayment(decimal paymentValue, int customerId);
    }
}
