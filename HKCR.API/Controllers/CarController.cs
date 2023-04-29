using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Car;
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

        [HttpGet]
        [Route("/api/v1/cars/{id}")]
        public async Task<List<CarResponseDto>> GetSingleCarDetails(Guid id)
        {
            // var data = await _carDetails.GetSingleCarAsync(Guid id);
            var data = await _carDetails.GetSingleCarAsync(id);
            return data;
        }

        [HttpPost]
        [Route("/api/v1/cars/add")]
        public async Task<CarResponseDto> AddCarDetails(CarRequestDto car)
        {
            var data = await _carDetails.AddCarDetails(car);
            return data;
        }

        [HttpPatch]
        [Route("/api/v1/cars/update-car/{id}")]
        public async Task<CarResponseDto> UpdateCarDetails(Guid id, UpdateCarRequestDto updateCar)
        {
            try
            {
                var product = await _carDetails.GetSingleCarAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var data = await _carDetails.UpdateCarDetails(id, updateCar);
            return data;
        }

        [HttpPatch]
        [Route("/api/v1/car/update-rental/{id}")]
        public async Task<CarResponseDto> UpdateCarRentalDetails(Guid id)
        {
            var data = await _carDetails.UpdateCarRentalDetails(id);
            return data;
        }

        [HttpDelete]
        [Route("/api/v1/car/delete/{id}")]
        public async Task<ResponseDto> DeleteCar(Guid id)
        {
            var data = await _carDetails.DeleteCar(id);
            return data;
        }
    }
}