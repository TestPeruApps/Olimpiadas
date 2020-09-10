using System.ServiceModel;
using Olimpiadas.Application.Dto.Fault;


namespace Olimpiadas.DistributedServices.Interfaces.GestionSeguridad
{
    /// <summary>
    /// Contrato con métodos del servicio de la gestión de  Seguridad.
    /// </summary>
    [ServiceContract(
        Name = "IGestionSeguridadService",
        Namespace = "PROMPERU.GestionSeguridadService",
        SessionMode = SessionMode.NotAllowed)]
    public partial interface IGestionSeguridadService
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