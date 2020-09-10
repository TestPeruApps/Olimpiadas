using System.ServiceModel;
using System.ServiceModel.Activation;
using Olimpiadas.DistributedServices.Interfaces.GestionContenido;


namespace Olimpiadas.DistributedServices.Implementations.GestionContenido
{
    /// <summary>
    /// Implementa contrato con métodos del servicio de la gestión de contenido.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        Namespace = "PROMPERU.GestionContenidoService")]
    public partial class GestionContenidoService : IGestionContenidoService
    {
        /// <summary>
        /// Implementa método del servicio para realizar la prueba de conexión a este.
        /// </summary>
        /// <returns>Datos de prueba de conexión.</returns>
        public string Prueba()
        {
            return "ok";
        }
    }
}