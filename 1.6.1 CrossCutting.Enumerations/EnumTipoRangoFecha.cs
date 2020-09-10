using System.Runtime.Serialization;

namespace Olimpiadas.CrossCutting.Enumerations
{    
    /// <summary>
    /// Enumeración los tipos de rango de fechas.
    /// </summary>
    [DataContract]
    public enum EnumTipoRangoFecha
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorDia = 0,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorRango = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorMes = 2,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorTrimestre = 3,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorSemestre = 4,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        PorAnio = 5
    }
}