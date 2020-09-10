using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Personal;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Web.CMS.Models;


namespace Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Personal
{
    /// <summary>
    /// Modelo para la vista de la grid de personal
    /// </summary>
    public class PersonalGridViewModel : PaginationModel<PersonalDto>
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public PersonalGridViewModel()
        {
        }

        /// <summary>
        /// Constructor con valores response
        /// </summary>
        /// <param name="response">Objeto response del servicio</param>
        /// <param name="criterios">Criterios de paginación</param>
        public PersonalGridViewModel(PersonalPaginacionResponseDto response, CriteriosPaginacionDto criterios)
            : base(response.Personal, criterios, response.TotalItems, response.Opciones)
        {
            EstadosSiNo = response.EstadosSiNo.FillForHtml();
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public BindingList<SelectListItem> EstadosSiNo { get; private set; }

        #endregion
    }
}
