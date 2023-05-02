using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.Rental
{
	public class RentalResponseDto
	{
		public Guid? RentalId { get; set; }
		public DateTime? RentalRequestDate { get; set; }
		public string? RentalStatus { get; set; }
		public Guid? CarID { get; set; }
		public string? UserId { get; set; }
		public string? UserName { get; set; }
		public string? CarName { get; set; }
		public double? CarRate { get; set; }
		public string? CarStatus { get; set; }
		public string? Status { get; set; }
		public string? Message { get; set; }
		public int StatusCode { get; set; }

		public DateTime? RentalDate { get; set; }
		public DateTime? ReturnDate { get; set; }
		public string? DamageStatus { get; set; }
		public Guid? StaffId { get; set; }

	}
}