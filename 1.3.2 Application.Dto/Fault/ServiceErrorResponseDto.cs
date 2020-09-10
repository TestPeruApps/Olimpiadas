using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.Fault
{
    /// <summary>
    /// Clase con datos del error.
    /// </summary>
    [DataContract]
    public class ServiceErrorResponseDto
    {
        /// <summary>
        /// Código del error.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Descripción del error.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Mensaje del error.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Tipo del error.
        /// </summary>
        [DataMember]
        public ServiceErrorResponseTypeDto Type { get; set; }

        /// <summary>
        /// Sub código del error.
        /// </summary>
        [DataMember]
        public string SubCode { get; set; }
    }
}
