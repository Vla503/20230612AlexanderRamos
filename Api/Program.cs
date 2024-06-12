using Core.Data;
using Data.Repos;
using Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//conexion 
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
ArgumentNullException.ThrowIfNull(connectionString);

// Configura la conexión a la base de datos
builder.Services.AddTransient<IDbConnection>((sp) =>
{
    return new SqlConnection(connectionString);
});

builder.Services.AddScoped<IEmpresaRepo>(provider => new EmpresaRepo(connectionString));
builder.Services.AddScoped<IDepartamentoRepo>(provider => new DepartamentoRepo(connectionString));

builder.Services.AddMediatR(new Assembly[] { typeof(DummyMarker).Assembly });

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
