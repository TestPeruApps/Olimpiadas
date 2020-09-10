using System.Collections.Generic;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad;


namespace Olimpiadas.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeViewModel
    {
        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        public HomeViewModel()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public HomeViewModel(ObtenerPermisosResponseDto response)
        {
            Usuario = response.Usuario;
            //Menus = response.Menus;
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public UsuarioDto Usuario { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public IEnumerable<MenuDto> Menus { get; set; }

        #endregion
    }
}