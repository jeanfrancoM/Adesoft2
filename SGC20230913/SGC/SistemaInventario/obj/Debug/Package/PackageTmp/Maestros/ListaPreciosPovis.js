var AppSession = "../Maestros/ListaPreciosPovis.aspx";
var CodigoMenu = 1000;
var CodigoInterno = 13;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar_Productos()
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
        return false;
    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac

        try {
            if (!F_ValidarAgregar())
                return false;

            if (!confirm("ESTA SEGURO DE GRABAR"))
                return false;

            F_AgregarTemporal();

            $('#MainContent_txtArticulo').focus();
            return false;
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnReporte').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 1001301, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac

        try {
            F_Reporte();

            return false;
        }
        catch (e) {
            alert("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {     
            if (!confirm("ESTA SEGURO DE GENERAR UNA NUEVA LISTA PRECIO"))
                return false;

            F_NuevoListaPrecio();

            $('#MainContent_txtArticulo').focus();
            return false;
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }
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

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    F_Controles_Inicializar();

    $("#MainContent_chkPrecioLista").change(function () {
        if (this.checked) {
            F_Buscar_Productos();
            return false;
        }
    });

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtMarca').css('background', '#FFFFE0');

    $('.ccsestilo').css('background', '#FFFFE0');

    $("#MainContent_txtM1").blur(function () {
        try {

            if ($('#MainContent_txtM1').val() == '') {
                $("#MainContent_txtPrecioLista1").val('');
                return false
            }

         



            if ($('#MainContent_txtCosto').val() == '') {
                var cadena = "Ingrese costo"
                $("#MainContent_txtPrecio1").val('');
                toastr.warning(cadena);
                return false;
            } else {
                if (($('#MainContent_txtM1').val() < $('#MainContent_txtM3').val()) && ($('#MainContent_txtM1').val() < $('#MainContent_txtM2').val())) {
                    toastr.warning("MARGEN 3 Y MARGEN 2 NO PUEDE SER MAYOR A MARGEN 1");
                    $("#MainContent_txtPrecioLista3").val('');
                    $("#MainContent_txtPrecioLista2").val('');
                    return false
                }

                if ($('#MainContent_txtM1').val() < $('#MainContent_txtM3').val()) {
                    toastr.warning("MARGEN 3 NO PUEDE SER MAYOR A MARGEN 1");
                    $("#MainContent_txtPrecioLista3").val('');
                    return false
                }

                if ($('#MainContent_txtM1').val() < $('#MainContent_txtM2').val()) {
                    toastr.warning("MARGEN 2 NO PUEDE SER MAYOR A MARGEN 2");
                    $("#MainContent_txtPrecioLista2").val('');
                    return false
                }
            }

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtxtM2").blur(function () {
        try {

            if ($('#MainContent_txtMargen2').val() == '') {
                $("#MainContent_txtPrecio2").val('');
                return false
            }


            if ($('#MainContent_txtCosto').val() == '') {
                var cadena = "Ingrese costo"
                $("#MainContent_txtPrecio2").val('');
                toastr.warning(cadena);
                return false;
            } else {
                var Margen2 = ($('#MainContent_txtMargen2').val() / 100) + 1

                $("#MainContent_txtPrecio2").val($("#MainContent_txtCosto").val() * Margen2);
            }

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtM3").blur(function () {
        try {

            if ($('#MainContent_txtMargen3').val() == '') {
                $("#MainContent_txtPrecio3").val('');
                return false
            }


            if ($('#MainContent_txtCosto').val() == '') {
                var cadena = "Ingrese costo"
                $("#MainContent_txtPrecio3").val('');
                toastr.warning(cadena);
                return false;
            } else {
                var Margen3 = ($('#MainContent_txtMargen3').val() / 100) + 1

                $("#MainContent_txtPrecio3").val($("#MainContent_txtCosto").val() * Margen3);
            }

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

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
        var objParams = {
            Filtro_CodFamilia: '001'
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
                        F_Update_Division_HTML('div_Familia', result.split('~')[2]);
                        F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[3]);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');              
                        $('#hfCodUsuario').val(result.split('~')[4]);
                        $('#hfCodSede').val(result.split('~')[5]);
                        var hfCodMoneda = '';
                        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                            var chkSi = '#' + this.id;
                            hfCodMoneda = chkSi.replace('chkOK', 'hfCodMoneda');
                            ddlMoneda = chkSi.replace('chkOK', 'ddlMoneda');
                            $(ddlMoneda).val($(hfCodMoneda).val());
                        });
                        $('.ccsestilo').css('background', '#FFFFE0');
                        return false;
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                        return false;
                    }
                }
            );
    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_Buscar_Productos() {
    var arg;
    var Marca = 0;

    if ($('#MainContent_chkMarca').is(':checked')) 
            Marca  = 1;
        
    try {
        var objParams =
            {
                Filtro_IdFamilia: $('#MainContent_ddlFamilia').val(),
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_chkMarca: Marca,
                Filtro_Marca: $('#hfCodMarca').val()
            };
            
            var ddlMoneda = '';

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
                        $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsultaArticulo", 'lblstock'));
                        var hfCodMoneda = '';
                        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                            var chkSi = '#' + this.id;
                            hfCodMoneda = chkSi.replace('chkOK', 'hfCodMoneda');
                            ddlMoneda = chkSi.replace('chkOK', 'ddlMoneda');                            
                            $(ddlMoneda).val($(hfCodMoneda).val());
                            
                        });
                        $('.ccsestilo').css('background', '#FFFFE0');
                        if (str_mensaje_operacion == 'No se encontraron registros')
                            toastr.warning(str_mensaje_operacion);
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
        //        if ($('#hfCodUsuario').val() != '6' & $('#hfCodUsuario').val() != '11') {
        //            toastr.warning("Permiso denegado");
        //            return false;
        //        }
        var cadena = "Ingrese los sgtes. campos: ";

        var x = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;
            var txtCostoMarginable = chkSi.replace('chkOK', 'txtCostoMarginable');
            var txtCosto = chkSi.replace('chkOK', 'txtCosto');
            var txtPrecioLista = chkSi.replace('chkOK', 'txtPrecioLista');
            var txtCodigoProducto = chkSi.replace('chkOK', 'txtCodigoProducto');
            var txtPrecioLista1 = chkSi.replace('chkOK', 'txtPrecioLista1');
            var txtPrecioLista2 = chkSi.replace('chkOK', 'txtPrecioLista2');
            var txtPrecioLista3 = chkSi.replace('chkOK', 'txtPrecioLista3');
            var txtM1 = chkSi.replace('chkOK', 'txtM1');
            var txtM2 = chkSi.replace('chkOK', 'txtM2');
            var txtM3 = chkSi.replace('chkOK', 'txtM3');


            if ($(chkSi).is(':checked')) {

                if ($(txtCostoMarginable).val() == '0.00')
                    cadena = cadena + "\n" + "Costo Marginable " + $(txtCostoMarginable).text();
                if ($(txtCosto).val() == '0.00')
                    cadena = cadena + "\n" + "Costo Real " + $(txtCosto).text();
                if ($(txtPrecioLista1).val() == '0.00')
                    cadena = cadena + "\n" + "Precio Calle " + $(txtCodigoProducto).text();

                if ($(txtPrecioLista2).val() == '0.00')
                    cadena = cadena + "\n" + "Precio Minorista " + $(txtCodigoProducto).text();

                if ($(txtPrecioLista3).val() == '0.00')
                    cadena = cadena + "\n" + "Precio Minimo " + $(txtCodigoProducto).text();

                if ($(txtM1).val() == '0.00')
                    cadena = cadena + "\n" + "Precio %P.C. " + $(txtCodigoProducto).text();

                if ($(txtM2).val() == '0.00')
                    cadena = cadena + "\n" + "Precio %P.F. " + $(txtCodigoProducto).text();

                if ($(txtM3).val() == '0.00')
                    cadena = cadena + "\n" + "Precio %P.MIN. " + $(txtCodigoProducto).text();


                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            toastr.warning(cadena);
            return false;
        }
        return true;
    }
    catch (e) 
    {
        toastr.warning("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {
    try {
        var arrDetalle = new Array();
        var hfCodProducto = '';
        var hfCodAlterno = '';
        var txtCosto = '';
        var txtMargen = '';
        var txtDescuento = '';
        var txtPrecioLista1 = '';
        var txtPrecioLista2 = '';
        var txtPrecioLista3 = '';
        var ddlEstado = '';
        var txtDescripcion = '';
        var txtMarca = '';
        var txtModelo = '';
        var txtMedida = '';
        var txtPosicion = '';
        var txtAño = '';
        var txtDescripcionIngles = '';
        var ddlMonedaLista = '1';
        var Flag = 0;

        if ($('#MainContent_chkPrecioLista').is(':checked'))
            Flag = 1;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;

            hfCodProducto = chkSi.replace('chkOK', 'hfCodProducto');
            hfCodAlterno = chkSi.replace('chkOK', 'hfCodAlterno');
            lblCostoReal = chkSi.replace('chkOK', 'txtCosto');
            lblCostoOriginal = chkSi.replace('chkOK', 'txtCostoMarginable');
            txtMargen = chkSi.replace('chkOK', 'txtMargen');
            txtDescuento = chkSi.replace('chkOK', 'txtDescuento');
            txtPrecioLista1 = chkSi.replace('chkOK', 'txtPrecioLista1');
            txtPrecioLista2 = chkSi.replace('chkOK', 'txtPrecioLista2');
            txtPrecioLista3 = chkSi.replace('chkOK', 'txtPrecioLista3');
            txtM1 = chkSi.replace('chkOK', 'txtM1');
            txtM2 = chkSi.replace('chkOK', 'txtM2');
            txtM3 = chkSi.replace('chkOK', 'txtM3');
            ddlEstado = chkSi.replace('chkOK', 'ddlEstado');
            txtDescripcion = chkSi.replace('chkOK', 'txtDescripcion');
            txtMarca = chkSi.replace('chkOK', 'txtMarca');
            txtModelo = chkSi.replace('chkOK', 'txtModelo');
            txtMedida = chkSi.replace('chkOK', 'txtMedida');
            txtPosicion = chkSi.replace('chkOK', 'txtPosicion');
            txtAño = chkSi.replace('chkOK', 'txtAño');
            txtDescripcionIngles = chkSi.replace('chkOK', 'txtDescripcionIngles');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodProducto: $(hfCodProducto).val(),
                    Precio1: $(txtPrecioLista1).val(),
                    Precio2: $(txtPrecioLista2).val(),
                    Precio3: $(txtPrecioLista3).val(),
                    M1: $(txtM1).val(),
                    M2: $(txtM2).val(),
                    M3: $(txtM3).val(),
                    CodEstado: $(ddlEstado).val(),
                    CodMoneda: 1,
                    CReal: $(lblCostoReal).val(),
                    Costo: $(lblCostoOriginal).val()
                };
                arrDetalle.push(objDetalle);
            }
        });

        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_IdFamilia: $('#MainContent_ddlFamilia').val(),
            Filtro_FechaVigencia: $('#MainContent_txtEmision').val(),
            Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_Flag: Flag
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "Se Grabo Correctamente")
                F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);

            var hfCodMoneda = '';
            $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                var chkSi = '#' + this.id;
                hfCodMoneda = chkSi.replace('chkOK', 'hfCodMoneda');
                ddlMoneda = chkSi.replace('chkOK', 'ddlMoneda');
                $(ddlMoneda).val($(hfCodMoneda).val());
            });
            $('.ccsestilo').css('background', '#FFFFE0');
            toastr.warning(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
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

function F_ValidarCheck(ControlID) {
    
    var chkok_grilla = '#' + ControlID;;
    var cadena = 'Ingrese los sgtes. campos: '
    var txtCosto = chkok_grilla.replace('chkOK', 'txtCosto');
    var txtCostoMarginable = chkok_grilla.replace('chkOK', 'txtCostoMarginable');
    var txtDescuento = chkok_grilla.replace('chkOK', 'txtDescuento');
    var txtM1 = chkok_grilla.replace('chkOK', 'txtM1');
    var txtM2 = chkok_grilla.replace('chkOK', 'txtM2');
    var txtM3 = chkok_grilla.replace('chkOK', 'txtM3');
    var txtPrecioLista1 = chkok_grilla.replace('chkOK', 'txtPrecioLista1');
    var txtPrecioLista2 = chkok_grilla.replace('chkOK', 'txtPrecioLista2');
    var txtPrecioLista3 = chkok_grilla.replace('chkOK', 'txtPrecioLista3');
    var txtPrecioLista4 = chkok_grilla.replace('chkOK', 'txtPrecioLista4');
    var lblCostoOriginal = chkok_grilla.replace('chkOK', 'lblCostoOriginal');
    var txtDescripcion = chkok_grilla.replace('chkOK', 'txtDescripcion');
    var txtMarca = chkok_grilla.replace('chkOK', 'txtMarca');
    var txtModelo = chkok_grilla.replace('chkOK', 'txtModelo');
    var txtMedida = chkok_grilla.replace('chkOK', 'txtMedida');
    var txtAño = chkok_grilla.replace('chkOK', 'txtAño');
    var txtPosicion = chkok_grilla.replace('chkOK', 'txtPosicion');
    var txtCodigoProducto = chkok_grilla.replace('chkOK', 'txtCodigoProducto');

    if ($(chkok_grilla).is(':checked')) 
    {
        $(txtCosto).prop('disabled', false);
        $(txtCostoMarginable).prop('disabled', false);
        $(txtM1).prop('disabled', false);
        $(txtM2).prop('disabled', false);
        $(txtM3).prop('disabled', false);
        $(txtDescuento).prop('disabled', false);
//        $(txtPrecioLista1).prop('disabled', false);
//        $(txtPrecioLista2).prop('disabled', false);
//        $(txtPrecioLista3).prop('disabled', false);
        $(txtPrecioLista4).prop('disabled', false);
        $(lblCostoOriginal).prop('disabled', false);
        $(txtDescripcion).prop('disabled', false);
        $(txtMarca).prop('disabled', false);
        $(txtModelo).prop('disabled', false);
        $(txtMedida).prop('disabled', false);
        $(txtAño).prop('disabled', false);
        $(txtPosicion).prop('disabled', false);
        $(txtCodigoProducto).prop('disabled', false);
//        $(txtPrecioLista).select();
    }
    else 
    {
        $(txtCosto).prop('disabled', true);
        $(txtCostoMarginable).prop('disabled', false);
        $(txtM1).prop('disabled', false);
        $(txtM2).prop('disabled', false);
        $(txtM3).prop('disabled', false);
        $(txtDescuento).prop('disabled', true);
        $(txtPrecioLista1).prop('disabled', true);
        $(txtPrecioLista2).prop('disabled', true);
        $(txtPrecioLista3).prop('disabled', true);
        $(txtPrecioLista4).prop('disabled', true);
        $(lblCostoOriginal).prop('disabled', true);
        $(txtDescripcion).prop('disabled', true);
        $(txtMarca).prop('disabled', true);
        $(txtModelo).prop('disabled', true);
        $(txtMedida).prop('disabled', true);
        $(txtAño).prop('disabled', true);
        $(txtPosicion).prop('disabled', true);
        $(txtCodigoProducto).prop('disabled', true);
    }
    return true;
}

function F_Costo(ControlID) 
{
    var lblCostoOriginal = '#' + ControlID;
    var hfCostoOriginal = lblCostoOriginal.replace('lblCostoOriginal', 'hfCostoOriginal');

    if ($(lblCostoOriginal).val() == '' | $(lblCostoOriginal).val() == '0.00') {
        $(lblCostoOriginal).val($(hfCostoOriginal).val());
        return false;
    }

    var txtMargen = txtCosto.replace('txtCosto', 'txtMargen');
    var txtPrecio = txtCosto.replace('txtCosto', 'txtPrecio');

    if ($(txtPrecio).val() != '0.00' & $(txtMargen).val() != '0.00')
        $(txtPrecio).val(parseFloat((($(txtMargen).val() / 100) + 1) * $(txtCosto).val()).toFixed(2));

    return false;
}

function F_Precio(ControlID) {

    var txtPrecio = '#' + ControlID;
    var hfPrecio = txtPrecio.replace('txtPrecio', 'hfPrecio');

    if ($(txtPrecio).val() == '' | $(txtPrecio).val() == '0.00') {
        $(txtPrecio).val($(hfPrecio).val());
        return false;
    }

    return false;
}

function F_Descuento(ControlID) {

    var txtDescuento = '#' + ControlID;
    var hfDescuento = txtDescuento.replace('txtDescuento', 'hfDescuento');

    if ($(txtDescuento).val() == '' | $(txtDescuento).val() == '0.00') {
        $(txtDescuento).val($(hfDescuento).val());
        return false;
    }

    return false;
}

function F_Margen1(ControlID) {

    var txtMargen = '#' + ControlID;
    var hfMargen = txtMargen.replace('txtM1', 'hfMargen');
    var hfCostoOriginal = txtMargen.replace('txtM1', 'txtCostoMarginable');

    

    var txtPrecio = txtMargen.replace('txtM1', 'txtPrecioLista1');
    var HFM1 = txtMargen.replace('txtM1', 'HFM1');
    var txtM2 = txtMargen.replace('txtM1', 'txtM2');
    var txtM3 = txtMargen.replace('txtM1', 'txtM3');
    var lblCostoOriginal = txtMargen.replace('txtM1', 'lblCostoOriginal');

        var Margen=parseFloat($(txtMargen).val())

        var Precio = ((parseFloat($(txtMargen).val()) / 100) + 1) * parseFloat($(hfCostoOriginal).val());
        var Margen = (parseFloat($(txtMargen).val()))

        if ($(hfCostoOriginal).val() == '' | $(hfCostoOriginal).val() == '0.00') {
            toastr.warning("No Tiene Costo de Producto");
            return false;
        }

        if ($(txtMargen).val() == '' | $(txtMargen).val() == '0.00') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM1).val());
            return false;
        }

        if (parseFloat($(txtMargen).val()) == '' ) {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM1).val());
            return false
        }


        if (parseFloat($(txtMargen).val()) == 0) {
            toastr.warning("EL MARGEN NO PUEDE SER 0");
            $(txtMargen).val($(HFM1).val());
            return false
        }


        if ((parseFloat($(txtMargen).val()) < parseFloat($(txtM3).val())) && (parseFloat($(txtMargen).val()) < parseFloat($(txtM2).val()))) {
            toastr.warning("%P.MIN. Y MARGEN 2 NO PUEDE SER MAYOR A %P.C.");
            $(txtMargen).val($(HFM1).val());
            return false
        }

        if (parseFloat($(txtMargen).val()) < parseFloat($(txtM3).val())) {
            toastr.warning("%P.MIN. NO PUEDE SER MAYOR A %P.C.");
            $(txtMargen).val($(HFM1).val());
            return false
        }

        if (parseFloat($(txtMargen).val()) < parseFloat($(txtM2).val())) {
            toastr.warning("%P.F. NO PUEDE SER MAYOR A %P.C.");
            $(txtMargen).val($(HFM1).val());
            return false
        }
        
    $(txtPrecio).val(Number(roundNumber(Precio,1,false)).toFixed(2));
    $(txtMargen).val(Margen.toFixed(2));

    return false;
}


function roundNumber(number, precision, isDown) {
    var factor = Math.pow(10, precision);
    var tempNumber = number * factor;
    var roundedTempNumber = 0;
    if (isDown) {
        tempNumber = -tempNumber;
        roundedTempNumber = Math.round(tempNumber) * -1;
    } else {
        roundedTempNumber = Math.round(tempNumber);
    }
    return roundedTempNumber / factor;
}
function F_Reporte() {
    var Cuerpo = '#MainContent_';
    var Cadena = 'Ingresar los sgtes. Datos:';
    var Titulo = 'REPORTE LISTA DE PRECIOS';
    var NombreTabla = 'ListaPreciosPovis';
    var Marca = 0;
     if ($('#MainContent_chkMarca').is(':checked')) 
            Marca  = 1;
     var NombreArchivo = 'Xls_ListadoPrecioPovis.xlsx';
     var NombreHoja = 'Listado';
    if (Cadena != 'Ingresar los sgtes. Datos:') {
        alert(Cadena);
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = 709;

    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
    rptURL = rptURL + 'NombreHoja=' + NombreHoja + '&';
    rptURL = rptURL + 'IdFamilia=' + $('#MainContent_ddlFamilia').val() + '&';
    rptURL = rptURL + 'DscProducto=' + $('#MainContent_txtArticulo').val() + '&';
    rptURL = rptURL + 'CodMarca=' + $('#hfCodMarca').val() + '&';
    rptURL = rptURL + 'Marca=' + Marca + '&';
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_NuevoListaPrecio() {
    try {

        var objParams = {       
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_NuevoListaPrecio_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            $('.ccsestilo').css('background', '#FFFFE0');
            toastr.warning(result.split('~')[1]);

            return false;
        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
    }
}

function F_Margen2(ControlID) {

    var txtMargen = '#' + ControlID;
    var hfMargen = txtMargen.replace('txtM2', 'hfMargen');

    

    var HFM2 = txtMargen.replace('txtM2', 'HFM2');
    var txtM1 = txtMargen.replace('txtM2', 'txtM1');
    var txtM3 = txtMargen.replace('txtM2', 'txtM3');
    var hfCostoOriginal = txtMargen.replace('txtM2', 'txtCostoMarginable');

    


    var txtPrecio = txtMargen.replace('txtM2', 'txtPrecioLista2');
    var lblCostoOriginal = txtMargen.replace('txtM2', 'lblCostoOrigina2');

    
        var Margen = parseFloat($(txtMargen).val())

        var Precio = ((parseFloat($(txtMargen).val()) / 100) + 1) * parseFloat($(hfCostoOriginal).val());

        if ($(hfCostoOriginal).val() == '' | $(hfCostoOriginal).val() == '0.00') {
            toastr.warning("No Tiene Costo de Producto");
            return false;
        }

        if ($(txtMargen).val() == '' | $(txtMargen).val() == '0.00') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM2).val());
            return false;
        }

        if (parseFloat($(txtMargen).val()) == '') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM2).val());
            return false
        }


        if (parseFloat($(txtMargen).val()) == '') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM2).val());
            return false
        }


        if (parseFloat($(txtMargen).val()) == 0) {
            toastr.warning("EL MARGEN NO PUEDE SER 0");
            $(txtMargen).val($(HFM2).val());
            return false
        }

        if (parseFloat($(txtMargen).val()) == 0) {
            toastr.warning("EL MARGEN NO PUEDE SER 0");
            $(txtMargen).val($(HFM2).val());
            return false
        }

        if (parseFloat($(txtM1).val()) < parseFloat($(txtMargen).val())) {
            toastr.warning("%P.F. NO PUEDE SER MAYOR A MARGEN %P.C");
            $(txtMargen).val($(HFM2).val());
            return false
        }

        if (parseFloat($(txtMargen).val()) < parseFloat($(txtM3).val())) {
            toastr.warning("%P.MIN. NO PUEDE SER MAYOR A %P.F.");
            $(txtMargen).val($(HFM2).val());
            return false
        }
        
//    Precio = (parseFloat(Precio * 2).toFixed(0)) / 2;
//    $(txtPrecio).val(Precio.toFixed(2));
//    $(txtMargen).val(Margen.toFixed(2));

    $(txtPrecio).val(Number(roundNumber(Precio, 1, false)).toFixed(2));
    $(txtMargen).val(Margen.toFixed(2));
    return false;
}

function F_Margen3(ControlID) {

    var txtMargen = '#' + ControlID;
    var hfMargen = txtMargen.replace('txtM3', 'hfMargen');



    var HFM3 = txtMargen.replace('txtM3', 'HFM3');
    var txtM1 = txtMargen.replace('txtM3', 'txtM1');
    var txtM2 = txtMargen.replace('txtM3', 'txtM2');
    var hfCostoOriginal = txtMargen.replace('txtM3', 'txtCostoMarginable');

    var txtPrecio = txtMargen.replace('txtM3', 'txtPrecioLista3');
    var lblCostoOriginal = txtMargen.replace('txtM3', 'lblCostoOriginal');

    
        var Margen = parseFloat($(txtMargen).val())

        var Precio = ((parseFloat($(txtMargen).val()) / 100) + 1) * parseFloat($(hfCostoOriginal).val());

        if ($(hfCostoOriginal).val() == '' | $(hfCostoOriginal).val() == '0.00') {
            toastr.warning("No Tiene Costo de Producto");
            return false;
        }

        if ($(txtMargen).val() == '' | $(txtMargen).val() == '0.00') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM3).val());
            return false;
        }

        if (parseFloat($(txtMargen).val()) == '') {
            toastr.warning("EL MARGEN NO PUEDE ESTAR EN VACIO");
            $(txtMargen).val($(HFM3).val());
            return false
        }


        if (parseFloat($(txtMargen).val()) == 0) {
            toastr.warning("EL MARGEN NO PUEDE SER 0");
            $(txtMargen).val($(HFM3).val());
            return false
        }

        if ((parseFloat($(txtM1).val()) < parseFloat($(txtMargen).val())) && (parseFloat($(txtM2).val()) < parseFloat($(txtMargen).val()))) {
            toastr.warning("%P.MIN. NO PUEDE SER MAYOR A %P.C. NI AL %P.F.");
            $(txtMargen).val($(HFM3).val());
            return false
        }

        if (parseFloat($(txtM1).val()) < parseFloat($(txtMargen).val())) {
            toastr.warning("%P.MIN. NO PUEDE SER MAYOR A %P.C.");
            $(txtMargen).val($(HFM3).val());
            return false
        }

        if (parseFloat($(txtM2).val()) < parseFloat($(txtMargen).val())) {
            toastr.warning("%P.MIN. NO PUEDE SER MAYOR A %P.F.");
            $(txtMargen).val($(HFM3).val());
            
            return false
        }
       
//    Precio = (parseFloat(Precio * 2).toFixed(0)) / 2;
//    $(txtPrecio).val(Precio.toFixed(2));
        //    $(txtMargen).val(Margen.toFixed(2));

        $(txtPrecio).val(Number(roundNumber(Precio, 1, false)).toFixed(2));
        $(txtMargen).val(Margen.toFixed(2));

    return false;
}

function F_COSTOMarginable(ControlID) {

    var txtCosto = '#' + ControlID;
    var hfCosto = txtCosto.replace('txtCostoMarginable', 'hfCosto');



    var hfCosto = txtCosto.replace('txtCostoMarginable', 'hfCosto');
    var txtM1 = txtCosto.replace('txtCostoMarginable', 'txtM1');
    var txtM2 = txtCosto.replace('txtCostoMarginable', 'txtM2');
    var txtM3 = txtCosto.replace('txtCostoMarginable', 'txtM3');
    var hfCostoOriginal = txtCosto.replace('txtCostoMarginable', 'hfCosto');

    var txtPrecio1 = txtCosto.replace('txtCostoMarginable', 'txtPrecioLista1');
    var txtPrecio2 = txtCosto.replace('txtCostoMarginable', 'txtPrecioLista2');
    var txtPrecio3 = txtCosto.replace('txtCostoMarginable', 'txtPrecioLista3');
    var lblCostoOriginal = txtCosto.replace('txtCostoMarginable', 'lblCostoOriginal');


    var Costo = parseFloat($(txtCosto).val())





    if ($(txtCosto).val() == '' | $(txtCosto).val() == '0.00') {
        toastr.warning("EL COSTO NO PUEDE ESTAR EN VACIO");
        $(txtCosto).val($(hfCosto).val());
        return false;
    }

    if (parseFloat($(txtCosto).val()) == '') {
        toastr.warning("EL COSTO NO PUEDE ESTAR EN VACIO");
        $(txtCosto).val($(hfCosto).val());
        return false
    }


    if (parseFloat($(txtCosto).val()) == 0) {
        toastr.warning("EL COSTO NO PUEDE SER 0");
        $(txtCosto).val($(hfCosto).val());
        return false
    }

    if ($(txtM1).val()!=''){
        var Precio1 = ((parseFloat($(txtM1).val()) / 100) + 1) * parseFloat($(txtCosto).val());
    $(txtPrecio1).val(Precio1.toFixed(2));
    }

    if ($(txtM2).val()!=''){
        var Precio2 = ((parseFloat($(txtM2).val()) / 100) + 1) * parseFloat($(txtCosto).val());
    $(txtPrecio2).val(Precio2.toFixed(2));
    }

if ($(txtM2).val() != '') {
    var Precio3 = ((parseFloat($(txtM3).val()) / 100) + 1) * parseFloat($(txtCosto).val());
    $(txtPrecio3).val(Precio3.toFixed(2));
    }

    
    
   

    return false;
}

function F_COSTO(ControlID) {

    var txtCosto = '#' + ControlID;
    var hfCostoUniOriginal = txtCosto.replace('txtCosto', 'hfCostoUniOriginal');



    var hfCosto = txtCosto.replace('txtCosto', 'hfCosto');
    var txtM1 = txtCosto.replace('txtCosto', 'txtM1');
    var txtM2 = txtCosto.replace('txtCosto', 'txtM2');
    var txtM3 = txtCosto.replace('txtCosto', 'txtM3');
    var hfCostoOriginal = txtCosto.replace('txtCosto', 'hfCosto');

    var txtPrecio1 = txtCosto.replace('txtCosto', 'txtPrecioLista1');
    var txtPrecio2 = txtCosto.replace('txtCosto', 'txtPrecioLista2');
    var txtPrecio3 = txtCosto.replace('txtCosto', 'txtPrecioLista3');
    var lblCostoOriginal = txtCosto.replace('txtCosto', 'lblCostoOriginal');


    var Costo = parseFloat($(txtCosto).val())





    if ($(txtCosto).val() == '' | $(txtCosto).val() == '0.00') {
        toastr.warning("EL COSTO NO PUEDE ESTAR EN VACIO");
        $(txtCosto).val($(hfCostoUniOriginal).val());
        return false;
    }

    if (parseFloat($(txtCosto).val()) == '') {
        toastr.warning("EL COSTO NO PUEDE ESTAR EN VACIO");
        $(txtCosto).val($(hfCostoUniOriginal).val());
        return false
    }


    if (parseFloat($(txtCosto).val()) == 0) {
        toastr.warning("EL COSTO NO PUEDE SER 0");
        $(txtCosto).val($(hfCostoUniOriginal).val());
        return false
    }

   





    return false;
}
