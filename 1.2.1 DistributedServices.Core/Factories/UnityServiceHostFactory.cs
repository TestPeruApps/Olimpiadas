using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Olimpiadas.DistributedServices.Core.Factories
{
    /// <summary>
    /// Generador de instancias UnityServiceHost que se crean dinámicamente como respuesta a los mensajes entrantes.
    /// </summary>
    public class UnityServiceHostFactory : ServiceHostFactory    
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public UnityServiceHostFactory()
        {
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// Crea un UnityServiceHostFactory para una tipo especificado con una dirección base concreta.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="baseAddresses"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var host = new UnityServiceHost(serviceType, baseAddresses)
            {
                Container = UnityContainerFactory.GetContainer()
            };
            
            return host;
        }

        #endregion
    }
}