using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.DistributedServices.Core.Log;
using Olimpiadas.DistributedServices.Core.Resources;

namespace Olimpiadas.DistributedServices.Core.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorHandler : IErrorHandler
    {
        #region VARIABLES

        private readonly static LogHelper logHelper = new LogHelper();

        private readonly string _identificador;

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
        public ErrorHandler(bool enabled)
        {
            Enabled = enabled;
            _identificador = Guid.NewGuid().ToString();
        }

        #endregion

        #region MÉTODOS NUEVOS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool HandleError(Exception error)
        {
            if (Enabled && !(error is BusinessException))
            {
                //LOG ERROR
                logHelper.AddError(Messages.Message_error, _identificador, error);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException) return;

            var faultDetail = new ErrorHelper().ConstruirError(error);

            var faultType = typeof(FaultException<>).MakeGenericType(faultDetail.GetType());
            var faultReason = new FaultReason(faultDetail.Description);
            var faultCode = FaultCode.CreateReceiverFaultCode(new FaultCode(faultDetail.SubCode));
            var faultException = (FaultException)Activator.CreateInstance(faultType, faultDetail, faultReason, faultCode);
            MessageFault faultMessage = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, faultMessage, faultException.Action);
        }

        #endregion
    }
}