namespace Olimpiadas.Infrastructure.Data.Core.Conexion
{
    /// <summary>
    /// 
    /// </summary>
    public class ConexionOlimpiadas : ConexionBase, IConexionBase
    {
        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyCadenaConexion"></param>
        public ConexionOlimpiadas(string keyCadenaConexion)
            :base (keyCadenaConexion)
        {
        }

        #endregion              

    }
}