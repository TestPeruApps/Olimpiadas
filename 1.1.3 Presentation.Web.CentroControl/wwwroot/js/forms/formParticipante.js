var formParticipante = {
    grid: {
        idFormGrid: "#participanteGridForm",
        inputSelected: "#",
        call: function (sender) {
            baseGrid.callInTab(route.participante, sender.textContent);
        },

        load: function () {
            var formContent = $(formParticipante.grid.idFormGrid);            
            baseGrid.load(route.participante, formParticipante.grid.idFormGrid, route.participante.idTab, formParticipante.editor.call, formParticipante.grid.desactivar, formParticipante.grid.activar);
            if (formParticipante.grid.inputSelected !== "#") {
                helperFunctions.focus(formContent, formParticipante.grid.inputSelected);
            }
            helperFunctions.datepicker(formContent);

            formParticipante.grid.validation(formContent);
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
                    formParticipante.grid.inputSelected = "#" + document.activeElement.id;
                    baseGrid.find(route.participante, formParticipante.grid.idFormGrid, undefined, route.participante.idTab, 1);
                });
        },

        activar: function (aler_Id) {
            baseGrid.activar(route.participante, aler_Id, formParticipante.grid.idFormGrid, route.participante.idTab);
        },

        desactivar: function (aler_Id) {
            baseGrid.desactivar(route.participante, aler_Id, formParticipante.grid.idFormGrid, route.participante.idTab, undefined, "¿Seguro que desea desactivar el participante?");
        }

    },

    editor: {
        idFormEditor: "#participanteEditorForm",
        anchoImagen: 250,
        altoImagen: 250,

        call: function (id) {
            var title = id ? "Editar Participante" : "Agregar Participante";
            baseEditor.call(route.participante, id, title, dialog.normal, "#Participante_NombreParticipante", undefined, undefined, undefined, undefined, undefined, undefined, undefined, null);
        },

        load: function () {
            var formContent = $(formParticipante.editor.idFormEditor);
            helperFunctions.desactivarEnter(formContent);
            helperFunctions.checked(formContent);

            formParticipante.editor.validation(formContent);
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
                    "Participante.NombreParticipante": {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el Nombre'
                            },
                        }
                    },
                    "Participante.IdPais": {
                        validators: {
                            notEmpty: {
                                message: 'Seleccione el país'
                            },
                        }
                    },
                    "Participante.IdDeporte": {
                        validators: {
                            notEmpty: {
                                message: 'Seleccione el deporte'
                            },
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();
                    var id = $(formParticipante.editor.idFormEditor + " #Participante_IdParticipante").val();
                    if (id === "")
                        formParticipante.editor.agregar();
                    else
                        formParticipante.editor.modificar();

                });
        },

        agregar: function () {
            baseGrid.insertar(route.participante, formParticipante.editor.idFormEditor, formParticipante.grid.idFormGrid, route.participante.idTab);
        },

        modificar: function () {
            baseGrid.actualizar(route.participante, formParticipante.editor.idFormEditor, formParticipante.grid.idFormGrid, route.participante.idTab);
        }
    }
};