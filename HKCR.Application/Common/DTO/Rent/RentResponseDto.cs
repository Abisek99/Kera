namespace HKCR.Application.Common.DTO.Rent;

public class RentResponseDto
{
	public Guid RentId { get; set; }
	public string? Status { get; set; }
	public string? Message { get; set; }
	public int StatusCode { get; set; }
	public DateTime? RentalDate { get; set; }
	public string? DamageStatus { get; set; }
	public DateTime? ReturnDate { get; set; }
	public string? RentalStatus { get; set; }
	public DateTime? ApprovedDate { get; set; }
	public Guid? RentalId { get; set; }
	public string? ApprovedBy { get; set; }
	public string? CarRentalStatus { get; set; }
}