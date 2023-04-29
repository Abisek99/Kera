using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarDetails _carDetails;
        public CarController(ICarDetails carDetails)
        {
            _carDetails = carDetails;
        }

        [HttpGet]
        [Route("/api/v1/cars")]
        public async Task<List<CarResponseDto>> GetAllCarDetails()
        {
            var data = await _carDetails.GetAllCarsAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/v1/cars")]
        public async Task<CarResponseDto> AddCarDetails(CarRequestDto car)
        {
            var data = await _carDetails.AddCarDetails(car);
            return data;
        }
    }
}