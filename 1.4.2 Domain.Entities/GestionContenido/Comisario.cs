//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimpiadas.Domain.Entities.GestionContenido
{
    using System;
    using System.Collections.Generic;
    
    
    /// <summary>
    ///
    /// </summary>
    public partial class Comisario
    {
    
        /// <summary>
        ///
        /// </summary>
        public int IdComisario { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdEvento { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdPersonal { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdTipoComisario { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public bool Activo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdComisario{ get {return "IdComisario"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdEvento{ get {return "IdEvento"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdPersonal{ get {return "IdPersonal"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdTipoComisario{ get {return "IdTipoComisario"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_Activo{ get {return "Activo"; }}
    
    
    	/// <summary>
        /// Propiedad de navegación a Evento
        /// </summary>
        public virtual Evento Evento { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Personal
        /// </summary>
        public virtual Personal Personal { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Tipo
        /// </summary>
        public virtual Tipo Tipo { get; set; }
    
    }
}