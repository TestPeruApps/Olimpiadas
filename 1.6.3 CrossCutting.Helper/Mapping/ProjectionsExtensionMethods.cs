using System;
using System.Linq;
using System.Collections.Generic;

namespace Olimpiadas.CrossCutting.Helper.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProjectionsExtensionMethods
    {       
        /// <summary>
        /// Project a type using a object
        /// </summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="item">The source entity to project</param>
        /// <returns>The projected type</returns>
        public static TProjection ProjectedAs<TProjection>(this Object item)
            where TProjection : class,new()
        {
            if (item == null) return null;
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <typeparam name="TSource">Tipo de la lista origen a convertir</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsList<TSource, TProjection>(this IEnumerable<TSource> items)
            where TProjection : class
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }        

        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<object> items)
            where TProjection : class,new()
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }                

        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this Dictionary<string, string> items)
            where TProjection : class,new()
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }       
    }
}
