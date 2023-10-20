using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Context;
using Aplication.Handlers; //eliminar referencia luego
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CalendarSerieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblyContaining<AgregarSerieHandler>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});

builder.Services.AddScoped<ISerieRepository, SerieRepository>();
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
