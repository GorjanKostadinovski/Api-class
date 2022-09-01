using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Database;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Domain.UnitOfWork;
using MovieAppWorkShop.Registrations;
using MovieAppWorkShop.Services.Services;
using MovieAppWorkShop.Shared;
using MovieAppWorkShop.Storage.Database;
using MovieAppWorkShop.Storage.Repositories;
using MovieAppWorkShop.Storage.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
                .RegisterDatabase(builder.Configuration.GetConnectionString("Database"));
builder.Services
    .AddDbContext<IMoviesDbContext, MoviesDbContext>(options =>
    {
        options.UseSqlServer();
    })
    .AddScoped<IMovieRepository, MovieRepositoriy>()
    .AddScoped<IMovieService,MovieService>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IUserRepository,UserRepository>();
var appConfig = builder.Configuration.GetSection("Auth");

//var secret = appConfig.GetValue<string>("SecretKey");

builder.Services.Configure<Auth>(appConfig);

var auth = appConfig.Get<Auth>();
var secret = Encoding.ASCII.GetBytes(auth.SecretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secret)
    };
});
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
