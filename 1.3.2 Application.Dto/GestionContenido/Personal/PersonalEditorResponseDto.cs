using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Application.Dto.GestionContenido.Personal
{
    /// <summary>
    /// Clase con datos para mostrar el editor de Personal.
    /// </summary>
    [DataContract]
    public class PersonalEditorResponseDto
    {
        /// <summary>
        /// Datos del participante que se edita.
        /// </summary>
        [DataMember]
        public PersonalDto Personal { get; set; }
    }
}
