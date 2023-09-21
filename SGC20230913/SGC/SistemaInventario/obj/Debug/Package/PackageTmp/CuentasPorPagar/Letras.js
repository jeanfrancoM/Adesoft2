var AppSession = "../CuentasPorPagar/Letras.aspx";
var CodigoMenu = 6000; var CodigoInterno = 3;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtProveedor').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 2 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
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
            $('#hfCodCtaCte').val(i.item.val);

        },
        minLength: 3
    });

    $('#MainContent_txtProveedorConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 2 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
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
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#divTabs').tabs();

    $('#MainContent_txtDesde').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    } 
    });

    $('#MainContent_txtDesde').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    } 
    });

$('#MainContent_imgBuscar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
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
                toastr.warning(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 6000302, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Cliente";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                toastr.warning(Cadena);
                return false;
            }

            $("#divConsultaFactura").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 450,
                width: 390,
                autoOpen: false
            });

            $('#divConsultaFactura').dialog('open');

            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_CodSede: $('#hfCodSede').val()
            };
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

            MostrarEspera(true);
            F_Buscar_Factura_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);
                else
                    toastr.warning(result.split('~')[1]);

                return false;
            });
        }
        catch (e) {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }
        return false;
    });

    $('#MainContent_btnAgregarLetra').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 6000301, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            var Cadena = "Ingrese los sgtes. campos:"

            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Cliente";

            if ($('#MainContent_txtTotalFactura').val() == '0.00')
                Cadena = Cadena + '<p></p>' + 'No ha agregado ninguna factura';

            if (Cadena != "Ingrese los sgtes. campos:") {
                toastr.warning(Cadena);
                return false;
            }

            $("#div_DatosLetra").dialog({
                resizable: false,
                modal: true,
                title: "Datos de la Letra",
                title_html: true,
                height: 220,
                width: 440,
                autoOpen: false
            });

            F_LimpiarLetra();
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
        return false;
    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarAgregar())
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnEliminarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarEliminar_Factura())
                return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LAS FACTURAS SELECCIONADOS"))
                F_EliminarTemporal_Factura();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LAS LETRAS"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabarLetra').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarAgregarLetra())
                return false;

            if (confirm("ESTA SEGURO DE AGREGAR LA LETRA"))
                F_AgregarLetra();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnEliminarLetra').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarEliminar_Letra())
                return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LAS LETRAS SELECCIONADAS"))
                F_EliminarTemporal_Letra();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });

    F_Controles_Inicializar();

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtTotalFactura').css('background', '#FFFFE0');

    $('#MainContent_txtTotalLetra').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtTotalFactura').css('background', '#FFFFE0');

    $('#MainContent_txtPercepcion').css('background', '#FFFFE0');

    $('#MainContent_txtProveedorLetra').css('background', '#FFFFE0');

    $('#MainContent_txtNroLetra').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtFechaGiro').css('background', '#FFFFE0');

    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtProveedorConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtImporteLetra').css('background', '#FFFFE0');

    $('#MainContent_txtTotalFacturaLetra').css('background', '#FFFFE0');

    $('#MainContent_txtNroLetra').css('background', '#FFFFE0');

    $('#MainContent_txtEmpresa').css('background', '#FFFFE0');

    $('#MainContent_txtMoneda').css('background', '#FFFFE0');

    $('#MainContent_txtCantidadLetra').css('background', '#FFFFE0');

    $("#divSeleccionarEmpresa").dialog({
        resizable: false,
        modal: true,
        title: "Empresas",
        title_html: true,
        height: 300,
        width: 420,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }
    });

    if ($('#MainContent_hdnCodEmpresa').val() == '') {
        $('#divSeleccionarEmpresa').dialog('open');
    }

    $('.ccsestilo').css('background', '#FFFFE0');

    F_Derecha();
});

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

function VerifySessionState(result) { }

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']", function () {
    $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
});

$(document).on("change", "select[id $= 'MainContent_ddlSerie']", function () {
    F_Mostrar_Correlativo($("#MainContent_ddlSerie").val(), 1);
});

$(document).on("change", "select[id $= 'MainContent_ddlFormaPago']", function () {
    $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
    F_FormaPago($("#MainContent_ddlFormaPago").val());
});

function F_Controles_Inicializar() {
    var arg;
    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodSerie: 13
            };

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
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_Banco', result.split('~')[6]);
                        F_Update_Division_HTML('div_Empresa', result.split('~')[7]);
                        F_Update_Division_HTML('div_EmpresaConsulta', result.split('~')[8]);
                        $('#hfCodEmpresa').val(result.split('~')[9]);
                        $('#MainContent_lblTC').text(result.split('~')[3]);
                        $('#MainContent_txtNroLetra').val(result.split('~')[5]);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlBanco').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaConsulta').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
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

function F_ValidarAgregar() {
    try {
        var chkSi = '';
        var cadena = '';
        var x = 0;
        var j = 0;
        var lblcodproducto_grilla = '';
        var lblDetalle_grilla = '';
        var lblFactura_grilla = '';
        var chkDel = '';

        $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0)
        { cadena = "No ha seleccionado ninguna factura"; }
        else {
            cadena = "Las sgtes. facturas se encuentran agregadas : ";
            $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkOK', 'lblCodigo');

                if ($(chkSi).is(':checked')) {
                    $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                        chkDel = '#' + this.id;
                        lblDetalle_grilla = chkDel.replace('chkEliminar', 'lblcodigo');
                        lblFactura_grilla = chkDel.replace('chkEliminar', 'lblFactura');
                        if ($(lblcodproducto_grilla).text() == $(lblDetalle_grilla).text()) {
                            cadena = cadena + "\n" + $(lblFactura_grilla).text();
                            j += 1;
                        }

                    });
                }
            });
        }

        if (x != 0 && j == 0)
            cadena = "";

        if (cadena != "") {
            toastr.warning(cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {
    try {
        var lblCodigo_grilla = '';
        var lblFactura_grilla = '';
        var lblEmision_grilla = '';
        var lblTotal_grilla = '';
        var lblMoneda_grilla = '';
        var hfCodMoneda = '';
        var hfCodEmpresa = '';
        var chkSi = '';
        var arrDetalle = new Array();

        $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblCodigo_grilla = chkSi.replace('chkOK', 'lblCodigo');
            lblFactura_grilla = chkSi.replace('chkOK', 'lblFactura');
            lblEmision_grilla = chkSi.replace('chkOK', 'lblEmision');
            lblTotal_grilla = chkSi.replace('chkOK', 'lblTotal');
            lblMoneda_grilla = chkSi.replace('chkOK', 'lblMoneda');
            hfCodMoneda = chkSi.replace('chkOK', 'hfCodMoneda');
            hfCodEmpresa = chkSi.replace('chkOK', 'hfCodEmpresa');  

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodigoFactura: $(lblCodigo_grilla).text(),
                    CodMoneda: $(hfCodMoneda).val(),
                    CodEmpresa: $(hfCodEmpresa).val(),
                    Factura: $(lblFactura_grilla).text(),
                    Emision: $(lblEmision_grilla).text(),
                    Soles: $(lblTotal_grilla).text(),
                    Dolares: $(lblTotal_grilla).text(),
                    xSoles: $(lblTotal_grilla).text(),
                    xDolares: $(lblTotal_grilla).text(),
                    TC: $('#MainContent_lblTC').text(),
                    CodCtaCte: $('#hfCodCtaCte').val()
                };

                arrDetalle.push(objDetalle);
            }
        });

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_AgregarTemporal_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotalFactura').val(result.split('~')[5]);
                F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                if (result.split('~')[2] == 'La(s) factura(s) se han agregado con exito')
                    toastr.warning('La(s) factura(s) se han agregado con exito');
            }
            else {
                toastr.warning(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
    }
}

function F_MostrarTotales() {

    var lblimporte_grilla = '';
    var chkDel = '';
    var Total = 0;
    var Igv = 0;
    var Subtotal = 0;
    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
        chkDel = '#' + this.id;
        lblimporte_grilla = chkDel.replace('chkEliminar', 'lblimporte');
        Total += parseFloat($(lblimporte_grilla).text());
    });
    var Cuerpo = '#MainContent_'
    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgv').val((Total * parseFloat($(Cuerpo + 'ddligv').val())).toFixed(2));
    $(Cuerpo + 'txtSubTotal').val((Total / (1 + parseFloat($(Cuerpo + 'ddligv').val()))).toFixed(2));

}

function F_EliminarTemporal_Factura() {
    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblID = '';

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblID = chkSi.replace('chkEliminar', 'lblID');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodDetalle: $(lblID).text()
                };
                arrDetalle.push(objDetalle);
            }
        });
        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_EliminarTemporal_Factura_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0')
                    $('#MainContent_txtTotalFactura').val('0.00');
                else
                    $('#MainContent_txtTotalFactura').val(result.split('~')[5]);
                F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                toastr.warning(result.split('~')[2]);
            }
            else {
                toastr.warning(result.split('~')[2]);
            }

            return false;

        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
    }
}

function F_ValidarEliminar_Factura() {

    try {
        var chkSi = '';
        var x = 0;

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0) {
            toastr.warning("Seleccione una factura para eliminar");
            return false;
        }
        else
        { return true; }

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_ValidarGrabarDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtProveedor').val() == '' || $('#hfCodCtaCte').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Cliente';

        if ($(Cuerpo + 'lblTC').text() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtEmision').val() == '')
            Cadena = Cadena + '<p></p>' + 'Emision';

        if ($(Cuerpo + 'txtTotalFactura').val() == '0.00')
            Cadena = Cadena + '<p></p>' + 'Ingrese Factura(s)';

        if ($(Cuerpo + 'txtTotalLetra').val() == '0.00')
            Cadena = Cadena + '<p></p>' + 'Ingrese Letra(s)';

        if (parseFloat($(Cuerpo + 'txtTotalFactura').val()) != parseFloat($(Cuerpo + 'txtTotalLetra').val()))
            Cadena = Cadena + '<p></p>' + 'El total de la factura y la letra no puede ser distintos.';

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
        var lblCodigo_grilla = '';
        var chkSi = '';
        var arrDetalle = new Array();
        var Contenedor = '#MainContent_';

        $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblCodigo_grilla = chkSi.replace('chkEliminar', 'lblCodigo');

            var objDetalle = {
                CodLetraCab: $(lblCodigo_grilla).text()
            };

            arrDetalle.push(objDetalle);
        });

        var objParams = {
            Filtro_CodEmpresa: $('#hfCodEmpresa').val(),
            Filtro_CodSede: $('#hfCodSede').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'La(s) Letra(s) se ha agregado con exito') {
                    toastr.success('Se grabo correctamente');

                    F_Nuevo();

                }

            }
            else {
                MostrarEspera(false);
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#MainContent_ddlMoneda').val(2);
    $('#hfCodCtaCte').val('0');
    $('#hfCodigoTemporal').val('0');
    $('#MainContent_txtProveedor').val('');
    $('#MainContent_txtTotalFactura').val('0.00');
    $('#MainContent_txtTotalLetra').val('0.00');
    $('#MainContent_txtProveedor').focus();
    try {
        var objParams = {
            Filtro_CodSerie: '61'
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Nuevo_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_grvFactura', result.split('~')[3]);
                F_Update_Division_HTML('div_grvLetra', result.split('~')[2]);
                $('#MainContent_ddlMoneda').val(2);
                $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                $('#MainContent_txtNroLetra').val(result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                if (UnaEmpresa == 0)
                    $('#divSeleccionarEmpresa').dialog('open');
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

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkCliente').is(':checked'))
            chkCliente = '1';

        var objParams = {
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_CodSede: $('#hfCodSede').val(),
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
            Filtro_CodEmpresa: $('#MainContent_ddlEmpresaConsulta').val()
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
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function imgMas_Click(Control) {
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        $(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_AnularRegistro(Fila) {
    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
        var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');

        if ($(lblEstado).text() == "ANULADO") {
            toastr.warning("LA LETRA SE ENCUENTRA ANULADA");
            return false;
        }

        if ($(lblEstado).text() == "CANCELADO PARCIAL") {
            toastr.warning("ESTA LETRA SE ENCUENTRA CANCELADA PARCIAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ANULE LA LETRA");
            return false;
        }

        if ($(lblEstado).text() == "CANCELADO TOTAL") {
            toastr.warning("ESTA LETRA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ANULE LA LETRA");
            return false;
        }

        if (!confirm("ESTA SEGURO DE ELIMINAR LA LETRA" + "\nSE VA ANULAR LAS LETRAS ASOCIADAS A LAS FACTURAS DEL DETALLE"))
            return false;

        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkCliente').is(':checked'))
            chkCliente = '1';

        var objParams = {
            Filtro_Codigo: $(lblCodigo).text(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
            Filtro_CodSede: $('#hfCodSede').val()
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

function getContentTab() {

    var date = new Date();
    date.setMonth(date.getMonth(), 1);
    $('#MainContent_ddlEmpresaConsulta').val($('#hfCodEmpresa').val());
    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;

}

function F_ValidarAgregarLetra() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';
        var lblcoddetalle_grilla = '';
        var x = 0;

        $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblLetra');

            if ($(lblcoddetalle_grilla).text() == $(Cuerpo + 'txtNroLetra').val())
                x = 1;

        });

        if (x == 0) {
            if ($(Cuerpo + 'txtNroLetra').val() == '')
                Cadena = Cadena + '<p></p>' + 'Nro Letra';

            if ($(Cuerpo + 'txtCantidadLetra').val() == '')
                Cadena = Cadena + '<p></p>' + 'Importe de Letra';

            if ($(Cuerpo + 'txtVencimiento').val() == '')
                Cadena = Cadena + '<p></p>' + 'Vencimiento';

            if ($(Cuerpo + 'txtImporteLetra').val() == '')
                Cadena = Cadena + '<p></p>' + 'Importe';

            if (($(Cuerpo + 'txtTotalFactura').val() != '0.00' & $(Cuerpo + 'txtTotalLetra').val() != '0.00') && (parseFloat($(Cuerpo + 'txtTotalFactura').val()) == parseFloat($(Cuerpo + 'txtTotalLetra').val())))
                Cadena = Cadena + '<p></p>' + 'No se puede agregar mas letras; el total de la factura y la letra son iguales.';
        }
        else {
            Cadena = "La letra " + $(Cuerpo + 'txtNroLetra').val() + ' se encuentra agregada';
        }

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            $(Cuerpo + 'txtNroLetra').focus();
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_AgregarLetra() {
    try {
        var hfCodigo = '';
        var chkSi = '';
        var hfSoles = '';
        var arrDetalle = new Array();
        var Contenedor = '#MainContent_';
        var arrDetalle = new Array();

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodigo = chkSi.replace('chkEliminar', 'hfCodigo');
            hfSoles = chkSi.replace('chkEliminar', 'hfSoles');  

            var objDetalle = {
                CodFactura: $(hfCodigo).val(),
                Total: $(hfSoles).val()
            };

            arrDetalle.push(objDetalle);
        });

        var objParams = {
            Filtro_Numero: $(Contenedor + 'txtNroLetra').val(),
            Filtro_Emision: $(Contenedor + 'txtFechaGiro').val(),
            Filtro_CantidadLetra: $(Contenedor + 'txtCantidadLetra').val(),
            Filtro_TotalFactura: $(Contenedor + 'txtTotalFacturaLetra').val(),
            Filtro_Moneda: $(Contenedor + 'txtMoneda').val(),
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_XmlConsulta: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AgregarLetraTemporal_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'LAS LETRAS SE HAN AGREGADO CON EXITO') {
                    F_Update_Division_HTML('div_grvLetra', result.split('~')[2]);
                    $('#MainContent_txtTotalLetra').val(result.split('~')[3]);
                    toastr.warning('LAS LETRAS SE HAN AGREGADO CON EXITO');
                    var Correlativo = '0000000' + (parseInt($(Contenedor + 'txtNroLetra').val().replace('0', '')) + 1);
                    $(Contenedor + 'txtNroLetra').val(Correlativo.slice(-7));
                    F_LimpiarLetra();
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $('.Jq-ui-dtp').datepicker({
                        changeMonth: true,
                        changeYear: true,
                        dateFormat: 'dd/mm/yy'
                    });
                    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
                    $('#div_DatosLetra').dialog('close');
                }
                else
                    toastr.warning(str_mensaje_operacion);
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

function F_ValidarEliminar_Letra() {

    try {
        var chkSi = '';
        var x = 0;

        $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0) {
            toastr.warning("Seleccione una Letra para eliminar");
            return false;
        }
        else
        { return true; }

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_EliminarTemporal_Letra() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var arrConsulta = new Array();
        var lblcoddetalle_grilla = '';
        var lblCodigo_grilla = '';


        $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {

                    CodLetraCab: $(lblcoddetalle_grilla).text()
                };

                arrDetalle.push(objDetalle);
            }
        });

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblCodigo_grilla = chkSi.replace('chkEliminar', 'lblcodigo');


            var objDetalle = {
                CodFactura: $(lblCodigo_grilla).text()
            };

            arrConsulta.push(objDetalle);

        });

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_XmlConsulta: Sys.Serialization.JavaScriptSerializer.serialize(arrConsulta)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EliminarTemporal_Letra_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                if (result.split('~')[4] == '0')
                    $('#MainContent_txtTotalLetra').val('0.00');
                else
                    $('#MainContent_txtTotalLetra').val(result.split('~')[4]);
                F_Update_Division_HTML('div_grvLetra', result.split('~')[3]);
                toastr.warning(result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');
            }
            else {
                toastr.warning(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
    }
}

function F_LimpiarLetra() {
    $('#MainContent_txtMoneda').val($("#MainContent_ddlMoneda option:selected").text());
    $('#MainContent_txtProveedorLetra').val($('#MainContent_txtProveedor').val());
    $('#MainContent_txtFechaGiro').val($('#MainContent_txtEmision').val());
    $('#MainContent_txtTotalFacturaLetra').val($('#MainContent_txtTotalFactura').val());
    $('#MainContent_txtNroLetra').val('');
    $('#MainContent_txtCantidadLetra').val('');
    $('#MainContent_ddlFormaPago').val(4);
    F_FormaPago(4);
    $('#div_DatosLetra').dialog('open');
    $('#MainContent_txtNroLetra').focus();
}

function F_TipoCambio() {
    try {
        var objParams = {
            Filtro_Emision: $("#MainContent_txtEmision").val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_TipoCambio_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1")
                $('#MainContent_lblTC').text(result.split('~')[2]);
            else
                toastr.warning(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
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

function F_FormaPago(CodFormaPago) {

    var arg;
    try {
        switch (CodFormaPago) {
            case "1":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 0));
                break;

            case "4":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 30));
                break;

            case "3":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 15));
                break;

            case "8":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 45));
                break;

            case "9":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 60));
                break;

            case "11":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 7));
                break;

            case "12":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 0));
                break;

            case "13":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 75));
                break;

            case "14":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 90));
                break;
        }


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_Imprimir(Fila) {

    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgImprimir', 'lblcodigo');
    var lblEstado = '#' + imgID.replace('imgImprimir', 'lblestado');

    if ($(lblEstado).text() == 'Anulado(a)') {
        toastr.warning("La letra se encuentra anulada");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '206';


    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).text() + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_Mostrar_Correlativo(CodDoc) {

    var arg;

    try {
        var objParams = {
            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerie option:selected").text()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Correlativo_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        if (CodDoc == 19)
                            $('#MainContent_txtNumero').val(result.split('~')[2]);
                        else
                            $('#MainContent_txtNumeroGuia').val(result.split('~')[2]);
                    }
                    else
                        toastr.warning(str_mensaje_operacion);
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function F_ElegirEmpresa(Fila) {
    var imgID = Fila.id;
    var hfCodEmpresa_Grilla = '#' + imgID.replace('imgSelecEmpresa', 'hfCodEmpresa');
    var ddlSede = '#' + imgID.replace('imgSelecEmpresa', 'ddlSede');
    var lblRazonSocial = '#' + imgID.replace('imgSelecEmpresa', 'lblRazonSocial');
    var Cuerpo = '#MainContent_';
    $(Cuerpo + 'txtEmpresa').val($(lblRazonSocial).text());
    $('#hfCodEmpresa').val($(hfCodEmpresa_Grilla).val());
    $('#hfCodSede').val($(ddlSede).val());
    $('#divSeleccionarEmpresa').dialog('close');
}

var UnaEmpresa = 0;
function F_ElegirEmpresa2() {
    UnaEmpresa = 1;
    var Cuerpo = '#MainContent_';
    //$(Cuerpo + 'txtEmpresa').val($(lblRazonSocial).text());
    $('#hfCodEmpresa').val($(Cuerpo + 'hdnCodEmpresa').val());
    $('#hfCodSede').val($(Cuerpo + 'hdnCodSede').val());
    $('#divSeleccionarEmpresa').dialog('close');
}

function F_ActualizarLetra(Fila, Control) {
    try {
        var txtLetra = '';
        var lblCodigo = '';
        var txtEmision = '';
        var txtVencimiento = '';
        var txtTotal = '';
        var hfTotal = '';
        var hfLetra = '';
        var txtLetraDetalle = '';

        switch (Control) {
            case 1:
                txtLetra = '#' + Fila;
                lblCodigo = txtLetra.replace('txtLetra', 'lblCodigo');
                txtEmision = txtLetra.replace('txtLetra', 'txtEmision');
                txtVencimiento = txtLetra.replace('txtLetra', 'txtVencimiento');
                txtTotal = txtLetra.replace('txtLetra', 'txtTotal');
                hfLetra = txtLetra.replace('txtLetra', 'hfLetra');

                if ($.trim($(txtLetra).val()) == $.trim($(hfLetra).val()))
                    return false;

                if ($.trim($(txtLetra).val()) == '') {
                    $(txtLetra).val($(hfLetra).val());
                    return false;
                }

                var Mensaje = "El sgte numero de Letra se esta repitiendo";

                $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    txtLetraDetalle = chkSi.replace('chkEliminar', 'txtLetra');

                    if ($(txtLetraDetalle).val() == $(txtLetra).val()) {
                        Mensaje = Mensaje + "\n" + $(txtLetraDetalle).val();
                        return false;
                    }

                });

                if (Mensaje != "El sgte numero de Letra se esta repitiendo") {
                    toastr.warning(Mensaje);
                    $(txtLetra).val($(hfLetra).val());
                    return false;
                }
                break;
            case 2:
                txtEmision = '#' + Fila;
                lblCodigo = txtEmision.replace('txtEmision', 'lblCodigo');
                txtLetra = txtEmision.replace('txtEmision', 'txtLetra');
                txtVencimiento = txtEmision.replace('txtEmision', 'txtVencimiento');
                txtTotal = txtEmision.replace('txtEmision', 'txtTotal');
                hfEmision = txtEmision.replace('txtEmision', 'hfEmision');

                if (F_ValidarFechaMayor($('#MainContent_txtEmision').val(), $(txtEmision).val())) {
                    toastr.warning("EMISION NO DEBE SER ANTERIOR A LA FECHA ACTUAL");
                    $(txtEmision).val($(hfEmision).val());
                    return false;
                }

                if (F_ValidarFechaMayor($(txtEmision).val(), $(txtVencimiento).val())) {
                    toastr.warning("EMISION NO DEBE SER SUPERIOR AL VENCIMIENTO");
                    $(txtEmision).val($(hfEmision).val());
                    return false;
                }
                break;
            case 3:
                txtVencimiento = '#' + Fila;
                lblCodigo = txtVencimiento.replace('txtVencimiento', 'lblCodigo');
                txtEmision = txtVencimiento.replace('txtVencimiento', 'txtEmision');
                txtLetra = txtVencimiento.replace('txtVencimiento', 'txtLetra');
                txtTotal = txtVencimiento.replace('txtVencimiento', 'txtTotal');
                hfVencimiento = txtVencimiento.replace('txtVencimiento', 'hfVencimiento');

                if (F_ValidarFechaMayor($('#MainContent_txtEmision').val(), $(txtVencimiento).val())) {
                    toastr.warning("VENCIMIENTO NO DEBE SER ANTERIOR A LA FECHA ACTUAL");
                    $(txtVencimiento).val($(hfVencimiento).val());
                    return false;
                }

                if (F_ValidarFechaMayor($(txtEmision).val(), $(txtVencimiento).val())) {
                    toastr.warning("EMISION NO DEBE SER SUPERIOR AL VENCIMIENTO");
                    $(txtVencimiento).val($(hfVencimiento).val());
                    return false;
                }
                break;
            case 4:
                txtTotal = '#' + Fila;
                lblCodigo = txtTotal.replace('txtTotal', 'lblCodigo');
                txtEmision = txtTotal.replace('txtTotal', 'txtEmision');
                txtVencimiento = txtTotal.replace('txtTotal', 'txtVencimiento');
                txtLetra = txtTotal.replace('txtTotal', 'txtLetra');
                hfTotal = txtTotal.replace('txtTotal', 'hfTotal');

                if ($.trim($(txtTotal).val()) == $.trim($(hfTotal).val()))
                    return false;

                if ($.trim($(txtTotal).val()) == '') {
                    $(txtTotal).val($(hfTotal).val());
                    return false;
                }

                break;
        }

        var arrDetalle = new Array();

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodigo = chkSi.replace('chkEliminar', 'hfCodigo');

            var objDetalle = {
                CodFactura: $(hfCodigo).val()
            };

            arrDetalle.push(objDetalle);
        });

        var objParams = {
            Filtro_CodLetra: $(lblCodigo).text(),
            Filtro_Numero: $(txtLetra).val(),
            Filtro_FechaEmision: $(txtEmision).val(),
            Filtro_FechaVencimiento: $(txtVencimiento).val(),
            Filtro_Total: $(txtTotal).val(),
            Filtro_XmlConsulta: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_ActualizarLetra_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_mensaje_operacion == "SE ACTUALIZO CORRECTAMENTE") {
                F_Update_Division_HTML('div_grvLetra', result.split('~')[2]);
                $('#MainContent_txtTotalLetra').val(result.split('~')[3]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('.Jq-ui-dtp').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd/mm/yy'
                });
                $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
                $('#div_DatosLetra').dialog('close');
                toastr.success(result.split('~')[1]);
            }
            else
                toastr.warning(result.split('~')[1]);
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgEliminarDocumento', 'hfCodigo');
        var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
        var lblNumero = '#' + imgID.replace('imgEliminarDocumento', 'lblNumero');

        if ($(lblEstado).text() == "CANCELADO PARCIAL") {
            toastr.warning("ESTA LETRA SE ENCUENTRA CANCELADA PARCIAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA LETRA");
            return false;
        }

        if ($(lblEstado).text() == "CANCELADO TOTAL") {
            toastr.warning("ESTA LETRA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA LETRA");
            return false;
        }

        if (!confirm("ESTA SEGURO DE ELIMINAR LA LETRA : " + $(lblNumero).text() + "\nSE VA ELIMINAR LAS LETRAS ASOCIADAS A LAS FACTURAS DEL DETALLE"))
            return false;

        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkCliente').is(':checked'))
            chkCliente = '1';

        var objParams = {
            Filtro_Codigo: $(hfCodigo).val(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
            Filtro_CodSede: $('#hfCodSede').val(),
            Filtro_CodEmpresa: $('#MainContent_ddlEmpresaConsulta').val()
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