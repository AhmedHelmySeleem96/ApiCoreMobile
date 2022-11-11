using ApiCoreMobile;
using ApiCoreMobile.Configuration;
using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using ApiCoreMobile.Repository;
using ApiCoreMobile.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var key = Environment.GetEnvironmentVariable("Key");
var JwtSettings = configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
builder.Services.ConfigureIdentity();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<MobileContext>(x => x.UseSqlServer(connectionString));
//builder.Services.ConfigureJwt(configuration);
builder.Services.AddTransient < IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped< IAuthManager, AuthManager>();
builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());
builder.Services.AddAutoMapper(typeof(MapperInitialize));
builder.Services.AddSwaggerGen();

#region Jwt In Swagger
builder.Services.AddSwaggerGen(options =>
{
    //options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    //Version = "v1",
    //    //Title = "MoviesApi",
    //    //Description = "My first api",
    //    ////TermsOfService = new Uri("https://www.google.com"),
    //    //Contact = new Microsoft.OpenApi.Models.OpenApiContact
    //    //{
    //    //    Name = "DevCreed",
    //    //    Email = "test@domain.com",
    //    //    Url = new Uri("https://www.google.com")
    //    //},
    //    //License = new Microsoft.OpenApi.Models.OpenApiLicense
    //    //{
    //    //    Name = "My license",
    //    //    //Url = new Uri("https://www.google.com")
    //    //}
    //});

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
