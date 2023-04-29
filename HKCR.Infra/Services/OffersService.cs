using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Offers;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Infra.Services
{
    public class OffersService : IOffersDetails
    {
        private readonly IApplicationDbContext _dbContext;

        public OffersService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OffersResponseDto> AddOffersDetails(OffersRequestDto offers)
        {
            var offersService = new Offers()
            {
                OfferName = offers.OfferName,
                OfferType = offers.OfferType,
                OfferAmount = offers.OfferAmount,
            };

            await _dbContext.Offers.AddAsync(offersService);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new OffersResponseDto()
            {
                OfferName = offersService.OfferName,
                OfferType = offersService.OfferType,
                OfferAmount = offersService.OfferAmount,
            };
            return result;
        }

        public Task<List<OffersResponseDto>> GetAllOffersDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<OffersResponseDto>> GetAllOffersDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
