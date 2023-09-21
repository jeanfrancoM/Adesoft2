﻿var AppSession = "../Compras/RegistroGasto.aspx";

var CodigoMenu = 3000;
var CodigoInterno = 5;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

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
            
        },
        minLength: 3
    });

    $('#MainContent_txtClienteConsulta').autocomplete({
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
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy',
        maxDate: '0'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#divTabs').tabs();   
    
    $('#MainContent_txtDesde').datepicker({onSelect: function() {
      var date = $(this).datepicker('getDate');
      if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
      }
      }}); 

    $('#MainContent_txtDesde').datepicker({beforeShowDay: function(date) {
      return [date.getDate() == 1, ''];
    }});

    $('#MainContent_imgBuscar').click(function () {
        try 
        {
        var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val=="")
            cadena=cadena + "<p></p>" + "Articulo"

              if ($('#MainContent_ddlMoneda option').size() == 0)
              { cadena = cadena + "<p></p>" + "Moneda"; }
              else 
              {
              if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "<p></p>" + "Moneda";
              }

              if ( cadena != "Ingresar los sgtes. campos :")
              {
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

    $('#MainContent_btnGrabarEdicion').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            F_EditarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnAgregarProducto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try 
        {
               
                $('#MainContent_txtArticulo').val('');
                
                $("#divConsultaArticulo").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Productos",
                    title_html: true,
                    height: 500,
                    width: 1000,
                    autoOpen: false
                });

                $('#divConsultaArticulo').dialog('open');
               
                $('#MainContent_txtArticulo').focus();
              
               
                    $('#MainContent_chKConIgv').prop('checked', true);
                    $('#MainContent_chkSinIgv').prop('checked', false); 
                
                 var objParams = { };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


                F_CargarGrillaVaciaConsultaArticulo_NET(arg, function (result) {
//                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

//                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);    
                                
                  
                }
                else 
                {
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

    $('#MainContent_btnAgregar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
        if (F_ValidarAgregar()==false)
        return false;

        F_AgregarTemporal();
        F_LimpiarGrillaConsulta();
        $('#MainContent_txtArticulo').focus();
        return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnEliminar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
            if(F_ValidarEliminar()==false)
              return false;

            if (confirm("Esta seguro de quitar los productos seleccionado"))
            F_EliminarTemporal();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnGrabar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
     try 
        {
            if(!F_ValidarGrabarDocumento())
              return false;

            if (confirm("ESTA SEGURO DE GRABAR EL GASTO"))
            F_GrabarDocumento();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnNuevo').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_Nuevo();
          
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnBuscarConsulta').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_Buscar();
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });
    
    $('#MainContent_txtFechaIngreso').on('change', function (e) {
        $("#MainContent_txtPeriodo").val($('#MainContent_txtFechaIngreso').val().substr($('#MainContent_txtFechaIngreso').val().length - 4) + $('#MainContent_txtFechaIngreso').val().substring(3, 5));
    });

    $("#MainContent_txtTotal").blur(function () {

    if ($("#MainContent_txtTotal")=='')
    return false;

        $("#MainContent_txtTotal").val(parseFloat($("#MainContent_txtTotal").val()).toFixed(2));
        $("#MainContent_txtSubTotal").val(parseFloat($("#MainContent_txtTotal").val()/(parseFloat($("#MainContent_ddlIgv option:selected").text())+1)).toFixed(2));
        $("#MainContent_txtIgv").val(parseFloat($("#MainContent_txtTotal").val()-$("#MainContent_txtSubTotal").val()).toFixed(2));
       
        return false;
       
    });

    $("#MainContent_txtTotal").keydown(function (e) {
       if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
           return;
       }
       if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
           e.preventDefault();
   });

    $("#MainContent_txtDsctoTotal").keydown(function (e) {
       if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
           return;
       }
       if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
           e.preventDefault();
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

    $('#MainContent_txtProveedor').focus();

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtSerie').css('background', '#FFFFE0');

    $('#MainContent_txtDsctoTotal').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtPeriodo').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    F_Controles_Inicializar();

     F_Derecha();

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

function VerifySessionState(result) { }

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val()
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
                    if (str_resultado_operacion == "1") 
                    {
                        F_Update_Division_HTML('div_formapago', result.split('~')[2]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[3]);
                        $('#MainContent_lblTC').text(result.split('~')[4]);
                        F_Update_Division_HTML('div_igv', result.split('~')[5]);
                        F_Update_Division_HTML('div_tipodocumento', result.split('~')[6]);
                        F_Update_Division_HTML('div_clasificacion', result.split('~')[7]);
                        $('#MainContent_ddlTipoDocumento').val(1);
                        $('#MainContent_ddlClasificacion').val(9);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlFormaPago').val(1);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlClasificacion').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                    
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

function F_Prueba(){

           if ($('#MainContent_chkSinIgv').is(':checked'))
               $('#MainContent_chKConIgv').prop('checked', false);
           else
               $('#MainContent_chKConIgv').prop('checked', true);
return false;
}    
     
function F_ValidarCheckSinIgv(ControlID) {

   var chkok_grilla='';

            chkok_grilla = '#' + ControlID;
           
           if ($(chkok_grilla).is(':checked'))
               $('#MainContent_chkSinIgv').prop('checked', false);
           else
               $('#MainContent_chkSinIgv').prop('checked', true);
         
   return false;
}

$(document).on("change", "select[id $= 'MainContent_ddlFormaPago']",function () {
     F_FormaPago($("#MainContent_ddlFormaPago").val());
} );

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val()
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
                    if (str_resultado_operacion == "1") 
                    {
                        F_Update_Division_HTML('div_formapago', result.split('~')[2]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[3]);
                        $('#MainContent_lblTC').text(result.split('~')[4]);
                        F_Update_Division_HTML('div_igv', result.split('~')[5]);
                        F_Update_Division_HTML('div_tipodocumento', result.split('~')[6]);
                        F_Update_Division_HTML('div_clasificacion', result.split('~')[7]);
                        $('#MainContent_ddlClasificacion').val(9);
                        $('#MainContent_ddlTipoDocumento').val(1);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlFormaPago').val(1);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        $('#MainContent_ddlClasificacion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                    
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

function F_Buscar_Productos() {

    var arg;
    var CodTipoProducto='2';
    try {
        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
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
                    }
                    else {
                    MostrarEspera(false);
                        alertify.log(str_mensaje_operacion);

                    }


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

             switch ($(ddlLista_Grilla).val()) 
             {
              case "1":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio1');
                        $(txtprecio_grilla).val($(lblprecio).text());
                       $(txtprecio_grilla).prop('disabled', true);
                        $(txtcant_grilla).focus();
                        break;

              case "2":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio2');
                        $(txtprecio_grilla).val($(lblprecio).text());
                         $(txtprecio_grilla).prop('disabled', true);
                        $(txtcant_grilla).focus();
                        break;
              case "3":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio3');
                        $(txtprecio_grilla).val($(lblprecio).text());
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

function F_ValidarCheck(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla='';

    var cadena='Ingrese los sgtes. campos: '
            
            chkok_grilla = '#' + ControlID;
            txtprecio_grilla = chkok_grilla.replace('chkOK', 'txtPrecioLibre');
            txtcant_grilla = chkok_grilla.replace('chkOK', 'txtCantidad');
            ddlLista_grilla = chkok_grilla.replace('chkOK', 'ddlLista');
          
            
            boolEstado = $(chkok_grilla).is(':checked');
            if (boolEstado)
            {
               
                $(txtcant_grilla).prop('disabled', false);
                var i=0;
                if($(txtprecio_grilla).val()=="")
                {$(txtprecio_grilla).focus();
                i=1}

                if(i==0 && $(txtcant_grilla).val()=="")
                {$(txtcant_grilla).focus();}
            }
            else
            {
                $(txtprecio_Grilla).val('');
                $(txtcant_grilla).val('');
                $(ddlLista_grilla).val('4');
              
                $(txtcant_grilla).prop('disabled', true);
            }
            
        
    return true;
}

function F_FormaPago(CodFormaPago) {
 var arg;
    try 
    {
     switch (CodFormaPago)
     {
             case "1":
             case "12":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;

            case "3":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),30));
                       break;

            case "4":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),15));
                       break;

            case "8":
               $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),45));
               break;

            case "9":
               $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),60));
               break;

                case "11":
               $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),7));
               break;
     }

     
    }
     catch (mierror) 
     {
        alertify.log("Error detectado: " + mierror);
     }

}

function F_MostrarTotales(){

var lblimporte_grilla='';
var chkDel='';
var Total=0;
var Igv=0;
var Subtotal=0;
     $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
             chkDel = '#' + this.id;
             lblimporte_grilla = chkDel.replace('chkEliminar', 'lblimporte');
             Total+=parseFloat($(lblimporte_grilla).text());
     });
     var Cuerpo='#MainContent_'
    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgv').val((Total*parseFloat($(Cuerpo + 'ddligv').val())).toFixed(2));
    $(Cuerpo + 'txtSubTotal').val((Total/(1+parseFloat($(Cuerpo + 'ddligv').val()))).toFixed(2));

}

function F_ValidarGrabarDocumento(){
    try 
        {
        var Cuerpo='#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>'; 

        if ($(Cuerpo + 'txtProveedor').val()=='' || $('#hfCodCtaCte').val()==0)
                Cadena=Cadena + '<p></p>' + 'Proveedor';
        
        if ($(Cuerpo + 'lblTC').text()=='0')
                Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtSerie').val()=='')
                Cadena=Cadena + '<p></p>' + 'Serie de Factura';

        if ($(Cuerpo + 'txtNumero').val()=='')
                Cadena=Cadena + '<p></p>' + 'Numero de Factura';

        if ($(Cuerpo + 'txtEmision').val()=='')
                Cadena=Cadena + '<p></p>' + 'Fecha de Emision';

        if ($(Cuerpo + 'txtPeriodo').val()=='')
                Cadena=Cadena + '<p></p>' + 'Periodo Contable';

         if ($(Cuerpo + 'txtTotal').val()=='' | $(Cuerpo + 'txtTotal').val()=='0.00')
                Cadena=Cadena + '<p></p>' + 'Total';

        if ($(Cuerpo + 'txtSubTotal').val()=='' | $(Cuerpo + 'txtSubTotal').val()=='0.00')
                Cadena=Cadena + '<p></p>' + 'SubTotal';

        if ($(Cuerpo + 'txtIgv').val()=='' | $(Cuerpo + 'txtIgv').val()=='0.00')
                Cadena=Cadena + '<p></p>' + 'Igv';

        if ($(Cuerpo + 'txtDsctoTotal').val()=='')
                Cadena=Cadena + '<p></p>' + 'Descuento';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>')
        {alertify.log(Cadena);
        return false;}
        return true;
        }        
    catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
}

function F_GrabarDocumento(){

  try 
        {
       

        var lblcodproducto_grilla='';
        var lblcodunidadventa_grilla='';
        var lblcosto_grilla='';
        var chkSi='';
        var txtcantidad_grilla='';
        var txtprecio_grilla='';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla='';
        var hfcosto_grilla='';
        var FlagGuia='0';
        var NotaPedido='0';
        var Contenedor = '#MainContent_';
          

                var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                var objParams = {
                                        Filtro_CodTipoDoc: $(Contenedor + 'ddlTipoDocumento').val(),
                                        Filtro_SerieDocSust: $(Contenedor + 'txtSerie').val(),
                                        Filtro_NumeroDocSust: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaIngreso: $(Contenedor + 'txtEmision').val(),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_ImpSubTotal: $(Contenedor + 'txtSubTotal').val(),
                                        Filtro_ImpIGV: $(Contenedor + 'txtIgv').val(),
                                        Filtro_ImpTotal: $(Contenedor + 'txtTotal').val(),
                                        Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                                        Filtro_Descuento: $(Contenedor + 'txtDsctoTotal').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_Periodo: $(Contenedor + 'txtPeriodo').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        Filtro_CodCategoria: $(Contenedor + 'ddlClasificacion').val() ,
                                        Filtro_CodClasificacion: 1
                                        
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_GrabarDocumento_NET(arg, function (result) {
                
                 MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                  
                    if (str_mensaje_operacion=='Se grabo correctamente')
                    alertify.log('Se grabo correctamente');
                    F_Nuevo();
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
}

function F_Nuevo(){


       $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
       $('.Jq-ui-dtp').datepicker('setDate', new Date());
       $('.MesAnioPicker').datepicker($.datepicker.regional['es']);
       $('.MesAnioPicker').datepicker('setDate', new Date());
       $('#MainContent_ddlMoneda').val('2');
       $('#MainContent_ddlFormaPago').val('1');
       $('#MainContent_ddlTipoDocumento').val('1');
       $('#hfCodigoTemporal').val('0');
       $('#hfCodCtaCte').val('0');
       $('#MainContent_txtProveedor').val('');
       $('#MainContent_txtSubTotal').val('0.00');
       $('#MainContent_txtIgv').val('0.00');
       $('#MainContent_txtTotal').val('0.00');
       $('#MainContent_txtSerie').val('');
       $('#MainContent_txtNumero').val('');
       $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
       $('#MainContent_txtArticulo').val('');
       $('#MainContent_txtProveedor').focus();

}

function F_Buscar(){
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
       try 
        {
              var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';
              
              var objParams = {
                                     
                                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                        Filtro_ChkNumero: chkNumero,
                                        Filtro_ChkFecha: chkFecha,
                                        Filtro_CodClasificacion: 1,
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

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]); 
                        $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblcodigo'));
                    if (str_mensaje_operacion!='')                        
                    alertify.log(str_mensaje_operacion);
                  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
    var imgID = Fila.id;
    var lblCodMarcaGv = '#' + imgID.replace('imgAnularDocumento', 'lblcodigo');
    var lblestado_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblestado');
    var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');


    if(!confirm("ESTA SEGURO DE ELIMINAR FAC/BOL : " + $(lblnumero_grilla).text() + "\n" + "DEL PROVEEDOR : " +  $(lblcliente_grilla).text()))
    return false;
     var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

    var objParams = {
                          Filtro_Codigo: $(lblCodMarcaGv).text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: 1,
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_CodClasificacion: 9,
                          Filtro_ChkCliente: chkCliente
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);
    F_AnularRegistro_Net(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
        MostrarEspera(false);
        if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);      
                alertify.log(result.split('~')[1]);
        }
        else {
             alertify.log(result.split('~')[1]);
        }

        return false;
    });

            }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function getContentTab(){

    var date = new Date();
    date.setMonth(date.getMonth(), 1);
 
    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));
    $('#MainContent_ddlSerieConsulta').val('0');
    $('#MainContent_chkRango').prop('checked',true);
    F_Buscar();
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

function F_EditarTemporal() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';

        var Contenedor = '#MainContent_';

        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);


                  var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

        var objParams = {
                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                        Filtro_ChkNumero: chkNumero,
                        Filtro_ChkFecha: chkFecha,
                        Filtro_ChkCliente: chkCliente,
                        Filtro_Periodo: $('#MainContent_txtPeriodoConsulta').val(),
                        Filtro_CodMovimiento: $('#hfCodDocumentoVenta').val(),
                        Filtro_CodClasificacion: 9,
                        Filtro_CodTipoDocSust: 1
                                    
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EditarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
          
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);    
                    if (str_mensaje_operacion!='')                        
                    alertify.log(str_mensaje_operacion);
                $('#div_Mantenimiento').dialog('close');
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

function F_TipoCambio(){
    try 
        {
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
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

}

function F_EditarRegistro(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
            
        $("#div_Mantenimiento").dialog({
            resizable: false,
            modal: true,
            title: "Edicion Registro",
            title_html: true,
            height: 120,
            width: 300,
            autoOpen: false
        });

        var imgID = Fila.id;

        var lblPeriodo = '#' + imgID.replace('imgEditarRegistro', 'lblPeriodo');
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblcodigo');
        
        $(Contenedor + 'txtPeriodoConsulta').val($(lblPeriodo).text());
        $('#hfCodDocumentoVenta').val($(lblCodigo).text());

        $('#div_Mantenimiento').dialog('open');

        return false;


    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
        return false;
    }

}