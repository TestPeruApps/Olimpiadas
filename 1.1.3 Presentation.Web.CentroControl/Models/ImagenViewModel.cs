using Microsoft.AspNetCore.Http;

namespace Olimpiadas.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ImagenViewModel
    {
        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        public ImagenViewModel()
        {
            
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public string ConfigUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PosicionX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PosicionY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AltoMinimo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AnchoMinimo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AltoMaximo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AnchoMaximo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AltoCortado { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int AnchoCortado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IFormFile FilesToUpload { get; set; }

        #endregion
    }
}