using ApiCoreMobile.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCoreMobile.Configuration
{
    public class MobileConfiguration : IEntityTypeConfiguration<Mobiles>
    {
        public void Configure(EntityTypeBuilder<Mobiles> builder)
        {
            builder.HasData(new Mobiles
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

                  });
        }
    }
}
