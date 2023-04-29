using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Car;

namespace HKCR.Application.Common.Interface
{
    public interface ICarDetails
    {
        Task<List<CarResponseDto>> GetAllCarsAsync();
        Task<List<CarResponseDto>> GetSingleCarAsync(Guid prodId);
        Task<List<CarResponseDto>> GetAllCars();
        Task<CarResponseDto> AddCarDetails(CarRequestDto car);
        Task<CarResponseDto> UpdateCarDetails(Guid id, UpdateCarRequestDto car);
        Task<CarResponseDto> UpdateCarRentalDetails(Guid id);
        Task<ResponseDto> DeleteCar(Guid id);
    }
}