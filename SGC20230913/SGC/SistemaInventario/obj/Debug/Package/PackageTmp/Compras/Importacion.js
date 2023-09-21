var AppSession = "../Compras/Importacion.aspx";

var CodigoMenu = 3000;
var CodigoInterno = 6;

$(document).ready(function () {

    $('#MainContent_txtProveedor').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'0'}",
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
            $('#MainContent_hfCodCtaCte2').val(i.item.val);
            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
                F_EliminarTodos();
            if ($('#hfNotaPedido').val() != '0' & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16'))
                F_EliminarTodos();
        },
        minLength: 3
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'

    });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_TipoCambio();
    });

    $(document).on("change", "select[id $= 'MainContent_ddlFormaPago']", function () {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
    });

    $("#MainContent_btnImport").click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        $('#MainContent_hfEmision').val($('#MainContent_txtEmision').val());
        $('#MainContent_hfFechaDua').val($('#MainContent_txtFechaDua').val());
        $('#MainContent_hfFechaLlegada').val($('#MainContent_txtFechaLlegada').val());
        var Cadena = 'Ingresar los sgtes. datos';

        if ($('#MainContent_txtProveedor').val() == '')
            Cadena = Cadena + '<p></p>Proveedor';

        if ($('#MainContent_txtTC').val() == '')
            Cadena = Cadena + '<p></p>Proveedor';

        if ($('#MainContent_txtNumero').val() == '')
            Cadena = Cadena + '<p></p>Numero Factura';

        if ($('#MainContent_txtEmision').val() == '')
            Cadena = Cadena + '<p></p>Emision';

        if ($('#MainContent_txtNroDua').val() == '')
            Cadena = Cadena + '<p></p>Numero Dua';

        if ($('MainContent_txtFechaDua').val() == '')
            Cadena = Cadena + '<p></p>Fecha Dua';

        if ($('MainContent_txtGastosOperativos').val() == '')
            Cadena = Cadena + '<p></p>Gastos Operativos';

        if (Cadena != 'Ingresar los sgtes. datos') {
            alertify.log(Cadena);
            return false;
        }
    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alertify.log("ERROR DETECTADO: " + e);
        }

    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);

    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    F_Controles_Inicializar();

    $("#divSeleccionarEmpresa").dialog({
        resizable: false,
        modal: true,
        title: "VALIDAR USUARIO AUXILIAR",
        title_html: true,
        height: 130,
        width: 250,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }
    });

    $("#divEliminar").dialog({
        resizable: false,
        modal: true,
        title: "VALIDAR USUARIO AUXILIAR",
        title_html: true,
        height: 130,
        width: 250,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }
    });

    $("#divPreliminar").dialog({
        resizable: false,
        modal: true,
        title: "ELIMINAR IMPORTACION",
        title_html: true,
        height: 200,
        width: 430,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $("#MainContent_txtObservacionEli").focus();
            $("#MainContent_txtObservacionEli").val('');
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }
    });

    $("#divIngresar").dialog({
        resizable: false,
        modal: true,
        title: "INGRESAR IMPORTACION",
        title_html: true,
        height: 220,
        width: 430,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $("#MainContent_txtObservacion").focus();
            $("#MainContent_txtObservacion").val('');
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();

        }
    });


    $("#divObservacion").dialog({
        resizable: false,
        modal: true,
        title: "MODIFICAR OBSERVACION",
        title_html: true,
        height: 220,
        width: 430,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $("#MainContent_txtObEdi").focus();
            $("#MainContent_txtObEdi").val('');
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();

        }
    });
    $('#MainContent_btnValidar').click(function () {
        //        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            var Cadena = "Ingrese los sgtes. campos:";

            if ($('#MainContent_txtUsuario').val() == "")
                Cadena = Cadena + '<p></p>' + "usuario";

            if ($('#MainContent_txtContraseña').val() == "")
                Cadena = Cadena + '<p></p>' + "Clave";

            if (Cadena != "Ingrese los sgtes. campos:") {
                alertify.log(Cadena);
                return false;
            }

            var objParams = {
                Filtro_Usuario: $('#MainContent_txtUsuario').val(),
                Filtro_NvClave: $('#MainContent_txtContraseña').val(),
                Filtro_Pagina: 'CuentasPorCobrar/RegistroCobranzas.aspx'
            }
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

            MostrarEspera(true);
            F_ValidarUsuario_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                $('#hfCodUsuarioAuxiliar').val(result.split('~')[2]);
                if (str_mensaje_operacion == "USUARIO AUXILIAR AUTORIZADO") {
                    $('#divSeleccionarEmpresa').dialog('close');
                }
                //alertify.log(str_mensaje_operacion);

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }

        return false;

    });

    $('#MainContent_btnCancelar').click(function () {
        $('#divSeleccionarEmpresa').dialog('close');
        return false;
    });

    $('#MainContent_btnPreliminar').click(function () {
        if (!confirm("ESTA SEGURO DE ELIMINAR LA FACTURA : " + $(lblnumero_grilla).text() + "\nDEL PROVEEDOR : " + $(lblcliente_grilla).text()))
            return false;

        $('#divPreliminar').dialog('close');
        $('#divEliminar').dialog('open');
        return false;
    })

    $('#MainContent_btnEliminar').click(function () {
        //        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            var Cadena = "Ingrese los sgtes. campos:";

            if ($('#MainContent_txtUsuario').val() == "")
                Cadena = Cadena + '<p></p>' + "usuario";

            if ($('#MainContent_txtContraseña').val() == "")
                Cadena = Cadena + '<p></p>' + "Clave";

            if (Cadena != "Ingrese los sgtes. campos:") {
                alertify.log(Cadena);
                return false;
            }

            var objParams = {
                Filtro_Usuario: $('#MainContent_txtUsuarioEliminar').val(),
                Filtro_NvClave: $('#MainContent_txtContraseñaEliminar').val(),
                Filtro_Pagina: 'CuentasPorCobrar/RegistroCobranzas.aspx'
            }
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

            MostrarEspera(true);
            F_ValidarUsuario_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                $('#hfCodUsuarioAuxiliar').val(result.split('~')[2]);
                if (str_mensaje_operacion == "USUARIO AUXILIAR AUTORIZADO") {
                    $('#divEliminar').dialog('close');
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
                        Filtro_Codigo: lblCodImportacion,
                        Filtro_Observacion: $("#MainContent_txtObservacionEli").text(),
                        Filtro_Serie: $("#MainContent_ddlSerie option:selected").text(),
                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                        Filtro_CodTipoDocSust: 1,
                        Filtro_ChkNumero: chkNumero,
                        Filtro_ChkFecha: chkFecha,
                        Filtro_ChkCliente: chkCliente,
                        Filtro_CodClasificacion: 2
                    };

                    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                    MostrarEspera(true);
                    F_AnularRegistro_Net(arg, function (result) {
                        var str_resultado_operacion = "";
                        var str_mensaje_operacion = "";

                        str_resultado_operacion = result.split('~')[0];
                        str_mensaje_operacion = result.split('~')[1];

                        MostrarEspera(false);

                        if (str_mensaje_operacion == "SE ANULO CORRECTAMENTE") {
                            F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                            alertify.log(result.split('~')[1]);
                            $('#divEliminar').dialog('close');
                            F_Buscar();
                        }
                        else {
                            alertify.log(result.split('~')[1]);
                        }

                        return false;
                    });

                }
                //alertify.log(str_mensaje_operacion);

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }

        return false;

    });
    $("#MainContent_btnIngresar").click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (confirm("ESTA SEGURO DE INGRESAR LA IMPORTACION"))
                F_ImportarDocumento();

            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnCancelarEliminar').click(function () {
        $('#divEliminar').dialog('close');
        return false;
    });

    $('#MainContent_btnCancelarPreli').click(function () {
        $('#divPreliminar').dialog('close');
        return false;
    })

    $('#MainContent_btnCancelarIngreso').click(function () {
        $('#divIngresar').dialog('close');
        return false;
    });

    $('#MainContent_btnCancelarEdi').click(function () {
        $('#divObservacion').dialog('close');
        return false;
    });

    $('#MainContent_btnEdi').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (confirm("ESTA SEGURO DE MODIFICAR LA OBSERVACION"))

                var ModificarObs = {};
            ModificarObs["CodMovimiento"] = codigoOb;
            ModificarObs["Observacion"] = $("#MainContent_txtObEdi").val();

            $.ajax({
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'Importacion.aspx/F_ModificarObservacion',
                dataType: "json",
                data: JSON.stringify(ModificarObs),
                success: function (dataObject) {
                    var data = dataObject.d;
                    try {
                        if (data.MsgError === "") {

                        } else {
                            alertify.log(data.MsgError);                            
                        }
                    }
                    catch (x) { }
                },
                complete: function () {
                    F_Buscar();
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });

            $("#divObservacion").dialog('close');
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });


    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtSerie').css('background', '#FFFFE0');

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtPeriodo').css('background', '#FFFFE0');

    $('#MainContent_txtFechaIngreso').css('background', '#FFFFE0');

    $('#MainContent_txtPeriodo').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtMonto').css('background', '#FFFFE0');

    $('#MainContent_txtDsctoTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtPeriodoConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNroDua').css('background', '#FFFFE0');

    $('#MainContent_txtFechaDua').css('background', '#FFFFE0');

    $('#MainContent_txtFechaLlegada').css('background', '#FFFFE0');
    //---
    $('#MainContent_txtUsuario').css('background', '#FFFFE0');

    $('#MainContent_txtContraseña').css('background', '#FFFFE0');

    $('#MainContent_txtUsuarioEliminar').css('background', '#FFFFE0');

    $('#MainContent_txtContraseñaEliminar').css('background', '#FFFFE0');
    
    $('#divTabs').tabs();
});

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodSerie: 66

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
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        $('#MainContent_txtTC').val(result.split('~')[6]);                
                        $('#MainContent_ddlSerieConsulta').val(61);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[2]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        F_Update_Division_HTML('div_tipodocumento', result.split('~')[9]);
                        F_Update_Division_HTML('div_clasificacion', result.split('~')[10]);
                        //F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[11]);
                        $('#MainContent_ddlMoneda').val(2);
                        $('#MainContent_ddlFormaPago').val(1);
                        $('#MainContent_ddlTipoDocumento').val(1);
                        $('#MainContent_ddlClasificacion').val(2);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $("#MainContent_txtPeriodo").val($('#MainContent_txtFechaIngreso').val().substr($('#MainContent_txtFechaIngreso').val().length - 4) + $('#MainContent_txtFechaIngreso').val().substring(3, 5));
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_txtTC').css('background', '#FFFFE0');
                        $('#MainContent_txtGastosOperativos').css('background', '#FFFFE0');
                        $('#MainContent_txtFechaLlegadaIng').css('background', '#FFFFE0');
                        $('#MainContent_txtProveedorIng').css('background', '#FFFFE0');
                        $('#MainContent_txtNumIng').css('background', '#FFFFE0');
                        $('#MainContent_ddlClasificacion').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        $('#MainContent_txtObservacion').css('background', '#FFFFE0');
                        $('#MainContent_txtProveedorEli').css('background', '#FFFFE0');
                        $('#MainContent_txtNumEli').css('background', '#FFFFE0');
                        $('#MainContent_txtObservacionEli').css('background', '#FFFFE0');
                        $('#MainContent_txtProvEdi').css('background', '#FFFFE0');
                        $('#MainContent_txtNumEdi').css('background', '#FFFFE0');
                        $('#MainContent_txtObEdi').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_chKConIgv').prop('disabled', true);
                        $('#MainContent_chkSinIgv').prop('disabled', true);
                        $('#hfNotaPedido').val('0');
                        $('#hfCodCtaCteNP').val('0');
                        $('.ccsestilo').css('background', '#FFFFE0');

                        $('#divSeleccionarEmpresa').dialog('open');
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

function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
//    F_Buscar();
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
                alertify.log(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_FormaPago(CodFormaPago) {

    var arg;
    try {
        switch (CodFormaPago) {
            case "1":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 0));
                break;

            case "3":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 30));
                break;

            case "4":
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
        }


    }
    catch (mierror) {
        alertify.log("Error detectado: " + mierror);
    }

}
function F_ImportarDocumento(){
    try {

        var objParams = {
            Filtro_Codigo: lblCodImportacion,            
            Filtro_FechaLlegada:$("#MainContent_txtFechaLlegadaIng").val(),            
            Filtro_Observacion: $("#MainContent_txtObservacion").val()
        };
        console.log(objParams.Filtro_Codigo);
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ImportarDocumento_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                alertify.log(result.split('~')[1]);
                $('#divIngresar').dialog('close');
                F_Buscar();
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;
        });

    } catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
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
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
            Filtro_CodTipoDocSust: 1,
            Filtro_CodClasificacion: 2
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblnumero'));
                if (str_mensaje_operacion != '')
                    alertify.log(str_mensaje_operacion);

            }
            else {
                alertify.log(result.split('~')[1]);
            }
                        return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }

}

function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}

var lblCodImportacion = 0;
var lblnumero_grilla =''
var lblcliente_grilla = ''

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        lblCodImportacion = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
        var lblEstadoImportacion = '#' + imgID.replace('imgAnularDocumento', 'lblEstadoImportacion');
         lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
         lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');
        var lblfechaLlegada = '#' + imgID.replace('imgAnularDocumento', 'lblFechaLlegada');

        if ($(lblEstado).text() == "ANULADO" || $(lblEstadoImportacion).text() == "ANULADO") {
            alertify.log("ESTE DOCUMENTO SE ENCUENTRA ANULADO");
            return false;
        }
        //ESTO NO ES FUNCIONAL PORQUE HASTA AHORA LA ANULACION NO GUARDA EN PAGOS.... 
        //ASÍ QUE PARA QUE VALIDAR PAGOS SI NO REGISTRA.......
//        if ($(lblEstado).text() == "CANCELADO TOTAL") {
//            alertify.log("ESTE FACTURA SE ENCUENTRA CANCELADO TOTAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA FACTURA");
//            return false;
//        }

//        if ($(lblEstado).text() == "CANCELADO PARCIAL") {
//            alertify.log("ESTE FACTURA SE ENCUENTRA CANCELADO PARCIAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA FACTURA");
//            return false;
//        }



        lblCodImportacion = $(lblCodImportacion).val();
        $('#MainContent_txtProveedorEli').val($(lblcliente_grilla).text());
        $('#MainContent_txtNumEli').val($(lblnumero_grilla).text());

        $('#divPreliminar').dialog('open');
        return true;


    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }


}
//Ingresar la importacion
function F_IngresarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion    
    try {
        var imgID = Fila.id;
        console.log(imgID);
        lblCodImportacion = '#' + imgID.replace('imgIngresarImportacion', 'hfCodigo');
        var lblEstado = '#' + imgID.replace('imgIngresarImportacion', 'lblEstado');
        var lblEstadoImportacion = '#' + imgID.replace('imgIngresarImportacion', 'lblEstadoImportacion');
        lblnumero_grilla = '#' + imgID.replace('imgIngresarImportacion', 'lblnumero');
        lblcliente_grilla = '#' + imgID.replace('imgIngresarImportacion', 'lblcliente');
        var lblfechaLlegada = '#' + imgID.replace('imgIngresarImportacion', 'lblFechaLlegada');
                      
        if ($(lblEstado).text() == "ANULADO" || $(lblEstadoImportacion).text() == "ANULADO") {
            alertify.log("ESTE DOCUMENTO SE ENCUENTRA ANULADO");
            return false;
        }
        if ($(lblEstadoImportacion).text() == "RECIBIDO") {
            alertify.log("ESTE DOCUMENTO SE ENCUENTRA IMPORTADO");
            return false;
        }
        $('#MainContent_txtFechaLlegadaIng').val($(lblfechaLlegada).text());
        $('#MainContent_txtProveedorIng').val($(lblcliente_grilla).text());
        $('#MainContent_txtNumIng').val($(lblnumero_grilla).text());
        lblCodImportacion = $(lblCodImportacion).val();
       
          
        $('#divIngresar').dialog('open');
        return true;
    } catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }
}
//Modificar Observacion
function F_ModificarObservacion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion    
    try {
        var imgID = Fila.id;

        $('#MainContent_txtProvEdi').val($(provOb).text());
        $('#MainContent_txtNumEdi').val($(numOb).text());

        console.log(codigoOb);
        $('#divObservacion').dialog('open');
        return true;
    } catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
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
        //$(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
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
        var Codigo = $('#' + Fila.replace('pnlOrders', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalle_' + Col;
        Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

        if ($(Hfgv).val() === "1") {
            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: 0,
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_LlenarGridDetalle_NET(arg, function (result) {

                    MostrarEspera(false);

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
                        alertify.log(str_mensaje_operacion);
                    }

                    return false;

                });

            }

        }

    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }

    return true;
}

function F_ExportarExcel2(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 3000601, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        var imgID = Fila.id;
        lblCodImportacion = '#' + imgID.replace('imgExportarExcel', 'hfCodigo');
        var lblEstado =             '#' + imgID.replace('imgExportarExcel', 'lblEstado');
        var lblnumero_grilla =      '#' + imgID.replace('imgExportarExcel', 'lblnumero');
        var lblcliente_grilla =     '#' + imgID.replace('imgExportarExcel', 'lblcliente');

        var rptURL = '';
        rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodTipoArchivo = '5';
        var CodMenu = '9';
     
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
        rptURL = rptURL + 'Codigo=' + $(lblCodImportacion).val() + '&';

        window.open(rptURL, "PopUpRpt", Params);

        return false;
            }
    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }
}

function F_ExportarExcel(Fila) {

    var arg;

    var imgID = Fila.id;
    var Codigo = '#' + imgID.replace('imgExportarExcel', 'hfCodigo');

    try {
        var objParams =
            {
                Filtro_Codigo: $(Codigo).val()
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        F_ExportarDetalle_NET
            (
                arg,
                function (result) {


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + mierror);

    }

}


var obImportacion;
var hfgvObImportacion;
//Variables para editar la observacion
var codigoOb=0;
var numOb='';
var provOb='';

function imgMasObservacionImportacion_Click(Control) {
    obImportacion = Control;
    var id = obImportacion.id;
    codigoOb = '#' + id.replace('imgMasObservacion', 'hfCodigo');
    numOb = '#' + id.replace('imgMasObservacion', 'lblnumero');
    provOb = '#' + id.replace('imgMasObservacion', 'lblcliente');

    codigoOb = $(codigoOb).val();
    
    var Src = $(Control).attr('src');
    
    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_ObservacionImportacion(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_ObservacionImportacion(Fila) { 
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvObservacion_' + Col;
        hfgvObImportacion = '#' + Fila.replace('pnlOrdersObservacion', 'hfDetalleCargadoObservacion');

        if ($(hfgvObImportacion).val() === "1") {
            $(obImportacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(obImportacion).next().html() + '</td></tr>');
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

                MostrarEspera(true);
                F_ObservacionImportacion_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(obImportacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(obImportacion).next().html() + '</td></tr>');
                        $(hfgvObImportacion).val('1');
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }
                    return false;
                });
            }
        }
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }
    return true;
}

var auImportacion;
var hfgvAuImportacion;
function imgMasAuditoriaImportacion_Click(Control) {
    auImportacion = Control;
    var Src = $(Control).attr('src');
    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_AuditoriaImportacion(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_AuditoriaImportacion(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvAuditoria_' + Col;
        hfgvAuImportacion = '#' + Fila.replace('pnlOrdersAuditoria', 'hfDetalleCargadoAuditoria');

        if ($(hfgvAuImportacion).val() === "1") {
            $(auImportacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(auImportacion).next().html() + '</td></tr>');
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

                MostrarEspera(true);
                F_AuditoriaImportacion_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(auImportacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(auImportacion).next().html() + '</td></tr>');
                        $(hfgvAuImportacion).val('1');
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }
                    return false;
                });
            }
        }
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }
    return true;
}