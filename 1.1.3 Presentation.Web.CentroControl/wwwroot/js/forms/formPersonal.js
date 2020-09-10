var formPersonal = {
    grid: {
        idFormGrid: "#personalGridForm",
        inputSelected: "#",
        call: function (sender) {
            baseGrid.callInTab(route.personal, sender.textContent);
        },

        load: function () {
            var formContent = $(formPersonal.grid.idFormGrid);            
            baseGrid.load(route.personal, formPersonal.grid.idFormGrid, route.personal.idTab, formPersonal.editor.call, formPersonal.grid.desactivar, formPersonal.grid.activar);
            if (formPersonal.grid.inputSelected !== "#") {
                helperFunctions.focus(formContent, formPersonal.grid.inputSelected);
            }
            helperFunctions.datepicker(formContent);

            formPersonal.grid.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                locale: 'es_ES',
                framework: 'bootstrap',
                icon: {
                    valid: '',
                    invalid: '',
                    validating: ''
                },
                fields: {
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();
                    formPersonal.grid.inputSelected = "#" + document.activeElement.id;
                    baseGrid.find(route.personal, formPersonal.grid.idFormGrid, undefined, route.personal.idTab, 1);
                });
        },

        activar: function (aler_Id) {
            baseGrid.activar(route.personal, aler_Id, formPersonal.grid.idFormGrid, route.personal.idTab);
        },

        desactivar: function (aler_Id) {
            baseGrid.desactivar(route.personal, aler_Id, formPersonal.grid.idFormGrid, route.personal.idTab, undefined, "¿Seguro que desea desactivar el Personal?");
        }

    },

    editor: {
        idFormEditor: "#personalEditorForm",
        anchoImagen: 250,
        altoImagen: 250,

        call: function (id) {
            var title = id ? "Editar Personal" : "Agregar Personal";
            baseEditor.call(route.personal, id, title, dialog.normal, "#Personal_NombrePersonal", undefined, undefined, undefined, undefined, undefined, undefined, undefined, null);
        },

        load: function () {
            var formContent = $(formPersonal.editor.idFormEditor);
            helperFunctions.desactivarEnter(formContent);
            helperFunctions.checked(formContent);

            helperFunctions.asignarMascara(formContent, "Personal.DniPersonal","#Personal_DniPersonal", "########")

            formPersonal.editor.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                locale: 'es_ES',
                excluded: [':disabled'],
                button: {
                    //The submit buttons selector
                    //selector: '[type="submit"]'
                },
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "Personal.NombrePersonal": {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el Nombre'
                            },
                        }
                    },
                    "Personal.DniPersonal": {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el DNI'
                            },
                            stringLength: {
                                min: 8,
                                max: 8,
                                message: 'Debe ingresar 8 caracteres.'
                            }
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();
                    var id = $(formPersonal.editor.idFormEditor + " #Personal_IdPersonal").val();
                    if (id === "")
                        formPersonal.editor.agregar();
                    else
                        formPersonal.editor.modificar();

                });
        },

        agregar: function () {
            baseGrid.insertar(route.personal, formPersonal.editor.idFormEditor, formPersonal.grid.idFormGrid, route.personal.idTab);
        },

        modificar: function () {
            baseGrid.actualizar(route.personal, formPersonal.editor.idFormEditor, formPersonal.grid.idFormGrid, route.personal.idTab);
        }
    }
};