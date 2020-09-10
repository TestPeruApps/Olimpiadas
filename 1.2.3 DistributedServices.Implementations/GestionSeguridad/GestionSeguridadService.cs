using System.ServiceModel;
using System.ServiceModel.Activation;
using Olimpiadas.DistributedServices.Interfaces.GestionSeguridad;


namespace Olimpiadas.DistributedServices.Implementations.GestionSeguridad
{
    /// <summary>
    /// Implementa contrato con métodos del servicio de la gestión de seguridad.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        Namespace = "PROMPERU.GestionSeguridadService")]
    public partial class GestionSeguridadService : IGestionSeguridadService
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