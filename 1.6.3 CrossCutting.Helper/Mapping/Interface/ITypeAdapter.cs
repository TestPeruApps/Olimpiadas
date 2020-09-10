namespace Olimpiadas.CrossCutting.Helper.Mapping.Interface
{
    /// <summary>
    /// Contrato base para realizar el mapeo de una entidad a otra. (Este contrato trabaja con automapper,emitmapper,valueinjecter...)    
    /// </summary>
    public interface ITypeAdapter
    {
        #region MÉTODOS DE AL INTERFACE

        /// <summary>
        /// Adapta el objeto orígen al objeto destino.
        /// </summary>
        /// <typeparam name="TSource">Tipo de elemnto orígen.</typeparam>
        /// <typeparam name="TTarget">Tipo de elemento destino.</typeparam>
        /// <param name="source">Instancia del adatador.</param>
        /// <returns>Mapeo del objeto orígen al objeto destino.</returns>
        TTarget Adapt<TSource, TTarget>(TSource source)
                where TTarget : class, new()
                where TSource : class;

        /// <summary>
        /// Adapta el objeto orígen a una instancia definida en TTarget.
        /// </summary>
        /// <typeparam name="TTarget">Tipo del elemento destino.</typeparam>
        /// <param name="source">Instancia del adatador.</param>
        /// <returns>Mapeo del objeto orígen al objeto destino.</returns>
        TTarget Adapt<TTarget>(object source)
                where TTarget : class, new();

        #endregion
    }
}