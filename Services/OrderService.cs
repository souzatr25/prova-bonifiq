using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class OrderService
	{

        private readonly Dictionary<string, Payment> _payment;
        private readonly PixPaymentService _pixPaymentService;
        private readonly PaypalPaymentService _paypalPaymentService;
        private readonly CreditCardPaymentService _creditCardPaymentService;

        public OrderService(PixPaymentService pixPaymentService, PaypalPaymentService paypalPaymentService, CreditCardPaymentService creditCardPaymentService)
        {
            _pixPaymentService = pixPaymentService;
            _creditCardPaymentService = creditCardPaymentService;
            _paypalPaymentService = paypalPaymentService;

            _payment = new Dictionary<string, Payment>
            {
                { "pix", _pixPaymentService },
                { "creditcard", _creditCardPaymentService },
                { "paypal", _paypalPaymentService }
            
            };
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (_payment.TryGetValue(paymentMethod, out var processor))
            {
                return await processor.ProcessPayment(paymentValue, customerId);
            }

            // Tratar método de pagamento desconhecido ou lançar uma exceção
            throw new ArgumentException("Método de pagamento não suportado", nameof(paymentMethod));
        }
    }
}
