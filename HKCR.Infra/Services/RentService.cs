using HKCR.Application.Common.DTO.Rent;
using HKCR.Application.Common.DTO.Rental;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HKCR.Infra.Services;

public class RentService : IRentDetails
{
    private readonly IApplicationDbContext _dbContext;

    public RentService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<RentResponseDto>> GetAllRentsAsync()
    {
        var data = (from rentReqData in _dbContext.Rent
            select new RentResponseDto()
            {
                StatusCode = 200,
                RentalStatus = rentReqData.RentalStatus,
                ApprovedBy = rentReqData.ApprovedBy,
                ApprovedDate = rentReqData.ApprovedDate,
                RentalId = rentReqData.RentalId,
                RentId = rentReqData.RentId
            }).ToList();
        return Task.FromResult(data);
    }

    public Task<List<RentResponseDto>> GetAllRents()
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentResponseDto> GetSingleRent(Guid rentId)
    {
        var data = (from rentData in _dbContext.Rent
            where rentData.RentId.Equals(rentId)
            select new RentResponseDto()
            {
                RentId = rentData.RentId,
                Status = "Success",
                StatusCode = 200,
                Message = $"Rent Details Fetched",
                RentalId = rentData.RentalId,
                ApprovedBy = rentData.ApprovedBy,
                ApprovedDate = rentData.ApprovedDate,
                RentalStatus = rentData.RentalStatus
            });
        return (data);
    }

    public async Task<RentResponseDto> AddRentDetails(RentRequestDto rent)
    {
        var rentDetails = new Rent()
        {
            RentalId = rent.RentalId,
            RentalDate = DateTime.UtcNow,
            ApprovedBy = rent.ApprovedBy,
            ApprovedDate = DateTime.UtcNow,
        };


        await _dbContext.Rent.AddAsync(rentDetails);
        // await _dbContext.SaveChangesAsync(default(CancellationToken));
        // Retrieve the RentalRequest entity
        var rentalRequest = await _dbContext.Rental.FirstOrDefaultAsync(x => x.RentalId == rent.RentalId);
        if (rentalRequest != null)
        {
            // Update the RentalStatus property value
            rentalRequest.RentalStatus = "Approved";

            // Save changes to the database
            await _dbContext.SaveChangesAsync(default(CancellationToken));
        }


        var result = new RentResponseDto
        {
            Status = "Success",
            Message = "Rental Approved",
            StatusCode = 201,
            RentId = rentDetails.RentId,
            RentalStatus = rentDetails.RentalStatus,
            ApprovedBy = rentDetails.ApprovedBy,
            ApprovedDate = rentDetails.ApprovedDate,
            RentalId = rentDetails.RentalId,
            CarRentalStatus = rentalRequest?.RentalStatus
        };
        return result;
    }
}