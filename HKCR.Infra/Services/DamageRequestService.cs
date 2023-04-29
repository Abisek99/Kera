using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.DamageRequest;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Infra.Services
{
    public class DamageRequestService : IDamageRequestDetails
    {
        private readonly IApplicationDbContext _dbContext;

        public DamageRequestService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DamageResDto> AddDamageRequestDetails(DamageReqDto damageRequestDetails)
        {
            var damageRequestService = new Domain.Entities.DamageRequest()
            {
                DamageDescription = damageRequestDetails.DamageDescription,
                DamageDate = damageRequestDetails.DamageDate,
                DamageStatus = damageRequestDetails.DamageStatus,
                RepairBill = damageRequestDetails.RepairBill,
                CustomerId = damageRequestDetails.CustomerId,
                RentalId = damageRequestDetails.RentalId,
            };

            await _dbContext.DamageRequest.AddAsync(damageRequestService);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new DamageResDto()
            {
                DamageDescription = damageRequestService.DamageDescription,
                DamageDate = damageRequestService.DamageDate,
                DamageStatus = damageRequestService.DamageStatus,
                RepairBill = damageRequestService.RepairBill,
                CustomerId = damageRequestService.CustomerId,
                RentalId = damageRequestService.RentalId,
            };
            return result;
        }

        public Task<List<DamageResDto>> GetAllDamageRequestDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<DamageResDto>> GetAllDamageRequestDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
