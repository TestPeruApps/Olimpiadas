using System;
using System.Configuration;
using System.Web;
using Framework.Log.Params;

namespace Olimpiadas.DistributedServices.Core.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class LogHelper
    {
        private readonly bool _enabledError;
        private readonly bool _enabledTrace;
        private readonly string _eventSource;
        private readonly string _logNameError;
        private readonly string _logNameTrace;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabledError"></param>
        /// <param name="enabledTrace"></param>
        /// <param name="eventSource"></param>
        /// <param name="logNameError"></param>
        /// <param name="logNameTrace"></param>
        public LogHelper(bool enabledError, bool enabledTrace, string eventSource, string logNameError, string logNameTrace)
        {
            _enabledError = enabledError;
            _enabledTrace = enabledTrace;
            _eventSource = eventSource;
            _logNameError = logNameError;
            _logNameTrace = logNameTrace;
        }

        /// <summary>
        /// 
        /// </summary>
        public LogHelper()
        {
            _enabledError = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitaLogError"]);
            _enabledTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitaLogTraza"]);
            string rutaLog = ConfigurationManager.AppSettings["CarpetaLogError"].ToString();

            if (string.IsNullOrEmpty(rutaLog))
            {
                _enabledError = false;
                _enabledTrace = false;
            }
            else
            {
                _eventSource = rutaLog;
            }

            var ruta = HttpContext.Current.Server.MapPath(@"\");
            _eventSource = ruta + @"\" + ConfigurationManager.AppSettings["CarpetaLogError"];

            _logNameTrace = ConfigurationManager.AppSettings["FormatoLogTraza"];
            _logNameError = ConfigurationManager.AppSettings["FormatoLogError"];
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="identificador"></param>
        /// <param name="ex"></param>
        public void AddError(String titulo, String identificador, Exception ex)
        {
            if (_enabledError)
            {
                var paramError = new EventParameter<String, String>
                {
                    ObjetoEnviado = string.Empty,
                    ObjetoRecibido = string.Empty,
                    ErrorMessage = titulo,
                    Identificador = identificador,
                    Exception = ex,
                    Comments = string.Empty
                };

                new LogFileError(_eventSource, _logNameError).AddError(paramError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="identificador"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void AddTrace(String titulo, String identificador, String request, String response)
        {
            if (_enabledTrace)
            {
                var paramTrace = new EventParameter<String, String>
                {
                    ObjetoEnviado = request,
                    ObjetoRecibido = response,
                    ErrorMessage = titulo,
                    Identificador = identificador,
                    Comments = string.Empty
                };

                new LogFileError(_eventSource, _logNameTrace).AddInformation(paramTrace);
            }
        }        
    }
}