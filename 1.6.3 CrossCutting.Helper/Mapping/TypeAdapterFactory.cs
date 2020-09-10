using Olimpiadas.CrossCutting.Helper.Mapping.Interface;

namespace Olimpiadas.CrossCutting.Helper.Mapping
{    
    /// <summary>
    /// Factoria para contrucción del adaptador.
    /// </summary>
    public static class TypeAdapterFactory
    {
        #region VARIABLES

        /// <summary>
        /// Contrato del tipo de adaptador actual.
        /// </summary>
        static ITypeAdapterFactory _currentTypeAdapterFactory = null;

        #endregion

        #region MÉTODOS ESTATICOS

        /// <summary>
        /// Establece contrato para la factoria del adaptador.
        /// </summary>
        /// <param name="adapterFactory">Contrato de la factoria del adaptador.</param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }

        /// <summary>
        /// Crea un nuevo tipo de dapatador conla factoria actual.
        /// </summary>
        /// <returns>Instancia del tipo de adaptador creado.</returns>
        public static ITypeAdapter CreateAdapter()
        {
            if (_currentTypeAdapterFactory == null)            
                _currentTypeAdapterFactory = new AutomapperTypeAdapterFactory();            
            
            return _currentTypeAdapterFactory.Create();
        }

        #endregion
    }
}