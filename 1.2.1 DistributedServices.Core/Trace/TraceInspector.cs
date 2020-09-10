using System;
using System.ServiceModel.Dispatcher;

using Olimpiadas.DistributedServices.Core.Log;
using Olimpiadas.DistributedServices.Core.Resources;

namespace Olimpiadas.DistributedServices.Core.Trace
{
    /// <summary>
    /// 
    /// </summary>
    public class TraceInspector : IDispatchMessageInspector
    {
        #region VARIABLES

        private readonly String _identificador = null;
        private readonly static LogHelper LogHelper = new LogHelper();
        private string _request = string.Empty;

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        public TraceInspector(bool enabled)
        {
            _identificador = Guid.NewGuid().ToString();
            Enabled = enabled;
        }

        #endregion

        #region IDispatchMessageInspector - Implementación

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <param name="instanceContext"></param>
        /// <returns></returns>
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request,
            System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            if (Enabled && !String.IsNullOrEmpty(request.ToString()))
            {
                _request = request.ToString();
                //LogHelper.AddTrace(Messages.ServicioIncidenciaTrace, _identificador, request.ToString(), String.Empty);            
            }
            else
            {
                _request = string.Empty;
            }            
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="correlationState"></param>
        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            if (reply.IsFault && Enabled && !String.IsNullOrEmpty(reply.ToString()))
            {
                LogHelper.AddTrace(Messages.ServicioIncidenciaTrace, _identificador, _request, reply.ToString());
                //LogHelper.AddTrace(Messages.ServicioIncidenciaTrace, _identificador, String.Empty, reply.ToString());
            }                
        }

        #endregion
    }
}