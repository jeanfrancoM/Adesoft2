var AppSession = "../Maestros/Servicios.aspx";
var CodigoMenu = 1000;
var CodigoInterno = 12;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_imgBuscar').click(function () {
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "")
                cadena = cadena + "\n" + "Articulo"

            if ($('#MainContent_ddlMoneda option').size() == 0)
            { cadena = cadena + "\n" + "Moneda"; }
            else {
                if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
            }

            if (cadena != "Ingresar los sgtes. campos :") {
                alertify.log(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL SERVICIO"))
                F_GrabarDocumento();
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Buscar();
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR EL SERVICIO"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $("#MainContent_txtCostoConIgv").blur(function () {

        if ($("#MainContent_txtCostoConIgv") == '')
            return false;

        $("#MainContent_txtPrecio1").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.12).toFixed(2));
        $("#MainContent_txtPrecio2").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.15).toFixed(2));
        $("#MainContent_txtPrecio3").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.20).toFixed(2));

        if ($("#MainContent_ddlMoneda").val() == '2')
            $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val() * $("#MainContent_txtTC").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesIgv").val($("#MainContent_txtCostoConIgv").val());

        return false;

    });

    $("#MainContent_txtCostoEdicion").blur(function () {

        if ($("#MainContent_txtCostoEdicion") == '')
            return false;

        $("#MainContent_txtPrecio1Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.12).toFixed(2));
        $("#MainContent_txtPrecio2Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.15).toFixed(2));
        $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.20).toFixed(2));

        if ($("#MainContent_ddlMonedaEdicion").val() == '2')
            $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTcEdicion").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesEdicion").val($("#MainContent_txtCostoEdicion").val());

        if ($('#hfCodigoTemporal').val() == '1')
            $("#MainContent_txtCostoMercadoEdicion").val($("#MainContent_txtCostoEdicion").val());

        return false;

    });

    $("#MainContent_txtCostoMercadoEdicion").blur(function () {

        if ($("#MainContent_txtCostoMercadoEdicion") == '')
            return false;

        $("#MainContent_txtPrecio1Edicion").val(parseFloat($("#MainContent_txtCostoMercadoEdicion").val() * 1.12).toFixed(2));
        $("#MainContent_txtPrecio2Edicion").val(parseFloat($("#MainContent_txtCostoMercadoEdicion").val() * 1.15).toFixed(2));
        $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoMercadoEdicion").val() * 1.20).toFixed(2));

        return false;

    });

    $("#MainContent_txtDescripcionConsulta").blur(function () {

        var cadena = "Ingresar los sgtes. campos :";

        if ($('#MainContent_txtDescripcionConsulta').val == "" | $('#MainContent_txtDescripcionConsulta').val().length < 3)
            cadena = cadena + "\n" + "Servicio (Minimo 3 Caracteres)"

        if (cadena != "Ingresar los sgtes. campos :") {
            alertify.log(cadena);
            return false;
        }

        F_Buscar();
    });

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

});

$().ready(function () {

    $(document).everyTime(900000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });


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

function VerifySessionState(result) { }

$(document).on("change", "select[id $= 'MainContent_ddlFamilia']", function () {
    F_ValidarFamilia($("#MainContent_ddlFamilia").val(), 0);
});

$(document).on("change", "select[id $= 'MainContent_ddlFamiliaEdicion']", function () {
    F_ValidarFamilia($("#MainContent_ddlFamiliaEdicion").val(), 1);
});

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']", function () {
    if ($("#MainContent_txtCostoConIgv") == '')
        return false;

    $("#MainContent_txtPrecio1").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.12).toFixed(2));
    $("#MainContent_txtPrecio2").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.15).toFixed(2));
    $("#MainContent_txtPrecio3").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.20).toFixed(2));

    if ($("#MainContent_ddlMoneda").val() == '2')
        $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val() * $("#MainContent_txtTC").val()).toFixed(6));
    else
        $("#MainContent_txtCostoSolesIgv").val($("#MainContent_txtCostoConIgv").val());

    return false;
});

$(document).on("change", "select[id $= 'MainContent_ddlMonedaEdicion']", function () {
    if ($("#MainContent_txtCostoEdicion") == '')
        return false;

    $("#MainContent_txtPrecio1Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.12).toFixed(2));
    $("#MainContent_txtPrecio2Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.15).toFixed(2));
    $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.20).toFixed(2));

    if ($("#MainContent_ddlMonedaEdicion").val() == '2')
        $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTcEdicion").val()).toFixed(6));
    else
        $("#MainContent_txtCostoSolesEdicion").val($("#MainContent_txtCostoEdicion").val());

    return false;
});

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams = {};

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {

                        F_Update_Division_HTML('div_moneda', result.split('~')[2]);
                        F_Update_Division_HTML('div_umcompra', result.split('~')[4]);
                        F_Update_Division_HTML('div_umventa', result.split('~')[5]);
                        F_Update_Division_HTML('div_Familia', result.split('~')[6]);
                        F_Update_Division_HTML('div_familiaconsulta', result.split('~')[7]);
                        F_Update_Division_HTML('div_FamiliaEdicion', result.split('~')[8]);
                        F_Update_Division_HTML('div_MonedaEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_CompraEdicion', result.split('~')[10]);
                        F_Update_Division_HTML('div_VentaEdicion', result.split('~')[11]);
                        $('#MainContent_ddlMoneda').val('2');
                        $('#MainContent_ddlUMCompra').val('22');
                        $('#MainContent_ddlUMVenta').val('22');
                        $('#MainContent_txtFactor').val('1');
                        $('#MainContent_ddlFamiliaConsulta').val('0');
                        $('#MainContent_txtCostoSolesIgv').prop('disabled', true);
                        $('#MainContent_txtPrecio1').prop('disabled', true);
                        $('#MainContent_txtPrecio2').prop('disabled', true);
                        $('#MainContent_txtPrecio3').prop('disabled', true);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMCompra').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMVenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCompraEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlVentaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMonedaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaConsulta').css('background', '#FFFFE0');

                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_ValidarFamilia(CodFamilia, Mantenimiento) {
    var arg;
    try {
        if (Mantenimiento == '0') {
            switch (CodFamilia) {
                case "006":
                case "008":
                    $('#MainContent_txtAro').prop('disabled', false);
                    $('#MainContent_txtMedida').prop('disabled', true);
                    $('#MainContent_txtSeccion').prop('disabled', true);
                    $('#MainContent_txtMedida').val('');
                    $('#MainContent_txtSeccion').val('');
                    break;
                case "001":
                case "003":
                case "007":
                    $('#MainContent_txtAro').prop('disabled', false);
                    $('#MainContent_txtMedida').prop('disabled', false);
                    $('#MainContent_txtSeccion').prop('disabled', false);

                    break;
                default:
                    $('#MainContent_txtAro').prop('disabled', true);
                    $('#MainContent_txtMedida').prop('disabled', true);
                    $('#MainContent_txtSeccion').prop('disabled', true);
                    $('#MainContent_txtAro').val('');
                    $('#MainContent_txtMedida').val('');
                    $('#MainContent_txtSeccion').val('');
                    break;
            }
        }
        else {
            switch (CodFamilia) {

                case "006":
                case "008":
                    $('#MainContent_txtAroEdicion').prop('disabled', false);
                    $('#MainContent_txtMedidaEdicion').prop('disabled', true);
                    $('#MainContent_txtSeccionEdicion').prop('disabled', true);
                    $('#MainContent_txtMedidaEdicion').val('');
                    $('#MainContent_txtSeccionEdicion').val('');
                    break;
                case "007":
                case "001":
                case "003":
                    $('#MainContent_txtAroEdicion').prop('disabled', false);
                    $('#MainContent_txtMedidaEdicion').prop('disabled', true);
                    $('#MainContent_txtSeccionEdicion').prop('disabled', true);
                    break;
                default:
                    $('#MainContent_txtAroEdicion').prop('disabled', true);
                    $('#MainContent_txtMedidaEdicion').prop('disabled', true);
                    $('#MainContent_txtSeccionEdicion').prop('disabled', true);
                    $('#MainContent_txtAroEdicion').val('');
                    $('#MainContent_txtMedidaEdicion').val('');
                    $('#MainContent_txtSeccionEdicion').val('');
                    break;
            }
        }



    }
    catch (mierror) {
        alertify.log("Error detectado: " + mierror);
    }

}

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtTC').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtFactor').val() == '')
            Cadena = Cadena + '<p></p>' + 'Factor';

        if (($(Cuerpo + 'ddlUMCompra').val() != $(Cuerpo + 'ddlUMVenta').val()) && ($(Cuerpo + 'txtFactor').val() == '1' | $(Cuerpo + 'txtFactor').val() == '1.00'))
            Cadena = Cadena + '<p></p>' + 'El Factor no puede ser 1.';

        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003' | $(Cuerpo + 'ddlFamilia').val() == '007' | $(Cuerpo + 'ddlFamilia').val() == '008' | $(Cuerpo + 'ddlFamilia').val() == '006') && $(Cuerpo + 'txtAro').val() == '')
            Cadena = Cadena + '<p></p>' + 'Aro/Peso/Placas';

        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003' | $(Cuerpo + 'ddlFamilia').val() == '007') && $(Cuerpo + 'txtMedida').val() == '')
            Cadena = Cadena + '<p></p>' + 'Medida';

        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003' | $(Cuerpo + 'ddlFamilia').val() == '007') && $(Cuerpo + 'txtSeccion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Seccion';

        if ($(Cuerpo + 'txtCostoConIgv').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtPrecio1').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 1';

        if ($(Cuerpo + 'txtPrecio2').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 2';

        if ($(Cuerpo + 'txtPrecio3').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 3';


        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            alertify.log(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {

    try {
        var Contenedor = '#MainContent_';

        var objParams = {
          Filtro_CodigoProducto: $(Contenedor + 'txtCodigo').val().toUpperCase().trim(),
          Filtro_DscProducto: $(Contenedor + 'txtDescripcion').val()
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {
     
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente.') {
                    $(Contenedor + 'txtCodigo').val('');
                    $(Contenedor + 'txtDescripcion').val('');
                    alertify.log('Se Grabo Correctamente.');
                    $(Contenedor + 'txtDescripcion').focus();
                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {

    var Contenedor = '#MainContent_';

    $(Contenedor + 'txtCodigo').val('');
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtAro').val('');
    $(Contenedor + 'txtMedida').val('');
    $(Contenedor + 'txtSeccion').val(''),
                        $(Contenedor + 'txtFactor').val('1'),
                        $(Contenedor + 'txtCostoConIgv').val('');
    $(Contenedor + 'txtCostoSolesIgv').val('');
    $(Contenedor + 'ddlMoneda').val('2');
    $(Contenedor + 'ddlUMCompra').val('22');
    $(Contenedor + 'ddlUMVenta').val('22');
    $(Contenedor + 'ddlFamilia').val('007');
    $(Contenedor + 'txtPrecio1').val(''),
                        $(Contenedor + 'txtPrecio2').val('');
    $(Contenedor + 'txtPrecio3').val('');
    $(Contenedor + 'txtAro').prop('disabled', false);
    $(Contenedor + 'txtMedida').prop('disabled', false);
    $(Contenedor + 'txtSeccion').prop('disabled', false),
                        $(Contenedor + 'txtCodigo').focus();
    return false;
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac

    try {
        var objParams = {
            Filtro_Descripcion: $("#MainContent_txtDescripcionConsulta").val(),
            Filtro_CodFamilia: $('#MainContent_ddlFamiliaConsulta').val()

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodigo'));
                if (str_mensaje_operacion != "")
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        var imgID = Fila.id;

        var lblID = '#' + imgID.replace('imgAnularDocumento', 'lblID');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblProducto');


        if (!confirm("ESTA SEGURO DE ELIMINAR SERVICIO " + $(lblProducto_grilla).text()))
            return false;

        var objParams = {
            Filtro_CodProducto: $(lblID).val(),
            Filtro_Descripcion: $('#MainContent_txtDescripcionConsulta').val(),
            Filtro_CodFamilia: $('#MainContent_ddlFamiliaConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AnularRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                alertify.log(result.split('~')[1]);
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac

    try {
        var imgID = Fila.id;
        var lblID = '#' + imgID.replace('imgEditarRegistro', 'lblID');
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtCodigoEdicion').val($(lblCodigo).text());
        $(Cuerpo + 'txtDescripcionEdicion').val($(lblDescripcion).text());

        $('#hfCodProducto').val($(lblID).val());

        $("#divEdicionRegistro").dialog({
                    resizable: false,
                    modal: true,
                    title: "Edicion de Servicios",
                    title_html: true,
                    height: 250,
                    width: 655,
                    autoOpen: false
        });

        $('#divEdicionRegistro').dialog('open');

        return false;
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_EdicionRegistro() {

    try {
        var Contenedor = '#MainContent_';
     
        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_DscProductoEdicion: $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigoEdicion').val(),
            Filtro_CodFamilia: '0',
            Filtro_CodTipoProducto: 1,
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionConsulta').val()
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionRegistro_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Actualizo Correctamente.') {
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $(Contenedor + 'txtCodigoEdicion').val('');
                    $(Contenedor + 'txtDescripcionEdicion').val('');
                    alertify.log('Se Actualizo Correctamente.');
                    $('#divEdicionRegistro').dialog('close');
                }
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarEdicionDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            alertify.log(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

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
