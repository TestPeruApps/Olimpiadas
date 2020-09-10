using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionSeguridad.Usuarios
{
    /// <summary>
    /// Dto con datos del usuario para la sesión
    /// </summary>
    [DataContract]
    public class EjecutorDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public short? Usua_Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Usua_Email { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Usua_Nombres { get; set; }

        /// <summary>
        /// Tipo de autenticación del usuario.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public short Usua_TipoAutenticacionId { get; set; }
    }    
}