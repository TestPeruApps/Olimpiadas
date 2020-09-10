namespace System
{
    /// <summary>
    /// Métodos de extensión de la clase string.
    /// </summary> 
    public static class StringExtends
    {
        #region MÉTODOS NUEVOS

        /// <summary>
        /// Función que indica si el valor de la fecha no esta asignada. (Es el valor por defecto)
        /// </summary>
        /// <param name="textoBase">Clase que se extendida con el valor de la fecha y hora.</param>        
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static string TrimEmpty(this string textoBase)
        {
            if (string.IsNullOrEmpty(textoBase))
                return string.Empty;
            return textoBase.Trim();            
        }

        #endregion
    }
}