var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCredenciales", policy =>
    {
        policy.WithOrigins("https://mi-frontend-seguro.com:puerto") 
              .AllowAnyMethod(); 

        // Configurar Encabezados Permitidos (Request)
        // Usa '.WithHeaders(...)' para permitir explícitamente que el cliente
        // envíe los encabezados 'Authorization' y 'Content-Type'.


        // Permitir Credenciales de Forma Segura
        // Si tu API necesita recibir cookies o el header 'Authorization',
        // debes añadir '.AllowCredentials()'. Recuerda la advertencia:

        // Exponer Encabezados de Respuesta (Response)
        // Usa '.WithExposedHeaders(...)' para permitir que el cliente (JavaScript)
        // pueda leer las cabeceras personalizadas 'X-Total-Paginas' y 'X-Token-Expirado'
        // que enviaremos desde el controlador.

    });
});

builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
{
    options.Cookie.Name = "MyAuthCookie";
});
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("PoliticaCredenciales");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
