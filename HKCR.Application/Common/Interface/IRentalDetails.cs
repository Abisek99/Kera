using HKCR.Application.Common.DTO.Document;
using HKCR.Application.Common.DTO.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.Interface
{
	public interface IRentalDetails
	{
		Task<List<RentalResponseDto>> GetAllRentalAsync();
		// Task<RentalResponseDto> GetSingleRentalAsync(Guid id);
		Task<List<RentalResponseDto>> GetAllRental();
		Task<List<RentalResponseDto>> GetAllUserRental(Guid userId);
		Task<RentalResponseDto> AddRentalDetails(RentalRequestDto rental);
	}
}
