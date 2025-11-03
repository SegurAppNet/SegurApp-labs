using EncryptData.Services;
using Microsoft.AspNetCore.Mvc;

namespace EncryptData.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SecretsController : ControllerBase
    {
        private readonly EncryptionService _encryptionService;

        public SecretsController(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        // Endpoint de prueba para verificar la implementación
        [HttpGet("test-encryption")]
        public IActionResult TestEncryptionCycle()
        {
            try
            {
                string originalData = "Este es un dato secreto: 1234-5678";
                Console.WriteLine($"Original: {originalData}");

                // Prueba de cifrado
                string encryptedData = _encryptionService.Encrypt(originalData);
                Console.WriteLine($"Cifrado: {encryptedData}");

                // Prueba de descifrado 
                string decryptedData = _encryptionService.Decrypt(encryptedData);
                Console.WriteLine($"Descifrado: {decryptedData}");

                // Prueba de manejo de error 
                string decryptedCorruptedDataAttempt = "datos_invalidos_o_manipulados";
                string corruptedResult = _encryptionService.Decrypt(decryptedCorruptedDataAttempt);
                Console.WriteLine($"Intento de descifrar corrupto: {corruptedResult}");

                bool cycleOk = originalData == decryptedData;
                bool errorHandlingOk = !string.IsNullOrEmpty(corruptedResult) && corruptedResult.StartsWith("Error:"); 

                return Ok(new
                {
                    Original = originalData,
                    Encrypted = encryptedData, // Mostrará el resultado del cifrado
                    Decrypted = decryptedData, // Mostrará el resultado del descifrado
                    CorruptedDataCheck = corruptedResult, // Mostrará el resultado al intentar descifrar datos malos
                    CycleSuccessful = cycleOk,
                    ErrorHandlingSuccessful = errorHandlingOk
                });
            }
            catch (NotImplementedException)
            {
                return Problem("Parece que los métodos Encrypt/Decrypt o el constructor en EncryptionService aún no están implementados");
            }
            catch (Exception ex) 
            {
                return Problem($"Ocurrió un error inesperado. {ex.Message}");
            }
        }
    }
}