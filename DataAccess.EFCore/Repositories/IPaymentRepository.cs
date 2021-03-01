using CodingTest.Domain.RequestModel;
using DataAccess.EFCore;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.EFCore.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IExpensivePaymentGateway _expensiveRepo;
        private readonly IPremiumPaymentService _premiumRepo;
        public PaymentRepository(ApplicationContext context, ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePayment
            , IPremiumPaymentService premiumPaymentService
            )
        {
            _applicationContext = context;
            _cheapPayment = cheapPaymentGateway;
            _expensiveRepo = expensivePayment;
            _premiumRepo = premiumPaymentService;
        }
        public async Task<string> ProcessPayment(PaymentRequest paymentRequest)
        {
            try
            {
                if (paymentRequest.Amount <= 20) 
                {
                    string response = await _cheapPayment.ProcessPayment(paymentRequest);
                    return response;
                }

                if (paymentRequest.Amount >= 20 && paymentRequest.Amount <= 500)
                {
                    if (await _expensiveRepo.CheckIfPaymentGetwayExist(paymentRequest))
                    {
                        string response = await _expensiveRepo.ProcessPayment(paymentRequest);
                    }
                    else
                    {
                        string response = await _cheapPayment.ProcessPayment(paymentRequest);
                        return response;
                    }
                }
                
                bool result = false;
                
                if (paymentRequest.Amount >= 500) //  PremiumPaymentService
                {
                    result = await _premiumRepo.ProcessPayment(paymentRequest);
                    if (!result)
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            result = await _premiumRepo.ProcessPayment(paymentRequest);
                            if (result)
                            {
                                break;
                            }
                        }
                    }
                }
                if (result)
                    return "Success";
                else
                    return "Faild";
            }
            catch (Exception)
            {
                return "Exception";
            }
        }
    }
}
