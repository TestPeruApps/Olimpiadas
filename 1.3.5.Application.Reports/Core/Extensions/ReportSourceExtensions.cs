using Olimpiadas.CrossCutting.Enumerations;

namespace Olimpiadas.Application.Reports.Core.Extensions
{
    /// <summary>
    /// Métodos de extensión para reportes de CrystalReports.
    /// </summary>
    public static class ReportSourceExtensions
    {
        #region MÉTODOS APOYO       

        /// <summary>
        /// Retorna la extensión del reporte
        /// </summary>
        /// <param name="formatoReporte">formatoReporte</param>
        /// <returns>Extension</returns>
        public static string ReportExtension(this EnumFormatoReporte formatoReporte)
        {
            var ext = "";
            switch (formatoReporte)
            {
                case EnumFormatoReporte.PortableDocFormat:
                    ext = ".pdf";
                    break;
                case EnumFormatoReporte.Excel:
                    ext = ".xls";
                    break;
                case EnumFormatoReporte.ExcelRecord:
                    ext = ".xlsx";
                    break;
                case EnumFormatoReporte.HTML32:
                    ext = ".htm";
                    break;
                case EnumFormatoReporte.HTML40:
                    ext = ".html";
                    break;
                case EnumFormatoReporte.Text:
                    ext = ".txt";
                    break;
                case EnumFormatoReporte.WordForWindows:
                    ext = ".docx";
                    break;
                case EnumFormatoReporte.Xml:
                    ext = ".xml";
                    break;
                case EnumFormatoReporte.CrystalReport:
                    ext = ".rpt";
                    break;
            }
            return ext;
        }       

        /// <summary>
        /// Retorna el tipo de contenido del reporte
        /// </summary>
        /// <param name="formatoReporte">formatoReporte</param>
        /// <returns>ContentType</returns>
        public static string ReportContentType(this EnumFormatoReporte formatoReporte)
        {
            var contentType = "";
            switch (formatoReporte)
            {
                case EnumFormatoReporte.PortableDocFormat:
                    contentType = "application/pdf";
                    break;
                case EnumFormatoReporte.Excel:
                    contentType = "application/vnd.ms-excel";
                    break;
                case EnumFormatoReporte.ExcelRecord:
                    contentType = "application/vnd.ms-excel";
                    break;
                case EnumFormatoReporte.HTML32:
                    contentType = "text/HTML";
                    break;
                case EnumFormatoReporte.HTML40:
                    contentType = "text/HTML";
                    break;
                case EnumFormatoReporte.Text:
                    contentType = "text/plain";
                    break;
                case EnumFormatoReporte.WordForWindows:
                    contentType = "application/msword";
                    break;
                case EnumFormatoReporte.Xml:
                    contentType = "application/xml";
                    break;
            }
            return contentType;
        }

        #endregion
    }
}