using HKCR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HKCR.Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<User> User { get; set; }
    DbSet<Cars> Cars { get; set; }
    DbSet<Document> Document { get; set; }
    DbSet<Offers> Offers { get; set; }
    DbSet<DamageRequest> DamageRequest { get; set; }

    // DbSet<Department> Department { get; set; }
    // DbSet<SalaryOrBonus> SalaryOrBonus { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}