using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.DamageRequest;
using HKCR.Application.Common.Interface;
using HKCR.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers
{
    [ApiController]
    public class DamageRequestController
    {
        private readonly IDamageRequestDetails _damageRequestDetails;

        public DamageRequestController(IDamageRequestDetails damageRequestDetails)
        {
            _damageRequestDetails = damageRequestDetails;
        }

        [HttpGet]
        [Route("/api/v1/damagerequests")]
        public async Task<List<DamageResDto>> GetAllDamageRequestDetails()
        {
            var data = await _damageRequestDetails.GetAllDamageRequestDetailsAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/v1/damagerequests")]
        public async Task<DamageResDto> AddDamageRequestDetails(DamageReqDto damageRequest)
        {
            var data = await _damageRequestDetails.AddDamageRequestDetails(damageRequest);
            return data;
        }
    }
}
