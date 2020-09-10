using System.Runtime.Serialization;
using Olimpiadas.CrossCutting.Enumerations;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Datos para realizar la paginación.
    /// </summary>
    [DataContract]
    public class CriteriosPaginacionDto
    {        
        /// <summary>
        /// Índice de la página.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int NumeroPagina { get; set; }
        
        /// <summary>
        /// Número de items por página.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int TamanioPagina { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true)]
        public string SortBy { get; set; }

        /// <summary>
        /// Propiedad por la cual se realizar la ordenación.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ColumnaOrdenacion { get; set; }

        /// <summary>
        /// Dirección de la ordenación. (ASC o descendente)
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumDireccionPaginacion OrdenacionDireccion { get; set; }
    }    
}