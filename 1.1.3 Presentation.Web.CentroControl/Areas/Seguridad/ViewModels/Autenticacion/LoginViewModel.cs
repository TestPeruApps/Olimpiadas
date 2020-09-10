using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;

namespace Olimpiadas.Web.CMS.Areas.Seguridad.ViewModels.Autenticacion
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LoginViewModel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public LoginViewModel(ValidarLoginResponseDto request)
        {
            DatosLogin = request;
        }

        public string Usuario { get; set; }

        public string Contrasenia { get; set; }        

        public ValidarLoginResponseDto DatosLogin { get; set; }
    }
}