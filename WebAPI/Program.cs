using WebAPI.Data;
using WebAPI.Data.Interfaz;
using WebAPI.Data.Repositorio;
using WebAPI.Logica.Implementacion;
using WebAPI.Logica.Interfaz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>        
/// Configuracion de PostgreSQL      
/// </summary>
var connectionStrinng = builder.Configuration.GetConnectionString("PostgreSQLConnection");
var postgreSQLConeccionConfiguracion = new PostgreSQLConfiguracion(connectionStrinng);
builder.Services.AddSingleton(postgreSQLConeccionConfiguracion);

/// <summary>        
/// Inyección de dependencias     
/// </summary>
builder.Services.AddScoped<IColaboradorAD, ColaboradorAD>();
builder.Services.AddScoped<IColaboradorLN, ColaboradorLN>();

builder.Services.AddScoped<IEstadoAD, EstadoAD>();
builder.Services.AddScoped<IEstadoLN, EstadoLN>();

builder.Services.AddScoped<IPrioridadAD, PrioridadAD>();
builder.Services.AddScoped<IPrioridadLN, PrioridadLN>();

builder.Services.AddScoped<ITareasAD, TareasAD>();
builder.Services.AddScoped<ITareasLN, TareasLN>();



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
