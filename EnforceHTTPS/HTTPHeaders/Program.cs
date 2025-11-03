var builder = WebApplication.CreateBuilder(args);

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


// Crear un Middleware Personalizado
// Añade aquí el middleware usando app.Use(async (context, next) => { ... });
// Dentro del middleware, añade los encabezados a la respuesta
// usando context.Response.Headers.Append("NombreDelHeader", "Valor")

app.UseRouting();

app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();