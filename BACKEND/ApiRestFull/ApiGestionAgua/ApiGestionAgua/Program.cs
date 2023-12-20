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
builder.Services.AddScoped<IZonaRepositorio, ZonaRepositorio>();
builder.Services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
builder.Services.AddScoped<IMedioPagoRepositorio, MedioPagoRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<ICuentaRepositorio, CuentaCorrienteRepositorio>();
builder.Services.AddScoped<ICompraRepositorio, CompraRepositorio>();
builder.Services.AddScoped<IRegistroRepositorio, RegistroRepositorio>();
builder.Services.AddScoped<IClienteLoginRepositorio, ClienteLoginRepositorio>();

//Agreganos el AutoMapper
builder.Services.AddAutoMapper(typeof(AguaMapper));
;
//Agrego CORS

//Agrego CORS
builder.Services.AddCors(p => p.AddPolicy(
    "AngularCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
    
    ));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("AngularCors");

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
