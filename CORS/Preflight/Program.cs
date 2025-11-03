var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaPreflight", policy =>
    {
        policy.WithOrigins("https://mi-frontend.com:puerto") 
              .AllowAnyHeader();

        // Configurar Métodos Permitidos Explícitamente


        //  Configurar Tiempo de Caché para Preflight

    });
});

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

app.UseCors("PoliticaPreflight");

app.UseAuthorization();
app.MapControllers();

app.Run();
