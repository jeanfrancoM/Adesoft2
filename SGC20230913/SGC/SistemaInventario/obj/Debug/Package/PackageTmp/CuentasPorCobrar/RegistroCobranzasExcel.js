var AppSession = "../CuentasPorCobrar/RegistroCobranzasExcel.aspx";

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
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'0'}",
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

    $('#MainContent_txtProveedorConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'0'}",
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
        dateFormat: 'dd/mm/yy'
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

    $('#MainContent_btnAgregarFactura').click(function () {

            F_Buscar_Factura();
//      if ($('#MainContent_chkFactura').is(":checked"))
//        F_Buscar_Factura();
//     else
//        F_Buscar_Letra();

        return false;
       
    });  

    $('#MainContent_btnAgregar').click(function () {
     try 
        {
            if ($('#hfCobranzas').val()==0)
            { 
                if (!F_ValidarAgregar())
                    return false;
                F_AgregarTemporal();
            }
            else
            {
                if (!F_ValidarAgregarFacturaCobranzas())
                    return false;
                F_AgregarTemporalCobranzas();        
            }
            return false;
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }     
        });

    $('#MainContent_btnEliminarFactura').click(function () {
     try 
        {
            if(!F_ValidarEliminar_Factura())
              return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LAS FACTURAS SELECCIONADAS"))
            F_EliminarTemporal_Factura();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnGrabar').click(function () {
     try 
        {
            if(!F_ValidarGrabarDocumento())
              return false;

            if (confirm("ESTA SEGURO DE GRABAR LA COBRANZA"))
            F_GrabarDocumento();

            return false;
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
             
        });


    $('#MainContent_btnEdicionMedioPago').click(function () {

        if ($('#MainContent_ddlCuentaEdicion option:selected').text() == '' )
         {
            alertify.log('DEBE ESPECIFICAR UNA CUENTA VALIDA');
            return false;
         };

        if ($('#MainContent_txtNroOperacionEdicion').val() == '')
        {
            alertify.log('DEBE ESPECIFICAR UN NUMERO DE OPERACION');
            return false;
        }
        if (confirm("ESTA SEGURO DE EDITAR LOS MEDIOS DE PAGO"))
        F_EdicionMedioPago();

        return false;
       
    });  

    $('#MainContent_btnNuevo').click(function () {
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

    $('#MainContent_btnGrabarLetra').click(function () {
     try 
        {
            if(F_ValidarAgregarLetra()==false)
              return false;

            if (confirm("Esta Seguro de Agregar la Letra"))
            F_AgregarLetra();
//                F_Nuevo();
//            }
            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnEliminarLetra').click(function () {
     try 
        {
            if(F_ValidarEliminar_Letra()==false)
              return false;

            if (confirm("Esta seguro de eliminar la(s) letra(s) seleccionada(s)"))
            F_EliminarTemporal_Letra();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnCobranzas').click(function () {
        try 
        {
          var Cadena = "Ingrese los sgtes. campos: "     
          if ($('#hfCodCtaCte').val()=="0")
          Cadena=Cadena + '<p></p>' + "Razon Social";

          if (Cadena != "Ingrese los sgtes. campos: ")
          {alertify.log(Cadena);
          return false;
          }
          
                $("#divConsultaFactura").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Factura",
                    title_html: true,
                    height: 450,
                    width: 420,
                    autoOpen: false
                });

                $('#divConsultaFactura').dialog('open');
               
                var Letra=0;
                var Factura=0;

                if ($('#MainContent_chkFactura').is(':checked'))
                Factura=1;

                if ($('#MainContent_chkFactura').is(':checked'))
                Letra=1;

                 var objParams = {
                                    Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                    Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                                    Filtro_Letra: Letra,
                                    Filtro_Factura: Factura
                                 };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                  MostrarEspera(true);

                F_Buscar_FacturaPagos_NET(arg, function (result) {


                 MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    $('#hfCobranzas').val(1);

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);                            
                $('#hfCobranzas').val(1);     
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });


        }
        catch (e) {
         MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }


        return false;

    });  

    $('#MainContent_btnCobranzasEliminar').click(function () {
     try 
        {
            if(!F_ValidarEliminar_FacturaCobranza())
              return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LAS FACTURAS SELECCIONADAS"))
            F_EliminarTemporal_FacturaCobranza();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnNotaVenta').click(function () {
        try 
        {
          var Cadena = "Ingrese los sgtes. campos:  <br> <p></p>"     


//           if ($('#hfCodCtaCte').val()=="4479")
//             $('#hfCodCtaCte').val("3873");

//          if ($('#hfCodCtaCte').val()!="3873")
//          Cadena=Cadena + '<p></p>' + "Cliente Varios";

          if (Cadena != "Ingrese los sgtes. campos:  <br> <p></p>")
          {alertify.log(Cadena);
          return false;
          }
          
                $("#divConsultaFactura").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Nota de Venta",
                    title_html: true,
                    height: 450,
                    width: 450,
                    autoOpen: false
                });

                $('#divConsultaFactura').dialog('open');               

                 var objParams = {
                                    Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                                    Filtro_Total: '700'
                                 };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Buscar_NotaVenta_NET(arg, function (result) {
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);   
                     $('#hfNotaVenta').val(0);                         
                  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });


        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }


        return false;

    }); 

    $('#MainContent_txtEmision').on('change', function (e) {
        F_ListarNroCuenta($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });

    $('#MainContent_txtAmortizacion').blur(function () {
     if ($('#MainContent_txtAmortizacion').val()=='')
     $('#MainContent_txtAmortizacion').val('0.00');

     $('#MainContent_txtTotalPago').val(parseFloat(parseFloat($('#MainContent_txtAmortizacion').val()) + parseFloat($('#MainContent_txtTotalFactura').val())).toFixed(3));
     $('#MainContent_txtAmortizacion').val(parseFloat($('#MainContent_txtAmortizacion').val()).toFixed(3));
     return false;
    });

    $('#MainContent_chkFactura').change(function () {
        if ($(this).is(":checked")) {
            $(this).prop("checked", true);
            $('#MainContent_chkLetra').prop("checked", false);
        }
        else
        { $(this).prop("checked", true); }
    });

    $('#MainContent_chkLetra').change(function () {
        if ($(this).is(":checked")) {
            $(this).prop("checked", true);
            $('#MainContent_chkFactura').prop("checked", false);
        }
        else
        { $(this).prop("checked", true); }
    });

    $("#MainContent_chkCComision").change(function () {
        if (this.checked)  {
          $('#MainContent_chkSComision').prop('checked', false);        
          $('#MainContent_txtComision').prop('disabled', false);   
          $('#MainContent_txtComision').val(5); }
    });

     $("#MainContent_chkSComision").change(function () {
        if (this.checked) {
          $('#MainContent_chkCComision').prop('checked', false);      
          $('#MainContent_txtComision').prop('disabled', true);   
          $('#MainContent_txtComision').val(0); }
    });

    F_Controles_Inicializar();

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtTC').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('background', '#FFFFE0');

    $('#MainContent_txtTotalFactura').css('background', '#FFFFE0');

    $('#MainContent_txtResponsable').css('background', '#FFFFE0');

    $('#MainContent_txtPagador').css('background', '#FFFFE0');

    $('#MainContent_txtTotalLetra').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtTotalDeuda').css('background', '#FFFFE0');

    $('#MainContent_txtCobroOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtTotalCobranza').css('background', '#FFFFE0');

    $('#MainContent_txtProveedorConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtComision').css('background', '#FFFFE0');



    F_Derecha();

});

$().ready(function () {

    $(document).everyTime(600000, function () {

        $.ajax({
            type: "POST",
            url: '../CuentasPorCobrar/RegistroCobranzas.aspx/KeepActiveSession',
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: VerifySessionState,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });

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

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']",function () {    
     F_ListarNroCuenta();
     var chkSi = '';
     var lblSoles = '';
     var lblDolares = '';
     var Total = 0;
     $('#MainContent_txtTotalCobranza').val("0.00") ;
     $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
            lblDolares = chkSi.replace('chkEliminar', 'lblDolares');

            if ($('#MainContent_ddlMoneda').val()==1)
                Total+= parseFloat($(lblSoles).val());
            else
                Total+= parseFloat($(lblDolares).val());
     }); 
     if(isNaN(Total))
        Total = 0.00;
     $('#MainContent_txtTotalCobranza').val(parseFloat(Total).toFixed(2));
     Total = 0;
     $('#MainContent_grvFacturaCobranzas .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
            lblDolares = chkSi.replace('chkEliminar', 'lblDolares');

            if ($('#MainContent_ddlMoneda').val()==1)
                Total+= parseFloat($(lblSoles).val());
            else
                Total+= parseFloat($(lblDolares).val());
     });  
     if(isNaN(Total))
        Total = 0.00;
     $('#MainContent_txtTotalDeuda').val(parseFloat(Total).toFixed(2)); 
     $('#MainContent_txtCobroOperacion').val(parseFloat(parseFloat($('#MainContent_txtTotalCobranza').val())-parseFloat($('#MainContent_txtTotalDeuda').val())).toFixed(2));    
     F_ValidarTextMoneda();    
} );

$(document).on("change", "select[id $= 'MainContent_ddlBanco']",function () {
     F_ListarNroCuenta();
} );

$(document).on("change", "select[id $= 'MainContent_ddlBancoEdicion']",function () {
     F_ListarNroCuentaEdicion();
} );

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodSerie: 61,
                Filtro_CodBanco: '1',
                Filtro_CodMoneda: '1'
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
                        F_Update_Division_HTML('div_moneda', result.split('~')[2]);
                        F_Update_Division_HTML('div_MedioPago', result.split('~')[4]);
                        F_Update_Division_HTML('div_Banco', result.split('~')[5]);
                        F_Update_Division_HTML('div_Cuenta', result.split('~')[6]);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[7]);
                        F_Update_Division_HTML('div_BancoEdicion', result.split('~')[8]);
                        F_Update_Division_HTML('div_CuentaEdicion', result.split('~')[9]);
                        $('#MainContent_txtTC').val(result.split('~')[3]);
                        $('#MainContent_ddlMoneda').val('1');
                        $('#MainContent_ddlSerieConsulta').val('1');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlBanco').css('background', '#FFFFE0');
                        $('#MainContent_ddlMedioPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlCuenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlMedioPago').val(1);
                        $('#MainContent_ddlBancoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCuentaEdicion').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
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

function F_ValidarAgregar(){
try 
        {
               var chkSi='';
               var cadena= '';
               var x=0;
               var j=0;
               var lblCodigo='';
               var hfCodigo='';
               var lblFactura_grilla='';
               var chkDel='';

               $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                     chkSi = '#' + this.id;
                                 
                     if ($(chkSi).is(':checked')) 
                      x=1;                       
               });

               if(x==0)
               {cadena="No ha seleccionado ninguna factura";}
               else
               { 
                    cadena="Las sgtes. facturas se encuentran agregadas :  <br> <p></p>";
                    $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo = chkSi.replace('chkOK', 'lblCodigo');
               
                         if ($(chkSi).is(':checked')) 
                            {
                                 $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                                        chkDel = '#' + this.id;
                                        hfCodigo = chkDel.replace('chkEliminar', 'hfCodigo');
                                        lblFactura_grilla = chkDel.replace('chkEliminar', 'lblFactura');
                                        if ($(lblCodigo).text()==$(hfCodigo).val())
                                        {
                                            cadena= cadena + "<p></p>"  + $(lblFactura_grilla).text();
                                            j+=1;
                                        }
                                  });
                            }
                    });
                }
                
                if (x!=0 && j==0)
                    cadena="";

                if (cadena != "")
                   {
                      alertify.log(cadena);
                      return false;
                   } 
                return true; 
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
}

function F_AgregarTemporal(){
try 
        {
        var lblCodigo_grilla='';
        var lblFactura_grilla='';
        var lblEmision_grilla='';
        var lblTotal_grilla='';
        var lblMoneda_grilla='';
        var chkSi='';
        var arrDetalle = new Array();
                   
                $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo_grilla = chkSi.replace('chkOK', 'lblCodigo');
                    lblFactura_grilla = chkSi.replace('chkOK', 'lblFactura');
                    lblEmision_grilla = chkSi.replace('chkOK', 'lblEmision');
                    lblSoles = chkSi.replace('chkOK', 'lblSoles');
                    lblDolares = chkSi.replace('chkOK', 'lblDolares');
                    lblTC = chkSi.replace('chkOK', 'lblTC');           

                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodigoFactura: $(lblCodigo_grilla).text(),
                        Factura: $(lblFactura_grilla).text(),
                        Emision: $(lblEmision_grilla).text() ,
                        Soles:   $(lblSoles).text(),
                        Dolares: $(lblDolares).text(),
                        TC: $(lblTC).text(),
                        CodCtaCte:  $('#hfCodCtaCte').val(),
                        Tipo:   'C'
                        };
                        $('#hfMoneda').val($(lblMoneda_grilla).text());
                        arrDetalle.push(objDetalle);
                    }
                });

                var objParams = {
                                    Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                    Filtro_CodigoTemporal:$('#hfCodigoTemporal').val(),
                                    Filtro_CodMoneda:$('#MainContent_ddlMoneda').val()
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);

                F_AgregarTemporal_NET(arg, function (result) {

                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotalCobranza').val(result.split('~')[5]);
                    F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                    $('#MainContent_txtCobroOperacion').val(parseFloat($('#MainContent_txtTotalCobranza').val() - $('#MainContent_txtTotalDeuda').val()).toFixed(2));
                    $('.ccsestilo').css('background', '#FFFFE0');
                    F_ValidarTextMoneda(); 
                    $('#divConsultaFactura').dialog('close');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }
                return false;
                });
        }        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
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

function F_EliminarTemporal_Factura(){

  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblID='';
        
               
                $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblID = chkSi.replace('chkEliminar', 'lblID');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {                       
                        CodDetalle: $(lblID).val()
                        };                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var objParams = {
                                  Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                  Filtro_CodigoTemporal:$('#hfCodigoTemporal').val(),
                                  Filtro_CodMoneda:$('#MainContent_ddlMoneda').val()
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);

                F_EliminarTemporal_Factura_NET(arg, function (result) {
    
                 MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                        $('#MainContent_txtTotalCobranza').val('0.00');
                    else
                        $('#MainContent_txtTotalCobranza').val(result.split('~')[5]);                   
                    
                    $('#MainContent_txtCobroOperacion').val(parseFloat($('#MainContent_txtTotalCobranza').val() - $('#MainContent_txtTotalDeuda').val()).toFixed(2));
                    F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                     F_ValidarTextMoneda(); 
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarEliminar_Factura(){

 try 
        {
        var chkSi='';
        var x=0;

                $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                               
                     if ($(chkSi).is(':checked')) 
                        x=1;
                        
               });

               if(x==0)
               {
               alertify.log("Seleccione una factura para eliminar");
               return false;
               }
               else
               {return true;}
               
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarGrabarDocumento(){
        try 
        {
            var Cuerpo='#MainContent_';
            var Cadena = 'Ingresar los sgtes. Datos:'; 

            if ($(Cuerpo + 'txtEmision').val()=='')
                    Cadena=Cadena + '<p></p>' + 'Emision';

            if (Cadena != 'Ingresar los sgtes. Datos:')
            {
                alertify.log(Cadena.toUpperCase());
                return false;
            }
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
        var Contenedor = '#MainContent_';

        var objParams = {   
                             Filtro_CodigoTemporal:        $('#hfCodigoTemporal').val(),
                             Filtro_FechaEmision:          $(Contenedor + 'txtEmision').val(),
                             Filtro_Observacion:           $(Contenedor + 'txtObservacion').val(),
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
                    if (str_mensaje_operacion=='SE REGISTRO LA COBRANZA CORRECTAMENTE')
                    { 
                            F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                            F_Update_Division_HTML('div_FacturaCobranzas', result.split('~')[5]);
                            $(Contenedor + 'txtProveedor').val('');
                            $('#hfCodigoTemporal').val('0');
                            $('#hfCodigoTemporalPago').val('0');
                            $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
                            $('.Jq-ui-dtp').datepicker('setDate', new Date());
                            alertify.log('SE REGISTRO LA COBRANZA CORRECTAMENTE');
                            $(Contenedor + 'txtProveedor').focus();
                            $('.ccsestilo').css('background', '#FFFFE0');
                            F_GenerarExcel(result.split('~')[2]);
                    }   
                    else
                    {
                        alertify.log(result.split('~')[1]);                    
                    }
                                    
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
       var Contenedor = '#MainContent_';
       $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
       $('.Jq-ui-dtp').datepicker('setDate', new Date());
       $('#MainContent_ddlMoneda').val('1');
       $('#hfCodCtaCte').val('0');
       $('#hfCodigoTemporal').val('0');
       $('#hfMoneda').val('0');  
       $(Contenedor + 'txtTotalCobranza').val('0.00');
       $(Contenedor + 'txtTotalDeuda').val('0.00') ;
       $(Contenedor + 'txtResponsable').val('');
       $(Contenedor + 'txtPagador').val('');
       $(Contenedor + 'txtCobroOperacion').val('0.00') ;
       $(Contenedor + 'txtNroOperacion').val('');
       $(Contenedor + 'ddlMoneda').val('2'),
       $(Contenedor + 'ddlMedioPago').val(1),
       $(Contenedor + 'ddlBanco').val('1');
       $(Contenedor + 'ddlCuenta').val('2');
       $(Contenedor + 'txtProveedor').val('');
       $('#hfCodCtaCte').val('0');
       alertify.log('Se registro la cobranza correctamente');
       $(Contenedor + 'txtProveedor').focus();
       try 
        {
              var objParams = {
                                        Filtro_CodSerie: '61'
                                        
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Nuevo_NET(arg, function (result) {
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {                  
                    F_Update_Division_HTML('div_grvFactura', result.split('~')[3]);                            
                    F_Update_Division_HTML('div_FacturaCobranzas', result.split('~')[4]);         
                    $('.ccsestilo').css('background', '#FFFFE0');
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

function F_Buscar(){

       try 
        {
              var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';
              var chkSerie='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

              if ($('#MainContent_chkSerie').is(':checked'))
              chkSerie='1';
              
              var objParams = {
                                 Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                                 Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                 Filtro_Desde: $('#MainContent_txtDesde').val(),
                                 Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                 Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                 Filtro_ChkNumero: chkNumero,
                                 Filtro_ChkFecha: chkFecha,
                                 Filtro_ChkCliente: chkCliente,
                                 Filtro_ChkSerie: chkSerie
                                        
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
                    if  (str_mensaje_operacion!="")                       
                    alertify.log(result.split('~')[1]);
                  
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

function F_AnularRegistro(Fila) {
 try 
        {
                var imgID = Fila.id;
                var lblID = '#' + imgID.replace('imgAnularDocumento', 'lblID');
                var lblCodigo_Factura = '#' + imgID.replace('imgAnularDocumento', 'hfcodfactura');
                var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
                var lblProveedor = '#' + imgID.replace('imgAnularDocumento', 'lblProveedor');

                if(!confirm("ESTA SEGURO DE ELIMINAR LA COBRANZA DEL CLIENTE "  + $(lblProveedor).text()))
                return false;

                var chkNumero='0';
                var chkFecha='0';
                var chkCliente='0';
                var chkSerie='0';

                if ($('#MainContent_chkNumero').is(':checked'))
                    chkNumero='1';

                if ($('#MainContent_chkRango').is(':checked'))
                    chkFecha='1';

                if ($('#MainContent_chkCliente').is(':checked'))
                    chkCliente='1';

                if ($('#MainContent_chkSerie').is(':checked'))
                    chkSerie='1';

              var objParams = {
                                      Filtro_CodCobranza: $(lblID).text(),
                                      Filtro_CodDocumentoVenta: $(lblCodigo_Factura).val(),
                                      Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                      Filtro_Desde: $('#MainContent_txtDesde').val(),
                                      Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                      Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                      Filtro_ChkNumero: chkNumero,
                                      Filtro_ChkFecha: chkFecha,
                                      Filtro_ChkCliente: chkCliente,
                                      Filtro_ChkSerie: chkSerie
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
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function getContentTab(){
//    $('#MainContent_txtDesde').val(Date_AddDays($('#MainContent_txtHasta').val(), -7));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;
}

function F_ValidarAgregarLetra(){

    try 
        {

        var Cuerpo='#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p> <br> <p></p>'; 
        var lblcoddetalle_grilla='';
        var x=0;

         $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblLetra');
                   
                    if ($(lblcoddetalle_grilla).text()==$(Cuerpo + 'txtNroLetra').val())
                    x=1;
                      
                });

        if (x==0)     
        {        
        if ($(Cuerpo + 'txtImporteLetra').val() =='')
                Cadena=Cadena + '<p></p>' + 'Importe de Letra';

        if ($(Cuerpo + 'txtImporteLetra').val() !='' && (parseFloat($(Cuerpo + 'txtImporteLetra').val())> parseFloat($(Cuerpo + 'txtTotalFacturaLetra').val())))
                Cadena=Cadena + '<p></p>' + 'El importe de la letra no puede ser mayor al total de la factura';

        if ($(Cuerpo + 'txtNroLetra').val()=='')
                Cadena=Cadena + '<p></p>' + 'Nro Letra';

        if ($(Cuerpo + 'txtVencimiento').val()=='')
                Cadena=Cadena + '<p></p>' + 'Vencimiento';

        if ($(Cuerpo + 'txtImporteLetra').val()=='')
                Cadena=Cadena + '<p></p>' + 'Importe';

        if (($(Cuerpo + 'txtTotalFactura').val() !='0.00' & $(Cuerpo + 'txtTotalLetra').val() !='0.00') && (parseFloat($(Cuerpo + 'txtTotalFactura').val()) == parseFloat($(Cuerpo + 'txtTotalLetra').val())))
                Cadena=Cadena + '<p></p>' + 'No se puede agregar mas letras; el total de la factura y la letra son iguales.';}
        else
        {
        Cadena="La letra " + $(Cuerpo + 'txtNroLetra').val() + ' se encuentra agregada';
        }

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p> <br> <p></p>')
        {alertify.log(Cadena);
        $(Cuerpo + 'txtNroLetra').focus();
        return false;}
        return true;
        }
        
    catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_AgregarLetra(){

  try 
        {
            var lblCodigo_grilla='';
            var chkSi='';
            var arrDetalle = new Array();
            var Contenedor = '#MainContent_';
       
                   
                $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo_grilla = chkSi.replace('chkEliminar', 'lblcodigo');
                  
                 
                        var objDetalle = {
                        CodFactura: $(lblCodigo_grilla).text()
                        };
                                               
                        arrDetalle.push(objDetalle);
                   
                });

          
               var objParams = {
                                        Filtro_Numero: $(Contenedor + 'txtNroLetra').val(),
                                        Filtro_Emision: $(Contenedor + 'txtFechaGiro').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        Filtro_Total: $(Contenedor + 'txtImporteLetra').val(),
                                        Filtro_Moneda: $(Contenedor + 'txtMoneda').val(),
                                        Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_TipoCambio:  $(Contenedor + 'txtTC').val(),
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        Filtro_XmlConsulta: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        
                               };


                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);
                F_AgregarLetraTemporal_NET(arg, function (result) {
  
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                   if (str_mensaje_operacion=='La(s) Letra(s) se ha agregado con exito')
                   {
                     F_Update_Division_HTML('div_grvLetra', result.split('~')[2]);  
                     $('#MainContent_txtTotalLetra').val(result.split('~')[3]);  
                     alertify.log('La(s) Letra(s) se ha agregado con exito'); 
                     F_LimpiarLetra();
                     
                   }
                   else
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

function F_ValidarEliminar_Letra(){

 try 
        {
        var chkSi='';
        var x=0;

                $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                               
                     if ($(chkSi).is(':checked')) 
                        x=1;
                        
               });

               if(x==0)
               {
               alertify.log("Seleccione una Letra para eliminar");
               return false;
               }
               else
               {return true;}
               
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_EliminarTemporal_Letra(){

  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var arrConsulta = new Array();
        var lblcoddetalle_grilla='';
        var lblCodigo_grilla='';
        
               
                $('#MainContent_grvLetra .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblCodigo');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                       
                        CodLetraCab: $(lblcoddetalle_grilla).text()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

                $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo_grilla = chkSi.replace('chkEliminar', 'lblcodigo');
                  
                 
                        var objDetalle = {
                        CodFactura: $(lblCodigo_grilla).text()
                        };
                                               
                        arrConsulta.push(objDetalle);
                   
                });

                var objParams = {
                                  Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                  Filtro_XmlConsulta: Sys.Serialization.JavaScriptSerializer.serialize(arrConsulta)
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);

                F_EliminarTemporal_Letra_NET(arg, function (result) {
         
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                   
                    if (result.split('~')[4]=='0')
                    $('#MainContent_txtTotalLetra').val('0.00');
                    else
                    $('#MainContent_txtTotalLetra').val(result.split('~')[4]);
                    F_Update_Division_HTML('div_grvLetra', result.split('~')[3]);
                    alertify.log(result.split('~')[2]);
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_LimpiarLetra(){

                $('#MainContent_txtMoneda').val($("#MainContent_ddlMoneda option:selected").text());
                $('#MainContent_txtProveedorLetra').val($('#MainContent_txtProveedor').val());
                $('#MainContent_txtFechaGiro').val($('#MainContent_txtEmision').val());
                $('#MainContent_txtTotalFacturaLetra').val($('#MainContent_txtTotalFactura').val());
                $('#MainContent_txtImporteLetra').val('');
                $('#MainContent_txtVencimiento').val('');
                $('#MainContent_txtNroLetra').val('');
                $('#MainContent_ddlFormaPago').val('3');
                F_ListarNroCuenta('3');
                $('#div_DatosLetra').dialog('open');
                $('#MainContent_txtNroLetra').focus();
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
                    $('#MainContent_txtTC').val(result.split('~')[2]);
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

function F_ListarNroCuenta() {

    var arg;

    try {

        var objParams = {

            Filtro_CodBanco:  $('#MainContent_ddlBanco').val(),
            Filtro_CodMoneda:  $('#MainContent_ddlMoneda').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarNroCuenta_NET
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
                     F_Update_Division_HTML('div_Cuenta', result.split('~')[2]);
                            $('#MainContent_ddlCuenta').css('background', '#FFFFE0');       
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


function F_ListarNroCuentaEdicion() {

    var arg;

    try {

        var objParams = {

            Filtro_CodBanco:  $('#MainContent_ddlBancoEdicion').val(),
            Filtro_CodMoneda:  $('#MainContent_ddlMoneda').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarNroCuenta_NET
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
                     F_Update_Division_HTML('div_CuentaEdicion', result.split('~')[3]);
                            $('#MainContent_ddlCuentaEdicion').css('background', '#FFFFE0');       
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



function F_ValidarAgregarFacturaCobranzas(){
try 
        {
        var chkSi='';
        var cadena= '';
        var x=0;
        var j=0;
        var lblcodproducto_grilla='';
        var lblDetalle_grilla='';
        var lblFactura_grilla='';
        var chkDel='';

               $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                                 
                    if ($(chkSi).is(':checked')) 
                        x=1;                       
               });

               if(x==0)
               {cadena="No ha seleccionado ningun documento";}
               else
               { 
               cadena="Los sgtes. documentos se encuentran agregados : ";
                    $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblCodigo');
               
                         if ($(chkSi).is(':checked')) 
                            {
                                 $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                                    chkDel = '#' + this.id;
                                    lblDetalle_grilla = chkDel.replace('chkEliminar', 'hfCodigo');
                                    lblFactura_grilla=chkDel.replace('chkEliminar', 'lblFactura');
                                    if ($(lblcodproducto_grilla).text()==$(lblDetalle_grilla).val())
                                    {
                                    cadena= cadena + "<p></p>"  + $(lblFactura_grilla).text();
                                    j+=1;
                                    }
                                  });
                            }
                    });
                }
                
                if (x!=0 && j==0)
                cadena="";

                if (cadena != "")
                   {
                      alertify.log(cadena);
                      return false;
                   } 
                   return true;                 
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
}

function F_AgregarTemporalCobranzas(){
try 
        {
        var lblCodigo_grilla='';
        var lblFactura_grilla='';
        var lblEmision_grilla='';
        var lblTotal_grilla='';
        var lblMoneda_grilla='';
        var chkSi='';
        var arrDetalle = new Array();
                   
                $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo_grilla = chkSi.replace('chkOK', 'lblCodigo');
                    lblFactura_grilla = chkSi.replace('chkOK', 'lblFactura');
                    lblEmision_grilla = chkSi.replace('chkOK', 'lblEmision');
                    lblSoles = chkSi.replace('chkOK', 'lblSoles');
                    lblDolares = chkSi.replace('chkOK', 'lblDolares');
                    lblTC = chkSi.replace('chkOK', 'lblTC');             

                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                            CodigoFactura: $(lblCodigo_grilla).text(),
                            Factura: $(lblFactura_grilla).text(),
                            Emision: $(lblEmision_grilla).text() ,
                            Soles:   $(lblSoles).text(),
                            Dolares: $(lblDolares).text(),
                            TC:      $(lblTC).text(),
                            CodCtaCte:  $('#hfCodCtaCte').val(),
                            Tipo:   'P'
                        };
                        $('#hfMoneda').val($(lblMoneda_grilla).text());
                        arrDetalle.push(objDetalle);
                    }
                });

                var objParams = {
                                Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                Filtro_CodigoTemporal:$('#hfCodigoTemporal').val(),
                                Filtro_CodMoneda:$('#MainContent_ddlMoneda').val()
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_AgregarTemporal_NET(arg, function (result) {
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotalDeuda').val(parseFloat(result.split('~')[5]).toFixed(2));
                    $('#MainContent_txtCobroOperacion').val(parseFloat(parseFloat($('#MainContent_txtTotalCobranza').val()) - parseFloat($('#MainContent_txtTotalDeuda').val())).toFixed(2));
                    F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                    F_ValidarTextMoneda();
                     $('#divConsultaFactura').dialog('close');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }
                return false;
                });
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
}

function F_EliminarTemporal_FacturaCobranza(){

  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblID='';        
               
                $('#MainContent_grvFacturaCobranzas .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblID = chkSi.replace('chkEliminar', 'lblID');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {                       
                        CodDetalle: $(lblID).val()
                        };                                               
                        arrDetalle.push(objDetalle);
                    }
                });
                            
                var objParams = {
                                  Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                  Filtro_CodigoTemporal:$('#hfCodigoTemporalPago').val(),
                                  Filtro_CodMoneda:$('#MainContent_ddlMoneda').val()
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                 MostrarEspera(true);
                F_EliminarTemporal_FacturaCobranza_NET(arg, function (result) {
                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                 $('#hfCodigoTemporalPago').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                            $('#MainContent_txtTotalDeuda').val('0.00');
                    else
                            $('#MainContent_txtTotalDeuda').val(result.split('~')[5]);
                     
                    $('#MainContent_txtCobroOperacion').val(parseFloat($('#MainContent_txtTotalCobranza').val() - $('#MainContent_txtTotalDeuda').val()).toFixed(2));
                    F_Update_Division_HTML('div_FacturaCobranzas', result.split('~')[4]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                     F_ValidarTextMoneda(); 
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarEliminar_FacturaCobranza(){

 try 
        {
        var chkSi='';
        var x=0;
                
                $('#MainContent_grvFacturaCobranzas .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                               
                     if ($(chkSi).is(':checked')) 
                        x=1;
                        
               });

               if(x==0)
               {
               alertify.log("Seleccione una proforma para eliminar");
               return false;
               }
               else
               {return true;}
               
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_VentaTC(Fila,Flag,Operacion) {
 try 
        {
            var txtTC =  '';         
            var lblID =  '';
            var lblSoles   = '';
            var lblDolares = '';
            var hfSoles =    ''; 
            var hfDolares =  ''; 
            var hfxSoles =    ''; 
            var hfxDolares =  ''; 
            var hfTC =  ''; 
            var CodigoTemporal = 0;      
            var Dolares = 0;
            var Soles = 0;  

            switch(Flag) 
            {
                case 1:
                    txtTC =  '#' + Fila;         
                    lblID =      txtTC.replace('txtTC', 'lblID');
                    lblSoles   = txtTC.replace('txtTC', 'lblSoles');
                    lblDolares = txtTC.replace('txtTC', 'lblDolares');
                    hfSoles =    txtTC.replace('txtTC', 'hfSoles'); 
                    hfDolares =  txtTC.replace('txtTC', 'hfDolares'); 
                    hfxSoles =    txtTC.replace('txtTC', 'hfxSoles'); 
                    hfxDolares =  txtTC.replace('txtTC', 'hfxDolares'); 
                    hfTC =       txtTC.replace('txtTC', 'hfTC');
                    if(parseFloat($(txtTC).val())==parseFloat($(hfTC).val()))
                        return false;
                    break;
                case 2:
                    lblSoles =  '#' + Fila;         
                    lblID =      lblSoles.replace('lblSoles', 'lblID');
                    txtTC   =    lblSoles.replace('lblSoles', 'txtTC');
                    lblDolares = lblSoles.replace('lblSoles', 'lblDolares');
                    hfSoles =    lblSoles.replace('lblSoles', 'hfSoles'); 
                    hfDolares =  lblSoles.replace('lblSoles', 'hfDolares');  
                    hfxSoles =    lblSoles.replace('lblSoles', 'hfxSoles'); 
                    hfxDolares =  lblSoles.replace('lblSoles', 'hfxDolares');
                    if(parseFloat($(hfSoles).val())==parseFloat($(lblSoles).val()))
                        return false; 
                    if(parseFloat($(hfxSoles).val()) < parseFloat($(lblSoles).val()))
                    {
                        $(lblSoles).val($(hfSoles).val());
                        return false;
                    }      
                    break;
                default:
                    lblDolares =  '#' + Fila;         
                    lblID =      lblDolares.replace('lblDolares', 'lblID');
                    txtTC   =    lblDolares.replace('lblDolares', 'txtTC');
                    lblSoles =   lblDolares.replace('lblDolares', 'lblSoles');
                    hfSoles =    lblDolares.replace('lblDolares', 'hfSoles'); 
                    hfDolares =  lblDolares.replace('lblDolares', 'hfDolares'); 
                    hfxSoles =    lblDolares.replace('lblDolares', 'hfxSoles'); 
                    hfxDolares =  lblDolares.replace('lblDolares', 'hfxDolares');  
                    if(parseFloat($(hfDolares).val())==parseFloat($(lblDolares).val()))
                        return false;  
                    if(parseFloat($(hfxDolares).val()) < parseFloat($(lblDolares).val()))
                    {
                        $(lblDolares).val($(hfDolares).val());
                        return false;
                    }                        
            }
    
            if(Operacion==0)
                CodigoTemporal = $('#hfCodigoTemporal').val();
            else
                CodigoTemporal = $('#hfCodigoTemporalPago').val();

            if($('#MainContent_ddlMoneda').val()==1)
            {
                  Soles = $(lblSoles).val();
                  Dolares = parseFloat($(lblSoles).val())/parseFloat($(txtTC).val());
            }            
            else
            {          
                  Soles = parseFloat($(lblDolares).val())*parseFloat($(txtTC).val()); 
                  Dolares = $(lblDolares).val();     
            }                
                     
            var objParams = {
                              Filtro_CodFacturaDet: $(lblID).val(),
                              Filtro_TipoCambio: $(txtTC).val(),
                              Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                              Filtro_Soles: Soles,
                              Filtro_Dolares: Dolares,
                              Filtro_CodigoTemporal: CodigoTemporal,
                              Filtro_Operacion : Operacion
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ActualizarTC_Net(arg, function (result) {

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                MostrarEspera(false);
                if (str_mensaje_operacion == "")
                {          
                     var chkSi = '';
                     var lblSoles = '';
                     var lblDolares = '';
                     var Total = 0;       
                     
                     if (Operacion==0)  
                     {
                             F_Update_Division_HTML('div_grvFactura', result.split('~')[2]);
                             $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                                     chkSi = '#' + this.id;
                                     lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
                                     lblDolares = chkSi.replace('chkEliminar', 'lblDolares');

                                     if ($('#MainContent_ddlMoneda').val()==1)
                                         Total+= parseFloat($(lblSoles).val());
                                     else
                                         Total+= parseFloat($(lblDolares).val());
                             });               
                             $('#MainContent_txtTotalCobranza').val(parseFloat(Total).toFixed(2));    
                     }
                     else
                     {
                            F_Update_Division_HTML('div_FacturaCobranzas', result.split('~')[2]);
                            $('#MainContent_grvFacturaCobranzas .chkDelete :checkbox').each(function () {
                                 chkSi = '#' + this.id;
                                 lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
                                 lblDolares = chkSi.replace('chkEliminar', 'lblDolares');

                                 if ($('#MainContent_ddlMoneda').val()==1)
                                     Total+= parseFloat($(lblSoles).val());
                                 else
                                     Total+= parseFloat($(lblDolares).val());
                            });               
                            $('#MainContent_txtTotalDeuda').val(parseFloat(Total).toFixed(2)) ;    
                     }
                     $('#MainContent_txtCobroOperacion').val(parseFloat(parseFloat($('#MainContent_txtTotalCobranza').val())-parseFloat($('#MainContent_txtTotalDeuda').val())).toFixed(2));               
                     $('.ccsestilo').css('background', '#FFFFE0');
                }
                else 
                {
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);
                    $('.ccsestilo').css('background', '#FFFFE0');
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

function F_ValidarTextMoneda()
{
        var lblSoles = '';
        var lblDolares = '';

        $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
                    lblDolares = chkSi.replace('chkEliminar', 'lblDolares');
                    if($('#MainContent_ddlMoneda').val()==1)
                    {
                        $(lblSoles).prop("readonly",false);
                        $(lblDolares).prop("readonly",true);
                    }
                    else
                    {
                        $(lblSoles).prop("readonly",true);
                        $(lblDolares).prop("readonly",false);
                    }        
         });
        
         $('#MainContent_grvFacturaCobranzas .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblSoles = chkSi.replace('chkEliminar', 'lblSoles');
                    lblDolares = chkSi.replace('chkEliminar', 'lblDolares');
                    if($('#MainContent_ddlMoneda').val()==1)
                    {
                        $(lblSoles).prop("readonly",false);
                        $(lblDolares).prop("readonly",true);
                    }
                    else
                    {
                        $(lblSoles).prop("readonly",true);
                        $(lblDolares).prop("readonly",false);
                    }        
         });
}

function F_Moneda(Fila,Flag) { 
     var lblSoles   = '#' + Fila;         
     var lblDolares = lblSoles.replace('lblSoles', 'lblDolares'); 
     var hfSoles = lblSoles.replace('lblSoles', 'hfSoles'); 
     var hfDolares = lblSoles.replace('lblSoles', 'hfDolares'); 
     
     if($(hfSoles).val()<$(lblSoles).val())  
        $(lblSoles).val($(hfSoles).val());

     if($(hfDolares).val()<$(lblDolares).val())  
        $(lblDolares).val($(hfDolares).val());
}

function F_Buscar_Factura ()
{
 try 
        {
          var Cadena = "Ingrese los sgtes. campos: "  
          if ($('#hfCodCtaCte').val()=="4479")
             $('#hfCodCtaCte').val("3873");
          if ($('#hfCodCtaCte').val()=="0")
          Cadena=Cadena + '<p></p>' + "Razon Social";

          if (Cadena != "Ingrese los sgtes. campos: ")
          {alertify.log(Cadena);
          return false;
          }
          
                $("#divConsultaFactura").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Factura",
                    title_html: true,
                    height: 450,
                    width: 440,
                    autoOpen: false
                });

                $('#divConsultaFactura').dialog('open');
               
                 var objParams = {
                                    Filtro_CodCtaCte: $('#hfCodCtaCte').val()
                                 };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Buscar_Factura_NET(arg, function (result) {
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                     F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);   
                     $('#hfCobranzas').val(0);                      
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }
                return false;
                });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
        return false;
}

function F_Buscar_Letra ()
{
   try 
        {
          var Cadena = "Ingrese los sgtes. campos: "     
          if ($('#hfCodCtaCte').val()=="0")
          Cadena=Cadena + '<p></p>' + "Razon Social";

          if (Cadena != "Ingrese los sgtes. campos: ")
          {alert(Cadena);
          return false;
          }
          
                $("#divConsultaFactura").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Letras",
                    title_html: true,
                    height: 450,
                    width: 440,
                    autoOpen: false
                });

                $('#divConsultaFactura').dialog('open');
               

                 var objParams = {
                                    Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                    Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                                    Filtro_CodTipoOperacion: 1,
                                    Filtro_Total: '700'
                                 };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Buscar_Letra_NET(arg, function (result) {
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);   
                     $('#hfCobranzas').val(0);                         
                  
                }
                else 
                {
                    alert(result.split('~')[1]);
                }

                return false;

                });


        }
        catch (e) {
            MostrarEspera(false);
            alert("Error Detectado: " + e);
        }

}


function F_EditarMedioPago(Fila) {
        try {
            var imgID = Fila.id;
            var lblCodigo = '#' + imgID.replace('imgEditar', 'lblID');
            var lblCuenta = '#' + imgID.replace('imgEditar', 'lblCuenta');
            var lblNroOperacion = '#' + imgID.replace('imgEditar', 'lblNroOperacion');
            var hfCodMedioPago = '#' + imgID.replace('imgEditar', 'hfCodMedioPago');
            var hfCodBanco = '#' + imgID.replace('imgEditar', 'hfCodBanco');
            var hfCodCtaBancaria = '#' + imgID.replace('imgEditar', 'hfCodCtaBancaria');
            var hfObservacion = '#' + imgID.replace('imgEditar', 'hfObservacion');
            var hfComision = '#' + imgID.replace('imgEditar', 'hfComision');

//            if ($(lblCuenta).text() != "" && $(lblNroOperacion).text() != "")
//                return false;

            if (!($(hfCodMedioPago).val() == '3' | $(hfCodMedioPago).val() == '7'))
            {
                alertify.log('SOLO SE PUEDE EDITAR TIPOS DE MEDIOS DE PAGO DEPOSITO Y TARJETA');
                return false;
            }


            $('#hfCodCobranza').val($(lblCodigo).text());
            $('#MainContent_ddlBancoEdicion').val($(hfCodBanco).val());
            $('#MainContent_ddlCuentaEdicion').val($(hfCodCtaBancaria).val());
            
            $('#MainContent_txtNroOperacionEdicion').val($(lblNroOperacion).text());
            $('#MainContent_txtObservacion').val($(hfObservacion).val());
            $('#MainContent_txtComision').val($(hfComision).val());


            if ($(hfComision).val() == '0.00' | $(hfComision).val() == '')
            {
                $('#MainContent_chkSComision').prop('checked', true); 
                $('#MainContent_chkCComision').prop('checked', false); 
                $('#MainContent_txtComision').prop('disabled', true); 
                $('#MainContent_txtComision').val('0'); 
            }
            else
            {
                $('#MainContent_chkSComision').prop('checked', false); 
                $('#MainContent_chkCComision').prop('checked', true);             
                $('#MainContent_txtComision').prop('disabled', false); 
            }



            $("#div_EdicionMedioPago").dialog({
                resizable: false,
                modal: true,
                title: "Numero Unico",
                title_html: true,
                height: 300,
                width: 500,
                autoOpen: false
            });



            $('#div_EdicionMedioPago').dialog('open');


            return false;

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
            return false;
        }

    }






function F_EdicionMedioPago(){
  try 
        {

        var objParams = {   
                             Filtro_CodCobranza:            $('#hfCodCobranza').val(),
                             Filtro_CodBanco:               $('#MainContent_ddlBancoEdicion').val(),
                             Filtro_CodCtaBancaria:         $('#MainContent_ddlCuentaEdicion').val(),
                             Filtro_NroOperacion:           $('#MainContent_txtNroOperacionEdicion').val(),
                             Filtro_Observacion:            $('#MainContent_txtObservacion').val(),
                             Filtro_Comision:               $('#MainContent_txtComision').val()
                         };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_EditarMedioPago_Net(arg, function (result) {
      
                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    alertify.log(result.split('~')[1]);  
                    $('#div_EdicionMedioPago').dialog('close');
                    F_Buscar();              
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

function F_GenerarExcelGrilla(ctrl) { 
    var Codigo = $('#' + ctrl.replace('imgExcel', 'lblID')).text();
    F_GenerarExcel(Codigo);
return true;
}

function F_GenerarExcel(Codigo) {
    var Cuerpo = '#MainContent_';

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodMenu = '2';

    rptURL = '../Reportes/ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodCobranza=' + Codigo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}