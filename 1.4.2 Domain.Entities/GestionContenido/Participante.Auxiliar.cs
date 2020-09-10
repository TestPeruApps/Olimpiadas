namespace Olimpiadas.Domain.Entities.GestionContenido
{
    /// <summary>
    /// Propiedades extendidas de la entidad Participante
    /// </summary>
    public partial class Participante
    {
        /// <summary>
        /// Nombre del país
        /// </summary>
        public string NombrePais { set; get; }

        /// <summary>
        /// Nombre del deporte
        /// </summary>
        public string NombreDeporte { get; set; }
    }
}