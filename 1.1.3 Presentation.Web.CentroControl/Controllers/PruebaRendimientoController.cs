using Microsoft.AspNetCore.Mvc;

namespace Olimpiadas.Web.CMS.Controllers
{
    public class PruebaRendimientoController : Controller
    {
        #region VARIABLES


        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del controlador
        /// </summary>
        public PruebaRendimientoController()
        {
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Retornamos vista con modelo
            return View();
        }        
    }
}