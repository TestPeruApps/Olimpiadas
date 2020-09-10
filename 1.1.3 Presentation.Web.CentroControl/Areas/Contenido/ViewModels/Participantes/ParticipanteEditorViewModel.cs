using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olimpiadas.Application.Dto.GestionContenido.Participante;
using Olimpiadas.Web.CMS.Helper;


namespace Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Participantes
{
    /// <summary>
    /// Modelo para la vista del editor de participantes
    /// </summary>
    public class ParticipanteEditorViewModel
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ParticipanteEditorViewModel()
        {
            Participante = new ParticipanteDto();            
        }

        /// <summary>
        /// Constructor con valores response
        /// </summary>
        /// <param name="response">Objeto response del servicio</param>
        public ParticipanteEditorViewModel(ParticipanteEditorResponseDto response)
        {
            Participante = response.Participante;
            Paises = response.Paises.FillForHtml();
            Deportes = response.Deportes.FillForHtml();
        }

        #endregion



        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public ParticipanteDto Participante { get; set; }

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