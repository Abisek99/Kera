using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;

namespace HKCR.Infra.Services
{
    public class CarDetails : ICarDetails

    {
        private readonly IApplicationDbContext _dbContext;

        public CarDetails(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarResponseDto> AddCarDetails(CarRequestDto car)
        {
            var carDetails = new Cars()
            {
                CarName = car.CarName,
                CarBrand = car.CarBrand,
                CarAvailability = car.CarAvailability,
                CarColor = car.CarColor,
                CarLastRented = car.CarLastRented,
                CarModel = car.CarModel,
                CarRentalRate = car.CarRentalRate,
                CarNoOfRent = car.CarNoOfRent,
                CarImage = car.CarImage
            };

            await _dbContext.Cars.AddAsync(carDetails);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new CarResponseDto()
            {
                CarName = carDetails.CarName,
                CarBrand = carDetails.CarBrand,
                CarAvailability = carDetails.CarAvailability,
                CarColor = carDetails.CarColor,
                CarLastRented = carDetails.CarLastRented,
                CarModel = carDetails.CarModel,
                CarRentalRate = carDetails.CarRentalRate,
                CarNoOfRent = carDetails.CarNoOfRent,
                CarImage = carDetails.CarImage
            };
            return result;
        }

        public Task<List<CarResponseDto>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<List<CarResponseDto>> GetAllCarsAsync()
        {
            throw new NotImplementedException();
        }
    }
}