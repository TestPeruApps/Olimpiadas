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
    public partial class MaterialEvento
    {
    
        /// <summary>
        ///
        /// </summary>
        public int IdMaterial { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdEvento { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdEquipamiento { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public bool Activo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public System.DateTime FechaCreacion { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdMaterial{ get {return "IdMaterial"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdEvento{ get {return "IdEvento"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdEquipamiento{ get {return "IdEquipamiento"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_Activo{ get {return "Activo"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_FechaCreacion{ get {return "FechaCreacion"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_FechaModificacion{ get {return "FechaModificacion"; }}
    
    
    	/// <summary>
        /// Propiedad de navegación a Equipamiento
        /// </summary>
        public virtual Equipamiento Equipamiento { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Evento
        /// </summary>
        public virtual Evento Evento { get; set; }
    
    }
}