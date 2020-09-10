using System.Collections.Generic;
using System.Runtime.Serialization;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Application.Dto.GestionContenido.Personal
{
    /// <summary>
    /// Clase con datos para mostrar el resultado de la paginación de Participantes.
    /// </summary>
    [DataContract]
    public class PersonalPaginacionResponseDto : BasePaginacionResponseDto
    {
        /// <summary>
        /// Lista resultante de la paginación.
        /// </summary>
        [DataMember]
        public IEnumerable<PersonalDto> Personal { get; set; }
    }
}
