using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.CrossCutting.Enumerations;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Application.Dto.GestionContenido.Participante;
using Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Participantes;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionContenido;


namespace Olimpiadas.Web.CMS.Areas.Contenido.Controllers
{
    /// <summary>
    /// Métodos para controlar las interacciones desde el navegador web del formulario de Participantes.
    /// </summary>
    [Area("Contenido"), Authorize]
    public partial class ParticipanteController : Controller
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
        public ParticipanteController(IGestionContenidoService gestionContenidoService)
        {
            _gestionContenidoService = gestionContenidoService;
        }

        #endregion



        #region MÉTODOS - Actions

        /// <summary>
        /// Método que devuelve la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <returns>Vista con la paginación de Participantes.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(ParticipanteGridViewModel modelGrid)
        {
            //Construimos el request
            var request = new PaginacionRequestDto<ParticipanteDto>(modelGrid.Filtro, modelGrid.Index, 10, modelGrid.Dir, User.GetUsuarioIdOrDefault());

            //Invocamos al servicio
            var response = await _gestionContenidoService.ParticipantePaginarAsync(request);

            //Construimos el model
            modelGrid = new ParticipanteGridViewModel(response, request.CriteriosPaginacion);

            //Retornamos vista con modelo
            return PartialView("_Index", modelGrid);
        }

        /// <summary>
        /// Método que devuelve la vista con el editor de participante.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el editor.</returns>
        [HttpGet]
        public async Task<IActionResult> Editor(int? id)
        {
            //Invocamos al servicio
            var response = await _gestionContenidoService.ParticipanteObtenerEditorAsync(id);

            //Asignamos valores por defecto
            if (id == null)
            {
                response.Participante = new ParticipanteDto
                {
                    Activo = true
                };
            }

            //Construimos el modelo
            var model = new ParticipanteEditorViewModel(response);

            //Retornamos vista con modelo
            return PartialView("_Editor", model);
        }

        /// <summary>
        /// Método que solicita insertar un Participante y retorna la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="modelEditor">Modelo con datos del editor.</param>
        /// <returns>Vista con el listado de Participantes.</returns>
        [HttpPost]
        public async Task<IActionResult> Insertar(ParticipanteGridViewModel modelGrid, ParticipanteEditorViewModel modelEditor)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<ParticipanteDto>
                {
                    Registro = modelEditor.Participante,
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.ParticipanteInsertarAsync(request);

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
        /// Método que solicita actualizar un Participante y retorna la vista por defecto del controlador.
        /// </summary>        
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="modelEditor">Modelo con datos del editor.</param>
        /// <returns>Vista con el listado de Participantes.</returns>
        [HttpPost]
        public async Task<IActionResult> Actualizar(ParticipanteGridViewModel modelGrid, ParticipanteEditorViewModel modelEditor)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<ParticipanteDto>
                {
                    Registro = modelEditor.Participante,
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.ParticipanteActualizarAsync(request);

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
        /// Método que solicita activar un Participante y retorna la vista por defecto del controlador.
        /// </summary>
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el listado de Participantes.</returns>
        [HttpPost]
        public async Task<IActionResult> Activar(ParticipanteGridViewModel modelGrid, int id)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<ParticipanteDto>
                {
                    Registro = new ParticipanteDto { IdParticipante = id },
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.ParticipanteActivarAsync(request);

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
        /// Método que solicita desactivar un Participante y retorna la vista por defecto del controlador.
        /// </summary>
        /// <param name="modelGrid">Modelo con datos del filtro de la grilla.</param>
        /// <param name="id">Id del registro.</param>
        /// <returns>Vista con el listado de Participantes.</returns>
        [HttpPost]
        public async Task<IActionResult> Desactivar(ParticipanteGridViewModel modelGrid, int id)
        {
            try
            {
                //Construimos el request
                var request = new RequestDto<ParticipanteDto>
                {
                    Registro = new ParticipanteDto { IdParticipante = id },
                    //Auditoria = User.GetAuditoria()
                };

                //Invocamos al servicio
                await _gestionContenidoService.ParticipanteDesactivarAsync(request);

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