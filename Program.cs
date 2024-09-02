using Microsoft.EntityFrameworkCore;
using Sales_System_Api.Models;
using Stripe;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging; // Asegúrate de incluir este namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Configurar Stripe
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

// Configurar logging
builder.Logging.ClearProviders(); // Elimina los proveedores de logging predeterminados
builder.Logging.AddConsole(); // Agrega el proveedor de logging a la consola
builder.Logging.AddDebug(); // Agrega el proveedor de logging para depuración

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Habilitar CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
