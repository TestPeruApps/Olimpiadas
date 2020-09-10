using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Web.CMS.Models;

namespace Olimpiadas.Web.CMS.Controllers
{
    public class HomeController : Controller
    {
        #region VARIABLES

        /// <summary>
        /// Interface al servicio de gestión de procesos genéricos
        /// </summary>
        private readonly IGestionSeguridadService _gestionSeguridadService;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del controlador
        /// </summary>
        /// <param name="gestionProductosService">Interface al servicio de gestión de procesos genéricos</param>
        public HomeController(IGestionSeguridadService gestionProductosService)
        {
            _gestionSeguridadService = gestionProductosService;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            /*
            if (id != null)
            {

                var usuario1 = new UsuarioDto();
                usuario1.Usua_Nombres = "Prueba";
                usuario1.Usua_Email = "administrador@gmail.com";
                usuario1.Usua_Id = 1;
                usuario1.Usua_TipoAutenticacionId = 1;

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario1.Usua_Nombres, ClaimValueTypes.String),
                    new Claim("Usua_Email", usuario1.Usua_Email, ClaimValueTypes.String),
                    new Claim("Usua_Id", usuario1.Usua_Id.ToString(), ClaimValueTypes.String),
                    new Claim("Usua_TipoAutenticacionId", usuario1.Usua_TipoAutenticacionId.GetValueOrDefault(0).ToString(), ClaimValueTypes.String)
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

                return Redirect("/");
            }*/

            //Invocamos al servicio
            //int? usuarioId = User.GetUsuarioId();
            var usuario = User.GetUsuario();
            if (usuario == null)
                return View();

            var request = await _gestionSeguridadService.UsuarioListarMenuAsync(usuario.Usua_Id.Value);

            //Construimos el modelo
            var model = new HomeViewModel(request);

            //Retornamos vista con modelo
            return View(model);
        }        

        public IActionResult Error()
        {
            return View();
        }
    }
}