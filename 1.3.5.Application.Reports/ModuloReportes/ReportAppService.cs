using System;
using System.Linq;

using Olimpiadas.Application.Dto.ModuloReportes.Reportes;
using Olimpiadas.Application.Interfaces.ModuloReportes;
using Olimpiadas.Application.Reports.Core;
using Olimpiadas.Domain.Modulos.GestionSeguridad;
using Olimpiadas.Domain.Modulos.ModuloReportes;


namespace Olimpiadas.Application.Reports.ModuloReportes
{
    /// <summary>
    /// Implementa métodos para orquestar operaciones de la generación de reportes.
    /// </summary>
    public class ReportAppService : ReporteBaseLogic, IReportAppService
    {
        #region VARIABLES

        /// <summary>
        /// Interface del repositorio de Usuarios.
        /// </summary>
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Interface del repositorio de Usuarios.
        /// </summary>
        private readonly IReportYTQPRepository _reportYTQPRepository;

        /// <summary>
        /// Interface del repositorio de Usuarios.
        /// </summary>
        private readonly IReportRCRepository _reportRCRepository;

        /// <summary>
        /// Interface del repositorio de Estado de Uso.
        /// </summary>
        private readonly IEstadoUsoRepository _estadoUsoRepository;
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase con los repositorios que usa.
        /// </summary>
        /// <param name="usuarioRepository">Interface del repositorio de Usuarios.</param>
        /// <param name="reportRCRepository">Interface del repositorio de Reportes RC.</param>
        /// <param name="reportYTQPRepository">Interface del repositorio de Reportes YTQP.</param>
        /// <param name="estadoUsoRepository">Interface del repositorio de Estado de Uso.</param>
        public ReportAppService(
            IUsuarioRepository usuarioRepository,
            IReportRCRepository reportRCRepository,
            IReportYTQPRepository reportYTQPRepository,
            IEstadoUsoRepository estadoUsoRepository
            )
        {
            _usuarioRepository = usuarioRepository;
            _reportRCRepository = reportRCRepository;
            _reportYTQPRepository = reportYTQPRepository;
            _estadoUsoRepository = estadoUsoRepository;
        }

        #endregion

        #region MÉTODOS - Implementa IReportAppService

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Destinos Buscados"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto DestinosBuscados(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportRCRepository.DestinosBuscados(request.FechaInicio, request.FechaFinal);

            //Creamos reporte
            CargarPlantilla("DestinosBuscados");
            AgregarParametro("RangoDatos", request.RangoDatos);
            AgregarDataSource("DsDestinosBuscados", destinos);            

            //Retornamos reporte
            return ObtenerPdf("nombreArchivo");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Estados de uso"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto EstadoUso(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Actualizamos los campos en la Base de Datos
            _estadoUsoRepository.ActualizarEstadoUso(null);

            //Obtenemos datos
            var destinos = _reportRCRepository.EstadoUso();

            //Creamos reporte
            CargarPlantilla("EstadoDeUso");
            AgregarDataSource("DsEstadoDeUso", destinos);

            //Retornamos reporte
            return ObtenerPdf("EstadoDeUso");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Consolidado de Registros al Sistema por Ubigeo"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto ConsolidadoRegistroDistrito(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportRCRepository.ConsolidadoRegistroDistrito(request.FechaInicio, request.FechaFinal);

            //Creamos reporte
            CargarPlantilla("RegistroPorDistrito");
            AgregarParametro("RangoDatos", request.RangoDatos);
            AgregarDataSource("DsRegistroPorDistrito", destinos);

            //Retornamos reporte
            return ObtenerPdf("RegistroPorDistrito");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Desplazamientos de Usuarios a la Ruta Corta"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto DesplazamientoRuta(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportRCRepository.DesplazamientoRuta(request.AnioId);

            //Creamos reporte
            CargarPlantilla("DesplazamientoARuta");
            AgregarParametro("RangoDatos", request.RangoDatos);
            AgregarDataSource("DsDesplazamientoARuta", destinos);

            //Retornamos reporte
            return ObtenerPdf("DesplazamientoARuta");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Ranking de Secciones Internas mas Visitadas"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto RankingSeccionVisitada(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportRCRepository.RankingSeccionVisitada(request.FechaInicio, request.FechaFinal);

            //Creamos reporte
            CargarPlantilla("RankingSeccionVisitada");
            AgregarParametro("RangoDatos", request.RangoDatos);
            AgregarDataSource("DsRankingSeccionVisitada", destinos);

            //Retornamos reporte
            return ObtenerPdf("RankingSeccionVisitada");

        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Consolidado de Registros al Sistema por Género"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto ConsolidadoRegistroGenero(RequestReporteDto request)
        {
            try
            {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportYTQPRepository.ConsolidadoRegistroGenero();

            //Creamos reporte
            CargarPlantilla("RegistroPorGenero");
            AgregarDataSource("DsRegistroPorGenero", destinos);

            //Retornamos reporte
            return ObtenerPdf("RegistroPorGenero");
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                var i = ex.InnerException;
                return null;
            }
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Consolidado de Registros al Sistema por Edad"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto ConsolidadoRegistroEdad(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var destinos = _reportYTQPRepository.ConsolidadoRegistroEdad();

            //Creamos reporte
            CargarPlantilla("RegistroPorEdad");
            AgregarDataSource("DsRegistroPorEdad", destinos);

            //Retornamos reporte
            return ObtenerPdf("RegistroPorEdad");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Lista de Turistas Registrados en el App"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte.</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto RegistroTurista(RequestReporteDto request)
        {
            //Obtenemos parametros
            request.ObtenerFechas();

            //Obtenemos datos
            var usuariosYTQP = _reportYTQPRepository.ListaUsuariosYTQP(request.FechaInicio, request.FechaFinal);
            var turistas = _reportRCRepository.ListaTuristas(request.FechaInicio, request.FechaFinal);

            var listaTurista = from usuario in usuariosYTQP
                               join turista in turistas
                                    on usuario.IdUsuario equals turista.IdUsuarioYTQP
                                select new
                                {
                                    usuario.IdUsuario,
                                    usuario.NombresApellidos,
                                    usuario.Genero,
                                    usuario.Dni,
                                    usuario.FechaNacimiento,
                                    usuario.CorreoElectronico,
                                    usuario.RegistroPorApp,
                                    usuario.CodigoUbigeo,
                                    usuario.FechaRegistro,
                                    turista.IdUsuarioYTQP,
                                    turista.TipoRegistro,
                                    turista.Departamento,
                                    turista.Distrito,
                                    turista.OrigenRuta,
                                    turista.AceptaPrivacidad,
                                    turista.Avat_Nivel
                                };

            //Creamos reporte
            CargarPlantilla("RegistroTurista");
            AgregarParametro("RangoDatos", request.RangoDatos);
            AgregarDataSource("DsRegistroTurista", listaTurista);

            //Retornamos reporte
            return ObtenerExcel("RegistroTurista");
        }

        /// <summary>
        /// Implementa método orquestador para obtener el reporte : "Lista de Notificaciones Push Masivo"
        /// </summary>
        /// <param name="request">Datos para obtener el reporte</param>
        /// <returns>Datos del reporte.</returns>
        public ResponseReporteDto NotificacionesPushMasivo(RequestReporteDto request)
        {
            //Obtenemos datos
            var notificacionesPush = _reportRCRepository.NotificacionPushMasivo(request.Push_Id);

            //Creamos reporte
            CargarPlantilla("NotificacinesPushMasivo");
            AgregarDataSource("DsNotificacinesPushMasivo", notificacionesPush);

            //Retornamos reporte
            return ObtenerExcel("NotificacinesPushMasivo");
        }

        #endregion

        #region MÉTODOS - Implementa IDisposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public new void Dispose()
        {
            _usuarioRepository.Dispose();
            _reportRCRepository.Dispose();
            _reportYTQPRepository.Dispose();
            _estadoUsoRepository.Dispose();
            base.Dispose();
        }

        #endregion
    }
}