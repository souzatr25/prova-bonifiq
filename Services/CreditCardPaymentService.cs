using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class CreditCardPaymentService : Payment
    {
        public async override Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            // Lógica de processamento para cartão de crédito

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
