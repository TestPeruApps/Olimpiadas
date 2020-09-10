using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.CrossCutting.Enumerations;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Application.Dto.GestionContenido.Personal;
using Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Personal;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionContenido;


namespace Olimpiadas.Web.CMS.Areas.Contenido.Controllers
{
    /// <summary>
    /// Métodos para controlar las interacciones desde el navegador web del formulario de Personal.
    /// </summary>
    [Area("Contenido"), Authorize]
    public partial class PersonalController : Controller
    {                
        #region VARIABLES

        /// <summary>
        /// Interface al servicio de gestión de contenidos.
        /// </summary>
        private readonly IGestionContenidoService _gestionContenidoService;

        #endregion



        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del controlador.
        /// </summary>
        /// <param name="gestionContenidoService">Interface al servicio de gestión de contenido.</param>
        public PersonalController(IGestionContenidoService gestionContenidoService)
        {
            _gestionContenidoService = gestionContenidoService;
        }

        #endregion



        #region MÉTODOS - Actions

        /// <summary>
        /// Método que devuelve la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <returns>Vista con la paginación de Personal.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(PersonalGridViewModel modelGrid)
        {
            //Construimos el request
            var request = new PaginacionRequestDto<PersonalDto>(modelGrid.Filtro, modelGrid.Index, 10, modelGrid.Dir, User.GetUsuarioIdOrDefault());

            //Invocamos al servicio
            var response = await _gestionContenidoService.PersonalPaginarAsync(request);

            //Construimos el model
            modelGrid = new PersonalGridViewModel(response, request.CriteriosPaginacion);

            //Retornamos vista con modelo
            return PartialView("_Index", modelGrid);
        }

        /// <summary>
        /// Método que devuelve la vista con el editor de Personal.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el editor.</returns>
        [HttpGet]
        public async Task<IActionResult> Editor(int? id)
        {
            //Invocamos al servicio
            var response = await _gestionContenidoService.PersonalObtenerEditorAsync(id);

            //Asignamos valores por defecto
            if (id == null)
            {
                response.Personal = new PersonalDto
                {
                    Activo = true
                };
            }

            //Construimos el modelo
            var model = new PersonalEditorViewModel(response);

            //Retornamos vista con modelo
            return PartialView("_Editor", model);
        }

        /// <summary>
        /// Método que solicita insertar un Personal y retorna la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="modelEditor">Modelo con datos del editor.</param>
        /// <returns>Vista con el listado de Personal.</returns>
        [HttpPost]
        public async Task<IActionResult> Insertar(PersonalGridViewModel modelGrid, PersonalEditorViewModel modelEditor)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<PersonalDto>
                {
                    Registro = modelEditor.Personal,
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.PersonalInsertarAsync(request);

                //Refrescamos la pagina con los registros actuales
                return await Index(modelGrid);
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }

        /// <summary>
        /// Método que solicita actualizar un Personal y retorna la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="modelEditor">Modelo con datos del editor.</param>
        /// <returns>Vista con el listado de Personal.</returns>
        [HttpPost]
        public async Task<IActionResult> Actualizar(PersonalGridViewModel modelGrid, PersonalEditorViewModel modelEditor)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<PersonalDto>
                {
                    Registro = modelEditor.Personal,
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.PersonalActualizarAsync(request);

                //Refrescamos la pagina con los registros actuales
                return await Index(modelGrid);
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }

        /// <summary>
        /// Método que solicita activar un Personal y retorna la vista por defecto del controlador.
        /// </summary>
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el listado de Personal.</returns>
        [HttpPost]
        public async Task<IActionResult> Activar(PersonalGridViewModel modelGrid, int id)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<PersonalDto>
                {
                    Registro = new PersonalDto { IdPersonal = id },
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.PersonalActivarAsync(request);

                //Refrescamos la pagina con los registros actuales
                return await Index(modelGrid);
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }

        /// <summary>
        /// Método que solicita desactivar un Personal y retorna la vista por defecto del controlador.
        /// </summary>
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el listado de Personal.</returns>
        [HttpPost]
        public async Task<IActionResult> Desactivar(PersonalGridViewModel modelGrid, int id)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<PersonalDto>
                {
                    Registro = new PersonalDto { IdPersonal = id },
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.PersonalDesactivarAsync(request);

                //Refrescamos la pagina con los registros actuales
                return await Index(modelGrid);
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }

        #endregion
    }
}