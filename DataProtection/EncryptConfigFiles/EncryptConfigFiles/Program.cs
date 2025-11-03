using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Configurar Data Protection Compartido
// Añade la configuración del servicio AddDataProtection aquí.

// Descifrar Configuración al Iniciar la App Web

// Obtén una instancia temporal del IDataProtectionProvider.

// Obtén el 'protector' usando la misma "cadena de propósito" que en la herramienta de cifrado.

// Lee la cadena de conexión cifrada desde la configuración.

// Verifica si la cadena cifrada no es nula/vacía.

// Descifra la cadena usando protector.Unprotect(). Maneja posibles errores con try-catch.
//
// Sobrescribe el valor en la configuración en memoria con la versión descifrada.
//
// Maneja los errores, esto podría indicar que el archivo no fue cifrado correctamente


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
app.UseAuthorization();
app.MapControllers();

app.Run();