using System.DirectoryServices;

namespace Olimpiadas.CrossCutting.Helper.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class ActiveDirectory
    {
        /// <summary>
        /// Verifica que el dominio, usuario y contraseña sean incorectos
        /// </summary>
        /// <param name="dominio"></param>
        /// <param name="usuario"></param>
        /// <param name="pwd"></param>
        /// <param name="path"></param>
        /// <returns>Devuelve un valor booleano para indidcar si esta autenticado, o una exepción con los resultados de la autenticació.</returns>
        public static bool Autenticar(string dominio, string usuario, string pwd, string path)
        {
            var entry = new DirectoryEntry(path, usuario, pwd);
            var search = new DirectorySearcher(entry);
            SearchResult result = search.FindOne();
            return result != null;
        }
    }
}
