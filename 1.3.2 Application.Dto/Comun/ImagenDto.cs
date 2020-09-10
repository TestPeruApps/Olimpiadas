using System.Runtime.Serialization;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con los datos de una imagen
    /// </summary>
    [DataContract]
    public class ImagenDto
    {
        /// <summary>
        /// Nombre de la imagen
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        [DataMember]
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Extensión del archivo
        /// </summary>
        [DataMember]
        public string ExtensionArchivo { get; set; }
    }
}
