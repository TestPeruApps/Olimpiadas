using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.Web.CMS.Areas.Contenido.ViewModels.Personal
{
    /// <summary>
    /// Modelo para la vista del editor de personal
    /// </summary>
    public class PersonalEditorViewModel
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public PersonalEditorViewModel()
        {
            Personal = new PersonalDto();            
        }

        /// <summary>
        /// Constructor con valores response
        /// </summary>
        /// <param name="response">Objeto response del servicio</param>
        public PersonalEditorViewModel(PersonalEditorResponseDto response)
        {
            Personal = response.Personal;
        }

        #endregion



        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public PersonalDto Personal { get; set; }

        #endregion
    }    
}