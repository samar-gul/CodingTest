using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardHolder { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public int Status_ID { get; set; }
        public virtual PaymentState PaymentState { get; set; }
    }
}
