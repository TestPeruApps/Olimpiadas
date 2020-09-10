var baseGrid = {
    call: function (route, id, updateTargetId, metodo, data, senderSelected) {
        if (metodo == undefined) {
            metodo = "index";
        }
        var url = "";
        if (id == undefined)
            url = route.area + "/" + route.controller + "/" + metodo + "/";
        else
            url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
        
        var params = {
            url: url,
            data:data,
            updateTargetId: updateTargetId,
            senderSelected: senderSelected
        };
        helperAjax.sendGet(params);
    },
    /*    
    route: {
        area, 
        controller, 
        idTab
    }
    */
    //carga el tab, si ya existe lo reemplaza
    callInTab: function (route, titulo, method, nombreClassUlTab, data, id) {
        var url;
        if (method === undefined) {
            url = route.area + "/" + route.controller + "/" + route.method + "/";
        } else {
            url = route.area + "/" + route.controller + "/" + method + "/";
        }
        if (id != undefined) {
            url = url + "/" + id;        
        }
        
        if (titulo === undefined) titulo = route.titulo;
        var params = {
            url: url,
            data: data,
            onSuccess: function (data1, textStatus, jqXhr) {
                var divTab = $("div#tab-main");
                var ulTab = $("ul#ul-tab-main");
                var divContent = $(divTab).find(route.idTab);
                $(divTab).find(">div.active").removeClass("active");
                $(ulTab).find(">li.active").removeClass("active");

                if (divContent.length > 0) {
                    $(divContent).html(data1);
                    $(divContent).addClass("active");
                    $(ulTab).find(">li>a[href='" + route.idTab + "']").parent().addClass("active");
                } else {
                    var menuId = route.idTab.substr(1);
                    if (nombreClassUlTab === undefined) {
                        $(ulTab).append("<li role='presentation' id='" + menuId + "Menu' class='active'><a data-toggle='pill' href='" + route.idTab + "'>" + titulo + "&nbsp<i data='" + menuId +"' class='fa fa-times'></i></a></li>");                        
                    } else {
                        $(ulTab).append("<li role='presentation' id='" + menuId + "Menu' class='active " + nombreClassUlTab + "'><a data-toggle='pill' href='" + route.idTab + "'>" + titulo + "&nbsp<i data='" + menuId +"' class='fa fa-times'></i></a></li>");
                    }
                    $("#" + menuId + "Menu a i").on("click", function () {
                        var data = $(this).attr("data");
                        baseGrid.closeTab("#" + data);
                    });
                    $(divTab).append("<div id='" + route.idTab.substr(1) + "' class='tab-pane active'>" + data1 + "</div>");
                }
            }
        };
        helperAjax.sendGet(params);
    },

    closeTab: function (idTab) {
        $(idTab).remove();
        $(idTab + "Menu").remove();        
    },

    //busca el tab si existe lo selecciona, si no existe lo carga
    callOrRefreshInTab: function (route, data, method) {
        var tab = $('#ul-tab-main a[href="' + route.idTab + '"]');
        var divTab = $("div#tab-main");
        var ulTab = $("ul#ul-tab-main");

        if (tab.length === 0) {
            if (data === undefined) {
                baseGrid.callInTab(route, undefined, method);
            } else {
                //Si existe data pero aún existe panel se crea el html                
                $(divTab).find(">div.active").removeClass("active");
                $(ulTab).find(">li.active").removeClass("active");

                $(ulTab).append("<li role='presentation' class='active'><a data-toggle='pill' href='" + route.idTab + "'>" + route.titulo + "</a></li>");
                $(divTab).append("<div id='" + route.idTab.substr(1) + "' class='tab-pane active'>" + data + "</div>");
            }
            return false;
        } else {
            var divContent = $(divTab).find(route.idTab);
            $(divTab).find(">div.active").removeClass("active");
            $(ulTab).find(">li.active").removeClass("active");

            $(divContent).html(data);
            $(tab).tab('show');
            return true;
        }
    },

    isInTab: function (route) {
        var tab = $('#ul-tab-main a[href="' + route.idTab + '"]');
        if (tab.length === 0) {
            return false;
        } else {
            return true;
        }
    },

    /*
        route: {                OBLIGATORIO
            area,               OBLIGATORIO
            controller,         OBLIGATORIO
            idTab               OBLIGATORIO
        },    
        idFormGrid,             OBLIGATORIO   
        idWrapperGrid,          OBLIGATORIO
        addFunction             OBLIGATORIO
        */
    load: function (route, idFormGrid, updateTargetId, addFunction, desactivarFunction, activarFunction,  findFunction, metodoFind) {
        var formGridContent = $(route.idTab + " " + idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(idFormGrid);
        }

        if (addFunction !== undefined) {
            $(formGridContent).find(".btn-agregar").on("click", function () {
                addFunction();
            });

            $(formGridContent).find(".column-set a").on("click", function () {
                var id1 = $(this).attr("data1");
                var id2 = $(this).attr("data2");

                if (id2 === undefined) {
                    addFunction(id1);
                } else {
                    addFunction(id1, id2);
                }                                
            });
        }

        if (desactivarFunction !== undefined) {
            $(formGridContent).find(".column-del a").on("click", function () {
                var id1 = $(this).attr("data1");
                var id2 = $(this).attr("data2");

                if (id2 === undefined) {
                    desactivarFunction(id1);
                } else {
                    desactivarFunction(id1, id2);
                }
            });
        }

        if (activarFunction !== undefined) {
            $(formGridContent).find(".column-activar a").on("click", function () {
                var id1 = $(this).attr("data1");
                var id2 = $(this).attr("data2");

                if (id2 === undefined) {
                    activarFunction(id1);
                } else {
                    activarFunction(id1, id2);
                }
            });
        }

        $(formGridContent).find(".btn-search").on("click", function () {
            if (findFunction === undefined) {
                baseGrid.find(route, idFormGrid, metodoFind, updateTargetId, 1);
            } else {
                findFunction();
            }
        });

        $(formGridContent).find(".column-clean a").on("click", function () {
            baseGrid.cleanFilter($(this), idFormGrid);
        });

        $(formGridContent).find(".filterText").each(function () {
            if ($(this).val() === "") {
                $(this).removeClass("conFiltro").addClass("sinFiltro");
            } else {
                $(this).removeClass("sinFiltro").addClass("conFiltro");
            }

            $(this).on('input', function () {
                if ($(this).val() === "") {
                    $(this).removeClass("conFiltro").addClass("sinFiltro");
                } else {
                    $(this).removeClass("sinFiltro").addClass("conFiltro");
                }
            });
        });

        $(formGridContent).find(".filterSelect").each(function () {
            if ($(this).val() === "") {
                $(this).removeClass("conFiltro").addClass("sinFiltro");
            } else {
                $(this).removeClass("sinFiltro").addClass("conFiltro");
            }

            $(this).on('change', function () {
                if ($(this).val() === "") {
                    $(this).removeClass("conFiltro").addClass("sinFiltro");
                } else {
                    $(this).removeClass("sinFiltro").addClass("conFiltro");
                }
            });
        });

        baseGrid.pagination(route, idFormGrid, undefined, updateTargetId);
    },

    /*
       route: {                OBLIGATORIO
           area,               OBLIGATORIO
           controller,         OBLIGATORIO
           idTab               OBLIGATORIO
       },    
       idFormGrid,             OBLIGATORIO   
       idWrapperGrid,          OBLIGATORIO
       addFunction             OBLIGATORIO
       */
    loadInModal: function (route, idFormGrid, idWrapperGrid, addFunction, findFunction) {
        var formGridContent = $(idFormGrid);        

        if (addFunction !== undefined) {
            $(formGridContent).find(".btn-agregar").on("click", function () {
                addFunction();
            });
        }

        $(formGridContent).find(".btn-search").on("click", function () {
            if (findFunction === undefined) {
                baseGrid.find(route, idFormGrid, undefined, idWrapperGrid, 1);
            } else {
                findFunction();
            }
        });

        $(formGridContent).find(".filterText").each(function () {
            if ($(this).val() === "") {
                $(this).removeClass("conFiltro").addClass("sinFiltro");
            } else {
                $(this).removeClass("sinFiltro").addClass("conFiltro");
            }

            $(this).on('input', function () {
                if ($(this).val() === "") {
                    $(this).removeClass("conFiltro").addClass("sinFiltro");
                } else {
                    $(this).removeClass("sinFiltro").addClass("conFiltro");
                }
            });
        });

        $(formGridContent).find(".filterSelect").each(function () {
            if ($(this).val() === "") {
                $(this).removeClass("conFiltro").addClass("sinFiltro");
            } else {
                $(this).removeClass("sinFiltro").addClass("conFiltro");
            }

            $(this).on('change', function () {
                if ($(this).val() === "") {
                    $(this).removeClass("conFiltro").addClass("sinFiltro");
                } else {
                    $(this).removeClass("sinFiltro").addClass("conFiltro");
                }
            });
        });

        baseGrid.pagination(route, idFormGrid, undefined, idWrapperGrid);
    },

    /*
    route: {                OBLIGATORIO
        area,               OBLIGATORIO
        controller,         OBLIGATORIO
        idTab               OBLIGATORIO
    },    
    idFormGrid,             OBLIGATORIO   
    searcher: {             OPCIONAL        
        metodo                  OPCIONAL
        idWrapperGrid,          OBLIGATORIO
    }, 
    add: {                  OPCIONAL
        onOpen                  OBLIGATORIO
        data                    OPCIONAL
    },
    hover: {             OPCIONAL
        idTabla                 OBLIGATORIO
    },
    selected: {             OPCIONAL
        idTabla,                OBLIGATORIO
        indexGrid               OBLIGATORIO
    }
    */
    loadCustom: function (options) {
        var formGridContent = $(options.route.idTab + " " + options.idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(options.idFormGrid);
        }

        if (options.add !== undefined) {
            $(formGridContent).find(".btn-add").on("click", function (e) {
                options.add.onOpen(options.add.data);
            });
        }

        if (options.searcher !== undefined) {
            $(formGridContent).find(".btn-find").on("click", function (e) {
                baseGrid.find(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid, 1);
            });
        }

        baseGrid.pagination(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid);

        if (options.hover !== undefined) {
            var idTabla1 = options.hover.idTabla;
            if (idTabla1 !== undefined) {
                $(idTabla1 + ' tbody tr').hover(function () {
                    $(this).toggleClass('row_mouseOver');
                });
            }
        }

        if (options.selected !== undefined) {
            var idTabla2 = options.selected.idTabla;
            var indexGrid = options.selected.indexGrid;
            if (idTabla2 !== undefined && indexGrid != undefined) {
                //Obtenemnos el id seleccionado
                var rowSelectedId = helperConstantes.getRowSelected(indexGrid);
                //recorremos las filas y si esta el Id lo seleccionamos
                if (rowSelectedId !== undefined) {
                    $(idTabla2 + ' tbody tr').each(function () {
                        var itemId = $(this).find("input#itemId").val();
                        if (itemId === rowSelectedId) {
                            $(this).toggleClass('row_mouseSelected');
                        }
                    });
                }

                $(idTabla2 + ' tbody tr').click(function () {
                    $(idTabla2 + ' tbody tr.row_mouseSelected').removeClass("row_mouseSelected");
                    $(this).toggleClass('row_mouseSelected');
                    var itemSelectedId = $(this).find("input#itemId").val();
                    helperConstantes.setRowSelected(indexGrid, itemSelectedId);
                });
            }
        }

        var totalRegistros = $(formGridContent).find('#totalRegistroBandeja').val();
        $(formGridContent).find('#totRegistro').html(totalRegistros);
    },

    find: function (route, idFormGrid, metodo, updateTargetId, pageIndex, id) {
        var formGridContent = $(route.idTab + " " + idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(idFormGrid);
        }
        if (pageIndex != undefined) {
            $(formGridContent).find("#Index").val(pageIndex);
        }
        if (metodo == undefined) metodo = "index";

        var url = "";
        if (route.area == undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        var data = undefined;
        if (id != undefined) {
            url = url + "/" + id;
        } else {
            data = $(formGridContent).serialize();
        }

        var params = {
            url: url,
            data: data,
            updateTargetId: updateTargetId
        };

        helperAjax.sendGet(params);
    },

    pagination: function (route, idFormGrid, metodo, updateTargetId) {
        var formGridContent = $(route.idTab + " " + idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(idFormGrid);
        }

        var contentPagination = $(formGridContent).find("ul.pagination");
        $(contentPagination).find("a").each(function (index, value) {
            $(this).attr("href", "#");

            $(this).on("click", function (e) {
                e.preventDefault();

                if ($(this).parent().attr("class") !== "disabled") {
                    var index = $(this).html();
                    if (index === "«") {
                        index = parseInt($(idFormGrid).find("#Index").val()) - 1;
                    }
                    else if (index === "»") {
                        index = parseInt($(idFormGrid).find("#Index").val()) + 1;
                    }
                    else if (index === "&lt;") {
                        index = 1;
                    }
                    else if (index === "&gt;") {
                        var totalItems = parseInt($(idFormGrid).find("#TotalItems").val());
                        var size = parseInt($(idFormGrid).find("#Size").val());
                        index = parseInt(totalItems / size);
                        if (totalItems % size > 0)
                            index++;
                    }
                    baseGrid.find(route, idFormGrid, metodo, updateTargetId, index);
                }
            });
        });

    },

    headerUpdate: function (formContent, idRowFilter) {
        baseGrid.unirGridconFiltro(formContent, idRowFilter);
        helperGrid.headerArrow(formContent, idRowFilter);
    },

    /*
    route: {                OBLIGATORIO
        area,               OBLIGATORIO
        controller,         OBLIGATORIO
        idTab               OBLIGATORIO
    },
    metodo:            OBLIGATORIO
    id:                OPCIONAL*
    data: {}           OPCIONAL*
    updateTargetId:    OPCIONAL
    idWrapperEditor:   OPCIONAL
    messageSuccess     OPCIONAL
    onSuccess          OPCIONAL   
    onErrorComplete    OPCIONAL
    type               OPCIONAL, por defecto POST,    
    */
    ejecutarAccion: function (options) {

        //Mensaje
        if (options.messageSuccess === undefined) options.messageSuccess = "Operación satisfactoria";

        //URL
        var url = "";
        if (options.route.area === undefined) {
            url = options.route.controller + "/" + options.metodo;
        } else {
            url = options.route.area + "/" + options.route.controller + "/" + options.metodo;
        }
        if (options.id !== undefined) {
            url = url + "/" + options.id;
        }
        if (options.route.area === "") {
            url = options.route.controller + "/" + options.metodo;
        }

        //Partametros Ajax
        var params = {
            url: url,
            data: options.data,
            processData: options.processData,
            contentType: options.contentType,
            datatype: options.datatype,
            updateTargetId: options.updateTargetId,
            onSuccess: options.onSuccess,
            onSuccessComplete: options.onSuccessComplete,
            onErrorComplete: options.onErrorComplete,
            idWrapperEditor: options.idWrapperEditor,
            messageSuccess: options.messageSuccess,
            messageConfirmation: options.messageConfirmation
        };

        if (options.type === undefined)
            helperAjax.sendPost(params);
        else if (options.type === "POST") {
            helperAjax.sendPost(params);
        }
        else if (options.type === "GET") {
            helperAjax.sendGet(params);
        }
    },

    insertar: function (route, idFormEditor, idFormGrid, updateTargetId, close, metodo, messageSuccess, preservedSelected) {
        var url = "";
        if (metodo === undefined) metodo = "insertar";
        if (messageSuccess === undefined) messageSuccess = "Registro satisfactorio";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        var data = $(idFormEditor).serialize();
        if (idFormGrid !== undefined) {
            data = data + "&" + $(idFormGrid).serialize();
        }

        var params = {
            url: url,
            data: data,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close,
            preservedSelected: preservedSelected
        };
        helperAjax.sendPost(params);
    },

    insertarConArchivo: function (route, idFormEditor, idFormGrid, updateTargetId, close, metodo, messageSuccess, preservedSelected) {
        var url = "";
        if (metodo === undefined) metodo = "insertar";
        if (messageSuccess === undefined) messageSuccess = "Registro satisfactorio";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        var formData = new FormData();
        var params = $(idFormEditor).serializeArray();
        var fileInputs = $(idFormEditor).find('[type="file"]');

        $.each(fileInputs, function (i, input) {
            var nombre = $(input).attr("name");
            var files = $(input)[0].files;
            $.each(files, function (i, file) {
                formData.append(nombre, file);
            });
        });
        $.each(params, function (i, val) {
            formData.append(val.name, val.value);
        });

        if (idFormGrid != undefined) {
            var params1 = $(idFormGrid).serializeArray();

            $.each(params1, function (i, val) {
                formData.append(val.name, val.value);
            });
        }

        var params = {
            url: url,
            data: formData,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close,
            processData: false,
            contentType: false,
            preservedSelected: preservedSelected
        };
        helperAjax.sendPost(params);
    },


    actualizar: function (route, idFormEditor, idFormGrid, updateTargetId, close, metodo, messageSuccess, preservedSelected) {
        var url = "";
        if (metodo === undefined) metodo = "actualizar";
        if (messageSuccess === undefined) messageSuccess = "Registro satisfactorio";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        var data = $(idFormEditor).serialize();
        if (idFormGrid !== undefined) {
            data = data + "&" + $(idFormGrid).serialize();
        }

        var params = {
            url: url,
            data: data,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close,
            preservedSelected: preservedSelected
        };
        helperAjax.sendPost(params);
    },

    actualizarConArchivo: function (route, idFormEditor, idFormGrid, updateTargetId, close, metodo, messageSuccess, preservedSelected) {
        var url = "";
        if (metodo === undefined) metodo = "actualizar";
        if (messageSuccess === undefined) messageSuccess = "Registro satisfactorio";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }        
        var formData = new FormData();
        var params = $(idFormEditor).serializeArray();
        var fileInputs = $(idFormEditor).find('[type="file"]');

        $.each(fileInputs, function (i, input) {
            var nombre = $(input).attr("name");
            var files = $(input)[0].files;
            $.each(files, function (i, file) {                
                formData.append(nombre, file);
            });
        });
        $.each(params, function (i, val) {
            formData.append(val.name, val.value);
        });

        if (idFormGrid != undefined) {
            var params1 = $(idFormGrid).serializeArray();

            $.each(params1, function (i, val) {
                formData.append(val.name, val.value);
            });
        }

        var params = {
            url: url,
            data: formData,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close,
            processData: false,
            contentType: false,
            preservedSelected: preservedSelected
        };

        helperAjax.sendPost(params);       
    },

    eliminar: function (route, id, updateTargetId, metodo, idFormGrid) {
        var url = "";
        if (metodo == undefined) metodo = "eliminar";
        if (idFormGrid != undefined) {
            if (route.area == undefined) {
                url = route.controller + "/" + metodo + "/";
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/";
            }
        } else {
            if (route.area == undefined) {
                url = route.controller + "/" + metodo + "/" + id;
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
            }
        }

        var params = {
            url: url,
            messageSuccess: "Operación satisfactoria",
            updateTargetId: updateTargetId
        };

        if (idFormGrid != undefined) {
            var dataGrid = $(idFormGrid).serialize();
            params.data = dataGrid + "&id=" + id;
        }

        helperAjax.sendPost(params);
    },

    /*
    selected: true o false: indica si debe mantenerse seleccionado la fila
    */
    activar: function (route, id, idFormGrid, updateTargetId, data, messageConfirmation, preservedSelected) {
        //Obtenemos la data
        var dataGrid = undefined;
        if (idFormGrid != undefined) dataGrid = $(idFormGrid).serialize();

        if (dataGrid != undefined && data != undefined) {
            data = dataGrid + "&" + decodeURIComponent($.param(data));
        } else if (dataGrid != undefined && data == undefined) {
            data = dataGrid;
        } else if (dataGrid == undefined && data != undefined) {
            data = decodeURIComponent($.param(data));
        } else {
            data = undefined;
        }

        if (data != undefined && id != undefined) {
            data = data + "&id=" + id;
        }

        //Obtenemos la url
        var url = "";
        if (data != undefined) {
            if (route.area == undefined) {
                url = route.controller + "/activar/";
            } else {
                url = route.area + "/" + route.controller + "/activar/";
            }
        } else {
            if (id == undefined) {
                if (route.area == undefined) {
                    url = route.controller + "/activar/";
                } else {
                    url = route.area + "/" + route.controller + "/activar/";
                }
            } else {
                if (route.area == undefined) {
                    url = route.controller + "/activar/" + id;
                } else {
                    url = route.area + "/" + route.controller + "/activar/" + id;
                }
            }
        }

        //Construimos parametros
        var params = {
            url: url,
            messageConfirmation: messageConfirmation,
            messageSuccess: "Operación satisfactoria",
            updateTargetId: updateTargetId,
            data: data,
            preservedSelected: preservedSelected
        };
        debugger;
        helperAjax.sendPost(params);        
    },

    desactivar: function (route, id, idFormGrid, updateTargetId, data, messageConfirmation, preservedSelected, metodo) {
        if (messageConfirmation == undefined)
            messageConfirmation = "¿Esta seguro que desea Desactivar?";

        //Obtenemos la data
        var dataGrid = undefined;
        if (idFormGrid != undefined) dataGrid = $(idFormGrid).serialize();

        if (dataGrid != undefined && data != undefined) {
            data = dataGrid + "&" + decodeURIComponent($.param(data));
        } else if (dataGrid != undefined && data == undefined) {
            data = dataGrid;
        } else if (dataGrid == undefined && data != undefined) {
            data = decodeURIComponent($.param(data));
        } else {

            data = undefined;
        }

        if (data != undefined && id != undefined) {
            data = data + "&id=" + id;
        }

        //Obtenemos la url
        var url = "";        
        if (metodo == undefined) {
            metodo = "/desactivar/";
        }
        else {
            metodo = "/" + metodo;
        }            

        if (data != undefined) {
            if (route.area == undefined) {
                url = route.controller + metodo;
            } else {
                url = route.area + "/" + route.controller + metodo;
            }
        } else {
            if (id == undefined) {
                if (route.area == undefined) {
                    url = route.controller + metodo;
                } else {
                    url = route.area + "/" + route.controller + metodo;
                }
            } else {
                if (route.area == undefined) {
                    url = route.controller + metodo + id;
                } else {
                    url = route.area + "/" + route.controller + metodo + id;
                }
            }
        }

        //Construimos parametros
        var params = {
            url: url,
            messageConfirmation: messageConfirmation,
            messageSuccess: "Operación satisfactoria",
            updateTargetId: updateTargetId,
            data: data,
            preservedSelected: preservedSelected
        };

        helperAjax.sendPost(params);        
    },

    ejecutar: function (route, metodo, id, idFormGrid, updateTargetId, data, messageConfirmation, messageSuccess) {
        var url = "";
        if (idFormGrid != undefined) {
            if (route.area == undefined) {
                url = route.controller + "/" + metodo + "/";
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/";
            }
        } else {
            if (route.area == undefined) {
                url = route.controller + "/" + metodo + "/" + id;
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
            }
        }

        if (messageSuccess == undefined) {
            messageSuccess = "Operación satisfactoria";
        }

        var params = {
            url: url,
            messageConfirmation: messageConfirmation,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId
        };

        if (idFormGrid != undefined) {
            var dataGrid = $(idFormGrid).serialize();
            var concantenar;
            if (dataGrid === "") {
                concantenar = "";
            } else {
                concantenar = "&";
            }
            if (data == undefined)
                params.data = dataGrid + concantenar + "id=" + id;
            else
                params.data = dataGrid + concantenar + decodeURIComponent($.param(data));
        } else if (data != undefined) {
            params.data = decodeURIComponent($.param(data));
        }

        helperAjax.sendPost(params);
    },

    cleanFilter: function (sender, formContent) {
        var fila = $(sender).parent("th").parent("tr");
        //$(fila).find(":input:not([type=hidden])").each(function () {
        $(fila).find(":input").each(function () {
            if ($(this).is(':checkbox')) {
                $(this).prop("checked", false);
            } else {
                $(this).val('');
                $(this).removeClass("conFiltro").addClass("sinFiltro");
            }
        });

        if (formContent != undefined) {
            $(formContent).find(".fa-search").click();
        }
    }
}