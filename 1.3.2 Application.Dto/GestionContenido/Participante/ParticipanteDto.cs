using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionContenido.Participante
{
    /// <summary>
    /// Dto con datos del participante
    /// </summary>
    [DataContract]
    public class ParticipanteDto
    {
        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public int? IdParticipante { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public string NombreParticipante { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public int IdPais { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public int IdDeporte { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public bool? Activo { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public string NombrePais { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public string NombreDeporte { get; set; }

    }
}