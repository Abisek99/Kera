using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using HKCR.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace HKCR.Infra.Persistence;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>, IApplicationDbContext
{
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime) : base(options)
    {
        _dateTime = dateTime;
    }

    public DbSet<User> User { get; set; }
    public DbSet<Cars> Cars { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<Rental> Rental { get; set; }
    public DbSet<Offers> Offers { get; set; }
    public DbSet<DamageRequest> DamageRequest { get; set; }


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
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Cars>().HasKey(c => c.CarID);
        builder.Entity<Document>().HasKey(d => d.DocID);
        builder.Entity<Rental>().HasKey(d => d.RentalID);
        builder.Entity<Offers>().HasKey(d => d.OfferID);
        builder.Entity<DamageRequest>().HasKey(da => da.DamageId);

        // Configure the foreign key between User and Document entities
        builder.Entity<User>()
            .HasOne(u => u.Document)
            .WithMany()
            .HasForeignKey(u => u.DocId)
            .OnDelete(DeleteBehavior.SetNull);
        
        // Configure the foreign key between Rental and Car entities
        builder.Entity<Rental>()
            .HasOne(u => u.Car)
            .WithMany()
            .HasForeignKey(u => u.CarID)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between Rental and Staff entities
        builder.Entity<Rental>()
            .HasOne(u => u.Staff)
            .WithMany()
            .HasForeignKey(u => u.StaffID)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between Rental and Customer entities
        builder.Entity<Rental>()
            .HasOne(u => u.Customer)
            .WithMany()
            .HasForeignKey(u => u.CustomerID)
            .OnDelete(DeleteBehavior.SetNull);
        // Configure the foreign key between DamageRequest and Customer entities
        builder.Entity<DamageRequest>()
            .HasOne(u => u.Customer)
            .WithMany()
            .HasForeignKey(u => u.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the foreign key between DamageRequest and Rental entities
        builder.Entity<DamageRequest>()
            .HasOne(u => u.Rental)
            .WithMany()
            .HasForeignKey(u => u.RentalId)
            .OnDelete(DeleteBehavior.SetNull);



        var ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        var ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";


        //seed admin role
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN",
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        //create user
        var appUser = new IdentityUser()
        {
            Id = ADMIN_ID,
            Email = "admin@hajur.com",
            EmailConfirmed = true,
            UserName = "Hajur Ko Admin",
            NormalizedEmail = "ADMIN@HAJUR.COM",
            NormalizedUserName = "HAJUR KO ADMIN"
        };

        //set user password
        var ph = new PasswordHasher<IdentityUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "Admin_12!");

        //seed user
        builder.Entity<IdentityUser>().HasData(appUser);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });

        base.OnModelCreating(builder);
    }
}