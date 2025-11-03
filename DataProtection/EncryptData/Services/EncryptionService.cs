using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace EncryptData.Services
{

    public class EncryptionService
    {
        private readonly IDataProtector _protector;

        public EncryptionService(IDataProtectionProvider provider)
        {
            // Crea el protector usando provider.CreateProtector().
            throw new NotImplementedException("El protector no ha sido inicializado."); // Elimina esto al implementar
        }

        
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            // Implementa la lógica para cifrar usando _protector.Protect().
            throw new NotImplementedException("El método Encrypt no ha sido implementado."); // Elimina esto al implementar
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return string.Empty;
            }

            // Implementa la lógica para descifrar usando _protector.Unprotect().
            // Envuelve la llamada a Unprotect en un bloque try-catch
            throw new NotImplementedException("El método Decrypt no ha sido implementado.");
        }
    }
}
