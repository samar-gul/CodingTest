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
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly ApplicationContext _database;
        public ExpensivePaymentGateway(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }
        public Task<bool> CheckIfPaymentGetwayExist(PaymentRequest paymentRequest)
        {
            return Task.FromResult(true);
        }

        public async Task<string> ProcessPayment(PaymentRequest request)
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
                    Status_ID = 1,
                };
                _database.Payments.Add(payment);
                await _database.SaveChangesAsync();
                return "Success";
            }
            catch (Exception)
            {
                return "Faild";
            }
        }
    }
}
