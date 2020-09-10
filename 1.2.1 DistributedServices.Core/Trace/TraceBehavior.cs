using System;
using System.ServiceModel.Description;

namespace Olimpiadas.DistributedServices.Core.Trace
{
    /// <summary>
    /// 
    /// </summary>
    public class TraceBehavior : IEndpointBehavior
    {
        #region PROPIEDAES

        /// <summary>
        /// 
        /// </summary>
        public Boolean Enabled { get; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        public TraceBehavior()
        {
            Enabled = true;
        }

        internal TraceBehavior(bool enabled)
        {
            Enabled = enabled;
        }

        #endregion

        #region IEndpointBehavior - Implementación

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="clientRuntime"></param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new TraceInspector(Enabled));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        public void Validate(ServiceEndpoint endpoint)
        {}

        #endregion
    }
}