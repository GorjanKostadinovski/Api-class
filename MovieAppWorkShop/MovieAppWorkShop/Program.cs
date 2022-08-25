using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Database;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Domain.UnitOfWork;
using MovieAppWorkShop.Registrations;
using MovieAppWorkShop.Services.Services;
using MovieAppWorkShop.Storage.Database;
using MovieAppWorkShop.Storage.Repositories;
using MovieAppWorkShop.Storage.UnitOfWork;

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
    .AddScoped<IUnitOfWork, UnitOfWork>();

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
