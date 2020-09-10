using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Participante;
using Olimpiadas.Web.CMS.Helper;
using Olimpiadas.Web.CMS.Models;


namespace Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Participantes
{
    /// <summary>
    /// Modelo para la vista de la grid de participantes
    /// </summary>
    public class ParticipanteGridViewModel : PaginationModel<ParticipanteDto>
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ParticipanteGridViewModel()
        {
        }

        /// <summary>
        /// Constructor con valores response
        /// </summary>
        /// <param name="response">Objeto response del servicio</param>
        /// <param name="criterios">Criterios de paginación</param>
        public ParticipanteGridViewModel(ParticipantePaginacionResponseDto response, CriteriosPaginacionDto criterios)
            : base(response.Participantes, criterios, response.TotalItems, response.Opciones)
        {
            EstadosSiNo = response.EstadosSiNo.FillForHtml();
            Paises = response.Paises.FillForHtml();
            Deportes = response.Deportes.FillForHtml();
        }

        #endregion


        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public BindingList<SelectListItem> EstadosSiNo { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BindingList<SelectListItem> Paises { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BindingList<SelectListItem> Deportes { get; private set; }

        #endregion
    }
}
