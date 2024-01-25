using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PaypalPaymentService : Payment
    {
        public async override Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            // Lógica de processamento para PayPal

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
