using System;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.CrossCutting.Strings;

namespace Olimpiadas.Application.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AppServiceBase<TEntidad>
        where TEntidad : class, new()
    {        
        /// <summary>
        /// Método para validar parámetro del request.
        /// </summary>
        /// <param name="request">Clase que se valida.</param>
        public void ValidarParametroRequest(RequestDto<TEntidad> request)
        {
            if (request == null) throw new ArgumentNullException("request", ResourcesArgumentExceptions.ArgumentNullException);
            //if (request.Auditoria == null) throw new ArgumentNullException("request.Auditoria", ResourcesArgumentExceptions.ArgumentNullException);
        }

        /// <summary>
        /// Método para validar parámetro del request.
        /// </summary>
        /// <param name="request">Clase que se valida.</param>
        public void ValidarParametroRequest<T>(RequestDto<T> request)
        {
            if (request == null) throw new ArgumentNullException("request", ResourcesArgumentExceptions.ArgumentNullException);
            //if (request.Auditoria == null) throw new ArgumentNullException("request.Auditoria", ResourcesArgumentExceptions.ArgumentNullException);
        }

        /// <summary>
        /// Método para validar el formato de la fecha
        /// </summary>
        /// <param name="fecha">Fecha que se valida.</param>
        public void ValidarFormatoFecha(string fecha)
        {
            if (fecha != null)
            {
                DateTime fechaNueva;
                if (DateTime.TryParse(fecha, out fechaNueva) == false)
                {
                    throw new BusinessException(ResourcesArgumentExceptions.Fecha_FormatoIncorrecto);
                }
            }
        }

        /// <summary>
        /// Método para validar los parámetros para realizar la paginación.
        /// </summary>
        /// <param name="request">Clase que se valida.</param>
        public static void ValidarParametrosPaginacion(PaginacionRequestDto<TEntidad> request)
        {
            if (request == null) throw new ArgumentNullException("request", ResourcesArgumentExceptions.ArgumentNullException);
            if (request.Filtro == null) throw new ArgumentNullException("request.Filtro", ResourcesArgumentExceptions.ArgumentNullException);
            //if (request.Usua_Id == 0) throw new ArgumentNullException("request.Usua_Id", ResourcesArgumentExceptions.ParámetroIncorrecto);

            ValidationsHelper.ValidarCriteriosPaginacion(request.CriteriosPaginacion);
        }

        /// <summary>
        /// Método para validar los parámetros de paginación
        /// </summary>
        /// <param name="request"></param>
        public static void ValidarParametrosPaginacion(CriteriosPaginacionDto request)
        {
            ValidationsHelper.ValidarCriteriosPaginacion(request);
        }
    }
}