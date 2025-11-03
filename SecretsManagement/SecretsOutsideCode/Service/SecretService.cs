using SecretsOutsideCode.Models;

namespace SecretsOutsideCode.Service
{
    public interface ISecretService
    {
        Settings GetSecrets();
    }

    public class SecretService : ISecretService
    {
        private readonly Settings _secrets;

        // Inyectar y Usar Secretos en un Servicio
        // Inyecta IOptions<Settings> en el constructor.
        // Accede al valor de la configuración usando '.Value' y guárdalo
        // en el campo privado '_secrets'.
        public SecretService()
        {
            throw new NotImplementedException("El constructor no ha sido implementado para recibir IOptions."); // Elimina esto
        }

        public Settings GetSecrets()
        {
            // Devuelve el objeto de configuración ya cargado.
            // Asegúrate de que _secrets no sea null.
            if (_secrets == null)
            {
                throw new InvalidOperationException("El objeto de secretos no fue inicializado correctamente en el constructor.");
            }
            return _secrets;
        }
    }
}