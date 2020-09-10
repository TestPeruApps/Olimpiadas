using System.Collections.Generic;
using System.Runtime.Serialization;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Application.Dto.GestionContenido.Participante
{
    /// <summary>
    /// Clase con datos para mostrar el editor de Participantes.
    /// </summary>
    [DataContract]
    public class ParticipanteEditorResponseDto
    {
        /// <summary>
        /// Datos del participante que se edita.
        /// </summary>
        [DataMember]
        public ParticipanteDto Participante { get; set; }

        /// <summary>
        /// Listado de países
        /// </summary>
        [DataMember]
        public List<ItemDto> Paises { get; set; }

        /// <summary>
        /// Listado de deportes
        /// </summary>
        [DataMember]
        public List<ItemDto> Deportes { get; set; }
    }
}
