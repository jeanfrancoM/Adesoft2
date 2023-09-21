var AppSession = "../CuentasPorCobrar/RegistroRetenciones.aspx";
var CodigoMenu = 5000; var CodigoInterno = 2;

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

    $('#MainContent_txtClienteConsulta').autocomplete({
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

    $('#MainContent_txtEmision').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }
    });

    $('#MainContent_txtEmision').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

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
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 5000201, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac

        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Cliente";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                alertify.log(Cadena);
                return false;
            }

            $("#divConsultaFactura").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 450,
                width: 500,
                autoOpen: false
            });

            $('#divConsultaFactura').dialog('open');

            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_CodSede: $('#hfCodSede').val(),
                Filtro_FlagRenovar: $('#hfFlagRenovar').val(),
                Filtro_Total: 700,
                Filtro_CodEmpresa: $('#MainContent_ddlEmpresa').val()
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
                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);
                else
                    alertify.log(result.split('~')[1]);

                $('.ccsestilo').css('background', '#FFFFE0');

                return false;
            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
        return false;
    });

    $('#MainContent_btnAgregar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
        if (!F_ValidarAgregar())
        return false;

        F_AgregarTemporal();  
        return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnEliminarFactura').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
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
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
     try 
        {
            if(!F_ValidarGrabarDocumento())
              return false;

            if (confirm("ESTA SEGURO DE GRABAR LA RETENCION"))
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
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
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

         $('#MainContent_btnAnular').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if ($.trim($('#MainContent_txtObservacionAnulacion').val()).length < 10) {
                toastr.warning("INGRESAR LA OBSERVACION (MINIMO 10 CARACTERES)");
                return false;
            }
            F_AnularRegistro();
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarLetra').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
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
    if (!F_SesionRedireccionar(AppSession)) return false;
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

    $('#MainContent_txtEmision').on('change', function (e) {
 
        F_TipoCambio();
    });

    $("#MainContent_txtNumero").ForceNumericOnly();
     
    $('#MainContent_txtNumero').blur(function () {
        if ($('#MainContent_txtNumero').val() == '')
            return false;
        var id = '00000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - 8));
        return false;
    });

        //elIMINADOS
    $('#MainContent_btnBuscarConsultaEliminados').click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_BuscarEliminados();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });


    F_Controles_Inicializar();
    
    $('#MainContent_txtProveedor').css('background', '#FFFFE0');
    $('#MainContent_txtSerie').css('background', '#FFFFE0');
    $('#MainContent_txtNumero').css('background', '#FFFFE0');
    $('#MainContent_txtEmision').css('background', '#FFFFE0');
    $('#MainContent_txtResponsable').css('background', '#FFFFE0');
    $('#MainContent_txtObservacionAnulacion').css('background', '#FFFFE0');
    $('#MainContent_txtTC').css('background', '#FFFFE0');
    $('#MainContent_txtFactura').css('background', '#FFFFE0');
    $('#MainContent_txtTotalFactura').css('background', '#FFFFE0');
    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtDesde').css('background', '#FFFFE0');
    $('#MainContent_txtHasta').css('background', '#FFFFE0');
    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtnroEliminado').css('background', '#FFFFE0');
    $('#MainContent_txtDesdeEliminado').css('background', '#FFFFE0');
    $('#MainContent_txtHastaEliminado').css('background', '#FFFFE0');
    $('#MainContent_txtclienteEliminado').css('background', '#FFFFE0');
              
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

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodTasa: 2
               
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
                        F_Update_Division_HTML('div_tasa', result.split('~')[4]);
                        F_Update_Division_HTML('div_Empresa', result.split('~')[5]);
                        F_Update_Division_HTML('div_EmpresaConsulta', result.split('~')[6]);
                           $('#hfCodEmpresa').val(result.split('~')[7]);
                        $('#MainContent_txtTC').val(result.split('~')[3]);
                        $('#MainContent_ddlMoneda').val('1');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlTasa').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaConsulta').css('background', '#FFFFE0');
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
               {cadena="No ha seleccionado ninguna factura";}
               else
               { 
               cadena="Las sgtes. facturas se encuentran agregadas : ";
                    $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblCodigo');
               
                         if ($(chkSi).is(':checked')) 
                            {
                                 $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                                    chkDel = '#' + this.id;
                                    lblDetalle_grilla = chkDel.replace('chkEliminar', 'lblcodigo');
                                    lblFactura_grilla=chkDel.replace('chkEliminar', 'lblFactura');
                                    if ($(lblcodproducto_grilla).text()==$(lblDetalle_grilla).text())
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
        var chkSi = '';
        var hfCodMoneda = '';
        var hfCodEmpresa = '';
        var hfCodTipoDoc = '';
        var txtMontoObligacion = '';
        var arrDetalle = new Array();
                   
                $('#MainContent_grvConsultaFactura .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodigo_grilla = chkSi.replace('chkOK', 'lblCodigo');
                    lblFactura_grilla = chkSi.replace('chkOK', 'lblFactura');
                    lblEmision_grilla = chkSi.replace('chkOK', 'lblEmision');
                    lblTotal_grilla = chkSi.replace('chkOK', 'lblTotal');
                    lblMoneda_grilla = chkSi.replace('chkOK', 'lblMoneda');
                    hfCodMoneda = chkSi.replace('chkOK', 'hfCodMoneda');
                    hfCodEmpresa = chkSi.replace('chkOK', 'hfCodEmpresa');
                    hfCodTipoDoc = chkSi.replace('chkOK', 'hfCodTipoDoc'); 
                    txtMontoObligacion = chkSi.replace('chkOK', 'txtMontoObligacion'); 

                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodigoFactura: $(lblCodigo_grilla).text(),
                        CodMoneda: $(hfCodMoneda).val(),
                        CodEmpresa: $(hfCodEmpresa).val(),
                        Factura: $(lblFactura_grilla).text(),
                        Emision: $(lblEmision_grilla).text() ,
                        Soles: $(lblTotal_grilla).text(),
                        Dolares: $(lblTotal_grilla).text(),
                        xSoles: $(txtMontoObligacion).val(),
                        xDolares: 0,
                        CodTipoDoc: $(hfCodTipoDoc).val(),
                        TC: $('#MainContent_txtTC').val(),
                        CodCtaCte: $('#hfCodCtaCte').val()
                        };
                        $('#hfMoneda').val($(lblMoneda_grilla).text());
                        arrDetalle.push(objDetalle);
                    }
                });

                var objParams = {
                                Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                Filtro_CodigoTemporal:$('#hfCodigoTemporal').val()
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
                var Total=0;
                Total=result.split('~')[5]*$("#MainContent_ddlTasa option:selected").text();
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotalFactura').val(Total.toFixed(2));
                    $('#MainContent_txtFactura').val(result.split('~')[5]);
                    $('#MainContent_txtTotalFactura').val(result.split('~')[6]);

                   F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
                   numerar3();    
                    if (result.split('~')[2]=='La(s) factura(s) se han agregado con exito')
                    alertify.log('La(s) factura(s) se han agregado con exito');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                $('.ccsestilo').css('background', '#FFFFE0');
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
    Total= Total.toFixed(2)*$("#MainContent_ddlTasa option:selected").text();
     var Cuerpo='#MainContent_';
    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
}

function F_ActualizarMonto(Fila) {
    try {
            var txtLetra = '';
            var lblID = '';
            var txtMontoOperacion = '';

            var hfSoles = '';
            var hfDolares = '';
            var hfxSoles = '';
            var hfxDolares = '';
            var hfTC = '';
            var hfCodTipoDoc = '';
            var hfCodMoneda = '';

            txtMontoOperacion = '#' + Fila;
            lblID = txtMontoOperacion.replace('txtMontoObligacion', 'lblID');
            hfSoles = txtMontoOperacion.replace('txtMontoObligacion', 'hfSoles');
            hfDolares = txtMontoOperacion.replace('txtMontoObligacion', 'hfDolares');
            hfxSoles = txtMontoOperacion.replace('txtMontoObligacion', 'hfxSoles');
            hfxDolares = txtMontoOperacion.replace('txtMontoObligacion', 'hfxDolares');
            hfTC = txtMontoOperacion.replace('txtMontoObligacion', 'hfTC');
            hfCodTipoDoc = txtMontoOperacion.replace('txtMontoObligacion', 'hfCodTipoDoc');
            hfCodMoneda = txtMontoOperacion.replace('txtMontoObligacion', 'hfCodMoneda');

            if ($.trim($(txtMontoOperacion).val()) == $.trim($(hfxSoles).val()))
                return false;

            if ($.trim($(txtMontoOperacion).val()) == '') {
                $(txtMontoOperacion).val($(hfxSoles).val());
                return false;
                }
                if ($(lblID).text() === '')
                    return false;
          
                var objParams = {
                        Filtro_Codigo:              $('#hfCodigoTemporal').val(),
                        Filtro_ID:                  $(lblID).text(),
                        Filtro_TC:                  $(hfTC).val(),
                        Filtro_Soles:               $(hfSoles).val(),
                        Filtro_Dolares:             $(hfDolares).val(),
                        Filtro_CodTipoDoc:          $(hfCodTipoDoc).val(),
                        Filtro_CodMoneda:           $(hfCodMoneda).val(),
                        Filtro_Monto:            $(txtMontoOperacion).val()
                };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
     
            F_ActualizarObligaciones_NET(arg, function (result) {
                        var str_resultado_operacion = "";
                        var str_mensaje_operacion = "";

                        str_resultado_operacion = result.split('~')[0];
                        str_mensaje_operacion = result.split('~')[1];
                        MostrarEspera(false);
                        if (str_mensaje_operacion == "") {
                            F_Update_Division_HTML('div_grvFactura', result.split('~')[2]);
                            //$('#MainContent_txtTotalLetra').val(result.split('~')[3]);
                            $('#MainContent_txtFactura').val(result.split('~')[3]);
                            $('#MainContent_txtTotalFactura').val(result.split('~')[4]);
                            $('.ccsestilo').css('background', '#FFFFE0');
                            alertify.log('ACTUALIZADO CORRECTAMENTE');
                        }
                        else
                            alertify.log(result.split('~')[1]);
                        return false;
            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    }

function F_EliminarTemporal_Factura(){

  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvFactura .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblID');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                       
                        CodDetalle: $(lblcoddetalle_grilla).text()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var objParams = {
                                  Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                  Filtro_CodigoTemporal:$('#hfCodigoTemporal').val()
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
                    {
                    $('#MainContent_txtTotalFactura').val('0.00');
                    $('#MainContent_txtFactura').val('0.00');
                    }
                    
                    else
                    {
                        var Total=0;
                        Total=result.split('~')[5]*$("#MainContent_ddlTasa option:selected").text();
                        $('#MainContent_txtTotalFactura').val(Total.toFixed(2));
                        $('#MainContent_txtFactura').val(result.split('~')[5]);
                        $('#MainContent_txtTotalFactura').val(result.split('~')[6]);
                    }
                    
                    F_Update_Division_HTML('div_grvFactura', result.split('~')[4]);
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
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>'; 

        if ($(Cuerpo + 'txtTC').val()=='')
                Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtSerie').val()=='')
                Cadena=Cadena + '<p></p>' + 'Serie';
        
        if ($(Cuerpo + 'txtNumero').val()=='')
                Cadena=Cadena + '<p></p>' + 'Numero';

        if ($(Cuerpo + 'txtProveedor').val()=='' || $('#hfCodCtaCte').val()==0)
                Cadena=Cadena + '<p></p>' + 'Razon Social';
        
        if ($(Cuerpo + 'txtTC').val()=='0')
                Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtTC').val()=='')
                Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtEmision').val()=='')
                Cadena=Cadena + '<p></p>' + 'Emision';

        if ($(Cuerpo + 'txtTotalFactura').val()=='0.00')
                Cadena=Cadena + '<p></p>' + 'Ingrese Factura(s)';

//        if ($(Cuerpo + 'txtResponsable').val()=='')
//                Cadena=Cadena + '<p></p>' + 'Responsable';
        
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
                  var Contenedor='#MainContent_';
                    var objParams = {                                        
                                        Filtro_CodTipoDoc: 18,
                                        Filtro_SerieDoc: $(Contenedor + 'txtSerie').val(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_CodCliente: $('#hfCodCtaCte').val(),
                                        Filtro_CodEstado: '6',
                                        Filtro_CodFormaPago: '1',
                                        Filtro_FechaVencimiento: $(Contenedor + 'txtEmision').val(),
                                        Filtro_FechaCancelacion: $(Contenedor + 'txtEmision').val(),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'txtTC').val(),
                                        Filtro_SubTotal: '0',
                                        Filtro_Igv: '0',
                                        Filtro_Total: $(Contenedor + 'txtTotalFactura').val(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlTasa').val(),
                                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                        Filtro_CodTipoOperacion: '1',
                                        Filtro_Responsable: $(Contenedor + 'txtResponsable').val(),
                                        Filtro_Tasa: $("#MainContent_ddlTasa option:selected").text(),
                                        Filtro_CodEmpresa: $(Contenedor + 'ddlEmpresa').val()
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
                    { 
                        F_Update_Division_HTML('div_grvFactura', result.split('~')[2]);
                          $('.ccsestilo').css('background', '#FFFFE0');    
                        $(Contenedor + 'txtResponsable').val('');
                        $(Contenedor + 'txtSerie').val('');
                        $(Contenedor + 'txtNumero').val('');
                        $(Contenedor + 'ddlMoneda').val('1'),
                        $(Contenedor + 'txtProveedor').val('');
                        $('#hfCodigoTemporal').val('0');
                        $('#hfMoneda').val('0');
                        $('#MainContent_txtTotalFactura').val('0.00');
                        $('#MainContent_txtFactura').val('0.00');
                        $('#hfCodCtaCte').val('0');
                        $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
                        $('.Jq-ui-dtp').datepicker('setDate', new Date());
                        alertify.log('Se grabo correctamente');
                        $(Contenedor + 'txtProveedor').focus();
                    }
                    else
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

function F_Nuevo(){
                        $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
                        $('.Jq-ui-dtp').datepicker('setDate', new Date());
                        $('#hfCodCtaCte').val('0');
                        $('#hfCodigoTemporal').val('0');
                        $('#hfMoneda').val('0');  
                        $('#MainContent_txtTotalFactura').val('0.00');
                        $('#MainContent_txtFactura').val('0.00');
                        $(Contenedor + 'txtResponsable').val('');
                        $(Contenedor + 'txtPagador').val('');
                        $(Contenedor + 'txtTotalLetra').val('0.00') ;
                        $(Contenedor + 'txtNroOperacion').val('');
                        $(Contenedor + 'ddlMoneda').val('1');                   
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
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

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
                                 Filtro_ChkSerie: chkSerie,
                                 Filtro_CodTipoDoc: 18,
                                 Filtro_CodEmpresa: $('#MainContent_ddlEmpresaConsulta').val()       
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
                    $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblnumero'));   
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
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
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
                                      Filtro_CodTipoOperacion: 1,
                                      Filtro_CodDocumentoVenta: $(lblCodigo_Factura).val(),
                                      Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                      Filtro_Desde: $('#MainContent_txtDesde').val(),
                                      Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                      Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                      Filtro_ChkNumero: chkNumero,
                                      Filtro_ChkFecha: chkFecha,
                                      Filtro_ChkCliente: chkCliente,
                                      Filtro_ChkSerie: chkSerie,
                                      Filtro_Observacion: 'ELIMINADO DESDE EL FORMULARIO REGISTRO DE RETENCIONES',
                                      Filtro_CodEmpresa: $('#MainContent_ddlEmpresaConsulta').val(),
                                      Filtro_ObservacionAnulacion: $('#MainContent_txtObservacionAnulacion').val()              
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

    var date = new Date();
    date.setMonth(date.getMonth(), 1);
    $('#MainContent_ddlEmpresaConsulta').val($('#hfCodEmpresa').val());
    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));
    $('#MainContent_chkRango').prop('checked',true);
    F_Buscar();
    return false;

}

function F_ValidarAgregarLetra(){

    try 
        {

        var Cuerpo='#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>'; 
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

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>')
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

function F_AnularRegistro(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
   

 

    if(!confirm("ESTA SEGURO DE ANULAR LA RETENCION : " + $('#lblcliente_grilla').val() + "\n" + "DEL CLIENTE : " +  $('#lblnumero_grilla').val()))
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
                          Filtro_CodDocumentoVenta: $('#hfCodDocumentoVentaAnulacion').val(),
                          Filtro_Serie: $("#MainContent_ddlSerie option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: '18',
                          Filtro_CodTipoOperacion: '1',
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_Observacion: 'ELIMINADO DESDE EL FORMULARIO REGISTRO DE RETENCIONES',
                                      Filtro_ObservacionAnulacion: $('#MainContent_txtObservacionAnulacion').val() 
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
                $('#div_Anulacion').dialog('close');
                F_Buscar();
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

function F_Imprimir(Fila) {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgImprimir', 'hfCodigo');

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '211';

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function numerar3() {
    var c = 0;
    $('.detallesartd').each(function () {
        c++;
        $(this).text(c.toString());
    });
    $("#MainContent_Lbldetalle").text(c);
}

var CargaInicial2 = 0;
function getContentTab2() {
    if (CargaInicial2 === 1)
        return true;
    CargaInicial2 = 1;
    var date = new Date();
    date.setMonth(date.getMonth(), 1);
    $('#MainContent_ddlEmpresaConsulta').val($('#hfCodEmpresa').val());
    $('#MainContent_txtDesdeEliminado').val(date.format("dd/MM/yyyy"));
    $('#MainContent_chkRangoEliminado').prop('checked', true);
    F_BuscarEliminados();
    return false;
}

function F_BuscarEliminados() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';
        var chkSerie = '0';

        if ($('#MainContent_ChknroEliminado').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRangoEliminado').is(':checked'))
            chkFecha = '1';

        if ($('#chkClienteEliminado').is(':checked'))
            chkCliente = '1';

        if ($('#MainContent_chkSerie').is(':checked'))
            chkSerie = '1';

        var objParams = {

            Filtro_Numero: $('#MainContent_txtnroEliminado').val(),
            Filtro_Desde: $('#MainContent_txtDesdeEliminado').val(),
            Filtro_Hasta: $('#MainContent_txtHastaEliminado').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
             Filtro_CodTipoDoc: 18,
            Filtro_Cliente: $("#MainContent_txtclienteEliminado").val()
           
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);

        F_Buscar_Eliminados_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_Eliminados', result.split('~')[2]);
                $('#lblNumeroConsulta2').text(F_Numerar_Grilla("grvEliminado", 'lblcliente'));
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
        MostrarEspera(false);
       alertify.log("Error Detectado: " + e);
        return false;
    }

}

// INICIO DETALLES DE LA GRILLA CONSULTA ELIMINADOS

var CtlgvEliminados;
var HfgvEliminados;

function imgMas_ClickEliminar(Control) {
    CtlgvEliminados = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_LlenarGridEliminar(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridEliminar(Fila) {
    try {
        var nmrow = 'MainContent_grvEliminado_pnlOrdersE_0';
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersE', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvEliminado_grvDetalleEliminado_' + Col;
        HfgvEliminados = '#' + Fila.replace('pnlOrdersE', 'hfDetalleCargado2');

        if ($(HfgvEliminados).val() === "1") {
            $(CtlgvEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvEliminados).next().html() + '</td></tr>');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: 0,
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_LlenarGridEliminar_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvEliminados).next().html() + '</td></tr>');
                        $(HfgvEliminados).val('1');
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

var CtlgvObservacionEliminados;
var HfgvObservacionEliminados;

function imgMasObservacionEliminados_Click(Control) {
    CtlgvObservacionEliminados = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_ObservacionEliminadas(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_ObservacionEliminadas(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersObservacionEliminadas', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvEliminado_grvDetalleObservacionE_' + Col;
        HfgvObservacionEliminados = '#' + Fila.replace('pnlOrdersObservacionEliminadas', 'hfDetalleCargadoObservacion');

        if ($(HfgvObservacionEliminados).val() === "1") {
            $(CtlgvObservacionEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacionEliminados).next().html() + '</td></tr>');
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
                F_Observacion_Eliminados_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvObservacionEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacionEliminados).next().html() + '</td></tr>');
                        $(HfgvObservacionEliminados).val('1');
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

var CtlgvAuditoriaEliminados;
var HfgvAuditoriaEliminados;
function imgMasAuditoriaEliminados_Click(Control) {
    CtlgvAuditoriaEliminados = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_AuditoriaEliminados(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_AuditoriaEliminados(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoriaEliminados', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvEliminado_grvDetalleAuditoria_' + Col;
        HfgvAuditoriaEliminados = '#' + Fila.replace('pnlOrdersAuditoriaEliminados', 'hfDetalleCargadoAuditoria');

        if ($(HfgvAuditoriaEliminados).val() === "1") {
            $(CtlgvAuditoriaEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoriaEliminados).next().html() + '</td></tr>');
            //                    $(CtlgvAuditoriaEliminados).attr('src', '../Asset/images/minus.gif');
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

                //MostrarEspera(true);
                //$(CtlgvAuditoriaEliminados).attr('src', '../Asset/images/loading.gif');
                F_Auditoria_Eliminados_NET(arg, function (result) {
                    //$(CtlgvAuditoriaEliminados).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvAuditoriaEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoriaEliminados).next().html() + '</td></tr>');
                        $(HfgvAuditoriaEliminados).val('1');
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

var CtlgvObservacionesEliminados;
var HfgvObservacionesEliminados;
function imgMasObservacionesEliminados_Click(Control) {
    CtlgvObservacionesEliminados = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_ObservacionesEliminados(grid.attr('id'));
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_ObservacionesEliminados(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlObservacionesEliminados', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvEliminado_grvObservacionesEliminados_' + Col;
        HfgvObservacionesEliminados = '#' + Fila.replace('pnlObservacionesEliminados', 'hfDetalleObservacionesEliminados');

        if ($(HfgvObservacionesEliminados).val() === "1") {
            $(CtlgvObservacionesEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacionesEliminados).next().html() + '</td></tr>');
            //                    $(CtlgvObservacionesEliminados).attr('src', '../Asset/images/minus.gif');
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

                //MostrarEspera(true);
                $(CtlgvObservacionesEliminados).attr('src', '../Asset/images/loading.gif');
                F_ObservacionesEliminados_NET(arg, function (result) {
                    $(CtlgvObservacionesEliminados).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvObservacionesEliminados).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacionesEliminados).next().html() + '</td></tr>');
                        $(HfgvObservacionesEliminados).val('1');
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

// INICIO DETALLES DE LA GRILLA CONSULTA ELIMINADOS

function F_AnularPopUP(Fila) {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
     var imgID = Fila.id;
    var hfCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
    var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');

    $('#hfCodDocumentoVentaAnulacion').val($(hfCodigo).val());
    $('#lblcliente_grilla').val($(lblcliente_grilla).text());
     $('#lblnumero_grilla').val($(lblnumero_grilla).text());
    $('#MainContent_txtObservacionAnulacion').val('');
    var lblCodigo = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblNumero = '#' + imgID.replace('imgEliminarDocumento', 'lblNumero');



//    if (!confirm("ESTA SEGURO DE ELIMINAR LA COBRANZA DEL CLIENTE \n" + $('#hfClienteAnulacion').val() + "\nSE VA ELIMINAR LAS LETRAS ASOCIADAS A LAS FACTURAS DEL DETALLE"))
//        return false;

    $('#div_Anulacion').dialog({
        resizable: false,
        modal: true,
        title: "Eliminacion de Retencion",
        title_html: true,
        height: 190,
        width: 470,
        autoOpen: false
    });
    $('#div_Anulacion').dialog('open');
}