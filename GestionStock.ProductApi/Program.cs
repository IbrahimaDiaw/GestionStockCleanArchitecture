
using GestionStock.DAL;
using GestionStock.ProductApi.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using GestionStock.Application.Command;
using GestionStock.ProductApi.Command.Brand;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRepositoriesExtenstion();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BrandCommand).Assembly));
// Add database connection
builder.Services.AddDbContext<GestionStockDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        var origins = builder.Configuration["Security:AllowedOrigins"]!.Split(";");
        policyBuilder.WithOrigins(origins);
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
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
app.UseCors("CorsPolicy");

app.Run();
