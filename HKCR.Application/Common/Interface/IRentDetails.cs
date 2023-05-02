using HKCR.Application.Common.DTO.Rent;
using HKCR.Application.Common.DTO.Rental;

namespace HKCR.Application.Common.Interface;

public interface IRentDetails
{
	Task<List<RentResponseDto>> GetAllRentsAsync();
	Task<List<RentResponseDto>> GetAllRents();
	IQueryable<RentResponseDto> GetSingleRent(Guid rentId);

	// Task<RentResponseDto> UpdateCarDetails(Guid id, RentResponseDto car);
	Task<RentResponseDto> AddRentDetails(RentRequestDto rent);

	// Task<RentResponseDto> GetSingleRentalAsync(Guid id);
}