var builder = WebApplication.CreateBuilder(args);

//  Crear la Política CORS en Program.cs
// Usa 'builder.Services.AddCors(...)' y 'options.AddPolicy(...)'

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

// Registrar el Middleware CORS
// Añade 'app.UseCors()' aquí. Como usaremos atributos [EnableCors] en los controladores, no necesitas especificar un nombre de política aquí.

app.UseAuthorization(); 
app.MapControllers();

app.Run();
