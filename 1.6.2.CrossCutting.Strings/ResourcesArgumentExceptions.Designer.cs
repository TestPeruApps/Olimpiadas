﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimpiadas.CrossCutting.Strings {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourcesArgumentExceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourcesArgumentExceptions() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Olimpiadas.CrossCutting.Strings.ResourcesArgumentExceptions", typeof(ResourcesArgumentExceptions).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El argumento no puede ser nulo..
        /// </summary>
        public static string ArgumentNullException {
            get {
                return ResourceManager.GetString("ArgumentNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El índice de la página solicitada debe ser un número positivo..
        /// </summary>
        public static string CriteriosPaginacion_PageIndexMenorCero {
            get {
                return ResourceManager.GetString("CriteriosPaginacion_PageIndexMenorCero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El tamaño de la página solicitada debe ser mayor a cero..
        /// </summary>
        public static string CriteriosPaginacion_PageSizeMenorCero {
            get {
                return ResourceManager.GetString("CriteriosPaginacion_PageSizeMenorCero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El formato de la fecha es incorrecto.
        /// </summary>
        public static string Fecha_FormatoIncorrecto {
            get {
                return ResourceManager.GetString("Fecha_FormatoIncorrecto", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor del parámetro es incorrecto.
        /// </summary>
        public static string ParámetroIncorrecto {
            get {
                return ResourceManager.GetString("ParámetroIncorrecto", resourceCulture);
            }
        }
    }
}
