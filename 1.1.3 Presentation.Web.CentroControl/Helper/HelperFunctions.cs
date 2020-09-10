using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Olimpiadas.Web.CMS.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class HelperFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivoEnModelo"></param>
        /// <returns></returns>
        public static byte[] DevolverImagen(IFormFile archivoEnModelo)
        {
            try
            {
                byte[] result;
                int lenght = 0;
                bool error = false;

                using (var fileStream = archivoEnModelo.OpenReadStream())
                {
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        result = ms.ToArray();
                        error = Int32.TryParse(fileStream.Length.ToString(), out lenght);
                        if (!error) return null;

                        //string s = Convert.ToBase64String(fileBytes);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}