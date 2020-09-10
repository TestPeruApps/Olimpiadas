using System.Linq;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Olimpiadas.DistributedServices.Core.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorBehavior : IServiceBehavior
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        internal ErrorBehavior(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Proporciona la capacidad de inspeccionar el host de servicio y la descripción del servicio para confirmar que el servicio puede ejecutarse correctamente.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Proporciona la capacidad de pasar datos personalizados a los elementos de enlace para admitir la implementación del contrato.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Proporciona la capacidad de cambixar los valores de propiedad en tiempo de ejecución o insertar objetos de extensión personalizados como controladores de errores, interceptores de mensajes o de parámetros, extensiones de seguridad, y otros objetos de extensión personalizados.
        /// </summary>
        /// <param name="serviceDescription">La descripción del servicio.</param>
        /// <param name="serviceHostBase">El host que se está compilando actualmente.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                channelDispatcher.ErrorHandlers.Add(new ErrorHandler(Enabled));
            }
        }
    }
}
