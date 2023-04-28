using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO
{
    public class CarResponseDto
    {
        public string CarName { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string CarRentalRate { get; set; }
        public CarStatus CarAvailability { get; set; }
        public string CarNoOfRent { get; set; }
        public DateTime? CarLastRented { get; set; }
        public string? CarImage { get; set; }
    }
}