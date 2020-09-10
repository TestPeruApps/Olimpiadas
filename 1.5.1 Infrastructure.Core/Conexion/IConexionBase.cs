using System;
using System.Data.SqlClient;

namespace Olimpiadas.Infrastructure.Data.Core.Conexion
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConexionBase : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SqlConnection ObtenerConexion();

        /// <summary>
        /// 
        /// </summary>
        void AbrirConexion();

        /// <summary>
        /// 
        /// </summary>
        void IniciarTransaccion();

        /// <summary>
        /// 
        /// </summary>
        void FinalizarTransaccion();        
    }
}