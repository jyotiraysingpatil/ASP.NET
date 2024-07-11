using Movie_Man.Repository;
using Movie_Man.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<IMovieRepository,MovieRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
