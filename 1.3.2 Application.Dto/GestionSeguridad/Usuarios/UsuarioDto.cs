using System;
using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionSeguridad.Usuarios
{
    /// <summary>
    /// Dto con datos del usuario
    /// </summary>
    [DataContract]
    public class UsuarioDto
    {


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int IdUsuario { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string LoginUsuario { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public byte[] Contrasenia { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NombreUsuario { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ApellidoUsuario { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string EmailUsuario { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool Activo { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public System.DateTime FechaCreacion { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<System.DateTime> FechaModificacion { get; set; }

    }
}