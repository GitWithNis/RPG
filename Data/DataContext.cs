using Microsoft.EntityFrameworkCore;
using RPG.Models;
using RPG.Models.Enums;

namespace RPG.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // seeding data ------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Armor>(
                eb => {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                }
            );
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Armor> Armor => Set<Armor>();
        
    }
}