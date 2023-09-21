var AppSession = "../Planilla/MaestroCategoria.aspx";
var CodigoMenu = 8000;
var CodigoInterno = 90;
$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();


    $('#MainContent_txtDistrito').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
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
            $('#hfRegion').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    $('#MainContent_txtDistritoEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
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
            $('#hfRegion').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });


    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarEliminar_Factura() == false)
                return false;

            if (confirm("Esta seguro de eliminar los documentos seleccionado"))
                F_EliminarTemporal_Factura();

            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false;
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL TRABAJADOR"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.error("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL TRABAJADOR"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }
    });


    $('#MainContent_txtNroDocumento').blur(function () {

        if ($('#MainContent_txtNroDocumento').val().trim() != "")
            if (!F_ValidarDni()) {
                $('#MainContent_txtNroDocumento').select();
            }
        return false;
    });

    $('#MainContent_txtNroHijos').blur(function () {
        if (!F_ValidarNroHijos())
            $('#MainContent_txtNroHijos').select();
        return false;
    });

    $('#MainContent_txtNroHijosEdicion').blur(function () {
        if (!F_ValidarNroHijos())
            $('#MainContent_txtNroHijosEdicion').select();
        return false;
    });

    $('#MainContent_txtRetencionAnteriorAño').blur(function () {
        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorAño'))
            $('#MainContent_txtRetencionAnteriorAño').select();
        return false;
    });

    $('#MainContent_txtRetencionAnteriorMonto').blur(function () {
        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorMonto'))
            $('#MainContent_txtRetencionAnteriorMonto').select();
        return false;
    });

    $('#MainContent_txtRetencionAnteriorAñoEdicion').blur(function () {
        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorAñoEdicion'))
            $('#MainContent_txtRetencionAnteriorAñoEdicion').select();
        return false;
    });

    $('#MainContent_txtRetencionAnteriorMontoEdicion').blur(function () {
        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorMontoEdicion'))
            $('#MainContent_txtRetencionAnteriorMontoEdicion').select();
        return false;
    });
    $('#MainContent_ddlBancos').change(function () {

        if ($(this).val() == 0) {
            $("#MainContent_txtCCI").prop('disabled', true);
            $("#MainContent_txtNumCta").prop('disabled', true);
            $("#MainContent_txtCCI").val('');
            $("#MainContent_txtNumCta").val('');
        } else {
            $("#MainContent_txtCCI").prop('disabled', false);
            $("#MainContent_txtNumCta").prop('disabled', false);
            $("#MainContent_txtCCI").val('');
            $("#MainContent_txtNumCta").val('');
        }

    });
    $('#MainContent_ddlBancosEdicion').change(function () {

        if ($(this).val() == 0) {
            $("#MainContent_txtCCIEdicion").prop('disabled', true);
            $("#MainContent_txtNumCtaEdicion").prop('disabled', true);
            $("#MainContent_txtCCIEdicion").val('');
            $("#MainContent_txtNumCtaEdicion").val('');
        } else {
            $("#MainContent_txtCCIEdicion").prop('disabled', false);
            $("#MainContent_txtNumCtaEdicion").prop('disabled', false);
            $("#MainContent_txtCCIEdicion").val('');
            $("#MainContent_txtNumCtaEdicion").val('');
        }

    });

    $('#MainContent_chkCeseEdicion').click(function () {
        if ($(this).is(':checked')) {
            $("#MainContent_txtFCeseEdicion").removeAttr('disabled');
            $('#lblCeseEdicion').removeAttr('disabled');
            $("#MainContent_txtFCeseEdicion").css('color', 'blue');
            $('#lblCeseEdicion').css('color', '#000');
            checked = 1;
        } else {
            $("#MainContent_txtFCeseEdicion").attr('disabled', 'disabled');
            $('#lblCeseEdicion').attr('disabled', 'disabled');
            $("#MainContent_txtFCeseEdicion").css('color', '#999');
            $('#lblCeseEdicion').css('color', '#999');
            checked = 0;
        }
        console.log(checked);
    });

    F_Controles_Inicializar();

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtCodFamiliaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNroDocumento').css('background', '#FFFFE0');
    $('#MainContent_txtApellidosNombres').css('background', '#FFFFE0');
    $('#MainContent_ddlCategoria').css('background', '#FFFFE0');
    $('#MainContent_ddlProyecto').css('background', '#FFFFE0');
    $('#MainContent_ddlAFP').css('background', '#FFFFE0');
    $('#MainContent_txtCusp').css('background', '#FFFFE0');
    $('#MainContent_txtFechaNacimiento').css('background', '#FFFFE0');
    $('#MainContent_ddlPaisEmisor').css('background', '#FFFFE0');
    $('#MainContent_ddlSexo').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoCivil').css('background', '#FFFFE0');
    $('#MainContent_ddlNacionalidad').css('background', '#FFFFE0');
    $('#MainContent_txtNroHijos').css('background', '#FFFFE0');
    $('#MainContent_txtFechaIngreso').css('background', '#FFFFE0');
    $('#MainContent_txtDireccion').css('background', '#FFFFE0');
    $('#MainContent_txtDistrito').css('background', '#FFFFE0');
    $('#MainContent_ddlEstado').css('background', '#FFFFE0');
    $('#MainContent_txtFechaCese').css('background', '#FFFFE0');
    $('#MainContent_txtPensiones_AFP').css('background', '#FFFFE0');
    $('#MainContent_txtPrima_AFP').css('background', '#FFFFE0');
    $('#MainContent_txtComisionAFP').css('background', '#FFFFE0');
    $('#MainContent_txtAnticipada_AFP').css('background', '#FFFFE0');
    $('#MainContent_txtDescuentoJudicial').css('background', '#FFFFE0');

    $('#MainContent_txtRetencionAnteriorAño').css('background', '#FFFFE0');
    $('#MainContent_ddlRetencionAnteriorCodRetencion').css('background', '#FFFFE0');
    $('#MainContent_txtRetencionAnteriorMonto').css('background', '#FFFFE0');
    $('#MainContent_txtRetencionAnteriorTotalRemuneraciones').css('background', '#FFFFE0');


    $('#MainContent_txtSalarioMensual').css('background', '#FFFFE0');



    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionEdicionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcion2EdicionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionConsultaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtCodFamiliaEdicionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNroDocumentoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtApellidosNombresEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlCategoriaEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlProyectoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlAFPEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtCuspEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtFechaNacimientoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlPaisEmisorEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlSexoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoCivilEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlNacionalidadEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNroHijosEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtFechaIngresoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDireccionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDistritoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtPensiones_AFPEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtPrima_AFPEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtComisionAFPEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtAnticipada_AFPEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescuentoJudicialEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtRetencionAnteriorAñoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlRetencionAnteriorCodRetencionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtRetencionAnteriorMontoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtRetencionAnteriorTotalRemuneracionesEdicion').css('background', '#FFFFE0');


    $('#MainContent_txtSalarioMensualEdicion').css('background', '#FFFFE0');


    $('#MainContent_txtRanteriorPeriodo').css('background', '#FFFFE0');
    $('#MainContent_txtRanteriorMontoRetenido').css('background', '#FFFFE0');
    $('#MainContent_txtRanteriorTotalIngresos').css('background', '#FFFFE0');
    $('#MainContent_txtRanteriorObservacion').css('background', '#FFFFE0');

    $('#MainContent_txtRanteriorApellidosNombres').css('background', '#FFFFE0');
    $('#MainContent_ddlSeguridadSocial').css('background', '#FFFFE0');
    $('#MainContent_ddlSeguridadSocialEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlBancos').css('background', '#FFFFE0');
    $('#MainContent_ddlBancosEdicion').css('background', '#FFFFE0');
    $("#MainContent_txtFCeseEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtFEx").css('background', '#FFFFE0');
    $("#MainContent_txtNumCta").css('background', '#FFFFE0');
    $("#MainContent_txtEstrab").css('background', '#FFFFE0');
    $("#MainContent_txtCcost").css('background', '#FFFFE0');
    $("#MainContent_txtCons").css('background', '#FFFFE0');
    $("#MainContent_txtCCI").css('background', '#FFFFE0');
    $("#MainContent_txtCCI").prop('disabled', true);
    $("#MainContent_txtNumCta").prop('disabled', true);
    $("#MainContent_txtNumCtaEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtEstrabEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtCcostEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtConsEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtCCIEdicion").css('background', '#FFFFE0');
    $("#MainContent_ddlCargo").css('background', '#FFFFE0');
    $("#MainContent_ddlCargoEdicion").css('background', '#FFFFE0');
    $("#MainContent_txtCCIEdicion").prop('disabled', true);
    $("#MainContent_txtNumCtaEdicion").prop('disabled', true);

    F_ListarBancos();
    F_ListarCargos();
    $('#MainContent_txtRanteriorPeriodo').blur(function () {

        if ($('#MainContent_txtRanteriorPeriodo').val().trim() != '') {

            if ($('#MainContent_txtRanteriorPeriodo').val().trim().length != 6) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#MainContent_lblDisplayPeriodo').text("");
                $('#MainContent_txtRanteriorPeriodo').select();
                return false;
            }


            if (isNaN($('#MainContent_txtRanteriorPeriodo').val())) {
                toastr.error("FORMATO DE Periodo INCORRECTO, DEBE SER AAAASS, EJEMPLO: " + Planilla_Periodo.AñoPeriodo2);
                $('#MainContent_lblDisplayPeriodo').text("");
                $('#MainContent_txtRanteriorPeriodo').select();
                return false;
            }



            var SemPro = utF_Planilla_Periodo_Obtener_Por_Periodo($('#MainContent_txtRanteriorPeriodo').val());

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






    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    F_Derecha();

    F_Nuevo();

    F_EmpleadoCampos();
    F_AFPCampos();
});



$(document).on("change", "select[id $= 'MainContent_ddlCategoria']", function () {
    $("#MainContent_txtSalarioMensual").val('0.00');

    F_EmpleadoCampos();
    return true;
});

function F_EmpleadoCampos() {
    if ($("#MainContent_ddlCategoria option:selected").text() === 'EMPLEADOS') {
        $("#tdSalarioMensualLabel").css('display', "block");
        $(".tdEmpleado").show();
        //$("#MainContent_txtAnticipada_AFP").prop('disabled', true);
    } else {
        $("#tdSalarioMensualLabel").css('display', "none");
        $(".tdEmpleado").hide();
        $("#MainContent_ddlCargo").children("option[value='0']").prop('selected', true);
        //$("#MainContent_txtAnticipada_AFP").prop('disabled', true);
    }
    return true;
}

$(document).on("change", "select[id $= 'MainContent_ddlCategoriaEdicion']", function () {
    $("#MainContent_txtSalarioMensualEdicion").val('0.00');

    F_EmpleadoCamposEdicion();
    return true;
});

function F_EmpleadoCamposEdicion() {
    if ($("#MainContent_ddlCategoriaEdicion option:selected").text() === 'EMPLEADOS') {
        $("#tdSalarioMensualLabelEdicion").css('display', "block");
        $(".tdEmpleadoEdicion").show();
        //$("#MainContent_txtAnticipada_AFP").prop('disabled', true);
    } else {
        $("#tdSalarioMensualLabelEdicion").css('display', "none");
        $(".tdEmpleadoEdicion").hide();
        $("#MainContent_ddlCargoEdicion").children("option[value='0']").show();
        //$("#MainContent_txtAnticipada_AFP").prop('disabled', true);
    }
    return true;
}

//---------------------------------------------------------------------------

$(document).on("change", "select[id $= 'MainContent_ddlAFP']", function () {
    $("#MainContent_txtPrima_AFP").val('0.00');
    $("#MainContent_txtComisionAFP").val('0.00');
    $("#MainContent_txtAnticipada_AFP").val('0.00');

    F_AFPCampos();
    return true;
});

function F_AFPCampos() {
    if ($("#MainContent_ddlAFP").val() === '1') {
        $("#MainContent_txtPrima_AFP").prop('disabled', true);
        $("#MainContent_txtComisionAFP").prop('disabled', true);
        $("#MainContent_txtAnticipada_AFP").prop('disabled', true);
    } else {
        $("#MainContent_txtPrima_AFP").prop('disabled', false);
        $("#MainContent_txtComisionAFP").prop('disabled', false);
        $("#MainContent_txtAnticipada_AFP").prop('disabled', false);
    }
    return true;
}

$(document).on("change", "select[id $= 'MainContent_ddlAFPEdicion']", function () {
    $("#MainContent_txtPrima_AFPEdicion").val('0.00');
    $("#MainContent_txtComisionAFPEdicion").val('0.00');
    $("#MainContent_txtAnticipada_AFPEdicion").val('0.00');
    F_AFPCamposEdicion();
    return true;
});

function F_AFPCamposEdicion() {
    if ($("#MainContent_ddlAFPEdicion").val() === '1') {
        $("#MainContent_txtPrima_AFPEdicion").prop('disabled', true);
        $("#MainContent_txtComisionAFPEdicion").prop('disabled', true);
        $("#MainContent_txtAnticipada_AFPEdicion").prop('disabled', true);
    } else {
        $("#MainContent_txtPrima_AFPEdicion").prop('disabled', false);
        $("#MainContent_txtComisionAFPEdicion").prop('disabled', false);
        $("#MainContent_txtAnticipada_AFPEdicion").prop('disabled', false);
    }
    return true;
}

function F_ValidarDni() {
    var retorno = true;

    if ($('#MainContent_txtNroDocumento').val().length != 8 && $('#MainContent_txtNroDocumento').val().length > 1) {
        toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
        $('#MainContent_txtNroDocumento').select();
        retorno = false;
        return false;
    } else {
        if (isNaN($('#MainContent_txtNroDocumento').val())) {
            toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
            $('#MainContent_txtNroDocumento').select();
            retorno = false;
            return false;
        }

        if (!ValidarRuc($('#MainContent_txtNroDocumento').val())) {
            toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
            $('#MainContent_txtNroDocumento').select();
            retorno = false;
            return false;
        }
    }


    return retorno;
}


function F_ValidarDniEdicion() {
    var retorno = true;

    if ($('#MainContent_txtNroDocumentoEdicion').val().length != 8 && $('#MainContent_txtNroDocumentoEdicion').val().length > 1) {
        toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
        $('#MainContent_txtNroDocumentoEdicion').select();
        retorno = false;
        return false;
    } else {
        if (isNaN($('#MainContent_txtNroDocumentoEdicion').val())) {
            toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
            $('#MainContent_txtNroDocumentoEdicion').select();
            retorno = false;
            return false;
        }

        if (!ValidarRuc($('#MainContent_txtNroDocumentoEdicion').val())) {
            toastr.warning("DEBE ESPECIFICAR UN DNI CORRECTO");
            $('#MainContent_txtNroDocumentoEdicion').select();
            retorno = false;
            return false;
        }
    }


    return retorno;
}



function F_ValidarNroHijos() {
    var retorno = true;

    if ($('#MainContent_txtNroHijos').val().trim() != "") {
        if (isNaN($('#MainContent_txtNroHijos').val())) {
            toastr.warning("Nro. Hijos incorrecto");
            retorno = false;
            return false;
        }

        if (Number($('#MainContent_txtNroHijos').val()) < 0) {
            toastr.warning("Nro. Hijos incorrecto");
            retorno = false;
            return false;
        }
    }

    return retorno;
}

function F_ValidarNumerico(control) {
    var retorno = true;

    if ($(control).val().trim() != "") {
        if (isNaN($(control).val())) {
            toastr.warning("Valor Numerico Incorrecto");
            retorno = false;
            return false;
        }

        if (Number($(control).val()) < 0) {
            toastr.warning("Valor Numerico Incorrecto");
            retorno = false;
            return false;
        }
    }

    return retorno;
}

function F_ValidarNroHijosEdicion() {
    var retorno = true;

    if ($('#MainContent_txtNroHijosEdicion').val().trim() != "") {
        if (isNaN($('#MainContent_txtNroHijosEdicion').val())) {
            toastr.warning("Nro. Hijos incorrecto");
            retorno = false;
            return false;
        }

        if (Number($('#MainContent_txtNroHijosEdicion').val()) < 0) {
            toastr.warning("Nro. Hijos incorrecto");
            retorno = false;
            return false;
        }
    }

    return retorno;
}


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
//BRUNO
function F_ListarBancos() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_ListarBancos',
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $("#MainContent_ddlBancos").append(new Option('EFECTIVO', 0));
            $("#MainContent_ddlBancosEdicion").append(new Option('EFECTIVO', 0));
            for (var i = 0; i < data.length; i++) {
                $("#MainContent_ddlBancos").append(new Option(data[i].DscBanco, data[i].CodBanco));
                $("#MainContent_ddlBancosEdicion").append(new Option(data[i].DscBanco, data[i].CodBanco));
            }
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
function F_ListarCargos() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Servicios/Servicios.asmx/F_Listar_Planilla_Cargo",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $("#MainContent_ddlCargo").append(new Option("SELECCIONE", 0));
            $("#MainContent_ddlCargoEdicion").append(new Option("SELECCIONE", 0));
            for (var i = 0; i < data.length; i++) {
                $("#MainContent_ddlCargo").append(new Option(data[i].DscCargo, data[i].CodCargo));
                $("#MainContent_ddlCargoEdicion").append(new Option(data[i].DscCargo, data[i].CodCargo));
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

function F_Controles_Inicializar() {

    utF_Conceptos_Combos('#MainContent_ddlTipoDocumento', 70);
    utF_Conceptos_Combos('#MainContent_ddlTipoDocumentoEdicion', 70);

    //categoria
    utF_Planilla_Categoria_Listar('#MainContent_ddlCategoria', '');
    utF_Planilla_Categoria_Listar('#MainContent_ddlCategoriaEdicion', '');

    //proyecto
    utF_Planilla_Proyecto_Listar('#MainContent_ddlProyecto', 0, 1, '');
    utF_Planilla_Proyecto_Listar('#MainContent_ddlProyectoEdicion', 0, 1, '');


    //AFP
    utF_Planilla_AFP_Listar('#MainContent_ddlAFP', '');
    utF_Planilla_AFP_Listar('#MainContent_ddlAFPEdicion', '');

    //estados
    utF_Conceptos_Combos('#MainContent_ddlEstado', 27);
    utF_Conceptos_Combos('#MainContent_ddlEstadoEdicion', 27);

    //utF_Conceptos_Combos('#MainContent_ddlEstadoEdicion', 27);

    //utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboral', '');
    //utF_Planilla_RegimenLaboral_Listar('#MainContent_ddlRegimenLaboralEdicion', '');    
    return true;
}

function F_ValidarGrabarDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if (!F_ValidarDni())
            Cadena = Cadena + '<p></p>' + 'Nro. Documento';

        if ($(Cuerpo + 'txtApellidosNombres').val() == '')
            Cadena = Cadena + '<p></p>' + 'Apellidos y Nombres';

        if ($(Cuerpo + 'txtCusp').val() == '' && $(Cuerpo + 'ddlAFP').val() != '1')
            Cadena = Cadena + '<p></p>' + 'Cusp';

        if ($(Cuerpo + 'txtNroHijos').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro. Hijos';

        if (!F_ValidarNroHijos())
            Cadena = Cadena + '<p></p>' + 'Nro. Hijos';

        if ($(Cuerpo + 'txtDireccion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

        if ($(Cuerpo + 'txtDistrito').val().trim() == '' || $('#hfDistrito').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Distrito';

        if (isNaN($(Cuerpo + 'txtPensiones_AFP').val()))
            Cadena = Cadena + '<p></p>' + 'Pensiones AFP';

        if ($(Cuerpo + 'ddlAFP').val() == 1 && Number($(Cuerpo + 'txtPensiones_AFP').val()) <= 0 | $(Cuerpo + 'txtPensiones_AFP').val().trim() == '')
            Cadena = Cadena + '<p></p>' + 'Pensiones AFP debe ser mayor a 0';

        if (isNaN($(Cuerpo + 'txtPrima_AFP').val()))
            Cadena = Cadena + '<p></p>' + 'Prima AFP';

        if (isNaN($(Cuerpo + 'txtComisionAFP').val()))
            Cadena = Cadena + '<p></p>' + 'Comision AFP';

        if (isNaN($(Cuerpo + 'txtAnticipada_AFP').val()))
            Cadena = Cadena + '<p></p>' + 'Anticipada AFP';

        if (isNaN($(Cuerpo + 'txtDescuentoJudicial').val()))
            Cadena = Cadena + '<p></p>' + 'Descuento Judicial';

        if ((isNaN($(Cuerpo + 'txtSalarioMensual').val()) | $(Cuerpo + 'txtSalarioMensual').val() == '') && $(Cuerpo + 'ddlCategoria').val() == '9')
            Cadena = Cadena + '<p></p>' + 'Salario mensual de EMPLEADO';

        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorMonto'))
            Cadena = Cadena + '<p></p>' + 'Monto de Retencion Anterior';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {

    var objEntidad = {};
    objEntidad["CodTrabajador"] = Number('0');
    objEntidad["CodCategoria"] = Number($('#MainContent_ddlCategoria').val());
    objEntidad["CodProyecto"] = Number($('#MainContent_ddlProyecto').val());
    objEntidad["CodAFP"] = Number($('#MainContent_ddlAFP').val());
    objEntidad["CodTipoDocumento"] = Number($('#MainContent_ddlTipoDocumento').val());
    objEntidad["NroDocumento"] = $('#MainContent_txtNroDocumento').val();
    objEntidad["CUSP"] = $('#MainContent_txtCusp').val();
    objEntidad["FechaNacimiento"] = $('#MainContent_txtFechaNacimiento').val();
    objEntidad["PaisEmisor"] = $('#MainContent_ddlPaisEmisor').val();
    objEntidad["ApellidosNombres"] = $('#MainContent_txtApellidosNombres').val();
    objEntidad["Sexo"] = $('#MainContent_ddlSexo').val();
    objEntidad["EstadoCivil"] = $('#MainContent_ddlEstadoCivil').val();
    objEntidad["Nacionalidad"] = $('#MainContent_ddlNacionalidad').val();
    objEntidad["Direccion"] = $('#MainContent_txtDireccion').val();
    objEntidad["CodDistrito"] = Number($('#hfDistrito').val());
    objEntidad["FechaIngreso"] = $('#MainContent_txtFechaIngreso').val();
    objEntidad["FechaCese"] = $('#MainContent_txtFechaIngreso').val();
    objEntidad["NroHijos"] = Number($('#MainContent_txtNroHijos').val());
    objEntidad["Pensiones_AFP"] = Number($('#MainContent_txtPensiones_AFP').val());
    objEntidad["Prima_AFP"] = Number($('#MainContent_txtPrima_AFP').val());
    objEntidad["Comision_AFP"] = Number($('#MainContent_txtComisionAFP').val());
    objEntidad["Anticipada_AFP"] = Number($('#MainContent_txtAnticipada_AFP').val());
    objEntidad["DescuentoJudicial"] = Number($('#MainContent_txtDescuentoJudicial').val());
    objEntidad["CodEstado"] = Number($('#MainContent_ddlEstado').val());
    objEntidad["CodSeguridadSocial"] = Number($('#MainContent_ddlSeguridadSocial').val());
    objEntidad["RetencionAnteriorAño"] = 2000;
    objEntidad["RetencionAnteriorCodRetencion"] = 1;
    objEntidad["RetencionAnteriorMonto"] = Number($('#MainContent_txtRetencionAnteriorMonto').val());
    objEntidad["RetencionAnteriorTotalRemuneraciones"] = Number($('#MainContent_txtRetencionAnteriorTotalRemuneraciones').val());
    objEntidad["SalarioMensual"] = Number($('#MainContent_txtSalarioMensual').val());
    objEntidad["CodBanco"] = Number($('#MainContent_ddlBancos').val());
    objEntidad["NumCuenta"] = $("#MainContent_txtNumCta").val();
    objEntidad["CCI"] = $("#MainContent_txtCCI").val();
    objEntidad["AreaTrabajo"] = $("#MainContent_txtEstrab").val();
    objEntidad["CentroCostos"] = $("#MainContent_txtCcost").val();
    objEntidad["Consorciado"] = $("#MainContent_txtCons").val();
    objEntidad["CodCargo"] = $("#MainContent_ddlCargo").val();
    objEntidad["RegistroOperacion"] = "Insert";


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Trabajador_Actualizar',
        data: JSON.stringify(objEntidad),
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.MsgError === "SE GRABO CORRECTAMENTE") {
                    toastr.success('SE GRABO CORRECTAMENTE');
                    F_Nuevo();
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

    return true;
}

function F_Nuevo() {


    $('#MainContent_ddlCategoria').val('1');
    $('#MainContent_ddlProyecto').val('1');
    $('#MainContent_ddlAFP').val('1');
    $('#MainContent_ddlTipoDocumento').val('1');
    $('#MainContent_txtNroDocumento').val('');
    $('#MainContent_txtCusp').val('');
    $('#MainContent_ddlPaisEmisor').val('PERU');
    $('#MainContent_txtApellidosNombres').val('');
    $('#MainContent_ddlSexo').val('1');
    $('#MainContent_ddlEstadoCivil').val('1');
    $('#MainContent_ddlNacionalidad').val('1');
    $('#MainContent_txtDireccion').val('');
    $('#hfDistrito').val('0');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtNroHijos').val('');
    $('#MainContent_txtPensiones_AFP').val('');
    $('#MainContent_txtPrima_AFP').val('');
    $('#MainContent_txtComisionAFP').val('');
    $('#MainContent_txtAnticipada_AFP').val('');
    $('#MainContent_txtDescuentoJudicial').val('');
    $('#MainContent_ddlEstado').val('1');
    $('#MainContent_txtRetencionAnteriorMontoEdicion').val('');
    $("#MainContent_ddlBancos").val(0);
    $("#MainContent_ddlCargo").val(0);
    $("#MainContent_txtNumCta").val('');
    $("#MainContent_txtCCI").val('');
    $("#MainContent_txtEstrab").val('');
    $("#MainContent_txtCcost").val('');
    $("#MainContent_txtCons").val('');
    $('#MainContent_txtSalarioMensual').val('0.00');

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());


    $('#hfCodigo').val(0);
    return false;
}

function F_Buscar() {

    try {
        var objParams = {
            Filtro_Descripcion: $("#MainContent_txtDescripcionConsulta").val()

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
                if (str_mensaje_operacion != "")
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
        return false;
    }

}

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false;
    try {
        var imgID = Fila.id;
        var hfCodTrabajador = '#' + imgID.replace('imgAnularDocumento', 'hfID');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblApellidosNombres');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL TRABAJADOR " + $(lblDescripcion).text().toUpperCase()))
            return false;

        var objEntidad = {};
        objEntidad["CodTrabajador"] = $(hfCodTrabajador).val();

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Trabajador_Eliminar',
            data: JSON.stringify(objEntidad),
            dataType: "json",
            async: false,
            success: function (dbObject) {
                var data = dbObject.d;
                try {
                    if (data.MsgError === "SE ELIMINO CORRECTAMENTE") {
                        toastr.success('SE ELIMINO CORRECTAMENTE');
                        F_Buscar();
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


    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    try {

        var imgID = Fila.id;
        var hfCodTrabajador = '#' + imgID.replace('imgEditarRegistro', 'hfID');
        var hfCodCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodCategoria');
        var hfCodProyecto = '#' + imgID.replace('imgEditarRegistro', 'hfCodProyecto');
        var hfCodAFP = '#' + imgID.replace('imgEditarRegistro', 'hfCodAFP');
        var hfCodTipoDocumento = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoDocumento');
        var hfNroDocumento = '#' + imgID.replace('imgEditarRegistro', 'hfNroDocumento');
        var hfCUSP = '#' + imgID.replace('imgEditarRegistro', 'hfCUSP');
        var hfFechaNacimiento = '#' + imgID.replace('imgEditarRegistro', 'hfFechaNacimiento');
        var hfPaisEmisor = '#' + imgID.replace('imgEditarRegistro', 'hfPaisEmisor');
        var hfApellidosNombres = '#' + imgID.replace('imgEditarRegistro', 'hfApellidosNombres');
        var hfSexo = '#' + imgID.replace('imgEditarRegistro', 'hfSexo');
        var hfEstadoCivil = '#' + imgID.replace('imgEditarRegistro', 'hfEstadoCivil');
        var hfNacionalidad = '#' + imgID.replace('imgEditarRegistro', 'hfNacionalidad');
        var hfDireccion = '#' + imgID.replace('imgEditarRegistro', 'hfDireccion');
        var hfCodDistrito = '#' + imgID.replace('imgEditarRegistro', 'hfCodDistrito');
        var hfDistrito = '#' + imgID.replace('imgEditarRegistro', 'hfDistrito');
        var hfFechaIngreso = '#' + imgID.replace('imgEditarRegistro', 'hfFechaIngreso');
        var hfFechaCese = '#' + imgID.replace('imgEditarRegistro', 'hfFechaCese');
        var hfNroHijos = '#' + imgID.replace('imgEditarRegistro', 'hfNroHijos');
        var hfPensiones_AFP = '#' + imgID.replace('imgEditarRegistro', 'hfPensiones_AFP');
        var hfPrima_AFP = '#' + imgID.replace('imgEditarRegistro', 'hfPrima_AFP');
        var hfComision_AFP = '#' + imgID.replace('imgEditarRegistro', 'hfComision_AFP');
        var hfAnticipada_AFP = '#' + imgID.replace('imgEditarRegistro', 'hfAnticipada_AFP');
        var hfDescuentoJudicial = '#' + imgID.replace('imgEditarRegistro', 'hfDescuentoJudicial');
        var hfRetencionAnteriorMonto = '#' + imgID.replace('imgEditarRegistro', 'hfRetencionAnteriorMonto');
        var hfRetencionAnteriorTotalRemuneraciones = '#' + imgID.replace('imgEditarRegistro', 'hfRetencionAnteriorTotalRemuneraciones');
        var hfSalarioMensual = '#' + imgID.replace('imgEditarRegistro', 'hfSalarioMensual');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var hfCodSeguridadSocial = '#' + imgID.replace('imgEditarRegistro', 'hfCodSeguridadSocial');
        var hfCodBanco = '#' + imgID.replace('imgEditarRegistro', 'hfCodBanco');
        var hfNumeroCuenta = '#' + imgID.replace('imgEditarRegistro', 'hfNumeroCuenta');
        var hfCCI = '#' + imgID.replace('imgEditarRegistro', 'hfCCI');
        var hfAreaTrabajo = '#' + imgID.replace('imgEditarRegistro', 'hfAreaTrabajo');
        var hfCentroCostos = '#' + imgID.replace('imgEditarRegistro', 'hfCentroCostos');
        var hfConsorciado = '#' + imgID.replace('imgEditarRegistro', 'hfConsorciado');
        var hfCodCargo = '#' + imgID.replace('imgEditarRegistro', 'hfCodCargo');
        $('#hfCodigo').val($(hfCodTrabajador).val());
        $('#MainContent_ddlCategoriaEdicion').val($(hfCodCategoria).val());
        $('#MainContent_ddlProyectoEdicion').val($(hfCodProyecto).val());
        $('#MainContent_ddlAFPEdicion').val($(hfCodAFP).val());
        $('#MainContent_ddlTipoDocumentoEdicion').val($(hfCodTipoDocumento).val());
        $('#MainContent_txtNroDocumentoEdicion').val($(hfNroDocumento).val());
        $('#MainContent_txtCuspEdicion').val($(hfCUSP).val());
        $('#MainContent_txtFechaNacimientoEdicion').val($(hfFechaNacimiento).val());
        $('#MainContent_ddlPaisEmisorEdicion').val($(hfPaisEmisor).val());
        $('#MainContent_txtApellidosNombresEdicion').val($(hfApellidosNombres).val());
        $('#MainContent_ddlSexoEdicion').val($(hfSexo).val());
        $('#MainContent_ddlEstadoCivilEdicion').val($(hfEstadoCivil).val());
        $('#MainContent_ddlNacionalidadEdicion').val($(hfNacionalidad).val());
        $('#MainContent_txtDireccionEdicion').val($(hfDireccion).val());
        $('#hfDistrito').val($(hfCodDistrito).val());
        $('#MainContent_txtDistritoEdicion').val($(hfDistrito).val());
        $('#MainContent_txtFechaIngresoEdicion').val($(hfFechaIngreso).val());
        if ($(hfFechaCese).val().length === 0) {
            $("#MainContent_txtFCeseEdicion").attr('disabled', 'disabled');
            $('#lblCeseEdicion').attr('disabled', 'disabled');
            $("#MainContent_txtFCeseEdicion").css('color', '#999');
            $('#lblCeseEdicion').css('color', '#999');
            $('#MainContent_chkCeseEdicion').prop('checked', false);

            $('#MainContent_txtFCeseEdicion').val($.datepicker.formatDate('dd/mm/yy', new Date()));
        } else {
            $("#MainContent_txtFCeseEdicion").removeAttr('disabled');
            $('#lblCeseEdicion').removeAttr('disabled');
            $("#MainContent_txtFCeseEdicion").css('color', 'blue');
            $('#lblCeseEdicion').css('color', '#000');
            $('#MainContent_chkCeseEdicion').prop('checked', true);

            $('#MainContent_txtFCeseEdicion').val($(hfFechaCese).val());
        }

        $('#MainContent_txtNroHijosEdicion').val($(hfNroHijos).val());
        $('#MainContent_txtPensiones_AFPEdicion').val($(hfPensiones_AFP).val());
        $('#MainContent_txtPrima_AFPEdicion').val($(hfPrima_AFP).val());
        $('#MainContent_txtComisionAFPEdicion').val($(hfComision_AFP).val());
        $('#MainContent_txtAnticipada_AFPEdicion').val($(hfAnticipada_AFP).val());
        $('#MainContent_txtDescuentoJudicialEdicion').val($(hfDescuentoJudicial).val());
        $('#MainContent_ddlEstadoEdicion').val($(hfCodEstado).val());
        $('#MainContent_txtRetencionAnteriorMontoEdicion').val($(hfRetencionAnteriorMonto).val());
        $('#MainContent_txtRetencionAnteriorTotalRemuneracionesEdicion').val($(hfRetencionAnteriorTotalRemuneraciones).val());
        $('#MainContent_txtSalarioMensualEdicion').val($(hfSalarioMensual).val());
        $('#MainContent_ddlSeguridadSocialEdicion').val($(hfCodSeguridadSocial).val());
        if ($(hfCodBanco).val().length === 0) {
            $('#MainContent_ddlBancosEdicion').val(0);
        } else {
            $('#MainContent_ddlBancosEdicion').val($(hfCodBanco).val());
        }
        $('#MainContent_txtNumCtaEdicion').val($(hfNumeroCuenta).val());
        $('#MainContent_txtCCIEdicion').val($(hfCCI).val());
        $('#MainContent_txtEstrabEdicion').val($(hfAreaTrabajo).val());
        $('#MainContent_txtCcostEdicion').val($(hfCentroCostos).val());
        $('#MainContent_txtConsEdicion').val($(hfConsorciado).val());
        if ($(hfCodCargo).val().length === 0) {
            $('#MainContent_ddlCargoEdicion').val(0);
        } else {
            $('#MainContent_ddlCargoEdicion').val($(hfCodCargo).val());
        }

        F_AFPCamposEdicion();
        F_EmpleadoCamposEdicion();
        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Trabajador",
            title_html: true,
            height: 380,
            width: 930,
            autoOpen: false
        });

        $('#divEdicionRegistro').dialog('open');

        return false;
    }

    catch (e) {
        toastr.error("Error Detectado: " + e);
        return false;
    }

}
var checked = 0;
function F_EdicionRegistro() {

    var objEntidad = {};
    objEntidad["CodTrabajador"] = Number($('#hfCodigo').val());
    objEntidad["CodCategoria"] = Number($('#MainContent_ddlCategoriaEdicion').val());
    objEntidad["CodProyecto"] = Number($('#MainContent_ddlProyectoEdicion').val());
    objEntidad["CodAFP"] = Number($('#MainContent_ddlAFPEdicion').val());
    objEntidad["CodTipoDocumento"] = Number($('#MainContent_ddlTipoDocumentoEdicion').val());
    objEntidad["NroDocumento"] = $('#MainContent_txtNroDocumentoEdicion').val();
    objEntidad["CUSP"] = $('#MainContent_txtCuspEdicion').val();
    objEntidad["FechaNacimiento"] = $('#MainContent_txtFechaNacimientoEdicion').val();
    objEntidad["PaisEmisor"] = $('#MainContent_ddlPaisEmisorEdicion').val();
    objEntidad["ApellidosNombres"] = $('#MainContent_txtApellidosNombresEdicion').val();
    objEntidad["Sexo"] = $('#MainContent_ddlSexoEdicion').val();
    objEntidad["EstadoCivil"] = $('#MainContent_ddlEstadoCivilEdicion').val();
    objEntidad["Nacionalidad"] = $('#MainContent_ddlNacionalidadEdicion').val();
    objEntidad["Direccion"] = $('#MainContent_txtDireccionEdicion').val();
    objEntidad["CodDistrito"] = Number($('#hfDistrito').val());
    objEntidad["FechaIngreso"] = $('#MainContent_txtFechaIngresoEdicion').val();
    if (checked === 1) {
        objEntidad["FechaCese"] = $('#MainContent_txtFCeseEdicion').val();
    } else {
        objEntidad["FechaCese"] = null;
    }
    objEntidad["NroHijos"] = Number($('#MainContent_txtNroHijosEdicion').val());
    objEntidad["Pensiones_AFP"] = Number($('#MainContent_txtPensiones_AFPEdicion').val());
    objEntidad["Prima_AFP"] = Number($('#MainContent_txtPrima_AFPEdicion').val());
    objEntidad["Comision_AFP"] = Number($('#MainContent_txtComisionAFPEdicion').val());
    objEntidad["Anticipada_AFP"] = Number($('#MainContent_txtAnticipada_AFPEdicion').val());
    objEntidad["DescuentoJudicial"] = Number($('#MainContent_txtDescuentoJudicialEdicion').val());
    objEntidad["CodEstado"] = Number($('#MainContent_ddlEstadoEdicion').val());
    objEntidad["CodSeguridadSocial"] = Number($('#MainContent_ddlSeguridadSocialEdicion').val());
    objEntidad["RetencionAnteriorAño"] = 2000;
    objEntidad["RetencionAnteriorCodRetencion"] = 1;
    objEntidad["RetencionAnteriorMonto"] = Number($('#MainContent_txtRetencionAnteriorMontoEdicion').val());
    objEntidad["RetencionAnteriorTotalRemuneraciones"] = Number($('#MainContent_txtRetencionAnteriorTotalRemuneracionesEdicion').val());
    objEntidad["SalarioMensual"] = Number($('#MainContent_txtSalarioMensualEdicion').val());
    objEntidad["CodBanco"] = Number($('#MainContent_ddlBancosEdicion').val());
    objEntidad["NumCuenta"] = $("#MainContent_txtNumCtaEdicion").val();
    objEntidad["CCI"] = $("#MainContent_txtCCIEdicion").val();
    objEntidad["AreaTrabajo"] = $("#MainContent_txtEstrabEdicion").val();
    objEntidad["CentroCostos"] = $("#MainContent_txtCcostEdicion").val();
    objEntidad["Consorciado"] = $("#MainContent_txtConsEdicion").val();
    objEntidad["CodCargo"] = $("#MainContent_ddlCargoEdicion").val();
    objEntidad["RegistroOperacion"] = "Edit";


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Trabajador_Actualizar',
        data: JSON.stringify(objEntidad),
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.MsgError === "SE ACTUALIZO CORRECTAMENTE") {
                    toastr.success('SE ACTUALIZO CORRECTAMENTE');

                    $('#divEdicionRegistro').dialog('close');

                    F_Buscar();
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

    return true;
}

function F_ValidarEdicionDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if (!F_ValidarDniEdicion())
            Cadena = Cadena + '<p></p>' + 'Nro. Documento';

        if ($(Cuerpo + 'txtApellidosNombresEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Apellidos y Nombres';

        if ($(Cuerpo + 'txtCuspEdicion').val() == '' && $(Cuerpo + 'ddlAFP').val() != '1')
            Cadena = Cadena + '<p></p>' + 'Cusp';

        if ($(Cuerpo + 'txtNroHijosEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro. Hijos';

        if (!F_ValidarNroHijosEdicion())
            Cadena = Cadena + '<p></p>' + 'Nro. Hijos';

        if ($(Cuerpo + 'txtDireccionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

        if ($(Cuerpo + 'txtDistritoEdicion').val().trim() == '' || $('#hfDistrito').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Distrito';

        if (isNaN($(Cuerpo + 'txtPensiones_AFPEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Pensiones AFP';

        if ($(Cuerpo + 'ddlAFPEdicion').val() == 1 && Number($(Cuerpo + 'txtPensiones_AFPEdicion').val()) <= 0 | $(Cuerpo + 'txtPensiones_AFPEdicion').val().trim() == '')
            Cadena = Cadena + '<p></p>' + 'Pensiones AFP debe ser mayor a 0';

        if (isNaN($(Cuerpo + 'txtPrima_AFPEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Prima AFP';

        if (isNaN($(Cuerpo + 'txtComisionAFPEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Comision AFP';

        if (isNaN($(Cuerpo + 'txtAnticipada_AFPEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Anticipada AFP';

        if (isNaN($(Cuerpo + 'txtDescuentoJudicialEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Descuento Judicial';

        if ((isNaN($(Cuerpo + 'txtSalarioMensualEdicion').val()) | $(Cuerpo + 'txtSalarioMensualEdicion').val() == '') && $(Cuerpo + 'ddlCategoriaEdicion').val() == '9')
            Cadena = Cadena + '<p></p>' + 'Salario mensual de EMPLEADO';

        if (!F_ValidarNumerico('#MainContent_txtRetencionAnteriorMontoEdicion'))
            Cadena = Cadena + '<p></p>' + 'Monto de Retencion Anterior';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.error("Error Detectado: " + e);
    }
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (!isNaN(valor)) {
        if (valor.length < 11) {
            if (valor.length == 8)
                return true;
        } else if (valor.length == 11) {
            suma = 0
            x = 6
            for (i = 0; i < valor.length - 1; i++) {
                if (i == 4) x = 8
                digito = valor.charAt(i) - '0';
                x--
                if (i == 0) suma += (digito * x)
                else suma += (digito * x)
            }
            resto = suma % 11;
            resto = 11 - resto

            if (resto >= 10) resto = resto - 10;
            if (resto == valor.charAt(valor.length - 1) - '0') {
                return true
            }
        }
    }
    return false
}

function esnumero(campo) { return (!(isNaN(campo))); }

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

function F_RetencionesAnteriores(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 80009001, '') === "0") return false;
    try {
        var imgID = Fila.id;
        var hfCodTrabajador = '#' + imgID.replace('imgRetencionesAnteiores', 'hfID');
        var hfApellidosNombres = '#' + imgID.replace('imgRetencionesAnteiores', 'hfApellidosNombres');

        $('#hfCodigo').val($(hfCodTrabajador).val());
        $('#hfIdRetencionAnterior').val("0");
        $('#MainContent_txtRanteriorApellidosNombres').val($(hfApellidosNombres).val());
        $("#MainContent_txtRanteriorPeriodo").val('');
        $('#MainContent_txtRanteriorMontoRetenido').val('');
        $('#MainContent_txtRanteriorTotalIngresos').val('');
        $("#MainContent_txtRanteriorObservacion").val('');
        $("#MainContent_txtFEx").val('');

        F_Buscar_Retenciones_Anteriores($(hfCodTrabajador).val());
        return false;
    }

    catch (e) {
        toastr.error("Error Detectado: " + e);
        return false;
    }

}

function F_Buscar_Retenciones_Anteriores(CodTrabajador) {

    var objParams = {
        Filtro_CodTrabajador: CodTrabajador

    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);

    F_Buscar_Retenciones_Anteriores_NET(arg, function (result) {
        var str_resultado_operacion = "";
        var str_mensaje_operacion = "";

        str_resultado_operacion = result.split('~')[0];
        str_mensaje_operacion = result.split('~')[1];
        MostrarEspera(false);
        if (str_resultado_operacion == "1") {

            F_Update_Division_HTML('div_grvRetenciones', result.split('~')[2]);

            if (str_mensaje_operacion != "")
                toastr.warning(result.split('~')[1]);

        }
        else {
            toastr.warning(result.split('~')[1]);
        }

        $("#divRetenciones").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Retenciones Anteriores",
            title_html: true,
            height: 350,
            width: 900,
            autoOpen: false
        });

        $('#divRetenciones').dialog('open');

        return false;

    });
    return true;
}

function F_RetencionesAnteriores_Insertar() {

    var fecha = $('#MainContent_txtFEx').val();
    var arrFecha = fecha.split('/');
    var periodo = arrFecha[2] + arrFecha[1];

    if (Number($("#hfIdRetencionAnterior").val()) > 0) {
        F_RetencionesAnteriores_Edicion();
        return true;
    }


    if (Number($('#hfCodigo').val()) == 0) {
        toastr.error("Error al insertar, no hay codtrabajador");
        return false
    }


    if (Number($("#MainContent_lblCodPeriodo").text()) == 0) {
        toastr.error("Error al insertar, ha seleccionado un periodo");
        return false
    }

    if (isNaN($("#MainContent_txtRanteriorMontoRetenido").val()) || $("#MainContent_txtRanteriorMontoRetenido").val().trim() == "") {
        toastr.error("Monto retenido no es numerico");
        return false
    }

    if (Number($("#MainContent_txtRanteriorMontoRetenido").val()) < 0) {
        toastr.error("Monto no valido");
        return false
    }


    if (isNaN($("#MainContent_txtRanteriorTotalIngresos").val()) || $("#MainContent_txtRanteriorTotalIngresos").val().trim() == "") {
        toastr.error("Total Ingresos no es numerico");
        return false
    }

    if (Number($("#MainContent_txtRanteriorTotalIngresos").val()) <= 0) {
        toastr.error("Total Ingresos no valido");
        return false
    }

    if (Number($("#MainContent_lblCodPeriodo").text()) == 0) {
        toastr.error("Error al insertar, ha seleccionado un periodo");
        return false
    }

    if (Number(periodo) != $('#MainContent_txtRanteriorPeriodo').val()) {
        toastr.error("La Fecha Exacta de la Retencion es inferior o mayor al mes del periodo");
        return false;
    }

    try {

        var objEntidad = {};
        objEntidad["IdRetencion"] = Number('0');
        objEntidad["CodTrabajador"] = Number($('#hfCodigo').val());
        objEntidad["CodPeriodo"] = Number($("#MainContent_lblCodPeriodo").text());
        objEntidad["MontoRetenido"] = Number($('#MainContent_txtRanteriorMontoRetenido').val());
        objEntidad["TotalIngresos"] = Number($('#MainContent_txtRanteriorTotalIngresos').val());
        objEntidad["FechaExacta"] = $('#MainContent_txtFEx').val();
        objEntidad["Observacion"] = $("#MainContent_txtRanteriorObservacion").val();
        objEntidad["RegistroOperacion"] = "Insert";


        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_Trabajador_Retenciones_Anteriores_Actualizar',
            data: JSON.stringify(objEntidad),
            dataType: "json",
            async: false,
            success: function (dbObject) {
                var data = dbObject.d;
                try {
                    if (data.MsgError === "SE GRABO CORRECTAMENTE") {
                        toastr.success('SE GRABO CORRECTAMENTE');

                        $("#MainContent_txtRanteriorPeriodo").val("");
                        $("#MainContent_lblDisplayPeriodo").val("");
                        $("#MainContent_lblCodPeriodo").text(0);
                        $('#MainContent_txtRanteriorMontoRetenido').val("");
                        $('#MainContent_txtRanteriorTotalIngresos').val("");
                        $("#MainContent_txtRanteriorObservacion").val("");
                        $('#MainContent_txtFEx').val('');
                        F_Buscar_Retenciones_Anteriores(Number($('#hfCodigo').val()));

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

        return true;

    }

    catch (e) {
        toastr.error("Error Detectado: " + e);
        return false;
    }

}


function F_RetencionesAnteriores_Editar(Fila) {
    var imgID = Fila.id;
    var hfID = '#' + imgID.replace('imgEditarRegistro', 'hfID');
    var hfCodTrabajador = '#' + imgID.replace('imgEditarRegistro', 'hfCodTrabajador');
    var hfCodPeriodo = '#' + imgID.replace('imgEditarRegistro', 'hfCodPeriodo');
    var lblPeriodo = '#' + imgID.replace('imgEditarRegistro', 'lblPeriodo');
    var lblMontoRetenido = '#' + imgID.replace('imgEditarRegistro', 'lblMontoRetenido');
    var lblTotalIngresos = '#' + imgID.replace('imgEditarRegistro', 'lblTotalIngresos');
    var lblObservacion = '#' + imgID.replace('imgEditarRegistro', 'lblObservacion');
    var lblFechaEx = '#' + imgID.replace('imgEditarRegistro', 'lblFEx');

    $("#hfIdRetencionAnterior").val($(hfID).val());
    $('#hfCodigo').val($(hfCodTrabajador).val());
    $("#MainContent_lblCodPeriodo").text($(hfCodPeriodo).val());
    $("#MainContent_txtRanteriorPeriodo").val($(lblPeriodo).text().replace('-', ''));
    $('#MainContent_txtRanteriorMontoRetenido').val($(lblMontoRetenido).text());
    $('#MainContent_txtRanteriorTotalIngresos').val($(lblTotalIngresos).text());
    $("#MainContent_txtRanteriorObservacion").val($(lblObservacion).text());
    $("#MainContent_txtFEx").val($(lblFechaEx).text());

    return true;
}

function F_RetencionesAnteriores_Eliminar(Fila) {
    var objEntidad = {};
    var imgID = Fila.id;
    var hfID = '#' + imgID.replace('imgAnularDocumento', 'hfID');
    var hfCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodTrabajador');
    $("#hfIdRetencionAnterior").val($(hfID).val());
    objEntidad["Id"] = Number($("#hfIdRetencionAnterior").val());
    if (confirm('¿ESTA SEGURO DE ELIMINAR LA RETENCION?')) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar',
            data: JSON.stringify(objEntidad),
            dataType: "json",
            async: false,
            success: function (dbObject) {
                var data = dbObject.d;
                try {
                    if (data.MsgError === "SE ELIMINO CORRECTAMENTE LA RETENCION") {
                        toastr.success('SE ELIMINO CORRECTAMENTE LA RETENCION');
                        F_Buscar_Retenciones_Anteriores(Number($(hfCodigo).val()));
                    } else {
                        toastr.error(data.MsgError);
                    }
                }
                catch (x) { toastr.error('ERROR AL ELIMINAR LA RETENCION'); }
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
    return false;
}


function F_RetencionesAnteriores_Edicion() {

    var fecha = $('#MainContent_txtFEx').val();
    var arrFecha = fecha.split('/');
    var periodo = arrFecha[2] + arrFecha[1];

    if (Number($('#hfCodigo').val()) == 0) {
        toastr.error("Error al insertar, no hay codtrabajador");
        return false
    }


    if (Number($("#MainContent_lblCodPeriodo").text()) == 0) {
        toastr.error("Error al insertar, ha seleccionado un periodo");
        return false
    }

    if (isNaN($("#MainContent_txtRanteriorMontoRetenido").val()) || $("#MainContent_txtRanteriorMontoRetenido").val().trim() == "") {
        toastr.error("Monto retenido no es numerico");
        return false
    }

    if (Number($("#MainContent_txtRanteriorMontoRetenido").val()) < 0) {
        toastr.error("Monto no valido");
        return false
    }


    if (isNaN($("#MainContent_txtRanteriorTotalIngresos").val()) || $("#MainContent_txtRanteriorTotalIngresos").val().trim() == "") {
        toastr.error("Total Ingresos no es numerico");
        return false
    }

    if (Number($("#MainContent_txtRanteriorTotalIngresos").val()) <= 0) {
        toastr.error("Total Ingresos no valido");
        return false
    }

    if (Number($("#MainContent_lblCodPeriodo").text()) == 0) {
        toastr.error("Error al insertar, ha seleccionado un periodo");
        return false
    }

    if (Number(periodo) != $('#MainContent_txtRanteriorPeriodo').val()) {
        toastr.error("La Fecha Exacta de la Retencion es inferior o mayor al mes del periodo");
        return false;
    }

    try {

        var objEntidad = {};
        objEntidad["IdRetencion"] = Number($("#hfIdRetencionAnterior").val());
        objEntidad["CodTrabajador"] = Number($('#hfCodigo').val());
        objEntidad["CodPeriodo"] = Number($("#MainContent_lblCodPeriodo").text());
        objEntidad["MontoRetenido"] = Number($('#MainContent_txtRanteriorMontoRetenido').val());
        objEntidad["TotalIngresos"] = Number($('#MainContent_txtRanteriorTotalIngresos').val());
        objEntidad["Observacion"] = $("#MainContent_txtRanteriorObservacion").val();
        objEntidad["FechaExacta"] = $('#MainContent_txtFEx').val();
        objEntidad["RegistroOperacion"] = "Actualizar";


        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/DatosPlanilla_Trabajador.asmx/F_Planilla_Trabajador_Retenciones_Anteriores_Actualizar',
            data: JSON.stringify(objEntidad),
            dataType: "json",
            async: false,
            success: function (dbObject) {
                var data = dbObject.d;
                try {
                    if (data.MsgError === "SE MODIFICO CORRECTAMENTE") {
                        toastr.success('SE MODIFICO CORRECTAMENTE');

                        $("#MainContent_txtRanteriorPeriodo").val("");
                        $("#MainContent_lblDisplayPeriodo").val("");
                        $("#MainContent_lblCodPeriodo").text(0);
                        $('#MainContent_txtRanteriorMontoRetenido').val("");
                        $('#MainContent_txtRanteriorTotalIngresos').val("");
                        $("#MainContent_txtRanteriorObservacion").val("");
                        $('#MainContent_txtFEx').val('');
                        F_Buscar_Retenciones_Anteriores(Number($('#hfCodigo').val()));

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

        return true;

    }

    catch (e) {
        toastr.error("Error Detectado: " + e);
        return false;
    }

}
