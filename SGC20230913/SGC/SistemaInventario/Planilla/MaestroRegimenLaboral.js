var AppSession = "../Planilla/MaestroRegimenLaboral.aspx";

var CodigoMenu = 8000;
var CodigoInterno = 10;


$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarEliminar_Factura() == false)
                return false;

            if (confirm("Esta seguro de eliminar los documentos seleccionado"))
                F_EliminarTemporal_Factura();

            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false;
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL REGIMEN LABORAL"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL REGIMEN LABORAL"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });

    F_Controles_Inicializar();
    
    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtCodFamiliaEdicion').css('background', '#FFFFE0');
});

$(document).unbind('keydown').bind('keydown', function (event) {
    var doPrevent = false;
    if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD' || d.type.toUpperCase() === 'FILE' || d.type.toUpperCase() === 'EMAIL'))
             || d.tagName.toUpperCase() === 'TEXTAREA') {
            doPrevent = d.readOnly || d.disabled;
        }
        else {
            doPrevent = true;
        }
    }

    if (doPrevent) {
        event.preventDefault();
    }
});

function F_Controles_Inicializar() {

    utF_Conceptos_Combos('#MainContent_ddlEstado', 27);
    utF_Conceptos_Combos('#MainContent_ddlEstadoEdicion', 27);

    return true;
}

function F_ValidarGrabarDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtDescripcion2').val() == '')
            Cadena = Cadena + '<p></p>' + 'Observacion';

        if ($(Cuerpo + 'ddlEstado').val() == 0 || $(Cuerpo + 'ddlEstado').val() == null)
            Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {

    var objEntidad = {};
    objEntidad["CodRegimenLaboral"] = $("#hfCodigo").val();
    objEntidad["Descripcion"] = $('#MainContent_txtDescripcion').val().trim();
    objEntidad["Descripcion2"] = $('#MainContent_txtDescripcion2').val().trim();
    objEntidad["CodEstado"] = Number($('#MainContent_ddlEstado').val());
    objEntidad["RegistroOperacion"] = "Insert";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DatosPlanilla_RegimenLaboral.asmx/F_RegimenLaboral_Actualizar',
        data: JSON.stringify(objEntidad),
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.MsgError === "SE GRABO CORRECTAMENTE") {
                    toastr.success('SE GRABO CORRECTAMENTE');
                    F_Nuevo();
                } else {
                    toastr.error(data.MsgError);
                }
            }
            catch (x) { toastr.error('ERROR AL GRABAR'); }
        },
        complete: function () {

        },
        error: function (response) {
            toastr.error(response.responseText);
        },
        failure: function (response) {
            toastr.error(response.responseText);
        }
    });

    return true;
}

function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtDescripcion2').val('');
    $(Contenedor + 'ddlEstado').val(1);
    $('#hfCodigo').val(0);
    return false;
}

function F_Buscar() {

    try {
        var objParams = {
            Filtro_DscFamilia: $("#MainContent_txtDescripcionConsulta").val()

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                if (str_mensaje_operacion != "")
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
        return false;
    }

}

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false;
    try {
        var imgID = Fila.id;
        var hfCodLinea = '#' + imgID.replace('imgAnularDocumento', 'hfCodLinea');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL REGIMEN LABORAL " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodLinea: $(hfCodLinea).val(),
            Filtro_Descripcion: $('#MainContent_txtDescripcionConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                toastr.success(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    try {
        var imgID = Fila.id;
        var hfID = '#' + imgID.replace('imgEditarRegistro', 'hfID');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfDescripcion2 = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcion2');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';

        $('#hfCodigo').val($(hfID).val());

        $(Cuerpo + 'txtDescripcionEdicion').val($(lblDescripcion).text());
        $(Cuerpo + 'txtDescripcion2Edicion').val($(hfCodEstado).text());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());

        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Linea",
            title_html: true,
            height: 300,
            width: 530,
            autoOpen: false
        });

        $('#divEdicionRegistro').dialog('open');

        return false;
    }

    catch (e) {
        toastr.error("Error Detectado: " + e);
        return false;
    }

}

function F_EdicionRegistro() {

    var objEntidad = {};
    objEntidad["CodRegimenLaboral"] = $("#hfCodigo").val();
    objEntidad["Descripcion"] = $('#MainContent_txtDescripcionEdicion').val().trim();
    objEntidad["Descripcion2"] = $('#MainContent_txtDescripcion2Edicion').val().trim();
    objEntidad["CodEstado"] = Number($('#MainContent_ddlEstadoEdicion').val());
    objEntidad["RegistroOperacion"] = "Edit";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DatosPlanilla_RegimenLaboral.asmx/F_RegimenLaboral_Actualizar',
        data: JSON.stringify(objEntidad),
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.MsgError === "SE ACTUALIZO CORRECTAMENTE") {
                    toastr.success('SE ACTUALIZO CORRECTAMENTE');

                    $('#divEdicionRegistro').dialog('close');

                    F_Buscar();
                } else {
                    toastr.error(data.MsgError);
                }
            }
            catch (x) { toastr.error('ERROR AL grabar'); }
        },
        complete: function () {

        },
        error: function (response) {
            toastr.error(response.responseText);
        },
        failure: function (response) {
            toastr.error(response.responseText);
        }
    });

    return true;
}

function F_ValidarEdicionDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'ddlEstadoEdicion').val() == 0 || $(Cuerpo + 'ddlEstadoEdicion').val() == null)
            Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.error("Error Detectado: " + e);
    }
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length == 8) {
            suma = 0
            for (i = 0; i < valor.length - 1; i++) {

                if (i == 0) suma += (digito * 2)
                else suma += (digito * (valor.length - i))
            }
            resto = suma % 11;
            if (resto == 1) resto = 11;
            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
                return true
            }
        } else if (valor.length == 11) {
            suma = 0
            x = 6
            for (i = 0; i < valor.length - 1; i++) {
                if (i == 4) x = 8
                digito = valor.charAt(i) - '0';
                x--
                if (i == 0) suma += (digito * x)
                else suma += (digito * x)
            }
            resto = suma % 11;
            resto = 11 - resto

            if (resto >= 10) resto = resto - 10;
            if (resto == valor.charAt(valor.length - 1) - '0') {
                return true
            }
        }
    }
    return false
}

function esnumero(campo) { return (!(isNaN(campo))); }

function MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        //        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}
