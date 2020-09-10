using System.Collections.Generic;
using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Application.Dto.Comun;


namespace Olimpiadas.Domain.Modulos.GestionContenido
{
    /// <summary>
    /// Interface con los métodos de acceso a datos del repositorio de tipos.
    /// </summary>
    public interface ITipoRepository : IRepository<Tipo>
    {
        /// <summary>
        /// Método para cargar la cache con el listado de los tipos activos de un grupo desde el orígen de datos.
        /// </summary>
        /// <param name="tipo_grupoId">Id del grupo.</param>
        /// <returns>Lista de tipos.</returns>
        List<ItemDto> ListarActivosParaCachePorGrupo(byte tipo_grupoId);

        /// <summary>
        /// Método para seleccionar un tipo por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="tipo_Id">Id de tipo.</param>
        /// <returns>Tipo seleccionado.</returns>
        Tipo SeleccionarPorId(short tipo_Id);
    }
}