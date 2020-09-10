using System;
using System.Runtime.Serialization;


namespace Olimpiadas.Application.Dto.GestionContenido.Personal
{
    /// <summary>
    /// Dto con datos del personal
    /// </summary>
    [DataContract]
    public class PersonalDto
    {
        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public int? IdPersonal { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public string NombrePersonal { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public string DniPersonal { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public bool? Activo { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public System.DateTime FechaCreacion { get; set; }


        /// <summary>
        ///
        /// </summary>
        [DataMember]
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }
}