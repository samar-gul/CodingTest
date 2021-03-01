using CodingTest.Domain.RequestModel;
using DataAccess.EFCore;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.EFCore.Repositories
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        private readonly ApplicationContext _Database;
        public PremiumPaymentService(ApplicationContext applicationContext)
        {
            _Database = applicationContext;
        }
        public async Task<bool> ProcessPayment(PaymentRequest request)
        {
            try
            {
                Payment payment = new Payment()
                {
                    CreditCardNumber = request.CreditCardNumber,
                    ExpirationDate = request.ExpirationDate,
                    CardHolder = request.CardHolder,
                    SecurityCode = request.SecurityCode,
                    Amount = request.Amount,
                    Status_ID = 1, // Status_ID 1 means completed successfully
                };
                _Database.Payments.Add(payment);
                await _Database.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
