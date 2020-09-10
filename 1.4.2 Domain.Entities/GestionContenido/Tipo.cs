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
    public partial class Tipo
    {
    	/// <summary>
        /// Incializa una nueva instancia de la clase.
        /// </summary>
        public Tipo()
        {
            this.Comisario = new HashSet<Comisario>();
            this.ComplejoDeportivo = new HashSet<ComplejoDeportivo>();
            this.Evento = new HashSet<Evento>();
            this.Evento1 = new HashSet<Evento>();
            this.Participante = new HashSet<Participante>();
            this.Participante1 = new HashSet<Participante>();
        }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdTipo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public int IdGrupo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public string NombreTipo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public bool Activo { get; set; }
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdTipo{ get {return "IdTipo"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_IdGrupo{ get {return "IdGrupo"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_NombreTipo{ get {return "NombreTipo"; }}
    
    
        /// <summary>
        ///
        /// </summary>
        public static string Propiedad_Activo{ get {return "Activo"; }}
    
    
    	/// <summary>
        /// Propiedad de navegación a Comisario
        /// </summary>
        public virtual ICollection<Comisario> Comisario { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a ComplejoDeportivo
        /// </summary>
        public virtual ICollection<ComplejoDeportivo> ComplejoDeportivo { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Evento
        /// </summary>
        public virtual ICollection<Evento> Evento { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Evento1
        /// </summary>
        public virtual ICollection<Evento> Evento1 { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Grupo
        /// </summary>
        public virtual Grupo Grupo { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Participante
        /// </summary>
        public virtual ICollection<Participante> Participante { get; set; }
    
    	/// <summary>
        /// Propiedad de navegación a Participante1
        /// </summary>
        public virtual ICollection<Participante> Participante1 { get; set; }
    
    }
}
