var AppSession = "../Planilla/SalarioConsultas.aspx";

var CodigoMenu = 8000;
var CodigoInterno = 70;

$(document).ready(function () {

    F_ValidaSesionActiva('', true);

    $('#MainContent_txtTrabajador').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_Trabajador_Listar_AutoComplete',
                data: "{'Nombres':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.NombreCompleto,
                            val: item.CodTrabajador,
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

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.error("ERROR DETECTADO: " + e);
        }

        return false;
    });

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
    $('#MainContent_btnVerPDF').click(function(){
     if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_VerPDF(0);
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }

    });    

     $('#MainContent_btnVerPDFReintegro').click(function(){
     if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_VerPDF(1);
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
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
                toastr.error(Cadena);
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
            toastr.error("Error Detectado: " + e);
        }

        return false;

    });
    $("#MainContent_ddlEstado").change(function(){
        var valor = $(this).val();
        $('#MainContent_grvConsulta .detallesart').each(function () {
            var fila = '#' + this.id;
            var hfCodEstado= fila.replace("lblFecha","hfCodEstado");
            if (valor==0){
                $("#MainContent_grvConsulta tr").show();
            }else{
                if (valor!=$(hfCodEstado).val()){
                $(hfCodEstado).closest("tr").hide();
            }else{
                $(hfCodEstado).closest("tr").show();
            }
            }
            

        });
    });
    
    $('#MainContent_imgEliminarCarga').click(function () {
        //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_EliminarCarga();
            return false;
        }

        catch (e) {

            toastr.error("ERROR DETECTADO: " + e);
        }

        return false;
    });

    $('#MainContent_imgConfirmarPago').click(function () {
        //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_ConfirmarPago();
            return false;
        }

        catch (e) {

            toastr.error("ERROR DETECTADO: " + e);
        }

        return false;
    });
    $('#MainContent_btnCancelar').click(function () {
        $('#divSeleccionarEmpresa').dialog('close');
        return false;
    });

    $('#MainContent_btnEliminar').click(function () {
        //        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            var Cadena = "Ingrese los sgtes. campos:";

            if ($('#MainContent_txtUsuario').val() == "")
                Cadena = Cadena + '<p></p>' + "usuario";

            if ($('#MainContent_txtContraseña').val() == "")
                Cadena = Cadena + '<p></p>' + "Clave";

            if (Cadena != "Ingrese los sgtes. campos:") {
                toastr.error(Cadena);
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
                        Filtro_Codigo: lblCodMarcaGv,
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
                            toastr.success(result.split('~')[1]);
                            $('#divEliminar').dialog('close');
                            F_Buscar();
                        }
                        else {
                            toastr.error(result.split('~')[1]);
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
            toastr.error("Error Detectado: " + e);
        }

        return false;

    });

    $('#MainContent_btnCancelarEliminar').click(function () {
        $('#divEliminar').dialog('close');
        return false;
    });


    $('#MainContent_txtAñoSemana').blur(function () {

        if ($('#MainContent_txtAñoSemana').val().trim() != '') {

            if ($('#MainContent_txtAñoSemana').val().trim().length != 6) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#lblDisplaySemana').text("");
                $('#MainContent_txtAñoSemana').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemana').val())) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#lblDisplaySemana').text("");
                $('#MainContent_txtAñoSemana').select();
                return false;
            }



            var SemPro = utF_Planilla_Semana_Obtener_Por_Semana($('#MainContent_txtAñoSemana').val());

            if (SemPro.CodSemana == "0") {
                $('#lblDisplaySemana').text("");
                toastr.error("SEMANA NO ENCONTRADA");
                $('#MainContent_lblCodSemana').text(0);
                return false;
            }

            $('#lblDisplaySemana').text("AÑO: " + SemPro.Año + ", SEMANA: " + SemPro.NroSemana + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemana').text(SemPro.CodSemana);

        }

        return false;
    });

    $('#MainContent_txtFechaHoraDisplayCobranza').css('background', '#FFFFEE');
    $('#MainContent_txtAñoSemanaActual').css('background', '#FFFFEE');
    $('#MainContent_ddlProyecto').css('background', '#FFFFE0');
    $('#MainContent_ddlRegimenLaboral').css('background', '#FFFFE0');
    $('#MainContent_txtAñoSemana').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');
    $('#MainContent_txtTrabajador').css('background', '#FFFFE0');
    $("#MainContent_ddlEstado").css('background', '#FFFFE0');


    $('#divTabs').tabs();
    F_ListarEstados();
});


var DiaActual = "";
var Planilla_Semana;
$().ready(function () {

    $(document).everyTime(100, function () {
        var now = moment().format('DD/MM/YYYY, h:mm:ss a');
        var now2 = moment().format('DD/MM/YYYY');
        $('#MainContent_txtFechaHoraDisplayCobranza').val(now);

        if (DiaActual != now2) {
            DiaActual = now2;
            Planilla_Semana = utF_Planilla_Semana_Obtener(DiaActual);
            $('#MainContent_txtAñoSemanaActual').val(Planilla_Semana.AñoSemana1);
        };

    });

});

function F_Controles_Inicializar() {

    utF_Planilla_Proyecto_Listar('#MainContent_ddlProyecto', 0, 1, '');
    utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboral', '');

    return true;
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

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkTrabajador = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkTrabajador').is(':checked'))
            chkTrabajador = '1';

        var objParams = {
            Filtro_CodRegimenLaboral: $('#MainContent_ddlRegimenLaboral').val(),
            Filtro_CodCategoria: 1,
            Filtro_CodProyecto: $('#MainContent_ddlProyecto').val(),
            Filtro_CodSemana: $('#MainContent_lblCodSemana').text(),
            Filtro_ChkTrabajador: chkTrabajador,
            Filtro_CodTrabajador: $('#hfCodCtaCteConsulta').val(),

            Filtro_ChkFecha: chkFecha,
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),

            Filtro_CodTipoDocSust: 1,
            Filtro_CodClasificacion: 2
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Buscar_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";
            var str_estado="";
            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            str_estado=result.split('~')[3];
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                if (str_mensaje_operacion != '')
                    toastr.warning(str_mensaje_operacion);
                    $('#MainContent_grvConsulta .detallesart').each(function () {
                        var fila= '#' + this.id;                         
                        var lblEstado=fila.replace("lblFecha","lblEstado");     
                        var hfCodEstado=fila.replace("lblFecha","hfCodEstado");  
                        if($(hfCodEstado).val()==6){
                            $(lblEstado).css("color","red");
                        }else if ($(hfCodEstado).val()==11){
                            $(lblEstado).css("color","blue");
                        }else{
                            $(lblEstado).css("color","green");
                        }
                    });
                    $("#MainContent_ddlEstado").val(0);
            }
            else {
                toastr.error(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.error("ERROR DETECTADO: " + e);
        return false;
    }

}

function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}

var lblCodMarcaGv = 0;
function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        lblCodMarcaGv = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
        var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
        var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');

        //ESTO NO ES FUNCIONAL PORQUE HASTA AHORA LA ANULACION NO GUARDA EN PAGOS.... 
        //ASÍ QUE PARA QUE VALIDAR PAGOS SI NO REGISTRA.......
//        if ($(lblEstado).text() == "CANCELADO TOTAL") {
        //           toastr.error("ESTE FACTURA SE ENCUENTRA CANCELADO TOTAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA FACTURA");
//            return false;
//        }

//        if ($(lblEstado).text() == "CANCELADO PARCIAL") {
        //            toastr.error("ESTE FACTURA SE ENCUENTRA CANCELADO PARCIAL; PRIMERO ELIMINE EL PAGO Y LUEGO ELIMINE LA FACTURA");
//            return false;
//        }

        if (!confirm("ESTA SEGURO DE ELIMINAR LA FACTURA : " + $(lblnumero_grilla).text() + "\nDEL PROVEEDOR : " + $(lblcliente_grilla).text()))
            return false;

        lblCodMarcaGv = $(lblCodMarcaGv).val();

        $('#divEliminar').dialog('open');
        return true;


    }

    catch (e) {
        MostrarEspera(false);
        toastr.error("ERROR DETECTADO: " + e);
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
        var IDExcel = $('#' + Fila.replace('pnlOrders', 'hfIDExcel')).val();
        var CodTrabajador = $('#' + Fila.replace('pnlOrders', 'hfCodTrabajador')).val();
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
                            Filtro_grvNombre: grvNombre,
                            Filtro_IDExcel: IDExcel,
                            Filtro_CodTrabajador: CodTrabajador,
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
                        toastr.error(str_mensaje_operacion);
                    }

                    return false;

                });

            }

        }

    }
    catch (e) {
        MostrarEspera(false);
        toastr.error("ERROR DETECTADO: " + e);
        return false;
    }

    return true;
}
function F_ListarEstados() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Servicios/DatosPlanilla_Trabajador.asmx/F_Listar_Estados_Planilla_Pago",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            console.log(data);
            $("#MainContent_ddlEstado").append(new Option("TODOS", 0));            
            for (var i = 0; i < data.length; i++) {
                $("#MainContent_ddlEstado").append(new Option(data[i].DscAbvConcepto, data[i].CodConcepto));                
            }
        },
        error: function (response) {
            toastr.error(response.responseText);
        },
        failure: function (response) {
            toastr.error(response.responseText);
        }
    });
}
function F_ExportarExcel2(Fila) {
    try {
        var imgID = Fila.id;
        lblCodMarcaGv =             '#' + imgID.replace('imgExportarExcel', 'hfCodigo');
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
        rptURL = rptURL + 'Codigo=' + $(lblCodMarcaGv).val() + '&';

        window.open(rptURL, "PopUpRpt", Params);

        return false;
            }
    catch (e) {
        MostrarEspera(false);
        toastr.error("ERROR DETECTADO: " + e);
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
        toastr.error("ERROR DETECTADO: " + mierror);

    }

}





function F_ImprimirDocumento(Fila, Reintegro) {

        var rplc = 'imgPdf2';
        if (Number(Reintegro) === 1)
            rplc = 'imgPdf3';

        var hfIDExcel       = '#' + Fila.replace(rplc, 'hfIDExcel');
        var hfCodTrabajador = '#' + Fila.replace(rplc, 'hfCodTrabajador');

        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodMenu = '8001';
        var FormatoRPT = 'Web_rptPlanilla_Salario_Boleta_Operario.rpt'

        rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
        rptURL = rptURL + 'IDExcel=' + $(hfIDExcel).val() + '&';
        rptURL = rptURL + 'CodTrabajador=' + $(hfCodTrabajador).val() + '&';
        rptURL = rptURL + 'FormatoRPT=' + FormatoRPT + '&';
        rptURL = rptURL + 'EsReintegro=' + Reintegro + '&';
        window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_CheckAll(x){
    if(x.checked){
         $('.chkItem').find('input').prop('checked', true);
    }else{
         $('.chkItem').find('input').prop('checked', false);
    }
}

function F_VerPDF(EsReintegro){
    var CodTrabajadores = $("#MainContent_grvConsulta input:checkbox:checked").not("#MainContent_grvConsulta_ChkAll").map(function(){       
        var fila = this.id;
        var hfCodTrabajador = "#"+fila.replace('chkPdf','hfCodTrabajador');
        var idExcel = "#"+fila.replace('chkPdf','hfIDExcel');
        return $(hfCodTrabajador).val()+'-'+$(idExcel).val()+'-'+EsReintegro;
    }).get();  

    if (CodTrabajadores.length!=0){
      var json={
        Codigos:CodTrabajadores.toString(),
        CodTipoDoc:24
      }
      $.ajax({
        type:"POST",
        contentType:"application/json; charset=UTF-8",
        url:"../Servicios/PDF.asmx/F_Facturas_Pedido_Lote2_PDF",
        data:JSON.stringify(json),
        dataType:"json",
        async:true,
        success:function(data){
             if (data.d === "")
                    toastr.error("no se pudo descargar los documentos");

                var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';

                window.open(data.d, 'PopUpRpt', Params);
                //window.open(data.d, '_blank');
                MostrarEspera(false);
        },
        error: function (response) {
                alertify.log(response.responseText);
                MostrarEspera(false);
        },
        failure: function (response) {
                alertify.log(response.responseText);
                MostrarEspera(false);
        }
    });

    MostrarEspera(true);
    return false;
    }else {
        alertify.log("Seleccione almenos un elemento");
    }
  
}

function  F_EliminarCarga(){
    var obj={};
    obj["CodSemana"]=Number($("#MainContent_lblCodSemana").text());    
    if (confirm('¿ESTA SEGURO DE ELIMINAR LA CARGA DEL EXCEL?')){
       
        $.ajax({
        type:"POST",
        contentType: "application/json; charset=utf-8",
        url:"SalarioConsultas.aspx/P_Eliminar_Carga_Excel_PlanillaRCC",
        data:JSON.stringify(obj),
        dataType: "json",
        success:function(dObject){
         var data = dObject.d;
         console.log(data);                                            
         if (data.MsgError=='SE ELIMINO CORRECTAMENTE'){            
            toastr.success(data.MsgError);            
            F_Buscar();
         }else{
            toastr.warning(data.MsgError.replace(/;/g,"<br>"));
            MostrarEspera(false); 
         }
        },
        error: function (response) {
            toastr.error(response.responseText);
        },
        failure: function (response) {
            toastr.error(response.responseText);
        }
         
        });
         
     MostrarEspera(false);             
    }else{                   
       return false;
    }
    
    MostrarEspera(true);
    return true;
}

function F_ConfirmarPago(){
    var obj={};
    obj["CodSemana"]=Number($("#MainContent_lblCodSemana").text());
    if (confirm('¿ESTA SEGURO DE CONFIRMAR EL PAGO DE LA SEMANA?')){
       
        $.ajax({
        type:"POST",
        contentType: "application/json; charset=utf-8",
        url:"SalarioConsultas.aspx/P_Confirmar_Pago_PlanillaRCC",
        data:JSON.stringify(obj),
        dataType: "json",
        success:function(dObject){
         var data = dObject.d;                                            
         if (data.MsgError=='SE CONFIRMO CORRECTAMENTE'){            
            toastr.success(data.MsgError);            
            F_Buscar();
         }else{
            toastr.warning(data.MsgError.replace(/;/g,"<br>"));
            MostrarEspera(false); 
         }
        },
        error: function (response) {
            toastr.error(response.responseText);
        },
        failure: function (response) {
            toastr.error(response.responseText);
        }
         
        });
         
     MostrarEspera(false);             
    }else{                   
       return false;
    }
    
    MostrarEspera(true);
    return true;
}


