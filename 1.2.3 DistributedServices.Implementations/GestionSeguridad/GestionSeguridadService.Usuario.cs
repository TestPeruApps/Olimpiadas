using Microsoft.Practices.Unity;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.DistributedServices.Core.Factories;
using Olimpiadas.Application.Interfaces.GestionSeguridad;


namespace Olimpiadas.DistributedServices.Implementations.GestionSeguridad
{
    /// <summary>
    /// Implementa contrato del servicio con métodos de operaciones de Usuarios.
    /// </summary>
    public partial class GestionSeguridadService
    {
        /// <summary>
        /// Implementa método del servicio para obtener el menú de un usuario.
        /// </summary>
        /// <param name="usuarioId">Id del usuario.</param>
        /// <returns>Permisos de</returns>
        public ObtenerPermisosResponseDto UsuarioListarMenu(short usuarioId)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IUsuarioAppService>())
                return service.ListarMenuPorUsuario(usuarioId);
        }

        /// <summary>
        /// Implementa método del servicio para validar la autenticación del Login
        /// </summary>
        /// <param name="request">Datos del login</param>
        /// <returns>Datos resultantes del proceso</returns>
        public UsuarioDto UsuarioValidarLogin(ValidarLoginRequestDto request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IUsuarioAppService>())
                return service.ValidarLogin(request);
        }
    }
}