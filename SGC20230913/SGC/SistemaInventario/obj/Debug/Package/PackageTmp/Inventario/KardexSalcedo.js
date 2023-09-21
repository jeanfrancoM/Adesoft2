var AppSession = "../Inventario/KardexSalcedo.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 1;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    $('#MainContent_txtRazonSocial').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_Ruc_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 0 + "','CodTipoCliente':'0'}",
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
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtArticulo').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGProductos_Select',
                data: "{'Descripcion':'" + request.term + "','CodAlmacen':'" + $('#hfCodSede').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Stock: item.split(',')[2],
                            Costo: item.split(',')[3],
                            Moneda: item.split(',')[4]
                        }
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCte').val(i.item.val);
//            $('#MainContent_lblCosto').text(i.item.Costo);
            $('#MainContent_lblMoneda').text(i.item.Moneda);

        },
        minLength: 3
    });

    $('#MainContent_txtCosto').on('change', function (e) {
        if (isNaN($('#MainContent_txtCosto').val())) {
            $('#MainContent_txtCosto').val($('#MainContent_lblCosto').text());
            $('#MainContent_txtCosto').select();
        }
    });

    var dateToday = new Date();
    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy',
        maxDate: dateToday
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (F_Validar() == false)
                return false;

            F_Buscar();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (isNaN($("#MainContent_txtIngreso").val()) | $("#MainContent_txtIngreso").val().trim() === '') {
                alertify.log('INGRESO: NUMERO INVALIDO');
                $("#MainContent_txtIngreso").val($(lblIngreso).text());
                $("#MainContent_txtIngreso").select();
                $("#MainContent_txtFinal").val($(lblFinal).text());
                $("#MainContent_txtSalida").val($(lblSalida).text());
                return false;
            }

            if (Number($("#MainContent_txtIngreso").val()) < 0) {
                alertify.log('INGRESO: DEBE SER MAYOR A CERO (0)');
                $("#MainContent_txtIngreso").val($(lblIngreso).text());
                $("#MainContent_txtSalida").val($(lblSalida).text());
                $("#MainContent_txtIngreso").select();
                $("#MainContent_txtFinal").val($(lblFinal).text());
                return false;
            }

            if (isNaN($("#MainContent_txtSalida").val()) | $("#MainContent_txtSalida").val().trim() === '') {
                alertify.log('SALIDA: NUMERO INVALIDO');
                $("#MainContent_txtSalida").val($(lblSalida).text());
                $("#MainContent_txtFinal").val($(lblFinal).text());
                $("#MainContent_txtIngreso").val($(lblIngreso).text());
                return false;
            }

            if (Number($("#MainContent_txtSalida").val()) < 0) {
                alertify.log('SALIDA: DEBE SER MAYOR A CERO (0)');
                $("#MainContent_txtSalida").val($(lblSalida).text());
                $("#MainContent_txtFinal").val($(lblFinal).text());
                $("#MainContent_txtIngreso").val($(lblIngreso).text());
                return false;
            }

            if (Number($('#MainContent_txtFinal').val()) < 0) {
                alertify.log('El stock final resultante de la operacion, no puede ser negativo');
                $("#MainContent_txtFinal").val($(lblFinal).text());
                $("#MainContent_txtSalida").val($(lblSalida).text());
                $("#MainContent_txtIngreso").val($(lblIngreso).text());
                return false;
            };

            if ($('#MainContent_txtObservacion').val().length < 10) {
                alertify.log('El comentario debe tener una longitud minima de 10 caracteres');
                return false;
            }

            if ($(hfCodTipoOperacion).val() == 16) {
                if (confirm("¿ESTA SEGURO DE MODIFICAR EL SALDO INICIAL?"))
                    F_EdicionInicialAjuste();
                return false;
            } else {
                if (confirm("¿ESTA SEGURO DE MODIFICAR EL AJUSTE?"))
                    F_EdicionInicialAjuste();
                return false;
            }

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtIngreso").bind("propertychange change keyup paste input", function () {

        try {
            if ($(hfCodTipoOperacion).val() == 17) {
                $('#MainContent_txtSalida').val(0);
                $('#MainContent_txtFinal').val(Number($('#MainContent_txtInicial').val()) + Number($("#MainContent_txtIngreso").val()) - Number($("#MainContent_txtSalida").val()));
            } else {
                $('#MainContent_txtFinal').val(Number($("#MainContent_txtIngreso").val()));            
            }

        } catch (e) {

        }
    });

    $("#MainContent_txtSalida").bind("propertychange change keyup paste input", function () {

        try {
            $('#MainContent_txtIngreso').val(0);
            $('#MainContent_txtFinal').val(Number($('#MainContent_txtInicial').val()) - Number($("#MainContent_txtSalida").val()));

        } catch (e) {

        }
    });

    $('#MainContent_txtArticulo').focus();

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtRazonSocial').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtProd').css('background', '#FFFFE0');

    $('#MainContent_txtIngreso').css('background', '#FFFFE0');

    $('#MainContent_txtSalida').css('background', '#FFFFE0');

    $('#MainContent_txtFinal').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('background', '#FFFFE0');

    $('#MainContent_txtFechaIng').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('height', '60px');

    $('#MainContent_txtInicial').css('background', '#FFFFE0');

    F_Controles_Inicializar();

});

//-----------------

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

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {

                Filtro_CodEstadoAlmacen: 1
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {
                    $('#hfCodSede').val(result.split('~')[0]);
                    F_Update_Division_HTML('div_Sucursal', result.split('~')[1]);
                    F_Update_Division_HTML('div_Operacion', result.split('~')[2]);
                    $('#MainContent_txtDesde').val(result.split('~')[3]);
                    $('#MainContent_ddlOperacion').css('background', '#FFFFE0');
                    $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
                    // $('#MainContent_ddlSucursal').val(0);
                    $('#MainContent_ddlSucursal').val(result.split('~')[0]);
                    $('#MainContent_ddlOperacion').val(0);
                }
            );

    } catch (mierror) {
        alert("Error detectado: " + mierror);
    }
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    var arg;

    try {
        if ($('#MainContent_txtRazonSocial').val() == '')
            $('#hfCodCtaCteConsulta').val('0');

        var objParams =
            {
                Filtro_Desde: $('#MainContent_txtDesde').val(),
                Filtro_Hasta: $('#MainContent_txtHasta').val(),
                Filtro_CodAlterno: $('#hfCodCtaCte').val(),
                Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                Filtro_CodTipoOperacion: $('#MainContent_ddlOperacion').val(),
                Filtro_CodAlmacen: $('#MainContent_ddlSucursal').val()
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
                        F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);
                        $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvKardex", 'lblCosto'));
                        //                        $('#MainContent_lblStock').text(result.split('~')[3]);
                        F_RecorrerGrilla();
                        F_Stockkardex();
                        if (str_mensaje_operacion != '')
                            alert(str_mensaje_operacion);
                    }
                    else {
                        alert(str_mensaje_operacion);
                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alert("Error detectado: " + mierror);

    }

}

function F_Nuevo() {


    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#hfCodCtaCte').val('0');
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_lblStock').text('0.00');
    $('#MainContent_lblCosto').text('0.00');
    $('#MainContent_lblMoneda').text('dolares');
    $('#MainContent_txtDesde').val('01/01/2014');
    $('#MainContent_txtArticulo').focus();

    try {
        var objParams = {};



        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Nuevo_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);

            }
            else {
                alert(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alert("Error Detectado: " + e);
        return false;
    }

}

function F_Validar() {

    var Cadena = "Ingrese los sgtes. campos: ";
    if ($('#MainContent_txtArticulo').val() == "")
        Cadena = Cadena + "\n" + "Articulo";

    if ($('#MainContent_txtDesde').val() == "")
        Cadena = Cadena + "\n" + "Desde";

    if ($('#MainContent_txtHasta').val() == "")
        Cadena = Cadena + "\n" + "Hasta";

    if (Cadena != "Ingrese los sgtes. campos: ") {
        alert(Cadena);
        return false;
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

function  F_EliminarRegistro  (Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var hfCodTipoOperacion = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoOperacion');

        if ($(hfCodTipoOperacion).val() != '17') {
            toastr.warning("OPCION VALIDA SOLO PARA LOS AJUSTES");
            return false;
        }

        if (!confirm("ESTA SEGURO DE ELIMINAR EL AJUSTE"))
            return false;

        var objParams = {
            Filtro_CodMovimiento: $(hfCodigo).val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodAlterno: $('#hfCodCtaCte').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_CodTipoOperacion: $('#MainContent_ddlOperacion').val(),
            Filtro_CodAlmacen: $('#MainContent_ddlSucursal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);
                $('#MainContent_lblStock').text(result.split('~')[3]);
                $('#MainContent_lblCosto').text(result.split('~')[4]);
                if (str_mensaje_operacion != '')
                    toastr.warning(str_mensaje_operacion);
            }
            else {
                toastr.warning(str_mensaje_operacion);
            }

            return false;
        });

    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }


}
var lblSalida=0;
var lblFinal=0;
var lblIngreso = 0;
var hfCodTipoOperacion=0;
function F_EditarSaldoInicial(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;

        var hfCodigo = '#' + imgID.replace('imgEditarDocumento', 'hfCodigo');        
        hfCodTipoOperacion = '#' + imgID.replace('imgEditarDocumento', 'hfCodTipoOperacion');
        var hfProducto = '#' + imgID.replace('imgEditarDocumento', 'hfProducto');
        var lblInicial = '#' + imgID.replace('imgEditarDocumento', 'lblInicial');
        var lblFechaIng = '#' + imgID.replace('imgEditarDocumento', 'lblRegistro');        
        lblIngreso = '#' + imgID.replace('imgEditarDocumento', 'lblIngreso');
        lblSalida = '#' + imgID.replace('imgEditarDocumento', 'lblSalida');        
        lblFinal = '#' + imgID.replace('imgEditarDocumento', 'lblFinal'); 
        var Cuerpo = '#MainContent_';                

        $('#hfCodMovimiento').val($(hfCodigo).val());
        $(Cuerpo+'txtInicial').val($(lblInicial).text());
        $(Cuerpo+'txtIngreso').val($(lblIngreso).text());
        $(Cuerpo+'txtSalida').val($(lblSalida).text());
        $(Cuerpo+'txtFinal').val($(lblFinal).text());
        $(Cuerpo + 'txtProd').val($(hfProducto).val());
        $(Cuerpo + 'txtFechaIng').val($(lblFechaIng).text());        

        if($(hfCodTipoOperacion).val().toString()=='16'){
            $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Saldo Inicial",
            title_html: true,
            height: 310,
            width: 460,
            autoOpen: false
        });
            $(Cuerpo + 'lblSalidaEdi').hide();
            $(Cuerpo + 'txtSalida').hide();
            $(Cuerpo + 'lblIngresoEdi').text("NUEVO INCIAL");
            $('#MainContent_txtFechaIng').datepicker('disable');
            $('#MainContent_txtObservacion').val('')
            $('#divEdicionRegistro').dialog('open');
        }else if($(hfCodTipoOperacion).val().toString()=='17'){            
            $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Ajuste",
            title_html: true,
            height: 310,
            width: 460,
            autoOpen: false
        });
            $(Cuerpo + 'lblSalidaEdi').show();
            $(Cuerpo + 'txtSalida').show();
            $(Cuerpo + 'lblIngresoEdi').text("INGRESO");
            $(Cuerpo + 'txtSalida').attr("readonly", false);
            $('#MainContent_txtFechaIng').datepicker('enable');
            $('#MainContent_txtObservacion').val('');
            $('#divEdicionRegistro').dialog('open');
        }else{
            alertify.log('Esta opcion solo esta disponible para Saldos Iniciales y Ajustes');
        }
                
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EdicionInicialAjuste() {

    try {
        var Contenedor = '#MainContent_';
        var Aro = '0';
        var Medida = '0';
        var Seccion = '0';


        //  VERSION NUEVA
            var ModIA ={};
            ModIA["CodMovimiento"] = $('#hfCodMovimiento').val();            
            ModIA["CantIng"]=$('#MainContent_txtIngreso').val();
            ModIA["CantSalida"] = $('#MainContent_txtSalida').val();
            ModIA["FechaIngreso"] = $('#MainContent_txtFechaIng').val();
            ModIA["TipoOperacion"] = $(hfCodTipoOperacion).val();
            ModIA["Observacion"] = $('#MainContent_txtObservacion').val();

            $.ajax({
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'Kardex.aspx/F_InicialAjusteModificar',
                dataType: 'json',
                data: JSON.stringify(ModIA),
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
            $('#divEdicionRegistro').dialog('close');
            return false;


        //        if ($(Contenedor + 'txtAroEdicion').val()!='')
        //            Aro=$(Contenedor + 'txtAroEdicion').val();

        //        if ($(Contenedor + 'txtMedidaEdicion').val()!='')
        //            Medida=$(Contenedor + 'txtMedidaEdicion').val();

        //        if ($(Contenedor + 'txtSeccionEdicion').val()!='')
        //            Seccion=$(Contenedor + 'txtSeccionEdicion').val();

        /*    VERSION ANTIGUA
        var objParams = {
            Filtro_CodMovimiento: $('#hfCodMovimiento').val(),
            Filtro_CantidadIngreso: $('#MainContent_txtIngreso').val(),
            Filtro_Costo: $('#MainContent_txtCosto').val(),
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionSaldoInicial_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == '') {
                    alertify.log('SE MODIFICO CORRECTAMENTE EL SALDO INICIAL');
                    $('#divEdicionRegistro').dialog('close');
                    F_Buscar();
                } else {
                    toastr.warning(result.split('~')[1]);
                }
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
        */

    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
    

    
}

function F_ValidarEdicionDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtTcEdicion').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtFactorEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Factor';

        if (($(Cuerpo + 'ddlCompraEdicion').val() != $(Cuerpo + 'ddlVentaEdicion').val()) && ($(Cuerpo + 'txtFactorEdicion').val() == '1' | $(Cuerpo + 'txtFactorEdicion').val() == '1.00'))
            Cadena = Cadena + '<p></p>' + 'La unidad de compra y venta son distintas,el Factor no puede ser 1.';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '008'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '006') && $(Cuerpo + 'txtAroEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Aro/Peso/Placas';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007') && $(Cuerpo + 'txtMedidaEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Medida';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007') && $(Cuerpo + 'txtSeccionEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Seccion';

        if ($(Cuerpo + 'txtCostoConIgvEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtPrecio1Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 1';

        if ($(Cuerpo + 'txtPrecio2Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 2';

        if ($(Cuerpo + 'txtPrecio3Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 3';


        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
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
        var nmrow = 'MainContent_grvKardex_pnlOrders_0';
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrders', 'lblCodigo')).val();
        //var CodTipoDoc = $('#' + Fila.replace('pnlOrders', 'hfCodTipoDoc')).val();
        var Observacion = $('#' + Fila.replace('pnlOrders', 'hfObservacion')).val();
        var grvNombre = 'MainContent_grvKardex_grvDetalle_' + Col;
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
                            Filtro_Observacion: Observacion,
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
                        toastr.warning(str_mensaje_operacion);
                    }

                    return false;

                });

            }

        }

    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("ERROR DETECTADO: " + e);
        return false;
    }

    return true;
}

function F_RecorrerGrilla()
{
var Ingreso = 0;
var Salida  = 0;
var NombreGrilla = 'grvKardex';
var NombreLabelIngreso  = 'lblIngreso';
var NombreLabelSalida   = 'lblSalida';
var C = 0;

    $('#MainContent_' + NombreGrilla + ' .detallesart2').each(function () {
        C++;
    });
    if (C==0)
        return false;
    else
        C = 0;

    $('#MainContent_' + NombreGrilla + ' .detallesart3').each(function () {
        Salida+=  parseFloat($('#MainContent_' + NombreGrilla + '_' + NombreLabelSalida  + '_' + C).text());
        Ingreso+= parseFloat($('#MainContent_' + NombreGrilla + '_' + NombreLabelIngreso + '_' + C).text());
                                               
        C++;
    });

    $('#MainContent_lblIngresos').text(Ingreso);
    $('#MainContent_lblSalidas').text(Salida);
    return false;
}
var auImportacion;
var hfgvAuImportacion;
function imgMasAu_Click(Control) {
    auImportacion = Control;
    var Src = $(Control).attr('src');
    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_Auditoria(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_Auditoria(Fila) {
    try {
        var Col = Fila.split('_')[3];
        console.log(Col);
        var Codigo = $('#' + Fila.replace('pnlOrdersAu', 'hfCodigo')).val();        
        var grvNombre = 'MainContent_grvKardex_grvAuditoria_' + Col;
        hfgvAuImportacion = '#' + Fila.replace('pnlOrdersAu', 'hfDetalleCargadoAuditoria');

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
                F_Auditoria_NET(arg, function (result) {

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

function F_ImprimirDocumento(codigo, Fila, rplc, TipoImp, TipoDoc) {
    //    if (F_PermisoOpcion(CodigoMenu, 4000205, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    var nrodoc = '';
    if (codigo == undefined) {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace(rplc, 'hfcoddoc');
        var lblNumero = '#' + imgID.replace(rplc, 'lblnumero');
        var hfTipoDoc = '#' + imgID.replace(rplc, 'hfcodtipodoc');
        var hfcodtipodocnota = '#' + imgID.replace(rplc, 'hfcodtipodocnota');
        codigo = $(lblCodigo).val();
        nrodoc = $(lblNumero).text();
        TipoDoc = $(hfTipoDoc).val();
        codtipodocnota = $(hfcodtipodocnota).val();
    }
    else {
        nrodoc = $("#MainContent_ddlSerie option:selected").text()
    }


    //VALIDACONES PRE IMPRESION
    //    if (nrodoc.substr(0, 1) == 'F' || nrodoc.substr(0, 1) == 'B' || nrodoc.substr(0, 1) == '0') {
    //        switch (TipoImp) {
    //            case 'PDF':
    //                break;
    //            case 'IMP':
    //                break;
    //            case 'TK':
    //                break;
    //        }
    //    }
    //    else {
    //        switch (TipoImp) {
    //            case 'PDF':
    //                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
    //                return false;
    //                break;
    //            case 'IMP':
    //                break;
    //            case 'TK':
    //                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
    //                return false;
    //                break;
    //        }
    //    }

    if (codigo == 0) {

        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodMenu = '2001';

    if (codtipodocnota == 7) {
        CodMenu = '205'
    }
    if (nrodoc.substr(3, 3) == '001') {
        TipoDoc = 16
    }

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodDocumentoVenta=' + codigo + '&';
    rptURL = rptURL + 'Codigo=' + codigo + '&';
    rptURL = rptURL + 'SerieDoc=' + nrodoc.substr(3, 4) + '&';
    rptURL = rptURL + 'CodTipoDoc=' + TipoDoc + '&';
    rptURL = rptURL + 'TipoImpresion=' + TipoImp + '&';
    rptURL = rptURL + 'NombreArchivo=' + '' + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_Stockkardex() {
    var Ingreso = 0;
    var Salida = 0;
    var NombreGrilla = 'grvKardex';
    var NombreLabelIngreso = 'lblIngreso';
    var NombreLabelSalida = 'lblSalida';
    var NombreLabelInicial = 'lblInicial';
    var Stock = 0;
    var C = 0;

    Stock += parseFloat($('#MainContent_' + NombreGrilla + '_' + NombreLabelInicial + '_' + C).text());

    $('#MainContent_' + NombreGrilla + ' .detallesart2').each(function () {
        C++;
    });
    if (C == 0)
        return false;
    else
        C = 0;

    $('#MainContent_' + NombreGrilla + ' .detallesart3').each(function () {
        Stock = parseFloat(Stock+(parseFloat($('#MainContent_' + NombreGrilla + '_' + NombreLabelIngreso + '_' + C).text())-parseFloat($('#MainContent_' + NombreGrilla + '_' + NombreLabelSalida + '_' + C).text())));

        C++;
    });

    $('#MainContent_lblStock').text(Stock);
    return false;
}