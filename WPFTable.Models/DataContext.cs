//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace WPFTable.Models
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DMITRY;Database=WPFTable;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Car> Cars { get; set; } = null!;
    }

}
