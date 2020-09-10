using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.Domain.Modulos.GestionContenido
{
    /// <summary>
    /// Interface con los métodos de acceso a datos del repositorio de personal.
    /// </summary>
    public interface IPersonalRepository : IRepository<Personal>
    {
        /// <summary>
        /// Método para paginar los avatars desde el orígen de datos.
        /// </summary>
        /// <param name="filtro">Filtro de la paginación.</param>
        /// <param name="criteriosPaginacion">Criterios de paginación.</param>
        /// <returns>Lista paginada de personal.</returns>
        Paginado<PersonalDto> Paginar(PersonalDto filtro, CriteriosPaginacionDto criteriosPaginacion);

        /// <summary>
        /// Método para seleccionar un Personal por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Personal seleccionado.</returns>
        Personal SeleccionarPorId(int idPersonal);

        /// <summary>
        /// Método para insertar un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal a insertar.</param>
        void Insertar(Personal Personal);

        /// <summary>
        /// Método para actualizar un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal que se actualiza.</param>
        void Actualizar(Personal Personal);

        /// <summary>
        /// Método para actualizar en campo Activo de un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal que se actualiza.</param>
        void ActualizarActivo(Personal Personal);
    }
}