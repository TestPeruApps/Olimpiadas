using Olimpiadas.Domain.Core;
using Olimpiadas.Domain.Entities.GestionSeguridad;
using Olimpiadas.Domain.Modulos.GestionSeguridad;
using Olimpiadas.Infrastructure.Data.Core;
using Olimpiadas.Infrastructure.Data.Core.Conexion;


namespace Olimpiadas.Infrastructure.Data.GestionSeguridad.Repositories
{
    /// <summary>
    /// Implementa los métodos de acceso a datos del repositorio de usuarios.
    /// </summary>
    public class UsuarioRepository
        : Repository<Usuario>, IUsuarioRepository
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public UsuarioRepository(IConexionBase conexionBaseDatos)
            :  base(conexionBaseDatos)
        { }

        #endregion



        #region MÉTODOS - Implementa interface IUsuarioRepository

        /// <summary>
        /// Implementa método para seleccionar un usuario por su login, desde el orígen de datos.
        /// </summary>
        /// <param name="loginUsuario">Login del usaurio.</param>
        /// <returns>Registro seleccionado.</returns>
        public Usuario SelecccionarPorLogin(string loginUsuario)
        {
            ParametroAccesosDatos parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "USP_Usuario_Seleccionar_PorLogin",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Usuario.Propiedad_LoginUsuario, loginUsuario)
                }
            };

            return Obtener(parametroAccesosDatos);
        }

        /// <summary>
        /// Implementa método para seleccionar un usuario por su Id, desde el orígen de datos.
        /// </summary>
        /// <param name="idUsuario">Id del usaurio.</param>
        /// <returns>Usuario seleccionado.</returns>
        public Usuario SelecccionarPorId(short idUsuario)
        {
            ParametroAccesosDatos parametroAccesosDatos = new ParametroAccesosDatos
            {
                ProcedimientoAlmacenado = "USP_Usuario_Seleccionar_PorId",
                ParametrosEntrada = new ParametroEntrada[]
                {
                    new ParametroEntrada(Usuario.Propiedad_IdUsuario, idUsuario)
                }
            };

            return Obtener(parametroAccesosDatos);
        }

        #endregion
    }
}