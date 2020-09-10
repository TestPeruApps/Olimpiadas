namespace Olimpiadas.Domain.Entities.GestionSeguridad
{
    /// <summary>
    /// Propiedades auxiliares de la entidad usuario.
    /// </summary>
    public partial class Usuario
    {
        /// <summary>
        /// Almacena la contraseña desencriptada.
        /// </summary>
        public string ContraseniaAuxiliar { get; set; }

        /// <summary>
        /// Ids concatenados de roles
        /// </summary>
        public string Usuario_RolIds { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UsuarioCreacion_Nombre { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UsuarioEdicion_Nombre { get; set; }
    }
}