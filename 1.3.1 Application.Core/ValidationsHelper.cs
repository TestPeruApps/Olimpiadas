using System;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Strings;

namespace Olimpiadas.Application.Core
{
    /// <summary>
    /// Helper para realizar validaciones de parámetros.
    /// </summary>
    internal static class ValidationsHelper
    {
        /// <summary>
        /// Método para validar los parámetros para realizar la paginación.
        /// </summary>
        /// <param name="criteriosPaginacion">Datos con los criterios de paginación.</param>
        internal static void ValidarCriteriosPaginacion(CriteriosPaginacionDto criteriosPaginacion)
        {                        
            if (criteriosPaginacion != null)
            {
                int pageIndex = criteriosPaginacion.NumeroPagina;
                int pageSize = criteriosPaginacion.TamanioPagina;
                if (pageIndex < 0) throw new ArgumentOutOfRangeException(ResourcesArgumentExceptions.CriteriosPaginacion_PageIndexMenorCero, "PageIndex");
                if (pageSize <= 0) throw new ArgumentOutOfRangeException(ResourcesArgumentExceptions.CriteriosPaginacion_PageSizeMenorCero, "PageSize");
            }
            else
            {
                throw new ArgumentNullException("criteriosPaginacion", ResourcesArgumentExceptions.ArgumentNullException);
            }
        }
    }
}
