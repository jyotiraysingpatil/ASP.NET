// program.cs or Startup.cs
using ExamManagement.Repository;
using ExamManagement.Services;

using ExamManagement.Services.ExamManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IMovieService, MovieService>(); // Register IMovieService with MovieService
builder.Services.AddScoped<IMovieRepository, MovieRepository>(); 

// Configure DbContext with dependency injection


var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
