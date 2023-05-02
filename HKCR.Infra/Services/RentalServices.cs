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
            var rentalDetails = new RentalRequest()
            {
                RentalRequestDate = DateTime.UtcNow,
                CarID = rental.CarID,
                AddUserId = rental.UserID.ToString()
            };

            await _dbContext.Rental.AddAsync(rentalDetails);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new RentalResponseDto()
            {
                Status = "Success",
                Message = "Rent Placed for Approval",
                StatusCode = 201,
                RentalRequestDate = rentalDetails.RentalRequestDate,
                RentalStatus = rentalDetails.RentalStatus,
                RentalId = rentalDetails.RentalId,
                CarID = rentalDetails.CarID,
                UserId = rentalDetails.AddUserId
            };
            return result;
        }


        public Task<List<RentalResponseDto>> GetAllRental()
        {
            throw new NotImplementedException();
        }

        public Task<List<RentalResponseDto>> GetAllRentalAsync()
        {
            var data = (from rentalReqData in _dbContext.Rental
                select new RentalResponseDto()
                {
                    RentalId = rentalReqData.RentalId,
                    RentalRequestDate = rentalReqData.RentalRequestDate,
                    RentalStatus = rentalReqData.RentalStatus,
                    CarID = rentalReqData.CarID
                }).ToList();
            return Task.FromResult(data);
        }
    }
}