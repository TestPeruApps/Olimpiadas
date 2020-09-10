using System.Collections.Generic;
using cloudscribe.Pagination.Models;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Enumerations;

namespace Olimpiadas.Web.CMS.Models
{
    public class PaginationModel<T> : IPaginationModel
    {
        public PaginationModel()
        {
            Index = 1;
            Column = string.Empty;
            Dir = EnumDireccionPaginacion.ASC;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filas"></param>
        /// <param name="criterios"></param>
        /// <param name="totalItems"></param>
        public PaginationModel(IEnumerable<T> filas, CriteriosPaginacionDto criterios, int totalItems)
        {
            Index = criterios.NumeroPagina;
            Size = criterios.TamanioPagina;
            Column = criterios.ColumnaOrdenacion;
            Dir = criterios.OrdenacionDireccion;
            TotalItems = totalItems;

            Lista = filas.ToPagedList(criterios.NumeroPagina - 1, criterios.TamanioPagina, totalItems);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filas"></param>
        /// <param name="criterios"></param>
        /// <param name="totalItems"></param>
        /// <param name="opciones"></param>
        public PaginationModel(IEnumerable<T> filas, CriteriosPaginacionDto criterios, int totalItems, List<short> opciones)
        {
            Index = criterios.NumeroPagina;
            Size = criterios.TamanioPagina;
            Column = criterios.ColumnaOrdenacion;
            Dir = criterios.OrdenacionDireccion;
            TotalItems = totalItems;

            Lista = filas.ToPagedList(criterios.NumeroPagina - 1, criterios.TamanioPagina, totalItems);

            Opciones = opciones;
        }

        /// <summary>
        /// Número de pagina solicitada para al paginación
        /// </summary>
        public T Filtro { get; set; }

        /// <summary>
        /// Lista de resultados
        /// </summary>
        public IPagedList<T> Lista { get; private set; }

        /// <summary>
        /// Número de pagina solicitada para al paginación
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Número de pagina solicitada para al paginación
        /// </summary>
        public int TotalItems { get; private set; }

        /// <summary>
        /// Cantidad de registro por página
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Nombre de la Columna por la cual debe estar ordenada la lista
        /// </summary>
        public string Column { get; private set; }

        /// <summary>
        /// Dirección (Ascendente o descendente) en base a la columna por la cual debe estar ordenada la lista
        /// </summary>
        public EnumDireccionPaginacion Dir { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<short> Opciones { get; set; }
    }
}
