using System;
using Microsoft.Practices.Unity;
using System.ServiceModel;

namespace Olimpiadas.DistributedServices.Core.Factories
{
    /// <summary>
    /// Proporciona un host para los servicios Unity.
    /// </summary>
    public class UnityServiceHost : ServiceHost
    {
        #region PROPIEDADES

        /// <summary>
        /// Interface del contenedor Unity.
        /// </summary>
        public IUnityContainer Container { set; get; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public UnityServiceHost()
            : base()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase con el tipo de servicio y las direcciones base especificadas.
        /// </summary>
        /// <param name="serviceType">Tipo de servicio que se crea.</param>
        /// <param name="baseAddresses">Dirección base específica.</param>
        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// Se invoca durante la transición de un objeto de comunicación al estado de abriendo.
        /// </summary>
        protected override void OnOpening()
        {
            new UnityServiceBehavior(Container).AddToHost(this);
            base.OnOpening();
        }

        #endregion
    }
}