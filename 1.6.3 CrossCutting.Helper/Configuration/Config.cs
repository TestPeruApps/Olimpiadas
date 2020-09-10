using System;
using System.Configuration;
using System.Globalization;

namespace Olimpiadas.CrossCutting.Helper.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Lee el valor de la configuración del web.config.
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <returns>Valor de la configuración representada en entero.</returns>
        public static int AppSettingObtenerEntero(string key)
        {
            return int.Parse(ConfigurationManager.AppSettings[key].ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Lee el valor de la configuración del web.config.
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <param name="valorPorDefecto">valor por defecto</param>
        /// <returns>Valor de la configuración representada en entero.</returns>
        public static int AppSettingObtenerEnteroDefault(string key, int valorPorDefecto = 0)
        {
            int resultado = 0;
            if (int.TryParse(ConfigurationManager.AppSettings[key].ToString(CultureInfo.InvariantCulture), out resultado) == false)
                resultado = valorPorDefecto;

            return resultado;
        }

        /// <summary>
        /// Lee el valor de la configuración del web.config.
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <returns>Valor de la configuración representada en cadena.</returns>
        public static string AppSettingObtenerCadena(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Lee el valor de la configuración del web.config, obtiene la url solicitada adicionando la rura base
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <returns>Valor de la configuración representada en cadena.</returns>
        public static string AppSettingObtenerCadenaUrl(string key)
        {
            return string.Concat(
                ConfigurationManager.AppSettings["UrlImagenesRaiz"].ToString(CultureInfo.InvariantCulture), "/", 
            ConfigurationManager.AppSettings[key].ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Lee el valor de la configuración del web.config.
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <returns>Valor de la configuración representada en cadena.</returns>
        public static DateTime AppSettingObtenerObtenerHora(string key)
        {
            return DateTime.Parse(ConfigurationManager.AppSettings[key].ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Lee el valor de la configuración del web.config.
        /// </summary>
        /// <param name="key">Nombre del valor de la configuración</param>
        /// <returns>Valor de la configuración representada en cadena.</returns>
        public static string AppSettingObtenerObtenerCadenaConexion(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();
        }
    }
}