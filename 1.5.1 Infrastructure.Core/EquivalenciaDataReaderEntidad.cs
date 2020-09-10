using System.Reflection;

namespace Olimpiadas.Infrastructure.Data.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class EquivalenciaDataReaderEntidad
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indiceEnDataReader"></param>
        /// <param name="propertyInfo"></param>
        public EquivalenciaDataReaderEntidad(byte indiceEnDataReader, PropertyInfo propertyInfo)
        {
            IndiceEnDataReader = indiceEnDataReader;
            PropertyInfo = propertyInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        public byte IndiceEnDataReader { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte IndiceEnEntidad { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }
    }
}