using System;
using System.Linq;
using AutoMapper;

using Olimpiadas.CrossCutting.Helper.Mapping.Interface;

namespace Olimpiadas.CrossCutting.Helper.Mapping
{
    /// <summary>
    /// Implementa loc métodos del contrato base para factoria del adaptador.
    /// </summary>
    public class AutomapperTypeAdapterFactory
        :ITypeAdapterFactory
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva factoria de adaptador para Automapper.
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                } 
            });
        }

        #endregion

        #region IMPLEMENTA ITypeAdapterFactory - Métodos

        /// <summary>
        /// Implementa el métodos para crear nueva instancia para la factoria con AutoMapper
        /// </summary>
        /// <returns>Factoria para el adaptador AutoMapper.</returns>
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}