var AppSession = "../Compras/ListaPedido.aspx"; //2018-11-20

var CodigoMenu = 3000;
var CodigoInterno = 7;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    F_FuncionesBotones();

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscarArticulo').click(function () {
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val() == "")
                return false
            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
                cadena = cadena + "\n" + "Articulo (Minimo 2 Caracteres)"

            if (cadena != "Ingresar los sgtes. campos :") {
                alertify.log(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarProducto').click(function () {
    if (F_PermisoOpcion(CodigoMenu, 3000701, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {

            $('#MainContent_txtArticulo').val('');
            $('#MainContent_chkServicios').prop('checked', false);
            $('#MainContent_chkNotaPedido').prop('checked', false);
            $("#divConsultaArticulo").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Productos",
                title_html: true,
                height: 600,
                width: 1250,
                autoOpen: false
            });

            $('#divConsultaArticulo').dialog('open');
            $('#MainContent_txtArticulo').focus();


            var objParams = {};
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


            F_CargarGrillaVaciaConsultaArticulo_NET(arg, function (result) {
                //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

                //                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);

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

    $('#MainContent_btnBuscarConsulta').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnAgregar').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            F_LimpiarGrillaConsulta();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminar').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (F_ValidarEliminar() == false)
                return false;

            if (confirm("Esta seguro de eliminar los productos seleccionado"))
                F_EliminarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnNuevo').click(function () {
        try {
            F_Nuevo();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnExcel').click(function () {
    if (F_PermisoOpcion(CodigoMenu, 3000702, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_VisualizarExcel($('#hfCodigoTemporal').val());
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_txtArticulo').blur(function () {
        try {
            if ($('#MainContent_txtArticulo').val() == '')
                return false

            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
                cadena = cadena + "\n" + "Articulo (Minimo 2 Caracteres)"



            if (cadena != "Ingresar los sgtes. campos :") {
                alertify.log(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;
    });

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#divTabs').tabs();

    F_Controles_Inicializar();


    $('#MainContent_txtEmision').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');

});

function F_FuncionesBotones() {
    var k = new Kibo();
    //Botones Principales
    k.down("f1", function () {
        $("#MainContent_btnNuevo").click();
        return false;
    });
    k.down("f2", function () {
        $("#MainContent_btnAgregarProducto").click();
        return false;
    });
    k.down("f6", function () {
        $("#MainContent_btnEliminar").click();
        return false;
    });
    k.down("f7", function () {
        $("#MainContent_btnGrabar").click();
        return false;
    });
    k.down("f11", function () {
        if ($("#MainContent_chkImpresionTicket").prop('checked') === true)
            $("#MainContent_chkImpresionTicket").prop('checked', false);
        else 
            $("#MainContent_chkImpresionTicket").prop('checked', true);

        return false;
    });

    
    //funcionalidades de productos
    k.down("up", function () {
        var control = $(':focus');
        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
        {
            F_PrecioDisplayUp();
            return true;
        } else { 
            try {
                if (control.attr('id') == 'MainContent_txtDireccion')
                {
                    F_DireccionDisplayUp();
                    return true;
                }
            } catch (e) { }

            try {
                if (control.attr('id').indexOf("ddl") >= 0) 
                {
                F_ddlDisplayUp(control.attr('id') );
                return true;
                }
            } catch (e) { }
        }

        F_TablaUp();
        return false;
    });
    k.down("down", function () {
        var control = $(':focus');
        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
        {
            F_PrecioDisplayDown();
            return true;
        } else { 
            try {
                if (control.attr('id') == 'MainContent_txtDireccion')
                {
                    F_DireccionDisplayDown();
                    return true;
                }
            } catch (e) { }

            try {
                if (control.attr('id').indexOf("ddl") >= 0) 
                {
                    F_ddlDisplayDown(control.attr('id') );
                    return true;
                }
            } catch (e) { }
        }

        F_TablaDown();
        return false;
    });

    k.down("enter", function () {

            var control = $(':focus');
            var inputs = control.parents("form").eq(0).find("input, select");
            var idx = inputs.index(control);

            if (idx == inputs.length - 1) {
                //campos especiales
                F_CamposAlternativas(control.attr('id'));

            } else {
                inputs[idx + 1].focus(); //  handles submit buttons
                try {inputs[idx + 1].select();

                F_CamposAlternativas(control.attr('id'));
                } catch (e) { 
                    F_CamposAlternativas(control.attr('id'));
                }   

//                alertify.log('normales');
//                inputs[idx + 1].focus(); //  handles submit buttons
//                try {inputs[idx + 1].select();} catch (e) { }               

            }
       return false;
    });
}

function F_CamposAlternativas(Campos) { 
                switch (Campos)
                {
                    case "MainContent_txtArticulo":
                        $('#MainContent_btnBuscarArticulo').click();
                    break;
                    case "MainContent_txtArticuloAgregar":
                        $('#MainContent_txtCantidad').select();
                    break;
                    case "MainContent_txtCantidad":
                        if (P_UNIDADES_ENTEROS == "1")
                            $("#MainContent_txtCantidad").val(Number($("#MainContent_txtCantidad").val()).toFixed(0));
                        $('#MainContent_txtPrecioDisplay').select();
                    break;
                    case "MainContent_txtPrecioDisplay":
                           $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_btnAgregar":
                           $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_ddlSerie":
                        $('#MainContent_ddlIgv').focus();
                    break;
                    case "MainContent_txtEmision":
                        $('#MainContent_ddlFormaPago').focus();
                    break;
                    case "MainContent_txtNroOperacion":
                        $('#MainContent_txtCorreo').focus();
                    break;
                    case "MainContent_txtKM":
                        $('#MainContent_chkImpresionTicket').focus();
                    break;
                    default:
                    //otros casos

                        //Agregar Con Enter desde la Grilla
                        if (Campos.indexOf("MainContent_grvConsultaArticulo_imgAgregar") >= 0)
                        {
                            F_AgregarArticulo(Campos, 0);
                            return true;
                        }

                    break;
                }
return true;
}

var ctrlPosActual = '';
var ctrlPosActualBuffer = '';
function F_TablaUp() {
    var ant = 0; var pos = 0;
    try {
        ant = parseInt(ctrlPosActual.split('_')[3]);
        pos = ant - 1; if (pos < 0) pos = 0;
        if ( $(ctrlPosActual.replace(ant, pos)).length > 0 ) {
            $(ctrlPosActual.replace(ant, pos)).focus();
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#FFFFFF")
            ctrlPosActual = ctrlPosActual.replace(ant, pos);
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
        }
        
    } catch (e) {
        $(ctrlPosActual).focus();
    }
    ctrlPosActualBuffer = ctrlPosActual;
}    
function F_TablaDown() {
    var ant = 0; var pos = 0;
    try {
        ant = parseInt(ctrlPosActual.split('_')[3]);
        pos = ant + 1;
        if ( $(ctrlPosActual.replace(ant, pos)).length > 0 ) {
            $(ctrlPosActual.replace(ant, pos)).focus();
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#FFFFFF")
            ctrlPosActual = ctrlPosActual.replace(ant, pos);
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
        }
    } catch (e) {
        $(ctrlPosActual).focus();
    }
    ctrlPosActualBuffer = ctrlPosActual;
}
function F_TablaClick(Control) {
    Control = "#" + Control;
    $(ctrlPosActualBuffer).closest("tr").children('td,th').css("background-color","#FFFFFF")
    $(Control).closest("tr").children('td,th').css("background-color","#ffec85")
    $(Control).focus();
    ctrlPosActualBuffer = Control;
}

function F_PrecioDisplayUp() 
{
  if ($('#MainContent_ddlPrecio option:selected').prev().length > 0) 
    $('#MainContent_ddlPrecio option:selected').prev().attr('selected', 'selected').trigger('change');
  else $('#MainContent_ddlPrecio option').last().attr('selected', 'selected').trigger('change');

  $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").text());   
}

function F_PrecioDisplayDown() 
{
  if ($('#MainContent_ddlPrecio option:selected').next().length > 0) 
  {
    $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").next().text());
    $('#MainContent_ddlPrecio option:selected').val($("#MainContent_txtPrecioDisplay").val());
  }
  else {
    $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").prev().text());
    $('#MainContent_ddlPrecio option:selected').val($("#MainContent_txtPrecioDisplay").val());    
  } 
}

function F_ddlDisplayUp(Control) {
  if ($('#' + Control + ' option:selected').prev().length > 0) 
    $('#' + Control + ' option:selected').prev().attr('selected', 'selected').trigger('change');
  else $('#' + Control + ' option').last().attr('selected', 'selected').trigger('change');
}

function F_ddlDisplayDown(Control) {
  if ($('#' + Control + ' option:selected').next().length > 0) 
  {
    $('#' + Control + ' option:selected').val($("#" + Control + " option:selected").next().text());
  }
  else {
    $('#' + Control + ' option:selected').val($("#" + Control + " option:selected").prev().text());    
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

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: ''
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
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);
                         F_Inicializar_Tabla_Almacenes_Stocks();
                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }

                    F_Nuevo();


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Buscar_Productos() {

    var arg;
    var CodTipoProducto = 2;

    try {

        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: 1,
                Filtro_Servicio: 0,
                Filtro_NotaPedido: 0
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_Productos_NET
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


                        ctrlPosActual = '#MainContent_grvConsultaArticulo_imgAgregar_0';
                        ctrlPosActualBuffer = ctrlPosActual;
                        $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
                        $(ctrlPosActual).focus();

                        if (str_mensaje_operacion != '')
                            alertify.log(str_mensaje_operacion);
                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }
                    $('.ccsestilo').css('background', '#FFFFE0');

                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_ValidarPrecioLista(ControlID) {

    var ddlLista_Grilla = '';
    var lblprecio = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;

    ddlLista_Grilla = '#' + ControlID;
    txtprecio_grilla = ddlLista_Grilla.replace('ddlLista', 'txtPrecioLibre');
    txtcant_grilla = ddlLista_Grilla.replace('ddlLista', 'txtCantidad');

    switch ($(ddlLista_Grilla).val()) {
        case "1":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio1');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;

        case "2":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio2');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;
        case "3":
            lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio3');
            $(txtprecio_grilla).val($(lblprecio).val());
            $(txtprecio_grilla).prop('disabled', true);
            $(txtcant_grilla).focus();
            break;

        case "4":
            $(txtprecio_grilla).val('');
            $(txtprecio_grilla).prop('disabled', false);
            $(txtprecio_grilla).focus();
            break;
    }

    return true;
}

function F_ValidarStockGrilla(ControlID) {

    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidad', 'chkOK');
    lblstock = txtcantidad_Grilla.replace('txtCantidad', 'lblstock');

    boolEstado = $(chkok_grilla).is(':checked');

    //    if (boolEstado && $(txtcantidad_Grilla).val() == '') {
    //        alertify.log("Ingrese la cantidad");

    //        return false;
    //    }

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if (boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            alertify.log("Stock insuficiente");
            $(txtcantidad_Grilla).val('');
            return false;
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            alertify.log("Stock insuficiente");
            $(txtcantidad_Grilla).val('');
            return false;
        }
    }


    return true;
}

function F_ValidarPrecioGrilla(ControlID) {

    var txtprecio_Grilla = '';
    var lblprecio_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtprecio_Grilla = '#' + ControlID;
    chkok_grilla = txtprecio_Grilla.replace('txtPrecioLibre', 'chkOK');
    lblprecio_grilla = txtprecio_Grilla.replace('txtPrecioLibre', 'lblPrecio1');
    boolEstado = $(chkok_grilla).is(':checked');


    //            if ($('#hfCodUsuario').val()!='5' && boolEstado && parseFloat($(txtprecio_Grilla).val())< parseFloat($(lblprecio_grilla).val()))
    //            {alertify.log("Precio por debajo del minimo");
    //            $(txtprecio_Grilla).val('');
    //              return false;
    //             }

    return true;
}

function F_ValidarCheck(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    var cadena = 'Ingrese los sgtes. campos: '

    chkok_grilla = '#' + ControlID;
    txtprecio_grilla = chkok_grilla.replace('chkOK', 'txtPrecioLibre');
    txtcant_grilla = chkok_grilla.replace('chkOK', 'txtCantidad');
    ddlLista_grilla = chkok_grilla.replace('chkOK', 'ddlLista');


    boolEstado = $(chkok_grilla).is(':checked');
    if (boolEstado) {

        $(txtcant_grilla).prop('disabled', false);
        var i = 0;
        if ($(txtprecio_grilla).val() == "") {
            $(txtprecio_grilla).focus();
            i = 1
        }

        if (i == 0 && $(txtcant_grilla).val() == "")
        { $(txtcant_grilla).focus(); }
    }
    else {
        //                $(txtprecio_grilla).val('');
        $(txtcant_grilla).val('');
        //                $(ddlLista_grilla).val('4');

        $(txtcant_grilla).prop('disabled', true);
    }


    return true;
}

function F_FormaPago(CodFormaPago) {

    var arg;
    try {
        switch (CodFormaPago) {
            case "1":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 0));
                break;

            case "4":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 30));
                break;

            case "3":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 15));
                break;

            case "8":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 45));
                break;

            case "9":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 4));
                break;

            case "11":
                $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(), 7));
                break;
        }


    }
    catch (mierror) {
        alertify.log("Error detectado: " + mierror);
    }

}

function F_ValidarAgregar() {

    try {
        var chkSi = '';
        var chkDel = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var cadena = "Ingrese los sgtes. campos: ";
        var lblcodproducto_grilla = '';
        var hfcodarticulodetalle_grilla = '';
        var lbldscproducto_grilla = '';
        var x = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
            txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
            lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');

            if ($(chkSi).is(':checked')) {
                //                            if ($(txtprecio_grilla).val()=='')
                //                                cadena=cadena + "\n" + "Precio para el Codigo " + $(lblcodproducto_grilla).text() ;

                if ($(txtcantidad_grilla).val() == '')
                    cadena = cadena + "\n" + "Cantidad para el Codigo " + $(lblcodproducto_grilla).text();

                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else {
            cadena = "Los sgtes. productos se encuentran agregados : ";
            $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');

                if ($(chkSi).is(':checked')) {
                    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                        chkDel = '#' + this.id;
                        hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
                        lbldscproducto_grilla = chkDel.replace('chkEliminar', 'lblproducto');

                        if ($(lblcodproducto_grilla).text() == $(hfcodarticulodetalle_grilla).val()) {
                            cadena = cadena + "\n" + $(lbldscproducto_grilla).text();
                        }

                    });
                }
            });
        }

        if (cadena != "Los sgtes. productos se encuentran agregados : ") {
            alertify.log(cadena);
            return false;
        }
        else {
            return true;
        }
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {

    try {


        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var chkNotaPedido = 0;
        var chkServicio = 0;

        if ($('#MainContent_chkServicios').is(':checked'))
            chkServicio = 1;

        if ($('#MainContent_chkNotaPedido').is(':checked'))
            chkNotaPedido = 1;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
            lblcodunidadventa_grilla = chkSi.replace('chkOK', 'lblcodunidadventa');
            lblcosto_grilla = chkSi.replace('chkOK', 'lblcosto');
            //                    txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
            txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
            hfcodunidadventa_grilla = chkSi.replace('chkOK', 'hfcodunidadventa');
            hfcosto_grilla = chkSi.replace('chkOK', 'hfcosto');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).text(),
                    Cantidad: 1, //$(txtcantidad_grilla).val(),
                    Precio: 0,
                    Costo: $(hfcosto_grilla).val(),
                    CodUm: $(hfcodunidadventa_grilla).val(),
                    CodDetalle: 0
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat(1.18);
        var objParams = {
            Filtro_CodTipoDoc: "17",
            Filtro_SerieDoc: '001',
            Filtro_NumeroDoc: '0000001',
            Filtro_FechaEmision: $('#MainContent_txtEmision').val(),
            Filtro_Vencimiento: $('#MainContent_txtEmision').val(),
            Filtro_CodCliente: 20,
            Filtro_CodFormaPago: 1,
            Filtro_CodMoneda: 1,
            Filtro_TipoCambio: 3,
            Filtro_SubTotal: 0,
            Filtro_CodProforma: "0",
            Filtro_Igv: 0,
            Filtro_Total: 0,
            Filtro_CodTraslado: "0",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_Servicio: chkServicio,
            Filtro_NotaPedido: chkNotaPedido,
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_AgregarTemporal_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                //                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                //                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                //                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito');
                numerar();
            }
            else {
                alertify.log(result.split('~')[2]);
            }
            $('.ccsestilo').css('background', '#FFFFE0');
            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_LimpiarGrillaConsulta() {

    var chkSi = '';
    var txtprecio_grilla = '';
    var txtcantidad_grilla = '';
    var ddlLista_grilla = '';

    $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
        chkSi = '#' + this.id;
        txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
        txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
        ddlLista_grilla = chkSi.replace('chkOK', 'ddlLista');

        $(txtcantidad_grilla).prop('disabled', true);
        $(txtprecio_grilla).val('');
        $(txtcantidad_grilla).val('');
        $(ddlLista_grilla).val('4');

        $(chkSi).prop('checked', false);

    });
}

function F_EliminarTemporal() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';


        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'hfCodDetalle');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {

                    CodDetalle: $(lblcoddetalle_grilla).val()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat(1.18);
        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EliminarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                }
                else {
                    //                      $('#MainContent_txtTotal').val(result.split('~')[5]);
                    //                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    //                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                }

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                if (result.split('~')[2] == 'Se han eliminado los productos correctamente.')
                    alertify.log('Se han eliminado los productos correctamente.');
            }
            else {
                alertify.log(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarEliminar() {

    try {
        var chkSi = '';
        var x = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0) {
            alertify.log("Seleccione un articulo para eliminar");
            return false;
        }
        else
        { return true; }

    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtCliente').val() == '' && $('#hfCodCtaCte').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Cliente';

        if ($(Cuerpo + 'lblTC').text() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtNumero').val() == '')
            Cadena = Cadena + '<p></p>' + 'Numero de Factura';

        if ($(Cuerpo + 'txtEmision').val() == '')
            Cadena = Cadena + '<p></p>' + 'Fecha de Emision';

        if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtNumeroGuia').val() == '')
            Cadena = Cadena + '<p></p>' + 'Numero de Guia';

        if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtFechaTraslado').val() == '')
            Cadena = Cadena + '<p></p>' + 'Fecha de Traslado';

        if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtDestino').val() == '')
            Cadena = Cadena + '<p></p>' + 'Destino';

        if (ValidarRuc($(Cuerpo + 'txtNroRuc').val()) == false)
            Cadena = Cadena + "\n" + "Ruc Invalido";

        if ($('#hfCodCtaCte').val() == 0 && $('#hfCodDistrito').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Distrito';

        if ($('#hfCodCtaCte').val() == 0 && $(Cuerpo + 'txtDireccion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

        if ($(Cuerpo + 'txtTotal').val() == '0.00')
            Cadena = Cadena + '<p></p>' + 'No ha ingresado ningun producto';


        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            alertify.log(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_GrabarDocumento() {

    try {

        var FlagGuia = '0';
        var FlagIgv = '1';
        var Contenedor = '#MainContent_';
        var Index = $('#MainContent_txtCliente').val().indexOf('-');
        var RazonSocial = $('#MainContent_txtCliente').val();

        if (Index == -1)
            $('#hfCodCtaCte').val('0');
        else
            RazonSocial = RazonSocial.substr(RazonSocial.length - (RazonSocial.length - (Index + 2)));

        if ($(Contenedor + 'chkGuia').is(':checked'))
            FlagGuia = '1';


        var objParams = {
            Filtro_CodTipoDoc: "1",
            Filtro_SerieDoc: $("#MainContent_ddlSerie option:selected").text(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),

            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
            Filtro_CodCliente: $('#hfCodCtaCte').val(),
            Filtro_CodEstado: 6,
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),

            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
            Filtro_Igv: $(Contenedor + 'txtIgv').val(),
            Filtro_Total: $(Contenedor + 'txtTotal').val(),

            Filtro_CodTraslado: $('#hfCodTraslado').val(),
            Filtro_CodProforma: $('#hfCodProforma').val(),
            Filtro_FlagGuia: FlagGuia,
            Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),

            Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
            Filtro_FechaTraslado: $(Contenedor + 'txtFechaTraslado').val(),
            Filtro_CodTipoCliente: 1,
            Filtro_CodClaseCliente: 1,
            Filtro_CodDepartamento: $('#hfCodDepartamento').val(),

            Filtro_CodProvincia: $('#hfCodProvincia').val(),
            Filtro_CodDistrito: $('#hfCodDistrito').val(),
            Filtro_ApePaterno: '',
            Filtro_ApeMaterno: '',
            Filtro_Nombres: '',

            Filtro_RazonSocial: RazonSocial,
            Filtro_NroDni: '',
            Filtro_NroRuc: $(Contenedor + 'txtNroRuc').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
            Filtro_Destino: $(Contenedor + 'txtDestino').val(),

            Filtro_FlagIgv: FlagIgv,
            Filtro_Placa: $(Contenedor + 'txtPlaca').val(),
            Filtro_Cliente: RazonSocial,
            Filtro_CodTasa: $(Contenedor + 'ddlIgv').val(),
            Filtro_SerieOC: '',

            Filtro_NumeroOC: '',
            Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
            Filtro_CodTipoOperacion: 1,
            Filtro_Partida: $('#hfPartida').val(),

            Filtro_Descuento: 0

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_GrabarDocumento_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se grabo correctamente') {
                    alertify.log('Se grabo correctamente');
                    $('#MainContent_txtNumero').val(result.split('~')[3]);
                    if ($('#MainContent_chkImpresion').is(':checked')) {
                        F_ImprimirFactura(result.split('~')[2]);
                    }
                    F_Nuevo();

                }
                else {
                    alertify.log(str_mensaje_operacion);
                    return false;
                }

            }
            else {
                alertify.log(result.split('~')[1]);
                return false;
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#hfCodTraslado').val('0');
    $('#hfCodProforma').val('0');
    $('#hfCodDepartamento').val('0');
    $('#hfCodProvincia').val('0');
    $('#hfCodDistrito').val('0');
    $('#hfCodCtaCte').val('0');
    $('#MainContent_ddlMoneda').val('1');
    $('#MainContent_ddlFormaPago').val('1');
    $('#MainContent_ddlSerie').val('1');
    $('#hfCodigoTemporal').val('0');

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = dd + '/' + mm + '/' + yyyy;

    $('#MainContent_txtEmision').val(today);
    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtPlaca').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtSubTotal').val('0.00');
    $('#MainContent_txtIgv').val('0.00');
    $('#MainContent_txtTotal').val('0.00');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_chkGuia').prop('checked', false);
    $('#MainContent_chkServicios').prop('checked', false);
    $('#MainContent_chkNotaPedido').prop('checked', false);
    $('#MainContent_chkImpresion').prop('checked', true);
    $('#MainContent_txtNroRuc').val('');
    $('#MainContent_txtCliente').focus();

    try {
        var objParams = {
            Filtro_CodSerie: '1',
            Filtro_CodSerieGuia: '4'

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Nuevo_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#MainContent_txtNumero').val(result.split('~')[3]);
                $('#MainContent_txtNumeroGuia').val(result.split('~')[4]);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
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
            Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_CodTipoDoc: '1',
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente

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
                 $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodigo'));
                if (str_mensaje_operacion != '')
                    alertify.log(str_mensaje_operacion);

            }
            else {
                alertify.log(result.split('~')[1]);
            }
            
            $('.ccsestilo').css('background', '#FFFFE0');
            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
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

function esnumero(campo) { return (!(isNaN(campo))); }

function F_VisualizarExcel_Grilla(Fila) {
if (F_PermisoOpcion(CodigoMenu, 3000703, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    var lblCodigo = '#' + Fila.replace('imgExcel', 'lblCodigo');

    F_VisualizarExcel($(lblCodigo).text());
return true;
}

function F_VisualizarExcel(Codigo) {
    if (Codigo == 0)
        return false;

    var Cuerpo = '#MainContent_';
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodMenu = '3';

    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ReemplazarFactura(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    var Fila = '#' + Fila;
    var lblCodTemporal = Fila.replace('imgReemplazar', 'lblCodigo');
    var hfFechaEmision = Fila.replace('imgReemplazar', 'hfFechaEmision');

    var objParams = {
        Filtro_Codigo: $(lblCodTemporal).text(),
        Filtro_Igv: '1',
        Filtro_CodMoneda: '1',
        Filtro_Tasa: '1',
        Filtro_TasaIgv: '1'
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);

    F_ConsultarTemporal_NET(arg, function (result) {

        MostrarEspera(false);

        var str_resultado_operacion = "";
        var str_mensaje_operacion = "";

        str_resultado_operacion = result.split('~')[0];
        str_mensaje_operacion = result.split('~')[1];

        if (str_resultado_operacion == "1") {
            $('#hfCodigoTemporal').val($(lblCodTemporal).text());
            $('#MainContent_txtEmision').val($(hfFechaEmision).val());
            F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
//            if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
            //                alertify.log('Los Producto(s) se han agregado con exito');

            $("#divTabs").tabs("option", "active", $("#liRegistro").index());

        }
        else {
            alertify.log(result.split('~')[2]);
        }

        return false;

    });

    
    return true;
}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
        var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'hfUsuario');

        if (!confirm("ESTA SEGURO DE ELIMINAR LISTA DEL USUARIO " + $(lblcliente_grilla).val()))
            return false;


        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        var objParams = {
            Filtro_Codigo: $(lblCodigo).text(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_ChkFecha: chkFecha,
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AnularTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                //                alertify.log(result.split('~')[1]);
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function getContentTab() {
    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}

function F_AgregarArticulo(ControlID, DirectoBoton) {
//    var txtprecio_Grilla = '';
//    var ddlLista_grilla = '';
//    var txtcant_grilla = '';
//    var txtprecio_grilla = '';
//    var ddlprecio_grilla = '';
//    var hfArticulo_grilla = '';
//    var hfPrecio1_grilla = '';
//    var hfPrecio2_grilla = '';
//    var hfPrecio3_grilla = '';
//    var lblCodigoProducto_grilla = '';
//    var lblStock_grilla = '';
//    var lblUM_grilla = '';
//    var lblMoneda_grilla = '';
//    var lblCodProducto_grilla = '';
//    var lblCosto_grilla = '';
//    var lblCodUm_grilla = '';
//    var boolEstado = false;
//    var imgAgregar_grilla = '';
//    var cadena = 'Ingrese los sgtes. campos: '

//    imgAgregar_grilla = '#' + ControlID;
//    ctrlPosActual = imgAgregar_grilla;
//    txtprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtPrecioLibre');
//    ddlprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlPrecio');
//    txtcant_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtCantidad');
//    ddlLista_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlLista');
//    hfArticulo_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblProducto');
//    hfPrecio1_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio1');
//    hfPrecio2_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio2');
//    hfPrecio3_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio3');
//    lblCodigoProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hlkCodNeumaticoGv');
//    lblStock_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblstock');
//    lblUM_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblUM');
//    lblMoneda_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfMoneda');
//    lblCosto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcosto');
//    lblCodUm_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcodunidadventa');

//    lblCodProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblcodproducto');

//    $('#hfCodProductoAgregar').val($(lblCodProducto_grilla).val());
//    $('#hfCostoAgregar').val($(lblCosto_grilla).val());
//    $('#hfCodUmAgregar').val($(lblCodUm_grilla).val());
//    $('#MainContent_txtCodigoProductoAgregar').val($(lblCodigoProducto_grilla).text());
//    $('#MainContent_txtUMAgregar').val($(lblUM_grilla).text());
//    $('#MainContent_txtStockAgregar').val($(lblStock_grilla).text());
//    $('#MainContent_lblMonedaAgregar').text($(lblMoneda_grilla).val());
//    

//    $('#MainContent_txtArticuloAgregar').val($(hfArticulo_grilla).text());
//    $('#MainContent_txtCantidad').val(1);
//    $('#MainContent_txtPrecioDisplay').val($(hfPrecio1_grilla).val());
//    $("#hfMenorPrecioAgregar").val(0);

//    $("#MainContent_ddlPrecio").empty();

//    if ($(hfPrecio1_grilla).val() != '')
//    {
//        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio1_grilla).val()).html($(hfPrecio1_grilla).val()));
//        $("#hfMenorPrecioAgregar").val($(hfPrecio1_grilla).val());
//    }

//    if ($(hfPrecio2_grilla).val() != '0.00') {
//        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio2_grilla).val()).html($(hfPrecio2_grilla).val()));

//        if (Number($(hfPrecio2_grilla).val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($(hfPrecio2_grilla).val()) > 0)
//            $("#hfMenorPrecioAgregar").val($(hfPrecio2_grilla).val());
//    }

//    if ($(hfPrecio3_grilla).val() != '0.00') {
//        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio3_grilla).val()).html($(hfPrecio3_grilla).val()));

//        if (Number($(hfPrecio3_grilla).val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($(hfPrecio3_grilla).val()) > 0)
//            $("#hfMenorPrecioAgregar").val($(hfPrecio3_grilla).val());
//        }

//    $('#MainContent_chkServicios').prop('checked', false);

   
    F_Consultar_Almacenes_Stocks(ControlID);
//    if (DirectoBoton === 1)
//        F_TablaClick(ControlID);
    return false;
}

function F_Consultar_Almacenes_Stocks(CodigoProducto) {
    var Marca = $("#" + CodigoProducto.replace("imgAgregar", "hfMarca")).val();
    var CodProductoAzure = $("#" + CodigoProducto.replace("imgAgregar", "hfCodProductoAzure")).val();
    var CodigoInterno = $("#" + CodigoProducto.replace("imgAgregar", "hfCodigoInterno")).val();
    CodProductoAzure = 0;


    $('#tbStocksAlmacenes .td-tdsel').each(function () {
        trControl = this.id; var len = trControl.length; var tdControl = "#td" + trControl.substring(2, len);
        $(tdControl).text("");
        $(tdControl).append('<img class="cssimgAlmacen" style="width:8px" src="../Asset/images/loading.gif" />');
        
    });

//    $('.cssimgAlmacen').each(function() {
//        $(this).css('display', 'block');
//    });
//    
    F_Consulta_Stock(CodProductoAzure, CodigoInterno);

    return true;

return true;
}

function F_Consulta_Stock(CodigoProducto, CodigoInterno) {

    if (CodigoProducto == "")
        CodigoProducto = 0;

        $.ajax({
            async: true,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/Servicios.asmx/F_Consulta_Stock_Azure_NET',
            dataType: "json",
            data: "{'CodProductoAzure':'" + CodigoProducto + "','CodigoInterno':'" + CodigoInterno + "'}",
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;
                try {
                    $('.cssimgAlmacen').each(function () {
                        $(this).css('display', 'none');
                    });
                    $.each(data.rows, function (index, item) {

                        if (item.ConsultadoSN === '0')
                            $('#td' + item.Clave).text('N/A');
                        else
                            $('#td' + item.Clave).text(item.Stock);
                    });
                }
                catch (x) { alertify.log('El Producto no tiene Imagenes'); }
                MostrarEspera(false);
            },
            complete: function () {

            },
            error: function (xhr, ajaxOptions, thrownError) {
            alertify.log(thrownError);
            },
            async: true
        });
        return true;
    }

function F_Inicializar_Tabla_Almacenes_Stocks() {
        //limpio el div donde se encuentra el table
    var ta = $('#divStocksEmpresas'); ta.empty();
    
    //Table
    var Table = '   <table id="tbStocksAlmacenes" Class="GridView"> <thead> <tr> <th style="width:180px"> otros almacenes </th> <th style="width:25px"> Stock </th> </tr> </thead> ' +
		        '   <tbody> @Body </tbody> </table> ';

    var Row =   '   <tr id="@ID" class="td-tdsel"> ' +
				'       <td> @Almacen </td>' + 
				'       <td id="@Clave" align="right"> @Cuanto </td> ' +
			    '   </tr> ';
    var Cuerpo = '';
    
    var Count = 0;
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '../Compras/RegistroFacturaCompraNuevo.aspx/F_Inicializar_Tabla_Almacenes_Stocks_NET',
        dataType: "json",
        //data: JSON.stringify({ 'CodAlterno': objParams }),
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {
                $.each(data.rows, function (index, item) {
                    Cuerpo += Row.replace("@Almacen", item.Empresa + ' - ' + item.DscAlmacen)
                                    .replace("@Clave", "td" + item.Clave).replace("@ID", "tr" + item.Clave)
                                    .replace("@Cuanto", 0);
                    Count++;
                });

                Table = Table.replace('@Body', Cuerpo);
                //var ta = $('#divProductosRelacionadosListado'); ta.empty();
                ta.append(Table);

//                $('.cssimgAlmacen').each(function() {
//                    $(this).css('display', 'none');
//                });

            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });

return true;
}

function numerar() {
    var c = 0;
    $('.detallesart2').each(function () {
        c++;
        $(this).text(c.toString());
    });
    $("#MainContent_lblNumRegistros").text(c);
}