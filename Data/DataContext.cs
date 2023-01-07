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
            // modelBuilder.Entity<Character>().HasData(
            //     new Character { Id = 1, Name = "FirstTestPlayer"},
            //     new Character { Id = 2, Name = "SecondTestPlayer", Class = CharacterClass.Archer},
            //     new Character { Id = 3, Name = "ThirdTestPlayer", Class = CharacterClass.Wizard}
            // );

            modelBuilder.Entity<Armor>(
                eb => {
                    eb.Property(p => p.MeleeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.RangeProt).HasColumnType("decimal(18,4)");
                    eb.Property(p => p.MagicProt).HasColumnType("decimal(18,4)");
                    eb.HasData(
                        new Armor
                        {
                            Id = 1,
                            Name = "Leather Hat",
                            Defense = 1,
                            Protection = 1,
                            MeleeProt = 1.5m,
                            RangeProt = 1.5m,
                            MagicProt = 0.5m,
                            Material = Material.Leather,
                            Slot = ArmorSlot.Head
                        },
                        new Armor
                        {
                            Id = 2,
                            Name = "Leather Chest-piece",
                            Defense = 2,
                            Protection = 3,
                            MeleeProt = 1.5m,
                            RangeProt = 1.5m,
                            MagicProt = 0.5m,
                            Material = Material.Leather,
                            Slot = ArmorSlot.Chest
                        },
                        new Armor
                        {
                            Id = 3,
                            Name = "Leather Pants",
                            Defense = 2,
                            Protection = 3,
                            MeleeProt = 1.5m,
                            RangeProt = 1.5m,
                            MagicProt = 0.5m,
                            Material = Material.Leather,
                            Slot = ArmorSlot.Legs
                        }
                    );
                }
            );
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Armor> Armor => Set<Armor>();
        
    }
}