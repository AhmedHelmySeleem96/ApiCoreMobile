using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreMobile.Data
{
    public class MobileContext : IdentityDbContext<ApiUser>
    {
        public MobileContext(DbContextOptions options) : base() { }

        public DbSet<Mobiles> mobiles { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mobiles>().HasData(
                new Mobiles
                {
                    Id = 1,
                    Name = "Iphone 6 ",
                    Price = 6500,
                    CategoryId = 1

                },
                new Mobiles
                {
                    Id = 2,
                    Name = "Iphone 7 ",
                    Price = 7500,
                    CategoryId = 1
                },
                  new Mobiles
                  {
                      Id = 3,
                      Name = "Iphone 8 ",
                      Price = 9500,
                      CategoryId = 1

                  }
                );
            modelBuilder.Entity<Category>().HasData(
                        new Category
                        {
                            Id = 1,
                            Name = "Iphone"
                        },
                        new Category { Id = 2, Name = "Samsung" },
                        new Category { Id = 3, Name = "Oppo" }
                );
        }
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
