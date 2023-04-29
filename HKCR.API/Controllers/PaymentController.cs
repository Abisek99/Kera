using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Offers;
using HKCR.Application.Common.DTO.Payment;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using HKCR.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentDetails _paymentDetails;

        public PaymentController(IPaymentDetails paymentDetails)
        {
            _paymentDetails = paymentDetails;
        }

        [HttpGet]
        [Route("/api/v1/payment")]
        public async Task<List<PaymentResponseDto>> GetAllPaymentDetails()
        {
            var data = await _paymentDetails.GetAllPaymentAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/v1/payment")]
        public async Task<PaymentResponseDto> AddPaymentDetails(PaymentRequestDto payment)
        {
            var data = await _paymentDetails.AddPaymentDetails(payment);
            return data;
        }
    }
}
