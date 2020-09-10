using System.ServiceModel;
using Microsoft.Practices.Unity;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;

namespace Olimpiadas.DistributedServices.Core.Factories
{
    /// <summary>
    /// Implementa mecanismo para modificar o insertar las extensiones personalizadas en un servicio completo.
    /// </summary>
    public class UnityServiceBehavior : IServiceBehavior
    {
        #region VARIABLES

        /// <summary>
        /// Host del servicio
        /// </summary>
        private ServiceHost _serviceHost;

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Interface con métodos para controlar la creación y el reciclaje de objetos del servicio.
        /// </summary>
        public UnityInstanceProvider InstanceProvider { get; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public UnityServiceBehavior()
        {
            InstanceProvider = new UnityInstanceProvider();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="unity">Interface del contenedor Unity.</param>
        public UnityServiceBehavior(IUnityContainer unity)
        {
            InstanceProvider = new UnityInstanceProvider
            {
                Container = unity
            };
        }

        #endregion

        #region MÉTODOS - Implementación IServiceBehavior

        /// <summary>
        /// Implementa método para cambiar los valores de propiedad en tiempo de ejecución o insertar objetos de extensión personalizados como controladores de errores, interceptores de mensajes o de parámetros, extensiones de seguridad, y otros objetos de extensión personalizados.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        InstanceProvider.ServiceType = serviceDescription.ServiceType;
                        ed.DispatchRuntime.InstanceProvider = InstanceProvider;

                    }
                }
            }
        }

        /// <summary>
        /// Implemenat método para pasar datos personalizados a los elementos de enlace para admitir la implementación del contrato.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        { }

        /// <summary>
        /// Implementa mecamnismo para inspeccionar el host de servicio y la descripción del servicio para confirmar que el servicio puede ejecutarse correctamente.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        #endregion

        #region MÉTODOS DE APOYO

        /// <summary>
        /// Establece el servicio y agrega el comportamiento asociado al servicio.
        /// </summary>
        /// <param name="host"></param>
        public void AddToHost(ServiceHost host)
        {            
            if (_serviceHost != null) return;

            host.Description.Behaviors.Add(this);
            _serviceHost = host;
        }

        #endregion
    }
}