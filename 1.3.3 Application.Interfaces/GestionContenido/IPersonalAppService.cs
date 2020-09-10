using System;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.Application.Interfaces.GestionContenido
{
    /// <summary>
    /// Interface con métodos para orquestar operaciones del personal.
    /// </summary>
    public interface IPersonalAppService : IDisposable
    {
        /// <summary>
        /// Implementa método orquestador para paginar el Personal.
        /// </summary>
        /// <param name="request">Datos para obtener las alertas paginados.</param>
        /// <returns>Datos con la paginación de alertas.</returns>
        PersonalPaginacionResponseDto Paginar(PaginacionRequestDto<PersonalDto> request);

        /// <summary>
        /// Método orquestador para obtener los datos necesarios para el editor de Personals.(Agregar o Modificar).
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Datos para mostrar el editor.</returns>
        PersonalEditorResponseDto ObtenerEditor(int? idPersonal);

        /// <summary>
        /// Método orquestador para insertar una Personal.
        /// </summary>
        /// <param name="request">Datos que se insertan.</param>
        /// <returns>Identificador del registro insertado.</returns>
        int Insertar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método orquestador para actualizar una Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se actualiza.</param>        
        void Actualizar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método orquestador para desactivar un registro.
        /// </summary>
        /// <param name="request">Datos del registro que se desactiva.</param>
        void Desactivar(RequestDto<PersonalDto> request);

        /// <summary>
        /// Método orquestador para activar una Personal.
        /// </summary>
        /// <param name="request">Datos del registro que se activa.</param>
        void Activar(RequestDto<PersonalDto> request);
    }
}