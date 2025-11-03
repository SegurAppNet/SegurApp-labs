using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Nodes;

var services = new ServiceCollection();

// Configurar Data Protection Compartido
// Añade la configuración del servicio AddDataProtection aquí.
// Recuerda que esta configuración debe ser identica a la de la Web API


var serviceProvider = services.BuildServiceProvider();
var dataProtectionProvider = serviceProvider.GetRequiredService<IDataProtectionProvider>();

// Crear Herramienta de Cifrado
// Obtén el 'protector'. Usa dataProtectionProvider.CreateProtector()
// con una "cadena de propósito" específica para la configuración

var configPath = @"C:\Ruta\Al\Proyecto\WebApi\appsettings.Production.json"; 

var jsonContent = File.ReadAllText(configPath);
var jsonNode = JsonNode.Parse(jsonContent)!;

// Obtén el valor actual de la cadena de conexión (en texto plano).
// Accede a la sección "ConnectionStrings" y luego a "DefaultConnection".

// Cifra el valor usando protector.Protect().

// Reemplaza el valor en el nodo JSON con la versión cifrada.
// Asegúrate de asignar el valor cifrado a la misma ruta en el jsonNode.

// Guarda el archivo JSON modificado.
var options = new JsonSerializerOptions { WriteIndented = true };

Console.WriteLine("Archivo de configuración cifrado exitosamente!");

