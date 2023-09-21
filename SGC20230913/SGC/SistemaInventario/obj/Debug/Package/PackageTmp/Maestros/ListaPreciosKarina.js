var AppSession = "../Maestros/ListaPreciosKarina.aspx";
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

    $('.ccsestilo').css('background', '#FFFFE0');

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
    var Flag = 0;

    if ($('#MainContent_chkPrecioLista').is(':checked'))
        Flag = 1;

    try {
        var objParams =
            {
                Filtro_IdFamilia: $('#MainContent_ddlFamilia').val(),
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_Flag: Flag
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
                        $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsultaArticulo", 'lblCostoOriginal'));
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
            var txtDscProducto = chkSi.replace('chkOK', 'txtDscProducto');
            var txtPrecioLista = chkSi.replace('chkOK', 'txtPrecioLista');
            var txtCodigoProducto = chkSi.replace('chkOK', 'txtCodigoProducto');

            if ($(chkSi).is(':checked')) {
                if ($(txtDscProducto).val() == '')
                    cadena = cadena + "\n" + "Descripcion para el codigo " + $(txtCodigoProducto).text();

                if ($(txtPrecioLista).val() == '')
                    cadena = cadena + "\n" + "Precio Lista " + $(txtCodigoProducto).text();

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
    catch (e) {
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
        var ddlMonedaLista = '';
        var Flag = 0;

        if ($('#MainContent_chkPrecioLista').is(':checked'))
            Flag = 1;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;

            hfCodProducto = chkSi.replace('chkOK', 'hfCodProducto');
            hfCodAlterno = chkSi.replace('chkOK', 'hfCodAlterno');
            lblCostoOriginal = chkSi.replace('chkOK', 'lblCostoOriginal');
            txtMargen = chkSi.replace('chkOK', 'txtMargen');
            txtDescuento = chkSi.replace('chkOK', 'txtDescuento');
            txtPrecioLista1 = chkSi.replace('chkOK', 'txtPrecioLista1');
            txtPrecioLista2 = chkSi.replace('chkOK', 'txtPrecioLista2');
            txtPrecioLista3 = chkSi.replace('chkOK', 'txtPrecioLista3');
            ddlEstado = chkSi.replace('chkOK', 'ddlEstado');
            ddlMonedaLista = chkSi.replace('chkOK', 'ddlMonedaLista');
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
                    CodEstado: $(ddlEstado).val(),
                    CodMoneda: $(ddlMonedaLista).val()
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

    var chkok_grilla = '#' + ControlID; ;
    var cadena = 'Ingrese los sgtes. campos: '
    var txtCosto = chkok_grilla.replace('chkOK', 'txtCosto');
    var txtDescuento = chkok_grilla.replace('chkOK', 'txtDescuento');
    var txtMargen = chkok_grilla.replace('chkOK', 'txtMargen');
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

    if ($(chkok_grilla).is(':checked')) {
        $(txtCosto).prop('disabled', false);
        $(txtMargen).prop('disabled', false);
        $(txtDescuento).prop('disabled', false);
        $(txtPrecioLista1).prop('disabled', false);
        $(txtPrecioLista2).prop('disabled', false);
        $(txtPrecioLista3).prop('disabled', false);
        $(txtPrecioLista4).prop('disabled', false);
        $(lblCostoOriginal).prop('disabled', false);
        $(txtDescripcion).prop('disabled', false);
        $(txtMarca).prop('disabled', false);
        $(txtModelo).prop('disabled', false);
        $(txtMedida).prop('disabled', false);
        $(txtAño).prop('disabled', false);
        $(txtPosicion).prop('disabled', false);
        $(txtCodigoProducto).prop('disabled', false);
        $(txtPrecioLista).select();
    }
    else {
        $(txtCosto).prop('disabled', true);
        $(txtMargen).prop('disabled', true);
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

function F_Costo(ControlID) {
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

function F_Margen(ControlID) {

    var txtMargen = '#' + ControlID;
    var hfMargen = txtMargen.replace('txtMargen', 'hfMargen');
    var hfCostoOriginal = txtMargen.replace('txtMargen', 'hfCostoOriginal');

    if ($(lblCostoOriginal).val() == '' | $(lblCostoOriginal).val() == '0.00') {
        $(lblCostoOriginal).val($(hfCostoOriginal).val());
        return false;
    }

    if ($(txtMargen).val() == '' | $(txtMargen).val() == '0.00') {
        $(txtMargen).val($(hfMargen).val());
        return false;
    }

    var txtPrecio = txtMargen.replace('txtMargen', 'txtPrecio');
    var lblCostoOriginal = txtMargen.replace('txtMargen', 'lblCostoOriginal');
    var Precio = ((parseFloat($(txtMargen).val()) / 100) + 1) * parseFloat($(lblCostoOriginal).val());

    Precio = (parseFloat(Precio * 2).toFixed(0)) / 2;
    $(txtPrecio).val(Precio.toFixed(2));

    return false;
}

function F_Reporte() {
    var Cuerpo = '#MainContent_';
    var Cadena = 'Ingresar los sgtes. Datos:';
    var Titulo = 'REPORTE LISTA DE PRECIOS';
    var NombreTabla = 'ListaPrecios';
    var NombreArchivo = '';
    if (Cadena != 'Ingresar los sgtes. Datos:') {
        alert(Cadena);
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = 403;

    rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
    rptURL = rptURL + 'IdFamilia=' + $('#MainContent_ddlFamilia').val() + '&';
    rptURL = rptURL + 'DscProducto=' + $('#MainContent_txtArticulo').val() + '&';
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