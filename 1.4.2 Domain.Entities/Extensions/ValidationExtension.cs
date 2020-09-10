using System;
using System.Globalization;
using Olimpiadas.Domain.Entities.Resources;


namespace Olimpiadas.Domain.Entities.Extensions
{
    /// <summary>
    /// Clase con métodos de extensión de un texto para realizar validaciones.
    /// </summary>
    internal static class ValidationExtension
    {
        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion(this string valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (string.IsNullOrEmpty(valorBase))
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }        

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionNull(this DateTime? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionNull(this bool? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionNullOr0(this decimal? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null || valorBase == 0)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionNull(this Guid? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionPorDefecto(this DateTime valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase.EsFechaPorDefecto())
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionPorDefecto(this TimeSpan? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                    ? string.Concat("'", nombrePropiedad, "'")
                    : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }            
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionPorDefecto(this Guid valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == Guid.Empty)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                    ? string.Concat("'", nombrePropiedad, "'")
                    : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion(this int? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion(this byte? valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == null)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el texto es null o vacío.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion0(this int valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == 0)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el tipo dato es short 0.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion0(this short valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == 0)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando el tipo dato es short 0.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacion0(this byte valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == 0)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }        

        /// <summary>
        /// Genera el mensaje de validación cuando el  tipo dato es int 0.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarAsignacionDecimal(this decimal valorBase, string nombrePropiedad, ref string mensaje)
        {
            if (valorBase == 0)
            {
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? string.Concat("'", nombrePropiedad, "'")
                        : string.Concat(mensaje, ", '", nombrePropiedad, "'");
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando la cantidad de caracteres del texto es inválida.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="tamanio">Tamaño de caracteres exactos que debe tener el texto.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarTamanio(this string valorBase, int tamanio, string nombrePropiedad, ref string mensaje)
        {
            if (string.IsNullOrEmpty(valorBase)) return;
            if (valorBase.Trim().Length != tamanio)
            {
                string mensajeTemp = string.Format(Messages.GenereralTamanioFijoIncorrecto, nombrePropiedad, tamanio.ToString(CultureInfo.InvariantCulture));
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? mensajeTemp
                        : string.Concat(mensaje, ", ", mensajeTemp);                                
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando la cantidad de caracteres del texto es inválida.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="tamanioMaximo">Tamaño máximo de caracteres que debe tener el texto.</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarTamanioMaximo(this string valorBase, int tamanioMaximo, string nombrePropiedad, ref string mensaje)
        {
            if (string.IsNullOrEmpty(valorBase)) return;
            if (valorBase.Trim().Length > tamanioMaximo)
            {
                string mensajeTemp = string.Format(Messages.GenereralTamanioFijoIncorrecto, nombrePropiedad, tamanioMaximo.ToString(CultureInfo.InvariantCulture));
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? mensajeTemp
                        : string.Concat(mensaje, ", ", mensajeTemp);                
            }
        }

        /// <summary>
        /// Genera el mensaje de validación cuando la cantidad de caracteres del texto es inválida.
        /// </summary>
        /// <param name="valorBase">Clase que se extiende.</param>
        /// <param name="valorIncorrecto"></param>
        /// <param name="nombrePropiedad">Nombre de la propiedad que se valida.</param>
        /// <param name="mensaje">Mensaje de validación.</param>
        internal static void ValidarValorIncorrecto(this string valorBase, string valorIncorrecto, string nombrePropiedad, ref string mensaje)
        {
            if (string.IsNullOrEmpty(valorBase)) return;
            if (valorBase.Trim() == valorIncorrecto)
            {
                string mensajeTemp = string.Format(Messages.GenereralCadenaValorIncorrecto, nombrePropiedad);
                mensaje = string.IsNullOrEmpty(mensaje)
                        ? mensajeTemp
                        : string.Concat(mensaje, ", ", mensajeTemp);
            }
        }
        
    }
}