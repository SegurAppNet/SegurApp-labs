using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(options =>
{
    // Política "PerIP"
    // Añade aquí la política "PerIP" usando 'options.AddPolicy()'.

    //  Política "Global"
    // Añade aquí un 'options.GlobalLimiter' que sea particionado.
    
    //  Respuesta de Rechazo
    // Configura 'options.OnRejected' para que devuelva un
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Añade 'app.UseRateLimiter()' en el lugar correcto.

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Estos endpoints son para prueba. La política "Global" se aplicará

// Aplicar política "PerIP"
app.MapGet("/api/minimal/per-ip", () =>
{
    return Results.Ok(new { message = "Minimal API - Por IP", timestamp = DateTime.UtcNow });
});
// Añade el método .RequireRateLimiting(...) aquí


app.MapGet("/api/minimal/global", () =>
{
    // Este usará el limitador global por defecto.
    return Results.Ok(new { message = "Minimal API - Global", timestamp = DateTime.UtcNow });
});

// Desactivar límite
app.MapGet("/api/minimal/unlimited", () =>
{
    return Results.Ok(new { message = "Minimal API - Sín limites", timestamp = DateTime.UtcNow });
});
// Añade el método .DisableRateLimiting() aquí


app.Run();
