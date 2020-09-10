using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Runtime.Serialization;

using Olimpiadas.CrossCutting.Helper.Mapping;

namespace Olimpiadas.CrossCutting.Helper.Caching
{
    /// <summary>
    /// Implementa métodos para realizar operaciones con datos en cache.
    /// </summary>
    [DataContract]
    public class ServicioCache : ICache
    {
        #region VARIABLES

        /// <summary>
        /// Memória cache de objetos, proporciona métodos y propiedades para tener acceso ala memoria cche de objetos.
        /// </summary>
        private readonly ObjectCache _objectCache;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public ServicioCache()
        {
            _objectCache = MemoryCache.Default;
        }

        #endregion

        #region MÉTODOS - Implementacion ICache

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, agrega un primer item, guadar en cache y retorna los datos.
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
        public List<TTypeResult> ResolveList<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeSource>> methodCall, TParam param, TTypeSource primerItem, Double minutes = 0)
            where TTypeResult : class
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeSource> listDataSource = methodCall.Invoke(param).ToList();
            if (listDataSource.Any())
            {
                listDataSource.Insert(0, primerItem);
                listResult = listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
                AddItem(name, listResult, minutes);

                return listResult;
            }

            return listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public List<TTypeResult> ResolveList<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeSource>> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class
            where TTypeSource : class
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);

            var allCache = _objectCache.Select(c => c.Key).ToList();

            if (listResult != null)
                return listResult;

            List<TTypeSource> listDataSource = methodCall.Invoke(param).ToList();
            if (listDataSource.Any())
            {
                listResult = listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
                AddItem(name, listResult, minutes);

                return listResult;
            }

            return listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
        }

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
        public List<TTypeResult> ResolveList<TParam, TTypeResult>(string name, Func<TParam, IEnumerable<TTypeResult>> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            listResult = methodCall.Invoke(param).ToList();
            if (listResult.Any())
            {
                AddItem(name, listResult, minutes);
                return listResult;
            }

            return new List<TTypeResult>();
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public List<TTypeResult> ResolveList<TParam1, TParam2, TTypeSource, TTypeResult>(string name, 
            Func<TParam1, TParam2, IEnumerable<TTypeSource>> methodCall, 
            TParam1 param1, TParam2 param2, Double minutes = 0)
            where TTypeResult : class
            where TTypeSource : class
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeSource> listDataSource = methodCall.Invoke(param1, param2).ToList();
            if (listDataSource.Any())
            {
                listResult = listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
                AddItem(name, listResult, minutes);

                return listResult;
            }

            return listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
        }

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
        public List<TTypeResult> ResolveList<TParam1, TParam2, TParam3, TTypeResult>(string name, 
            Func<TParam1, TParam2, TParam3, IEnumerable<TTypeResult>> methodCall,
            TParam1 param1, TParam2 param2, TParam3 param3, Double minutes = 0)            
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeResult> listDataSource = methodCall.Invoke(param1, param2, param3).ToList();
            if (listDataSource.Any())
            {
                AddItem(name, listDataSource, minutes);
            }
            return listDataSource;
        }

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
        public List<TTypeResult> ResolveList<TParam1, TParam2, TTypeResult>(string name,
            Func<TParam1, TParam2, IEnumerable<TTypeResult>> methodCall,
            TParam1 param1, TParam2 param2, Double minutes = 0)
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeResult> listDataSource = methodCall.Invoke(param1, param2).ToList();
            if (listDataSource.Any())
            {
                AddItem(name, listDataSource, minutes);
            }
            return listDataSource;
        }

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
        public List<TTypeResult> ResolveListOriginal<TParam1, TParam2, TTypeResult>(string name, Func<TParam1, TParam2, IEnumerable<TTypeResult>> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0)
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeResult> listDataSource = methodCall.Invoke(param1, param2).ToList();
            if (listDataSource.Any())
            {
                AddItem(name, listDataSource, minutes);
            }
            return listDataSource;
        }

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
        public TTypeResult ResolveObjectNoSaveCache<TParam1, TParam2, TTypeSource, TTypeResult>(string name, Func<TParam1, TParam2, TTypeSource> methodCall, TParam1 param1, TParam2 param2)
            where TTypeResult : class, new()
            where TTypeSource : class
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeSource objectDataSource = methodCall.Invoke(param1, param2);
            if (objectDataSource != null)
            {
                result = objectDataSource.ProjectedAs<TTypeResult>();

                return result;
            }

            return null;
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>        
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public List<TTypeResult> ResolveList<TTypeSource, TTypeResult>(string name, Func<IEnumerable<TTypeSource>> methodCall, Double minutes = 0)
            where TTypeResult : class
            where TTypeSource : class
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeSource> listDataSource = methodCall.Invoke().ToList();
            if (listDataSource.Any())
            {
                listResult = listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
                AddItem(name, listResult, minutes);

                return listResult;
            }

            return listDataSource.ProjectedAsList<TTypeSource, TTypeResult>();
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>        
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public TTypeResult ResolveObject<TTypeSource, TTypeResult>(string name, Func<TTypeSource> methodCall, Double minutes = 0)
            where TTypeResult : class, new()
            where TTypeSource : class
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeSource objectDataSource = methodCall.Invoke();
            if (objectDataSource != null)
            {
                result = objectDataSource.ProjectedAs<TTypeResult>();
                AddItem(name, result, minutes);

                return result;
            }

            return null;
        }

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
        public TTypeResult ResolveObject<TParam, TTypeSource, TTypeResult>(string name, Func<TParam, TTypeSource> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class, new()
            where TTypeSource : class
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeSource objectDataSource = methodCall.Invoke(param);
            if (objectDataSource != null)
            {
                result = objectDataSource.ProjectedAs<TTypeResult>();
                AddItem(name, result, minutes);

                return result;
            }

            return null;
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public TTypeResult ResolveObject<TParam1, TParam2, TTypeSource, TTypeResult>(string name, Func<TParam1, TParam2, TTypeSource> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0)
            where TTypeResult : class, new()
            where TTypeSource : class
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeSource objectDataSource = methodCall.Invoke(param1, param2);
            if (objectDataSource != null)
            {
                result = objectDataSource.ProjectedAs<TTypeResult>();
                AddItem(name, result, minutes);

                return result;
            }

            return null;
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public TTypeResult ResolveObject<TParam1, TParam2, TTypeResult>(string name, Func<TParam1, TParam2, TTypeResult> methodCall, TParam1 param1, TParam2 param2, Double minutes = 0)
            where TTypeResult : class, new()
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeResult objectDataSource = methodCall.Invoke(param1, param2);
            if (objectDataSource != null)
            {
                AddItem(name, objectDataSource, minutes);
                return objectDataSource;
            }

            return null;
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam1">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam2">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TParam3">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param1">Parámetro a pasar</param>
        /// <param name="param2">Parámetro a pasar</param>
        /// <param name="param3">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public TTypeResult ResolveObject<TParam1, TParam2, TParam3, TTypeResult>(string name, Func<TParam1, TParam2, TParam3, TTypeResult> methodCall, TParam1 param1, TParam2 param2, TParam3 param3, Double minutes = 0)
            where TTypeResult : class, new()
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            TTypeResult objectDataSource = methodCall.Invoke(param1, param2, param3);
            if (objectDataSource != null)
            {
                AddItem(name, objectDataSource, minutes);
                return objectDataSource;
            }

            return null;
        }

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
        public TTypeResult ResolveObject<TParam, TTypeResult>(string name, Func<TParam, TTypeResult> methodCall, TParam param, Double minutes = 0)
            where TTypeResult : class, new()
        {
            var result = (TTypeResult)_objectCache.Get(name);
            if (result != null)
                return result;

            result = methodCall.Invoke(param);
            if (result != null)
            {
                AddItem(name, result, minutes);

                return result;
            }

            return null;
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource">Tipo de datos del origen.</typeparam>        
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public string ResolveString<TParam, TTypeSource>(string name, Func<TParam, string> methodCall, TParam param, Double minutes = 0)
            where TTypeSource : class
        {
            var result = _objectCache.Get(name);
            if (result != null)
                return result.ToString();

            string objectDataSource = methodCall.Invoke(param);
            if (string.IsNullOrEmpty(objectDataSource) == false)
            {
                AddItem(name, objectDataSource, minutes);
                return objectDataSource;
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ResolveString(string name)
        {
            var result = _objectCache.Get(name);
            return (result??string.Empty).ToString();
        }

        /// <summary>
        /// Implementa método para obtener la lista del orígen de datos, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TTypeResult">Tipo de datos devuelto (Proyectado).</typeparam>
        /// <param name="name">Nombre del key en cache</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public List<TTypeResult> ResolveList<TTypeResult>(string name, Func<IEnumerable<TTypeResult>> methodCall, Double minutes = 0)
        {
            var listResult = (List<TTypeResult>)_objectCache.Get(name);
            if (listResult != null)
                return listResult;

            List<TTypeResult> listDataSource = methodCall.Invoke().ToList();
            if (listDataSource.Any())
            {
                listResult = listDataSource;
                AddItem(name, listResult, minutes);

                return listResult;
            }

            return listDataSource;
        }

        /// <summary>
        /// Implementa método para obtener los datos de la memoria cache de objetos en base a su Key.
        /// </summary>
        /// <param name="keyCache">Nombre del key en cache</param>
        public void ClearMemoryCache(string keyCache)
        {
            List<string> cacheKeys = _objectCache.Select(c => c.Key).Where(w => w.Contains(keyCache)).ToList();

            foreach (string cacheKey in cacheKeys)
            {
                _objectCache.Remove(cacheKey);
            }
        }

        #endregion

        #region MÉTODOS - Apoyo

        /// <summary>
        /// Agrega un item en cache.
        /// </summary>
        /// <typeparam name="T">Tipo a agregar</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="value">Objeto a agregar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        private void AddItem<T>(string name, T value, Double minutes) where T : class
        {
            if (value != null)
            {
                if (minutes > 0)
                {
                    _objectCache.Add(name, value, DateTime.Now.AddMinutes(minutes));
                }
                else
                {
                    var cacheItemPolicy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
                    };
                    _objectCache.Add(name, value, cacheItemPolicy);
                }
            }
        }

        /// <summary>
        /// Agrega un item en cache.
        /// </summary>
        /// <typeparam name="T">Tipo a agregar</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="value">Objeto a agregar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        public void SetOrAddItem<T>(string name, T value, Double minutes = 0) where T : class
        {
            if (value != null)
            {
                var result = _objectCache.Get(name);
                if (minutes > 0)
                {
                    if (result != null)
                        _objectCache.Set(name, value, DateTime.Now.AddMinutes(minutes));
                    else
                        _objectCache.Add(name, value, DateTime.Now.AddMinutes(minutes));
                }
                else
                {
                    var cacheItemPolicy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
                    };
                    if (result != null)
                        _objectCache.Set(name, value, cacheItemPolicy);
                    else
                        _objectCache.Add(name, value, cacheItemPolicy);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExisteVariable(string name)
        {
            var objeto = _objectCache.Get(name);
            if (objeto != null)
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void CrearVariable(string name)
        {
            var objeto = _objectCache.Get(name);
            if (objeto == null)
            {
                var temporal = true;
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
                };
                _objectCache.Add(name, temporal, cacheItemPolicy);
            }            
        }        

        #endregion
    }
}