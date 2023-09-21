var AppSession = "../Reportes/CajaBanco_CuentaBancaria.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtCliente').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'0'}",
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
    
    $('#MainContent_btnReporte').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {           
            F_Reporte();
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

    F_Controles_Inicializar();

    F_Derecha();

    $('#MainContent_txtCliente').css('background', '#FFFFE0');
    $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');
});

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']", function () {
    F_ListarNroCuenta();
});

$(document).on("change", "select[id $= 'MainContent_ddlBanco']", function () {
    F_ListarNroCuenta();
});

function F_Controles_Inicializar() {
    var arg;

    try {
        var objParams =
            {                
                Filtro_CodBanco: 1,
                Filtro_CodMoneda: 1
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
                        F_Update_Division_HTML('div_Sucursal', result.split('~')[2]);
                        F_Update_Division_HTML('div_Moneda', result.split('~')[3]);                    
                        F_Update_Division_HTML('div_Banco', result.split('~')[4]);
                        F_Update_Division_HTML('div_Cuenta', result.split('~')[5]);
                        F_Update_Division_HTML('div_CajaFisica', result.split('~')[6]);
                        F_Update_Division_HTML('div_MedioPago', result.split('~')[7]);     
                        $('#MainContent_ddlMoneda').val(1);                  
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlBanco').css('background', '#FFFFE0');
                        $('#MainContent_ddlMedioPago').css('background', '#FFFFE0');                        
                        $('#MainContent_ddlCajaFisica').css('background', '#FFFFE0');
                        $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
                        $('#MainContent_ddlCuenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSucursal').val('0');
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

//function F_Reporte() {
//    var rptURL = '';
//    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
//    var TipoArchivo = 'application/pdf';
//    var CodTipoArchivo = 5;
//    var CodMenu = 702;   
//    var Titulo = "REPORTE DE CUENTAS BANCARIAS";
//    var SubTitulo = "DESDE " + $("#MainContent_txtDesde").val() + " HASTA " + $('#MainContent_txtHasta').val();
//    var NombreTabla = "CuentaBancaria";
//    var NombreArchivo = "Web_Reporte_CajaBanco_rptCuentaBancaria.rpt";
// 
//    rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
//    rptURL = rptURL + '?';
//    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
//    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
//    rptURL = rptURL + 'Titulo=' + Titulo + '&';
//    rptURL = rptURL + 'SubTitulo=' + SubTitulo + '&';
//    rptURL = rptURL + 'CodAlmacen=' + $('#MainContent_ddlSucursal').val() + '&';
//    rptURL = rptURL + 'Desde=' + $("#MainContent_txtDesde").val() + '&';
//    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';
//    rptURL = rptURL + 'CodCliente=' + $('#hfCodCtaCte').val() + '&';
//    rptURL = rptURL + 'CodCtaBancaria=' + $('#MainContent_ddlCuenta').val() + '&';
//    rptURL = rptURL + 'CodCajaFisica=' + $('#MainContent_ddlCajaFisica').val() + '&';
//    rptURL = rptURL + 'CodMedioPago=' + $('#MainContent_ddlMedioPago').val() + '&';
//    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
//    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';    
//    
//    window.open(rptURL, "PopUpRpt", Params);

//    return false;
//}

function F_Reporte() {
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var CodMenu = 718;
    var Titulo = "REPORTE DE CUENTAS BANCARIAS";
    var SubTitulo = "DESDE " + $("#MainContent_txtDesde").val() + " HASTA " + $('#MainContent_txtHasta').val();
    var NombreHoja = "TARJETASDEPOSITOS";
    var NombreArchivo = "Xls_CuentaBancaria.xlsx";

    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';   
    rptURL = rptURL + 'Titulo=' + Titulo + '&';
    rptURL = rptURL + 'SubTitulo=' + SubTitulo + '&';
    rptURL = rptURL + 'CodAlmacen=' + $('#MainContent_ddlSucursal').val() + '&';
    rptURL = rptURL + 'Desde=' + $("#MainContent_txtDesde").val() + '&';
    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';  
    rptURL = rptURL + 'CodCtaBancaria=' + $('#MainContent_ddlCuenta').val() + '&';
    rptURL = rptURL + 'CodCajaFisica=' + $('#MainContent_ddlCajaFisica').val() + '&';
    rptURL = rptURL + 'CodMedioPago=' + $('#MainContent_ddlMedioPago').val() + '&';
    rptURL = rptURL + 'NombreHoja=' + NombreHoja + '&';
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

function F_ListarNroCuenta() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {
        var objParams = {
            Filtro_CodBanco: $('#MainContent_ddlBanco').val(),
            Filtro_CodMoneda: $('#MainContent_ddlMoneda').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarNroCuenta_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Cuenta', result.split('~')[2]);
                        $('#MainContent_ddlCuenta').css('background', '#FFFFE0');
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




