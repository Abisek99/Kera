namespace HKCR.Application.Common.DTO.Rent;

public class RentRequestDto
{
    public Guid? RentalId { get; set; }
    public DateTime? RentalDate { get; set; }
    public string? ApprovedBy { get; set; }
    public string? DamageStatus { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? RentalStatus { get; set; }
    public DateTime? ApprovedDate { get; set; }
}