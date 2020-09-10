using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Participante;


namespace Olimpiadas.Domain.Modulos.GestionContenido
{
    /// <summary>
    /// Interface con los métodos de acceso a datos del repositorio de participantes.
    /// </summary>
    public interface IParticipanteRepository : IRepository<Participante>
    {
        /// <summary>
        /// Método para paginar los avatars desde el orígen de datos.
        /// </summary>
        /// <param name="filtro">Filtro de la paginación.</param>
        /// <param name="criteriosPaginacion">Criterios de paginación.</param>
        /// <returns>Lista paginada de avatares.</returns>
        Paginado<ParticipanteDto> Paginar(ParticipanteDto filtro, CriteriosPaginacionDto criteriosPaginacion);

        /// <summary>
        /// Método para seleccionar un participante por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Participante seleccionado.</returns>
        Participante SeleccionarPorId(int idParticipante);

        /// <summary>
        /// Método para insertar un Participante en el orígen de datos.
        /// </summary>
        /// <param name="participante">Datos del Participante a insertar.</param>
        void Insertar(Participante participante);

        /// <summary>
        /// Método para actualizar un Participante en el orígen de datos.
        /// </summary>
        /// <param name="participante">Datos del Participante que se actualiza.</param>
        void Actualizar(Participante participante);

        /// <summary>
        /// Método para actualizar en campo Activo de un Participante en el orígen de datos.
        /// </summary>
        /// <param name="Participante">Datos del Participante que se actualiza.</param>
        void ActualizarActivo(Participante Participante);
    }
}