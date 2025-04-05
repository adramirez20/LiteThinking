using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(options =>

options.UseInMemoryDatabase("StoreDB")); // Cambiamos a base de datos en memoria

var app = builder.Build();

// Configurar middleware

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();