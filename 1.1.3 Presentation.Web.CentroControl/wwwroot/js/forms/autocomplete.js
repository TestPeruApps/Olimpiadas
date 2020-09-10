var selectOk = false;
var autocomplete = {
    iniciarSearchRutaNombre: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("buscarPorTexto", route.ruta, inputSearchId, inputHiddenId, undefined, autocomplete.rutaXnombre.success, autocomplete.rutaXnombre.selected, onSuccessComplete);
    },

    iniciarSearchUsuarioNombre: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("buscarUsuarioPorTexto", route.configuracionPush, inputSearchId, inputHiddenId, undefined, autocomplete.usuarioXnombre.success, autocomplete.usuarioXnombre.selected, onSuccessComplete);
    },

    iniciarsearch: function (metodo, route, inputSearchId, inputHiddenId, inputHiddenId2, functionSuccess, functionSelected, onSuccessComplete, cleanInputs) {        
        var url = "";                
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        $["ui"]["autocomplete"].prototype["_renderItem"] = function (ul, item) {
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append(item.customHtml)
                .appendTo(ul);            
        };
        
        var maxItems = 15;
        var minLength = 3;

        $(inputSearchId).autocomplete({            
            position: { collision: "flip" },
            source: function (request, response) {
                var dataSend = {};
                dataSend["maximoItems"] = maxItems;
                dataSend["filtro"] = request.term;

                $.ajax({
                    url: url, 
                    //dataType: "jsonp",
                    data: dataSend,
                    /*highlight: false,*/
                    success: function (data) {
                        response($.map(data, function (item) {
                            return functionSuccess(item);
                        }));
                    }
                });

                selectOk = false;                                               
                if (inputHiddenId !== undefined) {                    
                    if (cleanInputs == undefined || cleanInputs == true) {
                        $(inputHiddenId).val("");
                    } 
                    if (onSuccessComplete !== undefined) {
                        onSuccessComplete();
                    }
                }
                if ((cleanInputs == undefined || cleanInputs == true) && inputHiddenId2 !== undefined) {
                    $(inputHiddenId2).val("");
                }
            },
            minLength: minLength,
            select: function (event, ui) {
                if (inputHiddenId !== null) {
                    functionSelected(event, ui, inputHiddenId, inputHiddenId2);
                    selectOk = true;
                }                
                if (onSuccessComplete !== undefined) onSuccessComplete(ui.item);
            },            
            open: function () {
                
            },
            close: function () {
            }
        });
    },

    construirFila: function (item) {
        var fila = "";
        fila = fila.concat("<table class='search-default'>",
            "<tr>",
            "<td>", item.nombre, "</td>",
            "</tr>",
            "</table>");
        return fila;
    },

    /************************************************************************************************************************
    RUTAXNOMBRE
    ************************************************************************************************************************/
    rutaXnombre: {
        success: function (item) {
            return {
                nombre: item.nombre,
                value: item.nombre,
                id: item.id,
                customHtml: autocomplete.construirFila(item)
            };
        },

        selected: function (event, ui, inputHiddenId) {
            var rutaId = ui.item ? ui.item.id : "";
            $(inputHiddenId).val(rutaId);
        }
    },

    usuarioXnombre: {
        success: function (item) {
            return {
                nombre: item.nombre,
                value: item.nombre,
                id: item.uniqueId,
                customHtml: autocomplete.construirFila(item)
            };
        },

        selected: function (event, ui, inputHiddenId) {
            var usuarioId = ui.item ? ui.item.id : "";
            $(inputHiddenId).val(usuarioId);
        }
    },
};