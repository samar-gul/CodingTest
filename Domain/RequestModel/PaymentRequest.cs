using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.Domain.RequestModel
{
    public class PaymentRequest
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardHolder { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
    }
}
