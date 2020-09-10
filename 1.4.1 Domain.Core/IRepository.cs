using System;
using System.Collections.Generic;

using Olimpiadas.Application.Dto.Comun;

namespace Olimpiadas.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository<TEntidad> : IDisposable
        where TEntidad : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        List<TEntidad> Listar(ParametroAccesosDatos parametroAccesosDatos);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResultado"></typeparam>
        /// <param name="parametroAccesosDatos"></param>
        /// <param name="filtro"></param>
        /// <param name="criteriosPaginacion"></param>
        /// <returns></returns>
        Paginado<TResultado> Paginar<TResultado>(ParametroAccesosDatosTipado parametroAccesosDatos, TResultado filtro, CriteriosPaginacionDto criteriosPaginacion)
            where TResultado : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <returns></returns>
        TEntidad Obtener(ParametroAccesosDatos parametroAccesosDatos);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroAccesosDatos"></param>
        /// <param name="entidad"></param>
        void Ejecutar(ParametroAccesosDatosTipado parametroAccesosDatos, TEntidad entidad);

        /// <summary>
        /// 
        /// </summary>
        void IniciarTransaccion();

        /// <summary>
        /// 
        /// </summary>
        void FinalizarTransaccion();
    }
}