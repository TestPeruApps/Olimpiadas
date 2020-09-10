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
    public class Repository<TEntidad> : RepositoryBase, IRepository<TEntidad>
        where TEntidad : class, new()
    {
        #region VARIABLES PRIVADAS                

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexionBaseDatos"></param>
        public Repository(IConexionBase conexionBaseDatos)
            : base (conexionBaseDatos)
        {
        }

        #endregion

        #region MÉTODOS - Implementación IRepository

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public List<TEntidad> Listar(ParametroAccesosDatos parametroAccesosDatos)
        {
            var resultado = new List<TEntidad>();
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    resultado = mapeador.MapearListaComplex<TEntidad>(dataReader);
                }
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            }
            return resultado;
        }                

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public TEntidad Obtener(ParametroAccesosDatos parametroAccesosDatos)
        {
            TEntidad resultado;
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    resultado = mapeador.MapearObjeto<TEntidad>(dataReader);
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
        /// <param name="filtro"></param>
        /// <param name="criteriosPaginacion"></param>
        /// <returns></returns>
        public Paginado<TResultado> Paginar<TResultado>(ParametroAccesosDatosTipado parametroAccesosDatos, TResultado filtro, CriteriosPaginacionDto criteriosPaginacion)
            where TResultado : class, new()
        {
            var items = new List<TResultado>();
            int totalItems = 0;
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos, filtro, criteriosPaginacion))
            {
                using (SqlDataReader dataReader = comandoSql.ExecuteReader())
                {
                    items = mapeador.MapearListaComplex<TResultado>(dataReader);
                }
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
                if (criteriosPaginacion != null) totalItems = (int)comandoSql.Parameters["@TotalFilas"].Value;
            }
            return new Paginado<TResultado>
            {
                Items = items,
                TotalItems = totalItems
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <param name="entidad"></param>
        public void Ejecutar(ParametroAccesosDatosTipado parametroAccesosDatos, TEntidad entidad)
        {
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos, entidad))
            {
                comandoSql.ExecuteNonQuery();
                ActualizarEntidad(comandoSql, parametroAccesosDatos.PropiedadesCalculadas, entidad);
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        public void Ejecutar(ParametroAccesosDatos parametroAccesosDatos)
        {
            using (SqlCommand comandoSql = CrearComando(parametroAccesosDatos))
            {
                comandoSql.ExecuteNonQuery();
                ObtenerValorParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            }
        }        

        #endregion

        #region MÉTODOS DE APOYO

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parametroAccesosDatos"></param>
        /// <param name="entidad"></param>
        /// <param name="criteriosPaginacion"></param>
        /// <returns></returns>
        private SqlCommand CrearComando<T>(ParametroAccesosDatosTipado parametroAccesosDatos, T entidad, CriteriosPaginacionDto criteriosPaginacion = null)
            where T : class, new()
        {
            var comandoSql = new SqlCommand(parametroAccesosDatos.ProcedimientoAlmacenado, _conexionBaseDatos.ObtenerConexion());
            {
                comandoSql.CommandType = CommandType.StoredProcedure;
            }

            CrearParametrosEntrada(comandoSql, parametroAccesosDatos.ParametrosEntrada, entidad);
            CrearParametrosSalidaParaActualizarEntidad(comandoSql, parametroAccesosDatos.PropiedadesCalculadas);
            CrearParametrosPaginacion(comandoSql, criteriosPaginacion);
            CrearParametrosSalida(comandoSql, parametroAccesosDatos.ParametrosSalida);
            AbrirConexionBaseDatos();

            return comandoSql;
        }           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="parametrosEntrada"></param>
        /// <param name="entidad"></param>
        private void CrearParametrosEntrada<T>(SqlCommand comandoSql, string[] parametrosEntrada, T entidad)
            where T : class, new()
        {
            if (parametrosEntrada != null)
            {
                foreach (string parametroEntrada in parametrosEntrada)
                {
                    comandoSql.Parameters.AddWithValue
                    (
                        string.Concat("@", parametroEntrada),
                        mapeador.ObtenerValorDePropiedad<T>(entidad, parametroEntrada)
                    );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="propiedadesCalculadas"></param>
        private void CrearParametrosSalidaParaActualizarEntidad(SqlCommand comandoSql, string[] propiedadesCalculadas)
        {
            if (propiedadesCalculadas != null)
            {
                foreach (string propiedadeCalculada in propiedadesCalculadas)
                {
                    SqlParameter parametro = new SqlParameter
                    {
                        ParameterName = string.Concat("@", propiedadeCalculada),
                        Direction = ParameterDirection.Output,
                        SqlDbType = mapeador.MapearATipoSql<TEntidad>(propiedadeCalculada)
                    };
                    comandoSql.Parameters.Add(parametro);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSql"></param>
        /// <param name="propiedadesCalculadas"></param>
        /// <param name="entidad"></param>
        private void ActualizarEntidad(SqlCommand comandoSql, string[] propiedadesCalculadas, TEntidad entidad)
        {
            if (propiedadesCalculadas != null)
            {
                foreach (string propiedadeCalculada in propiedadesCalculadas)
                {
                    object valor = comandoSql.Parameters[string.Concat("@", propiedadeCalculada)].Value;
                    mapeador.EstablecerValorAPropiedad<TEntidad>(entidad, propiedadeCalculada, valor);
                }
            }
        }

        #endregion       
    }
}