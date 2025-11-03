// Instalar el paquete NuGet Microsoft.AspNetCore.Authentication.JwtBearer si no está ya instalado.
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar Autenticación JWT

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Añade aquí los middlewares de autenticación y autorización.

app.MapControllers();

app.Run();
