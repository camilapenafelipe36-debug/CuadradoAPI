using CuadradoAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        @"Server=(localdb)\MSSQLLocalDB;Database=Tarea2DB;Trusted_Connection=True;TrustServerCertificate=True;"
    ));

var app = builder.Build();

app.MapControllers();

app.Run();
