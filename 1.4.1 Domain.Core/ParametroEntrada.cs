using System.Data;

namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ParametroEntrada
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valor"></param>
        public ParametroEntrada(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }        

        /// <summary>
        /// 
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Valor { get; private set; }        
    }
}