var formHome = {

    loadMenuLateral: function () {        
        $(".main-sidebar").find(".subMenuLateral").on("click", function (e) {            
            var subM_Id = jQuery(e.currentTarget).data("callback");
            if (subM_Id === 1) { formRol.grid.call($(this)[0]); }
            else if (subM_Id === 2) { formUsuario.grid.call($(this)[0]); }
            else if (subM_Id === 3) { formRol_Opcion.editor.call($(this)[0]); }
            else if (subM_Id === 4) { formRuta.grid.call($(this)[0]); }
            else if (subM_Id === 5) { formCampania.grid.call($(this)[0]); }
            else if (subM_Id === 6) { formIconografia.grid.call($(this)[0]); }
            else if (subM_Id === 7) { formBeneficio.grid.call($(this)[0]); }
            else if (subM_Id === 8) { formAvatar.grid.call($(this)[0]); }
            else if (subM_Id === 9) { formTipo.grid.call($(this)[0]); }
            else if (subM_Id === 10) { formAlerta.grid.call($(this)[0]); }
            else if (subM_Id === 11) { formPregunta.grid.call($(this)[0]); }
            else if (subM_Id === 12) { formAtractivo.grid.call($(this)[0]); }
            else if (subM_Id === 13) { formAtractivoValorado.grid.call($(this)[0]); }
            else if (subM_Id === 14) { formConfiguracionPush.call($(this)[0]); }
            else if (subM_Id === 15) { formNotificacionPush.grid.call($(this)[0]); }
            else if (subM_Id === 16) { repRegistroPorUbigeo.editor.call($(this)[0]); }
            else if (subM_Id === 17) { repRegistroPorGenero.editor.call($(this)[0]); }
            else if (subM_Id === 18) { repRegistroPorEdad.editor.call($(this)[0]); }
            else if (subM_Id === 19) { repEstadoUso.editor.call($(this)[0]); }
            else if (subM_Id === 20) { repDesplazamientoARuta.editor.call($(this)[0]); }
            else if (subM_Id === 21) { repTiempoPermanenciaEnApp.editor.call($(this)[0]); }
            else if (subM_Id === 22) { repRankingSeccionVisitada.editor.call($(this)[0]); }
            else if (subM_Id === 23) { repDestinosBuscados.editor.call($(this)[0]); }
            else if (subM_Id === 24) { formNotificacionEmail.grid.call($(this)[0]); }
            else if (subM_Id === 25) { formNotificacionManual.grid.call($(this)[0]); }
            else if (subM_Id === 26) { formAvatar.editorPuntuacion.call($(this)[0]); }
            else if (subM_Id === 27) { formUsuario.editorActualizarContraseña.call($(this)[0]); }
            else if (subM_Id === 28) { formMensaje.grid.call($(this)[0]); }
            else if (subM_Id === 29) { formConfiguracionEmail.call($(this)[0]); }
            else if (subM_Id === 31) { formDirectorio.grid.call($(this)[0]); }
            else if (subM_Id === 32) { repRegistroTurista.editor.call($(this)[0]); }
            else if (subM_Id === 33) { formOfertas.sincronizar.call($(this)[0]); }
            else if (subM_Id === 35) { formPush.grid.call($(this)[0]); }
        });
    },
    
    loadNotificaciones: function () {
        $("#btn-comentarioPendiente").on("click", function () {
            formAtractivoValorado.grid.callComentariosPendientes(this);
        });

        $("#btn-fotoPendiente").on("click", function () {
            formAtractivoValorado.grid.callFotosPendientes(this);
        });
    }
};