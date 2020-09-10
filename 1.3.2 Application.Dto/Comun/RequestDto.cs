using System.Runtime.Serialization;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con datos usados como request.
    /// </summary>
    [DataContract]
    public class RequestDto<T>
    {
        /// <summary>
        /// Objeto de auditoría
        /// </summary>
        [DataMember]
        public AuditoriaDto Auditoria { get; set; }

        /// <summary>
        /// Registro con atos del request
        /// </summary>
        [DataMember]
        public T Registro { get; set; }
    }

    /// <summary>
    /// Clase con datos usados para la auditoría del request.
    /// </summary>
    [DataContract]
    public class AuditoriaDto
    {
        /// <summary>
        /// Ip. del equipo
        /// </summary>
        [DataMember]
        public string Ip { get; set; }

        /// <summary>
        /// Id. del usuario
        /// </summary>
        [DataMember]
        public short IdUsuario { get; set; }

    }
}