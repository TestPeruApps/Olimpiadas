using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionSeguridad.Usuarios
{
    /// <summary>
    /// Clase con los datos del response de la validación del login
    /// </summary>
    [DataContract]
    public class ValidarLoginResponseDto
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public UsuarioDto Usuario { get; set; }                
    }    
}