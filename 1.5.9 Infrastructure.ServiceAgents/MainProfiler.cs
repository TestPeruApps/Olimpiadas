using AutoMapper;
using Olimpiadas.Application.Dto.GestionNotificacion.Mensaje;
using Olimpiadas.Domain.Entities.ValueObject;
using Olimpiadas.Infrastructure.ServiceAgents.Proxy.MessagingEngine;

namespace Olimpiadas.Infrastructure.ServiceAgents
{
    internal class MainProfiler : Profile
    {
        protected override void Configure()
        {
            /*--------------------------------------*/
            Mapper.CreateMap<string, Destino>()
                .ForMember(d=>d.Dest_Email, mc => mc.MapFrom(s => s));

            /*--------------------------------------*/
            Mapper.CreateMap<PushVob, Push>();
            Mapper.CreateMap<Push, PushVob>();

            /*--------------------------------------*/
            Mapper.CreateMap<MensajeEnvioVob, MensajeRespuesta>();
            Mapper.CreateMap<MensajeRespuesta, MensajeEnvioVob>();
            
        }
    }
}
