using CodingTest.Domain.RequestModel;
using Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Validator;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepo;
        public PaymentController(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [Route("ProcessPayment")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                PaymenRequestValidatore validator = new PaymenRequestValidatore();
                ValidationResult results = validator.Validate(paymentRequest);
                if (!results.IsValid)
                {
                    return BadRequest(results.Errors);
                }
                string response = await _paymentRepo.ProcessPayment(paymentRequest);

                if (response == "Success")
                {
                    return Ok();
                }
                else
                {
                   return StatusCode(StatusCodes.Status500InternalServerError, "An error Occur while processing your request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error Occur while processing your request");
            }
        }
    }
}
