var AppSession = "../Maestros/ProductosReeim.aspx";
var myDropzone = null;
var mydropzone_Edit = null;

var CodigoMenu = 1000;
var CodigoInterno = 3;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    F_FuncionesBotones();

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtModeloDetalle').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MODELOVEHICULO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodModeloDetalle').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 2
    });

    $('#MainContent_txtModeloDetalleEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MODELOVEHICULO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodModeloDetalleEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 2
    });

    $('#MainContent_txtLinea').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_Linea_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodLinea').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtLineaEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_Linea_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodLineaEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtMarca').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MARCAPRODUCTO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodMarca').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtMarcaEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MARCAPRODUCTO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodMarcaEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#divTabs').tabs();
    $('#div_tab2').tabs();

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL PRODUCTO"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarDetalle').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDetalle())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL DETALLE DEL PRODUCTO"))
                F_GrabarDetalle();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarDetalleEdicion').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDetalleEdicion())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR EL DETALLE DEL PRODUCTO"))
                F_EdicionDetalleRegistro();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnLimpiarConsulta').click(function () {
        try {
            $("#MainContent_txtDescripcionConsulta").val('');
            $("#MainContent_txtDescripcionConsulta2").val('');
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL PRODUCTO"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $("#MainContent_txtCostoConIgv").blur(function () {
        F_Precio(0);
    });
    
    $("#MainContent_txtCostoEdicion").blur(function () {
        F_Precio(1);
    });

    $("#MainContent_txtFactorEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoSolesEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecioEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoMercadoEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtFactor").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCosto").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoSoles").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtMargen").blur(function () {
        F_Precio(0);
    });

    $("#MainContent_txtMargenEdicion").blur(function () {
        F_Precio(1);
    });

    $("#MainContent_txtMargen2").blur(function () {
        F_Precio(0);
    });

    $("#MainContent_txtMargen2Edicion").blur(function () {
        F_Precio(1);
    });

    F_Controles_Inicializar();

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');

    $('#MainContent_txtTC').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo2').css('background', '#FFFFE0');

    $('#MainContent_txtPartidaArancelaria').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtLinea').css('background', '#FFFFE0');

    $('#MainContent_txtMarca').css('background', '#FFFFE0');

    $('#MainContent_txtModelo').css('background', '#FFFFE0');

    $('#MainContent_txtMedida').css('background', '#FFFFE0');

    $('#MainContent_txtPosicion').css('background', '#FFFFE0');

    $('#MainContent_txtAño').css('background', '#FFFFE0');

    $('#MainContent_txtCostoConIgv').css('background', '#FFFFE0');

    $('#MainContent_txtCostoSolesIgv').css('background', '#FFFFE0');

    $('#MainContent_txtFactor').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio1').css('background', '#FFFFE0');

    $('#MainContent_txtStockMinimo').css('background', '#FFFFE0');

    $('#MainContent_txtStockMaximo').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProductoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTCEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPartidaArancelariaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtLineaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMedidaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPosicionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAñoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCostoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCostoSolesEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtFactorEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecioEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtStockMinimoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtStockMaximoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMargen').css('background', '#FFFFE0');

    $('#MainContent_txtDescuento').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtMargenEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescuentoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMargen2').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio2').css('background', '#FFFFE0');

    $('#MainContent_ddlFiltroCodEstado').css('background', '#FFFFE0');

    $('#MainContent_txtMargen2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtTCEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtProductoDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtModeloDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtAñoDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtMotorDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtProductoDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAñoDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMotorDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCajaCambio').css('background', '#FFFFE0');

    $('#MainContent_txtFiltro').css('background', '#FFFFE0');

    $('#MainContent_txtTransmision').css('background', '#FFFFE0');

    $('#MainContent_txtCajaCambioEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtFiltroEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTransmisionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtProductoHistorial').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaHistorial').css('background', '#FFFFE0');

    $('#MainContent_txtCostoActual').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoFabrica').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta2').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta3').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoFabricaEdicion').css('background', '#FFFFE0');

    F_Derecha();
});

function F_FuncionesBotones() {
    var k = new Kibo();

    k.down("enter", function () {

        var control = $(':focus');
        var inputs = control.parents("form").eq(0).find("input, select");
        var idx = inputs.index(control);

        if (idx == inputs.length - 1) {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
                F_Buscar();

        } else {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
                F_Buscar();
        }

        if (idx == inputs.length - 1) {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta2')
                F_Buscar();

        } else {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta2')
                F_Buscar();
        }

        if (idx == inputs.length - 1) {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta3')
                F_Buscar();

        } else {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta3')
                F_Buscar();
        }
        return false;
    });
}

$().ready(function () {
    $(document).everyTime(600000, function () {
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

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']", function () {
    F_Precio(0);
});

$(document).on("change", "select[id $= 'MainContent_ddlMonedaEdicion']", function () {
    F_Precio(1);
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
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[12]);
                        $('#MainContent_ddlMoneda').val('2');
                        $('#MainContent_ddlUMCompra').val('22');
                        $('#MainContent_ddlUMVenta').val('22');
                        $('#MainContent_txtFactor').val('1');
                        $('#MainContent_ddlFamilia').val('78');
                        $('#MainContent_ddlFamiliaConsulta').val('0');
                        $('#MainContent_txtTCEdicion').val(result.split('~')[3]);
                        $('#MainContent_txtTC').val(result.split('~')[3]);
                        $('#MainContent_txtCostoSolesIgv').prop('disabled', true);
                        $('#MainContent_txtPrecio2').prop('disabled', true);
                        $('#MainContent_txtPrecio').prop('disabled', true);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMCompra').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMVenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCompraEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlVentaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMonedaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_txtCodigoVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtCodigo2Visualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtDescripcionVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtMedidaVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtLineaVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtMarcaVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtModeloVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtPosicionVisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtAnovisualizacion').css('background', '#FFFFE0');
                        $('#MainContent_txtCodigo').focus();
                        F_AbrirDropzone_JS();
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                }
            );
    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
    }
}

function F_ValidarGrabarDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtTC').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtLinea').val()=='')
                Cadena=Cadena + '<p></p>' + 'LINEA';
        
        if ($(Cuerpo + 'txtMarca').val() =='')
                Cadena=Cadena + '<p></p>' + 'MARCA';
        
        if ($(Cuerpo + 'txtCostoConIgv').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtMargen').val() == '')
            Cadena = Cadena + '<p></p>' + 'Margen';

        if ($(Cuerpo + 'txtPrecio1').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio ';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {
    try {
        var Contenedor = '#MainContent_';
        
        if ($(Contenedor + 'txtStockMinimo').val() == '')
            $(Contenedor + 'txtStockMinimo').val('0.00');

        if ($(Contenedor + 'txtStockMaximo').val() == '')
            $(Contenedor + 'txtStockMaximo').val('0.00');

        var CostoSoles = 0;
        var CostoDolares = 0;
        var Precio1Dolares = 0;
        var Precio2Dolares = 0;
        var Precio3Dolares = 0;

        if ($(Contenedor + 'ddlMoneda').val() == '1') {
            CostoSoles = $(Contenedor + 'txtCostoConIgv').val();
            CostoDolares = (Number($(Contenedor + 'txtCostoConIgv').val()) / Number($(Contenedor + 'txtTC').val())).toFixed(2);
            Precio1Dolares = (Number($(Contenedor + 'txtPrecio').val()) / Number($(Contenedor + 'txtTC').val())).toFixed(2);
            Precio2Dolares = (Number($(Contenedor + 'txtPrecio2').val()) / Number($(Contenedor + 'txtTC').val())).toFixed(2);
            Precio3Dolares = 0;
        } else {
            CostoSoles = (Number($(Contenedor + 'txtCostoConIgv').val()) * Number($(Contenedor + 'txtTC').val())).toFixed(2);
            CostoDolares = $(Contenedor + 'txtCostoConIgv').val();
            Precio1Dolares = Number($(Contenedor + 'txtPrecio').val());
            Precio2Dolares = Number($(Contenedor + 'txtPrecio2').val());
            Precio3Dolares = 0;
        }

        // recorrido para seleccionar imagen
        var arrImg = new Array();
        $('.dz-preview').each(function () {
            arrImg.push(this.id);
        });

        var objParams = {
            Filtro_IdFamilia: $(Contenedor + 'ddlFamilia').val(),
            Filtro_DscProducto: $(Contenedor + 'txtDescripcion').val(),
            Filtro_DscProductoIngles: $(Contenedor + 'txtLinea').val(),
            Filtro_PartidaArancelaria: $(Contenedor + 'txtPartidaArancelaria').val(),
            Filtro_CodTipoProducto: '2',
            Filtro_CodUnidadCompra: $(Contenedor + 'ddlUMCompra').val(),
            Filtro_CodUnidadVenta: $(Contenedor + 'ddlUMVenta').val(),
            Filtro_Costo: $(Contenedor + 'txtCostoConIgv').val(),
            Filtro_CostoOriginal: $(Contenedor + 'txtCostoConIgv').val(),
            Filtro_Factor: 1,
            Filtro_CodigoInterno: $(Contenedor + 'txtCodigo').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigo').val(),
            Filtro_CodigoAlternativo: $(Contenedor + 'txtCodigo2').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_CostoSoles: CostoSoles,
            Filtro_CostoDolares: CostoDolares,
            Filtro_Precio: $(Contenedor + 'txtPrecio').val(),
            Filtro_Precio2: $(Contenedor + 'txtPrecio2').val(),
            Filtro_Precio3: 0,
            Filtro_PrecioDolares: Precio1Dolares,
            Filtro_Precio2Dolares: Precio2Dolares,
            Filtro_Precio3Dolares: 0,
            Filtro_Anio: $(Contenedor + 'txtAño').val(),
            Filtro_Ubicacion: '',
            Filtro_IdImagenProducto:0,//$('#hid_id_logo').val()
            Filtro_Marca: $(Contenedor + 'txtMarca').val(),
            Filtro_Posicion: $(Contenedor + 'txtPosicion').val(),
            Filtro_Modelo: $(Contenedor + 'txtModelo').val(),
            Filtro_Medida: $(Contenedor + 'txtMedida').val(),
            Filtro_StockMinimo: $(Contenedor + 'txtStockMinimo').val(),
            Filtro_StockMaximo: $(Contenedor + 'txtStockMaximo').val(),
            Filtro_M1: $(Contenedor + 'txtMargen').val(),
            Filtro_M2: $(Contenedor + 'txtMargen2').val(),
            Filtro_Imagenes: Sys.Serialization.JavaScriptSerializer.serialize(arrImg),
            Filtro_CodigoFabrica: $(Contenedor + 'txtCodigoFabrica').val()
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
                    $('#hid_id_logo').val('');
                    F_Nuevo();
                    toastr.success('Se Grabo Correctamente.');
                    $('#mydropzone').remove();
                    F_AbrirDropzone_JS();
                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtCodigo').val('');
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtMarca').val('');
    $(Contenedor + 'txtModelo').val('');
    $(Contenedor + 'txtMedida').val(''),
    $(Contenedor + 'txtFactor').val('1'),
    $(Contenedor + 'txtCostoConIgv').val('');
    $(Contenedor + 'txtCostoSolesIgv').val('');
    $(Contenedor + 'ddlMoneda').val('2');
    $(Contenedor + 'ddlUMCompra').val('22');
    $(Contenedor + 'ddlUMVenta').val('22');
    $('#MainContent_ddlFamilia').val('78');
    $(Contenedor + 'txtPrecio').val(''),
    $(Contenedor + 'txtPrecio2').val('');
    $(Contenedor + 'txtMargen2').val('');
    $(Contenedor + 'txtStockMinimo').val('0.00');
    $(Contenedor + 'txtStockMaximo').val('0.00');
    $(Contenedor + 'txtAño').val('');
    $(Contenedor + 'txtMarca').prop('disabled', false);
    $(Contenedor + 'txtModelo').prop('disabled', false);
    $(Contenedor + 'txtMedida').prop('disabled', false),
    $(Contenedor + 'txtCodigo2').val(''),
    $(Contenedor + 'txtPartidaArancelaria').val('');
    $(Contenedor + 'txtLinea').val('');
    $(Contenedor + 'txtAño').val(''),
    $(Contenedor + 'txtMargen').val('');
    $(Contenedor + 'txtDescuento').val('');
    $(Contenedor + 'txtPosicion').val('');
    $(Contenedor + 'txtCodigoFabrica').val('');
    $('#MainContent_ddlFamilia').val('78');
    $(Contenedor + 'txtCodigo').focus();
    $('hid_id_logo').val('');
    $('hid_id_logo_Edit').val('');
    $('hid_id_logo_Edit2').val('');
    return false;
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {

       if ($('#MainContent_txtDescripcionConsulta').val == "" | $('#MainContent_txtDescripcionConsulta').val().length < 3) {
             toastr.warning("Descripcion (Minimo 3 Caracteres)");
             return false;
         }

         var Descripcion = $("#MainContent_txtDescripcionConsulta").val();

         if ($.trim($("#MainContent_txtDescripcionConsulta2").val()) != "")
             Descripcion = Descripcion + '%' + $.trim($("#MainContent_txtDescripcionConsulta2").val());

         if ($.trim($("#MainContent_txtDescripcionConsulta3").val()) != "")
             Descripcion = Descripcion + '%' + $.trim($("#MainContent_txtDescripcionConsulta3").val());           

        var objParams = {
            Filtro_Descripcion: Descripcion,
            Filtro_IdFamilia: $('#MainContent_ddlFamiliaConsulta').val(),
            Filtro_CodEstado: $('#MainContent_ddlFiltroCodEstado').val()
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodigoProducto'));
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
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblProducto');
        
        if (!confirm("ESTA SEGURO DE ELIMINAR EL PRODUCTO " + $(lblProducto_grilla).text()))
            return false;

        var objParams = {
            Filtro_CodProducto: $(lblCodigo).val(),
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
                toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });

    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodigoProducto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoProducto');
        var lblProducto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblProducto');
        var lblCosto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCosto');
        var hfPrecio1Original = '#' + imgID.replace('imgEditarRegistro', 'hfPrecio1Original');
        var hfPrecio2Original = '#' + imgID.replace('imgEditarRegistro', 'hfPrecio2Original');
        var lblMargen = '#' + imgID.replace('imgEditarRegistro', 'hfMargen1');
        var hfDescuento = '#' + imgID.replace('imgEditarRegistro', 'hfDescuento');     
        var hfMarca = '#' + imgID.replace('imgEditarRegistro', 'hfMarca');
        var hfMedida = '#' + imgID.replace('imgEditarRegistro', 'hfMedida');
        var hfCodMoneda_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodMoneda');
        var hfCodUnidadCompra_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodUnidadCompra');
        var hfCodUnidadVenta_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodUnidadVenta');
        var hfCodFamilia_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodFamilia');
        var hfFactor_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfFactor');
        var lblCodigo_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblcostomercado_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCostoMercado');
        var lblcostosoles_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCostoSoles');
        var hfModelo = '#' + imgID.replace('imgEditarRegistro', 'hfModelo');
        var hfPosicion = '#' + imgID.replace('imgEditarRegistro', 'hfPosicion');
        var hfAnio = '#' + imgID.replace('imgEditarRegistro', 'hfAnio');
        var hfStockMaximo = '#' + imgID.replace('imgEditarRegistro', 'hfStockMaximo');
        var hfStockMinimo = '#' + imgID.replace('imgEditarRegistro', 'hfStockMinimo');
        var hfCodigoAlternativo = '#' + imgID.replace('imgEditarRegistro', 'hfCodigoAlternativo');
        var hfPartidaArancelaria = '#' + imgID.replace('imgEditarRegistro', 'hfPartidaArancelaria');
        var lblDescripcionIngles = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcionIngles');
        var hfDescripcionCorta = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcionCorta');
        var lbIdImagenProducto1 = '#' + imgID.replace('imgEditarRegistro', 'hIdImagenProducto1');
        var lblM1 = '#' + imgID.replace('imgEditarRegistro', 'hfMargen1');
        var lblM2 = '#' + imgID.replace('imgEditarRegistro', 'hfMargen2');
        var hfCosto = '#' + imgID.replace('imgEditarRegistro', 'hfCosto');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var hfCodigoFabrica = '#' + imgID.replace('imgEditarRegistro', 'hfCodigoFabrica');
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtCodigoProductoEdicion').val($(lblCodigoProducto_grilla).text());
        $(Cuerpo + 'ddlFamiliaEdicion').val($(hfCodFamilia_grilla).val());
        $(Cuerpo + 'txtDescripcionEdicion').val($(hfDescripcionCorta).val());
        $(Cuerpo + 'txtMarcaEdicion').val($(hfMarca).val());
        $(Cuerpo + 'txtModeloEdicion').val($(hfModelo).val());
        $(Cuerpo + 'txtMedidaEdicion').val($(hfMedida).val());
        $(Cuerpo + 'txtPosicionEdicion').val($(hfPosicion).val());
        $(Cuerpo + 'txtFactorEdicion').val($(hfFactor_grilla).val());
        $(Cuerpo + 'txtCostoEdicion').val($(hfCosto).val());
        $(Cuerpo + 'ddlMonedaEdicion').val($(hfCodMoneda_grilla).val());
        $(Cuerpo + 'ddlCompraEdicion').val($(hfCodUnidadCompra_grilla).val());
        $(Cuerpo + 'ddlVentaEdicion').val($(hfCodUnidadVenta_grilla).val());
        $(Cuerpo + 'txtCostoSolesEdicion').val($(lblcostosoles_grilla).val());
        $(Cuerpo + 'txtAñoEdicion').val($(hfAnio).val());
        $(Cuerpo + 'txtPrecioEdicion').val($(hfPrecio1Original).val());
        $(Cuerpo + 'txtPrecio2Edicion').val($(hfPrecio2Original).val());
        $(Cuerpo + 'txtMargenEdicion').val($(lblMargen).text());
        $(Cuerpo + 'txtDescuentoEdicion').val($(hfDescuento).val());
        $(Cuerpo + 'txtStockMaximoEdicion').val($(hfStockMaximo).val());
        $(Cuerpo + 'txtStockMinimoEdicion').val($(hfStockMinimo).val());
        $(Cuerpo + 'txtCodigo2Edicion').val($(hfCodigoAlternativo).val());
        $(Cuerpo + 'txtPartidaArancelariaEdicion').val($(hfPartidaArancelaria).val());
        $(Cuerpo + 'txtLineaEdicion').val($(lblDescripcionIngles).text());
        $(Cuerpo + 'txtMargenEdicion').val($(lblM1).val());
        $(Cuerpo + 'txtMargen2Edicion').val($(lblM2).val());
        $(Cuerpo + 'txtPrecio2Edicion').prop('disabled', true);
        $(Cuerpo + 'txtPrecioEdicion').prop('disabled', true);
        $(Cuerpo + 'txtCostoSolesEdicion').prop('disabled', true);
        $(Cuerpo + 'txtCostoMercadoEdicion').val($(lblcostomercado_grilla).val());
        $(Cuerpo + 'txtCodigoFabricaEdicion').val($(hfCodigoFabrica).val());
        $('#hfCodProducto').val($(lblCodigo_grilla).val());
        //$(Cuerpo + 'ddlFamiliaConsulta').val($(hfCodFamilia_grilla).val());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());
        $('#hid_id_nombre_edit').val(lbIdImagenProducto1); //asigna el campo de la grilla donde se refrescara el numero de la imagen
        $('#hid_id_logo_Edit').val($(lbIdImagenProducto1).val());
        $('#hid_id_logo_Edit2').val($(lbIdImagenProducto1).val());

        var d = new Date();
        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_Emision: d.format("dd/MM/yyyy")
        };

        F_AbrirDropzone_Edit_JS($('#hfCodProducto').val(), $('#hfCodProducto').val());

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ConsultaMovimiento_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                $(Cuerpo + 'txtTcEdicion').val(result.split('~')[4]);
                if (result.split('~')[2] == '0') {
                    //$(Cuerpo + 'txtCostoEdicion').prop('disabled',false) ;
                    $('#hfCodigoTemporal').val('1');
                }

                else {
                    //$(Cuerpo + 'txtCostoEdicion').prop('disabled',true) ;
                    //  $(Cuerpo + 'ddlMonedaEdicion').prop('disabled', true);
                    $(Cuerpo + 'ddlCompraEdicion').prop('disabled', true);
                    $(Cuerpo + 'ddlVentaEdicion').prop('disabled', true);
                }
                if (result.split('~')[3] == '5') {
                    $(Cuerpo + 'txtCostoMercadoEdicion').prop('disabled', false);
                    $('#hfCodigoTemporal').val('2');
                }

                else
                    $(Cuerpo + 'txtCostoMercadoEdicion').prop('disabled', true);

                $("#divEdicionRegistro").dialog({
                    resizable: false,
                    modal: true,
                    title: "Edicion de Productos",
                    title_html: true,
                    height: 500,
                    width: 1250,
                    autoOpen: false
                });

                $('#divEdicionRegistro').dialog('open');

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

//agutierrez  - Visualizacion de imagenes
function F_VisualizarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 1000302, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    var imgID = Fila.id;
    var Cuerpo = '#MainContent_';
    //    var lblcodigo = '#' + imgID.replace('imgVisualizarRegistro', 'lblcodigo');
    var lblCodigo = '#' + imgID.replace('imgVisualizarRegistro', 'lblCodigo');

    var hlblCodigoProducto = '#' + imgID.replace('imgVisualizarRegistro', 'lblCodigoProducto'); $(Cuerpo + 'txtCodigoVisualizacion').val($(hlblCodigoProducto).text());
    var hlblCodigo = '#' + imgID.replace('imgVisualizarRegistro', 'hfCodigoAlternativo'); $(Cuerpo + 'txtCodigo2Visualizacion').val($(hlblCodigo).val());
    var hlblProducto = '#' + imgID.replace('imgVisualizarRegistro', 'hfDescripcionCorta'); $(Cuerpo + 'txtDescripcionVisualizacion').val($(hlblProducto).val());
    var hlblMedida = '#' + imgID.replace('imgVisualizarRegistro', 'hfMedida'); $(Cuerpo + 'txtMedidaVisualizacion').val($(hlblMedida).val());

    var lblDescripcionIngles = '#' + imgID.replace('imgVisualizarRegistro', 'lblDescripcionIngles'); $(Cuerpo + 'txtLineaVisualizacion').val($(lblDescripcionIngles).text());
    var hlblMarca = '#' + imgID.replace('imgVisualizarRegistro', 'hfMarca'); $(Cuerpo + 'txtMarcaVisualizacion').val($(hlblMarca).val());
    var hlblModelo = '#' + imgID.replace('imgVisualizarRegistro', 'hfModelo'); $(Cuerpo + 'txtModeloVisualizacion').val($(hlblModelo).val());
    var hlblPosicion = '#' + imgID.replace('imgVisualizarRegistro', 'hfPosicion'); $(Cuerpo + 'txtPosicionVisualizacion').val($(hlblPosicion).val());
    var hlblAño = '#' + imgID.replace('imgVisualizarRegistro', 'hfAnio'); $(Cuerpo + 'txtAnovisualizacion').val($(hlblAño).val());


    var str_id = $(lblCodigo).val(); if (str_id == "") { str_id = 0; };
    var arrImg = new Array();
    var carga = 0;
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: "../Digitalizacion/FileDocDB.ashx?IdFile=" + str_id + "&Flag=1&tipo=1" + "&otro=" + Math.round(Math.random()) * 100,
        success: function (data) {
            MostrarEspera(true);
            try {
                var obj = $.parseJSON(data);
                $.each(obj, function (index, item) {
                    arrImg.push(item.img);
                });
                F_ArmarListaImagenes(arrImg);
            } catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function () {
            toastr.warning('Ha ocurrido un error interno, por favor intentelo nuevamente.');
        }
    });
}

function F_ArmarListaImagenes(arrImg) {
    var lu = $('#luImagenes'); lu.empty();

    //imagenes dinamicas por cuadricula
    var med_li = ""; var med_img = "";
    switch (arrImg.length) {
        case 1: med_li = "width:900px; height:450px"; med_img = "max-width:850px; max-height:450px;"; break;
        case 2: med_li = "width:450px; height:450px"; med_img = "max-width:450px; max-height:450px;"; break;
        case 3: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 4: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 5: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 6: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 7: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 8: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 9: med_li = "width:225px; height:135px"; med_img = "max-width:175px; max-height:135px;"; break;
        case 10: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 11: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 12: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        default: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
    }

    $.each(arrImg, function (key, value) {

        var fmt = ' <li class="li-float" style="' + med_li + '"> ' +
                    '     <a href=' + value + '  ' +
                    '         target="_blank" ' +
                    '         rel="nofollow"  ' +
                    '         style="background-image: url(' + value + ');"> ' +
                    '         <img src="' + value + '" class="li-img" style="' + med_img + ' margin: 0 auto" alt="Imagen 1"/> ' +
                    '      </a> ' +
                    ' </li> ';
        lu.append(fmt)
    });

    $("#divVisualizarImagen").dialog({
        resizable: false,
        modal: true,
        title: "Visualización del Artículo",
        title_html: true,
        width: 1100,
        height: 650,
        autoOpen: false
    });

    $('#divVisualizarImagen').dialog('open');
}

function F_EdicionRegistro() {

    try {
        var Contenedor = '#MainContent_';

        var IdImagenEdit = 0;
        if ($('#hid_id_logo_Edit').val() != $('#hid_id_logo_Edit2').val()) { IdImagenEdit = $('#hid_id_logo_Edit2').val(); }

        // recorrido para seleccionar imagen
        var arrImg = new Array();
        $('.dz-preview').each(function () {
            arrImg.push(this.id);
        });

        if ($(Contenedor + 'txtStockMinimoEdicion').val() == '')
            $(Contenedor + 'txtStockMinimoEdicion').val('0.00');
                                          
        if ($(Contenedor + 'txtStockMaximoEdicion').val() == '')
            $(Contenedor + 'txtStockMaximoEdicion').val('0.00');

        var CostoSoles = 0;
        var CostoDolares = 0;
        var Precio1Dolares = 0;
        var Precio2Dolares = 0;
        var Precio3Dolares = 0;

        if ($(Contenedor + 'ddlMonedaEdicion').val() == '1') {
            CostoSoles = $(Contenedor + 'txtCostoEdicion').val();
            CostoDolares = (Number($(Contenedor + 'txtCostoEdicion').val()) / Number($(Contenedor + 'txtTCEdicion').val())).toFixed(2);
            Precio1Dolares = (Number($(Contenedor + 'txtPrecioEdicion').val()) / Number(   $(Contenedor + 'txtTCEdicion').val())).toFixed(2);
            Precio2Dolares = (Number($(Contenedor + 'txtPrecio2Edicion').val()) / Number(  $(Contenedor + 'txtTCEdicion').val())).toFixed(2);
            Precio3Dolares = 0;
        } else {
            CostoSoles = (Number($(Contenedor + 'txtCostoEdicion').val()) * Number($(Contenedor + 'txtTCEdicion').val())).toFixed(2);
            CostoDolares = $(Contenedor + 'txtCostoEdicion').val();
            Precio1Dolares = Number($(Contenedor + 'txtPrecioEdicion').val());
            Precio2Dolares = Number($(Contenedor + 'txtPrecio2Edicion').val());
            Precio3Dolares = 0;
        }

        var Descripcion = $("#MainContent_txtDescripcionConsulta").val();

        if ($.trim($("#MainContent_txtDescripcionConsulta2").val()) != "")
            Descripcion = Descripcion + '%' + $.trim($("#MainContent_txtDescripcionConsulta2").val());

        if ($.trim($("#MainContent_txtDescripcionConsulta3").val()) != "")
            Descripcion = Descripcion + '%' + $.trim($("#MainContent_txtDescripcionConsulta3").val());     

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_IdFamilia: $(Contenedor + 'ddlFamiliaEdicion').val(),
            Filtro_DscProducto: $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_DscProductoIngles: $(Contenedor + 'txtLineaEdicion').val(),
            Filtro_PartidaArancelaria: $(Contenedor + 'txtPartidaArancelariaEdicion').val(),
            Filtro_CodTipoProducto: '2',
            Filtro_CodUnidadCompra: $(Contenedor + 'ddlCompraEdicion').val(),
            Filtro_CodUnidadVenta: $(Contenedor + 'ddlVentaEdicion').val(),
            Filtro_Costo: $(Contenedor + 'txtCostoEdicion').val(),
            Filtro_CostoOriginal: $(Contenedor + 'txtCostoEdicion').val(),
            Filtro_Factor: 1,
            Filtro_CodigoInterno: $(Contenedor + 'txtCodigoProductoEdicion').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigoProductoEdicion').val(),
            Filtro_CodigoAlternativo: $(Contenedor + 'txtCodigo2Edicion').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMonedaEdicion').val(),
            Filtro_CostoSoles: CostoSoles,
            Filtro_CostoDolares: CostoDolares,
            Filtro_Precio: $(Contenedor + 'txtPrecioEdicion').val(),
            Filtro_Precio2: $(Contenedor + 'txtPrecio2Edicion').val(),
            Filtro_Precio3: 0,
            Filtro_PrecioDolares: Precio1Dolares,
            Filtro_Precio2Dolares: Precio2Dolares,
            Filtro_Precio3Dolares: 0,
            Filtro_Anio: $(Contenedor + 'txtAñoEdicion').val(),
            Filtro_Ubicacion: '',
            Filtro_IdImagenProducto: 0, //$('#hid_id_logo').val()
            Filtro_Marca: $(Contenedor + 'txtMarcaEdicion').val(),
            Filtro_Posicion: $(Contenedor + 'txtPosicionEdicion').val(),
            Filtro_Modelo: $(Contenedor + 'txtModeloEdicion').val(),
            Filtro_Medida: $(Contenedor + 'txtMedidaEdicion').val(),
            Filtro_StockMinimo: $(Contenedor + 'txtStockMinimoEdicion').val(),
            Filtro_StockMaximo: $(Contenedor + 'txtStockMaximoEdicion').val(),
            Filtro_M1: $(Contenedor + 'txtMargenEdicion').val(),
            Filtro_M2: $(Contenedor + 'txtMargen2Edicion').val(),
            Filtro_Imagenes: Sys.Serialization.JavaScriptSerializer.serialize(arrImg),
            Filtro_Descripcion: Descripcion,
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_CodigoFabrica: $(Contenedor + 'txtCodigoFabricaEdicion').val()
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
                    $(Contenedor + 'txtCodigoProductoEdicion').val('');
                    $(Contenedor + 'txtDescripcionEdicion').val('');
                    $(Contenedor + 'txtMarcaEdicion').val('');
                    $(Contenedor + 'txtModeloEdicion').val('');
                    $(Contenedor + 'txtMedidaEdicion').val(''),
                    $(Contenedor + 'txtFactorEdicion').val('1'),
                    $(Contenedor + 'txtCostoConIgvEdicion').val('');
                    $(Contenedor + 'txtCostoSolesIgvEdicion').val('');
                    $(Contenedor + 'txtAñoEdicion').val('');
                    $(Contenedor + 'txtPrecio2Edicion').val(''),
                    $(Contenedor + 'txtMargenEdicion').val('');
                    $(Contenedor + 'txtPrecioEdicion').val('');
                    $(Contenedor + 'txtMargen2Edicion').val('');
                    $(Contenedor + 'txtDescripcionInglesEdicion').val('');
                    $(Contenedor + 'txtCodigo2Edicion').val('');
                    $(Contenedor + 'txtPartidaArancelariaEdicion').val('');
                    toastr.success('Se Actualizo Correctamente.');
                    $('#divEdicionRegistro').dialog('close');
                    $('#hid_id_logo_Edit').val('');
                    $('#hid_id_logo_Edit2').val('');
                }
                else {
                    toastr.warning(result.split('~')[1]);
                }
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarEdicionDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtLineaEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'LINEA';

        if ($(Cuerpo + 'txtMarcaEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'MARCA';

        if ($(Cuerpo + 'txtTcEdicion').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtFactorEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Factor';

        if (($(Cuerpo + 'ddlCompraEdicion').val() != $(Cuerpo + 'ddlVentaEdicion').val()) && ($(Cuerpo + 'txtFactorEdicion').val() == '1' | $(Cuerpo + 'txtFactorEdicion').val() == '1.00'))
            Cadena = Cadena + '<p></p>' + 'La unidad de compra y venta son distintas,el Factor no puede ser 1.';

        if ($(Cuerpo + 'txtCostoConIgvEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtPrecio1Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 1';

        if ($(Cuerpo + 'txtPrecio2Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 2';

        if ($(Cuerpo + 'txtPrecioEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 3';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {
        toastr.warning("Error Detectado: " + e);
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

function F_VerPrecioMinimo(HlkControlID) {
    var Contenedor = '#MainContent_';



    $(Contenedor + 'txtPrecioMinimo').val($('#' + HlkControlID.replace('lblPrecio1', 'hfPrecio2')).val());
    $(Contenedor + 'txtMoneda').val($('#' + HlkControlID.replace('lblPrecio1', 'lblMoneda')).text());

    $('#div_ultimoprecio').dialog({
        resizable: false,
        modal: true,
        title: "Precio Minimo",
        title_html: true,
        height: 100,
        width: 300,
        autoOpen: false
    });

    $('#div_ultimoprecio').dialog('open');


}

//Procedimiento para crear el Objeto DropZone.
function F_CrearDropzone_JS() {
    var midiv = document.createElement("div");
    midiv.setAttribute("id", "mydropzone");
    midiv.setAttribute("class", "dropzone");
    midiv.setAttribute("style", "width:450px; height:420px; margin-left: 10px; border-radius:12px; min-height:200px; padding:0px;");
    document.getElementById('drop').appendChild(midiv);
}

function F_CrearDropzone_Edit_JS() {
    var midiv_Edit = document.createElement("div");
    midiv_Edit.setAttribute("id", "mydropzone_Edit");
    midiv_Edit.setAttribute("class", "dropzone");
    midiv_Edit.setAttribute("style", "width:450px; height:350px; margin-left: 10px; border-radius:12px; min-height:200px; padding:0px;");
    document.getElementById('div_drop_Edit').appendChild(midiv_Edit);

}

//Procedimiento para abrir el dropZone
function F_CrearDropzone_JS() {
    var midiv = document.createElement("div");
    midiv.setAttribute("id", "mydropzone");
    midiv.setAttribute("class", "dropzone");
    midiv.setAttribute("style", "width:450px; height:420px; margin-left: 10px; border-radius:12px; min-height:200px; padding:0px;");
    document.getElementById('drop').appendChild(midiv);
}

function F_CrearDropzone_Edit_JS() {
    var midiv_Edit = document.createElement("div");
    midiv_Edit.setAttribute("id", "mydropzone_Edit");
    midiv_Edit.setAttribute("class", "dropzone");
    midiv_Edit.setAttribute("style", "width:450px; height:420px; margin-left: 10px; border-radius:12px; min-height:200px; padding:0px;");
    document.getElementById('div_drop_Edit').appendChild(midiv_Edit);

}

function F_AbrirDropzone_JS() {
    F_CrearDropzone_JS();

    var str_id;
    str_id = $('#hid_id_mantenimiento').val(); if (str_id == '') str_id = '0';

    myDropzone = new Dropzone("#mydropzone", {
        url: "Productos.aspx",
        method: "POST",
        paramName: "file1",
        parallelUploads: 10,
        addRemoveLinks: true,
        autoProcessQueue: true,
        uploadMultiple: true,
        maxFileSize: 2,
        maxFiles: null,
        dictResponseError: "Ha ocurrido un error en el server",
        dictRemoveFile: "Remover Doc.",
        acceptedFiles: 'image/*,.jpeg,.jpg,.png,.bmp,.JPEG,.JPG,.PNG,.psd',
        previewTemplate: "<div id=\"idzID\" class=\"dz-preview dz-file-preview\">\n  <div  class=\"dz-details\">\n <div class=\"dz-filename\"><span data-dz-name></span></div>\n             <div class=\"dz-size\" data-dz-size></div>\n  <img data-dz-thumbnail />\n  </div>\n  <div class=\"progress progress-small progress-striped active\"><div class=\"progress-bar bar progress-bar-success\" data-dz-uploadprogress></div></div>\n  <div class=\"dz-success-mark\"><span></span></div>\n  <div class=\"dz-error-mark\"><span></span></div>\n  <div class=\"dz-error-message\"><span data-dz-errormessage>Error, archivo no compatible o fuera del rango del tamaño permitido.</span></div>\n</div>",
        error: function (file, response) {
            file.previewElement.classList.add("dz-error");
        },
        init: function () {
            var thisDropzone = this;

            $('#btn_man_cancelar').click(function () {
                thisDropzone.removeAllFiles(true);
            });

            this.on("reset", function (file) {
                thisDropzone.removeAllFiles(true);
            });

            this.on("addedfile", function (file) {
                if (this.files.length) {
                    var i, len, pre;
                    for (i = 0, len = this.files.length; i < len - 1; i++) {
                        if (this.files[i].name == file.name) {
                            toastr.warning("EL LOGO : " + file.name + " YA SE ENCUENTRA REGISTRADO.");
                            return (pre = file.previewElement) != null ? pre.parentNode.removeChild(file.previewElement) : void 0;
                        }
                    }
                }
                return false;
            });

            this.on("maxfilesexceeded", function (file) {
                this.removeAllFiles();
                this.addFile(file);

            });

            this.on("success", function (file) {

                //if ($('#hid_tipo_operacion_mantenimiento').val() == "I") {
                //F_Botones_Mantenimiento_Lock();
                F_Consultar_Imagen(0);
                //}


            });
            this.on("removedfile", function (file) {
                //nuevo
                //                if ($('#hid_id_logo').val() !== "") {
                //                    F_Eliminar_Imagen($('#hid_id_logo').val(), 0);
                //                }
                var id = file.name.split('-', 2);
                var idn = id[1].toString().replace(".jpg", "");
                F_Eliminar_Temporal_Imagen(idn);
                $('#hid_id_logo').val('');

            });

            $.ajax({
                async: true,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: "../Digitalizacion/FileUpLoadDB.ashx?IdFile=" + str_id + "&Flag=1" + "&tipo=" + 0 + "&otro=" + Math.round(Math.random()) * 100,

                success: function (data) {
                    var obj = $.parseJSON(data);
                    //  if (obj != "") {
                    $.each(obj, function (index, item) {
                        var mockFile = {
                            name: item.T_NombreArchivo,
                            size: item.T_Tamaño
                        };
                        thisDropzone.emit("addedfile", mockFile);
                        thisDropzone.emit("thumbnail", mockFile, item.T_Preview);
                        thisDropzone.emit("sending", mockFile);
                        thisDropzone.emit("success", mockFile);
                        thisDropzone.files.push(mockFile);
                    });

                },
                error: function () {
                    toastr.warning('Ha ocurrido un error interno, por favor intentelo nuevamente.');
                }
            });

            return false;
        }
    });

    $(".dz-message").remove();
    $("#mydropzone").append('<div class="dz-default dz-message-mini" ></div>');


}

function F_AbrirDropzone_Edit_JS(str_id, nameimg) {
    //    var str_id;
    //    str_id = $('#hid_id_logo_Edit').val(); if (str_id == '') str_id = '0';
    $('#mydropzone').remove();
    $('#mydropzone_Edit').remove();
    //    if (mydropzone_Edit != null) {
    //        mydropzone_Edit.removeAllFiles(true);
    //        mydropzone_Edit = null;
    //    } else {
    F_AbrirDropzone_JS();
    F_CrearDropzone_Edit_JS();
    //    }

    mydropzone_Edit = new Dropzone("#mydropzone_Edit", {
        url: "Productos.aspx",
        method: "POST",
        paramName: "file1",
        parallelUploads: 10,
        addRemoveLinks: true,
        autoProcessQueue: true,
        uploadMultiple: true,
        maxFileSize: 2,
        maxFiles: null,
        dictResponseError: "Ha ocurrido un error en el server",
        dictRemoveFile: "Remover Doc.",
        acceptedFiles: 'image/*,.jpeg,.jpg,.png,.bmp,.JPEG,.JPG,.PNG,.psd',
        previewTemplate: "<div id=\"EDITidzEDIT\" class=\"dz-preview dz-file-preview\">\n  <div class=\"dz-details\">\n <div class=\"dz-filename\"><span data-dz-name></span></div>\n <div class=\"dz-size\" data-dz-size></div>\n  <img data-dz-thumbnail />\n  </div>\n  <div class=\"progress progress-small progress-striped active\"><div class=\"progress-bar bar progress-bar-success\" data-dz-uploadprogress></div></div>\n  <div class=\"dz-success-mark\"><span></span></div>\n  <div class=\"dz-error-mark\"><span></span></div>\n  <div class=\"dz-error-message\"><span data-dz-errormessage>Error, archivo no compatible o fuera del rango del tamaño permitido.</span></div>\n</div>",
        error: function (file, response) {
            file.previewElement.classList.add("dz-error");
        },
        init: function () {
            var thisDropzone = this;
            var isDroped = false; //Droped (file) or Downloaded (from db)  //esta variable va a diferenciar cuando entra al dz un archivo dropeado o cargado de la base de datos

            //            $('button.ui-button').click(function () {
            //                thisDropzone.removeAllFiles(true);
            //            });

            //            $('#divEdicionRegistro').unload(function () {
            //                thisDropzone.removeAllFiles(true);
            //            });

            this.on("reset", function (file) {
                thisDropzone.removeAllFiles(true);
            });

            this.on("addedfile", function (file) {
                if (this.files.length) {
                    var i, len, pre;
                    for (i = 0, len = this.files.length; i < len - 1; i++) {
                        if (this.files[i].name == file.name) {
                            toastr.warning("EL LOGO : " + file.name + " YA SE ENCUENTRA REGISTRADO.");
                            return (pre = file.previewElement) != null ? pre.parentNode.removeChild(file.previewElement) : void 0;
                        }
                    }
                    isDroped = true;
                }
                return false;
            });

            this.on("maxfilesexceeded", function (file) {
                this.removeAllFiles();
                this.addFile(file);

            });

            this.on("success", function (file) {
                //if ($('#hid_tipo_operacion_mantenimiento').val() == "I") {
                //F_Botones_Mantenimiento_Lock();

                if (isDroped == true) {
                    F_Consultar_Imagen_Editar(idn)
                }
                else {
                    var id = file.name.split('-', 2);
                    var idn = id[1].toString().replace(".jpg", "");
                    $('#EDITidzEDIT').attr('id', idn);
                }

                //                F_Consultar_Imagen_Editar(idn);
                //}

                isDroped = false;
            });
            this.on("removedfile", function (file) {
                //remover en editar

                //if ($('#hid_id_logo').val() !== "") {
                //    F_Eliminar_Imagen($('#hid_id_logo').val(), 0);
                //}
                var id = file.name.split('-', 2);
                var idn = id[1].toString().replace(".jpg", "");
                F_Eliminar_Imagen(idn);
                $('#hid_id_logo_Edit').val('');
                $('#hid_id_logo_Edit2').val('');
            });

            $.ajax({
                async: true,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: "../Digitalizacion/FileUpLoadDB.ashx?IdFile=" + str_id + "&nameimg=" + nameimg + "&Flag=1" + "&tipo=1" + "&otro=" + Math.round(Math.random()) * 100,

                success: function (data) {
                    var obj = $.parseJSON(data);
                    //  if (obj != "") {
                    $.each(obj, function (index, item) {
                        var mockFile = {
                            name: item.T_NombreArchivo,
                            size: item.T_Tamaño
                        };
                        isDroped = false;
                        thisDropzone.emit("addedfile", mockFile);
                        thisDropzone.emit("thumbnail", mockFile, item.T_Preview);
                        thisDropzone.emit("sending", mockFile);
                        thisDropzone.emit("success", mockFile);
                        thisDropzone.files.push(mockFile);
                        var id = mockFile.name.split('-', 2); var idn = id[1].toString().replace(".jpg", "");
                        $('#EDITidzEDIT').attr('id', idn);
                    });

                },
                error: function () {
                    toastr.warning('Ha ocurrido un error interno, por favor intentelo nuevamente.');
                }
            });

            return false;
        }
    });

    $(".dz-message").remove();
    $("#mydropzone_Edit").append('<div class="dz-default dz-message-mini" ></div>');
}

function F_Consultar_Imagen(str_tipoConsulta) {
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset= utf-8",
        url: "Productos.aspx/F_UltimaImagenTMP_JS",
        dataType: "json",
        success: function (dataObject, textStatus) {
            if (textStatus == "success") {
                var data = dataObject.d;
                var id_imagen = data.ID_Imagen;
                if (data.msg == "") {
                    $('#hid_id_logo').val(id_imagen);
                    $('#idzID').attr('id', id_imagen);
                    F_Botones_Mantenimiento_Unlock();
                } else {
                    toastr.warning(data.msg);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });
}

function F_Consultar_Imagen_Editar(str_tipoConsulta) {
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset= utf-8",
        url: "Productos.aspx/F_UltimaImagenTMP_JS",
        dataType: "json",
        success: function (dataObject, textStatus) {
            if (textStatus == "success") {
                var data = dataObject.d;
                var id_imagen = data.ID_Imagen;
                if (data.msg == "") {
                    $('#hid_id_logo_Edit2').val(id_imagen);
                    $('#EDITidzEDIT').attr('id', id_imagen);
                    F_Botones_Mantenimiento_Unlock();
                } else {
                    toastr.warning(data.msg);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });
}

function F_Consultar_Imagen_Editar2(str_tipoConsulta) {
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset= utf-8",
        url: "Productos.aspx/F_UltimaImagenTMP_JS",
        dataType: "json",
        success: function (dataObject, textStatus) {
            if (textStatus == "success") {
                var data = dataObject.d;
                var id_imagen = data.ID_Imagen;
                if (data.msg == "") {
                    $('#hid_id_logo_Edit2').val(id_imagen);
                    $('#EDITidzEDIT').attr('id', id_imagen);
                    F_Botones_Mantenimiento_Unlock();
                } else {
                    toastr.warning(data.msg);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });
}

function F_Botones_Mantenimiento_Unlock() {
    //    $('#btn_man_grabar').removeAttr('disabled');
    //    $('#btn_man_cancelar').removeAttr('disabled');
}

function F_Eliminar_Temporal_Imagen(id_Imagen, str_tipoConsulta) {

    var param = {
        ID_TemporalImagen: id_Imagen
    };

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'Productos.aspx/F_Eliminar_Temporal_Imagen',
        dataType: "json",
        data: JSON.stringify({ 'objEntidad': param }),
        success: function (dataObject, textStatus) {
            if (textStatus == "success") {
                var data = dataObject.d;
                if (data.msg == "") {

                    if (str_tipoConsulta == 0) {
                        $('#hid_id_logo').val('');
                    } else {
                        $('#hid_id_QR').val('');
                    }

                } else {
                    toastr.warning(data.msg);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
        },
        async: false

    });
}

function F_Eliminar_Imagen(id_Imagen, str_tipoConsulta) {

    var param = {
        IdImagenProducto1: id_Imagen
    };

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'Productos.aspx/F_Eliminar_Imagen',
        dataType: "json",
        data: JSON.stringify({ 'objEntidad': param }),
        success: function (dataObject, textStatus) {
            if (textStatus == "success") {
                var data = dataObject.d;
                if (data.msg == "") {

                    if (str_tipoConsulta == 0) {
                        $('#hid_id_logo').val('');
                    } else {
                        $('#hid_id_QR').val('');
                    }

                } else {
                    toastr.warning(data.msg);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
        },
        async: false

    });
}

function F_Precio(Mantenimiento) {
    if (Mantenimiento == 0) {
        if ($("#MainContent_txtCostoConIgv").val() == '')
            return false;

        $("#MainContent_txtPrecio").val(parseFloat($("#MainContent_txtCostoConIgv").val() * ((parseFloat($("#MainContent_txtMargen").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_ddlMoneda").val() == '2')
            $("#MainContent_txtCostoSolesIgv").val(parseFloat(parseFloat($("#MainContent_txtCostoConIgv").val()) * parseFloat($("#MainContent_txtTC").val())).toFixed(2));
        else
            $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val()).toFixed(2));

        if ($("#MainContent_txtMargen") != '')
            $("#MainContent_txtPrecio").val(parseFloat($("#MainContent_txtCostoConIgv").val() * ((parseFloat($("#MainContent_txtMargen").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_txtMargen2") != '')
            $("#MainContent_txtPrecio2").val(parseFloat($("#MainContent_txtCostoConIgv").val() * ((parseFloat($("#MainContent_txtMargen2").val()) / 100) + 1)).toFixed(2));

        return false;
    }
    else {
        if ($("#MainContent_txtCostoEdicion").val() == '')
            return false;

        if ($("#MainContent_ddlMonedaEdicion").val() == '2')
            $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTCEdicion").val()).toFixed(2));
        else
            $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val()).toFixed(2));

        if ($("#MainContent_txtMargenEdicion") != '')
            $("#MainContent_txtPrecioEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * ((parseFloat($("#MainContent_txtMargenEdicion").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_txtMargen2Edicion") != '')
            $("#MainContent_txtPrecio2Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * ((parseFloat($("#MainContent_txtMargen2Edicion").val()) / 100) + 1)).toFixed(2));

        return false;
    }
}

function F_ValidarGrabarDetalle() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtModeloDetalle').val() == '' | $('#hfCodModeloDetalle').val()==0)
            Cadena = Cadena + '<p></p>' + 'Modelo';
            
        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarDetalle() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalle').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalle').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalle').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmision').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambio').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltro').val()          
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    $('#hfCodModeloDetalle').val(0);
                    $(Contenedor + 'txtAñoDetalle').val('');
                    $(Contenedor + 'txtMotorDetalle').val('');
                    $(Contenedor + 'txtModeloDetalle').val('');
                    $(Contenedor + 'txtTransmision').val('');
                    $(Contenedor + 'txtCajaCambio').val('');
                    $(Contenedor + 'txtFiltro').val('');
                    F_Buscar_Detalle($('#hfCodProducto').val());
                    toastr.success('Se Grabo Correctamente.');
                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ActualizarDetalle() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalle').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalle').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalle').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmisionEdicion').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambioEdicion').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltroEdicion').val()     
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente.') {
                    F_Buscar_Detalle();
                    toastr.success('Se Grabo Correctamente.');
                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_Buscar_Detalle(CodProducto) {
    try {
        var objParams = {
            Filtro_CodProducto: CodProducto
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_Detalle_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_ProductoDetalle', result.split('~')[2]);
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
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_DetalleProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 1000303, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    var imgID = Fila.id;
    var Contenedor = '#MainContent_';
    var lblCodigo = '#' + imgID.replace('imgDetalleProducto', 'lblCodigo');
    var lblCodigoProducto = '#' + imgID.replace('imgDetalleProducto', 'lblCodigoProducto');
    var lblProducto = '#' + imgID.replace('imgDetalleProducto', 'lblProducto');
    $('#hfCodProducto').val($(lblCodigo).val());
    $(Contenedor + 'txtProductoDetalle').val($(lblProducto).text());
    $(Contenedor + 'txtModeloDetalle').val('');
    $(Contenedor + 'txtAñoDetalle').val('');
    $(Contenedor + 'txtMotorDetalle').val('');
    $(Contenedor + 'txtCajaCambio').val('');
    $(Contenedor + 'txtTransmision').val('');
    $(Contenedor + 'txtFiltro').val('');
    $('#hfCodModeloDetalle').val(0);
    $('#div_DetalleProducto').dialog({
        resizable: false,
        modal: true,
        title: "DETALLE PRODUCTO",
        title_html: true,
        height: 500,
        width: 890,
        autoOpen: false
    });
    $('#div_DetalleProducto').dialog('open');
    F_Buscar_Detalle($(lblCodigo).val());
    return false;
}

function F_EliminarDetalleProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodProductoModelo = '#' + imgID.replace('imgAnularDocumento', 'hfCodProductoModelo');
    
        if (!confirm("ESTA SEGURO DE ELIMINAR EL DETALLE"))
            return false;

        var objParams = {
            Filtro_CodProductoModelo: $(hfCodProductoModelo).val()   
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Eliminar_Detalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Buscar_Detalle($('#hfCodProducto').val())
                toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }


}

function F_EditarDetalleProducto(Fila) {
    try {
        var imgID = Fila.id;
        var lblLinea = '#' + imgID.replace('imgEditarRegistro', 'lblLinea');
        var hfCodProductoModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodProductoModelo');
        var hfCodModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodModelo');
        var lblModelo = '#' + imgID.replace('imgEditarRegistro', 'lblModelo');
        var lblAño = '#' + imgID.replace('imgEditarRegistro', 'lblAño');
        var lblMotor = '#' + imgID.replace('imgEditarRegistro', 'lblMotor');
        var lblCajaCambio = '#' + imgID.replace('imgEditarRegistro', 'lblCajaCambio');
        var lblTransmision = '#' + imgID.replace('imgEditarRegistro', 'lblTransmision');
        var lblFiltro = '#' + imgID.replace('imgEditarRegistro', 'lblFiltro');   
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtProductoDetalleEdicion').val($(Cuerpo + 'txtProductoDetalle').val());
        $(Cuerpo + 'txtModeloDetalleEdicion').val($(lblLinea).text() + ' - ' + $(lblModelo).text());
        $(Cuerpo + 'txtAñoDetalleEdicion').val($(lblAño).text());
        $(Cuerpo + 'txtMotorDetalleEdicion').val($(lblMotor).text());
        $(Cuerpo + 'txtCajaCambioEdicion').val($(lblCajaCambio).text());
        $(Cuerpo + 'txtTransmisionEdicion').val($(lblTransmision).text());
        $(Cuerpo + 'txtFiltroEdicion').val($(lblFiltro).text());
        $('#hfCodModeloDetalleEdicion').val($(hfCodModelo).val());
        $('#hfCodProductoModelo').val($(hfCodProductoModelo).val());
        
        $("#div_DetalleProductoEditar").dialog({
            resizable: false,
            modal: true,
            title: "Edicion Detalle Producto",
            title_html: true,
            height: 250,
            width: 500,
            autoOpen: false
        });

        $('#div_DetalleProductoEditar').dialog('open');
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EdicionDetalleRegistro() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProductoModelo: $('#hfCodProductoModelo').val(),
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalleEdicion').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalleEdicion').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalleEdicion').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmisionEdicion').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambioEdicion').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltroEdicion').val()     
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
                    toastr.success('Se Actualizo Correctamente.');
                    $('#hfCodModeloDetalleEdicion').val(0);
                    $(Contenedor + 'txtAñoDetalleEdicion').val('');
                    $(Contenedor + 'txtMotorDetalleEdicion').val('');
                    $(Contenedor + 'txtModeloDetalleEdicion').val('');
                    $(Contenedor + 'txtFiltroEdicion').val('');
                    $(Contenedor + 'txtCajaCambioEdicion').val('');
                    $(Contenedor + 'txtTransmisionEdicion').val('');
                    $('#div_DetalleProductoEditar').dialog('close');
                    F_Buscar_Detalle($('#hfCodProducto').val());               
                }
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarGrabarDetalleEdicion() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtModeloDetalleEdicion').val() == '' | $('#hfCodModeloDetalleEdicion').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Modelo';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

var Ctlgv;
var Hfgv;

function imgMas_Click(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalle(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle(Fila) {
    try {
        var nmrow = 'MainContent_grvConsulta_pnlOrders_0';
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrders', 'lblCodigo')).val();      
        var grvNombre = 'MainContent_grvConsulta_grvDetalle_' + Col;
        Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

        if ($(Hfgv).val() === "1") {
            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
            $(Ctlgv).attr('src', '../Asset/images/minus.gif');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,          
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                //MostrarEspera(true);
                $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                F_LlenarGridDetalle_NET(arg, function (result) {

                    $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                        $(Hfgv).val('1');
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }

                    return false;
                });
            }
        }
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("ERROR DETECTADO: " + e);
        return false;
    }
    return true;
}








function F_HistorialCostos(Fila) {
    if (F_PermisoOpcion(CodigoMenu, '333004', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodProducto = '#' + imgID.replace('imgHistorialCosto', 'lblCodigo');
        var lblCodigoProducto_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblCodigoProducto');
        var lblProducto_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblProducto');
        var lblMarca_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblMarca');
        var lblcostomercado_grilla = '#' + imgID.replace('imgHistorialCosto', 'hfCostoMercado');
        var hfCodMoneda_grilla = '#' + imgID.replace('imgHistorialCosto', 'hfCodMoneda');
        var Mon = 'S/ ';
        if ($(hfCodMoneda_grilla).val() === '2')
            Mon = '$/ '

        var MarcaProducto = $(lblMarca_grilla).text().trim();
        var TituloProducto = $(lblCodigoProducto_grilla).text() + ' - ' + $(lblProducto_grilla).text();
        $('#MainContent_txtCostoActual').val(Mon + $(lblcostomercado_grilla).val());

        var objParams = {
            Filtro_CodProducto: $(hfCodProducto).val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ConsultaHistorialCostos_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            if (result.split('~')[1] == "") {

                F_Update_Division_HTML('div_grvHistorialCostos', result.split('~')[2]);
                F_Update_Division_HTML('div_grvHistorialPrecios', result.split('~')[3]);

                $('#MainContent_txtProductoHistorial').val(TituloProducto.replace(MarcaProducto, ''));
                $('#MainContent_txtMarcaHistorial').val(MarcaProducto);

                $("#div_HistorialCostos").dialog({
                    resizable: false,
                    modal: true,
                    title: "Historial de Costos y Precios de Productos",
                    title_html: true,
                    height: 500,
                    width: 1150,
                    autoOpen: false
                });

                $('#div_HistorialCostos').dialog('open');
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            MostrarEspera(false);
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}
