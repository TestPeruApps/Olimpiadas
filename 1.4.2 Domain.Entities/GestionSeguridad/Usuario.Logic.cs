using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.CrossCutting.Helper.Security;
using Olimpiadas.Domain.Entities.Resources;
using Olimpiadas.Domain.Entities.ValueObject;


namespace Olimpiadas.Domain.Entities.GestionSeguridad
{
    /// <summary>
    /// Lógica de negocio del manejo de Usuarios.
    /// </summary>
    public partial class Usuario
    {
        #region VARIABLES

        /// <summary>
        /// Texto del mensaje de validación.
        /// </summary>
        private string _mensaje;

        #endregion



        #region MÉTOOS

        /// <summary>
        /// Lógica de negocio para validar si un usuario existe
        /// </summary>
        /// <param name="usuario">Usuario</param>
        public static void ValidarExiste(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new BusinessException(Messages.Usuario_LoginNoExiste);
            }
        }

        /// <summary>
        /// Valida los datos del usuario para permitir el inicio de sesión.
        /// </summary>
        /// <param name="usuario">Datos del usuario.</param>
        /// <param name="credencialesParaValidar">Contraseña ingresada por el usuario.</param>
        public UsuarioResultadoValidarCredencialesVob ValidarCredenciales(Usuario usuario, string credencialesParaValidar)//, List<Usuario_Rol> roles)
        {
            //REGLA: Validar que el usuario existe
            if (usuario == null)
            {
                _mensaje = string.Format(Messages.Usuario_LoginNoExiste);
                throw new BusinessException(_mensaje);
            }

            //REGLA: El usuario esta inactivo
            if (usuario.Activo == false)
            {
                _mensaje = string.Format(Messages.Usuario_Desactivado, usuario.NombreUsuario);
                throw new BusinessException(_mensaje);
            }

            //REGLA: Validar que la contraseña sea correcta
            var cryptography = new Cryptography();
            var contraseniaDesencriptada = cryptography.Decrypt(usuario.Contrasenia);
            if (contraseniaDesencriptada.ToUpper() != credencialesParaValidar.ToUpper())
            {
                _mensaje = string.Format(Messages.Usuario_ContraseniaActualIncorrecta);
                return new UsuarioResultadoValidarCredencialesVob(false, _mensaje);
            }

            //Devolvemos validación
            return new UsuarioResultadoValidarCredencialesVob(true, string.Empty);
        }

        #endregion
    }
}