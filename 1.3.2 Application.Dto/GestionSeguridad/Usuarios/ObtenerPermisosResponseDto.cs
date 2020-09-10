using System.Collections.Generic;
using System.Runtime.Serialization;

//using Olimpiadas.Application.Dto.GestionSeguridad.Menus;

namespace Olimpiadas.Application.Dto.GestionSeguridad.Usuarios
{
    /// <summary>
    /// Clase con datos para mostrar el editor de Usuarios.
    /// </summary>
    [DataContract]
    public class ObtenerPermisosResponseDto
    {        
        /// <summary>
        /// Datos del Usuario que se edita.
        /// </summary>
        [DataMember]
        public UsuarioDto Usuario { get; set; }

        ///// <summary>
        ///// Datos del Usuario que se edita.
        ///// </summary>
        //[DataMember]
        //public IEnumerable<MenuDto> Menus { get; set; }
    }
}