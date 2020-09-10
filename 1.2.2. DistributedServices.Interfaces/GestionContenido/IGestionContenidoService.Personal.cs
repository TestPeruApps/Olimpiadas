using System.ServiceModel;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.DistributedServices.Interfaces.GestionContenido
{
    /// <summary>
    /// Contrato del servicio con métodos de operaciones de Personal.
    /// </summary>
    public partial interface IGestionContenidoService
    {
        /// <summary>
        /// Método del servicio para paginar el Personal.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginadas.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        PersonalPaginacionResponseDto PersonalPaginar(PaginacionRequestDto<PersonalDto> request);

        /// <summary>
        /// Método del servicio para obtener los datos necesarios para el editor de Personal.(Agregar o Modificar).
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        PersonalEditorResponseDto PersonalObtenerEditor(int? idPersonal);


        /// <summary>
        /// Método del servicio para insertar un Personal.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        int PersonalInsertar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método del servicio para actualizar un Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void PersonalActualizar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método del servicio para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void PersonalDesactivar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método del servicio para activar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        void PersonalActivar(RequestDto<PersonalDto> request);
    }
}