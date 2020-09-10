using System;

namespace Olimpiadas.CrossCutting.Helper.Exceptions
{
    /// <summary>
    /// Expcion controlada de negocio
    /// </summary>
    public class BusinessInformation : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase BusinessException con un mensaje de error especificado y una referencia a la excepción interna que representa la causa de esta excepción.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula.</param>
        public BusinessInformation(String message, Exception innerException = null)
            : base(message, innerException)
        {

        }
    }
}
