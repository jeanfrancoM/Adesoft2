var AppSession = "../Planilla/MaestroCategoriaValores.aspx";
var CodigoMenu = 8000;
var CodigoInterno = 80;   
$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            F_Agregar_NoAsignados();
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
            //if (!F_ValidarGrabarDocumento())
            //    return false;

            if (confirm("ESTA SEGURO DE GRABAR LA LINEA"))
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


    $('#MainContent_btnBuscarNoAsignados').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 80008002, '') === "0") return false;
        try {
            F_BuscarNoAsignados();
            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DE LA LINEA"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });


    $('#MainContent_btnGenerarReintegros').click(function () {
        if (F_PermisoOpcion(CodigoMenu, 80008001, '') === "0") return false;
        try {

            F_Reintegros();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnRecalcularReintegros').click(function () {
        try {

            F_Reintegros_Recalcular();

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

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());


    $('.Jq-ui-dtp').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }


    
});

$('.Jq-ui-dtp').datepicker({ beforeShowDay: function (date) {
    return [date.getDate() == 1, ''];
} 
});

});

$(document).on("change", "select[id $= 'MainContent_ddlCategoria']", function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
    F_Buscar();
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

    //utF_Conceptos_Combos('#MainContent_ddlEstado', 27);
    //utF_Conceptos_Combos('#MainContent_ddlEstadoEdicion', 27);

    utF_Planilla_Categoria_Listar('#MainContent_ddlCategoria', '');
    //utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboralEdicion', '');

    $('.ccsestilo').css('background', '#FFFFE0');

    F_Buscar();
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


        var count = 0;
        $('#MainContent_grvConsulta .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;

            if ($(chkSi).is(':checked')) {
                count++;            
            }

        });

        if (count === 0)
            Cadena = Cadena + '<p></p>' + 'DEBE SELECCIONAR AL MENOS UNA';

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

    $('#MainContent_grvConsulta .chkSi :checkbox').each(function () {
        var chkSi = '#' + this.id;
        if ($(chkSi).is(':checked')) {


            var hfCodCodCategoriaValores = chkSi.replace('chkOK', 'hfID');
            var hfCodCodCategoria = chkSi.replace('chkOK', 'hfCodCodCategoria');
            var hfCodConceptoRemuneracion = chkSi.replace('chkOK', 'hfCodConceptoRemuneracion');
            var txtValor = chkSi.replace('chkOK', 'txtValor');
            var txtValor2 = chkSi.replace('chkOK', 'txtValor2');
            var txtObservacion = chkSi.replace('chkOK', 'txtObservacion');
            var txtTopeDiferencia = chkSi.replace('chkOK', 'txtTopeDiferencia');
            var txtFechaInicial = chkSi.replace('chkOK', 'txtFechaInicial');
            var txtFechaFinal = chkSi.replace('chkOK', 'txtFechaFinal');

            var objEntidad = {};
            objEntidad["CodCodCategoriaValores"] = Number($(hfCodCodCategoriaValores).val()); //int
            objEntidad["CodCodCategoria"] = Number($(hfCodCodCategoria).val()); //int
            objEntidad["CodConceptoRemuneracion"] = Number($(hfCodConceptoRemuneracion).val()); //int
            objEntidad["Valor"] = Number($(txtValor).val()); //decimal
            objEntidad["Observacion"] = $(txtObservacion).val().trim();
            objEntidad["Valor2"] = Number($(txtValor2).val()); //decimal
            objEntidad["TopeDiferencia"] = $(txtTopeDiferencia).val(); //decimal
            objEntidad["FechaInicial"] = $("#MainContent_txtFechaInicial").val();
            objEntidad["FechaFinal"] = $("#MainContent_txtFechaFinal").val();
            objEntidad["RegistroOperacion"] = (Number($(hfCodCodCategoriaValores).val()) == 0) ? "Insert" : "Update";

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DatosPlanilla_CategoriaValores.asmx/F_CategoriaValores_Actualizar',
                data: JSON.stringify(objEntidad),
                dataType: "json",
                async: false,
                success: function (dbObject) {
                    var data = dbObject.d;
                    try {
                        if (data.MsgError === "SE GRABO CORRECTAMENTE" || data.MsgError === "SE ACTUALIZO CORRECTAMENTE" || data.MsgError === "") {
                            toastr.success("SE GRABO CORRECTAMENTE");
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




        }
    });

    F_Buscar();

    return true;
}

function F_Agregar_NoAsignados() {

    $('#MainContent_grvConceptosNoAsignados .chkSi :checkbox').each(function () {
        var chkSi = '#' + this.id;
        if ($(chkSi).is(':checked')) {


            var hfCodConceptoRemuneracion = chkSi.replace('chkOK', 'hfID');
            var CodCodCategoria = $('#MainContent_ddlCategoria').val();

            var objEntidad = {};
            objEntidad["CodConceptoRemuneracion"] = Number($(hfCodConceptoRemuneracion).val()); //int
            objEntidad["CodCodCategoria"] = Number(CodCodCategoria); //int
            

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DatosPlanilla_CategoriaValores.asmx/F_CategoriaValores_Agregar',
                data: JSON.stringify(objEntidad),
                dataType: "json",
                async: false,
                success: function (dbObject) {
                    var data = dbObject.d;
                    try {
                        if (data.MsgError === "SE GRABO CORRECTAMENTE" || data.MsgError === "SE ACTUALIZO CORRECTAMENTE" || data.MsgError === "") {
                            toastr.success("SE GRABO CORRECTAMENTE");
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




        }
    });

    $('#div_AgregarConcepto').dialog('close');
    F_Buscar();

    return true;
}


function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'ddlEstado').val(1);
    $('#hfCodigo').val(0);
    return false;
}

function F_Buscar() {

    try {
        var objParams = {
            Filtro_CodCategoria: $("#MainContent_ddlCategoria").val()

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

                $('.ccsestilo').css('background', '#FFFFE0');
                $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);


                $('#MainContent_grvConsulta .chkSi :checkbox').each(function () {
                    var chkSi = '#' + this.id;

                    var hfFechaInicial = chkSi.replace('chkOK', 'hfFechaInicial');
                    var hfFechaFinal = chkSi.replace('chkOK', 'hfFechaFinal');

                    $('#MainContent_txtFechaInicial').val($(hfFechaInicial).val());
                    $('#MainContent_txtFechaFinal').val($(hfFechaFinal).val());

                });

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

function F_BuscarNoAsignados() {

    try {
        var objParams = {
            Filtro_CodCategoria: $("#MainContent_ddlCategoria").val()

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_BuscarNoAsignados_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_TableConceptosNoAsignados', result.split('~')[2]);
                if (str_mensaje_operacion != "")
                    toastr.warning(result.split('~')[1]);

                $("#div_AgregarConcepto").dialog({
                    resizable: false,
                    modal: true,
                    title: "CONCEPTOS NO ASIGNADOS",
                    title_html: true,
                    height: 300,
                    width: 530,
                    autoOpen: false
                });

                $('#div_AgregarConcepto').dialog('open');

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
    try {
        var imgID = Fila.id;
        var hfCodLinea = '#' + imgID.replace('imgAnularDocumento', 'hfID');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA LINEA " + $(lblDescripcion).text()))
            return false;

        var objEntidad = {};
        objEntidad["CodCategoria"] = $(hfCodLinea).val();

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/DatosPlanilla_Categoria.asmx/F_Categoria_Eliminar',
            data: JSON.stringify(objEntidad),
            dataType: "json",
            async: false,
            success: function (dbObject) {
                var data = dbObject.d;
                try {
                    if (data.MsgError === "SE ELIMINO CORRECTAMENTE") {
                        toastr.success('SE ELIMINO CORRECTAMENTE');
                        F_Buscar();
                    } else {
                        toastr.error(data.MsgError);
                    }
                }
                catch (x) { toastr.error('ERROR AL ELIMINAR'); }
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
        var hfCodRegimenLaboral = '#' + imgID.replace('imgEditarRegistro', 'hfCodRegimenLaboral');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';

        $('#hfCodigo').val($(hfID).val());

        $(Cuerpo + 'txtDescripcionEdicion').val($(lblDescripcion).text());
        $(Cuerpo + 'ddlRegimenLaboralEdicion').val($(hfCodRegimenLaboral).val());
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
    objEntidad["CodCategoria"] = $("#hfCodigo").val();
    objEntidad["Descripcion"] = $('#MainContent_txtDescripcionEdicion').val().trim();
    objEntidad["CodRegimenLaboral"] = $('#MainContent_ddlRegimenLaboralEdicion').val().trim();
    objEntidad["CodEstado"] = Number($('#MainContent_ddlEstadoEdicion').val());
    objEntidad["RegistroOperacion"] = "Edit";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DatosPlanilla_Categoria.asmx/F_Categoria_Actualizar',
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










function F_ValidarCheck(ControlID) {


    var cadena = 'Ingrese los sgtes. campos: '

    var chkok_grilla = '#' + ControlID;
    var txtValor = chkok_grilla.replace('chkOK', 'txtValor');
    var txtValor2 = chkok_grilla.replace('chkOK', 'txtValor2');
    var txtObservacion = chkok_grilla.replace('chkOK', 'txtObservacion');
    var txtTopeDiferencia = chkok_grilla.replace('chkOK', 'txtTopeDiferencia');

    var hfValor = chkok_grilla.replace('chkOK', 'hfValor');
    var hfValor2 = chkok_grilla.replace('chkOK', 'hfValor2');
    var hfObservacion = chkok_grilla.replace('chkOK', 'hfObservacion');
    var hfTopeDiferencia = chkok_grilla.replace('chkOK', 'hfTopeDiferencia');
    var hfFechaInicial = chkok_grilla.replace('chkOK', 'hfFechaInicial');
    var hfFechaFinal = chkok_grilla.replace('chkOK', 'hfFechaFinal');

    var txtFechaInicial = chkok_grilla.replace('chkOK', 'txtFechaInicial');
    var txtFechaFinal = chkok_grilla.replace('chkOK', 'txtFechaFinal');


    var boolEstado = $(chkok_grilla).is(':checked');

    if (boolEstado) {

        $(txtValor).prop('disabled', false);
        $(txtValor2).prop('disabled', false);
        $(txtObservacion).prop('disabled', false);
        $(txtTopeDiferencia).prop('disabled', false);
        $(txtFechaInicial).prop('disabled', false);
        $(txtFechaFinal).prop('disabled', false);

        var i = 0;
        //if ($(txtprecio_grilla).val() == "") {
            $(txtValor).select();
            //i = 1
        //}

    }
        else {

        $(txtValor).val($(hfValor).val());
        $(txtValor2).val($(hfValor2).val());
        $(txtObservacion).val($(hfObservacion).val());
        $(txtTopeDiferencia).val($(hfTopeDiferencia).val());
        $(txtFechaInicial).val($(hfFechaInicial).val());
        $(txtFechaFinal).val($(hfFechaFinal).val());

        $(txtValor).prop('disabled', true);
        $(txtValor2).prop('disabled', true);
        $(txtObservacion).prop('disabled', true);
        $(txtTopeDiferencia).prop('disabled', true);
        $(txtFechaInicial).prop('disabled', true);
        $(txtFechaFinal).prop('disabled', true);
    }


    return true;
}









function F_Reintegros() {


    try {
        var objParams = {
            Filtro_CodCategoria: $("#MainContent_ddlCategoria").val(),
            Filtro_flagTodos: 0,

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Planilla_Buscar_Nominas_Reintegros_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_GrillaReintegros', result.split('~')[2]);
                if (str_mensaje_operacion != "")
                    toastr.warning(result.split('~')[1]);

                $("#div_Reintegros").dialog({
                    resizable: false,
                    modal: true,
                    title: "Reintegros",
                    title_html: true,
                    height: 500,
                    width: 900,
                    autoOpen: false,                    
                    open: function (event, ui) {
                        $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
                    }
                });


                $('#div_Reintegros').dialog('open');

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


function F_Reintegros_Recalcular() {

        var Cadena = 'Ingresar los sgtes. Datos:';

        var count = 0;
        $('#MainContent_grvReintegros .chkDelete :checkbox').each(function () {
            var chkSi = '#' + this.id;

            if ($(chkSi).is(':checked')) {
                count++;            
            }
        });

        if (count === 0)
            Cadena = Cadena + '<p></p>' + 'DEBE SELECCIONAR AL MENOS UNA';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }


    if (!confirm("¿SEGURO DE REGENERAR LOS REINTEGROS?"))
        return false;


    $('#MainContent_grvReintegros .chkDelete :checkbox').each(function () {
        var chkSi = '#' + this.id;

        if ($(chkSi).is(':checked')) {
            var IDExcel = chkSi.replace("chkEliminar", "hfIDExcel");
            

            var objEntidad = {};
            objEntidad["IDExcel"] = $(IDExcel).val();

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DatosPlanilla_CategoriaValores.asmx/F_CategoriaValores_Recalcular_Reintegro',
                data: JSON.stringify(objEntidad),
                dataType: "json",
                async: false,
                success: function (dbObject) {
                    var data = dbObject.d;
                    try {
                        if (data.MsgError === "SE GRABO CORRECTAMENTE") {

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



        }
    });


    toastr.success('SE ACTUALIZO CORRECTAMENTE');
    F_Reintegros();

    return true;
}








function checkAll(objRef)
{
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvReintegros input:checkbox').prop('checked', true);
        else
        $('#MainContent_grvReintegros input:checkbox').prop('checked', false);
}


