using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Rental;
using HKCR.Application.Common.Interface;
using HKCR.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers
{
	[ApiController]
	public class RentalController : ControllerBase
	{
		private readonly IRentalDetails _rentalDetails;

		public RentalController(IRentalDetails rentalDetails)
		{
			_rentalDetails = rentalDetails;
		}

		[HttpGet]
		[Route("/api/v1/rental")]
		public async Task<List<RentalResponseDto>> GetAllRentalDetails()
		{
			var data = await _rentalDetails.GetAllRentalAsync();
			return data;
		}

		[HttpGet]
		[Route("/api/v1/rental/{id}")]
		public async Task<List<RentalResponseDto>> GetAllUserRental(Guid id)
		{
			var data = await _rentalDetails.GetAllUserRental(id);
			return data;
		}

		[HttpPost]
		[Route("/api/v1/rental")]
		public async Task<RentalResponseDto> AddRentalDetails(RentalRequestDto rental)
		{
			var data = await _rentalDetails.AddRentalDetails(rental);
			return data;
		}

	}
}
