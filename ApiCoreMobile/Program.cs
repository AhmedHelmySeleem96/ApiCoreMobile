using ApiCoreMobile;
using ApiCoreMobile.Configuration;
using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using ApiCoreMobile.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<MobileContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient < IUnitOfWork,UnitOfWork>();

builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());
builder.Services.AddAutoMapper(typeof(MapperInitialize));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
