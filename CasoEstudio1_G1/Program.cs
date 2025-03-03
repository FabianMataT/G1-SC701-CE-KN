using CasoEstudio1_G1.Models;
using CasoEstudio1_G1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CasoEstudio"));
});

// Registrar servicios como Scoped para inyección de dependencias
builder.Services.AddScoped<RutaService>();
builder.Services.AddScoped<HorarioService>();

// Configurar HttpClient para inyección de dependencias
builder.Services.AddHttpClient<RutaService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7245/");
});
builder.Services.AddHttpClient<HorarioService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7245/");
});

// Configurar MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
