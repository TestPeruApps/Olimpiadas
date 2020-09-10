using System.Runtime.Serialization;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con la clave y su valor.
    /// </summary>
    [DataContract]
    public class ItemDto
    {
        /// <summary>
        /// Clave del objeto.
        /// </summary>
        [DataMember]
        public string IdTipo { get; set; }

        /// <summary>
        /// Valor asociado a la clave especificada.
        /// </summary>
        [DataMember]
        public string NombreTipo { get; set; }        
    }
}