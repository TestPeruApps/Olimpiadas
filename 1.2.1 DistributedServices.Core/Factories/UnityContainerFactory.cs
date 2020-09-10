using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Olimpiadas.DistributedServices.Core.Factories
{
    /// <summary>
    /// Factoria para crear el contenedor Unity.
    /// </summary>
    public class UnityContainerFactory
    {
        #region VARIABLES

        private static readonly object SyncLock = new object();

        private static IUnityContainer _container;

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene la interfaz del contendor unity.
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetContainer()
        {
            if (_container == null)
            {
                lock (SyncLock)
                {
                    if (_container == null)
                    {
                        var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

                        IUnityContainer unitContainer = new UnityContainer();
                        _container = unitContainer.LoadConfiguration(section);
                    }
                }
            }

            return _container;
        }

        #endregion
    }
}