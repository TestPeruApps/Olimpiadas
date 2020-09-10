using System;

namespace Olimpiadas.CrossCutting.Helper.Exceptions
{
    /// <summary>
    /// Expcion controlada de negocio
    /// </summary>
    public class BusinessInformationPregunta<T> : Exception
        where T : class, new() 
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase BusinessException con un mensaje de error especificado y una referencia a la excepción interna que representa la causa de esta excepción.
        /// </summary>
        /// <param name="datos">Datos adjuntos al mensaje.</param>
        /// <param name="message">Mensaje que describe el error.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula.</param>
        public BusinessInformationPregunta(T datos, String message, Exception innerException = null)
            : base(message, innerException)
        {
            Datos = datos;
        }

        /// <summary>
        /// 
        /// </summary>
        public T Datos { get; set; }
    }
}
