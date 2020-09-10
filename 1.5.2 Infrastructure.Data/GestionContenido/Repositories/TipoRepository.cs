using System.Collections.Generic;

using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionContenido;
using Olimpiadas.Domain.Modulos.GestionContenido;
using Olimpiadas.Infrastructure.Data.Core;
using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.Infrastructure.Data.Core.Conexion;


namespace Olimpiadas.Infrastructure.Data.GestionContenido.Repositories
{
    /// <summary>
    /// Implementa los métodos de acceso a datos del repositorio de tipos.
    /// </summary>
    public class TipoRepository
        : Repository<Tipo>, ITipoRepository
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public TipoRepository(IConexionBase conexionBaseDatos)
            :  base(conexionBaseDatos)
        { }

        #endregion

        #region MÉTODOS - Implementa interface TipoRepository

        /// <summary>
        /// Implementa método para cargar la cache con el listado de los tipos activos de un grupo desde el orígen de datos.
        /// </summary>
        /// <param name="idGrupo">Id del grupo.</param>
        /// <returns>Lista de tipos.</returns>
        public List<ItemDto> ListarActivosParaCachePorGrupo(byte idGrupo)
        {
            var parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "USP_Tipo_Listar_ActivosPorIdGrupoParaCache",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Tipo.Propiedad_IdGrupo, idGrupo)
                }
            };

            return Listar<ItemDto>(parametroAccesosDatos);
        }

        /// <summary>
        /// Implementa método para seleccionar un tipo por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="tipo_Id">Id de tipo.</param>
        /// <returns>Tipo seleccionado.</returns>
        public Tipo SeleccionarPorId(short tipo_Id)
        {
            ParametroAccesosDatos parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "COMPARTIDO.USP_Tipo_SEL_PorId",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Tipo.Propiedad_IdTipo, tipo_Id)
                }
            };

            return Obtener(parametroAccesosDatos);
        }

        #endregion
    }
}
