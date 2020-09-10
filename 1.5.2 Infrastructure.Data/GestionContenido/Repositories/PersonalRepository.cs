using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionContenido;
using Olimpiadas.Infrastructure.Data.Core;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Infrastructure.Data.Core.Conexion;
using Olimpiadas.Application.Dto.GestionContenido.Personal;


namespace Olimpiadas.Infrastructure.Data.GestionContenido.Repositories
{
    /// <summary>
    /// Implementa los métodos de acceso a datos del repositorio de Personales.
    /// </summary>
    public class PersonalRepository
        : Repository<Personal>, IPersonalRepository
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public PersonalRepository(IConexionBase conexionBaseDatos)
            :  base(conexionBaseDatos)
        { }

        #endregion



        #region MÉTODOS - Implementa interface IPersonalRepository


        /// <summary>
        /// Implementa método para paginar el Personal desde el orígen de datos.
        /// </summary>
        /// <param name="filtro">Filtro de la paginación.</param>
        /// <param name="criteriosPaginacion">Criterios de paginación.</param>
        /// <returns>Lista paginada de personal.</returns>
        public Paginado<PersonalDto> Paginar(PersonalDto filtro, CriteriosPaginacionDto criteriosPaginacion)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Personal_Paginar",
                ParametrosEntrada = new string[]
                {
                    Personal.Propiedad_NombrePersonal,
                    Personal.Propiedad_DniPersonal,
                    Personal.Propiedad_Activo
                }
            };
            return Paginar(parametroAccesosDatos, filtro, criteriosPaginacion);
        }


        /// <summary>
        /// Implementa método para seleccionar un personal por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idPersonal">Id del registro.</param>
        /// <returns>Personal seleccionado.</returns>
        public Personal SeleccionarPorId(int idPersonal)
        {
            ParametroAccesosDatos parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "USP_Personal_Seleccionar_PorId",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Personal.Propiedad_IdPersonal, idPersonal)
                }
            };

            return Obtener(parametroAccesosDatos);
        }


        /// <summary>
        /// Implementa método para insertar un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal a insertar.</param>
        public void Insertar(Personal Personal)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Personal_Insertar",
                ParametrosEntrada = new string[]
                {
                    Personal.Propiedad_NombrePersonal,
                    Personal.Propiedad_DniPersonal,
                    Personal.Propiedad_Activo,
                    Personal.Propiedad_FechaCreacion
                },
                PropiedadesCalculadas = new string[] { Personal.Propiedad_IdPersonal }
            };
            Ejecutar(parametroAccesosDatos, Personal);
        }

        /// <summary>
        /// Implementa método para actualizar un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal que se actualiza.</param>
        public void Actualizar(Personal Personal)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Personal_Actualizar",
                ParametrosEntrada = new string[]
                {
                    Personal.Propiedad_IdPersonal,
                    Personal.Propiedad_NombrePersonal,
                    Personal.Propiedad_DniPersonal,
                    Personal.Propiedad_Activo,
                    Personal.Propiedad_FechaModificacion
                }
            };
            Ejecutar(parametroAccesosDatos, Personal);
        }

        /// <summary>
        /// Implementa método para actualizar en campo Activo de un Personal en el orígen de datos.
        /// </summary>
        /// <param name="Personal">Datos del Personal que se actualiza.</param>
        public void ActualizarActivo(Personal Personal)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Personal_ActualizarActivo",
                ParametrosEntrada = new string[]
                {
                    Personal.Propiedad_IdPersonal,
                    Personal.Propiedad_Activo,
                    Personal.Propiedad_FechaModificacion
                }
            };
            Ejecutar(parametroAccesosDatos, Personal);
        }

        #endregion
    }
}
