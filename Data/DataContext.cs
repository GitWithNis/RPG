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

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Monster)
                .WithOne(m => m.Character)
                .HasForeignKey<Character>(c => c.MonsterId);

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasOne(c => c.Head)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.HeadId);
                
                entity.HasOne(c => c.Neck)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.NeckId);
                
                entity.HasOne(c => c.Chest)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.ChestId);
                
                entity.HasOne(c => c.Hands)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.HandsId);
                
                entity.HasOne(c => c.Legs)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.LegsId);
                
                entity.HasOne(c => c.Feet)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.FeetId);

                entity.HasOne(c => c.FingerL)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.FingerLId);

                entity.HasOne(c => c.FingerR)
                    .WithOne()
                    .HasForeignKey<Character>(c => c.FingerRId);
            });

            modelBuilder.Entity<Character>(
                eb =>
                {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangedProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                }
            );
            
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