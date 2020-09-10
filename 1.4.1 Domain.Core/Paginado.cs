using System.Collections.Generic;

namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// Clase con datos del resultado de la paginación.
    /// </summary>
    /// <typeparam name="T">Tipo de datos usado para almacenar las entidad paginadas.</typeparam>
    public class Paginado<T>
    {
        /// <summary>
        /// Inicializa una instancia de la clase.
        /// </summary>
        public Paginado()
        {
            TotalItems = 0;
            Items = new List<T>();
        }

        /// <summary>
        /// Inicializa una instancia de la clase.
        /// </summary>
        /// <param name="items">Items devueltos por la paginación.</param>
        /// <param name="totalItems">Cantidad total de items sobre el cual se realiza la paginación.</param>
        public Paginado(List<T> items, int totalItems)
        {
            TotalItems = totalItems;
            Items = items;
        }

        /// <summary>
        /// Items devueltos por la paginación.
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Cantidad total de items sobre el cual se realiza la paginación.
        /// </summary>
        public int TotalItems { get; set; }
    }
}