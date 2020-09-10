namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ParametroAccesosDatosTipado
    {
        /// <summary>
        /// 
        /// </summary>
        public string ProcedimientoAlmacenado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] ParametrosEntrada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ParametroEntrada[] ParametrosEntradaOtros { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] PropiedadesCalculadas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ParametroSalida[] ParametrosSalida { get; set; }
    }    
}