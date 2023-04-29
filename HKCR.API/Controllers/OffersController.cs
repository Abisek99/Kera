using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Offers;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers
{
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersDetails _offersDetails;

        public OffersController(IOffersDetails offersDetails)
        {
            _offersDetails = offersDetails;
        }

        [HttpPost]
        [Route("/api/v1/offers")]
        public async Task<OffersResponseDto> AddOffersDetails(OffersRequestDto offers)
        {
            var data = await _offersDetails.AddOffersDetails(offers);
            return data;
        }
    }
}
