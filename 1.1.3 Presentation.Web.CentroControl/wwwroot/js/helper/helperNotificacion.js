var helperNotificacion = {
    /*************************************************************************************
   HELPER: procesamiento de mensajes de las llamadas ajax
   *************************************************************************************/

    //Procesa los mensajes ocurridos después de una llamada realizada con $.ajax
    procesarSuccessDefault: function (data, textStatus, jqXhr, messageSuccess) {
        if (data == null) {
            mensaje.satisfactorio(messageSuccess);
            return true;
        }
        if (data.tipoNotificacion === "Advertencia") {
            mensaje.advertencia(data.mensaje);
            return false;
        } else if (data.tipoNotificacion === "Informativo") {
            mensaje.informacion(data.mensaje);
            return false;
        } else if (data.tipoNotificacion === "Alerta") {
            mensaje.alerta(data.mensaje);
            return false;
        } else if (data.tipoNotificacion === "Satisfactorio") {
            if (data.mensaje != undefined) {
                mensaje.satisfactorio(data.mensaje);
            }
            return true;
        } else {
            if (messageSuccess != undefined && messageSuccess != "") {
                $.noty.consumeAlert({ layout: 'topRight', type: 'success', dismissQueue: true });
                mensaje.satisfactorio(messageSuccess);
            }
            return true;
        }
        //$("#button-0").focus();
    },

    procesarErrorDefault: function (data, textStatus, errorThrown) {
        BootstrapDialog.show({
            title: textStatus,
            type: BootstrapDialog.TYPE_DANGER,
            message: errorThrown.responseText
        });        
    }
};

var mensaje = {    
    confirmacion: function (mensaje, functionSi, parametrosSi) {        
        var n = noty({
            text: mensaje,
            type: 'confirm',
            dismissQueue: true,
            modal: true,
            layout: 'center',
            theme: 'defaultTheme',
            buttons: [
                {
                    addClass: 'btn btn-primary',
                    text: 'Si',
                    onClick: function ($noty) {
                        $noty.close();
                        functionSi(parametrosSi);
                    }
                },
                {
                    addClass: 'btn btn-danger',
                    text: 'No',
                    onClick: function ($noty) {
                        $noty.close();
                    }
                }
            ]
        });
    },
    advertencia: function (mensaje) {
        var n = noty({
            text: mensaje,
            type: 'warning',
            dismissQueue: true,
            modal: true,
            layout: 'center',
            theme: 'defaultTheme',
            buttons: [
                {
                    addClass: 'btn btn-primary',
                    text: 'Ok',
                    onClick: function ($noty) {
                        $noty.close();
                    }
                }
            ]
        });
    },
    alerta: function (mensaje) {
        var n = noty({
            text: mensaje,
            type: 'alert',
            dismissQueue: true,
            modal: true,
            layout: 'center',
            theme: 'defaultTheme',
            buttons: [
                {
                    addClass: 'btn btn-primary',
                    text: 'Ok',
                    onClick: function ($noty) {
                        $noty.close();
                    }
                }
            ]
        });
    },
    informacion: function (mensaje) {
        var n = noty({
            text: mensaje,
            type: 'information',
            dismissQueue: true,
            modal: true,
            layout: 'center',
            theme: 'defaultTheme',
            buttons: [
                {
                    addClass: 'btn btn-primary',
                    text: 'Ok',
                    onClick: function ($noty) {
                        $noty.close();
                    }
                }
            ]
        });
    },
    notificacion: function (mensaje) {
        var n = noty({
            text: mensaje,
            type: 'notification',
            dismissQueue: true,
            modal: false,
            maxVisible: 10,
            timeout: 1500,
            layout: 'topCenter',
            theme: 'defaultTheme'
        });
    },
    satisfactorio: function (mensaje) {
        var n = noty({
            text: mensaje,
            type: 'success',
            dismissQueue: true,
            modal: false,
            maxVisible: 10,
            timeout: 3000,
            layout: 'topCenter',
            theme: 'defaultTheme'
        });
    }
};