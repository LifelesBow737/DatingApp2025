using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Ruta absoluta a la carpeta Data dentro del proyecto
var projectRoot = Directory.GetCurrentDirectory(); 
var dbPath = Path.Combine(projectRoot, "Data", "dating.db"); // aquí se creará el archivo

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});

var app = builder.Build();

app.MapControllers();

app.Run();



