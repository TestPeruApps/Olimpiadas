using Olimpiadas.Application.Core;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Participante;
using Olimpiadas.Application.Implementations.Helper;
using Olimpiadas.Application.Interfaces.GestionContenido;
using Olimpiadas.CrossCutting.Helper.Caching;
using Olimpiadas.CrossCutting.Helper.Mapping;
using Olimpiadas.CrossCutting.Strings;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionSeguridad;


namespace Olimpiadas.Application.Implementations.GestionContenido
{
    /// <summary>
    /// Implementa métodos para orquestar operaciones de los participantes.
    /// </summary>
    public class ParticipanteAppService :
        AppServiceBase<ParticipanteDto>, IParticipanteAppService
    {
        #region VARIABLES

        /// <summary>
        /// Interface del repositorio de participante.
        /// </summary>
        private readonly IParticipanteRepository _participanteRepository;

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
        /// <param name="participanteRepository">Interface del repositorio de participantes.</param>
        /// <param name="cache">Interface para acceder a la cache de objetos.</param>
        public ParticipanteAppService(
            IUsuarioRepository usuarioRepository,
            ITipoRepository tipoRepository,
            IParticipanteRepository participanteRepository,
            ICache cache)
        {
            _participanteRepository = participanteRepository;
            _usuarioRepository = usuarioRepository;
            _tipoRepository = tipoRepository;
            _cache = cache;
        }

        #endregion



        #region MÉTODOS - Implementa interface IParticipanteAppService        

        /// <summary>
        /// Implementa método orquestador para paginar las Participantes.
        /// </summary>
        /// <param name="request">Datos para obtener las Participantes paginados.</param>
        /// <returns>Datos con la paginación de Participantes.</returns>
        public ParticipantePaginacionResponseDto Paginar(PaginacionRequestDto<ParticipanteDto> request)
        {
            //Validación de parámetros
            ValidarParametrosPaginacion(request);

            //Obtenemos los filtros
            var estadosSiNo = CachingHelper.EstadosSiNo();
            //var opciones = CachingHelper.ListarOpcionXUsuarioYSubMenu(_cache, _usuarioRepository, request.Usua_Id, ResourcesSubMenu.AdministrarParticipantes);
            var paises = CachingHelper.ListarTiposActivosPorGrupo(_cache, _tipoRepository, ResourcesGrupos.Paises);
            var deportes = CachingHelper.ListarTiposActivosPorGrupo(_cache, _tipoRepository, ResourcesGrupos.Deportes);

            //Realizamos la paginación
            var participantesPaginadas = _participanteRepository.Paginar(request.Filtro, request.CriteriosPaginacion);

            //Obtenemos el resultado
            return new ParticipantePaginacionResponseDto
            {
                Participantes = participantesPaginadas.Items,
                TotalItems = participantesPaginadas.TotalItems,
                //Opciones = opciones,
                EstadosSiNo = estadosSiNo,
                Paises = paises,
                Deportes = deportes
            };
        }


        /// <summary>
        /// Implementa método orquestador para obtener los datos necesarios para el editor de participantes.(Agregar o Modificar).
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        public ParticipanteEditorResponseDto ObtenerEditor(int? idParticipante)
        {
            //Obtenemos datos            
            Participante participante = null;
            if (idParticipante != null)
            {
                participante = _participanteRepository.SeleccionarPorId(idParticipante.Value);
            }
            var paises = CachingHelper.ListarTiposActivosPorGrupo(_cache, _tipoRepository, ResourcesGrupos.Paises);
            var deportes = CachingHelper.ListarTiposActivosPorGrupo(_cache, _tipoRepository, ResourcesGrupos.Deportes);

            //Obtenemos el resultado
            return new ParticipanteEditorResponseDto
            {
                Participante = participante?.ProjectedAs<ParticipanteDto>(),
                Paises = paises,
                Deportes = deportes
            };
        }

        /// <summary>
        /// Implementa método orquestador para insertar una Participante.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        public int Insertar(RequestDto<ParticipanteDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos            
            var ParticipanteNuevo = request.Registro.ProjectedAs<Participante>();

            //Logica de negocio para agregar la Participante
            ParticipanteNuevo.Insertar(request.Auditoria);

            //Iniciamos la transacción
            _participanteRepository.IniciarTransaccion();

            //Registramos los cambios en la Base de Datos
            _participanteRepository.Insertar(ParticipanteNuevo);

            //Finalizamos la transacción
            _participanteRepository.FinalizarTransaccion();

            return ParticipanteNuevo.IdParticipante;
        }

        /// <summary>
        /// Implementa método orquestador para actualizar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        public void Actualizar(RequestDto<ParticipanteDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos            
            AuditoriaDto auditoria = request.Auditoria;
            Participante ParticipanteConNuevoValores = request.Registro.ProjectedAs<Participante>();
            
            Participante ParticipanteActual = _participanteRepository.SeleccionarPorId(ParticipanteConNuevoValores.IdParticipante);

            //Logica de negocio para modificar al Participante
            ParticipanteActual.Actualizar(ParticipanteConNuevoValores, request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _participanteRepository.Actualizar(ParticipanteActual);
        }


        /// <summary>
        /// Implementa método orquestador para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        public void Desactivar(RequestDto<ParticipanteDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos
            var ParticipanteActual = _participanteRepository.SeleccionarPorId(request.Registro.IdParticipante.Value);

            //Logica de negocio para modificar la usuario
            ParticipanteActual.Desactivar(request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _participanteRepository.ActualizarActivo(ParticipanteActual);
        }

        /// <summary>
        /// Implementa método orquestador para activar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        public void Activar(RequestDto<ParticipanteDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos
            var ParticipanteActual = _participanteRepository.SeleccionarPorId(request.Registro.IdParticipante.Value);

            //Logica de negocio para modificar la usuario
            ParticipanteActual.Activar(request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _participanteRepository.ActualizarActivo(ParticipanteActual);
        }

        #endregion



        #region MÉTODOS - Implementa IDisposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public void Dispose()
        {
            _participanteRepository.Dispose();
            _usuarioRepository.Dispose();
            _tipoRepository.Dispose();
        }

        #endregion
    }
}