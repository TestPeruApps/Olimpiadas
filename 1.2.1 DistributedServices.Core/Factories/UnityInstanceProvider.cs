using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Olimpiadas.DistributedServices.Core.Factories
{
    /// <summary>
    /// Implementa métodos para controlar la creación y el reciclaje de objetos del servicio.
    /// </summary>
    public class UnityInstanceProvider : IInstanceProvider
    {
        #region PROPIEDADES

        /// <summary>
        /// Interface contendor Unity.
        /// </summary>
        public IUnityContainer Container { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public Type ServiceType { set; get; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        public UnityInstanceProvider()
            : this(null)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public UnityInstanceProvider(Type type)
        {
            ServiceType = type;
        }

        #endregion

        #region MÉTODOS - Implementación IInstanceProvider

        /// <summary>
        /// Implementa método para devolver un objeto del servicio.
        /// </summary>
        /// <param name="instanceContext"></param>
        /// <param name="message">El mensaje que activó la creación de un objeto de servicio.</param>
        /// <returns></returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return Container.Resolve(ServiceType);
        }

        /// <summary>
        /// Implementa método para devolver un objeto del servicio.
        /// </summary>
        /// <param name="instanceContext"></param>
        /// <returns></returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Implementa método cuando un objeto de InstanceContext recicla un objeto de servicio.
        /// </summary>
        /// <param name="instanceContext"></param>
        /// <param name="instance"></param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            
        }

        #endregion
    }
}