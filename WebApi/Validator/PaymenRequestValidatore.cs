using CodingTest.Domain.RequestModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Validator
{
    public class PaymenRequestValidatore : AbstractValidator<PaymentRequest>
    {
        public PaymenRequestValidatore()
        {
            RuleFor(x => x.CreditCardNumber).NotEmpty().WithMessage("Card number is required");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("Card expired date is required");
            RuleFor(x => x.CardHolder).NotEmpty().WithMessage("CardHolder holder name is required");
            RuleFor(x => x.SecurityCode).NotEmpty().WithMessage("SecurityCode is required");
            RuleFor(x => x.Amount).GreaterThan(0).NotEmpty().WithMessage("SecurityCode is required");
            RuleFor(ac => ac.ExpirationDate).NotNull().WithMessage("Card expiry date is require");
            RuleFor(ac => ac.ExpirationDate).NotEmpty().WithMessage("Card expiry date is require").GreaterThan(DateTime.Now).WithMessage("Card expiry must in future date");
        }
    }
}
