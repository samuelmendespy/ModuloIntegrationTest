using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositories;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add EntityFramework Context SQlite Database
builder.Services.AddDbContext<EscolaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Add Repositories
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// Nota : Uma instância desses repositórios será criada para cada solicitação HTTP (escopo)

// Register Services Dependency Injection
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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
