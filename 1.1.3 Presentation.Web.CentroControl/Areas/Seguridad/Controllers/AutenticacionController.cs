using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

using Olimpiadas.CrossCutting.Enumerations;
using Olimpiadas.Web.CMS.Areas.Seguridad.ViewModels.Autenticacion;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.Application.Dto.Fault;


namespace Olimpiadas.Web.CMS.Areas.Seguridad.Controllers
{
    /// <summary>
    /// Métodos para controlar las interacciones desde el navegador web del formulario de autentiación.
    /// </summary>
    [Area("Seguridad"), Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public class AutenticacionController : Controller
    {
        #region VARIABLES

        /// <summary>
        /// Interface al servicio de seguridad.
        /// </summary>
        private readonly IGestionSeguridadService _gestionSeguridadService;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del controlador
        /// </summary>
        /// <param name="gestionSeguridadService">Interface al servicio de seguridad.</param>
        public AutenticacionController(IGestionSeguridadService gestionSeguridadService)
        {
            _gestionSeguridadService = gestionSeguridadService;
        }

        #endregion

        /// <summary>
        /// Método que devuelve la vista por defecto del controlador.
        /// </summary>
        /// <returns>Vista con el formulario de login</returns>
        public IActionResult Login()
        {
            var modelo = new LoginViewModel
            {
                Usuario = string.Empty,
                Contrasenia = string.Empty
            };
            return PartialView("_login", modelo);
        }

        /// <summary>
        /// Método que devuelve la vista por defecto del controlador.
        /// </summary>
        /// <param name="model">Modelo con datos del login</param>
        /// <returns>Vista con el formulario de login</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var request = new ValidarLoginRequestDto
                {
                    Login = model.Usuario,
                    Contrasenia = model.Contrasenia
                };

                //Invocamos al servicio
                var response = await _gestionSeguridadService.UsuarioValidarLoginAsync(request);

                //Iniciamos sesión
                return await IniciarSesion(response);
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }


        /// <summary>
        /// Método que genera los valores de la sesión
        /// </summary>
        /// <param name="usuario">Datos del usuario actual</param>
        /// <returns>Vista del home</returns>
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(UsuarioDto usuario)
        {
            try
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario, ClaimValueTypes.String),
                    new Claim("EmailUsuario", usuario.EmailUsuario, ClaimValueTypes.String),
                    new Claim("IdUsuario", usuario.IdUsuario.ToString(), ClaimValueTypes.String),
                    //new Claim("Usua_TipoAutenticacionId", usuario.Usua_TipoAutenticacionId.GetValueOrDefault(0).ToString(), ClaimValueTypes.String),
                };

                var userIdentity = new ClaimsIdentity("ManagementSecureLogin");
                userIdentity.AddClaims(claims);

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("PeruApps", userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.UtcNow.AddHours(8),
                        AllowRefresh = false
                    });

                return Json("/");
            }
            catch (FaultException<ServiceErrorResponseDto> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
            }
        }

        /// <summary>
        /// Método que cierra la sesión
        /// </summary>
        /// <returns>Vista del home</returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("PeruApps");
            return Redirect("/");
        }



        ///// <summary>
        ///// Método que devuelve la vista con el editor de Recuperar contraseñal del usuario.
        ///// </summary>
        ///// <param name="usuario_Email">Email del usuario.</param>
        ///// <returns>Vista con el editor del usuario.</returns>
        //[HttpGet]
        //public IActionResult EditorRecuperarContrasenia(string usua_Email)
        //{
        //    //Construimos el modelo
        //    var model = new RecuperarContraseniaViewModel();

        //    //Retornamos vista con modelo
        //    return PartialView("_EditorRecuperarContrasenia", model);
        //}

        ///// <summary>
        ///// Método que solicita enviar la contraseña de un usuario.
        ///// </summary>
        ///// <param name="usuario_Email">Email del usuario.</param>
        ///// <returns>Vista con el editor de recuperar contraseña</returns>
        //[HttpPost]
        //public async Task<IActionResult> RecuperarContrasenia(string usua_Email)
        //{
        //    try
        //    {
        //        //Invocamos al servicio
        //        await _gestionSeguridadService.UsuarioRecuperarContraseniaAsync(usua_Email);

        //        //Refrescamos la pagina con los registros actuales
        //        return Json(true);
        //        //return await Index(modelGrid);
        //    }
        //    catch (FaultException<ServiceErrorResponseDto> ex)
        //    {
        //        //Como existe excepción de lógica de negocio, lo enviamos al cliente para ser procesado por este
        //        return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message));
        //    }
        //}

    }
}