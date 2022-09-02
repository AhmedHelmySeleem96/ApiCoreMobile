using Microsoft.EntityFrameworkCore;

namespace ApiCoreMobile.Data
{
    public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions options) : base() { }

        public  DbSet<Mobiles> mobiles { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DBConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
