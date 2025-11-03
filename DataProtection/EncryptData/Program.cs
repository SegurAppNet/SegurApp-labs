using EncryptData.Services; 

var builder = WebApplication.CreateBuilder(args);

// Registrar el Servicio de Data Protection
// Añade aquí la llamada para registrar el servicio principal de Data Protection.

// Registrar el Servicio de Cifrado
// Añade aquí la llamada para registrar tu clase EncryptionService en el
// contenedor de dependencias.

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
