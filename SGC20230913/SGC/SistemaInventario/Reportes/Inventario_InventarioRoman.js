var AppSession = "../Reportes/Inventario_InventarioRoman.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnExcel').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_VisualizarExcel();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnPdf').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if ($('#MainContent_txtPeriodo').val() == '')
            { alertify.log("Ingrese Periodo"); $('#MainContent_txtPeriodo').focus(); return false; }
            F_VisualizarPdf();
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

$(document).on("change", "select[id $= 'MainContent_ddlFamilia']", function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    F_Mostrar_Marcas($('#MainContent_ddlFamilia').val());
});

function F_Mostrar_Marcas(CodFam) {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {

        var objParams = {
            Filtro_CodFamilia: CodFam
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Marcas_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Marca', result.split('~')[2]);
                        $('#MainContent_ddlMarca').css('background', '#FFFFE0');
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

function F_Controles_Inicializar() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $('#MainContent_ddlProcedencia').css('background', '#FFFFE0');

    var arg;

    try {
        var objParams =
            {
                Filtro_CodFamilia: '0'

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
                        //                        F_Update_Division_HTML('divConsultaArticulo', result.split('~')[2]);
                        F_Update_Division_HTML('div_Familia', result.split('~')[3]);
                        F_Update_Division_HTML('div_Marca', result.split('~')[4]);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca').css('background', '#FFFFE0');
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
    if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {
        var objParams = {
            Filtro_CodFamilia: $('#MainContent_ddlFamilia').val(),
            Filtro_Marca: $('#MainContent_ddlMarca').val(),
            Filtro_Procedencia: $('#MainContent_ddlProcedencia').val()
        };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_NET
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

function F_VisualizarExcel() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var rptURL = '';
    var Params = 'width=' + (screen.width) + ', height=' + (screen.height) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var CodMenu = '1';
    var Titulo = 'Inventario Actual ';

    rptURL = '../Reportes/Web_Pagina_Excel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

