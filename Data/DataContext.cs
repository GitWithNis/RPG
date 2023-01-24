using Microsoft.EntityFrameworkCore;
using RPG.Models;

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

            modelBuilder.Entity<Monster>()
                .HasOne(m => m.Character)
                .WithOne(c => c.Monster)
                .HasForeignKey<Monster>(m => m.CharacterId);
            
            modelBuilder.Entity<Armor>(
                eb => {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                }
            );
            
            modelBuilder.Entity<Monster>(
                eb =>
                {
                    eb.Property(p => p.Pierce).HasColumnType("decimal(18,4)");
                }
            );
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Armor> Armor => Set<Armor>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Monster> Monsters => Set<Monster>();

    }
}