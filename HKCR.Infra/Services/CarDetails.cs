using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Car;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.Infra.Services
{
    public class CarDetails : ICarDetails

    {
        private readonly IApplicationDbContext _dbContext;

        public CarDetails(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add Car
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

        // Update car
        public async Task<CarResponseDto> UpdateCarDetails(Guid id, UpdateCarRequestDto car)
        {
            var data = await _dbContext.Cars.FindAsync(id);
            if (data != null)
            {
                data.CarName = car.CarName;
                data.CarBrand = car.CarBrand;
                data.CarAvailability = car.CarAvailability;
                data.CarColor = car.CarColor;
                data.CarLastRented = car.CarLastRented;
                data.CarModel = car.CarModel;
                data.CarRentalRate = car.CarRentalRate;
                data.CarNoOfRent = car.CarNoOfRent;
                data.CarImage = car.CarImage;
            }

            await _dbContext.SaveChangesAsync(default(CancellationToken));
            var result = new CarResponseDto()
            {
                CarName = data.CarName,
                CarBrand = data.CarBrand,
                CarAvailability = data.CarAvailability,
                CarColor = data.CarColor,
                CarLastRented = data.CarLastRented,
                CarModel = data.CarModel,
                CarRentalRate = data.CarRentalRate,
                CarNoOfRent = data.CarNoOfRent,
                CarImage = data.CarImage
            };
            return result;
        }

        public async Task<CarResponseDto> UpdateCarRentalDetails(Guid id)
        {
            var data = await _dbContext.Cars.FindAsync(id);
            if (data != null)
            {
                data.CarLastRented = DateTime.UtcNow;
                data.CarNoOfRent += 1;
                data.CarAvailability = "Rented";
            }

            await _dbContext.SaveChangesAsync(default(CancellationToken));
            var result = new CarResponseDto()
            {
                CarID = data.CarID,
                CarName = data.CarName,
                CarBrand = data.CarBrand,
                CarAvailability = data.CarAvailability,
                CarColor = data.CarColor,
                CarLastRented = data.CarLastRented,
                CarModel = data.CarModel,
                CarRentalRate = data.CarRentalRate,
                CarNoOfRent = data.CarNoOfRent,
                CarImage = data.CarImage
            };
            return result;
        }

        // Delete Car
        public async Task<ResponseDto> DeleteCar(Guid id)
        {
            var car = await _dbContext.Cars.FindAsync(id);
            if (car == null)
            {
                return new ResponseDto { Message = $"Car with ID {id} not found." };
            }

            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync(default(CancellationToken));
            var result = new ResponseDto() { Message = $"Car: {car.CarName} Deletion Successful" };
            return result;
        }


        // Get Single Car
        public Task<List<CarResponseDto>> GetSingleCarAsync(Guid prodId)
        {
            var data = (from empData in _dbContext.Cars
                where empData.CarID.Equals(prodId)
                select new CarResponseDto()
                {
                    CarID = empData.CarID,
                    CarName = empData.CarName,
                    CarBrand = empData.CarBrand,
                    CarModel = empData.CarModel,
                    CarColor = empData.CarColor,
                    CarRentalRate = empData.CarRentalRate,
                    CarAvailability = empData.CarAvailability,
                    CarNoOfRent = empData.CarNoOfRent,
                    CarLastRented = empData.CarLastRented,
                    CarImage = empData.CarImage
                }).ToList();
            return Task.FromResult(data);
        }

        public Task<List<CarResponseDto>> GetAllCars()
        {
            var data = (from empData in _dbContext.Cars
                select new CarResponseDto()
                {
                    CarID = empData.CarID,
                    CarName = empData.CarName,
                    CarBrand = empData.CarBrand,
                    CarModel = empData.CarModel,
                    CarColor = empData.CarColor,
                    CarRentalRate = empData.CarRentalRate,
                    CarAvailability = empData.CarAvailability,
                    CarNoOfRent = empData.CarNoOfRent,
                    CarLastRented = empData.CarLastRented,
                    CarImage = empData.CarImage
                }).ToList();
            return Task.FromResult(data);
        }

        public Task<List<CarResponseDto>> GetAllCarsAsync()
        {
            var data = (from empData in _dbContext.Cars
                select new CarResponseDto()
                {
                    CarID = empData.CarID,
                    CarName = empData.CarName,
                    CarBrand = empData.CarBrand,
                    CarModel = empData.CarModel,
                    CarColor = empData.CarColor,
                    CarRentalRate = empData.CarRentalRate,
                    CarAvailability = empData.CarAvailability,
                    CarNoOfRent = empData.CarNoOfRent,
                    CarLastRented = empData.CarLastRented,
                    CarImage = empData.CarImage
                }).ToList();
            return Task.FromResult(data);
        }
    }
}