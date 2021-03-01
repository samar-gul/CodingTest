using CodingTest.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPremiumPaymentService
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest);
    }
}
