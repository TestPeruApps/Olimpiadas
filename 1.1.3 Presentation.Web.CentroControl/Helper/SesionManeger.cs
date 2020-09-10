using System.Security.Claims;
using System.Security.Principal;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;


namespace Olimpiadas.Web.CMS.Helper
{
    public static class SesionManeger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static EjecutorDto GetUsuario(this IPrincipal user)
        {            
            var claimsIdentity = ((ClaimsIdentity)user.Identity);

            var nombreUsuario = claimsIdentity.Name;
            var emailUsuario = claimsIdentity.FindFirst("EmailUsuario");
            var idUsuario = claimsIdentity.FindFirst("IdUsuario");
            //var usua_TipoAutenticacionId = claimsIdentity.FindFirst("Usua_TipoAutenticacionId");

            if (emailUsuario != null)
                return new EjecutorDto
                {
                    Usua_Id = short.Parse(idUsuario.Value),
                    Usua_Email = emailUsuario.Value,
                    Usua_Nombres = nombreUsuario,
                    //Usua_TipoAutenticacionId = short.Parse(usua_TipoAutenticacionId.Value)
                };
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static short? GetUsuarioId(this IPrincipal user)
        {
            var claimsIdentity = ((ClaimsIdentity)user.Identity);
            var idUsuario = claimsIdentity.FindFirst("IdUsuario");

            if (idUsuario != null)
                return  short.Parse(idUsuario.Value);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static short GetUsuarioIdOrDefault(this IPrincipal user)
        {
            var claimsIdentity = ((ClaimsIdentity)user.Identity);
            var idUsuario = claimsIdentity.FindFirst("IdUsuario");

            if (idUsuario != null)
                return short.Parse(idUsuario.Value);
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static AuditoriaDto GetAuditoria(this IPrincipal user)
        {
            var claimsIdentity = ((ClaimsIdentity)user.Identity);
            var idUsuario = claimsIdentity.FindFirst("IdUsuario");

            return new AuditoriaDto
            {
                IdUsuario = short.Parse(idUsuario.Value),
                Ip = "127.0.0.1"
            };
        }
    }
}