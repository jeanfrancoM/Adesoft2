var AppSession = "../Inventario/NotaIngresoSalidaManual.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 11;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

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

    $('#MainContent_txtCliente').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + 0 + "'}",
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
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCte').val(i.item.val);

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

    $('#MainContent_btnEnvio').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Envio();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnExcel').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Excel();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });
    $('.MesAnioPicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'yymm',

        onClose: function (dateText, inst) {
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            $(this).val($.datepicker.formatDate('yymm', new Date(year, month, 1)));
        }
    });

    $('.MesAnioPicker').datepicker($.datepicker.regional['es']);

    $('.MesAnioPicker').focus(function () {
        $('.ui-datepicker-calendar').hide();
        $('#ui-datepicker-div').position({
            my: 'center top',
            at: 'center bottom',
            of: $(this)
        });
    });

    $('.MesAnioPicker').datepicker('setDate', new Date());

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtCliente').css('background', '#FFFFE0');

    $('.ccsestilo').css('background', '#FFFFE0');

    F_Controles_Inicializar();
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

function F_Controles_Inicializar() {
    var arg;

    try {
        var objParams =
            {
                Filtro_CodCargo: 6,
                Filtro_CodEstado: 1
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
                        F_Update_Division_HTML('div_Empresa', result.split('~')[2]);
                        $('#MainContent_ddlEmpresa').val(1);
                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + mierror);
    }
}

function F_Reporte() {
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = 5;
    var CodMenu = 207;
    var Titulo = "REPORTE VENTAS POR VENDEDOR";
    var SubTitulo = "DESDE " + $("#MainContent_txtDesde").val() + " HASTA " + $('#MainContent_txtHasta').val();
    var NombreTabla = "VentasXVendedor";
    var NombreArchivo = "Web_Reporte_Ventas_rptVentasXVendedor.rpt";

    rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'SubTitulo=' + SubTitulo + '&';
    rptURL = rptURL + 'CodAlmacen=' + $('#MainContent_ddlSucursal').val() + '&';
    rptURL = rptURL + 'Desde=' + $("#MainContent_txtDesde").val() + '&';
    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';
    rptURL = rptURL + 'CodEmpleado=' + $('#MainContent_ddlVendedor').val() + '&';
    rptURL = rptURL + 'CodMoneda=' + $('#MainContent_ddlMoneda').val() + '&';
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alertify.log'
        });

        $('.alertify.log div.ui-dialog-titlebar').hide();
        //        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}

function F_Envio() {
    //  if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Empresa: $('#MainContent_ddlEmpresa').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Envio_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                alertify.log(result.split('~')[1]);
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            $('#toolbar-options').toolbar({
                content: '#toolbar-options',
                position: 'bottom'
            });
            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_Excel() {
    var Marca = 0
    var Cliente = 0
    var Vendedor = 0
    if ($('#MainContent_chkMarca').is(':checked'))
        Marca = 1;

    if ($('#MainContent_ChkCliente').is(':checked'))
        Cliente = 1;

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = 5;
    var TipoArchivo = 'application/pdf';
    var CodMenu = '711';
    var Ruta = $('#MainContent_ddlRuta').val();
    var Vendedor = $('#MainContent_ddlVendedor').val();
    var NombreArchivo = 'Xls_ReportexMes.xlsx';
    var NombreHoja = 'Reporte';
    var Titulo = "Reporte de Ventas x Mes";

    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Ruta=' + Ruta + '&';
    rptURL = rptURL + 'Vendedor=' + Vendedor + '&';
    rptURL = rptURL + 'Desde=' + $('#MainContent_txtDesde').val() + '&';
    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';
    rptURL = rptURL + 'CodMarca=' + $('#hfCodMarca').val() + '&';
    rptURL = rptURL + 'chkCliente=' + Cliente + '&';
    rptURL = rptURL + 'Marca=' + Marca + '&';
    rptURL = rptURL + 'CodCliente=' + $('#hfCodCtaCte').val() + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
    rptURL = rptURL + 'NombreHoja=' + NombreHoja + '&';
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

