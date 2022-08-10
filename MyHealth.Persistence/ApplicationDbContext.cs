using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MyHealth.Domain;
using MyHealth.Persistence.Identity;

namespace MyHealth.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
        builder.Entity<AnalysisPicture>().ToTable("AnalysisPictures");
        builder.Entity<DrRequest>().ToTable("DrRequests");
    }
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<AnalysisPicture> AnalysisPictures { get; set; }
    public DbSet<DrRequest> DrRequests { get; set; }
}
