var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();



/*Configurar aqui CSP, el uso de nonce es en las vistas donde se incluyen scripts o estilos inline, 
tambien se pueden ajustar las directivas a permitir cargar hojas de estilo como https://fonts.googleapis.com u otros recursos externos si es necesario*/


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();


app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    ;


app.Run();
