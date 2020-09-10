using System;
using System.Data.SqlClient;

using Olimpiadas.CrossCutting.Strings;

using Framework.Log;
using Framework.Log.Info;
using Framework.Log.Interfaces;
using Framework.Log.Params;

namespace Olimpiadas.DistributedServices.Core.Log
{
    internal class LogFileError
    {
        private static string FORMATO_FECHA = ResourcesFormatos.FechaLog;
        private readonly static IFactoryLogManager logFactory = FactoryLog.Create(LogType.FileSystem);

        private readonly string _eventSource;
        private readonly string _logName;

        public LogFileError(string eventSource, string logName)
        {
            _eventSource = eventSource;
            _logName = logName;
        }

        public void AddInformation<T, R>(EventParameter<T, R> param)
        {
            if (param == null)
            {
                throw new ArgumentNullException("param");
            }

            ILogManager manager = logFactory.CreateLogManager();
            manager.LogRepository = logFactory.CreateLogRepository();

            manager.LogRepository.Data = new LogData()
            {
                NombreLog = String.Format(_logName, DateTime.Now.ToString(FORMATO_FECHA)),
                Origen = _eventSource
            };

            param.Category = 0;

            param.Actions = "";
            param.Details = "";
            param.EventId = param.EventId;
            param.EventType = EventType.Information;

            if (String.IsNullOrWhiteSpace(param.Identificador))
                param.Identificador = "";

            if (String.IsNullOrWhiteSpace(param.Comments))
                param.Comments = "";

            manager.InformationHandler<T, R>(param);
        }

        public void AddError<T, R>(EventParameter<T, R> param)
        {            
            if (param == null)
            {
                throw new ArgumentNullException("param");
            }

            ILogManager manager = logFactory.CreateLogManager();
            manager.LogRepository = logFactory.CreateLogRepository();

            manager.LogRepository.Data = new LogData()
            {
                NombreLog = String.Format(_logName, DateTime.Now.ToString(FORMATO_FECHA)),
                Origen = _eventSource
            };

            param.Category = 0;

            if (String.IsNullOrWhiteSpace(param.Identificador))
                param.Identificador = "";

            if (param.Exception.GetType() == typeof(SqlException))
            {
                param.Actions = "";
                param.Details = "";
                param.EventId = EventId.ErrorConexionBd;
                param.EventType = EventType.Error;
                param.Comments = "";

                manager.ExceptionHandler<T, R, SqlException>(
                    param,
                    (SqlException)param.Exception,
                    new GetSqlErrorInformation());
            }
            else if (param.Exception.GetType() == typeof(TimeoutException))
            {
                param.Actions = "";
                param.Details = "";
                param.EventId = EventId.ErrorTimeOut;
                param.EventType = EventType.Error;
                param.Comments = "";

                manager.ExceptionHandler<T, R, TimeoutException>(
                    param,
                    (TimeoutException)param.Exception,
                    new GetTimeOutErrorInformation());
            }
            else
            {
                param.Actions = "";
                param.Details = "";
                param.EventId = EventId.ErrorDesconocido;
                param.EventType = EventType.Error;
                param.Comments = "";

                manager.ExceptionHandler<T, R, Exception>(
                    param,
                    param.Exception,
                    new GetUnknowErrorInformation());
            }
        }
    }
}