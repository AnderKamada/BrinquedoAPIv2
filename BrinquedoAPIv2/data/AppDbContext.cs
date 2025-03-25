using Microsoft.EntityFrameworkCore;
using BrinquedoAPIv2.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BrinquedoAPIv2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Brinquedo> Brinquedos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brinquedo>()
                .Property(b => b.Preco)
                .HasColumnType("decimal(10,2)");
        }
    }
}
