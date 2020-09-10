using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Olimpiadas.DistributedServices.Core.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorBehaviorSection : BehaviorExtensionElement
    {
        private const string EnabledAttributeName = "enabled";

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object CreateBehavior()
        {
            return new ErrorBehavior(Enabled);
        }

        /// <summary>
        /// 
        /// </summary>
        public override Type BehaviorType
        {
            get { return typeof(ErrorBehavior); }
        }
    }
}