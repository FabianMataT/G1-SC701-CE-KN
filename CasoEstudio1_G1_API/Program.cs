using Microsoft.EntityFrameworkCore;
using CasoEstudio1_G1_API.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(op =>
 op.UseSqlServer(builder.Configuration.GetConnectionString("CasoEstudio")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/routes", async (ApplicationDbContext context) =>
{
    var rutas = await context.Rutas.ToListAsync();
    return Results.Ok(rutas);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
