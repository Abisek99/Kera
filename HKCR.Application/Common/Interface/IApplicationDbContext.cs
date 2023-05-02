using HKCR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HKCR.Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<User> User { get; set; }
    DbSet<Cars> Cars { get; set; }
    DbSet<Document> Document { get; set; }
    DbSet<RentalRequest> Rental { get; set; }
    DbSet<Rent> Rent { get; set; }

    DbSet<Offers> Offers { get; set; }
    DbSet<DamageRequest> DamageRequest { get; set; }

    DbSet<Payment> Payment { get; set; }
    DbSet<AddUser> AddUsers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}