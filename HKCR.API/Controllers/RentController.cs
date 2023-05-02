using HKCR.Application.Common.DTO.Rent;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers;

[ApiController]
public class RentController : ControllerBase
{
	private readonly IRentDetails _rentDetails;

	public RentController(IRentDetails rentDetails)
	{
		_rentDetails = rentDetails;
	}

	[HttpGet]
	[Route("/api/v1/rent/lists")]
	public async Task<List<RentResponseDto>> GetAllRentDetails()
	{
		var data = await _rentDetails.GetAllRentsAsync();
		return data;
	}

	[HttpGet]
	[Route("/api/v1/rent/lists/{id}")]
	public async Task<IQueryable<RentResponseDto>> GetSingleRent(Guid id)
	{
		var data = _rentDetails.GetSingleRent(id);
		return data;
	}

	// [HttpGet]
	// [Route("/api/v1/rent/lists/user/{id}")]
	// public async Task<IQueryable<RentResponseDto>> GetSingleUserRent(Guid id)
	// {
	// 	var data = _rentDetails.GetSingleRent(id);
	// 	return data;
	// }

	[HttpPost]
	[Route("/api/v1/rent/add")]
	public async Task<RentResponseDto> AddRentalDetails(RentRequestDto rent)
	{
		var data = await _rentDetails.AddRentDetails(rent);
		return data;
	}
}