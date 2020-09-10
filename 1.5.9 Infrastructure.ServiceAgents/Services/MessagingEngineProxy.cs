using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Helper.Mapping;
using Olimpiadas.Domain.Entities.Resources;
using Olimpiadas.Domain.Entities.ValueObject;
using Olimpiadas.Domain.Modulos.ServiceAgents;
using Olimpiadas.Infrastructure.ServiceAgents.Proxy.MessagingEngine;

namespace Olimpiadas.Infrastructure.ServiceAgents.Services
{
    public partial class MessagingEngineProxy : IMessagingEngineProxy, IDisposable
    {
        /// <summary>
        /// Implementa método que solicita el envío de un mensaje de correo electrónico usando los parámetros especificados
        /// </summary>
        /// <param name="request">Datos de mensaje que se envía</param>
        /// <returns>validación de envío correcto</returns>
        public bool EnviarMensaje(MensajeRequestDto request)
        {
            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var destinatarios = request.Destinatarios.ProjectedAsCollection<Destino>();
                    destinatarios.ForEach(d => d.TipoDestinoEmail = EnumTipoDestinoEmail.PARA);

                    var mensaje = new Mensaje
                    {
                        Mens_Asunto = request.Asunto,
                        Mens_Cuerpo = request.Cuerpo,
                        Destinatarios = destinatarios,
                        Mens_Manual = request.Manual,
                        Mens_DestinatariosIds = request.DestinatariosIds
                    };

                    var envio = proxy.MensajeEnviar(mensaje);
                    if (envio.MensajeError != null && envio.MensajeError != string.Empty)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
                    }
                }
                return true;
            }
            catch
            {
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
            }
        }

        /// <summary>
        /// Implementa método que solicita el reenvío de un mensaje de correo electrónico usando los parámetros especificados
        /// </summary>
        /// <param name="request">Datos de mensaje que se envía</param>
        /// <returns>validación de envío correcto</returns>
        public bool ReenviarMensaje(MensajeRequestDto request)
        {
            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var destinatarios = request.Destinatarios.ProjectedAsCollection<Destino>();
                    destinatarios.ForEach(d => d.TipoDestinoEmail = EnumTipoDestinoEmail.PARA);

                    var mensaje = new Mensaje
                    {
                        Mens_Id = request.Id,
                        Mens_Asunto = request.Asunto,
                        Mens_Cuerpo = request.Cuerpo,
                        Destinatarios = destinatarios,
                        Mens_Manual = request.Manual,
                        Mens_DestinatariosIds = request.DestinatariosIds
                    };

                    var envio = proxy.MensajeReenviar(mensaje);
                    if (envio.MensajeError != null && envio.MensajeError != string.Empty)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
                    }
                }
                return true;
            }
            catch
            {
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
            }
        }

        /// <summary>
        /// Implementa método que solicita el envío de un mensaje de correo electrónico con un sólo destinatario
        /// </summary>
        /// <param name="request">Datos de mensaje que se envía</param>
        /// <returns>validación de envío correcto</returns>
        public bool EnviarMensajeUnDestinatario(MensajeRequestDto request)
        {
            var destinatarios = new List<Destino>
            {
                new Destino { TipoDestinoEmail = EnumTipoDestinoEmail.PARA, Dest_Email = request.Destinatario }
            };

            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var mensaje = new Mensaje
                    {
                        Mens_Asunto = request.Asunto,
                        Mens_Cuerpo = request.Cuerpo,
                        Destinatarios = destinatarios,
                        Mens_Manual = request.Manual,
                        Mens_UsuarioCreacion = request.UsuarioCreacion,
                        Mens_DestinatariosIds = request.DestinatariosIds??string.Empty
                    };

                    MensajeRespuesta envio = proxy.MensajeEnviar(mensaje);
                    if (envio.MensajeError != null && envio.MensajeError != string.Empty)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
                    }
                }
                return true;
            }
            catch
            {
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
            }
        }

        /// <summary>
        /// Implementa método que solicita el envío de un mensaje de correo electrónico con un sólo destinatario sin capturar el error del servicio de mensajería
        /// </summary>
        /// <param name="request">Datos de mensaje que se envía</param>
        /// <returns>validación de envío correcto</returns>
        public MensajeEnvioVob EnviarMensajeUnDestinatarioSinCapturarError(MensajeRequestDto request)
        {
            var destinatarios = new List<Destino>
            {
                new Destino { TipoDestinoEmail = EnumTipoDestinoEmail.PARA, Dest_Email = request.Destinatario }
            };

            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var mensaje = new Mensaje
                    {
                        Mens_Asunto = request.Asunto,
                        Mens_Cuerpo = request.Cuerpo,
                        Destinatarios = destinatarios,
                        Mens_Manual = request.Manual,
                        Mens_UsuarioCreacion = request.UsuarioCreacion,
                        Mens_DestinatariosIds = request.DestinatariosIds ?? string.Empty
                    };

                    MensajeRespuesta respuesta = proxy.MensajeEnviar(mensaje);
                    return respuesta.ProjectedAs<MensajeEnvioVob>();
                }
            }
            catch
            {
                return new MensajeEnvioVob { Enviado = false };
            }
        }

        /// <summary>
        /// Implementa método que solicita la prueba de un mensaje de correo electrónico
        /// </summary>
        /// <param name="request">Datos del mensaje que se prueba</param>
        /// <returns>validación de envío correcto</returns>
        public bool ProbarMensaje(MensajeRequestDto request)
        {
            var destinatarios = new List<Destino>
            {
                new Destino { TipoDestinoEmail = EnumTipoDestinoEmail.PARA, Dest_Email = request.Destinatario }
            };

            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var mensaje = new Mensaje
                    {
                        Mens_Asunto = request.Asunto,
                        Mens_Cuerpo = request.Cuerpo,
                        Destinatarios = destinatarios
                    };

                    var envio = proxy.MensajeProbar(mensaje);
                    if (envio.MensajeError != null && envio.MensajeError != string.Empty)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_MensajeNoEnviado);
            }
        }

        /// <summary>
        /// Implmenta método que solicita la prueba de una notificación push
        /// </summary>
        /// <param name="pushVob">Datos de la notificación que se prueba</param>
        public void EnviarNotificacionPush(PushVob pushVob)
        {
            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    Push push = pushVob.ProjectedAs<Push>();
                    var respuesta = proxy.ProbarNotificacionPush(push);
                    if (respuesta.MensajeError != null && respuesta.MensajeError != string.Empty)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_PushNoEnviado);
                    }
                }
            }
            catch
            {
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Turista_PushNoEnviado);
            }
        }

        /// <summary>
        /// Implementa método que solicita la sincronización de ofertas desde YTQP
        /// </summary>
        /// <param name="usuarioCreacion">Id. del usuario de creación</param>
        /// <param name="ipCreacion">Ip. del usuario de creación</param>
        /// <returns></returns>
        public void SincronizarOfertas(short usuarioCreacion, string ipCreacion)
        {
            try
            {
                using (var proxy = new MessagingEngineClient())
                {
                    var resultado = proxy.SincronizarOfertasManual(usuarioCreacion, ipCreacion);
                    if (!resultado.Exitoso)
                    {
                        throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Oferta_ProcesoFallido);
                    }
                }
            }
            catch
            {
                throw new CrossCutting.Helper.Exceptions.BusinessException(Messages.Oferta_ProcesoFallido);
            }
}


        public void Dispose()
        {

        }
    }
}