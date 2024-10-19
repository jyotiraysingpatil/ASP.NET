using StudentManagement.Services;
using StudentManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();



app.Run();
