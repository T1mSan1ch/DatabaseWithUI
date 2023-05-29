using LaboratoryWork2.Model;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork2.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Institute> Institutes{ get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LaboratoryWork2;Trusted_Connection=True;");
        }
    }
}
