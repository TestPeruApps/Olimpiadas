using System.Runtime.Serialization;

using Olimpiadas.CrossCutting.Enumerations;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con los datos que se usarán en la paginación.
    /// </summary>
    [DataContract]
    public class PaginacionRequestDto<T> where T : class, new()
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public PaginacionRequestDto()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="columnaOrdenacion"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="direccion"></param>
        public PaginacionRequestDto(T filtro, string columnaOrdenacion, int index, int size, EnumDireccionPaginacion direccion)
        {            
            CriteriosPaginacion = new CriteriosPaginacionDto
            {
                NumeroPagina = 1,
                TamanioPagina = size,
                ColumnaOrdenacion = columnaOrdenacion,
                OrdenacionDireccion = direccion
            };

            if (filtro != null)
            {
                CriteriosPaginacion.NumeroPagina = index;
                CriteriosPaginacion.TamanioPagina = size;
                CriteriosPaginacion.ColumnaOrdenacion = columnaOrdenacion;
                CriteriosPaginacion.OrdenacionDireccion = direccion;
                Filtro = filtro;
            }
            else
                Filtro = new T();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="direccion"></param>
        /// <param name="usua_Id"></param>
        public PaginacionRequestDto(T filtro, int index, int size, EnumDireccionPaginacion direccion, short usua_Id)
        {
            CriteriosPaginacion = new CriteriosPaginacionDto
            {
                NumeroPagina = 1,
                TamanioPagina = size,
                ColumnaOrdenacion = string.Empty,
                OrdenacionDireccion = direccion
            };

            if (filtro != null)
            {
                CriteriosPaginacion.NumeroPagina = index;
                CriteriosPaginacion.TamanioPagina = size;
                CriteriosPaginacion.ColumnaOrdenacion = string.Empty;
                CriteriosPaginacion.OrdenacionDireccion = direccion;
                Filtro = filtro;
            }
            else
                Filtro = new T();

            Usua_Id = usua_Id;
        }

        /// <summary>
        /// Datos con los filtros a usar en la paginación.
        /// </summary>
        [DataMember(IsRequired = true)]
        public T Filtro { get; set; }

        /// <summary>
        /// Criterios de paginación.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CriteriosPaginacionDto CriteriosPaginacion { get; set; }

        /// <summary>
        /// Id del usuario que realiza la solicitud.
        /// </summary>
        [DataMember]
        public short Usua_Id { get; set; }
    }
}