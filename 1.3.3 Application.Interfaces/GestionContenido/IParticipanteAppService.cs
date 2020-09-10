using System;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Participante;


namespace Olimpiadas.Application.Interfaces.GestionContenido
{
    /// <summary>
    /// Interface con métodos para orquestar operaciones de los participantes.
    /// </summary>
    public interface IParticipanteAppService : IDisposable
    {
        /// <summary>
        /// Método orquestador para paginar las alertas.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginados.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        ParticipantePaginacionResponseDto Paginar(PaginacionRequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método orquestador para obtener los datos necesarios para el editor de participantes.(Agregar o Modificar).
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        ParticipanteEditorResponseDto ObtenerEditor(int? idParticipante);

        /// <summary>
        /// Método orquestador para insertar una Participante.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        int Insertar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método orquestador para actualizar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        void Actualizar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método orquestador para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        void Desactivar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método orquestador para activar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        void Activar(RequestDto<ParticipanteDto> request);
    }
}