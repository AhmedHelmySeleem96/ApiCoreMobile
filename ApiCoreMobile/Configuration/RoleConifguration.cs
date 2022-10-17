using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace ApiCoreMobile.Configuration
{
    public class RoleConifguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
            }, new IdentityRole
            {
                Name = "Adminstrator",
                NormalizedName = "ADMINSTRATOR"
            }
            );
        }
    }
}
