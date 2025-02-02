using Microsoft.EntityFrameworkCore;
using WebAPIPerson.Contex;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//crear variable para la cadena de conexion
var conectionString = builder.Configuration.GetConnectionString("Conection");
//Registra servicio para la conexion
builder.Services.AddDbContext<AppBDContext>(options => options.UseSqlServer(conectionString));

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
