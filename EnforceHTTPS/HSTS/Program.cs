var builder = WebApplication.CreateBuilder(args);

// Configurar HSTS en Program.cs
// Registra el servicio AddHsts aquí.

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // En producción, usa un manejador de errores y HSTS con valores más largos
    app.UseExceptionHandler("/Home/Error");
}

// Añadir Middleware de HSTS y Redirección HTTPS

app.UseStaticFiles();
app.UseRouting();

// Añade app.UseHsts()

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
