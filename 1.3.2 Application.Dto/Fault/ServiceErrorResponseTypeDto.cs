using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.Fault
{
    /// <summary>
    /// Enumeración con los tipos de errores.
    /// </summary>
    [DataContract]
    public enum ServiceErrorResponseTypeDto
    {
        /// <summary>
        /// Error no manejado.
        /// </summary>
        [EnumMember]
        ErrorNoManejado = 0,

        /// <summary>
        /// Error de base de datos.
        /// </summary>
        [EnumMember]
        ErrorBaseDatos = 1,

        /// <summary>
        /// Error de comunicación SOAP.
        /// </summary>
        [EnumMember]
        ErrorComunicacionSoap = 2,

        /// <summary>
        /// Error de timeout.
        /// </summary>
        [EnumMember]
        ErrorTiempoConexion = 3,

        /// <summary>
        /// Error de permisos por acceso denegado.
        /// </summary>
        [EnumMember]
        AccesoDenegado = 4,

        /// <summary>
        /// Error de lógica del negocio.
        /// </summary>
        [EnumMember]
        ErrorNegocio = 5,

        /// <summary>
        /// No implemnetado.
        /// </summary>
        [EnumMember]
        NoImplementado = 6
    }
}
