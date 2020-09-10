using System.ServiceModel;

using Olimpiadas.Application.Dto.Fault;

namespace Olimpiadas.DistributedServices.Interfaces.GestionContenido
{
    /// <summary>
    /// Contrato con métodos del servicio de la gestión de Contenido.
    /// </summary>
    [ServiceContract(
        Name = "IGestionContenidoService",
        Namespace = "PROMPERU.GestionContenidoService",
        SessionMode = SessionMode.NotAllowed)]
    public partial interface IGestionContenidoService
    {
        /// <summary>
        /// Método del servicio para realizar la prueba de conexión a este.
        /// </summary>
        /// <returns>Datos de prueba de conexión.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceErrorResponseDto))]
        string Prueba();
    }
}