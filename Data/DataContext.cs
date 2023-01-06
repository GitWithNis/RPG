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
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "FirstTestPlayer"},
                new Character { Id = 2, Name = "SecondTestPlayer", Class = CharacterClass.Archer},
                new Character { Id = 3, Name = "ThirdTestPlayer", Class = CharacterClass.Wizard}
            );
        }

        public DbSet<Character> Characters => Set<Character>();
        
    }
}