global using Microsoft.EntityFrameworkCore;

namespace DiscountCarsAPI.Data
{
    public class CarDataContext : DbContext
    {
        public CarDataContext(DbContextOptions<CarDataContext>options): base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=discountcardb;Trusted_Connection=true;Encrypt=false");
        }

        public DbSet<Car> cars { get; set; }
    }
}
