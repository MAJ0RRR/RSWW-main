using contracts;

namespace paymentservice.Services.Payment;

public class PaymentService
{

    private static readonly Random _random = new Random();

    public PayResponse Pay(PayRequest request)
    {
        bool paymentResult = _random.Next(0, 10) >= 1; // 90% chance of success

        return new PayResponse(paymentResult);
    }

}