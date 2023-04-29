using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.Interface
{
    public interface IOffersDetails
    {
        Task<List<OffersResponseDto>> GetAllOffersDetailsAsync();
        Task<List<OffersResponseDto>> GetAllOffersDetails();
        Task<OffersResponseDto> AddOffersDetails(OffersRequestDto offers);
    }
}
