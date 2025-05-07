using System.Threading.Tasks;
using Stripe;

public class PaymentService
{
    public async Task<bool> ProcessPayment(string token, decimal amount)
    {
        StripeConfiguration.ApiKey = "your_stripe_key";
        
        var options = new ChargeCreateOptions
        {
            Amount = (long)(amount * 100),
            Currency = "usd",
            Source = token,
            Description = "Counseling Service Payment"
        };

        var service = new ChargeService();
        var charge = await service.CreateAsync(options);
        return charge.Paid;
    }
}
