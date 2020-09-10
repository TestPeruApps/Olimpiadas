using System;
using System.Data.SqlClient;
using System.ServiceModel.Security;
using Olimpiadas.Application.Dto.Fault;
using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.DistributedServices.Core.Resources;

namespace Olimpiadas.DistributedServices.Core.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public ServiceErrorResponseDto ConstruirError(Exception error)
        {
            var faultDetail = new ServiceErrorResponseDto();

            if (error is SqlException)
            {
                faultDetail.Code = Fault_Code.ErrorBD;
                faultDetail.Description = error.Message;// Fault_Message.ErrorBD;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.ErrorBaseDatos;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }
            else if (error is TimeoutException)
            {
                faultDetail.Code = Fault_Code.ErrorTimeOut;
                faultDetail.Description = error.Message;// Fault_Message.ErrorTimeOut;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.ErrorTiempoConexion;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }
            else if (error is SecurityNegotiationException)
            {
                faultDetail.Code = Fault_Code.ErrorAccessDenied;
                faultDetail.Description = error.Message;// Fault_Message.ErrorAccessDenied;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.AccesoDenegado;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }
            else if (error is BusinessException)
            {
                faultDetail.Code = Fault_Code.ErrorBusinessLogic;
                faultDetail.Description = error.Message;// Fault_Message.ErrorBusinessLogic;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.ErrorNegocio;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }
            else if (error is NotImplementedException)
            {
                faultDetail.Code = Fault_Code.ErrorNotImplemented;
                faultDetail.Description = error.Message;// Fault_Message.ErrorNotImplemented;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.NoImplementado;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }
            else
            {
                faultDetail.Code = Fault_Code.ErrorUnexpected;
                faultDetail.Description = error.Message;// Fault_Message.ErrorUnexpected;
                faultDetail.Message = error.Message;
                faultDetail.Type = ServiceErrorResponseTypeDto.ErrorNoManejado;
                faultDetail.SubCode = faultDetail.Type.ToString();
            }

            return faultDetail;
        }
    }
}