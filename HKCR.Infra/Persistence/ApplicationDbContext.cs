using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using HKCR.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HKCR.Infra.Persistence;

public class ApplicationDbContext : IdentityDbContext<AddUser, IdentityRole, string>, IApplicationDbContext
{
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime) : base(options)
    {
        _dateTime = dateTime;
    }

    public DbSet<AddUser> AddUsers { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<Cars> Cars { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<RentalRequest> Rental { get; set; }
    public DbSet<Rent> Rent { get; set; }
    public DbSet<Offers> Offers { get; set; }
    public DbSet<DamageRequest> DamageRequest { get; set; }

    public DbSet<Payment> Payment { get; set; }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity> entry in ChangeTracker
                     .Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedTime = _dateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedTime = _dateTime.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AddUser>().HasKey(u => u.Id);
        builder.Entity<Cars>().HasKey(c => c.CarID);
        builder.Entity<Document>().HasKey(d => d.DocID);
        builder.Entity<Payment>().HasKey(p => p.PaymentID);
        builder.Entity<RentalRequest>().HasKey(r => r.RentalId);
        builder.Entity<Rent>().HasKey(r => r.RentId);
        builder.Entity<Offers>().HasKey(o => o.OfferID);
        builder.Entity<DamageRequest>().HasKey(da => da.DamageId);

        // Configure the foreign key between User and Document entities
        builder.Entity<AddUser>()
            .HasOne(u => u.Document)
            .WithMany(a => a.AddUsers)
            .HasForeignKey(u => u.DocId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the foreign key between Rental and Car entities
        builder.Entity<RentalRequest>()
            .HasOne(u => u.Car)
            .WithMany(a => a.Rentals)
            .HasForeignKey(u => u.CarID)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between Rental and Customer entities
        builder.Entity<RentalRequest>()
            .HasOne(u => u.AddUser)
            .WithMany(a => a.Rentals)
            .HasForeignKey(u => u.AddUserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between Rent and Staff entities
        builder.Entity<Rent>()
            .HasOne(u => u.AddUser)
            .WithMany(s => s.Rent)
            .HasForeignKey(u => u.ApprovedBy)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between DamageRequest and Customer entities
        builder.Entity<DamageRequest>()
            .HasOne(u => u.AddUser)
            .WithMany(f => f.DamageRequests)
            .HasForeignKey(u => u.AddUserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between DamageRequest and Rental entities
        builder.Entity<DamageRequest>()
            .HasOne(u => u.RentalRequest)
            .WithMany(f => f.DamageRequests)
            .HasForeignKey(u => u.RentalId)
            .OnDelete(DeleteBehavior.SetNull);


        // Configure the foreign key between Payment and Offer entities
        builder.Entity<Payment>()
            .HasOne(u => u.Offers)
            .WithMany()
            .HasForeignKey(u => u.OfferID)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between Payment and Rental entities
        builder.Entity<Payment>()
            .HasOne(u => u.RentalRequest)
            .WithMany()
            .HasForeignKey(u => u.RentalID)
            .OnDelete(DeleteBehavior.SetNull);


        var ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        var ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
        Guid DOC_ID = new Guid("72eb3a74-5ff1-48b0-8b66-f08de1177332");
        var DOCs_ID = new Guid();


        //seed admin role
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN",
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        //create user
        var appUser = new AddUser()
        {
            Id = ADMIN_ID,
            Email = "admin@hajur.com",
            Name = "Admin BSDK",
            EmailConfirmed = true,
            UserName = "admin",
            NormalizedEmail = "ADMIN@HAJUR.COM",
            NormalizedUserName = "ADMIN",
            RoleUser = "admin",
            DocId = DOC_ID
        };
        var doc = new Document()
        {
            DocID = DOC_ID,
            DocType = "License",
            DocImage = "Not Available",
        };

        //set user password
        var ph = new PasswordHasher<AddUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "admin");

        //seed user
        builder.Entity<AddUser>().HasData(appUser);
        builder.Entity<Document>().HasData(doc);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });

        base.OnModelCreating(builder);
    }
}