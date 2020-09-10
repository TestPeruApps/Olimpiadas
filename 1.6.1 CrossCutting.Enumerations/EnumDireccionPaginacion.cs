using System.Runtime.Serialization;

namespace Olimpiadas.CrossCutting.Enumerations
{    
    /// <summary>
    /// Enumeración con las dirección de ordenación.
    /// </summary>
    [DataContract]
    public enum EnumDireccionPaginacion
    {
        /// <summary>
        /// Con ordenación por defecto. (Depederá de la consulta y/o índices de la tabla)
        /// </summary>
        [EnumMember]
        Ninguna = 0,

        /// <summary>
        /// Ordenación en forma ascendente.
        /// </summary>
        [EnumMember]
        ASC = 1,

        /// <summary>
        /// Ordenación en forma descendente.
        /// </summary>
        [EnumMember]
        DESC = 2
    }
}