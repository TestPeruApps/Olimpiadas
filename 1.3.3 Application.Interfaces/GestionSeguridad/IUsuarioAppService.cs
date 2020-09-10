using System;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;


namespace Olimpiadas.Application.Interfaces.GestionSeguridad
{    
    /// <summary>
    /// Interface con métodos para orquestar operaciones de Usuarios.
    /// </summary>
    public interface IUsuarioAppService : IDisposable
    {
        /// <summary>
        /// Método orquestador para validar la autenticación del Login
        /// </summary>
        /// <param name="request">Datos del login</param>
        /// <returns>Datos resultantes del proceso</returns>
        UsuarioDto ValidarLogin(ValidarLoginRequestDto request);

        /// <summary>
        /// Método orquestador para obtener el menú de un usuario.
        /// </summary>
        /// <param name="usuarioId">Id del usuario.</param>
        /// <returns>Permisos de</returns>
        ObtenerPermisosResponseDto ListarMenuPorUsuario(short usuarioId);
    }
}