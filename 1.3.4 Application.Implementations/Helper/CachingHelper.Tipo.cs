using System.Collections.Generic;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Helper.Caching;
using Olimpiadas.CrossCutting.Strings;
using Olimpiadas.Domain.Modulos.GestionContenido;


namespace Olimpiadas.Application.Implementations.Helper
{
    /// <summary>
    /// Helper con métodos simplificados para obtener accesos a la cache de objetos.
    /// </summary>
    static partial class CachingHelper
    {
        /// <summary>
        /// Método para obtener de la cache de objetos la lista de Tipos activos.
        /// </summary>
        /// <param name="cache">Interface con métodos para realizar operaciones en la cache de objetos.</param>
        /// <param name="tipoRepository">Interface con métodos del repositorio de Tipos.</param>
        /// <param name="grupoId">Id del grupo.</param>
        /// <returns>Lista de Tipos en una colección de pares clave-valor.</returns>
        internal static List<ItemDto> ListarTiposActivosPorGrupo(ICache cache, ITipoRepository tipoRepository, byte grupoId)
        {
            string keyCache = string.Format(KeyCache.TiposActivosPorGrupo, grupoId.ToString());
            return cache.ResolveList<byte, ItemDto>(keyCache, tipoRepository.ListarActivosParaCachePorGrupo, grupoId);
        }
    }
}