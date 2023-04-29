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

        // Update car last rented date
        public Task<CarResponseDto> UpdateCarLastRentedDetails(CarRequestDto car)
        {
            throw new NotImplementedException();
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


            // join depart in _dbContext.Department
            //     on empData.DepartmentId equals depart.Id
            // select new EmployeeResponseDTO()
            // {
            //     DepartmentName = depart.Name,
            //     Designation = empData.Designation,
            //     Salary = empData.Salary
            // }).ToList();


            return Task.FromResult(data);
        }
    }
}