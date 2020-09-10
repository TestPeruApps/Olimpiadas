using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;

namespace Olimpiadas.Web.CMS.Areas.Seguridad.ViewModels.Usuarios
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioEditorActualizarContraseniaViewModel
    {
        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        public UsuarioEditorActualizarContraseniaViewModel()
        {
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="response"></param>
        //public UsuarioEditorActualizarContraseniaViewModel(CambiarContraseniaRequestDto response) 
        //{
        //    usuarioId = response.UsuarioId;
        //    contraseniaAnterior = response.ContraseniaAnterior;
        //    contraseniaNueva = response.ContraseniaNueva;
        //    confirmarContraseniaNueva = response.ConfirmarContraseniaNueva;
        //}

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public short usuarioId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string contraseniaAnterior { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string contraseniaNueva { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string confirmarContraseniaNueva { get; set; }

        #endregion
    }    
}