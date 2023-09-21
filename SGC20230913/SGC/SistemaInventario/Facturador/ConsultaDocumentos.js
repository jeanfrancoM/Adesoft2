var AppSession = "../Maestros/Clientes.aspx";

var P_CodMoneda_LineaCredito_Inicial;

$(document).ready(function () {

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_btnBuscarConsulta').click(function () {
        try {

            F_Buscar();
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarFactura').click(function () {
        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Razon Social";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                alertify.log(Cadena);
                return false;
            }

            $("#divEdicionRegistro").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 450,
                width: 420,
                autoOpen: false
            });

            $('#divEdicionRegistro').dialog('open');

            var Letra = 0;
            var Factura = 0;

            if ($('#MainContent_chkFactura').is(':checked'))
                Factura = 1;

            if ($('#MainContent_chkFactura').is(':checked'))
                Letra = 1;

            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Letra: Letra,
                Filtro_Factura: Factura
            };
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


            F_Buscar_Factura_NET(arg, function (result) {
                //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

                //                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);

                }
                else {
                    alertify.log(result.split('~')[1]);
                }

                return false;

            });


        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    F_Controles_Inicializar();



    $('#MainContent_txtContactoTelefono').css('background', '#FFFFE0');
    $('#MainContent_txtSerie').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    
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
                        F_Update_Division_HTML('div_Empresa', result.split('~')[2]);

                        $('#MainContent_ddlEmpresa').val('1');
                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        
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

function F_Buscar() {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        var objParams = {
            Filtro_CodEmpresa: $("#MainContent_ddlEmpresa").val(),
            Filtro_Serie: $("#MainContent_txtSerie").val(),
            Filtro_Desde: $("#MainContent_txtDesde").val(),
            Filtro_Hasta: $("#MainContent_txtHasta").val(),
            Filtro_CodTipoDocumento: $("#MainContent_ddlTipoDocumento").val(),
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);


                //CONTEOS
                var NombreID = '#MainContent_grvConsulta_lblID_';
                var NombreEstado = '#MainContent_grvConsulta_lblRespuesta_';
                var NombreBaja = '#MainContent_grvConsulta_lblRespuestaBaja_';
                var NombreNumero = '#MainContent_grvConsulta_hfNumero_';
                var count = 0;
                var countACEPTADOS = 0;
                var countNOACEPTADOS = 0;
                var countBAJAS = 0;
                var titulos = true;

                var NroInferior = 0;
                var NroMayor = 0;

                $('#MainContent_grvConsulta > tbody  > tr').each(function(index, tr) { 

                    if (titulos == true) {
                        titulos = false;
                        NroInferior = Number($(NombreNumero +  index).val());
                    }
                    else {
                        var RowID = NombreID + (index - 1);
                        var Estado = NombreEstado + (index - 1);
                        var baja = NombreBaja +  (index - 1);

                        if ($(Estado).text() == "ACEPTADO") {
                            countACEPTADOS++;
                        }
                        else {
                            countNOACEPTADOS++;
                        }

                        if ($(baja).text() != "")
                            countBAJAS++;

                        NroMayor = Number($(NombreNumero +  (index - 1)).val());

                        count++;
                    }
                });

                $('#lblCantidadRegistros').text(count);

                $('#lblCantidadAceptados').text(countACEPTADOS);

                $('#lblCantidadNoAceptados').text(countNOACEPTADOS);

                $('#lblCantidadBajas').text(countBAJAS);

                var diferencia = (NroMayor - NroInferior) + 1;

                $('#lblCantidadRegistros').text(count +  '   (' + diferencia + ')  ' );

                if (str_mensaje_operacion != "")
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
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


function F_Update_Division_HTML(str_nombre_div, str_valor_div) {

    $('#' + str_nombre_div).css('display', 'none');
    $('#' + str_nombre_div).html(str_valor_div);
    $('#' + str_nombre_div).css('display', 'block');

}


function F_Numerar_Grilla(NombreGrilla,NombreLabel) {       
    var C=0;
    var Cantidad = 0;
    $('#MainContent_' + NombreGrilla).each(function () {
        var nombre = '#MainContent_' + NombreGrilla + '_' + NombreLabel + '_' + C.toString();
        if ($(nombre).text() != "") {
            Cantidad++;
        }
        C++;
    });

    return Cantidad;
}