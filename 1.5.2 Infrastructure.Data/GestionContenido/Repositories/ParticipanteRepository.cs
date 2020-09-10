using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionContenido;
using Olimpiadas.Infrastructure.Data.Core;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Infrastructure.Data.Core.Conexion;
using Olimpiadas.Application.Dto.GestionContenido.Participante;


namespace Olimpiadas.Infrastructure.Data.GestionContenido.Repositories
{
    /// <summary>
    /// Implementa los métodos de acceso a datos del repositorio de Participantees.
    /// </summary>
    public class ParticipanteRepository
        : Repository<Participante>, IParticipanteRepository
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public ParticipanteRepository(IConexionBase conexionBaseDatos)
            :  base(conexionBaseDatos)
        { }

        #endregion

        #region MÉTODOS - Implementa interface IParticipanteRepository


        /// <summary>
        /// Implementa método para paginar los Participantes desde el orígen de datos.
        /// </summary>
        /// <param name="filtro">Filtro de la paginación.</param>
        /// <param name="criteriosPaginacion">Criterios de paginación.</param>
        /// <returns>Lista paginada de Participantees.</returns>
        public Paginado<ParticipanteDto> Paginar(ParticipanteDto filtro, CriteriosPaginacionDto criteriosPaginacion)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Participante_Paginar",
                ParametrosEntrada = new string[]
                {
                    Participante.Propiedad_NombreParticipante,
                    Participante.Propiedad_IdPais,
                    Participante.Propiedad_IdDeporte,
                    Participante.Propiedad_Activo
                }
            };
            return Paginar(parametroAccesosDatos, filtro, criteriosPaginacion);
        }


        /// <summary>
        /// Implementa método para seleccionar un participante por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idParticipante">Id del registro.</param>
        /// <returns>Participante seleccionado.</returns>
        public Participante SeleccionarPorId(int idParticipante)
        {
            ParametroAccesosDatos parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "USP_Participante_Seleccionar_PorId",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Participante.Propiedad_IdParticipante, idParticipante)
                }
            };

            return Obtener(parametroAccesosDatos);
        }


        /// <summary>
        /// Implementa método para insertar un Participante en el orígen de datos.
        /// </summary>
        /// <param name="participante">Datos del Participante a insertar.</param>
        public void Insertar(Participante participante)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Participante_Insertar",
                ParametrosEntrada = new string[]
                {
                    Participante.Propiedad_NombreParticipante,
                    Participante.Propiedad_IdPais,
                    Participante.Propiedad_IdDeporte,
                    Participante.Propiedad_Activo,
                    Participante.Propiedad_FechaCreacion
                },
                PropiedadesCalculadas = new string[] { Participante.Propiedad_IdParticipante }
            };
            Ejecutar(parametroAccesosDatos, participante);
        }

        /// <summary>
        /// Implementa método para actualizar un Participante en el orígen de datos.
        /// </summary>
        /// <param name="participante">Datos del Participante que se actualiza.</param>
        public void Actualizar(Participante participante)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Participante_Actualizar",
                ParametrosEntrada = new string[]
                {
                    Participante.Propiedad_IdParticipante,
                    Participante.Propiedad_NombreParticipante,
                    Participante.Propiedad_IdPais,
                    Participante.Propiedad_IdDeporte,
                    Participante.Propiedad_Activo,
                    Participante.Propiedad_FechaModificacion
                }
            };
            Ejecutar(parametroAccesosDatos, participante);
        }

        /// <summary>
        /// Implementa método para actualizar en campo Activo de un Participante en el orígen de datos.
        /// </summary>
        /// <param name="Participante">Datos del Participante que se actualiza.</param>
        public void ActualizarActivo(Participante Participante)
        {
            var parametroAccesosDatos = new ParametroAccesosDatosTipado
            {
                ProcedimientoAlmacenado = "USP_Participante_ActualizarActivo",
                ParametrosEntrada = new string[]
                {
                    Participante.Propiedad_IdParticipante,
                    Participante.Propiedad_Activo,
                    Participante.Propiedad_FechaModificacion
                }
            };
            Ejecutar(parametroAccesosDatos, Participante);
        }

        #endregion
    }
}
