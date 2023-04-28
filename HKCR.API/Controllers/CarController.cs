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
        // [HttpPost]
        // [Route("/api/v1/cars")]
        // public async Task<ResponseDto> AddCarDetails([FromBody] CarRequestDto model)
        // {
        //     var result = await AddCarDetails(model);
        //     return result;
        // }


        [HttpPost]
        [Route("/api/v1/cars")]
        public async Task<CarResponseDto> AddCarDetails(CarRequestDto car)
        {
            var data = await _carDetails.AddCarDetails(car);
            return data;
        }
    }
}