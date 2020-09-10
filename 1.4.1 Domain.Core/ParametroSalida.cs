using System;
using System.Data;

namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ParametroSalida
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipoDatoSql"></param>
        /// <param name="sise"></param>
        public ParametroSalida(string nombre, SqlDbType tipoDatoSql, int sise = 0)
        {
            Nombre = nombre;
            TipoDatoSql = tipoDatoSql;
            Size = Size;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valor"></param>
        /// <param name="size"></param>
        public ParametroSalida(string nombre, object valor, int size = 0)
        {
            Nombre = nombre;
            Size = size;
            var tipoDato = valor.GetType();

            if (tipoDato.Equals(typeof(int)))
            {
                TipoDatoSql = SqlDbType.Int;
            }
            if (tipoDato.Equals(typeof(short)))
            {
                TipoDatoSql = SqlDbType.SmallInt;
            }
            if (tipoDato.Equals(typeof(byte)))
            {
                TipoDatoSql = SqlDbType.TinyInt;
            }
            if (tipoDato.Equals(typeof(string)))
            {
                TipoDatoSql = SqlDbType.VarChar;
            }
            if (tipoDato.Equals(typeof(bool)))
            {
                TipoDatoSql = SqlDbType.Bit;
            }
            if (tipoDato.Equals(typeof(Guid)))
            {
                TipoDatoSql = SqlDbType.UniqueIdentifier;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Valor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlDbType TipoDatoSql { get; private set; }
    }
}