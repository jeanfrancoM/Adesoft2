var AppSession = "../Maestros/ActualizacionPrecios.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscarArticulo').click(function () {
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val() == "")
                return false
            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
                cadena = cadena + "\n" + "Articulo (Minimo 2 Caracteres)"

//            if ($('#MainContent_ddlMoneda option').size() == 0)
//            { cadena = cadena + "\n" + "Moneda"; }
//            else {
//                if ($('#MainContent_ddlMoneda').val() == "-1")
//                    cadena = cadena + "\n" + "Moneda";
//            }

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

    $('#MainContent_btnAgregarProducto').click(function () {
        try {

            $('#MainContent_txtArticulo').val('');
            $('#MainContent_chkServicios').prop('checked', false);
            $('#MainContent_chkNotaPedido').prop('checked', false);
            $("#divConsultaArticulo").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Productos",
                title_html: true,
                height: 500,
                width: 1000,
                autoOpen: false
            });

            $('#divConsultaArticulo').dialog('open');
            $('#MainContent_txtArticulo').focus();


            var objParams = {};
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


            F_CargarGrillaVaciaConsultaArticulo_NET(arg, function (result) {
                //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

                //                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);

                }
                else {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

            });


        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

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

    $('#MainContent_btnAgregar').click(function () {
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            F_LimpiarGrillaConsulta();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminar').click(function () {
        try {
            if (F_ValidarEliminar() == false)
                return false;

            if (confirm("Esta seguro de eliminar los productos seleccionado"))
                F_EliminarTemporal();

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

    $('#MainContent_btnExcel').click(function () {
        try {
            F_VisualizarExcel($('#hfCodigoTemporal').val());
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        try {
            if (F_ValidarGrabarDocumento() === false)
            return false;

            if (confirm("ESTA SEGURO DE GRABAR LA " + $("#MainContent_ddlTipoDoc option:selected").text()))
            F_GrabarDocumento();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });


    $('#MainContent_txtArticulo').blur(function () {
        try {
            if ($('#MainContent_txtArticulo').val() == '')
                return false

            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
                cadena = cadena + "\n" + "Articulo (Minimo 2 Caracteres)"



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

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#divTabs').tabs();

    F_Controles_Inicializar();


    $('#MainContent_txtEmision').css('background', '#FFFFE0');
    $('#MainContent_txtObservacion').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    

});

$().ready(function () {

    $(document).everyTime(600000, function () {

        $.ajax({
            type: "POST",
            url: '../Compras/NotaPedido.aspx/KeepActiveSession',
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: VerifySessionState,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr.warning(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });

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
                Filtro_Fecha: ''
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
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);
                        F_Update_Division_HTML('div_igv', result.split('~')[3]);
                    }
                    else {

                        toastr.warning(str_mensaje_operacion);

                    }

                    F_Nuevo();
                    $('.ccsestilo').css('background', '#FFFFE0');

                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function VerifySessionState(result) { }

function F_Buscar_Productos() {

    var arg;
    var CodTipoProducto = 2;

    try {

        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: 1,
                Filtro_Servicio: 0,
                Filtro_NotaPedido: 0
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_Productos_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);
                        if (str_mensaje_operacion != '')
                            toastr.warning(str_mensaje_operacion);
                    }
                    else {

                        toastr.warning(str_mensaje_operacion);

                    }
                    $('.ccsestilo').css('background', '#FFFFE0');

                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function F_ValidarPrecioLista(ControlID) {

    var ddlLista_Grilla = '';
    var lblprecio = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;

    ddlLista_Grilla = '#' + ControlID;
    txtprecio_grilla = ddlLista_Grilla.replace('ddlLista', 'txtPrecioLibre');
    txtcant_grilla = ddlLista_Grilla.replace('ddlLista', 'txtCantidad');

    switch ($(ddlLista_Grilla).val()) {
        case "1":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio1');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;

        case "2":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio2');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;
        case "3":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio3');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;

        case "4":
            $(txtprecio_grilla).val('');
            $(txtprecio_grilla).prop('disabled', false);
            $(txtprecio_grilla).focus();
            break;
    }

    return true;
}

function F_ValidarStockGrilla(ControlID) {

    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidad', 'chkOK');
    lblstock = txtcantidad_Grilla.replace('txtCantidad', 'lblstock');

    boolEstado = $(chkok_grilla).is(':checked');

    //    if (boolEstado && $(txtcantidad_Grilla).val() == '') {
    //        toastr.warning("Ingrese la cantidad");

    //        return false;
    //    }

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if (boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            toastr.warning("Stock insuficiente");
            $(txtcantidad_Grilla).val('');
            return false;
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            toastr.warning("Stock insuficiente");
            $(txtcantidad_Grilla).val('');
            return false;
        }
    }


    return true;
}

function F_ValidarPrecioGrilla(ControlID) {

    var txtprecio_Grilla = '';
    var lblprecio_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtprecio_Grilla = '#' + ControlID;
    chkok_grilla = txtprecio_Grilla.replace('txtPrecioLibre', 'chkOK');
    lblprecio_grilla = txtprecio_Grilla.replace('txtPrecioLibre', 'lblPrecio1');
    boolEstado = $(chkok_grilla).is(':checked');


    //            if ($('#hfCodUsuario').val()!='5' && boolEstado && parseFloat($(txtprecio_Grilla).val())< parseFloat($(lblprecio_grilla).val()))
    //            {toastr.warning("Precio por debajo del minimo");
    //            $(txtprecio_Grilla).val('');
    //              return false;
    //             }

    return true;
}

function F_ValidarCheck(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var txtprecio2_grilla = '';
    var txtprecio3_grilla = '';
    var lblprecio_grilla = '';
    var lblprecio2_grilla = '';
    var lblprecio3_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    var cadena = 'Ingrese los sgtes. campos: '

    chkok_grilla = '#' + ControlID;

    txtprecio_grilla = chkok_grilla.replace('chkOK', 'txtPrecio');
    txtprecio2_grilla = chkok_grilla.replace('chkOK', 'txtPrecio2');
    txtprecio3_grilla = chkok_grilla.replace('chkOK', 'txtPrecio3');

    lblprecio_grilla = chkok_grilla.replace('chkOK', 'lblPrecio');
    lblprecio2_grilla = chkok_grilla.replace('chkOK', 'lblPrecio2');
    lblprecio3_grilla = chkok_grilla.replace('chkOK', 'lblPrecio3');
    


    boolEstado = $(chkok_grilla).is(':checked');
    if (boolEstado) {
        $(txtprecio_grilla).prop('disabled', false);
        $(txtprecio2_grilla).prop('disabled', false);
        $(txtprecio3_grilla).prop('disabled', false);

        $(txtprecio_grilla).val($(lblprecio_grilla).text());
        $(txtprecio2_grilla).val($(lblprecio2_grilla).text());
        $(txtprecio3_grilla).val($(lblprecio3_grilla).text());

        $(txtprecio_grilla).select();
    }
    else {
        $(txtprecio_grilla).prop('disabled', true);
        $(txtprecio2_grilla).prop('disabled', true);
        $(txtprecio3_grilla).prop('disabled', true);

        $(txtprecio_grilla).val('0.00');
        $(txtprecio2_grilla).val('0.00');
        $(txtprecio3_grilla).val('0.00');
    }


    return true;
}

function F_ModificarPrecio(ControlID) {
    var dato = "#" + ControlID;

    if ($(dato).val().trim() === "") {
        $(dato).val('0.00');
        $(dato).select();
        return false;
    }

    if (isNaN($(dato).val().trim())) {
        $(dato).val('0.00');
        $(dato).select();
        return false;
    }

    $(dato).val(Number($(dato).val()).toFixed(2));
return true;
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
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 4));
                break;

            case "11":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 7));
                break;
        }


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_ValidarAgregar() {

    try {
        var chkSi = '';
        var chkDel = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var cadena = "Ingrese los sgtes. campos: ";
        var lblcodproducto_grilla = '';
        var hfcodarticulodetalle_grilla = '';
        var lbldscproducto_grilla = '';
        var x = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');

            if ($(chkSi).is(':checked')) {
                //                            if ($(txtprecio_grilla).val()=='')
                //                                cadena=cadena + "\n" + "Precio para el Codigo " + $(lblcodproducto_grilla).text() ;

                if ($(txtcantidad_grilla).val() == '')
                    cadena = cadena + "\n" + "Cantidad para el Codigo " + $(lblcodproducto_grilla).val();

                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            toastr.warning(cadena);
            return false;
        }
        else {
            cadena = "Los sgtes. productos se encuentran agregados : ";
            $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');

                if ($(chkSi).is(':checked')) {
                    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                        chkDel = '#' + this.id;
                        hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfCodArticulo');
                        lbldscproducto_grilla = chkDel.replace('chkEliminar', 'txtProducto');

                        if ($(lblcodproducto_grilla).val() == $(hfcodarticulodetalle_grilla).val()) {
                            cadena = cadena + "\n" + $(lbldscproducto_grilla).val();
                        }

                    });
                }
            });
        }

        if (cadena != "Los sgtes. productos se encuentran agregados : ") {
            toastr.warning(cadena);
            return false;
        }
        else {
            return true;
        }
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {

    try {


        var chkSi = '';
        var arrDetalle = new Array();

        var lblcodproducto_grilla = '';
        var hfMarca_grilla = '';
        var hfDscProducto_grilla = '';
        var hfcodunidadventa = '';
        var txtprecio_grilla = '';
        var txtprecio2_grilla = '';
        var txtprecio3_grilla = '';
        var chkServicio = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
            hfDscProducto_grilla = chkSi.replace('chkOK', 'hfDscProducto');
            hfMarca_grilla = chkSi.replace('chkOK', 'hfMarca');
            hfcodunidadventa = chkSi.replace('chkOK', 'hfcodunidadventa');
            txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecio');
            txtprecio2_grilla = chkSi.replace('chkOK', 'txtPrecio2');
            txtprecio3_grilla = chkSi.replace('chkOK', 'txtPrecio3');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).val(),
                    Descripcion: $(hfDscProducto_grilla).val().trim(),
                    Marca: $(hfMarca_grilla).val().trim(),
                    Cantidad: 1, 
                    Precio: $(txtprecio_grilla).val(),
                    Precio2: $(txtprecio2_grilla).val(),
                    Precio3: $(txtprecio3_grilla).val(),
                    Costo: 0,
                    CodUm: $(hfcodunidadventa).val(),
                    CodDetalle: 0
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        var objParams = {
            Filtro_CodTipoDoc: "17",
            Filtro_SerieDoc: '001',
            Filtro_NumeroDoc: '0000001',
            Filtro_FechaEmision: $('#MainContent_txtEmision').val(),
            Filtro_Vencimiento: $('#MainContent_txtEmision').val(),
            Filtro_CodCliente: 20,
            Filtro_CodFormaPago: 1,
            Filtro_CodMoneda: 1,
            Filtro_TipoCambio: 3,
            Filtro_SubTotal: 0,
            Filtro_CodProforma: "0",
            Filtro_Igv: 0,
            Filtro_Total: 0,
            Filtro_CodTraslado: "0",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_Servicio: chkServicio,
            Filtro_NotaPedido: 0,
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
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
                //                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                //                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                //                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblPrecio"));
                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    toastr.success('Los Producto(s) se han agregado con exito');
            }
            else {
                toastr.warning(result.split('~')[2]);
            }
            $('.ccsestilo').css('background', '#FFFFE0');
            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
    }
}

function F_ActualizarPrecio(Fila, rplc) {
    try {
        var txtPrecio = '#' + Fila;
        var hfCodDetalle = txtPrecio.replace(rplc, 'hfCodDetalle');
        var Precio = txtPrecio.replace(rplc, 'txtPrecio');
        var Precio2 = txtPrecio.replace(rplc, 'txtPrecio2');
        var Precio3 = txtPrecio.replace(rplc, 'txtPrecio3');
        var Descripcion = txtPrecio.replace(rplc, 'txtProducto');
        var Marca = txtPrecio.replace(rplc, 'txtMarca');

        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetalle).val(),
            Filtro_Precio: $(Precio).val() / tasaigv,
            Filtro_Precio2: $(Precio2).val() / tasaigv,
            Filtro_Precio3: $(Precio3).val() / tasaigv,
            Filtro_Cantidad: 1,
            Filtro_Descripcion: $(Descripcion).val(),
            Filtro_Marca: $(Marca).val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_FlagIgv: 1,
            Filtro_Flag: 0,
            Filtro_TasaIgvDscto: tasaigv
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarPrecio_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
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

function F_LimpiarGrillaConsulta() {

    var chkSi = '';
    var txtprecio_grilla = '';
    var txtcantidad_grilla = '';
    var ddlLista_grilla = '';

    $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
        chkSi = '#' + this.id;
        txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
        txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
        ddlLista_grilla = chkSi.replace('chkOK', 'ddlLista');

        $(txtcantidad_grilla).prop('disabled', true);
        $(txtprecio_grilla).val('');
        $(txtcantidad_grilla).val('');
        $(ddlLista_grilla).val('4');

        $(chkSi).prop('checked', false);

    });
}

function F_EliminarTemporal() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';


        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'hfCodDetalle');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {

                    CodDetalle: $(lblcoddetalle_grilla).val()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat(1.18);
        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
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
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblPrecio"));
                $('.ccsestilo').css('background', '#FFFFE0');
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
            toastr.warning("Seleccione un articulo para eliminar");
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
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        var Count = 0;
        $('#MainContent_grvDetalleArticulo :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'hfCodDetalle');
            try {
                if (Number($(lblcoddetalle_grilla).val()) > 0)
                    Count++;    
            } catch (ex) {
    
            }
        });

        if (Count === 0)
            Cadena=Cadena + '<p></p>' + 'DEBE AGREGARSE AL MENOS UN ARTICULO';

        if ($(Cuerpo + 'txtObservacion').val().trim()=='')
            Cadena=Cadena + '<p></p>' + 'OBSERVACION';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_GrabarDocumento() {

    try {

        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_CodTasa: $('#MainContent_ddlIgv').val() ,
            Filtro_TasaIgv: tasaigv,
            Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
            Filtro_Observacion: $('#MainContent_txtObservacion').val()
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
                if (str_mensaje_operacion == "Se Grabo Correctamente.") {
                    toastr.success('Se grabo correctamente');
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);             
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $('#MainContent_txtObservacion').val('');
                }
                else {
                    toastr.warning(str_mensaje_operacion);
                    return false;
                }

            }
            else {
                toastr.warning(result.split('~')[1]);
                return false;
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
    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#hfCodTraslado').val('0');
    $('#hfCodProforma').val('0');
    $('#hfCodDepartamento').val('0');
    $('#hfCodProvincia').val('0');
    $('#hfCodDistrito').val('0');
    $('#hfCodCtaCte').val('0');
    $('#MainContent_ddlMoneda').val('1');
    $('#MainContent_ddlFormaPago').val('1');
    $('#MainContent_ddlSerie').val('1');
    $('#hfCodigoTemporal').val('0');

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = dd + '/' + mm + '/' + yyyy;

    $('#MainContent_txtEmision').val(today);
    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtPlaca').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtSubTotal').val('0.00');
    $('#MainContent_txtIgv').val('0.00');
    $('#MainContent_txtTotal').val('0.00');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_chkGuia').prop('checked', false);
    $('#MainContent_chkServicios').prop('checked', false);
    $('#MainContent_chkNotaPedido').prop('checked', false);
    $('#MainContent_chkImpresion').prop('checked', true);
    $('#MainContent_txtNroRuc').val('');
    $('#MainContent_txtCliente').focus();

    try {
        var objParams = {
            Filtro_CodSerie: '1',
            Filtro_CodSerieGuia: '4'

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

                $('#MainContent_txtNumero').val(result.split('~')[3]);
                $('#MainContent_txtNumeroGuia').val(result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblPrecio"));

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);

                $('.ccsestilo').css('background', '#FFFFE0');
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

    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        var objParams = {
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_ChkFecha: chkFecha
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
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblCodigo')); 
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

function esnumero(campo) { return (!(isNaN(campo))); }

function F_VisualizarExcel_Grilla(Fila) {
    var lblCodigo = '#' + Fila.replace('imgExcel', 'lblCodigo');

    F_VisualizarExcel($(lblCodigo).text());
return true;
}

function F_VisualizarExcel(Codigo) {

    if (Codigo == 0)
        return false;

    var Cuerpo = '#MainContent_';
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodMenu = '3';

    rptURL = '../Reportes/ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;

    return false;
}

function F_ReemplazarFactura(Fila) {

    var Fila = '#' + Fila;
    var lblCodTemporal = Fila.replace('imgReemplazar', 'lblCodigo');
    var hfFechaEmision = Fila.replace('imgReemplazar', 'hfFechaEmision');

    var objParams = {
        Filtro_Codigo: $(lblCodTemporal).text(),
        Filtro_Igv: '1',
        Filtro_CodMoneda: '1',
        Filtro_Tasa: '1',
        Filtro_TasaIgv: '1'
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);

    F_ConsultarTemporal_NET(arg, function (result) {

        MostrarEspera(false);

        var str_resultado_operacion = "";
        var str_mensaje_operacion = "";

        str_resultado_operacion = result.split('~')[0];
        str_mensaje_operacion = result.split('~')[1];

        if (str_resultado_operacion == "1") {
            $('#hfCodigoTemporal').val($(lblCodTemporal).text());
            $('#MainContent_txtEmision').val($(hfFechaEmision).val());
            F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
//            if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
            //                toastr.warning('Los Producto(s) se han agregado con exito');

            $("#divTabs").tabs("option", "active", $("#liRegistro").index());

        }
        else {
            toastr.warning(result.split('~')[2]);
        }

        return false;

    });

    
    return true;
}

function F_AnularRegistro(Fila) {
    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
        var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'hfUsuario');

        if (!confirm("ESTA SEGURO DE ELIMINAR LISTA DEL USUARIO " + $(lblcliente_grilla).val()))
            return false;


        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        var objParams = {
            Filtro_Codigo: $(lblCodigo).text(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_ChkFecha: chkFecha,
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AnularTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblCodigo')); 
                //                toastr.warning(result.split('~')[1]);
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
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}


function F_Sincronizar(Fila) {

    var Fila = '#' + Fila;
    var lblCodTemporal = Fila.replace('imgRefresh', 'lblCodigo');
    var hfFechaEmision = Fila.replace('imgRefresh', 'hfFechaEmision');
    var lblEstado = Fila.replace('imgRefresh', 'lblEstado');

//    if ($(lblEstado).text() != 'PENDIENTE') {
//        toastr.warning('NO SE PUEDE SINCRONIZAR PORQUE DEBE ESTAR PENDIENTE, TENER AL MENOS UNA SUCURSAL FALTANTE');
//        return false;
//    }


    var objParams = {
        Filtro_Codigo: $(lblCodTemporal).text()
    };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Sincronizar_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                toastr.warning('LA SINCRONIZACION PUEDE TARDAR UN PAR DE MINUTOS PARA LLEGAR A TODOS LOS ALMACENES');
                F_Buscar();
            }
            else {
                toastr.warning(result.split('~')[1]);
                return false;
            }

            return false;

        });


    return true;
}