using Olimpiadas.Application.Core;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.Application.Interfaces.GestionSeguridad;
using Olimpiadas.CrossCutting.Helper.Caching;
using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.CrossCutting.Helper.Mapping;
using Olimpiadas.Domain.Entities.GestionSeguridad;
using Olimpiadas.Domain.Modulos.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionSeguridad;


namespace Olimpiadas.Application.Implementations.GestionSeguridad
{
    /// <summary>
    /// Implementa métodos para orquestar operaciones de Usuarios.
    /// </summary>
    public class UsuarioAppService :
        AppServiceBase<UsuarioDto>, IUsuarioAppService
    {
        #region VARIABLES
        
        /// <summary>
        /// Interface del repositorio de Usuarios.
        /// </summary>
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Interface del repositorio de Tipos.
        /// </summary>
        private readonly ITipoRepository _tipoRepository;

        /// <summary>
        /// Interface para realizar operaciones con datos en cache.
        /// </summary>
        private readonly ICache _cache;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase con los repositorios que usa.
        /// </summary>
        /// <param name="usuarioRepository">Interface del repositorio de Usuarios.</param>
        /// <param name="tipoRepository">Interface del repositorio de Tipos.</param>
        /// <param name="cache">Interface para acceder a la cache de objetos.</param>
        public UsuarioAppService(
            IUsuarioRepository usuarioRepository,
            ITipoRepository tipoRepository,
            ICache cache
            )
        {
            _usuarioRepository = usuarioRepository;
            _tipoRepository = tipoRepository;
            _cache = cache;
        }

        #endregion



        #region MÉTODOS - Implementa IUsuarioAppService


        /// <summary>
        /// Implementa método orquestador para validar la autenticación del Login
        /// </summary>
        /// <param name="request">Datos del login</param>
        /// <returns>Datos resultantes del proceso</returns>
        public UsuarioDto ValidarLogin(ValidarLoginRequestDto request)
        {
            //Obtenemos datos
            var usuario = _usuarioRepository.SelecccionarPorLogin(request.Login);
            Usuario.ValidarExiste(usuario);

            //var roles = _usuario_RolRepository.ListarPorUsuario(usuario.Usua_Id);

            //Lógica de negocios para validar si la contraseña es correcta
            var resultado = usuario.ValidarCredenciales(usuario, request.Contrasenia);//, roles);

            ////Guardamos estado del bloqueo del usuario
            //_usuarioRepository.ActualizarDatosBloqueo(usuario);

            //Si la contraseña es incorrecta envia mensaje
            if (resultado.ContraseniaCorrecta == false) throw new BusinessException(resultado.MensajeError);

            ////Obtenemos datos de los permisos del usuario
            //var usuarioOpcion = _rol_OpcionRepository.SeleccionarPorIdyUsuario(usuario.Usua_Id, ResourcesOpciones.EvaluarPublicacion_Ver);

            return usuario.ProjectedAs<UsuarioDto>();
        }


        /// <summary>
        /// Implementa método orquestador para obtener el menú de un usuario.
        /// </summary>
        /// <param name="usuarioId">Id del usuario.</param>
        /// <returns>Permisos de</returns>
        public ObtenerPermisosResponseDto ListarMenuPorUsuario(short usuarioId)
        {
            var usuario = _usuarioRepository.SelecccionarPorId(usuarioId);
            //var menus = CachingHelper.ListarMenuPorUsuario(_cache, _usuarioRepository, usuarioId);

            return new ObtenerPermisosResponseDto
            {
                Usuario = usuario?.ProjectedAs<UsuarioDto>(),
                //Menus = menus,
            };
        }

        #endregion



        #region MÉTODOS - Implementa IDisposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public void Dispose()
        {
            _usuarioRepository.Dispose();
            _tipoRepository.Dispose();
        }

        #endregion
    }
}