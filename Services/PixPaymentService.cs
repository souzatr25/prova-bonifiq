using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PixPaymentService : Payment
    {
        public async override Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            // Lógica de processamento para Pix

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
