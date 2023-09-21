var AppSession = "../Reportes/Ventas_Reporte_Placa.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('#MainContent_txtCliente').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            DireccionEnvio: item.split(',')[3],
                            Distrito: item.split(',')[4],
                            CodDepartamento: item.split(',')[5],
                            CodProvincia: item.split(',')[6],
                            CodDistrito: item.split(',')[7],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1]
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

    $('#MainContent_txtCliente').blur(function () {
        try {
            if ($.trim($('#MainContent_txtCliente').val()) == '') {
                $('#hfCodCtaCte').val('0');
                return false;
            }
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
        return false;
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

    $('#MainContent_txtHasta').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }
    });

    $('#MainContent_txtHasta').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

    $('#MainContent_btnReporte').click(function () {
        var AppSession = "../Reportes/HistorialCobranzas.aspx";
        try {
            F_Reporte('R');

            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnExcel').click(function () {
        var AppSession = "../Reportes/HistorialCobranzas.aspx";
        try {
            F_Reporte('E');

            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
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

    $('#MainContent_txtPlaca').css('background', '#FFFFE0');

    F_Controles_Inicializar();
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

$(document).on("change", "select[id $= 'MainContent_ddlTipoDocumento']", function () {

    F_Mostrar_Serie($('#MainContent_ddlTipoDocumento').val());

});

function F_Reporte(Tipo) {
    var Cuerpo = '#MainContent_';
    var Cadena = 'Ingresar los sgtes. Datos:';

    if ($(Cuerpo + 'txtPlaca').val() == '')
        Cadena = Cadena + '<p></p>' + 'Hasta';

    if ($(Cuerpo + 'txtDesde').val() == '')
        Cadena = Cadena + '<p></p>' + 'Desde';

    if ($(Cuerpo + 'txtHasta').val() == '')
        Cadena = Cadena + '<p></p>' + 'Hasta';

    if (Cadena != 'Ingresar los sgtes. Datos:') {
        alertify.log(Cadena);
        return false;
    }

    var rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = 214;
    var Titulo = "REPORTE DE PLACA";
    var SubTitulo = "DESDE " + $("#MainContent_txtDesde").val() + " HASTA " + $('#MainContent_txtHasta').val();
    var NombreTabla = "ReportePlaca";
    var NombreArchivo = "Web_Reporte_Ventas_rptReportePlaca.rpt";

    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Desde=' + $('#MainContent_txtDesde').val() + '&';
    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';
    rptURL = rptURL + 'Placa=' + $('#MainContent_txtPlaca').val() + '&';
    rptURL = rptURL + 'CodCliente=' + $('#hfCodCtaCte').val() + '&';
    rptURL = rptURL + 'CodAlmacen=' + $('#MainContent_ddlSucursal').val() + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'SubTitulo=' + SubTitulo + '&';
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

function F_Controles_Inicializar() {
    var arg;

    try {
        var objParams =
            {
                Filtro_CodDoc: 3,
                Filtro_CodCargo: 6,
                Filtro_CodEstado: 1,
                Filtro_CodEstadoAlmacen: 1
            };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_tipodocumento', result.split('~')[2]);
                        F_Update_Division_HTML('div_serie', result.split('~')[3]);
                        F_Update_Division_HTML('div_Empresa', result.split('~')[4]);
                        F_Update_Division_HTML('div_Vendedor', result.split('~')[5]);
                        F_Update_Division_HTML('div_Sucursal', result.split('~')[6]);
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlVendedor').css('background', '#FFFFE0');
                        $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocumento').val(0);
                        $('#MainContent_ddlSerie').val(0);
                        $('#MainContent_ddlEmpresa').val(0);
                        $('#MainContent_ddlSucursal').val(0);
                    }
                    else {
                        alert(str_mensaje_operacion);
                    }
                }
            );

    } catch (mierror) {
        alert("Error detectado: " + mierror);
    }
}

function F_Mostrar_Serie(CodDoc) {

    var arg;

    try {

        var objParams = {
            Filtro_CodDoc: CodDoc
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Serie_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                    }

                    else
                        alertify.log(str_mensaje_operacion);
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Resumido(ControlID) {
    var chkok_grilla = '#' + ControlID;
    if ($(chkok_grilla).is(':checked')) {
        $('#MainContent_chkDetallado').prop('checked', false);
    }
    else {
        $('#MainContent_chkDetallado').prop('checked', true);
    }
}

function F_Detallado(ControlID) {
    var chkok_grilla = '#' + ControlID;
    if ($(chkok_grilla).is(':checked')) {
        $('#MainContent_chkResumido').prop('checked', false);
    }
    else {
        $('#MainContent_chkResumido').prop('checked', true);
    }
}

