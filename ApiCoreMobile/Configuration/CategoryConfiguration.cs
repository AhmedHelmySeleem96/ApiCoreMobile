using ApiCoreMobile.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCoreMobile.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Iphone"
                }, new Category
                {
                    Id = 2,
                    Name = "Samsung"
                }, new Category
                {
                    Id = 3,
                    Name = "Oppo"

                }
                );
        }
    }
}
