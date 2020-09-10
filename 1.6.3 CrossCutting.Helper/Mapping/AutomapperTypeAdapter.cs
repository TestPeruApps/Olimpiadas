using AutoMapper;

using Olimpiadas.CrossCutting.Helper.Mapping.Interface;

namespace Olimpiadas.CrossCutting.Helper.Mapping
{    
    /// <summary>
    /// Implementa el contrato  para realizar el mapeo de una entidad a otra con AutoMapper.
    /// </summary>
    public class AutomapperTypeAdapter
        :ITypeAdapter
    {
        #region IMPLEMENTA ITypeAdapter - Métodos

        /// <summary>
        /// Implementa el método que devuelve el adapta el objeto orígen al objeto destino.
        /// </summary>
        /// <typeparam name="TSource">Tipo de elemnto orígen.</typeparam>
        /// <typeparam name="TTarget">Tipo de elemento destino.</typeparam>
        /// <param name="source">Instancia del adatador.</param>
        /// <returns>Mapeo del objeto orígen al objeto destino.</returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// Implementa el método que devuelve el adapta el objeto orígen a una instancia definida en TTarget.
        /// </summary>
        /// <typeparam name="TTarget">Tipo del elemento destino.</typeparam>
        /// <param name="source">Instancia del adatador.</param>
        /// <returns>Mapeo del objeto orígen al objeto destino.</returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion
    }
}