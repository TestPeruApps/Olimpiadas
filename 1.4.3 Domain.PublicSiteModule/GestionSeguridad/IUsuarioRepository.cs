using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionSeguridad;


namespace Olimpiadas.Domain.Modulos.GestionSeguridad
{
    /// <summary>
    /// Interface con métodos del repositorio de usuarios.
    /// </summary>
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// Método para seleccionar un usuario por su login, desde el orígen de datos.
        /// </summary>
        /// <param name="loginUsuario">Login del usaurio.</param>
        /// <returns>Registro seleccionado.</returns>
        Usuario SelecccionarPorLogin(string loginUsuario);

        /// <summary>
        /// Método para seleccionar un usuario por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idUsuario">Id del usaurio.</param>
        /// <returns>Usuario seleccionado.</returns>
        Usuario SelecccionarPorId(short idUsuario);
    }
}