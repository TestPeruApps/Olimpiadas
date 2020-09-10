var formLogin = {
    idFormEditor: "#loginForm",    

    login: {
        load: function () {            
            var formContent = $(formLogin.idFormEditor);            
            $(formContent).find("#Usuario").on("input", function () {
                if ($(this).val() == "") {
                    $(formContent).find("#Contrasenia").val("");
                }
            });
                
            $(formContent).find("#lnkRecuperarContrasenia").on("click", function () {
                formLogin.editorRecuperarContrasenia.call();                
            });

            helperFunctions.desactivarEnter(formContent);
            formLogin.login.validation(formContent);            
        },        

        validation: function (formContent) {
            $(formContent).formValidation({
                locale: 'es_ES',
                button: {
                    selector: '[type="submit"]'
                },
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {                    
                    Usuario: {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese su Usuario'
                            },
                            callback: {
                                callback: function (value, validator, $field) {
                                    if (value.indexOf('@') != -1) {
                                        return helperFunctions.fielValidatorEmail(value);
                                    }
                                    else return true;
                                }
                            }
                        }
                    },
                    Contrasenia: {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese su Contraseña'
                            },
                            stringLength: {
                                max: 15,
                                min: 6,
                                message: 'Ingrese entre 6 a 15 caracteres.'
                            }
                        }
                    }
                }
            })
                .on('success.form.fv', function (e, data) {
                    e.preventDefault();
                    $(formLogin.idFormEditor).find("#btnLogOn").prop("disabled", "");
                    $(formLogin.idFormEditor).find("#btnLogOn").removeClass("disabled");
                    formLogin.login.loguearse();
                });
        },

        loguearse: function () {
            var options = {
                route: route.login,
                metodo: "Login",
                data: $(formLogin.idFormEditor).serialize(),
                messageSuccess: "",
                onSuccessComplete: function (data) {                    
                    if (data === '/') {
                        window.location = data;
                    }
                }
            };
            baseGrid.ejecutarAccion(options);
        },

        limpiarFormulario: function () {
            var formContent = $(formLogin.idFormEditor);
            $(formContent).find("#Contrasenia").val('');

            $(formContent).formValidation('revalidateField', 'Contrasenia');
            $(formContent).find(".divUsua_ContraseniaString").removeClass("has-feedback");
            $(formContent).find(".divUsua_ContraseniaString").removeClass("has-success");
            $(formContent).find(".divUsua_ContraseniaString").removeClass("has-error");
            $(formContent).find("#Contrasenia").focus();
        }
    },    

    editorRecuperarContrasenia: {
        idFormEditor: "#recuperarContraseniaForm",

        call: function (id) {            
            var title = "Enviar Contraseña";
            var opcion = {
                buttonOkLabel: "Enviar"
            };
            baseEditor.call(route.login, id, title, dialog.normal, '#Usua_Email', undefined, opcion, "EditorRecuperarContrasenia", true, false);            
        },

        load: function () {            
            var formContent = $(formLogin.editorRecuperarContrasenia.idFormEditor);
            helperFunctions.desactivarEnter(formContent);
            helperFunctions.checked(formContent);

            formLogin.editorRecuperarContrasenia.validation(formContent);            
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                locale: 'es_ES',
                button: {
                    // The submit buttons selector
                    selector: '[type="submit"]'
                },
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "Usua_Email": {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el Email del Usuario'
                            },
                            callback: {
                                callback: function (value, validator, $field) {
                                    return helperFunctions.fielValidatorEmail(value);
                                }
                            }
                        }
                    }                 
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();
                    var usuario_Email = $(formLogin.editorRecuperarContrasenia.idFormEditor + " #Usua_Email").val();
                    formLogin.editorRecuperarContrasenia.RecuperarContrasenia(usuario_Email);
                });
        },

        RecuperarContrasenia: function (usuario_Email) {
            var data = {
                usua_Email: usuario_Email
            };

            var options = {
                route: route.login,
                metodo: "RecuperarContrasenia",
                data: data,
                messageSuccess: "Se ha enviado satisfactoriamente la contraseña a su correo",
                onSuccessComplete: function () {
                    debugger;
                    helperFunctions.closeForm(formLogin.editorRecuperarContrasenia.idFormEditor);
                    formLogin.login.limpiarFormulario();
                }
            };
            baseGrid.ejecutarAccion(options);
        }
    }
}