var baseEditor = {
    /*    
    route: {
        area, 
        controller, 
        idTab
    },    
    metodo, 
    id,
    title,
    size   
    */    
    call: function (route, id, title, size, inputIdFocus, data, opcion, metodo, botonGuardarVisible, botonCancelarVisible, width, onclose, tabIndex) {
        if (metodo === undefined) {
            metodo = "editor";
        }
        var url = "";
        if (id === undefined)
            url = route.area + "/" + route.controller + "/" + metodo + "/";
        else
            url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
           
        var params = {
            url: url,
            data:data,
            onSuccess: function (data1, textStatus, jqXhr) {                
                var buttonOkLabel = undefined;
                if (opcion != undefined) buttonOkLabel = opcion.buttonOkLabel;
                var options = {
                    data: data1,
                    size: size,
                    title: title,
                    width: width,                    
                    buttonOkVisible: botonGuardarVisible,
                    buttonCerrarVisible: botonCancelarVisible,
                    buttonOkLabel: buttonOkLabel,
                    inputIdFocus: inputIdFocus,
                    onClose: onclose,
                    tabIndex: tabIndex
                };                
                baseEditor.popup(options, opcion);
            }
        };
        helperAjax.sendGet(params);
    },
    
    /*
    route: {
        area, 
        controller, 
        idTab
    },        
    width,
    title,
    buttonOkVisible, por defecto: true
    buttonOkLabel, por defecto: 'Guardar'
    buttonOkIcon, por defecto: 'glyphicon glyphicon-save'
    buttonCerrarVisible, por defecto: true
    buttonCerrarLabel, por defecto: 'Cerrar'
    buttonCerrarIcon, por defecto: 'glyphicon glyphicon-log-out'
    open: {	
        onOpen: 
        data:
    },
    onSuccess,
    metodo, 
    id
    */
    initCustom: function (options) {        
        var url = "";
        if (options.metodo == undefined) {
            url = options.route.controller + "/Editor";
        }
        else {
            url = options.route.controller + "/" + options.metodo;
        }
        if (options.route.area != undefined) {
            url = options.route.area + "/" + url;
        }

        if (options.id != undefined) url = url + "/" + options.id;

        var params = {
            url: url,
            data: options.data,
            onSuccess: function (data, textStatus, jqXhr) {
                options.data = data;
                baseEditor.popup(options);
            }
        };
        helperAjax.sendGet(params);
    },

    /*
    title, onOpen, data, width,
    buttonOkVisible, por defecto: true
    buttonOkLabel, por defecto: 'Guardar'
    buttonOkIcon, por defecto: 'glyphicon glyphicon-save'
    buttonCerrarVisible, por defecto: true
    buttonCerrarLabel, por defecto: 'Cerrar'
    buttonCerrarIcon, por defecto: 'glyphicon glyphicon-log-out'
    inputIdFocus. id del input que recibe el foco #id-input,
    tabIndex,
    onSuccess
    */
    popup: function (options, metodo) {        
        if (options.tabIndex === undefined) options.tabIndex = '-1';
        var buttons = [];
        var buttonOkVisible = true;
        var buttonCerrarVisible = true;
        if (options.buttonOkVisible !== undefined) buttonOkVisible = options.buttonOkVisible;
        if (options.size === undefined) options.size = BootstrapDialog.SIZE_NORMAL;
        if (options.buttonCerrarVisible !== undefined) buttonCerrarVisible = options.buttonCerrarVisible;
        
        if (buttonOkVisible === true) {
            var icon1 = 'glyphicon glyphicon-save';
            var label1 = 'Guardar';
            if (options.buttonOkIcon !== undefined) icon1 = options.buttonOkIcon;
            if (options.buttonOkLabel !== undefined) label1 = options.buttonOkLabel;
            buttons.push({
                icon: icon1,
                label: label1,
                cssClass: 'btn-primary',
                //hotkey: 13, // Enter.
                action: function (dialogRef) {
                    var form = dialogRef.getModalBody().find('form:first-of-type');
                    if (options.onSuccess !== undefined) {
                        options.onSuccess(dialogRef, form);
                    }
                    else {                        
                        $(form).submit();
                        //$(form).data('formValidation').validate();
                    }
                }
            });
        }

        if (buttonCerrarVisible === true) {
            var icon = 'glyphicon glyphicon-log-out';
            var label = 'Cerrar';
            if (options.buttonCerrarIcon !== undefined) icon = options.buttonCerrarIcon;
            if (options.buttonCerrarLabel !== undefined) label = options.buttonCerrarLabel;
            buttons.push({
                icon: icon,
                label: label,                
                action: function (dialogRef) {
                    dialogRef.close();
                }
            });
        }
        
        BootstrapDialog.show({
            title: options.title,
            message: $(options.data),
            draggable: true,
            animate: true,
            closable: true,
            closeByBackdrop: true,
            closeByKeyboard: true,
            buttons: buttons,
            tabindex: options.tabIndex,
            size: options.size,
            onshow: function (dialogRef) {
                if (options.width !== undefined) {
                    dialogRef.getModalDialog().css('width', options.width);
                }
            },
            onshown: function (dialogRef) {
                if (options.open !== undefined) {
                    options.open.onOpen(metodo);
                }
                if (options.inputIdFocus !== undefined) {
                    $(options.inputIdFocus).focus();
                    $(options.inputIdFocus).select();
                }
            },
            onhide: function (dialogRef) {
                if (options.onClose != undefined) {
                    options.onClose();
                }
            },
            /*
            onhide: function (dialogRef) {
                alert("1");
            },
            onhidden: function (dialogRef) {
                alert("2");
            }            */
        });
    }    
}