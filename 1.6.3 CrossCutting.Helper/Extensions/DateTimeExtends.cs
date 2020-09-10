using System.Globalization;

namespace System
{
    /// <summary>
    /// Métodos de extensión de la clase DateTime.
    /// </summary> 
    public static class DateTimeExtends
    {
        #region MÉTODOS NUEVOS

        /// <summary>
        /// Función para devolver la cantidad de días de diferencia entre 2 fechas
        /// </summary>
        /// <param name="fechaInicial">Final Incial.</param>        
        /// <param name="fechaFinal">>Fecha final.</param>        
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static int DiferenciaDias(this DateTime fechaInicial, DateTime fechaFinal)
        {                     
            // Difference in days, hours, and minutes.
            TimeSpan ts = fechaFinal - fechaInicial;
            // Difference in days.
            int differenceInDays = ts.Days;
            return differenceInDays;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha no esta asignada. (Es el valor por defecto)
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>        
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsFechaPorDefecto(this DateTime fechaBase)
        {
            if (fechaBase.Year == 1 && fechaBase.Month == 1 && fechaBase.Day == 1) return true;
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha no esta asignada. (Es el valor por defecto)
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>        
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsFechaHoraPorDefecto(this DateTime fechaBase)
        {
            if (fechaBase.Year == 1 && fechaBase.Month == 1 && fechaBase.Day == 1 && fechaBase.Hour == 12 && fechaBase.Minute == 0 && fechaBase.Second == 0) return true;
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es igual a la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaComparacion">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsIgual(this DateTime fechaBase, DateTime fechaComparacion)
        {
            if (fechaBase.Year == fechaComparacion.Year && fechaBase.Month == fechaComparacion.Month && fechaBase.Day == fechaComparacion.Day) return true;            
           return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es mayor a la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaComparacion">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsMayor(this DateTime fechaBase, DateTime fechaComparacion)
        {
            if (fechaBase.Year > fechaComparacion.Year) return true;
            if (fechaBase.Year == fechaComparacion.Year)
            {
                if (fechaBase.Month > fechaComparacion.Month) //Comparo meses
                    return true;
                if (fechaBase.Month == fechaComparacion.Month) //Comparo días
                {
                    if (fechaBase.Day > fechaComparacion.Day) return true;
                    return false;
                }
                return false;
            }            
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es mayor o igual a la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaComparacion">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsMayorIgual(this DateTime fechaBase, DateTime fechaComparacion)
        {
            if (fechaBase.Year > fechaComparacion.Year) return true;
            if (fechaBase.Year == fechaComparacion.Year)
            {
                if (fechaBase.Month > fechaComparacion.Month) //Comparo meses
                    return true;
                if (fechaBase.Month == fechaComparacion.Month) //Comparo días
                {
                    if (fechaBase.Day >= fechaComparacion.Day) return true;                    
                    return false;
                }                
                return false;
            }            
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es menor a la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaComparacion">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsMenor(this DateTime fechaBase, DateTime fechaComparacion)
        {
            if (fechaBase.Year < fechaComparacion.Year) return true;
            if (fechaBase.Year == fechaComparacion.Year)
            {
                if (fechaBase.Month < fechaComparacion.Month) //Comparo meses
                    return true;
                if (fechaBase.Month == fechaComparacion.Month) //Comparo días
                {
                    if (fechaBase.Day < fechaComparacion.Day) return true;
                   return false;
                }                
                return false;
            }            
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es menor o igual a la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaComparacion">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsMenorIgual(this DateTime fechaBase, DateTime fechaComparacion)
        {
            if (fechaBase.Year < fechaComparacion.Year) return true;
            if (fechaBase.Year == fechaComparacion.Year)
            {
                if (fechaBase.Month < fechaComparacion.Month) //Comparo meses
                    return true;

                if (fechaBase.Month == fechaComparacion.Month) //Comparo días
                {
                    if (fechaBase.Day <= fechaComparacion.Day) return true;                
                   return false;
                }                
                return false;
            }            
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha se encuentra entre 2 fechas.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="fechaInicial">Fecha inicial.</param>
        /// <param name="fechaFinal">Fecha final.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsEntre(this DateTime fechaBase, DateTime fechaInicial, DateTime fechaFinal)
        {
            if (fechaBase.EsMenorIgual(fechaFinal) && fechaBase.EsMayorIgual(fechaInicial)) return true;            
            return false;
        }

        /// <summary>
        /// Función que combina el valor de la fecha con el Time proporcionado.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="hora">Hora proporcionada que se combinará.</param>
        /// <returns>Fecha y hora combinada.</returns>
        public static DateTime Combine(this DateTime fechaBase, TimeSpan hora)
        {
            try
            {
                return new DateTime(fechaBase.Year, fechaBase.Month, fechaBase.Day, hora.Hours, hora.Minutes, hora.Seconds);
            }
            catch
            {
                return fechaBase;
            }
        }

        /// <summary>
        /// Función que indica si el valor de la fecha el igual al periodo(año y mes) de la fecha proporcionada.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <param name="mesAnio">Cadena que representa el mes y el año a comparar.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool EsIgualPeriodo(this DateTime fechaBase, string mesAnio)
        {
            try
            {
                mesAnio = mesAnio.Trim();
                if (mesAnio.Length == 5)
                    mesAnio = "0" + mesAnio;
                int intMes = int.Parse(mesAnio.Substring(0, 2));
                int intAnio = int.Parse(mesAnio.Substring(2));

                return (fechaBase.Year == intAnio && fechaBase.Month == intMes) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve solo el tiempo.
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <returns>Hora.</returns>
        public static DateTime SoloTiempo(this DateTime fechaBase)
        {
            return new DateTime(1, 1, 1, fechaBase.Hour, fechaBase.Minute, 0);
        }

        /// <summary>
        /// Obtiene el periodo del año
        /// </summary>
        /// <param name="fechaBase">Clase que se extendida con el valor de la fecha y hora.</param>
        /// <returns>Periodo (año) de la fecha.</returns>
        public static string Periodo(this DateTime fechaBase)
        {
            return fechaBase.Year.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}