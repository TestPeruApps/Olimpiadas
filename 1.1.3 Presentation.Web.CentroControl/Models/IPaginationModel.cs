using Olimpiadas.CrossCutting.Enumerations;

namespace Olimpiadas.Web.CMS.Models
{
    public interface IPaginationModel
    {        
        /// <summary>
        /// Número de pagina solicitada para al paginación
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Número de pagina solicitada para al paginación
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// Cantidad de registro por página
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Nombre de la Columna por la cual debe estar ordenada la lista
        /// </summary>
        string Column { get; }

        /// <summary>
        /// Dirección (Ascendente o descendente) en base a la columna por la cual debe estar ordenada la lista
        /// </summary>
        EnumDireccionPaginacion Dir { get; }        
    }
}
