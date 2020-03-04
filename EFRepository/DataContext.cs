using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using EFRepository.Entities;

namespace EFRepository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<VehicleEntity> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleEntity>()
                .HasKey(o => new { o.Series, o.Number });

            modelBuilder.Entity<VehicleEntity>()
                  .Property(s => s.Color)
                  .IsRequired();
        }
    }
}