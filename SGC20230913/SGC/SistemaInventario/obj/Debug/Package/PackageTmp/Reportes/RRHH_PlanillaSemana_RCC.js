var AppSession = "../Reportes/RRHH_PlanillaSemana_RCC.aspx";

var CodigoMenu = 10000;
var CodigoInterno = 800001;

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

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);

    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#MainContent_txtAñoSemanaInicio').blur(function () {

        if ($('#MainContent_txtAñoSemanaInicio').val().trim() != '') {

            if ($('#MainContent_txtAñoSemanaInicio').val().trim().length != 6) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#MainContent_lblDisplaySemanaInicio').text("");
                $('#MainContent_txtAñoSemanaInicio').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemanaInicio').val())) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#MainContent_lblDisplaySemanaInicio').text("");
                $('#MainContent_txtAñoSemanaInicio').select();
                return false;
            }

            var SemPro = utF_Planilla_Semana_Obtener_Por_Semana($('#MainContent_txtAñoSemanaInicio').val());

            if (SemPro.CodSemana == "0") {
                $('#MainContent_lblDisplaySemanaInicio').text("");
                toastr.error("SEMANA NO ENCONTRADA");
                $('#MainContent_lblCodSemanaInicio').text(0);
                return false;
            }

            $('#MainContent_lblDisplaySemanaInicio').text("AÑO: " + SemPro.Año + ", SEMANA: " + SemPro.NroSemana + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemanaInicio').text(SemPro.CodSemana);

        }

        return false;
    });

    $('#MainContent_txtAñoSemanaFinal').blur(function () {


        if ($('#MainContent_txtAñoSemanaFinal').val().trim() != '') {

            if ($('#MainContent_txtAñoSemanaFinal').val().trim().length != 6) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#MainContent_lblDisplaySemanaFinal').text("");
                $('#MainContent_txtAñoSemanaInicioFinal').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoSemanaFinal').val())) {
                toastr.error("FORMATO DE SEMANA INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Semana.AñoSemana2);
                $('#MainContent_lblDisplaySemanaFinal').text("");
                $('#MainContent_txtAñoSemanaFinal').select();
                return false;
            }

            var SemPro = utF_Planilla_Semana_Obtener_Por_Semana($('#MainContent_txtAñoSemanaFinal').val());

            if (SemPro.CodSemana == "0") {
                $('#MainContent_lblDisplaySemanaFinal').text("");
                toastr.error("SEMANA NO ENCONTRADA");
                $('#MainContent_lblCodSemanaFinal').text(0);
                return false;
            }

            $('#MainContent_lblDisplaySemanaFinal').text("AÑO: " + SemPro.Año + ", SEMANA: " + SemPro.NroSemana + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodSemanaFinal').text(SemPro.CodSemana);

        }
        return false;
    });

    $("#MainContent_ddlRegimenLaboral").change(function () {
        if ($(this).val() == 2) {
            $(".trCivil").hide();
        } else {
            $(".trCivil").show();
        }
    });
    $('#MainContent_txtAñoPeriodo').blur(function () {

        if ($('#MainContent_txtAñoPeriodo').val().trim() != '') {

            if ($('#MainContent_txtAñoPeriodo').val().trim().length != 6) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#MainContent_lblDisplayPeriodo').text("");
                $('#MainContent_txtAñoPeriodo').select();
                return false;
            }


            if (isNaN($('#MainContent_txtAñoPeriodo').val())) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#MainContent_lblDisplayPeriodo').text("");
                $('#MainContent_txtAñoPeriodo').select();
                return false;
            }



            var SemPro = utF_Planilla_Periodo_Obtener_Por_Periodo($('#MainContent_txtAñoPeriodo').val());

            if (SemPro.CodPeriodo == "0") {
                $('#MainContent_lblDisplayPeriodo').text("");
                toastr.error("Periodo NO ENCONTRADA");
                $('#MainContent_lblCodPeriodo').text(0);
                return false;
            }

            $('#MainContent_lblDisplayPeriodo').text("AÑO: " + SemPro.Año + ", Periodo: " + SemPro.NroPeriodo + ", FECHA: Del " + SemPro.FechaInicialStr + " al " + SemPro.FechaFinalStr);

            $('#MainContent_lblCodPeriodo').text(SemPro.CodPeriodo);

        }

        return false;
    });
    $('#MainContent_btnExcel').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            if ($("#MainContent_ddlRegimenLaboral").val() == 1) {
            
            if ($("#MainContent_txtAñoSemanaInicio").val() == '') {
                alertify.log("INGRESE EL NRO DE SEMANA DE INICIO");
                return false;
            }
            if ($("#MainContent_txtAñoSemanaFinal").val() == '') {
                alertify.log("INGRESE EL NRO DE SEMANA DE FIN");
                return false;
            }
        }
            if ($("#MainContent_txtAñoPeriodo").val() == '') {
                alertify.log("INGRESE EL NRO DE PERIODO");
                return false;
            }
            F_Excel();
            return false;
        }
        catch (e) {
            alert("Error Detectado: " + e);
        }
    });

    $("#MainContent_txtAñoSemanaInicio").ForceNumericOnly();
    $('#MainContent_txtAñoSemanaInicio').css('background', '#FFFFE0');
    $("#MainContent_txtAñoSemanaFinal").ForceNumericOnly();
    $('#MainContent_txtAñoSemanaFinal').css('background', '#FFFFE0');
    $('#MainContent_ddlProyecto').css('background', '#FFFFE0');
    $('#MainContent_ddlRegimenLaboral').css('background', '#FFFFE0');
    $('#MainContent_txtAñoPeriodo').css('background', '#FFFFEE');
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
    utF_Planilla_Proyecto_Listar('#MainContent_ddlProyecto', 0, 1, '');
    utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboral', '');

    return true;
}

function F_Excel() {
    var Cuerpo = '#MainContent_';
    var rptURL = '';
    var CodMenu;
    var NombreArchivo;
    var NombreHoja;    
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
   
    if ($("#MainContent_ddlRegimenLaboral").val()==1){
         CodMenu = 801;
         NombreArchivo = 'Xls_PlanillaRCC.xlsx';
         NombreHoja = 'PLANILLA';
    }else{
         CodMenu = 802;
         NombreArchivo = 'Xls_PlanillaRG.xlsx';
         NombreHoja = 'PLANILLA';
    }


    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodSemanaInicio=' + $('#MainContent_lblCodSemanaInicio').text() + '&';
    rptURL = rptURL + 'CodSemanaFin=' + $('#MainContent_lblCodSemanaFinal').text() + '&';
    rptURL = rptURL + 'CodPeriodo=' + $('#MainContent_lblCodPeriodo').text() + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
    rptURL = rptURL + 'NombreHoja=' + NombreHoja + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

