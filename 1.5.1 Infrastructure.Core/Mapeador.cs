using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Olimpiadas.Infrastructure.Data.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Mapeador 
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSimplex"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public List<TSimplex> MapearListaSimple<TSimplex>(IDataReader dataReader)
            where TSimplex : new()
        {
            var resultado = new List<TSimplex>();
            while (dataReader.Read())
            {
                var valor = dataReader.GetValue(0);
                resultado.Add((TSimplex)valor);
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public List<TComplex> MapearListaComplex<TComplex>(IDataReader dataReader)
            where TComplex : class, new()
        {
            var resultado = new List<TComplex>();
            EquivalenciaDataReaderEntidad[] equivalencia = null;
            while (dataReader.Read())
            {
                if (equivalencia == null) equivalencia = ObtenerEquivalencia<TComplex>(dataReader);
                resultado.Add(MapearFila<TComplex>(dataReader, equivalencia));
            }
            return resultado;
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public TComplex MapearObjeto<TComplex>(IDataReader dataReader)
            where TComplex : class, new()
        {
            TComplex resultado = null;
            EquivalenciaDataReaderEntidad[] equivalencia = null;
            while (dataReader.Read())
            {
                if (equivalencia == null) equivalencia = ObtenerEquivalencia<TComplex>(dataReader);
                resultado = MapearFila<TComplex>(dataReader, equivalencia);
                break;
            }
            return resultado;
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="propiedadNombre"></param>
        /// <returns></returns>
        public SqlDbType MapearATipoSql<TComplex>(string propiedadNombre)
            where TComplex : class, new()
        {
            var codigoTipo = typeof(TComplex).GetProperty(propiedadNombre).PropertyType;
            var cod = Type.GetTypeCode(codigoTipo);

            if (Type.GetTypeCode(codigoTipo) == TypeCode.Int32)
            {
                return SqlDbType.Int;
            }
            else if (Type.GetTypeCode(codigoTipo) == TypeCode.Int16)
            {
                return SqlDbType.SmallInt;
            }
            else if (Type.GetTypeCode(codigoTipo) == TypeCode.Byte)
            {
                return SqlDbType.TinyInt;
            }
            else if (Type.GetTypeCode(codigoTipo) == TypeCode.String)
            {
                return SqlDbType.VarChar;
            }
            else if (Type.GetTypeCode(codigoTipo) == TypeCode.Boolean)
            {
                return SqlDbType.Bit;
            }
            else if (Type.GetTypeCode(codigoTipo) == TypeCode.Decimal)
            {
                return SqlDbType.Decimal;
            }
            return SqlDbType.VarChar;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="entidad"></param>
        /// <param name="propiedadNombre"></param>
        /// <returns></returns>
        public object ObtenerValorDePropiedad<TComplex>(TComplex entidad, string propiedadNombre)
            where TComplex : class, new()
        {
            var resultado = entidad.GetType().GetProperty(propiedadNombre).GetValue(entidad, null);
            if (resultado == null) return DBNull.Value;
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="entidad"></param>
        /// <param name="propiedadNombre"></param>
        /// <param name="valor"></param>
        public void EstablecerValorAPropiedad<TComplex>(TComplex entidad, string propiedadNombre, object valor)
            where TComplex : class, new()
        {
            entidad.GetType().GetProperty(propiedadNombre).SetValue(entidad, valor, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private EquivalenciaDataReaderEntidad[] ObtenerEquivalencia<TComplex>(IDataReader dataReader)
            where TComplex : class, new()
        {
            var propiedades = typeof(TComplex).GetProperties();

            var cantidadColumnas = dataReader.FieldCount;
            var equivalenciasDataReaderEntidad = new EquivalenciaDataReaderEntidad[cantidadColumnas];
            for (byte indiceEnDataReader = 0; indiceEnDataReader < cantidadColumnas; indiceEnDataReader++)
            {
                var nombreColumna = dataReader.GetName(indiceEnDataReader);
                var propiedad = propiedades.FirstOrDefault(p => p.Name == nombreColumna);
                if (propiedad != null) equivalenciasDataReaderEntidad[indiceEnDataReader] = new EquivalenciaDataReaderEntidad(indiceEnDataReader, propiedad);
            }

            return equivalenciasDataReaderEntidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComplex"></typeparam>
        /// <param name="dataReader"></param>
        /// <param name="equivalenciasDataReaderEntidad"></param>
        /// <returns></returns>
        private TComplex MapearFila<TComplex>(IDataReader dataReader, EquivalenciaDataReaderEntidad[] equivalenciasDataReaderEntidad)
            where TComplex : class, new()
        {
            var fila = new TComplex();
            foreach (var equivalencia in equivalenciasDataReaderEntidad)
            {
                if (equivalencia != null)
                {
                    object value = dataReader[equivalencia.IndiceEnDataReader] is DBNull
                        ? null
                        : dataReader[equivalencia.IndiceEnDataReader];

                    equivalencia.PropertyInfo.SetValue(fila, value, null);
                }
            }

            return fila;
        }
    }
}