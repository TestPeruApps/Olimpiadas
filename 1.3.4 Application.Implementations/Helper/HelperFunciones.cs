using System.Collections.Generic;
using System.Linq;


namespace Olimpiadas.Application.Implementations.Helper
{
    /// <summary>
    /// Helper con funciones compartidas generales
    /// </summary>
    static public class HelperFunciones
    {
        /// <summary>
        /// Método para concatenar los valores de una lista
        /// </summary>
        /// <param name="lista">Lista</param>
        /// <param name="separador">Caracter separador</param>
        /// <returns>Lista concatenada</returns>
        public static string ConcatenarLista<T>(List<T> lista, string separador=",")
        {
            var idsConcatenadas = string.Empty;
            if (lista != null)
            {
                if (lista.Count() > 0)
                {
                    foreach (var id in lista)
                    {
                        idsConcatenadas += id.ToString() + separador;
                    }
                    idsConcatenadas = idsConcatenadas.Remove(idsConcatenadas.Length - 1);
                }
            }
            return idsConcatenadas;
        }
    }
}
