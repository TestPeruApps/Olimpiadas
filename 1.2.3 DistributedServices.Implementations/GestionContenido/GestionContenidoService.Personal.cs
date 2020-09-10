using Microsoft.Practices.Unity;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.DistributedServices.Core.Factories;
using Olimpiadas.Application.Interfaces.GestionContenido;
using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.DistributedServices.Implementations.GestionContenido
{
    /// <summary>
    /// Implementa contrato del servicio con métodos de operaciones de Personal.
    /// </summary>
    public partial class GestionContenidoService
    {
        /// <summary>
        /// Implementa método del servicio para paginar los Personals.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginadas.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        public PersonalPaginacionResponseDto PersonalPaginar(PaginacionRequestDto<PersonalDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                return service.Paginar(request);
        }

        /// <summary>
        /// Implementa método del servicio para obtener los datos necesarios para el editor de Personal.(Agregar o Modificar).
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        public PersonalEditorResponseDto PersonalObtenerEditor(int? idPersonal)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                return service.ObtenerEditor(idPersonal);
        }

        /// <summary>
        /// Implementa método del servicio para insertar una Personal.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        public int PersonalInsertar(RequestDto<PersonalDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                return service.Insertar(request);
        }

        /// <summary>
        /// Implementa método del servicio para actualizar una Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        public void PersonalActualizar(RequestDto<PersonalDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                service.Actualizar(request);
        }


        /// <summary>
        /// Implementa método del servicio para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        public void PersonalDesactivar(RequestDto<PersonalDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                service.Desactivar(request);
        }

        /// <summary>
        /// Implementa método del servicio para activar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        public void PersonalActivar(RequestDto<PersonalDto> request)
        {
            using (var service = UnityContainerFactory.GetContainer().Resolve<IPersonalAppService>())
                service.Activar(request);
        }
    }
}