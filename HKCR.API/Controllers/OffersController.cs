using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Offers;
using HKCR.Application.Common.Interface;
using HKCR.Infra.Services;
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

        [HttpGet]
        [Route("/api/v1/offers")]
        public async Task<List<OffersResponseDto>> GetAllOffersResponseDetails()
        {
            var data = await _offersDetails.GetAllOffersDetailsAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/v1/offers")]
        public async Task<OffersResponseDto> AddOffersDetails(OffersRequestDto car)
        {
            var data = await _offersDetails.AddOffersDetails(car);
            return data;
        }
    }
}
