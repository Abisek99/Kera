using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO.Car
{
    public class CarRequestDto
    {
        public string? CarName { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarColor { get; set; }
        public double? CarRentalRate { get; set; }
        public string CarAvailability { get; set; }
        public int? CarNoOfRent { get; set; }
        public DateTime? CarLastRented { get; set; }
        public string? CarImage { get; set; }

    }
}

