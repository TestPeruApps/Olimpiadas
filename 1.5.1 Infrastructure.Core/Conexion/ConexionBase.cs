using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Olimpiadas.CrossCutting.Helper.Configuration;

namespace Olimpiadas.Infrastructure.Data.Core.Conexion
{
    /// <summary>
    /// 
    /// </summary>
    public class ConexionBase
    {
        #region VARIABLES PRIVADAS

        /// <summary>
        /// Conexión a base de datos
        /// </summary>
        private readonly SqlConnection _sqlConnection;

        /// <summary>
        /// Transacción de base de datos
        /// </summary>
        private TransactionScope _transactionScope;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyCadenaConexion"></param>
        public ConexionBase(string keyCadenaConexion)
        {
            _sqlConnection = new SqlConnection(Config.AppSettingObtenerObtenerCadenaConexion(keyCadenaConexion));
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public SqlConnection ObtenerConexion()
        {
            return _sqlConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AbrirConexion()
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void IniciarTransaccion()
        {
            if (_transactionScope != null) return;

            if (_sqlConnection != null)
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }            

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };
            _transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            _sqlConnection.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public void FinalizarTransaccion()
        {
            if (_transactionScope == null) return;
            _transactionScope.Complete();
            _transactionScope.Dispose();
            _transactionScope = null;
        }

        #region MÉTODOS - Implementación IDsiposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public virtual void Dispose()
        {
            if (_sqlConnection != null)
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
                _sqlConnection.Dispose();
            }

            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }
        }

        #endregion

    }
}