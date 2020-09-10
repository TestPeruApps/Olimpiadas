namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ParametroAccesosDatos
    {
        /// <summary>
        /// 
        /// </summary>
        public string ProcedimientoAlmacenado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ParametroEntrada[] ParametrosEntrada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ParametroSalida[] ParametrosSalida { get; set; }
    }    
}