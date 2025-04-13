using ApiBiblioteca.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// zona de servicio

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

/// zona intermedia

app.MapControllers();

app.Run();
