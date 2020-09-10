using System.ServiceModel;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;


namespace Olimpiadas.DistributedServices.Interfaces.GestionSeguridad
{
    /// <summary>
    /// Contrato del servicio con métodos de operaciones de Usuarios.
    /// </summary>
    public partial interface IGestionSeguridadService
    {
        /// <summary>
        /// Método del servicio para obtener el menú de un usuario.
        /// </summary>
        /// <param name="usuarioId">Id del usuario.</param>
        /// <returns>Permisos de</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        ObtenerPermisosResponseDto UsuarioListarMenu(short usuarioId);

        /// <summary>
        /// Método del servicio para validar la autenticación del Login
        /// </summary>
        /// <param name="request">Datos del login</param>
        /// <returns>Datos resultantes del proceso</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        UsuarioDto UsuarioValidarLogin(ValidarLoginRequestDto request);
    }
}