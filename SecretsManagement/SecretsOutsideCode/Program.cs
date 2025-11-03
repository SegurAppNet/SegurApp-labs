using Microsoft.Extensions.Options;
using SecretsOutsideCode.Models;
using SecretsOutsideCode.Service; 

var builder = WebApplication.CreateBuilder(args);

// Configurar el Patrón IOptions

// Este código solo se ejecutará en producción. Lee la URL del Key Vault
// desde la configuración y usa AddAzureKeyVault para cargarlo.
// Necesitarás instalar el paquete NuGet Azure.Extensions.AspNetCore.Configuration.Secrets y Azure.Identity.

builder.Services.AddControllers();
builder.Services.AddScoped<ISecretService, SecretService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
