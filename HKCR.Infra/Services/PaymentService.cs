using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Payment;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Infra.Services
{
    public class PaymentService : IPaymentDetails
    {

        private readonly IApplicationDbContext _dbContext;

        public PaymentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaymentResponseDto> AddPaymentDetails(PaymentRequestDto payment)
        {
            var paymentService = new Payment()
            {
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentTotal = payment.PaymentTotal,
                Amount = payment.Amount,
                RentalID = payment.RentalID,
                OfferID = payment.OfferID,
            };

            await _dbContext.Payment.AddAsync(paymentService);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new PaymentResponseDto()
            {
                PaymentType = paymentService.PaymentType,
                PaymentDate = paymentService.PaymentDate,
                PaymentTotal = paymentService.PaymentTotal,
                Amount = paymentService.Amount,
                RentalID = paymentService.RentalID,
                OfferID = paymentService.OfferID,

            };
            return result;

        }

        public Task<List<PaymentResponseDto>> GetAllPayment()
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentResponseDto>> GetAllPaymentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
