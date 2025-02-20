using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.DataAccess.Servicios;
using Api_Ventas_Carrito.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository<Cliente>, ClienteServices>();
builder.Services.AddScoped<IArticulosRepository<Articulo>, ArticulosServices>();
builder.Services.AddScoped<ITiendaRepository<Tienda>, TiendaServices>();
builder.Services.AddScoped<IVentasRepository<Venta>, VentasServices>();

builder.Services.AddDbContext<SistemaVentasContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddCors(op =>
    {
        op.AddPolicy("angularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200").SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("angularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
