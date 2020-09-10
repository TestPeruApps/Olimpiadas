using AutoMapper;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionSeguridad.Usuarios;
using Olimpiadas.Domain.Entities.GestionSeguridad;
using Olimpiadas.Domain.Entities.ValueObject;
using Olimpiadas.Domain.Entities.GestionContenido;

namespace Olimpiadas.Application.Implementations.GestionSeguridad
{
    internal class MainProfiler : Profile
    {
        protected override void Configure()
        {
            /*--------------------------------------*/

            Mapper.CreateMap<Usuario, UsuarioDto>();
            Mapper.CreateMap<UsuarioDto, Usuario>();

        }
    }
}