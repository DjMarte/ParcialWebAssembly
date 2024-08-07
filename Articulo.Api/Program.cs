using Articulo.Api.DAL;
using Articulo.Api.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));

builder.Services.AddScoped<IApiService<Articulos>, ArticuloService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin",
		builder => builder.AllowAnyOrigin() // Allow any origin
						  .AllowAnyMethod()
						  .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
//}

app.UseCors("AllowAnyOrigin"); // Use the CORS policy

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
