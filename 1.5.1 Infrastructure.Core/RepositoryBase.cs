using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Domain.Core;
using Olimpiadas.Infrastructure.Data.Core.Conexion;

namespace Olimpiadas.Infrastructure.Data.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryBase : IDisposable
    {
        #region VARIABLES PRIVADAS

        /// <summary>
        /// 
        /// </summary>
        internal readonly Mapeador mapeador;

        /// <summary>
        /// Conexión a base de datos
        /// </summary>
        internal readonly IConexionBase _conexionBaseDatos;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexionBaseDatos"></param>
        public RepositoryBase(IConexionBase conexionBaseDatos)
        {
            _conexionBaseDatos = conexionBaseDatos;
            mapeador = new Mapeador();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void IniciarTransaccion()
        {
            _conexionBaseDatos.IniciarTransaccion();
        }

        /// <summary>
        /// 
        /// </summary>
        public void FinalizarTransaccion()
        {
            _conexionBaseDatos.FinalizarTransaccion();
        }

        #region MÉTODOS - Implementación IRepository       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public List<TResultado> Listar<TResultado>(ParametroAccesosDatos parametroAccesosDatos)
            where TResultado : class, new()
        {
            var resultado = new List<TResultado>();
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    resultado = mapeador.MapearListaComplex<TResultado>(dataReader);
                }
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            }
            return resultado;
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResultado"></typeparam>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public List<TResultado> ListarSimple<TResultado>(ParametroAccesosDatos parametroAccesosDatos)
            where TResultado : new()
        {
            var resultado = new List<TResultado>();
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    resultado = mapeador.MapearListaSimple<TResultado>(dataReader);
                }
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
                return resultado;
            }
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResultado"></typeparam>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public TResultado Obtener<TResultado>(ParametroAccesosDatos parametroAccesosDatos)
            where TResultado : class, new()
        {
            TResultado resultado;
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    resultado = mapeador.MapearObjeto<TResultado>(dataReader);
                }
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            }
            return resultado;
        }        
       
        #endregion

        #region MÉTODOS DE APOYO

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        internal SqlCommand CrearComando(ParametroAccesosDatos parametroAccesosDatos)
        {
            var comandoSql = new SqlCommand(parametroAccesosDatos.ProcedimientoAlmacenado, _conexionBaseDatos.ObtenerConexion());
            {
                comandoSql.CommandType = CommandType.StoredProcedure;
            }

            CrearParametrosEntrada(comandoSql, parametroAccesosDatos);
            CrearParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);            
            AbrirConexionBaseDatos();

            return comandoSql;
        }        

        internal void AbrirConexionBaseDatos()
        {
            _conexionBaseDatos.AbrirConexion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="parametroAccesosDatos"></param>
        internal void CrearParametrosEntrada(SqlCommand comandoSql, ParametroAccesosDatos parametroAccesosDatos)
        {
            if (parametroAccesosDatos.ParametrosEntrada != null)
            {
                foreach (ParametroEntrada parametroEntrada in parametroAccesosDatos.ParametrosEntrada)
                {
                    comandoSql.Parameters.AddWithValue
                    (
                        string.Concat("@", parametroEntrada.Nombre),
                        parametroEntrada.Valor
                    );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="parametrosSalida"></param>
        internal void CrearParametrosSalida(SqlCommand comandoSql, ParametroSalida[] parametrosSalida)
        {
            if (parametrosSalida != null)
            {
                foreach (ParametroSalida parametroSalida in parametrosSalida)
                {                    
                    var parametro = new SqlParameter
                    {
                        ParameterName = string.Concat("@", parametroSalida.Nombre),
                        Direction = ParameterDirection.Output,
                        SqlDbType = parametroSalida.TipoDatoSql
                    };

                    if (parametroSalida.Size != 0) parametro.Size = parametroSalida.Size;
                    comandoSql.Parameters.Add(parametro);
                }
            }
        }

        internal void CrearParametrosPaginacion(SqlCommand comandoSql, CriteriosPaginacionDto criteriosPaginacion)
        {
            if (criteriosPaginacion != null)
            {
                comandoSql.Parameters.AddWithValue(
                    string.Concat("@", nameof(criteriosPaginacion.NumeroPagina)),
                    criteriosPaginacion.NumeroPagina);

                comandoSql.Parameters.AddWithValue(
                    string.Concat("@", nameof(criteriosPaginacion.TamanioPagina)), 
                    criteriosPaginacion.TamanioPagina);

                SqlParameter parametro = new SqlParameter
                {
                    ParameterName = string.Concat("@TotalFilas"),
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Int
                };
                comandoSql.Parameters.Add(parametro);
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="parametrosSalida"></param>
        internal void ObtenerValorParametrosSalida(SqlCommand comandoSql, ParametroSalida[] parametrosSalida)
        {
            if (parametrosSalida != null)
            {
                foreach (ParametroSalida parametroSalida in parametrosSalida)
                {
                    parametroSalida.Valor = comandoSql.Parameters[string.Concat("@", parametroSalida.Nombre)].Value;
                }
            }
        }        

        #endregion

        #region MÉTODOS - Implementación IDsiposable

        /// <summary>
        /// Implementa tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public virtual void Dispose()
        {
            if (_conexionBaseDatos != null)
            {
                _conexionBaseDatos.Dispose();
            }
        }

        #endregion
    }
}