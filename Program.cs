using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WarehauseApiGraphql.Models;
using WarehauseApiGraphql.Mutation;
using WarehauseApiGraphql.Query;
using WarehauseApiGraphql.Sttetings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddPooledDbContextFactory<BsdnetphMatgazynMainContext>(options =>
           options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
           new MySqlServerVersion(new Version(8, 0, 21))));
// Odczytaj ustawienia JWT z pliku appsettings.json
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// Rejestracja autoryzacji JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
        {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
        ClockSkew = TimeSpan.Zero  // Brak dodatkowego marginesu czasowego
        };
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    {
    app.UseDeveloperExceptionPage(); // Wyœwietla pe³ne informacje o b³êdach
    }

app.UseRouting();
app.UseAuthentication();  // Dodaj autoryzacjê JWT
//app.UseAuthorization();

app.UseCors();

app.MapGraphQL();

app.Run();
