using HKCR.Application.Common.DTO.DamageRequest;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HKCR.Infra.Services
{
    public class DamageRequestService : IDamageRequestDetails
    {
        private readonly IApplicationDbContext _dbContext;

        public DamageRequestService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<DamageResDto>> GetAllDamageRequestDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<DamageResDto?> AddDamageRequestDetails(DamageReqDto damageRequestDetails)
        {
            var drs = new DamageRequest()
            {
                DamageDescription = damageRequestDetails.DamageDescription,
                DamageDate = DateTime.UtcNow,
                DamageStatus = damageRequestDetails.DamageStatus,
                RepairBill = damageRequestDetails.RepairBill,
                AddUserId = damageRequestDetails.AddUserId,
                RentalId = damageRequestDetails.RentalId,
            };

            await _dbContext.DamageRequest.AddAsync(drs);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = await _dbContext.DamageRequest
                .Include(d => d.RentalRequest)
                .ThenInclude(r => r!.AddUser)
                .Where(d => d.RentalId == drs.RentalId)
                .Select(d => new DamageResDto()
                {
                    DamageID = d.DamageId,
                    DamageDescription = d.DamageDescription,
                    DamageDate = d.DamageDate,
                    DamageStatus = d.DamageStatus,
                    RepairBill = d.RepairBill,
                    AcceptedBy = d.AddUserId,
                    DamagedBy = d.RentalRequest!.AddUserId,
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public Task<List<DamageResDto>> GetAllDamageRequestDetailsAsync()
        {
            var result = _dbContext.DamageRequest
                .Include(d => d.RentalRequest)
                .Select(d => new DamageResDto()
                {
                    DamageID = d.DamageId,
                    DamageDescription = d.DamageDescription,
                    DamageDate = d.DamageDate,
                    DamageStatus = d.DamageStatus,
                    RepairBill = d.RepairBill,
                    AcceptedBy = d.AddUserId,
                    DamagedBy = d.RentalRequest!.AddUserId,
                }).ToList();
            return Task.FromResult(result);
        }
    }
}