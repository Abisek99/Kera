using HKCR.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.Interface
{
    public interface ICarDetails
    {
        Task<List<CarResponseDto>> GetAllCarsAsync();
        Task<List<CarResponseDto>> GetAllCars();
        Task<CarResponseDto> AddCarDetails(CarRequestDto car);
    }
}
