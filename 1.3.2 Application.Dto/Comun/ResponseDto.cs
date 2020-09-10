using System;
using System.Runtime.Serialization;

using Olimpiadas.CrossCutting.Helper.Exceptions;

namespace Olimpiadas.Application.Dto.Comun
{
    /// <summary>
    /// Clase con datos usados como response para métodos REST.
    /// </summary>
    [DataContract]
    public class ResponseDto<T> 
        where T : class, new()
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ResponseDto() { }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="data">Datos del response</param>
        public ResponseDto(T data)
        {
            //Asignamos datos del response
            Data = data;

            //Devolvemos metadata sobre el response
            Response = new DataDto { Code = "1", Message = string.Empty };
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="data">Datos del response</param>
        /// <param name="mensaje">Mesaje a devolver</param>
        public ResponseDto(T data, string mensaje)
        {
            //Asignamos datos del response
            Data = data;

            //Devolvemos metadata sobre el response
            Response = new DataDto { Code = "1", Message = mensaje };
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="exception">Excepción capturada</param>
        public ResponseDto(Exception exception)
        {
            //Asignamos mensaje de la excepción
            var mensaje = exception.InnerException != null ? exception.InnerException.Message : exception.Message;

            //Devolvemos metadata sobre la excepción
            if (exception is BusinessException)
                Response = new DataDto { Code = "2", Message = mensaje };
            else if (exception is BusinessInformation)
                Response = new DataDto { Code = "1", Message = mensaje };
            else if (exception is BusinessInformationConData<T>)
            {
                Response = new DataDto { Code = "1", Message = mensaje };
                Data = (exception as BusinessInformationConData<T>).Datos;
            }
            else if (exception is BusinessInformationPregunta<T>)
            {
                Response = new DataDto { Code = "4", Message = mensaje };
                Data = (exception as BusinessInformationPregunta<T>).Datos;
            }
            else
                Response = new DataDto { Code = "3", Message = mensaje };
        }

        /// <summary>
        /// Datos del Tipo.
        /// </summary>
        [DataMember(Name = "data")]
        public T Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "response")]
        public DataDto Response { get; set; }
    }

    /// <summary>
    /// Clase con metadatos del response
    /// </summary>
    public class DataDto
    {
        /// <summary>
        /// Indica el resultado del proceso
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Mensaje devuelto por el response
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Clase del response para devolver un void
    /// </summary>
    public class VoidDto
    {
    }
}