using CodingTest.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Task<string> ProcessPayment(PaymentRequest paymentRequest);
        Task<bool> CheckIfPaymentGetwayExist(PaymentRequest paymentRequest);
    }
}
