
using GestionStock.Application.Profiles;
using GestionStock.DAL;
using GestionStock.ProductApi.Extensions;
using GestionStock.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServicesExtenstion();
builder.Services.AddRepositoriesExtenstion();
builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler
            = ReferenceHandler.IgnoreCycles;
    }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ProductProfile).Assembly));
// Add database connection
builder.Services.AddDbContext<GestionStockDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

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
