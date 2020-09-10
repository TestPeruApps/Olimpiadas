using Olimpiadas.Application.Core;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Personal;
using Olimpiadas.Application.Implementations.Helper;
using Olimpiadas.Application.Interfaces.GestionContenido;
using Olimpiadas.CrossCutting.Helper.Caching;
using Olimpiadas.CrossCutting.Helper.Mapping;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionContenido;


namespace Olimpiadas.Application.Implementations.GestionContenido
{
    /// <summary>
    /// Implementa métodos para orquestar operaciones del Personal.
    /// </summary>
    public class PersonalAppService :
        AppServiceBase<PersonalDto>, IPersonalAppService
    {
        #region VARIABLES

        /// <summary>
        /// Interface del repositorio de personal.
        /// </summary>
        private readonly IPersonalRepository _personalRepository;

        /// <summary>
        /// Interface para realizar operaciones con datos en cache.
        /// </summary>
        private readonly ICache _cache;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase con los repositorios que usa.
        /// </summary>
        /// <param name="personalRepository">Interface del repositorio de Personal.</param>
        /// <param name="cache">Interface para acceder a la cache de objetos.</param>
        public PersonalAppService(
            IPersonalRepository personalRepository,
            ICache cache)
        {
            _personalRepository = personalRepository;
            _cache = cache;
        }

        #endregion



        #region MÉTODOS - Implementa interface IPersonalAppService        

        /// <summary>
        /// Implementa método orquestador para paginar el Personal.
        /// </summary>
        /// <param name="request">Datos para obtener Personal paginados.</param>
        /// <returns>Datos con la paginación de Personals.</returns>
        public PersonalPaginacionResponseDto Paginar(PaginacionRequestDto<PersonalDto> request)
        {
            //Validación de parámetros
            ValidarParametrosPaginacion(request);

            //Obtenemos los filtros
            var estadosSiNo = CachingHelper.EstadosSiNo();
            //var opciones = CachingHelper.ListarOpcionXUsuarioYSubMenu(_cache, _usuarioRepository, request.Usua_Id, ResourcesSubMenu.AdministrarPersonals);

            //Realizamos la paginación
            var personalPaginadas = _personalRepository.Paginar(request.Filtro, request.CriteriosPaginacion);

            //Obtenemos el resultado
            return new PersonalPaginacionResponseDto
            {
                Personal = personalPaginadas.Items,
                TotalItems = personalPaginadas.TotalItems,
                //Opciones = opciones,
                EstadosSiNo = estadosSiNo
            };
        }


        /// <summary>
        /// Implementa método orquestador para obtener los datos necesarios para el editor de personal.(Agregar o Modificar).
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        public PersonalEditorResponseDto ObtenerEditor(int? idPersonal)
        {
            //Obtenemos datos            
            Personal Personal = null;
            if (idPersonal != null)
            {
                Personal = _personalRepository.SeleccionarPorId(idPersonal.Value);
            }

            //Obtenemos el resultado
            return new PersonalEditorResponseDto
            {
                Personal = Personal?.ProjectedAs<PersonalDto>(),
            };
        }

        /// <summary>
        /// Implementa método orquestador para insertar un Personal.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        public int Insertar(RequestDto<PersonalDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos            
            var PersonalNuevo = request.Registro.ProjectedAs<Personal>();

            //Logica de negocio para agregar la Personal
            PersonalNuevo.Insertar(request.Auditoria);

            //Iniciamos la transacción
            _personalRepository.IniciarTransaccion();

            //Registramos los cambios en la Base de Datos
            _personalRepository.Insertar(PersonalNuevo);

            //Finalizamos la transacción
            _personalRepository.FinalizarTransaccion();

            return PersonalNuevo.IdPersonal;
        }

        /// <summary>
        /// Implementa método orquestador para actualizar una Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        public void Actualizar(RequestDto<PersonalDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos            
            AuditoriaDto auditoria = request.Auditoria;
            Personal PersonalConNuevoValores = request.Registro.ProjectedAs<Personal>();
            
            Personal PersonalActual = _personalRepository.SeleccionarPorId(PersonalConNuevoValores.IdPersonal);

            //Logica de negocio para modificar al Personal
            PersonalActual.Actualizar(PersonalConNuevoValores, request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _personalRepository.Actualizar(PersonalActual);
        }


        /// <summary>
        /// Implementa método orquestador para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        public void Desactivar(RequestDto<PersonalDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos
            var PersonalActual = _personalRepository.SeleccionarPorId(request.Registro.IdPersonal.Value);

            //Logica de negocio para modificar la usuario
            PersonalActual.Desactivar(request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _personalRepository.ActualizarActivo(PersonalActual);
        }

        /// <summary>
        /// Implementa método orquestador para activar una Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        public void Activar(RequestDto<PersonalDto> request)
        {
            //Validación de parámetros
            ValidarParametroRequest(request);

            //Obtenemos datos
            var PersonalActual = _personalRepository.SeleccionarPorId(request.Registro.IdPersonal.Value);

            //Logica de negocio para modificar la usuario
            PersonalActual.Activar(request.Auditoria);

            //Registramos los cambios en la Base de Datos
            _personalRepository.ActualizarActivo(PersonalActual);
        }

        #endregion



        #region MÉTODOS - Implementa IDisposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public void Dispose()
        {
            _personalRepository.Dispose();
        }

        #endregion
    }
}