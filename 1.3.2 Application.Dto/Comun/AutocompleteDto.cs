using System;
using System.Runtime.Serialization;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con datos para llenar un autocomplete
    /// </summary>
    [DataContract]
    public class AutocompleteDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Guid.
        /// </summary>
        [DataMember(Order = 1)]
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        [DataMember(Order = 2)]
        public string Nombre { get; set; }
        
    }
}
