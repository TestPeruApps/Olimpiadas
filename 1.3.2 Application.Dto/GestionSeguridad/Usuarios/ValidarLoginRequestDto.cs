using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionSeguridad.Usuarios
{
    /// <summary>
    /// Dto con los datos para el login
    /// </summary>
    [DataContract]
    public class ValidarLoginRequestDto
    {
        /// <summary>
        /// Login
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Login { get; set; }

        /// <summary>
        /// Contraseña
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Contrasenia { get; set; }
    }    
}