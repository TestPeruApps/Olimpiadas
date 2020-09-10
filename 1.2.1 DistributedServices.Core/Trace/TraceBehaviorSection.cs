using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Olimpiadas.DistributedServices.Core.Trace
{
    /// <summary>
    /// 
    /// </summary>
    public class TraceBehaviorSection : BehaviorExtensionElement
    {
        #region CONSTANTES

        private const string EnabledAttributeName = "enabled";

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        #endregion

        #region PROPIEDADES REEMPLAZADOS

        /// <summary>
        /// 
        /// </summary>
        public override Type BehaviorType
        {
            get { return typeof(TraceBehavior); }
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object CreateBehavior()
        {
            return new TraceBehavior(Enabled);
        }        

        #endregion
    }
}