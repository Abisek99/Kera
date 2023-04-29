using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Rental;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;

namespace HKCR.Infra.Services
{
    public class RentalServices : IRentalDetails
    {
        private readonly IApplicationDbContext _dbContext;

        public RentalServices(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RentalResponseDto> AddRentalDetails(RentalRequestDto rental)
        {
            var rentalDetails = new Rental()
            {
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                RentalStatus = rental.RentalStatus,
                DamageStatus = rental.DamageStatus,
                CarID = rental.CarID,
                StaffID = rental.StaffID,
                CustomerID = rental.CustomerID
            };

            await _dbContext.Rental.AddAsync(rentalDetails);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new RentalResponseDto()
            {
                RentalDate = rentalDetails.RentalDate,
                ReturnDate = rentalDetails.ReturnDate,
                RentalStatus = rentalDetails.RentalStatus,
                DamageStatus = rentalDetails.DamageStatus,
                CarID = rentalDetails.CarID,
                StaffID = rentalDetails.StaffID,
                CustomerID = rentalDetails.CustomerID
            };
            return result;
        }


        public Task<List<RentalResponseDto>> GetAllRental()
        {
            throw new NotImplementedException();
        }

        public Task<List<RentalResponseDto>> GetAllRentalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
