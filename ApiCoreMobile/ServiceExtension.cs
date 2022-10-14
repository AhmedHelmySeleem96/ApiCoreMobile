using ApiCoreMobile.Data;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace ApiCoreMobile
{
    public static class ServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),services);
            builder.AddEntityFrameworkStores<MobileContext>().AddDefaultTokenProviders();
            
        }
    }
}
