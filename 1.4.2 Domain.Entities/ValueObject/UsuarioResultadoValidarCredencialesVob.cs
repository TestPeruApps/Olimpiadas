
namespace Olimpiadas.Domain.Entities.ValueObject
{
    /// <summary>
    /// Value object con los datos del resultado de validación de credenciales
    /// </summary>
    public class UsuarioResultadoValidarCredencialesVob
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contraseniaCorrecta"></param>
        /// <param name="mensajeError"></param>
        public UsuarioResultadoValidarCredencialesVob(bool contraseniaCorrecta, string mensajeError)
        {
            ContraseniaCorrecta = contraseniaCorrecta;
            MensajeError = mensajeError;
        }

        /// <summary>
        /// Valor booleano para indicar si la contraseña es correcta
        /// </summary>        
        public bool ContraseniaCorrecta { get; private set; }

        /// <summary>
        /// Mensaje de error de validación
        /// </summary>        
        public string MensajeError { get; private set; }
    }
}
