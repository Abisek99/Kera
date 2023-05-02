using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.DamageRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.Interface
{
    public interface IDamageRequestDetails
    {
        Task<List<DamageResDto>> GetAllDamageRequestDetailsAsync();
        Task<List<DamageResDto>> GetAllDamageRequestDetails();
        Task<DamageResDto?> AddDamageRequestDetails(DamageReqDto damageRequestDetails);
    }
}
