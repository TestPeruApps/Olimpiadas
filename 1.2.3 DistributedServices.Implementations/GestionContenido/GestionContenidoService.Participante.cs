using Microsoft.Practices.Unity;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.DistributedServices.Core.Factories;
using Olimpiadas.Application.Interfaces.GestionContenido;
using Olimpiadas.Application.Dto.GestionContenido.Participante;


namespace Olimpiadas.DistributedServices.Implementations.GestionContenido
{
    /// <summary>
    /// Implementa contrato del servicio con métodos de operaciones de Participantes.
    /// </summary>
    public partial class GestionContenidoService
    {
        /// <summary>
        /// Implementa método del servicio para paginar los participantes.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginadas.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        public ParticipantePaginacionResponseDto ParticipantePaginar(PaginacionRequestDto<ParticipanteDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                return service.Paginar(request);
        }

        /// <summary>
        /// Implementa método del servicio para obtener los datos necesarios para el editor de participantes.(Agregar o Modificar).
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        public ParticipanteEditorResponseDto ParticipanteObtenerEditor(int? idParticipante)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                return service.ObtenerEditor(idParticipante);
        }

        /// <summary>
        /// Implementa método del servicio para insertar una Participante.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        public int ParticipanteInsertar(RequestDto<ParticipanteDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                return service.Insertar(request);
        }

        /// <summary>
        /// Implementa método del servicio para actualizar una Participante.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        public void ParticipanteActualizar(RequestDto<ParticipanteDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                service.Actualizar(request);
        }


        /// <summary>
        /// Implementa método del servicio para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        public void ParticipanteDesactivar(RequestDto<ParticipanteDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                service.Desactivar(request);
        }

        /// <summary>
        /// Implementa método del servicio para activar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        public void ParticipanteActivar(RequestDto<ParticipanteDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IParticipanteAppService>())
                service.Activar(request);
        }
    }
}