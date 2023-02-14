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

            modelBuilder.Entity<Character>(
                eb =>
                {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangedProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                }
            );
            
            modelBuilder.Entity<Armor>(
                eb => 
                {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                    
                    eb.HasOne(a => a.Character)
                        .WithMany(c => c.Armors)
                        .HasForeignKey(a => a.CharacterId);
                }
            );

            modelBuilder.Entity<Weapon>(
                eb =>
                {
                    eb.Property(p => p.Pierce).HasColumnType("decimal(18,4)");
                    
                    eb.HasOne(w => w.Character)
                        .WithMany(c => c.Weapons)
                        .HasForeignKey(w => w.CharacterId);
                }
            );
            
            modelBuilder.Entity<Monster>(
                eb =>
                {
                    eb.Property(p => p.Pierce).HasColumnType("decimal(18,4)");
                    
                    eb.HasOne(m => m.Character)
                        .WithOne(c => c.Monster)
                        .HasForeignKey<Monster>(m => m.CharacterId);
                }
            );
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Armor> Armor => Set<Armor>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Monster> Monsters => Set<Monster>();

    }
}