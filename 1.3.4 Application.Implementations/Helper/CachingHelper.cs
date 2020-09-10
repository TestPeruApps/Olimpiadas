using System.Collections.Generic;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Application.Implementations.Helper
{    
    /// <summary>
    /// Helper con métodos simplificados para obtener accesos a la cache de objetos.
    /// </summary>
    static partial class CachingHelper
    {
        /// <summary>
        /// Método para obtener la lista de los estados booleanos.
        /// </summary>
        /// <returns>Lista de Estados Booleanos en una colección de pares clave-valor.</returns>
        internal static IEnumerable<ItemDto> EstadosBooleanos()
        {        
            var result = new List<ItemDto>
            {
                new ItemDto { IdTipo = "true", NombreTipo = "Activos" },
                new ItemDto { IdTipo = "false", NombreTipo = "Inactivos" }
            };

            return result;
        }        

        /// <summary>
        /// Método para obtener la lista de los estados booleanos.
        /// </summary>
        /// <returns>Lista de Estados Booleanos en una colección de pares clave-valor.</returns>
        internal static IEnumerable<ItemDto> EstadosSiNo()
        {
            var result = new List<ItemDto>
            {
                new ItemDto { IdTipo = "true", NombreTipo = "SI" },
                new ItemDto { IdTipo = "false", NombreTipo = "NO" }
            };

            return result;
        }

        /// <summary>
        /// Método para obtener la lista de los estados booleanos.
        /// </summary>
        /// <returns>Lista de Estados Booleanos en una colección de pares clave-valor.</returns>
        internal static IEnumerable<ItemDto> EstadosSiNoPendiente()
        {
            var result = new List<ItemDto>
            {
                new ItemDto { IdTipo = "", NombreTipo = "Pendiente" },
                new ItemDto { IdTipo = "true", NombreTipo = "SI" },
                new ItemDto { IdTipo = "false", NombreTipo = "NO" }
            };

            return result;
        }

        /// <summary>
        /// Método para obtener la lista de los estados booleanos.
        /// </summary>
        /// <returns>Lista de Estados Booleanos en una colección de pares clave-valor.</returns>
        internal static IEnumerable<ItemDto> EstadosSiNoPendienteTodos()
        {
            var result = new List<ItemDto>
            {                
                new ItemDto { IdTipo = "1", NombreTipo = "Pendiente" },
                new ItemDto { IdTipo = "2", NombreTipo = "SI" },
                new ItemDto { IdTipo = "3", NombreTipo = "NO" }                
            };

            return result;
        }

        /// <summary>
        /// Método para obtener la lista de meses.
        /// </summary>
        /// <returns>Lista de meses en una colección de pares clave-valor.</returns>
        internal static IEnumerable<ItemDto> Meses()
        {
            var result = new List<ItemDto>
            {
                new ItemDto { IdTipo = "01", NombreTipo = "Ene" },
                new ItemDto { IdTipo = "02", NombreTipo = "Feb" },
                new ItemDto { IdTipo = "03", NombreTipo = "Mar" },
                new ItemDto { IdTipo = "04", NombreTipo = "Abr" },
                new ItemDto { IdTipo = "05", NombreTipo = "May" },
                new ItemDto { IdTipo = "06", NombreTipo = "Jun" },
                new ItemDto { IdTipo = "07", NombreTipo = "Jul" },
                new ItemDto { IdTipo = "08", NombreTipo = "Ago" },
                new ItemDto { IdTipo = "09", NombreTipo = "Set" },
                new ItemDto { IdTipo = "10", NombreTipo = "Oct" },
                new ItemDto { IdTipo = "11", NombreTipo = "Nov" },
                new ItemDto { IdTipo = "12", NombreTipo = "Dic" }
            };

            return result;
        }
    }
}