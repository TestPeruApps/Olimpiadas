using System;

using Olimpiadas.Application.Dto.Comun;
using Olimpiadas.CrossCutting.Helper.Exceptions;
using Olimpiadas.CrossCutting.Strings;
using Olimpiadas.Domain.Entities.Extensions;
using Olimpiadas.Domain.Entities.Resources;

namespace Olimpiadas.Domain.Entities.GestionContenido
{
    /// <summary>
    /// Lógica de negocio del manejo de Personal.
    /// </summary>
    public partial class Personal
    {
        #region VARIABLES

        /// <summary>
        /// Texto del mensaje de validación.
        /// </summary>
        private string _mensaje;

        #endregion


        #region MÉTODOS

        /// <summary>
        /// Lógica de negocio para agregar una Personal.
        /// </summary>
        /// <param name="auditoria">Datos de auditoría.</param>
        public void Insertar(AuditoriaDto auditoria)
        {
            //REGLA: Validar que las propiedades tengan valores asignados.
            ValidarAsignacionValores(this, true);

            //Asignacion de valores de auditoría
            AsignarAuditoriaAgregar(auditoria);

            //REGLA: Asignamos valores por defecto
            AsignarValoresPorDefecto();
        }

        /// <summary>
        /// Lógica de negocio para actualizar una Personal.
        /// </summary>
        /// <param name="PersonalNuevosValores">Personal con nuevos valores.</param>
        /// <param name="auditoria">Datos de auditoría.</param>
        public void Actualizar(Personal PersonalNuevosValores, AuditoriaDto auditoria)
        {
            //REGLA: Validar que las propiedades tengan valores asignados. 
            ValidarAsignacionValores(PersonalNuevosValores, false);

            //REGLA: Asignamos valores modificados
            NombrePersonal = PersonalNuevosValores.NombrePersonal;
            DniPersonal = PersonalNuevosValores.DniPersonal;
            Activo = PersonalNuevosValores.Activo;

            //Asignacion de valores de auditoría
            AsignarAuditoriaEdicion(auditoria);

            //REGLA: Asignamos valores por defecto
            AsignarValoresPorDefecto();
        }


        /// <summary>
        /// Lógica de negocio para desactivar una Personal.
        /// </summary>
        /// <param name="auditoria">Datos de auditoría.</param>
        public void Desactivar(AuditoriaDto auditoria)
        {
            Activo = false;
            AsignarAuditoriaEdicion(auditoria);
        }

        /// <summary>
        /// Lógica de negocio para activar una Personal.
        /// </summary>
        /// <param name="auditoria">Datos de auditoría.</param>
        public void Activar(AuditoriaDto auditoria)
        {
            Activo = true;
            AsignarAuditoriaEdicion(auditoria);
        }

        #endregion



        #region MÉTODOS DE APOYO

        /// <summary>
        /// Valida que las propiedades tengan valores asignados.
        /// </summary>
        /// <param name="PersonalNuevosValores">Personal con nuevos valores.</param>
        /// <param name="esAgregar">Indica si la validación es para insertar una Personal.</param>
        private void ValidarAsignacionValores(Personal PersonalNuevosValores, bool esAgregar)
        {
            string propiedadesObservadas = string.Empty;

            /*VALIDAMOS ASIGNACION*/
            PersonalNuevosValores.NombrePersonal.ValidarAsignacion("Nombre", ref propiedadesObservadas);
            PersonalNuevosValores.DniPersonal.ValidarAsignacion("DNI", ref propiedadesObservadas);

            //Devolvemos mensaje de validación
            if (!string.IsNullOrEmpty(propiedadesObservadas))
            {
                _mensaje = string.Format(Messages.GeneralAsignacionValores, propiedadesObservadas);
                throw new BusinessException(_mensaje);
            }
        }

        /// <summary>
        /// Asigna los valores por defecto.
        /// </summary>
        private void AsignarValoresPorDefecto()
        {
            //Esta entidad no tiene valores por defecto
        }

        /// <summary>
        /// Asigna los valores de auditoría al insertar una Personal.
        /// </summary>
        /// <param name="auditoria">Datos de auditoría.</param>
        private void AsignarAuditoriaAgregar(AuditoriaDto auditoria)
        {
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Asigna los valores de auditoría al modificar una Personal.
        /// </summary>
        /// <param name="auditoria">Datos de auditoría.</param>
        private void AsignarAuditoriaEdicion(AuditoriaDto auditoria)
        {
            FechaModificacion = DateTime.Now;
        }

        #endregion
    }
}