using Microsoft.EntityFrameworkCore;
using MyWebsite.Models;
namespace MyWebsite.Data
  
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 

        {
            
        }
        //create table which name is Categories in DB
        public DbSet<Category> Categories { get; set; }

        //make seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "History", DisplayOrder = 2 },
                new Category { Id = 3, Name = "SciFi", DisplayOrder = 3 }
                );
        }
    }
}
