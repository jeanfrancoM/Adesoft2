var AppSession = "../Inventario/GuiaInternaCodigo.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 4;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
            return (evt ? evt.which : event.keyCode) != 13;
        }

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR"))
                F_GrabarDocumento();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Buscar();
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

    $('#MainContent_txtArticulo').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGProductos_Select',
                data: "{'Descripcion':'" + request.term + "','CodAlmacen':'" + $('#hfCodSede').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Stock: item.split(',')[2],
                            Costo: item.split(',')[3],
                            Moneda: item.split(',')[4],
                            CodProducto: item.split(',')[5],
                            NroSerie: item.split(',')[6]
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
            $('#hfCodProducto').val(i.item.CodProducto);       
            $('#MainContent_txtStock').val(i.item.Stock);
        },
        minLength: 3
    });

    $('#divTabs').tabs();


    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    
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

    $('#MainContent_txtNumeroConsulta').blur(function () {
        var id = '0000000' + $('#MainContent_txtNumeroConsulta').val();
        $('#MainContent_txtNumeroConsulta').val(id.substr(id.length - 7));
    return false;
});
    
    $("#MainContent_txtStock").ForceNumericOnly();

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtStock').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    F_Controles_Inicializar();

});

$(document).keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        console.log('You pressed a "enter" key in somewhere');
    }
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

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_CodSerie: 67
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
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[2]);        
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#hfCodSede').val(result.split('~')[3]);
                        F_Update_Division_HTML('div_Sucursal', result.split('~')[4]);
                        $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
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

function F_ListarNroCuenta() {

    var arg;

    try {

        var objParams = {

            Filtro_CodBanco: $('#MainContent_ddlTipoOperaciones').val(),
            Filtro_CodMoneda: $('#MainContent_ddlMoneda').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_ListarNroCuenta_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Serie', result.split('~')[2]);

                    }
                    else {

                        toastr.warning(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {

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

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {
    try {

        var chkSi = '';
        var lblSerie = '';
        var Contador = 0;
        var Contador2 = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblSerie = chkSi.replace('chkEliminar', 'lblSerie');

            Contador2 += 1;

            if ($(lblSerie).text() == $('#MainContent_txtSerializacion').val())
                Contador += 1;

            if ($(lblSerie).text() == '' && Contador2 == 1)
                Contador2 -= 1


        });


        if (Contador > 0) {
            $('#MainContent_txtSerializacion').val('');
            return false;
        }

        if ($('#MainContent_ddlTipoOperaciones').val() == 1 && parseFloat($('#MainContent_txtStock').val()) <= Contador2) {
            $('#MainContent_txtSerializacion').val('');
            return false;
        }

        if ($('#MainContent_ddlTipoOperaciones').val() == 1 && parseFloat($('#MainContent_txtNroSerie').val()) == parseFloat($('#MainContent_txtStock').val())) {
            $('#MainContent_txtSerializacion').val('');
            return false;
        }


        var objParams = {
            Filtro_CodSerializacionCab: $('#hfCodSerializacionCab').val(),
            Filtro_Serie: $('#MainContent_txtSerializacion').val(),
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodEstado: 1
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
                $('#hfCodSerializacionCab').val(result.split('~')[3]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#MainContent_txtSerializacion').val('');
            }
            else {
                toastr.warning(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_EliminarTemporal_Factura() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';


        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblDetalle');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {

                    CodDetalle: $(lblcoddetalle_grilla).text()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


        F_EliminarTemporal_Factura_NET(arg, function (result) {
            //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

            //                MostrarEspera(false);

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
 
        if ($(Cuerpo + 'txtArticulo').val() == '' || $('#hfCodProducto').val() == 0)
            Cadena = Cadena + '\n' + 'Producto';

        if ($(Cuerpo + 'txtCantidad').val() == '' || $(Cuerpo + 'txtCantidad').val() == 0)
            Cadena = Cadena + '\n' + 'Cantidad';

        if (parseFloat($(Cuerpo + 'txtCantidad').val()) > parseFloat($(Cuerpo + 'txtStock').val()))
            Cadena = Cadena + '\n' + 'Stock Insuficiente';

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

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_Cantidad:    $(Contenedor + 'txtCantidad').val(),
            Filtro_CodAlterno:  $('#hfCodAlterno').val(),
            Filtro_CodAlmacenDestino: $(Contenedor + 'ddlSucursal').val()
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
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                    toastr.success('Se grabo correctamente.');
                    F_Nuevo();
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

        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    var Contenedor = '#MainContent_';

    $('#hfCodAlterno').val('');
    $('#hfCodProducto').val('0');

    $(Contenedor + 'txtArticulo').val('');
    $(Contenedor + 'txtStock').val('');
    $(Contenedor + 'txtCantidad').val('');
    return false;  
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
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
            Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_CodTipoDoc: '4',
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente

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
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblnumero')); 
                if (str_mensaje_operacion != '')
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

function F_ValidarEliminar() {

    try {
        var chkSi = '';
        var x = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0) {
            toastr.warning("Seleccione una serie para eliminar");
            return false;
        }
        else
        { return true; }

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_EliminarTemporal() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblID = '';


        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
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
            Filtro_CodSerializacionCab: $('#hfCodSerializacionCab').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EliminarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                }
                else {
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                }

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                if (result.split('~')[2] == 'Se han eliminado los productos correctamente.')
                    toastr.success('Se han eliminado los productos correctamente.');
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

function getContentTab() {

    var date = new Date();
    date.setMonth(date.getMonth(), 1);

    //$('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));

    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;

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

function F_ImprimirFacturaPDF(Fila) {
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '100';
    var CodNotaIngreso = $("#" + Fila.id.replace("imgPdf", "lblcodigo")).text();
    var NombreTabla = "Electronica";
    var NombreArchivo = "Web_Reporte_Inventario_rptFormatoGuia.rpt";

    ArchivoRPT = "";
    rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Codigo=' + CodNotaIngreso + '&';
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}
