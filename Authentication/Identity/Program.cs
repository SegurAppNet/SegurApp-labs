// Añadir imports de Identity y Entity Framework, asi como de la carpeta Data creada



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configurar servicios de Identity y DbContext aqui

//Configurar cookies de autenticacion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Añadir middleware de autenticacion 
app.UseAuthorization();


app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    ;


app.Run();
