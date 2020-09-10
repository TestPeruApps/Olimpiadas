using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con datos para mostrar el resultado de la paginación.
    /// </summary>
    [DataContract]
    public class PaginacionResponseDto
    {
        /// <summary>
        /// Lista de estados booleanos.
        /// </summary>
        [DataMember]
        public IEnumerable<ItemDto> EstadosSiNo { get; set; }

        /// <summary>
        /// Url de la iconografía para mostrar en la grilla
        /// </summary>
        [DataMember]
        public string IconografiaImagenUrl { get; set; }

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

        /// <summary>
        /// Lista de años
        /// </summary>
        [DataMember]
        public IEnumerable<ItemDto> Anios { get; set; }

        /// <summary>
        /// Lista de meses
        /// </summary>
        [DataMember]
        public IEnumerable<ItemDto> Meses { get; set; }
    }    
}