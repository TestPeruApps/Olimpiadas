using AutoMapper;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Domain.Entities.GestionSeguridad;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Application.Dto.GestionContenido.Participante;
using Olimpiadas.Application.Dto.GestionContenido.Personal;

namespace Olimpiadas.Application.Implementations.GestionContenido
{
    internal class MainProfiler : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Participante, ParticipanteDto>();
            Mapper.CreateMap<ParticipanteDto, Participante>();

            Mapper.CreateMap<Personal, PersonalDto>();
            Mapper.CreateMap<PersonalDto, Personal>();
        }
    }
}