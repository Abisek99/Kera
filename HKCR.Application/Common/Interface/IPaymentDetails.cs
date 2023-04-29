using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.Interface
{
    public interface IPaymentDetails
    {
        Task<List<PaymentResponseDto>> GetAllPaymentAsync();
        Task<List<PaymentResponseDto>> GetAllPayment();
        Task<PaymentResponseDto> AddPaymentDetails(PaymentRequestDto payment);
    }
}
