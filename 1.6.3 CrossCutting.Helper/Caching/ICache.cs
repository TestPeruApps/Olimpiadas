using System;
using System.Collections.Generic;

namespace Olimpiadas.CrossCutting.Helper.Caching
{
    /// <summary>
    /// Métodos para realizar operaciones con datos en cache.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeResult>> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class;

        /// <summary>
        /// Método para obtener la lista del orígen de datos, agrega un primer item, guadar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="primerItem"></param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeSource>> methodCall, TParam param, TTypeSource primerItem, Double minutes = 0)
            where TTypeResult : class;

        /// <summary>
        /// Método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeSource>> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class
            where TTypeSource : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParam1"></typeparam>
        /// <typeparam name="TParam2"></typeparam>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <typeparam name="TTypeResult"></typeparam>
        /// <param name="name"></param>
        /// <param name="methodCall"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam1, TParam2, TTypeSource, TTypeResult>(string name,
            Func<TParam1, TParam2, IEnumerable<TTypeSource>> methodCall, TParam1 param1, TParam2 param2,
            Double minutes = 0)
            where TTypeResult : class
            where TTypeSource : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParam1"></typeparam>
        /// <typeparam name="TParam2"></typeparam>
        /// <typeparam name="TTypeResult"></typeparam>
        /// <param name="name"></param>
        /// <param name="methodCall"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        List<TTypeResult> ResolveListOriginal<TParam1, TParam2, TTypeResult>(string name, Func<TParam1, TParam2, IEnumerable<TTypeResult>> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0);            

        /// <summary>
        /// Método para obtener objeto desde el orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro 1 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro 2 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro 1 a pasar</param>
        /// <param name="param2">Parámetro 2 a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TParam1, TParam2, TTypeSource, TTypeResult>(string name,
            Func<TParam1, TParam2, TTypeSource> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0)
            where TTypeResult : class, new()
            where TTypeSource : class;


        /// <summary>
        /// Método para obtener objeto desde el orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro 1 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro 2 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro 1 a pasar</param>
        /// <param name="param2">Parámetro 2 a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TParam1, TParam2, TTypeResult>(string name,
            Func<TParam1, TParam2, TTypeResult> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0)
            where TTypeResult : class, new();

        /// <summary>
        /// Método para obtener objeto desde el orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro 1 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro 2 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam3">Parámetro 3 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro 1 a pasar</param>
        /// <param name="param2">Parámetro 2 a pasar</param>
        /// <param name="param3">Parámetro 2 a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TParam1, TParam2, TParam3, TTypeResult>(string name,
            Func<TParam1, TParam2, TParam3, TTypeResult> methodCall, TParam1 param1, TParam2 param2, TParam3 param3, Double minutes = 0)
            where TTypeResult : class, new();

        /// <summary>
        /// Implementa método para obtener objeto desde el orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro 1 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro 2 para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro 1 a pasar</param>
        /// <param name="param2">Parámetro 2 a pasar</param>
        /// <returns></returns>
        TTypeResult ResolveObjectNoSaveCache<TParam1, TParam2, TTypeSource, TTypeResult>(string name,
            Func<TParam1, TParam2, TTypeSource> methodCall, TParam1 param1, TParam2 param2)
            where TTypeResult : class, new()
            where TTypeSource : class;

        /// <summary>
        /// Método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>        
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TTypeSource, TTypeResult>(string name, Func<IEnumerable<TTypeSource>> methodCall, Double minutes = 0)            
            where TTypeResult : class
            where TTypeSource : class;

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>        
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TTypeSource, TTypeResult>(string name, Func<TTypeSource> methodCall, Double minutes = 0)
                where TTypeResult : class, new()
                where TTypeSource : class;

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>     
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, TTypeSource> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class, new()
            where TTypeSource : class;

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        TTypeResult ResolveObject<TParam, TTypeResult>(string name, Func<TParam, TTypeResult> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParam"></typeparam>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <param name="name"></param>
        /// <param name="methodCall"></param>
        /// <param name="param"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        string ResolveString<TParam, TTypeSource>(string name, Func<TParam, string> methodCall, TParam param, Double minutes = 0)
            where TTypeSource : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string ResolveString(string name);

        /// <summary>
        /// Método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TTypeResult>(string name, Func<IEnumerable<TTypeResult>> methodCall, Double minutes = 0);

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam3">Parámetro para llamar al método que obtiene datos</typeparam>        
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="param3">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam1, TParam2, TParam3, TTypeResult>(string name,
            Func<TParam1, TParam2, TParam3, IEnumerable<TTypeResult>> methodCall,
            TParam1 param1, TParam2 param2, TParam3 param3, Double minutes = 0);

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        List<TTypeResult> ResolveList<TParam1, TParam2, TTypeResult>(string name,
            Func<TParam1, TParam2, IEnumerable<TTypeResult>> methodCall,
            TParam1 param1, TParam2 param2, Double minutes = 0);

        /// <summary>
        /// Método para obtener los datos de la memoria cache de objetos en base a su Key.
        /// </summary>
        /// <param name="keyCache">Nombre del key en cache</param>
        void ClearMemoryCache(string keyCache);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        void SetOrAddItem<T>(string name, T value, Double minutes = 0)
            where T : class;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool ExisteVariable(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        void CrearVariable(string name);
    }
}