using System.ServiceModel;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.Application.Dto.GestionContenido.Participante;


namespace Olimpiadas.DistributedServices.Interfaces.GestionContenido
{
    /// <summary>
    /// Contrato del servicio con métodos de operaciones de Participantes.
    /// </summary>
    public partial interface IGestionContenidoService
    {
        /// <summary>
        /// Método del servicio para paginar los participantes.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginadas.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        ParticipantePaginacionResponseDto ParticipantePaginar(PaginacionRequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método del servicio para obtener los datos necesarios para el editor de participantes.(Agregar o Modificar).
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        ParticipanteEditorResponseDto ParticipanteObtenerEditor(int? idParticipante);


        /// <summary>
        /// Método del servicio para insertar una Participante.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        int ParticipanteInsertar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método del servicio para actualizar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void ParticipanteActualizar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método del servicio para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void ParticipanteDesactivar(RequestDto<ParticipanteDto> request);

        /// <summary>
        /// Método del servicio para activar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void ParticipanteActivar(RequestDto<ParticipanteDto> request);
    }
}