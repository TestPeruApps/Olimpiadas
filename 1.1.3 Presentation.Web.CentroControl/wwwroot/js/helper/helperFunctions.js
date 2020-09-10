var helperFunctions = {

    obtenerFormatoFecha: function () {
        return "dd/mm/yy";
    },

    obtenerFormatoFechaHora: function () {
        return "dd/mm/yy";
    },

    altoDisponible: function (borde) {
        if (borde === undefined) borde = 20;
        return $(window).height() - borde;
    },

    anchoDisponible: function () {
        return $(window).width() - 20;
    },

    desactivarEnter: function (formContent) {
        $(formContent).keypress(function (e) {
            if (e == 13) {
                return false;
            }
        });

        $(formContent).find(":input:not(textarea)").keypress(function (e) {
            if (e.which == 13) {
                return false;                
            }
        });        
    },

    activar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).find(":input").prop("readonly", "");
    },

    inactivar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).find(":input").prop("readonly", "readonly");
    },

    ocultar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).hide();
    },

    ocultarInactivar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).find(":input").prop("disabled", "disabled");
        $(control).hide();
    },

    ocultarInactivarMasivo: function (formContent) {
        $(formContent).find(".automatico").each(function () {
            var contenedor = $(this);
            $(contenedor).find(":input").each(function () {
                var control = $(this);
                $(control).prop("disabled", "disabled");
            });
            $(contenedor).hide();
        });
    },

    mostrarActivarMasivo: function (formContent) {
        $(formContent).find(".automatico").each(function () {
            var contenedor = $(this);
            $(contenedor).find(":input").each(function () {
                var control = $(this);
                $(control).prop("disabled", "");
            });
            $(contenedor).show();
        });
    },

    mostrar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).show();
    },

    mostrarActivar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).show();
        $(control).find(":input").prop("disabled", "");
    },

    mostrarActivarRefescarValidacion: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).show();
        $(control).find(":input").prop("disabled", "");

        $(control).find(":input[data-fv-field]").each(function (index, value) {
            var input = $(this);
            var inputName = $(input).attr("name");

            helperFunctions.refreshFielValidator(formContent, inputName);
        });
    },

    focus: function (formContent, idControl) {
        var control = $(formContent).find(idControl);
        $(control).focus();
        $(control).select();
    },

    datetimepicker: function (formContent) {
        $(formContent).find(".content-datetime").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");
            var inputId = $(divContainer).find("input").attr("id");

            $(divContainer).datetimepicker({
                locale: 'es',
                showTodayButton: true,
                showClear: true,
                format: 'DD/MM/YYYY hh:mm A',
                allowInputToggle: true
            })
                .on('dp.change', function (e) {
                    debugger;
                    if (e.date === false) {
                        $(formContent).find('#' + inputId).val(e.oldDate._i);
                    }
                    //$("#FechaHoraProgramadaText").val();
                    $(formContent).formValidation('revalidateField', inputName);
                });
        });
    },

    selectpicker: function (formContent) {
        $(formContent).find(".selectpicker").selectpicker();
    },

    datepicker: function (formContent, funcionChange) {
        $(formContent).find(".content-date").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");

            $(divContainer).datetimepicker({
                locale: 'es',
                showTodayButton: true,
                showClear: true,
                format: 'DD/MM/YYYY',
                allowInputToggle: true
            })
                .on('dp.change', function (e) {

                    $(formContent).formValidation('revalidateField', inputName);
                    if (funcionChange != undefined)
                        funcionChange();
                });
        });
    },

    timepicker: function (formContent) {
        $(formContent).find(".content-time").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");

            $(divContainer).datetimepicker({
                locale: 'es',
                showTodayButton: true,
                showClear: true,
                format: 'hh:mm A',
                allowInputToggle: true
            })
                .on('dp.change', function (e) {
                    $(formContent).formValidation('revalidateField', inputName);
                });
        });
    },

    colorPicker: function (formContent) {
        $(formContent).find(".divTipoColorApp").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");

            $(divContainer).colorpicker({
                format: 'hex'
            })
                .on('changeColor', function (e) {
                    $(formContent).formValidation('revalidateField', inputName);
                });
        });
    },

    checked: function (formContent) {
        $(formContent).find("input[type=checkbox]").each(function (index, value) {
            var checked = $(this);
            $(checked).iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    },

    touchSpin: function (formContent, controlName, min, max) {
        $(formContent).find('[name="' + controlName + '"]').TouchSpin({
            min: min,
            max: max
        })
            .on('change touchspin.on.min touchspin.on.max', function () {
                // Revaliate the field
                $(formContent).formValidation('revalidateField', controlName);
            })
            .end();
    },

    numericUpDown: function (formContent, controlName, min, max) {
        $(formContent).find('[name="' + controlName + '"]').TouchSpin({
            min: min,
            max: max,
            verticalbuttons: true
        })
            .on('change touchspin.on.min touchspin.on.max', function () {
                // Revaliate the field
                $(formContent).formValidation('revalidateField', controlName);
            })
            .end();
    },

    addFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('addField', control_name);
        $(formContent).formValidation('revalidateField', control_name);
    },

    removeFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('revalidateField', control_name);
        $(formContent).formValidation('removeField', control_name);
    },

    refreshFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('revalidateField', control_name);
    },

    validateFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('validateField', control_name);
    },

    addFielValidator2: function (formContent, control_name, options) {
        $(formContent).formValidation('addField', control_name, options);
    },

    fielValidatorTextoTipoPregunta: function (value) {
        if (value !== "") {
            var result = helperFunctions.validarTipoPregunta(value);
            if (!result) {
                return {
                    valid: false,
                    message: constantes.validacionTipoPregunta
                };
            }
        }
        return true;
    },

    fielValidatorTextoTipoNombre: function (value) {
        //if (value !== "") {
        //    var result = helperFunctions.validarTipoNombre(value);
        //    if (!result) {
        //        return {
        //            valid: false,
        //            message: constantes.validacionTipoNombre
        //        };
        //    }
        //}
        return true;
    },

    fielValidatorTextoTipoDescripcion: function (value) {
        //if (value !== "") {
        //    var result = helperFunctions.validarTipoDescripcion(value);
        //    if (!result) {
        //        return {
        //            valid: false,
        //            message: constantes.validacionTipoDescripcion
        //        };
        //    }
        //}
        return true;
    },

    fielValidatorEmail: function (value) {
        if (value !== "") {
            var result = helperFunctions.validarEmail(value);
            if (!result) {
                return {
                    valid: false,
                    message: 'Ingrese un Email válido ejemplo (prueba@prueba.com)'
                };
            }
        }
        return true;
    },

    fielValidatorCoordenada: function (value) {
        if (value !== "") {
            var result = helperFunctions.validarCoordenada(value);
            if (!result) {
                return {
                    valid: false,
                    message: 'Coordenada incorrecta ejm. (-12.1234567)'
                };
            }
        }
        return true;
    },

    fielValidatorEnteros: function (value) {
        if (value !== "") {           
            var result = helperFunctions.validarNumeros(value);
            if (!result) {
                return {
                    valid: false,
                    message: 'Formato de número entero incorrecto ejem. (12)'
                };
            }
        }
        return true;
    },

    fielValidatorEnterosConNegativos: function (value) {
        if (value !== "") {
            var result = helperFunctions.validarEnterosConNegativos(value);
            if (!result) {
                return {
                    valid: false,
                    message: 'Formato de número entero incorrecto ejem. (-12)'
                };
            }
        }
        return true;
    },

    formatCurrency: function (value) {
        return "$" + value.toFixed(2);
    },

    closeForm: function (idFormModal) {
        $.each(BootstrapDialog.dialogs, function (id, dialog) {
            var form = $("div#" + id + " " + idFormModal);
            if (form.length > 0) {
                dialog.close();
            }
        });
    },

    soloNumeros: function (formcontent) {
        var key;
        $(formcontent).find(".numero").on("keypress", function (e) {
            if (window.event !== undefined) {
                key = window.event ? e.which : e.keyCode;
            }
            else {
                key = e.which;
            }
            if ((key < 48 || key > 57) && key !== 8 && key !== 0) {
                e.preventDefault();
            }
        });
    },

    validarEmail: function (email) {
        var pattern = /^(([^<>()\[\]\\,;:\s@%&^+{}!"#$/=?'*+\u0022\u00A1\u00B7\u00B4\u0060\u007C\u00B0\u00BF]+(\.[^<>()\[\]\\,;:\s@"%&^+{}!"#$/=?'*+&deg;\u0022\u00A1\u00B4\u0060\u00B7\u007C]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var result = pattern.test(String(email).toLowerCase());
        return result;
    },

    validarTipoDescripcion: function (texto) {
        var pattern = /^[{}\u000A\u003a\u00a1\u0021\u00bf\u003f\u00F1\u00D1\u00C1\u00E1\u00C9\u00E9\u00CD\u00ED\u00D3\u00F3\u00DA\u00FA\u00DC\u00FCa-zA-Z0-9 .,-]+$/g;
        var result = pattern.test(String(texto));
        return result;
    },

    validarTipoNombre: function (texto) {        
        var pattern = /^[\u00F1\u00D1\u00C1\u00E1\u00C9\u00E9\u00CD\u00ED\u00D3\u00F3\u00DA\u00FA\u00DC\u00FCa-zA-Z0-9 .,-]+$/g;
        var result = pattern.test(String(texto));
        return result;
    },

    validarTipoPregunta: function (texto) {
        var pattern = /^[\u00bf\u003f\u00F1\u00D1\u00C1\u00E1\u00C9\u00E9\u00CD\u00ED\u00D3\u00F3\u00DA\u00FA\u00DC\u00FCa-zA-Z0-9 .,-]+$/g;
        var result = pattern.test(String(texto));
        return result;
    },

    validarNumeros: function (numero) {
        var pattern = /^[0-9]*$/;
        var result = pattern.test(String(numero));
        return result;        
    },

    validarEnterosConNegativos: function (numero) {
        var pattern = /^(\+|-)?\d+$/;
        var result = pattern.test(String(numero));
        return result;
    },

    validarWeb: function (url) {
        var pattern = /^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;
        var result = pattern.test(String(url).toLowerCase());
        return result;
    },

    validarColorHex: function (color) {
        var pattern = /^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/;
        var result = pattern.test(String(color).toLowerCase());
        return result;
    },

    validarCoordenada: function (coordendada) {
        var pattern = /^-(\d{1,2}(\.\d{6,11}))$/;
        var result = pattern.test(String(coordendada).toLowerCase());
        return result;
    },

    validarCampoArchivo: function (field, value) {
        var trr = field.closest("tr");
        var nameFile = $(trr).find(".name-file a").html();
        if (nameFile == "" || nameFile == null) {
            if (value == "") {
                return {
                    valid: false,
                    message: 'Campo Obligatorio'
                };
            }
        }

        return true;
    },    

    concatenarChecks: function (formContent, classDivContenedor, input) {
        var idsConcatenados = "";

        $(formContent).find(classDivContenedor).each(function () {
            $(this).find("input:checked").each(function () {
                idsConcatenados += $(this).attr("id") + "/";
            });
        });

        if (idsConcatenados.length > 0) {
            idsConcatenados = idsConcatenados.substring(0, idsConcatenados.length - 1);
        }

        $(formContent).find(input).val(idsConcatenados);
    },

    calcularImagenDimensiones: function (formContent, control_name) {
        $(formContent).find("#" + control_name).change(function () {
            var file, img;
            var _URL = window.URL || window.webkitURL;
            if (file = this.files[0]) {
                img = new Image();
                img.onload = function () {
                    $(formContent).find("#" + control_name).attr("ancho", this.width);
                    $(formContent).find("#" + control_name).attr("alto", this.height);
                    $(formContent).formValidation('revalidateField', control_name);
                };
                img.src = _URL.createObjectURL(file);
            }
        });
    },

    calcularImagenesDimensiones: function (formContent) {
        $(formContent).find(":file").each(function () {
            var input = $(this)[0];
            $(input).change(function () {
                var file, img;
                var _URL = window.URL || window.webkitURL;
                if (file = this.files[0]) {
                    img = new Image();
                    img.onload = function () {
                        $(input).attr("ancho", this.width);
                        $(input).attr("alto", this.height);
                        var control_Name = $(input).attr("name");
                        $(formContent).formValidation('revalidateField', control_Name);
                    };
                    img.src = _URL.createObjectURL(file);
                }
            });
        });
    },

    validarArchivoImagen: function (field, value, obligatorio, ancho, alto) {
        if (obligatorio == true) {
            var nameFile = field.closest("tr").find(".name-file a").html();
            if (nameFile == "" || nameFile == null) {
                if (value == "") {
                    return {
                        valid: false,
                        message: 'Campo Obligatorio'
                    };
                }
            }
        }

        if (value !== "") {
            if (ancho !== null && ancho !== undefined && alto !== null && alto !== undefined) {
                var archivo = $(field)[0];
                var attrAncho = $(archivo).attr("ancho");
                var attrAlto = $(archivo).attr("alto");
                if (attrAncho !== ancho.toString() || attrAlto !== alto.toString()) {
                    return {
                        valid: false,
                        message: "La imagen no cumple las dimensiones, la imagen actual tiene " + attrAncho + "x" + attrAlto
                    };
                }
            }
        }

        return true;
    },

    validarFechasInicioFin: function (field, value, obligatorio, fechaInicio, fechaFinal) {
        if (obligatorio === true) {
            if (value != "") {
                if (fechaInicio.length == 10 && fechaFinal.length == 10) {
                    fechaInicio = fechaInicio.split("/");
                    fechaFinal = fechaFinal.split("/");

                    if (fechaFinal.length == 3 && fechaInicio.length == 3) {
                        var fechaFinalDate = new Date(fechaFinal[2], fechaFinal[1] - 1, fechaFinal[0]);
                        var fechaInicioDate = new Date(fechaInicio[2], fechaInicio[1] - 1, fechaInicio[0]);
                        if (fechaFinalDate < fechaInicioDate) {
                            return {
                                valid: false,
                                message: 'La fecha fin debe ser mayor a la fecha inicio'
                            };
                        }
                        else {
                            return true;
                        }
                    }
                }

            }
        }
        else {
            if (fechaInicio.length === 10 && fechaFinal.length === 10) {
                fechaInicio = fechaInicio.split("/");
                fechaFinal = fechaFinal.split("/");

                if (fechaFinal.length === 3 && fechaInicio.length === 3) {
                    var fechaFinalDate1 = new Date(fechaFinal[2], fechaFinal[1] - 1, fechaFinal[0]);
                    var fechaInicioDate1 = new Date(fechaInicio[2], fechaInicio[1] - 1, fechaInicio[0]);
                    if (fechaFinalDate1 < fechaInicioDate1) {
                        return {
                            valid: false,
                            message: 'La fecha fin debe ser mayor a la fecha inicio'
                        };
                    }
                    else {
                        return true;
                    }
                }
            }
        }
        return true;
    },

    pluginEditorHtml: function (formContent, controlName) {
        var controlid = "#" + controlName.replace(".", "_");
        ClassicEditor
            .create(document.querySelector(controlid), {
                language: 'es',                
                toolbar: ['bold', 'italic', '|', 'link', '|', 'bulletedList', 'numberedList', '|', 'undo', 'redo']
            })
            .then(function(editor) {
                window.editor = editor;
                editor.model.document.on('change:data', function () {
                    var valor = editor.getData();
                    $(formContent).find(controlid).val(valor);
                    $(formContent).formValidation('revalidateField', controlName);
                });              
            });
    },

    pluginImagenes: function (formContent) {
        $(formContent).find("#FilesToUpload").fileinput({
            uploadAsync: false,
            language: "es",
            previewFileType: "image",
            maxFileCount: 1,
            initialPreviewAsData: true,
            showUpload: false
            //maxFileSize: 5
            //minImageWidth: 50,
            //minImageHeight: 50,
            //maxImageWidth: 1000,
            //maxImageHeight: 1000,
            //allowedFileExtensions: ["jpg"]
        });
        $(formContent).find('#FilesToUpload').on('filecleared', function (event) {
            $(formContent).formValidation('revalidateField', "FilesToUpload");
        });
    },

    pluginImagenesXControl: function (formContent, control_id) {
        $(formContent).find(control_id).fileinput({
            uploadAsync: false,
            language: "es",
            previewFileType: "image",
            maxFileCount: 1,
            initialPreviewAsData: true,
            showUpload: false
            //maxFileSize: 100,
            //minImageWidth: 50,
            //minImageHeight: 50,
            //maxImageWidth: 1000,
            //maxImageHeight: 1000,
            //allowedFileExtensions: ["jpg"]
        });
        
        $(formContent).find(control_id).on('filecleared', function (event) {
            var control_nombre = control_id.replace("#","");
            $(formContent).formValidation('revalidateField', control_nombre);
        });
    },

    asignarMascara: function (formContent, control_name, control_id, mascara) {
        $(formContent).find(control_id).mask(mascara);
        $(formContent).find(control_id).on('input', function () {
            $(formContent).formValidation('revalidateField', control_name);
        });
    },

    cropper: function (formContent) {
        'use strict';
        var anchoMaximo = Number($(formContent).find("#AnchoMaximo").val());
        var anchoMinimo = Number($(formContent).find("#AnchoMinimo").val());
        var altoMaximo = Number($(formContent).find("#AltoMaximo").val());
        var altoMinimo = Number($(formContent).find("#AltoMinimo").val());
        var Cropper = window.Cropper;
        var container = document.querySelector('.img-container');
        var image = container.getElementsByTagName('img').item(0);

        var dataX = $(formContent).find("#PosicionX");
        var dataY = $(formContent).find("#PosicionY");
        var dataHeight = $(formContent).find("#AltoCortado");
        var dataWidth = $(formContent).find("#AnchoCortado");

        var cropBoxData;
        var canvasData;
        var cropper;

        var options = {
            ready: function (e) {
                cropper.setCropBoxData(cropBoxData).setCanvasData(canvasData);
            },
            crop: function (e) {
                var data = e.detail;
                $(dataX).val(Math.round(data.x));
                $(dataY).val(Math.round(data.y));
                $(dataHeight).val(Math.round(data.height));
                $(dataWidth).val(Math.round(data.width));
            },            
            dragMode: 'move',
            viewMode: '1',
            cropBoxResizable: false,
            data: {
                width: (anchoMaximo + anchoMinimo) / 2,
                height: (altoMaximo + altoMinimo) / 2
            }
        };
        cropper = new Cropper(image, options);

        var originalImageURL = image.src;
        var uploadedImageType = 'image/jpeg';
        var uploadedImageName = 'cropped.jpg';
        var uploadedImageURL;

        // Tooltip
        $('[data-toggle="tooltip"]').tooltip();

        // Buttons
        if (!document.createElement('canvas').getContext) {
            $('button[data-method="getCroppedCanvas"]').prop('disabled', true);
        }

        if (typeof document.createElement('cropper').style.transition === 'undefined') {
            $('button[data-method="rotate"]').prop('disabled', true);
            $('button[data-method="scale"]').prop('disabled', true);
        }

        // Methods
        actions.querySelector('.docs-buttons').onclick = function (event) {
            var e = event || window.event;
            var target = e.target || e.srcElement;
            var cropped;
            var result;
            var input;
            var data;

            if (!cropper) {
                return;
            }

            while (target !== this) {
                if (target.getAttribute('data-method')) {
                    break;
                }

                target = target.parentNode;
            }

            if (target === this || target.disabled || target.className.indexOf('disabled') > -1) {
                return;
            }

            data = {
                method: target.getAttribute('data-method'),
                target: target.getAttribute('data-target'),
                option: target.getAttribute('data-option') || undefined,
                secondOption: target.getAttribute('data-second-option') || undefined
            };

            cropped = cropper.cropped;

            if (data.method) {
                if (typeof data.target !== 'undefined') {
                    input = document.querySelector(data.target);

                    if (!target.hasAttribute('data-option') && data.target && input) {
                        try {
                            data.option = JSON.parse(input.value);
                        } catch (e) {
                            console.log(e.message);
                        }
                    }
                }

                switch (data.method) {
                    case 'rotate':
                        if (cropped && options.viewMode > 0) {
                            cropper.clear();
                        }

                        break;

                    case 'getCroppedCanvas':
                        try {
                            data.option = JSON.parse(data.option);
                        } catch (e) {
                            console.log(e.message);
                        }

                        if (uploadedImageType === 'image/jpeg') {
                            if (!data.option) {
                                data.option = {};
                            }

                            data.option.fillColor = '#fff';
                        }

                        break;
                }

                result = cropper[data.method](data.option, data.secondOption);

                switch (data.method) {
                    case 'rotate':
                        if (cropped && options.viewMode > 0) {
                            cropper.crop();
                        }

                        break;

                    case 'scaleX':
                    case 'scaleY':
                        target.setAttribute('data-option', -data.option);
                        break;

                    case 'getCroppedCanvas':
                        if (result) {
                            // Bootstrap's Modal
                            $('#getCroppedCanvasModal').modal().find('.modal-body').html(result);

                            if (!download.disabled) {
                                download.download = uploadedImageName;
                                download.href = result.toDataURL(uploadedImageType);
                            }
                        }

                        break;

                    case 'destroy':
                        cropper = null;

                        if (uploadedImageURL) {
                            URL.revokeObjectURL(uploadedImageURL);
                            uploadedImageURL = '';
                            image.src = originalImageURL;
                        }

                        break;
                }

                if (typeof result === 'object' && result !== cropper && input) {
                    try {
                        input.value = JSON.stringify(result);
                    } catch (e) {
                        console.log(e.message);
                    }
                }
            }
        };

        document.body.onkeydown = function (event) {
            var e = event || window.event;

            if (e.target !== this || !cropper || this.scrollTop > 300) {
                return;
            }

            switch (e.keyCode) {
                case 37:
                    e.preventDefault();
                    cropper.move(-1, 0);
                    break;

                case 38:
                    e.preventDefault();
                    cropper.move(0, -1);
                    break;

                case 39:
                    e.preventDefault();
                    cropper.move(1, 0);
                    break;

                case 40:
                    e.preventDefault();
                    cropper.move(0, 1);
                    break;
            }
        };

        // Import image
        var inputImage = document.getElementById('FilesToUpload');

        if (URL) {
            inputImage.onchange = function () {
                var files = this.files;
                var file;

                if (cropper && files && files.length) {
                    file = files[0];

                    if (/^image\/\w+/.test(file.type)) {
                        uploadedImageType = file.type;
                        uploadedImageName = file.name;

                        if (uploadedImageURL) {
                            URL.revokeObjectURL(uploadedImageURL);
                        }

                        image.src = uploadedImageURL = URL.createObjectURL(file);
                        cropper.destroy();
                        cropper = new Cropper(image, options);
                        //inputImage.value = null;
                    } else {
                        window.alert('Por favor cambiar la imagen seleccionada.');
                    }
                }
            };
        } else {
            inputImage.disabled = true;
            inputImage.parentNode.className += ' disabled';
        }
    },

    habilitarValidator: function (formContent, control_name, habilitar, validator) {
        if (validator == undefined) { $(formContent).data('formValidation').enableFieldValidators(control_name, habilitar); }
        else { $(formContent).data('formValidation').enableFieldValidators(control_name, validator, habilitar); }
    },
};


/***********************************************************************************
 Utilitarios para el Chart.js
***********************************************************************************/
window.chartColors = {
    red: 'rgb(255, 99, 132)',
    orange: 'rgb(255, 159, 64)',
    yellow: 'rgb(255, 205, 86)',
    green: 'rgb(75, 192, 192)',
    blue: 'rgb(54, 162, 235)',
    purple: 'rgb(153, 102, 255)',
    grey: 'rgb(231,233,237)'
};

window.randomScalingFactor = function () {
    return (Math.random() > 0.5 ? 1.0 : -1.0) * Math.round(Math.random() * 100);
};


/***********************************************************************************/




$.fn.modal.Constructor.prototype.enforceFocus = function () {
    $(document)
        .off('focusin.bs.modal') // guard against infinite focus loop
        .on('focusin.bs.modal', $.proxy(function (e) {
            if (
                this.$element[0] !== e.target && !this.$element.has(e.target).length
                // CKEditor compatibility fix start.
                && !$(e.target).closest('.cke_dialog, .cke').length
                // CKEditor compatibility fix end.
            ) {
                this.$element.trigger('focus');
            }
        }, this));
};