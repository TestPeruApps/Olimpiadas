using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;

namespace Olimpiadas.Web.CMS.Areas.Seguridad.ViewModels.Autenticacion
{
    /// <summary>
    /// 
    /// </summary>
    public class CambiarContraseniaViewModel
    {
        public CambiarContraseniaViewModel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        public CambiarContraseniaViewModel(UsuarioDto usuario)
        {
            Usuario = usuario;
        }

        public UsuarioDto Usuario { get; set; }

        public string ContraseniaNueva { get; set; }

        public string RepetirContrasenia { get; set; }
    }
}