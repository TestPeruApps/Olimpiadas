using System.Collections.Generic;
using System.Runtime.Serialization;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Application.Dto.GestionContenido.Participante
{
    /// <summary>
    /// Clase con datos para mostrar el resultado de la paginación de Participantes.
    /// </summary>
    [DataContract]
    public class ParticipantePaginacionResponseDto : BasePaginacionResponseDto
    {
        /// <summary>
        /// Lista resultante de la paginación.
        /// </summary>
        [DataMember]
        public IEnumerable<ParticipanteDto> Participantes { get; set; }

        /// <summary>
        /// Lista de países.
        /// </summary>
        [DataMember]
        public List<ItemDto> Paises { get; set; }

        /// <summary>
        /// Lista de deportes.
        /// </summary>
        [DataMember]
        public List<ItemDto> Deportes { get; set; }
    }
}
