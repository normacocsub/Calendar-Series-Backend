using System.Security.Claims;
using System.Text;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Context;
using Aplication.Handlers;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.ExternalServices;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Jwt.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calendar Series", Version = "v1" });

    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT en este formato: Bearer {token}",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<CalendarSerieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
        options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
        options.ClaimsIdentity.UserNameClaimType = ClaimTypes.Name;
        options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
        
        //options.Tokens.ProviderMap.Add("CustomEmailConfirmation", new TokenProviderDescriptor(typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
        //options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
})
    .AddEntityFrameworkStores<CalendarSerieContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>();



JwtExtensions.AddJwtAuthentication(builder.Services, builder.Configuration);


builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddFilter("Microsoft.AspNetCore.Identity", LogLevel.Information);
    loggingBuilder.AddFilter("Microsoft.AspNetCore.Identity.EntityFrameworkCore", LogLevel.Information);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("Usuario"));
});

builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblyContaining<AddSerieHandler>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});

builder.Services.AddScoped<ISerieRepository, SerieRepository>();
builder.Services.AddScoped<IGoogleDriveService, GoogleDriveServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

