using ApiGestionAgua.AutoMapper;
using ApiGestionAgua.Data;
using ApiGestionAgua.Repositorio;
using ApiGestionAgua.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configuramos la conexion a sql server
builder.Services.AddDbContext<AppDbContext>(opciones => {

    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"));

});

//Agregamos los repositorios

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ILineaRepositorio, LineaRepositorio>();
builder.Services.AddScoped<IVehiculoRepositorio, VehiculoRepositorio>();
builder.Services.AddScoped<IBarrioRepositorio, BarrioRepositorio>();
builder.Services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();
builder.Services.AddScoped<IInsumoRepositorio, InsumoRepositorio>();

//Agreganos el AutoMapper
builder.Services.AddAutoMapper(typeof(AguaMapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
