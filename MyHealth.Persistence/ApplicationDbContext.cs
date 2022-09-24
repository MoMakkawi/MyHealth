using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MyHealth.Domain;
using MyHealth.Persistence.Identity;

namespace MyHealth.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Disease>().ToTable("Diseases");
        builder.Entity<DrRequest>().ToTable("DrRequests");
    }

    public DbSet<Disease> Diseases { get; set; }
    public DbSet<DrRequest> DrRequests { get; set; }
}