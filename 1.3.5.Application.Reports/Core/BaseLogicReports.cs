using System;
using Microsoft.Reporting.WebForms;

using Olimpiadas.Application.Dto.ModuloReportes.Reportes;

namespace Olimpiadas.Application.Reports.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ReporteBaseLogic : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private ReportViewer _reportViewer = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePlantilla"></param>
        public void CargarPlantilla(string nombrePlantilla)
        {            
            _reportViewer = new ReportViewer { ProcessingMode = ProcessingMode.Local };
            _reportViewer.Reset();
            _reportViewer.LocalReport.ReportPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\bin\Reportes\", nombrePlantilla, ".rdlc");
            _reportViewer.LocalReport.DataSources.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreDataSource"></param>
        /// <param name="dataSource"></param>
        public void AgregarDataSource(string nombreDataSource, object dataSource)
        {
            var reportDataSource = new ReportDataSource { Name = nombreDataSource, Value = dataSource };
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreParametro"></param>
        /// <param name="valor"></param>
        public void AgregarParametro(string nombreParametro, string valor)
        {
            var reportParameter = new ReportParameter();            

            var parametros = new ReportParameter[1];
            parametros[0] = new ReportParameter(nombreParametro, valor);
            _reportViewer.LocalReport.SetParameters(parametros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePlantilla"></param>
        public ResponseReporteDto ObtenerPdf(string nombreArchivoPdf)
        {
            var byteArray = _reportViewer.LocalReport.Render("pdf");

            return new ResponseReporteDto
            {
                NombreArchivo = string.Concat(nombreArchivoPdf, ".pdf"),
                TipoContenido = "application/pdf",
                Reporte = byteArray
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePlantilla"></param>
        public ResponseReporteDto ObtenerExcel(string nombreArchivoPdf)
        {
            var byteArray = _reportViewer.LocalReport.Render("Excel");

            return new ResponseReporteDto
            {
                NombreArchivo = string.Concat(nombreArchivoPdf, ".xls"),
                TipoContenido = "application/vnd.ms-excel",
                Reporte = byteArray
            };
        }

        public void Dispose()
        {
            _reportViewer.Dispose();
        }
    }
}