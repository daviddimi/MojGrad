using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MojGrad.Models.Entities;

namespace MojGrad.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Report> Reports => Set<Report>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Municipality> Municipalities => Set<Municipality>();
        public DbSet<ReportStatusHistory> ReportStatusHistories => Set<ReportStatusHistory>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Report>(e =>
            {
                e.Property(r => r.Title).IsRequired().HasMaxLength(150);
                e.Property(r => r.Description).IsRequired().HasMaxLength(2000);
                e.Property(r => r.Type).HasConversion<string>();
                e.Property(r => r.Status).HasConversion<string>();

                e.HasOne(r => r.Category).WithMany(c => c.Reports)
                 .HasForeignKey(r => r.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Municipality).WithMany(m => m.Reports)
                 .HasForeignKey(r => r.MunicipalityId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.User).WithMany(u => u.Reports)
                 .HasForeignKey(r => r.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ReportStatusHistory>(e =>
            {
                e.Property(h => h.OldStatus).HasConversion<string>();
                e.Property(h => h.NewStatus).HasConversion<string>();
                e.Property(h => h.Comment).HasMaxLength(500);

                e.HasOne(h => h.Report).WithMany(r => r.StatusHistory)
                 .HasForeignKey(h => h.ReportId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(h => h.ChangedByUser).WithMany(u => u.StatusHistory)
                 .HasForeignKey(h => h.ChangedByUserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Municipality>().Property(m => m.Name).IsRequired().HasMaxLength(100);

            //Seed data for Categories
            var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Патишта", CreatedAt = seedDate },
                new Category { Id = 2, Name = "Водовод", CreatedAt = seedDate },
                new Category { Id = 3, Name = "Струја", CreatedAt = seedDate },
                new Category { Id = 4, Name = "Канализација", CreatedAt = seedDate },
                new Category { Id = 5, Name = "Улично осветлување", CreatedAt = seedDate }
                );
        }
    }
}
