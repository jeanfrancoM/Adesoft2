var AppSession = "../Planilla/SalarioConsultas.aspx";

var CodigoMenu = 8000;
var CodigoInterno = 74;

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
    $('#MainContent_txtTrabajador2').autocomplete({
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
            $('#hfCodCtaCteConsulta2').val(i.item.val);
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
    $('#MainContent_btnBuscarConsulta2').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_Buscar2();
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
//    $('#MainContent_btnVerPDF').click(function(){
//     if (!F_SesionRedireccionar(AppSession)) return false;
//     try 
//        {
//          F_VerPDF(0);
//          return false;
//        }
//        
//        catch (e) 
//        {

//            alertify.log("Error Detectado: " + e);
//        }

//    });    

//     $('#MainContent_btnVerPDFReintegro').click(function(){
//     if (!F_SesionRedireccionar(AppSession)) return false;
//     try 
//        {
//          F_VerPDF(1);
//          return false;
//        }
//        
//        catch (e) 
//        {

//            alertify.log("Error Detectado: " + e);
//        }

//    });    
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
//         $('#MainContent_imgEliminarCarga').click(function () {
//        //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
//        try {
//            F_EliminarCarga();
//            return false;
//        }

//        catch (e) {

//            toastr.error("ERROR DETECTADO: " + e);
//        }

//        return false;
//    });

//    $('#MainContent_imgConfirmarPago').click(function () {
//        //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
//        try {
//            F_ConfirmarPago();
//            return false;
//        }

//        catch (e) {

//            toastr.error("ERROR DETECTADO: " + e);
//        }

//        return false;
//    });
    $('#MainContent_btnCancelar').click(function () {
        $('#divSeleccionarEmpresa').dialog('close');
        return false;
    });
    $("#MainContent_ddlRegimenLaboral").change(function(){
        if($(this).val()==1){
            $("#MainContent_txtAñoSemana").val("");
            $("#lblSemana").html("Semana");
        }else{
            $("#MainContent_txtAñoSemana").val("");
            $("#lblSemana").html("Periodo");
        }
    });
    $("#MainContent_ddlRegimenLaboral2").change(function(){
        if($(this).val()==1){
            $("#MainContent_txtAñoSemana2").val("");
            $("#lblSemana2").html("Semana");
        }else{
            $("#MainContent_txtAñoSemana2").val("");
            $("#lblSemana2").html("Periodo");
        }
    });
     $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
         if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false;
        try {
                if(!F_ValidarGrabarDocumento()){
                    return false;
                }
                if (confirm("ESTA SEGURO DE GRABAR LA LINEA"))
                F_GrabarDocumento();
                return false;
            
            
            
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });
   $('#MainContent_btnCalcular').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
         //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false;
        try {                
                F_CalcularPorcentaje();
                return false;
                                    
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
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
     if($("#MainContent_ddlRegimenLaboral").val()==1){
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
     }else{
        if ($('#MainContent_txtAñoSemana').val().trim() != '') {

            if ($('#MainContent_txtAñoSemana').val().trim().length != 6) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#lblDisplaySemana').text("");
                $('#MainContent_txtAñoSemana').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemana').val())) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#lblDisplaySemana').text("");
                $('#MainContent_txtAñoSemana').select();
                return false;
            }



            var SemPro = utF_Planilla_Periodo_Obtener_Por_Periodo($('#MainContent_txtAñoSemana').val());

            if (SemPro.CodPeriodo == "0") {
                $('#lblDisplaySemana').text("");
                toastr.error("Periodo NO ENCONTRADA");
                $('#MainContent_lblCodSemana').text(0);
                return false;
            }

            $('#lblDisplaySemana').text("AÑO: " + SemPro.Año + ", Periodo: " + SemPro.NroPeriodo + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemana').text(SemPro.CodPeriodo);

     }
        

        return false;
    }
    });

    $('#MainContent_txtAñoSemana2').blur(function () {
     if($("#MainContent_ddlRegimenLaboral2").val()==1){
        if ($('#MainContent_txtAñoSemana2').val().trim() != '') {

            if ($('#MainContent_txtAñoSemana2').val().trim().length != 6) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#lblDisplaySemana2').text("");
                $('#MainContent_txtAñoSemana2').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemana2').val())) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#lblDisplaySemana2').text("");
                $('#MainContent_txtAñoSemana2').select();
                return false;
            }



            var SemPro = utF_Planilla_Semana_Obtener_Por_Semana($('#MainContent_txtAñoSemana2').val());

            if (SemPro.CodSemana == "0") {
                $('#lblDisplaySemana2').text("");
                toastr.error("SEMANA NO ENCONTRADA");
                $('#MainContent_lblCodSemana2').text(0);
                return false;
            }

            $('#lblDisplaySemana2').text("AÑO: " + SemPro.Año + ", SEMANA: " + SemPro.NroSemana + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemana2').text(SemPro.CodSemana);

        }
     }else{
        if ($('#MainContent_txtAñoSemana2').val().trim() != '') {

            if ($('#MainContent_txtAñoSemana2').val().trim().length != 6) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#lblDisplaySemana2').text("");
                $('#MainContent_txtAñoSemana2').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemana2').val())) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#lblDisplaySemana2').text("");
                $('#MainContent_txtAñoSemana2').select();
                return false;
            }



            var SemPro = utF_Planilla_Periodo_Obtener_Por_Periodo($('#MainContent_txtAñoSemana2').val());

            if (SemPro.CodPeriodo == "0") {
                $('#lblDisplaySemana2').text("");
                toastr.error("Periodo NO ENCONTRADA");
                $('#MainContent_lblCodSemana2').text(0);
                return false;
            }

            $('#lblDisplaySemana2').text("AÑO: " + SemPro.Año + ", Periodo: " + SemPro.NroPeriodo + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemana2').text(SemPro.CodPeriodo);

     }
        

        return false;
    }
    });

    $('#MainContent_txtFechaHoraDisplayCobranza').css('background', '#FFFFEE');
    $('#MainContent_txtAñoSemanaActual').css('background', '#FFFFEE');
    $('#MainContent_ddlProyecto').css('background', '#FFFFE0');
    $('#MainContent_ddlRegimenLaboral').css('background', '#FFFFE0');
    $('#MainContent_txtAñoSemana').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtFechaPago').css('background', '#FFFFE0');
    $('#MainContent_txtTrabajador').css('background', '#FFFFE0');
    $('#MainContent_txtTrabajador2').css('background', '#FFFFE0');
    $('#MainContent_ddlProyecto2').css('background', '#FFFFE0');
    $('#MainContent_ddlRegimenLaboral2').css('background', '#FFFFE0');
    $('#MainContent_txtAñoSemana2').css('background', '#FFFFE0');
    $("#MainContent_txtEstado").css('background', '#FFFFE0');
    $('.ccsestilo').css('background', '#FFFFE0');

    $('#divTabs').tabs();
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
    utF_Planilla_Proyecto_Listar('#MainContent_ddlProyecto2', 0, 1, '');
    utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboral2', '');
    
    return true;
}

function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
   // $('#MainContent_chkRango').prop('checked', true);
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

//        if ($('#MainContent_chkRango').is(':checked'))
//            chkFecha = '1';

        if ($('#MainContent_chkTrabajador').is(':checked'))
            chkTrabajador = '1';

        var objParams = {
            Filtro_CodRegimenLaboral: $('#MainContent_ddlRegimenLaboral').val(),            
            Filtro_CodProyecto: $('#MainContent_ddlProyecto').val(),
            Filtro_CodSemanaPeriodo: $('#MainContent_lblCodSemana').text(),
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
            
            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                if (str_mensaje_operacion != '')
                    toastr.warning(str_mensaje_operacion);
                    $('.ccsestilo').css('background', '#FFFFE0');        
                    $('#MainContent_grvConsulta .detallesart').each(function () {
                        var fila= '#' + this.id;                         
                        var lblEstado=fila.replace("lblNombreCompleto","lblEstado");     
                        var hfCodEstado=fila.replace("lblNombreCompleto","hfCodEstado");  
                        if($(hfCodEstado).val()==6){
                            $(lblEstado).css("color","red");
                        }else if ($(hfCodEstado).val()==11){
                            $(lblEstado).css("color","blue");
                        }else{
                            $(lblEstado).css("color","green");
                        }
                    });
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
function F_Buscar2() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkTrabajador = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
             chkFecha = '1';

        if ($('#MainContent_chkTrabajador2').is(':checked'))
            chkTrabajador = '1';

        var objParams = {
            Filtro_CodRegimenLaboral: $('#MainContent_ddlRegimenLaboral2').val(),            
            Filtro_CodProyecto: $('#MainContent_ddlProyecto2').val(),
            Filtro_CodSemanaPeriodo: $('#MainContent_lblCodSemana2').text(),
            Filtro_ChkTrabajador: chkTrabajador,
            Filtro_CodTrabajador: $('#hfCodCtaCteConsulta2').val(),

            Filtro_ChkFecha: chkFecha,
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),

            Filtro_CodTipoDocSust: 1,
            Filtro_CodClasificacion: 2
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Buscar_NET2(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";
            
            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];            
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta2', result.split('~')[2]);
                if (str_mensaje_operacion != '')
                    toastr.warning(str_mensaje_operacion);                    
                   
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
function F_ValidarGrabarDocumento(){
    var count=0;   
    var countMontoSuperior=0;
    var countMontoVacio=0;
    
    $('#MainContent_grvConsulta .chkItem :checkbox').each(function () {
            var chkItem = '#' + this.id;
            var txtMonto= chkItem.replace("chkPdf","txtMonto");
            var lblSaldo = chkItem.replace("chkPdf","lblSaldo");
            if ($(chkItem).is(':checked')) {
                count++;            
            }
            if($(txtMonto).val()>Number($(lblSaldo).text())){
                countMontoSuperior++;
            }
            if($(chkItem).is(':checked') && ($(txtMonto).val()=='' || isNaN($(txtMonto).val()) || $(txtMonto).val()<=0)){
                countMontoVacio++;
            }
                        

        });
    if (count==0){
        toastr.warning("Seleccione almenos un registro");
        return false;
    }
    if (countMontoSuperior>0){
        toastr.warning("El monto excede el saldo en uno o mas registros");
        return false;
    }
    if(countMontoVacio>0){
        toastr.warning("El monto ingresado en uno o mas registros no es valido");
        return false;
    }
    return true;
    
}
function F_CalcularPorcentaje(){
  var count=0;   
  var porcentaje=$("#MainContent_txtPorcentaje").val();
    $('#MainContent_grvConsulta .chkItem :checkbox').each(function () {
            var chkItem = '#' + this.id;           
            if ($(chkItem).is(':checked')) {
                count++;            
            }                                               

        });
    if (count==0){
        toastr.warning("Seleccione almenos un registro");
        return false;
    }
    if(isNaN(porcentaje) || porcentaje=='' || porcentaje<=0){
        toastr.warning("Porcentaje no valido");
        return false;
    }
    $('#MainContent_grvConsulta .chkItem :checkbox').each(function () {
            var chkItem = '#' + this.id;
            if ($(chkItem).is(':checked')) {                
                var lblSaldo=chkItem.replace("chkPdf","lblSaldo");
                var txtMonto = chkItem.replace('chkPdf', 'txtMonto');
                var calculo=Number($(lblSaldo).text())*(porcentaje/100);      
                $(txtMonto).val(calculo.toFixed(2));
            }   
    });
  
    
}
function F_GrabarDocumento() {
        var n=0;
        $('#MainContent_grvConsulta .chkItem :checkbox').each(function () {
            var chkItem = '#' + this.id;
            if ($(chkItem).is(':checked')) {

            var hfCodPagoCab = chkItem.replace('chkPdf', 'hfCodPagoCab');
            var hfCodSalarioCab = chkItem.replace('chkPdf', 'hfCodSalarioCab');
            var hfCodRegimenLaboral = chkItem.replace('chkPdf', 'hfCodRegimenLaboral');
            var hfCodTrabajador = chkItem.replace('chkPdf', 'hfCodTrabajador');
            var hfCodSemana = chkItem.replace('chkPdf', 'hfCodSemana');
            var hfCodPeriodo = chkItem.replace('chkPdf', 'hfCodPeriodo');
            var txtMonto = chkItem.replace('chkPdf', 'txtMonto');            
            var hfCodProyecto=chkItem.replace('chkPdf', 'hfCodProyecto');
            var objEntidad = {};
            objEntidad["CodPagoCab"] = Number($(hfCodPagoCab).val()); //int
            objEntidad["CodSalarioCab"] = Number($(hfCodSalarioCab).val()); //int
            objEntidad["CodRegimenLaboral"] = Number($(hfCodRegimenLaboral).val()); //int
            objEntidad["CodTrabajador"] = Number($(hfCodTrabajador).val()); //decimal
            if($(hfCodSemana).val().trim()==""){
                objEntidad["CodSemana"] = 0;
            }else{
                objEntidad["CodSemana"] = $(hfCodSemana).val().trim();
            }

            if($(hfCodPeriodo).val().trim()==""){
                objEntidad["CodPeriodo"] = 0;
            }else{
                objEntidad["CodPeriodo"] = Number($(hfCodPeriodo).val()); //decimal
            }
            
            objEntidad["CodProyecto"] = Number($(hfCodProyecto).val()); //decimal
            objEntidad["Monto"] = Number($(txtMonto).val());
            objEntidad["FechaPago"] = $("#MainContent_txtFechaPago").val();

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_Grabar_Paga',
                data: JSON.stringify(objEntidad),
                dataType: "json",
                async: false,
                success: function (dbObject) {
                    var data = dbObject.d;
                    try {
                        if (data.MsgError === "SE GRABO CORRECTAMENTE" || data.MsgError === "SE ACTUALIZO CORRECTAMENTE" || data.MsgError === "") {
                            if(n==0){
                                toastr.success("SE GRABO CORRECTAMENTE");
                                n++;
                                $("#MainContent_txtPorcentaje").val('');
                            }
                            
                        } else {
                            toastr.error(data.MsgError);
                        }
                    }
                    catch (x) { toastr.error('ERROR AL grabar'); }
                },
                complete: function () {

                },
                error: function (response) {
                    toastr.error(response.responseText);
                },
                failure: function (response) {
                    toastr.error(response.responseText);
                }
            });




        }
    });

    F_Buscar();

    return true;
    
}
function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}


function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblAcuenta= "#"+imgID.replace("imgEliminarPago","lblAcuenta");
        var lblNombreCompleto2 = "#"+imgID.replace("imgEliminarPago","lblNombreCompleto2");
        var lblFechaPago = "#"+imgID.replace("imgEliminarPago","lblFechaPago");
        var hfCodSalarioCab="#"+imgID.replace("imgEliminarPago","hfCodSalarioCab2");
        var hfCodPagoCab="#"+imgID.replace("imgEliminarPago","hfCodPagoCab2");
        var hfCodPagoDet="#"+imgID.replace("imgEliminarPago","hfCodPagoDet");
        var hfCodRegimenLaboral="#"+imgID.replace("imgEliminarPago","hfCodRegimenLaboral2");
        var hfCodTrabajador="#"+imgID.replace("imgEliminarPago","hfCodTrabajador2");
        var hfCodSemana="#"+imgID.replace("imgEliminarPago","hfCodSemana2");
        var hfCodPeriodo="#"+imgID.replace("imgEliminarPago","hfCodPeriodo2");

        var objEntidad = {};
        objEntidad["CodPagoCab"] = Number($(hfCodPagoCab).val()); //int
        objEntidad["CodSalarioCab"] = Number($(hfCodSalarioCab).val()); //int
        objEntidad["CodPagoDet"] = Number($(hfCodPagoDet).val()); //int
        objEntidad["CodRegimenLaboral"] = Number($(hfCodRegimenLaboral).val()); //int
        objEntidad["CodTrabajador"] = Number($(hfCodTrabajador).val()); //decimal
        if($(hfCodSemana).val().trim()==""){
            objEntidad["CodSemana"] = 0;
        }else{
            objEntidad["CodSemana"] = $(hfCodSemana).val().trim();
        }
        if($(hfCodPeriodo).val().trim()==""){
            objEntidad["CodPeriodo"] = 0;
        }else{
            objEntidad["CodPeriodo"] = Number($(hfCodPeriodo).val()); //decimal
        }
            
        if (!confirm("ESTA SEGURO DE ELIMINAR EL PAGO DEL TRABAJADOR : " + $(lblNombreCompleto2).text() + "\nDEL DIA : " + $(lblFechaPago).text()+ "\nCON UN MONTO DE : " + $(lblAcuenta).text()+" SOLES"))
        {
           return false;
        }

        $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_ELIMINAR_Paga',
              data: JSON.stringify(objEntidad),
              dataType: "json",
              async: false,
              success: function (dbObject) {
                  var data = dbObject.d;
                  try {
                      if (data.MsgError === "SE ELIMINO CORRECTAMENTE") {
                          toastr.success("SE ELIMINO CORRECTAMENTE");  
                          F_Buscar2();                                                                               
                      } else {
                          toastr.error(data.MsgError);
                      }
                  }
                  catch (x) { toastr.error('ERROR AL ELIMINAR'); }
              },
              complete: function () {

              },
              error: function (response) {
                  toastr.error(response.responseText);
              },
              failure: function (response) {
                  toastr.error(response.responseText);
              }
            });
         

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

//function F_ExportarExcel2(Fila) {
//    try {
//        var imgID = Fila.id;
//        lblCodMarcaGv =             '#' + imgID.replace('imgExportarExcel', 'hfCodigo');
//        var lblEstado =             '#' + imgID.replace('imgExportarExcel', 'lblEstado');
//        var lblnumero_grilla =      '#' + imgID.replace('imgExportarExcel', 'lblnumero');
//        var lblcliente_grilla =     '#' + imgID.replace('imgExportarExcel', 'lblcliente');

//        var rptURL = '';
//        rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
//        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
//        var TipoArchivo = 'application/pdf';
//        var CodTipoArchivo = '5';
//        var CodMenu = '9';
//     
//        rptURL = rptURL + '?';
//        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
//        rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
//        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
//        rptURL = rptURL + 'Codigo=' + $(lblCodMarcaGv).val() + '&';

//        window.open(rptURL, "PopUpRpt", Params);

//        return false;
//            }
//    catch (e) {
//        MostrarEspera(false);
//        toastr.error("ERROR DETECTADO: " + e);
//        return false;
//    }
//}

//function F_ExportarExcel(Fila) {

//    var arg;

//    var imgID = Fila.id;
//    var Codigo = '#' + imgID.replace('imgExportarExcel', 'hfCodigo');

//    try {
//        var objParams =
//            {
//                Filtro_Codigo: $(Codigo).val()
//            };


//        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
//        F_ExportarDetalle_NET
//            (
//                arg,
//                function (result) {


//                }
//            );

//    } catch (mierror) {
//        MostrarEspera(false);
//        toastr.error("ERROR DETECTADO: " + mierror);

//    }

//}





//function F_ImprimirDocumento(Fila, Reintegro) {

//        var rplc = 'imgPdf2';
//        if (Number(Reintegro) === 1)
//            rplc = 'imgPdf3';

//        var hfIDExcel       = '#' + Fila.replace(rplc, 'hfIDExcel');
//        var hfCodTrabajador = '#' + Fila.replace(rplc, 'hfCodTrabajador');

//        var rptURL = '';
//        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
//        var TipoArchivo = 'application/pdf';
//        var CodMenu = '8001';
//        var FormatoRPT = 'Web_rptPlanilla_Salario_Boleta_Operario.rpt'

//        rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
//        rptURL = rptURL + '?';
//        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
//        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
//        rptURL = rptURL + 'IDExcel=' + $(hfIDExcel).val() + '&';
//        rptURL = rptURL + 'CodTrabajador=' + $(hfCodTrabajador).val() + '&';
//        rptURL = rptURL + 'FormatoRPT=' + FormatoRPT + '&';
//        rptURL = rptURL + 'EsReintegro=' + Reintegro + '&';
//        window.open(rptURL, "PopUpRpt", Params);

//    return false;
//}

function F_ValidarCheck(ControlID) {


    var cadena = 'Ingrese los sgtes. campos: '

    var chkok_grilla = '#' + ControlID;
    var txtMonto = chkok_grilla.replace('chkPdf', 'txtMonto');   

    var boolEstado = $(chkok_grilla).is(':checked');

    if (boolEstado) {

        $(txtMonto).prop('disabled', false);
        
        var i = 0;
        //if ($(txtprecio_grilla).val() == "") {
            $(txtMonto).select();
            //i = 1
        //}

    }
        else {
        $(txtMonto).val('');        
        $(txtMonto).prop('disabled', true);        
    }


    return true;
}


function F_CheckAll(x){
    var bool = false;
    if(x.checked){
         $('.chkItem').find('input').prop('checked', true);         
    }else{
         $('.chkItem').find('input').prop('checked', false);
         bool=true;
    }
     $("#MainContent_grvConsulta input:checkbox").not("#MainContent_grvConsulta_ChkAll").map(function(){
         var fila = this.id;
         var txtMonto = "#"+fila.replace('chkPdf','txtMonto');         
         $(txtMonto).prop('disabled',bool);
          $(txtMonto).val('');   
     })  
    
}

//function F_VerPDF(EsReintegro){
//    var CodTrabajadores = $("#MainContent_grvConsulta input:checkbox:checked").not("#MainContent_grvConsulta_ChkAll").map(function(){       
//        var fila = this.id;
//        var hfCodTrabajador = "#"+fila.replace('chkPdf','hfCodTrabajador');
//        var idExcel = "#"+fila.replace('chkPdf','hfIDExcel');
//        return $(hfCodTrabajador).val()+'-'+$(idExcel).val()+'-'+EsReintegro;
//    }).get();  

//    if (CodTrabajadores.length!=0){
//      var json={
//        Codigos:CodTrabajadores.toString(),
//        CodTipoDoc:24
//      }
//      $.ajax({
//        type:"POST",
//        contentType:"application/json; charset=UTF-8",
//        url:"../Servicios/PDF.asmx/F_Facturas_Pedido_Lote2_PDF",
//        data:JSON.stringify(json),
//        dataType:"json",
//        async:true,
//        success:function(data){
//             if (data.d === "")
//                    toastr.error("no se pudo descargar los documentos");

//                var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';

//                window.open(data.d, 'PopUpRpt', Params);
//                //window.open(data.d, '_blank');
//                MostrarEspera(false);
//        },
//        error: function (response) {
//                alertify.log(response.responseText);
//                MostrarEspera(false);
//        },
//        failure: function (response) {
//                alertify.log(response.responseText);
//                MostrarEspera(false);
//        }
//    });

//    MostrarEspera(true);
//    return false;
//    }else {
//        alertify.log("Seleccione almenos un elemento");
//    }
//  
//}

//function  F_EliminarCarga(){
//    var obj={};
//    obj["CodSemana"]=Number($("#MainContent_lblCodSemana").text());    
//    if (confirm('¿ESTA SEGURO DE ELIMINAR LA CARGA DEL EXCEL?')){
//       
//        $.ajax({
//        type:"POST",
//        contentType: "application/json; charset=utf-8",
//        url:"SalarioConsultas.aspx/P_Eliminar_Carga_Excel_PlanillaRCC",
//        data:JSON.stringify(obj),
//        dataType: "json",
//        success:function(dObject){
//         var data = dObject.d;
//         console.log(data);                                            
//         if (data.MsgError=='SE ELIMINO CORRECTAMENTE'){            
//            toastr.success(data.MsgError);            
//            F_Buscar();
//         }else{
//            toastr.warning(data.MsgError.replace(/;/g,"<br>"));
//            MostrarEspera(false); 
//         }
//        },
//        error: function (response) {
//            toastr.error(response.responseText);
//        },
//        failure: function (response) {
//            toastr.error(response.responseText);
//        }
//         
//        });
//         
//     MostrarEspera(false);             
//    }else{                   
//       return false;
//    }
//    
//    MostrarEspera(true);
//    return true;
//}

//function F_ConfirmarPago(){
//    var obj={};
//    obj["CodSemana"]=Number($("#MainContent_lblCodSemana").text());
//    if (confirm('¿ESTA SEGURO DE CONFIRMAR EL PAGO DE LA SEMANA?')){
//       
//        $.ajax({
//        type:"POST",
//        contentType: "application/json; charset=utf-8",
//        url:"SalarioConsultas.aspx/P_Confirmar_Pago_PlanillaRCC",
//        data:JSON.stringify(obj),
//        dataType: "json",
//        success:function(dObject){
//         var data = dObject.d;                                            
//         if (data.MsgError=='SE CONFIRMO CORRECTAMENTE'){            
//            toastr.success(data.MsgError);            
//            F_Buscar();
//         }else{
//            toastr.warning(data.MsgError.replace(/;/g,"<br>"));
//            MostrarEspera(false); 
//         }
//        },
//        error: function (response) {
//            toastr.error(response.responseText);
//        },
//        failure: function (response) {
//            toastr.error(response.responseText);
//        }
//         
//        });
//         
//     MostrarEspera(false);             
//    }else{                   
//       return false;
//    }
//    
//    MostrarEspera(true);
//    return true;
//}


