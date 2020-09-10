using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con datos para mostrar el resultado de la paginación.
    /// </summary>
    [DataContract]
    public class BasePaginacionResponseDto
    {
        /// <summary>
        /// Lista de estados booleanos.
        /// </summary>
        [DataMember]
        public IEnumerable<ItemDto> EstadosSiNo { get; set; }

        /// <summary>
        /// Total de items sobre el cual se realiza la paginación.
        /// </summary>
        [DataMember]
        public int TotalItems { get; set; }

        /// <summary>
        /// Lista de permisos del usuario en el formulario.
        /// </summary>
        [DataMember]
        public List<short> Opciones { get; set; }
    }
}
