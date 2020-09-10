var dialog = {
    normal: BootstrapDialog.SIZE_NORMAL,
    mediano: BootstrapDialog.SIZE_SMALL,
    ancho: BootstrapDialog.SIZE_WIDE,
    grande: BootstrapDialog.SIZE_LARGE
};

var localStorageKey = {
    establecimientoId: "identificador"
};

var route = {    
    rol: {
        area: "seguridad",
        controller: "rol",
        idTab: "#rol-tab",
        method: "index",
        titulo: "Roles"
    },
    rol_Opcion: {
        area: "seguridad",
        controller: "rol_opcion",
        idTab: "#rol_Opcion-tab",
        method: "index",
        titulo: "Permisos por Rol"
    },
    usuario: {
        area: "seguridad",
        controller: "usuario",
        idTab: "#usuario-tab",
        method: "index",
        obtenerPorActiveDirectory: "ObtenerPorActiveDirectory",
        recuperarContrasenia: "RecuperarContrasenia",
        editorActualizarContrasenia: "EditorActualizarContrasenia",
        actualizarContrasenia: "ActualizarContrasenia"
    },            
    login: {
        area: "seguridad",
        controller: "autenticacion",
        idTab: "",
        method: "login",
        titulo: "xxxxx"
    },
    tipo: {
        area: "compartido",
        controller: "tipo",
        idTab: "#tipo-tab",
        method: "index",
        actualizarTiposFiltro: "ListarTiposPorGrupo"
    },
    participante: {
        area: "contenido",
        controller: "participante",
        idTab: "#participante-tab",
        method: "index"
    },
    personal: {
        area: "contenido",
        controller: "personal",
        idTab: "#personal-tab",
        method: "index"
    },
};

var tipos = {
    
};

var constantes = {
    imagenSizeMax: 400000,
    imagenSizeMaxMessage: 'El tamaño máximo debe ser de 400 KB',
    validacionTipoDescripcion: 'Solo se permiten letras, números (a-z 0-9) y los caracteres (.-,¿?¡!:{})',
    validacionTipoNombre: 'Solo se permiten letras, números (a-z 0-9) y los caracteres (.-,)',
    validacionTipoPregunta: 'Solo se permiten letras (a-z) y los caracteres (.-,¿?)',
    igv: 1.18,
    tipoEncuestaRuta: 77,
    tipoRespuestaTextoLibre: 80,
    imgMaxSize: 5 * 1024 * 1024,
    imgMaxSizeIconografias: 200 * 1024,
    imgMaxSizeBeneficios: 200 * 1024,
    imgMaxSizePremios: 200 * 1024,
    imgMaxSizeCampanias: 200 * 1024,
    imgMaxSizeAlertas: 200 * 1024,
    imgMaxSizeAvatares: 100 * 1024,
    imgMaxSizeRuta: 30 * 1024 * 1024,
    grupoDestino: 5,
    grupoOrigen: 11,
    tipoDestinoRuta: 68,
    tipoDestinoUrl: 69,
    tipoAtenticacionDominio: 2    
}