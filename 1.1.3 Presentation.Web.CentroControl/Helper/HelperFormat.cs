using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;

using Olimpiadas.CrossCutting.Enumerations;
using Olimpiadas.CrossCutting.Strings;

namespace Olimpiadas.Web.CMS.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class HelperFormat
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FechaCorta(DateTime? fecha)
        {
            string fechaResult = fecha?.ToString(ResourcesFormatos.FechaCorta) ?? string.Empty;
            return (fechaResult == "01/01/1800") ? string.Empty : fechaResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FechaHoraCorta(DateTime? fecha)
        {
            string fechaResult = fecha?.ToString(ResourcesFormatos.FechaHoraCorta) ?? string.Empty;
            return (fechaResult == "01/01/1800") ? string.Empty : fechaResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public static string Hora(DateTime? hora)
        {
            return hora?.ToString(ResourcesFormatos.Hora) ?? string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public static string Hora(TimeSpan? hora)
        {
            return hora == null
                ? string.Empty
                : new DateTime().Add(hora.Value).ToString(ResourcesFormatos.Hora);
        }

        public static string Numero(decimal? moneda)
        {
            if (moneda == null)
                return string.Empty;
            return moneda.Value.ToString(ResourcesFormatos.Decimal);
        }

        public static HtmlString Porcentaje0Decimales(decimal? cantidad)
        {
            if (cantidad == null)
                return new HtmlString("<span></span>");
            return new HtmlString(string.Concat(cantidad.Value.ToString(ResourcesFormatos.Cantidad), "&nbsp;%"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString NumeroColors(decimal? moneda)
        {
            if (moneda == null)
                return new HtmlString("<span></span>");
            else
            {
                var numeroText = moneda.Value.ToString(ResourcesFormatos.Decimal);
                if (moneda.Value > 0)
                    return new HtmlString(string.Concat("<span class='text-blue'>", numeroText, "</span>"));
                else if (moneda.Value == 0)
                    return new HtmlString(string.Concat("<span class='text-black'>", numeroText, "</span>"));
                else
                    return new HtmlString(string.Concat("<span class='text-red'>", numeroText, "</span>"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaHoraCreacion"></param>
        /// <param name="fechaHoraModificacion"></param>
        /// <param name="usuarioCreacion"></param>
        /// <param name="usuarioModificacion"></param>
        /// <returns></returns>
        public static HtmlString Auditoria(DateTime? fechaHoraCreacion, DateTime? fechaHoraModificacion, string usuarioCreacion, string usuarioModificacion)
        {
            string table = string.Concat("<hr/><table class='table-auditoria'><tr><td>F.Creación</td><td>:</td><td>", HelperFormat.FechaHoraCorta(fechaHoraCreacion), "</td><td>-</td><td>", usuarioCreacion, "</td></tr><tr><td>F.Modificación</td><td>:</td><td>", HelperFormat.FechaHoraCorta(fechaHoraModificacion), "</td><td>-</td><td>", usuarioModificacion, "</td></tr></table>");

            return new HtmlString(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaHoraCreacion"></param>
        /// <param name="fechaHoraModificacion"></param>
        /// <param name="usuarioCreacion"></param>
        /// <param name="usuarioModificacion"></param>
        /// <returns></returns>
        public static HtmlString AuditoriaCreacion(DateTime? fechaHoraCreacion, string usuarioCreacion)
        {
            string table = string.Concat("<hr/><table class='table-auditoria'><tr><td>F.Creación</td><td>:</td><td>", HelperFormat.FechaHoraCorta(fechaHoraCreacion), "</td><td>-</td><td>", usuarioCreacion, "</td></tr></table>");

            return new HtmlString(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaHoraModificacion"></param>
        /// <param name="usuarioModificacion"></param>
        /// <returns></returns>
        public static HtmlString AuditoriaEdicion(DateTime? fechaHoraModificacion, string usuarioEdicion)
        {
            string table = string.Concat("<hr/><table class='table-auditoria'><tr><td>F.Modificación</td><td>:</td><td>", HelperFormat.FechaHoraCorta(fechaHoraModificacion), "</td><td>-</td><td>", usuarioEdicion, "</td></tr></table>");

            return new HtmlString(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString NumeroColors(int? moneda)
        {
            if (moneda == null)
                return new HtmlString("<span></span>");
            else
            {
                var numeroText = moneda.Value.ToString(ResourcesFormatos.DecimalCorto);
                if (moneda.Value > 0)
                    return new HtmlString(string.Concat("<span class='text-blue'>", numeroText, "</span>"));
                else if (moneda.Value == 0)
                    return new HtmlString(string.Concat("<span class='text-black'>", numeroText, "</span>"));
                else
                    return new HtmlString(string.Concat("<span class='text-red'>", numeroText, "</span>"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneda"></param>
        /// <param name="esDolar"></param>
        /// <returns></returns>
        public static HtmlString Moneda(decimal moneda, bool esDolar)
        {
            var result = esDolar ?
                string.Concat("<b>‎US$&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto)) :
                string.Concat("<b>S/&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto));

            return new HtmlString(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneda"></param>
        /// <param name="esDolar"></param>
        /// <returns></returns>
        public static string MonedaText(decimal moneda, bool esDolar)
        {
            var result = esDolar ?
                string.Concat("‎US$ ", moneda.ToString(ResourcesFormatos.DecimalCorto)) :
                string.Concat("S/ ", moneda.ToString(ResourcesFormatos.DecimalCorto));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneda"></param>
        /// <param name="esDolar"></param>
        /// <returns></returns>
        public static HtmlString MonedaColor(decimal moneda, bool esDolar)
        {
            var result = string.Empty;

            if (moneda > 0)
            {
                result = esDolar ?
                string.Concat("<span class='text-blue'><b>‎US$&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto), "</span>") :
                string.Concat("<span class='text-blue'><b>S/&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto), "</span>");
            }
            else
            {
                result = esDolar ?
                string.Concat("<span class='text-black'><b>‎US$&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto), "</span>") :
                string.Concat("<span class='text-black'><b>S/&nbsp;</b>", moneda.ToString(ResourcesFormatos.DecimalCorto), "</span>");
            }

            return new HtmlString(result);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneda"></param>
        /// <param name="esDolar"></param>
        /// <returns></returns>
        public static HtmlString MonedaDiferenteCeroRojoBold(decimal moneda)
        {
            var numeroText = moneda.ToString(ResourcesFormatos.Decimal);
            if (moneda != 0)
                return new HtmlString(string.Concat("<span class='text-red text-bold'>", numeroText, "</span>"));
            else
                return new HtmlString(string.Concat("<span class='text-black'>", numeroText, "</span>"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneda"></param>
        /// <param name="esDolar"></param>
        /// <returns></returns>
        public static HtmlString Moneda(decimal? moneda, bool esDolar)
        {
            if (moneda == null) return new HtmlString(string.Empty);

            var result = esDolar ?
                string.Concat("<spam class='text-redIntenso'><b class='text-font14'>‎$</b>", moneda.Value.ToString(ResourcesFormatos.DecimalCorto), "</spam>") :
                string.Concat("<b>S/.</b>", moneda.Value.ToString(ResourcesFormatos.DecimalCorto));

            return new HtmlString(result);
        }

        public static string Moneda(decimal moneda)
        {
            return "S/. " + moneda.ToString(ResourcesFormatos.Decimal);
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString SiNo(bool? estado)
        {
            if (estado.GetValueOrDefault(false)) return new HtmlString("Si");
            return new HtmlString("No");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString SiNoColors(bool? estado)
        {
            if (estado.GetValueOrDefault(false)) return new HtmlString("<span class='text-blue'>Si</span>");
            return new HtmlString("<span class='text-red'>No</span>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString SiNoNullColors(bool? estado)
        {
            if (estado == null) return new HtmlString("<span class='text-red'>-</span>");
            if (estado.GetValueOrDefault(false)) return new HtmlString("<span class='text-blue'>Si</span>");
            return new HtmlString("<span class='text-red'>No</span>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString SiNoColorsRedSiBold(bool? estado)
        {
            if (estado.GetValueOrDefault(false)) return new HtmlString("<span class='text-red text-bold'>Si</span>");
            return new HtmlString("<span class='text-blue'>No</span>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString SiNoColorsRedNoBold(bool? estado)
        {
            if (estado.GetValueOrDefault(false)) return new HtmlString("<span class='text-blue'>Si</span>");
            return new HtmlString("<span class='text-red text-bold'>No</span>");
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="permisoSet"></param>
        /// <returns></returns>
        public static HtmlString ColumnSet(int id1, int id2, bool permisoSet = true)
        {
            if (permisoSet)
                return new HtmlString(string.Format(ResourcesElementoHtml.ColumnSet_IdNumeric_2Params, id1.ToString(), id2.ToString()));
            return new HtmlString("<td></td>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permisoSet"></param>
        /// <returns></returns>
        public static HtmlString ColumnSet(int? id, bool permisoSet = true)
        {
            if (permisoSet)
            {
                if (id != null)
                    return new HtmlString(string.Format(ResourcesElementoHtml.ColumnSet_IdNumeric, id.Value));
                return new HtmlString("<td></td>");
            }
            return new HtmlString("<td></td>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activo"></param>
        /// <param name="id"></param>
        /// <param name="permisoActivar"></param>
        /// <param name="permisoDesactivar"></param>
        /// <returns></returns>
        public static HtmlString ColumnActivarDesactivar(bool? activo, int id, bool permisoActivar = true, bool permisoDesactivar = true)
        {
            if (activo.GetValueOrDefault(true))
                return (permisoDesactivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnDesactivar_IdString, id)) : new HtmlString("<td></td>");
            return (permisoActivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnActivar_IdString, id)) : new HtmlString("<td></td>");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activo"></param>
        /// <param name="id"></param>
        /// <param name="permisoActivar"></param>
        /// <param name="permisoDesactivar"></param>
        /// <returns></returns>
        public static HtmlString ColumnActivarDesactivar(bool? activo, int? id, bool permisoActivar = true, bool permisoDesactivar = true)
        {
            if (id != null)
                return ColumnActivarDesactivar(activo, id.Value, permisoActivar, permisoDesactivar);
            return new HtmlString("<td></td>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activo"></param>
        /// <param name="functionJsDesactivar"></param>
        /// <param name="functionJsActivar"></param>
        /// <param name="id"></param>
        /// <param name="permisoActivar"></param>
        /// <param name="permisoDesactivar"></param>
        /// <returns></returns>
        public static HtmlString ColumnActivarDesactivar(bool? activo, string functionJsDesactivar, string functionJsActivar, int? id, bool permisoActivar = true, bool permisoDesactivar = true)
        {
            if (id != null)
                return ColumnActivarDesactivar(activo, functionJsDesactivar, functionJsActivar, id.Value, permisoActivar, permisoDesactivar);
            return new HtmlString("<td></td>");
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activo"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="permisoActivar"></param>
        /// <param name="permisoDesactivar"></param>
        /// <returns></returns>
        public static HtmlString ColumnActivarDesactivar(bool? activo, int? id1, int? id2, bool permisoActivar = true, bool permisoDesactivar = true)
        {
            if (id1 != null && id2 != null)
            {
                if (activo.GetValueOrDefault(true))
                    return (permisoDesactivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnDesactivar_IdNumeric_2Params, id1.Value.ToString(), id2.Value.ToString())) : new HtmlString("<td></td>");
                return (permisoDesactivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnActivar_IdNumeric_2Params, id1.Value.ToString(), id2.Value.ToString())) : new HtmlString("<td></td>");
            }
            return new HtmlString("<td></td>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activo"></param>
        /// <param name="functionJsDesactivar"></param>
        /// <param name="functionJsActivar"></param>
        /// <param name="id"></param>
        /// <param name="permisoActivar"></param>
        /// <param name="permisoDesactivar"></param>
        /// <returns></returns>
        public static HtmlString ColumnActivarDesactivar(bool? activo, string functionJsDesactivar, string functionJsActivar, int id, bool permisoActivar = true, bool permisoDesactivar = true)
        {
            if (activo.GetValueOrDefault(true))
                return (permisoDesactivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnDesactivar_IdString, functionJsDesactivar, id)) : new HtmlString("<td></td>");
            return (permisoActivar) ? new HtmlString(string.Format(ResourcesElementoHtml.ColumnActivar_IdString, functionJsActivar, id)) : new HtmlString("<td></td>");
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionJsEliminar"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="permisoEliminar"></param>
        /// <returns></returns>
        public static HtmlString ColumnDel(string functionJsEliminar, int id1, int id2, bool permisoEliminar = true)
        {
            if (permisoEliminar)
                return new HtmlString(string.Format(ResourcesElementoHtml.ColumnDesactivar_IdNumeric_2Params, functionJsEliminar, id1.ToString(), id2.ToString()));
            return new HtmlString("<td></td>");
        }

        public static string ImagenJpg(string nombre)
        {
            return string.Concat(nombre, ".jpg");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString LinkVariaciones(string variacionesId, string variacionesDescripcion, string jsFunctionSelect)
        {
            string result = string.Empty;
            try
            {
                var ids = variacionesId.Split(new[] { " " }, StringSplitOptions.None);
                var values = variacionesDescripcion.Split(new[] { "#$%" }, StringSplitOptions.None);
                int index = 0;

                foreach (var item in values)
                {
                    if (string.IsNullOrEmpty(result))
                        result = string.Concat(result, "<a onclick='", jsFunctionSelect, "(", ids[index], ",this);'>", item, "</a>");
                    else
                        result = string.Concat(result, "&nbsp;&nbsp;&nbsp;&nbsp;<a onclick='", jsFunctionSelect, "(", ids[index], ",this);'>", item, "</a>");
                    index += 1;
                }
                return new HtmlString(result);
            }
            catch (Exception ex)
            {
                return new HtmlString(string.Concat("<span class='text-red'>Error: ", ex.Message,"</span>"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString PermisosLinkAdd(List<short?> opciones, short opcionConPermiso)
        {
            if (opciones.Exists(x => x.Value == opcionConPermiso))            
                return new HtmlString("<a class='btn btn-info btn-sm btn-agregar'><i class='fa fa-plus'></i></a>");
            return HtmlString.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlEnTexto"></param>
        /// <returns></returns>
        public static HtmlString ObtenerHtml(string htmlEnTexto)
        {
            return new HtmlString(htmlEnTexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlEnTexto"></param>
        /// <returns></returns>
        public static HtmlString ObtenerHtmlSinParrafo(string htmlEnTexto)
        {
            return new HtmlString(htmlEnTexto.Replace("<p>", "").Replace("</p>", ""));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static HtmlString PermisosSubmitSearch(List<short?> opciones, short opcionConPermiso)
        {
            if (opciones.Exists(x => x.Value == opcionConPermiso))
                return new HtmlString("<button type='submit' class='btn btn-info btn-sm'><i class='fa fa-search'></i></button>");
            return HtmlString.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public static HtmlString PermisosSubmitSearch(List<short?> opciones, bool ver)
        {
            if (ver)
                return new HtmlString("<button type='submit' class='btn btn-info btn-sm'><i class='fa fa-search'></i></button>");
            return HtmlString.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public static HtmlString ConvertirATextoConSaltosDeLinea(string texto)
        {
            return new HtmlString(texto.Replace(System.Environment.NewLine, "<br />"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="opcionConPermiso"></param>
        /// <returns></returns>
        public static bool PermisosExists(List<short> opciones, short opcionConPermiso)
        {
            if (opciones == null) return false;
            if (opciones.Exists(x => x == opcionConPermiso))
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static string MostrarMayorCero(short? cantidad)
        {
            if (cantidad == null) return string.Empty;
            else
            {
                if (cantidad.Value == 0)
                    return string.Empty;
                else
                    return cantidad.Value.ToString(ResourcesFormatos.Cantidad);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formato"></param>
        /// <returns></returns>
        public static string TipoArchivo(EnumFormatoReporte formato)
        {
            string result = string.Empty;
            switch (formato)
            {
                case EnumFormatoReporte.PortableDocFormat: result = "application / pdf"; break;
                case EnumFormatoReporte.NoFormat: result = "application / pdf"; break;
                case EnumFormatoReporte.Excel: result = "application / xlsx"; break;
                case EnumFormatoReporte.ExcelRecord: result = "application / xls"; break;
                case EnumFormatoReporte.Text: result = "application / txt"; break;
                case EnumFormatoReporte.WordForWindows: result = "application / doc"; break;
                case EnumFormatoReporte.Xml: result = "application / xml"; break;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoRangoFecha"></param>
        /// <param name="tipoRangoFechaAsignado"></param>
        /// <returns></returns>
        public static string ClaseFiltroFecha(EnumTipoRangoFecha tipoRangoFecha, EnumTipoRangoFecha tipoRangoFechaAsignado)
        {
            if (tipoRangoFecha == tipoRangoFechaAsignado)
                return "in";
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlIconos"></param>
        /// <param name="iconoId"></param>
        /// <returns></returns>
        public static HtmlString CeldaIconografia(string urlIconos, string iconoId)
        {            
            var icono = string.Concat(urlIconos, iconoId, ".png");
            var celda = string.Concat("<td class='centro'><img class='invertido mb-10' src='", icono, "' /></td>");
            return new HtmlString(celda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista">lista de ids de la iconografia</param>
        /// <param name="urlIconos">url de las imagenes de iconografia</param>
        /// <param name="filas">cantidad de filas de la tabla</param>
        /// <param name="columnas">cantidad de columans de la tabla</param>
        /// <param name="destinoId">id. del destino</param>
        /// <returns></returns>
        public static HtmlString CeldaIconografia(string[] lista, string urlIconos, int filas, int columnas, string destinoId = null, string tooltip = null)
        {
            string resultado = "<td class='column-thumbnail-30 column-center'";
            if (tooltip != null)
                resultado = string.Concat(resultado, " title='", tooltip);
            resultado = string.Concat(resultado, "'><table><tbody>");
            for (var f = 0; f <= filas; f++)
            {
                resultado = string.Concat(resultado, "<tr>");
                foreach (var e in lista.Skip(f * columnas).Take(columnas))
                {
                    var iconoId = destinoId == null ? e : string.Concat(e, "_", destinoId);
                    var celda = string.Concat("<td class='centro'><img class='invertido mb-10' src='", urlIconos, iconoId, ".png' /></td>");
                    resultado = string.Concat(resultado, celda);
                }
                resultado = string.Concat(resultado, "</tr>");
            }
            resultado = string.Concat(resultado, "</tbody>", "</table>", "</td>");
            return new HtmlString(resultado);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="urlImagen"></param>
        /// <param name="formato"></param>
        /// <returns></returns>
        public static HtmlString EditorImagen(string urlImagen, string nombreImagen)
        {
            /*
            if (string.IsNullOrEmpty(nombreImagen) == false)
            {
                var texto_imagen = nombreImagen.Replace("?", " ");
                texto_imagen = texto_imagen.Replace("=", " ");
                texto_imagen = texto_imagen.Replace("version", "versión:");

                var link = string.Concat("<a href='", urlImagen, "' data-lightbox='", texto_imagen, "' data-title='", texto_imagen, "'>", texto_imagen, "</a>");                
                return new HtmlString(link);
            }
            return new HtmlString(string.Empty);*/


            if (string.IsNullOrEmpty(nombreImagen) == false)
            {
                var texto_imagen = nombreImagen.Replace("?", " ");
                texto_imagen = texto_imagen.Replace("=", " ");
                texto_imagen = texto_imagen.Replace("version", "versión:");

                var link = string.Concat("<a target='_blank' href='", urlImagen, "'>", texto_imagen, "</a>");
                return new HtmlString(link);
            }
            return new HtmlString(string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlImagen"></param>
        /// <param name="dataLightbox"></param>
        /// <param name="title"></param>
        /// <param name="urlError"></param>
        /// <returns></returns>
        public static HtmlString ImagenConPopUp(string urlImagen, string dataLightbox, string title, string urlError)
        {
            var texto = string.Concat(
                "<a href=", urlImagen," data-lightbox=", dataLightbox, " data-title=", title, "> <img src=", urlImagen, 
                " onerror=\"this.onerror = null; this.src='", urlError,"'\"> </a>");
            return new HtmlString(texto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantEstrellasTotal"></param>
        /// <param name="cantEstrellasPintadas"></param>
        /// <returns></returns>
        public static HtmlString EstrellasCelda(byte cantEstrellasTotal, byte cantEstrellasPintadas)
        {
            var texto = string.Empty;
            int cantEstrellasVacias = cantEstrellasTotal - cantEstrellasPintadas;

            for (var i = 0; i < cantEstrellasPintadas; i++)
                texto = string.Concat(texto, "<i class='fa fa-star text-blue'></i>");

            for (var i = 0; i < cantEstrellasVacias; i++)
                texto = string.Concat(texto, "<i class='fa fa-star-o text-blue'></i>");

            return new HtmlString(texto);
        }
    }
}