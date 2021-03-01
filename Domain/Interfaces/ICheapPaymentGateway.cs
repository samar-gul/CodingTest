using CodingTest.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Task<string> ProcessPayment(PaymentRequest paymentRequest);
    }
}
