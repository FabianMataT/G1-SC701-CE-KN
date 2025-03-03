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
    var rutas = await context.Rutas
    .Where(r => r.Estado == true)
    .Include(r=>r.Usuario)
    .ToListAsync();
    return Results.Ok(rutas);
});

app.MapGet("/api/routes/{id}", async (ApplicationDbContext context, int id) =>
{
    var ruta = await context.Rutas.FindAsync(id);
    if (ruta == null)
    {
        return Results.NotFound("El ID indicado no es el indicado");
    }
    return Results.Ok(ruta);
});

app.MapGet("/api/horarios/{id}", async (ApplicationDbContext context, int id) =>
{
    var horarios = await context.HorariosRutas
        .Where(h => h.RutaId == id)
        .Include(h => h.Horario) 
        .Include(h => h.Ruta)
        .ToListAsync();

    return Results.Ok(horarios);
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
