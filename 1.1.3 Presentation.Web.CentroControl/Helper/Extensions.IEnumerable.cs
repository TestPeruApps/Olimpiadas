using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

using Olimpiadas.Application.Dto.Comun;

namespace Olimpiadas.Web.CMS.Helper
{
    public static partial class Extensions
    {                
        ///  
        internal static BindingList<SelectListItem> FillForHtml(this IEnumerable<ItemDto> sourceList)
        {
            var destinationList = new BindingList<SelectListItem>();
            if (sourceList == null) return destinationList;            

            foreach (ItemDto it in sourceList)
            {
                destinationList.Add(new SelectListItem
                {
                    Value = it.IdTipo,
                    Text = it.NombreTipo
                });
            }
            return destinationList;
        }

        internal static List<SelectListItem> FillForList(this IEnumerable<ItemDto> sourceList)
        {
            var destinationList = new List<SelectListItem>();
            if (sourceList == null) return destinationList;

            foreach (ItemDto it in sourceList)
            {
                destinationList.Add(new SelectListItem
                {
                    Value = it.IdTipo,
                    Text = it.NombreTipo
                });
            }
            return destinationList;
        }
    }
}