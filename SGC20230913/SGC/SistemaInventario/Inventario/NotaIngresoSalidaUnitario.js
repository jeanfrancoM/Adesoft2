var AppSession = "../Inventario/NotaIngresoSalidaUnitario.aspx";
var GridArticulosInicializado = '';

var CodigoMenu = 2000;
var CodigoInterno = 7;

var P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES;
var P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtDestino').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDireccion_Listar',
                data: "{'Descripcion':'" + request.term + "','Codigo':'" + $('#hfCodCtaCte').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodDepartamento').val(i.item.val);
            
        },
        minLength: 3
    });

    $('#MainContent_txtProveedor').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete2',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            DireccionEnvio: item.split(',')[3],
                            Distrito: item.split(',')[4],
                            CodDepartamento: item.split(',')[5],
                            CodProvincia: item.split(',')[6],
                            CodDistrito: item.split(',')[7],
                            NroRuc: item.split(',')[8],
                            FormaPago: item.split(',')[12],
                            Telefono: item.split(',')[13],
                            CodTransportista: item.split(',')[14],
                            Transportista: item.split(',')[15],
                            CodVendedor: item.split(',')[17]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfProveedor').val(i.item.label);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);

            F_BuscarDireccionesCliente();
            //F_DireccionProveedor(i.item.val, 'div_Destino', '#MainContent_ddlDestino', 'div_Direccion', '#MainContent_ddlDireccion');
        },
        minLength: 3
    });


    $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 2 + "'}",
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
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
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
    $('#MainContent_btnAnular').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
            try {
                if ($.trim($('#MainContent_txtObservacionAnulacion').val()).length<10)
                {
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
    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

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

    $('#MainContent_txtNumero').blur(function () {
    if ($.trim($('#MainContent_txtNumero').val()) =='')
    return false;
        var id = '00000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - 8));
        return false;
    });

    $('#MainContent_txtSerie').blur(function () {
    if ($.trim($('#MainContent_txtSerie').val()) =='')
    return false;
        var id = '0000' + $('#MainContent_txtSerie').val();
        $('#MainContent_txtSerie').val(id.substr(id.length - 4));
        return false;
    });

    $("#MainContent_txtProveedor").bind("propertychange change keyup paste input", function () {
        if ($("#MainContent_txtProveedor").val() != $("#hfProveedor").val() & $("#hfCodCtaCte").val() != '0' & $("#hfProveedor").val() != "") {
            $("#MainContent_txtProveedor").val("");
            $("#hfProveedor").val("");
            $("#hfCodCtaCte").val("0");
            $("#MainContent_ddlDireccion").empty();
            return true;
        }
    });

    F_Controles_Inicializar();

    $('#MainContent_btnBuscarArticulo').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try 
        {
        MostrarEspera(true);
        var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val=="")
            cadena=cadena + "\n" + "Articulo"

              if ($('#MainContent_ddlMoneda option').size() == 0)
              { cadena = cadena + "\n" + "Moneda"; }
              else 
              {
              if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
              }

              if ( cadena != "Ingresar los sgtes. campos :")
              {
                  MostrarEspera(false);
                  toastr.warning(cadena);
                  return false;
              }

              F_Buscar_Productos();
        }
        catch (e) {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarProducto').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 2000702, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
      //  if (F_PermisoOpcion(CodigoMenu, '777001', '') == "0") return false;
        try 
        {
               
                $('#MainContent_txtArticulo').val('');

                 $('#MainContent_txtCodigoProductoAgregar').val('');
                 $('#MainContent_txtStockAgregar').val('');
                 $('#MainContent_txtUMAgregar').val('');
                 $('#MainContent_txtArticuloAgregar').val('');
                 $('#MainContent_txtCantidad').val('');

                
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
                    $('.ccsestilo').css('background', '#FFFFE0');          
                  
                }
                else 
                {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

                });


        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
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
        return false;
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnEliminar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 2000705, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
     try 
        {
            if(!F_ValidarEliminar())
              return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LOS PRODUCTOS SELECCIONADOS"))
            F_EliminarTemporal();

            return false;
        }        
        catch (e) 
        {
            toastr.warning("Error Detectado: " + e);
        }     
   });

    $('#MainContent_btnGrabar').click(function () {
     if (!F_SesionRedireccionar(AppSession)) return false;
     if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
     try 
        {
            if(!F_ValidarGrabarDocumento())
              return false;

            if (confirm("ESTA SEGURO DE GRABAR LA NOTA DE INGRESO"))
            F_GrabarDocumento();

            return false;
        }        
        catch (e) 
        {
            toastr.warning("Error Detectado: " + e);
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

            toastr.warning("Error Detectado: " + e);
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

            toastr.warning("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnOC').click(function () {
              if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturacionOC();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnVentas').click(function () {
       if (!F_SesionRedireccionar(AppSession)) return false;
       if (F_PermisoOpcion(CodigoMenu, 2000701, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
       $('#divFacturarVentas').dialog({
     resizable: false,
     modal: true,
     title: "VENTAS",
     title_html: true,
     height: 500,
     width: 890,
     autoOpen: false
 });
              
       $('#divFacturarVentas').dialog('open');

       return false;        
    });

    $('#MainContent_btnBuscarVentas').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
            try {

            F_FacturacionVentas();
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnAgregarVentas').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarAgregarVentas())
                return false;

            F_AgregarTemporalVentas();
            F_LimpiarGrillaConsultaVentas();

            return false;
        }
        catch (e) {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnBuscarGuiaAlmacenExterno').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Obtener_Guia_AlmacenExterno();
            return false;
        }
        catch (e) {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });

    $('#MainContent_txtNumero').blur(function () {
        var id='00000000' + $('#MainContent_txtNumero').val();
            $('#MainContent_txtNumero').val(id.substr(id.length - 8));   
       return false;
    });
    
    $('#MainContent_txtArticulo').blur(function () {

        return false;

          try 
        {
        if ($('#MainContent_txtArticulo').val()=='')
        return false

        var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val=="" | $('#MainContent_txtArticulo').val().length<3)
            cadena=cadena + "\n" + "Articulo (Minimo 2 Caracteres)"

              if ($('#MainContent_ddlMoneda option').size() == 0)
              { cadena = cadena + "\n" + "Moneda"; }
              else 
              {
              if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
              }

              if ( cadena != "Ingresar los sgtes. campos :")
              {
                  toastr.warning(cadena);
                  return false;
              }

              F_Buscar_Productos(); 
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;
    });

    $('#MainContent_txtPeriodo').css('background', '#FFFFE0');

    $('#MainContent_txtObservacionAnulacion').css('background', '#FFFFE0');

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtFechaIngreso').css('background', '#FFFFE0');

     $('#MainContent_txtserieconsulta').css('background', '#FFFFE0');

    $('#MainContent_txtMonto').css('background', '#FFFFE0');

    $('#MainContent_txtDsctoTotal').css('background', '#FFFFE0');

    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtSerie').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuia').css('background', '#FFFFE0');

    $('#MainContent_txtPartida').css('background', '#FFFFE0');

    $('#MainContent_txtDestino').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_ddlDireccion').css('background', '#FFFFE0');

    $('#MainContent_txtSerie').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

   //ventana busqueda de producto
    //--
    $('#MainContent_txtArticuloAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');
    
    $('#MainContent_txtPrecioDisplay').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProductoAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtUMAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProductoAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtUMAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtStockAgregar').css('background', '#FFFFE0');
    
    $('#MainContent_txtStockAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtClienteDropTop').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtFacturaCDR').css('background', '#FFFFE0');

    $('#MainContent_txtArchivoCDR').css('background', '#FFFFE0');

    $("#MainContent_txtUsuarioPrecio").css('background', '#FFFFE0');

    $("#MainContent_txtContraseñaPrecio").css('background', '#FFFFE0');

    $("#MainContent_txtKMEdicion").css('background', '#FFFFE0');

    $("#MainContent_txtNroOperacionEdicion").css('background', '#FFFFE0');

    $('#MainContent_ddlDropTop').css('background', '#FFFFE0');

    $('#MainContent_ddlAlmacen').css('background', '#FFFFE0');

    $('#MainContent_txtSerieExterno').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroExterno').css('background', '#FFFFE0');
    $('#MainContent_txtObservacionAnulacion').css('background', '#FFFFE0');
    
    $('.ccsestilo').css('background', '#FFFFE0');
    $('#MainContent_ddlFormatoImpresion').css('background', '#FFFFE0');
    $('#MainContent_ddlFormatoImpresion2').css('background', '#FFFFE0');
    F_FuncionesBotones();

    $( "#accordion" ).accordion({
        collapsible: true,
        active: false
    });

 });
 
 //ENZO
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
    k.down("f3", function () {
        $("#MainContent_btnVentas").click();
        return false;
    });
    k.down("f4", function () {
        $("#MainContent_btnOC").click();
        return false;
    });
    k.down("f5", function () {
        $("#MainContent_btnEliminar").click();
        return false;
    });
    k.down("f6", function () {
        $("#MainContent_btnGrabar").click();
        return false;
    });
    k.down("f11", function () {
        if ($("#MainContent_chkImpresion").prop('checked') === true)
            $("#MainContent_chkImpresion").prop('checked', false);
        else 
            $("#MainContent_chkImpresion").prop('checked', true);

        return false;
    });
    

    
    //funcionalidades de productos
    //ENZO
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

    //ENZO
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
                } catch (e) { }               

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
//                    case "MainContent_txtCantidad":
//                        $('#MainContent_txtPrecioDisplay').select();
//                    break;
                    case "MainContent_txtCantidad":
                           $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_btnAgregar":
                           $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_ddlIgv":
                        $('#MainContent_txtGuia').focus();
                    break;
                    case "MainContent_txtTotal":
                        $('#MainContent_txtCorreo').focus();
                    break;
                    case "MainContent_txtCorreo":
                        $('#MainContent_txtNroOC').focus();
                    break;
                    case "MainContent_txtKM":
                        $('#MainContent_txtNroOperacion').focus();
                    break;
                    case "MainContent_txtCodCotizacion":
                        if ($("#MainContent_txtCodCotizacion").val().trim() != "")
                            {
                                if (isNaN($("#MainContent_txtCodCotizacion").val().trim()))
                                    $("#MainContent_txtCodCotizacion").val('');
                                else
                                    $('#MainContent_btnFacturarCotizacion').click();
                            }
                        
                        $('#MainContent_chkImpresion').focus();
                    break;
                    case "MainContent_txtVencimiento":
                        $("#MainContent_ddlCajaFisica").focus();
//                        if ($("#MainContent_chkConIgvMaestro").prop('disabled') === true | $("#MainContent_chkSinIgvMaestro").prop('disabled') === true)
//                            $("#MainContent_txtSubTotal").focus();
//                        else 
//                            $("#MainContent_chkConIgvMaestro").focus();
                    break;

                    
                    default:
                    //otros casos

                        //Agregar Con Enter desde la Grilla
                        if (Campos.indexOf("MainContent_grvConsultaArticulo_imgAgregar") >= 0)
                        {
                            F_AgregarArticulo(Campos, 0);
                            $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblProducto"));
                            return true;
                        }
                    break;
                }

return true;
}


function F_PrecioDisplayUp() {
  if ($('#MainContent_ddlPrecio option:selected').prev().length > 0) 
    $('#MainContent_ddlPrecio option:selected').prev().attr('selected', 'selected').trigger('change');
  else $('#MainContent_ddlPrecio option').last().attr('selected', 'selected').trigger('change');

  $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").text());   
}

function F_PrecioDisplayDown() {

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

//ENZO
function F_DireccionDisplayUp() {
  var p;

  if ($('#MainContent_ddlDireccion option:selected').prev().length > 0) {
    p = $('#MainContent_ddlDireccion option:selected').prev().val();
    }
  else { 
    p = $('#MainContent_ddlDireccion option:selected').last().val();
  }

  $('#MainContent_ddlDireccion').val(p);
  $("#MainContent_txtDireccion").val($("#MainContent_ddlDireccion option:selected").text());   
  $('#hfCodDireccion').val(p);

}
//ENZO
function F_DireccionDisplayDown() {
  var p;

  if ($('#MainContent_ddlDireccion option:selected').next().length > 0) {
    p = $('#MainContent_ddlDireccion option:selected').next().val();
    }
  else { 
    p = $('#MainContent_ddlDireccion option:selected').first().val();
  }
  $('#MainContent_ddlDireccion').val(p);
  $("#MainContent_txtDireccion").val($("#MainContent_ddlDireccion option:selected").text());  
  $('#hfCodDireccion').val(p);

}

function F_AgregarArticulo(ControlID, DirectoBoton) {
    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var ddlprecio_grilla = '';
    var hfArticulo_grilla = '';
    var hfPrecio1_grilla = '';
    var hfPrecio2_grilla = '';
    var hfPrecio3_grilla = '';
    var lblCodigoProducto_grilla = '';
    var lblStock_grilla = '';
    var lblUM_grilla = '';
    var lblMoneda_grilla = '';
    var lblCodProducto_grilla = '';
    var lblCosto_grilla = '';
    var lblCodUm_grilla = '';
    var boolEstado = false;
    var imgAgregar_grilla = '';
    var cadena = 'Ingrese los sgtes. campos: '

    imgAgregar_grilla = '#' + ControlID;
    ctrlPosActual = imgAgregar_grilla;
    txtprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtPrecioLibre');
    ddlprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlPrecio');
    txtcant_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtCantidad');
    ddlLista_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlLista');
    hfArticulo_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblProducto');
    hfPrecio1_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio1');
    hfPrecio2_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio2');
    hfPrecio3_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio3');
    lblCodigoProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hlkCodNeumaticoGv');
    lblStock_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblstock');
    lblUM_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblUM');
    lblMoneda_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfMoneda');
    lblCosto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcosto');
    lblCodUm_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcodunidadventa');

    lblCodProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblcodproducto');

    $('#hfCodProductoAgregar').val($(lblCodProducto_grilla).val());
    $('#hfCostoAgregar').val($(lblCosto_grilla).val());
    $('#hfCodUmAgregar').val($(lblCodUm_grilla).val());
    $('#MainContent_txtCodigoProductoAgregar').val($(lblCodigoProducto_grilla).text());
    $('#MainContent_txtUMAgregar').val($(lblUM_grilla).text());
    $('#MainContent_txtStockAgregar').val($(lblStock_grilla).text());
    $('#MainContent_lblMonedaAgregar').text($(lblMoneda_grilla).val());
    

    $('#MainContent_txtArticuloAgregar').val($(hfArticulo_grilla).text());
    $('#MainContent_txtCantidad').val();
//    $('#MainContent_txtPrecioDisplay').val($(hfPrecio1_grilla).val());
    $("#hfMenorPrecioAgregar").val(0);

    $("#MainContent_ddlPrecio").empty();

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

    $('#MainContent_chkServicios').prop('checked', false);

    //F_VerUltimoPrecio_Buscar($('#MainContent_txtCodigoProductoAgregar').val(), $('#hfCodProductoAgregar').val());
     $('#MainContent_txtArticuloAgregar').focus();
//    if (P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES == "1")
//        F_Consultar_Almacenes_Stocks(ControlID);
    if (DirectoBoton === 1)
        F_TablaClick(ControlID);
    return false;
}

function F_TablaClick(Control) {
    Control = "#" + Control;
    $(ctrlPosActualBuffer).closest("tr").children('td,th').css("background-color","#FFFFFF")
    $(Control).closest("tr").children('td,th').css("background-color","#ffec85")
    $(Control).focus();
    ctrlPosActualBuffer = Control;
}

//BRUNO
function F_FormatosImpresion2() {
     var CodTipoDoc =7;       
     var SerieDoc = 0;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_FormatoImpresion_Listar_NotaIngreso',
        data: "{'CodTipoDoc':'" + CodTipoDoc+"'}", //agregar parametro ms de FlagUsuariosInactivos
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_ddlFormatoImpresion').empty();
                $.each(dbObject.d, function (index, item) {
                    $('#MainContent_ddlFormatoImpresion').append($("<option></option>").val(item.CodTipoFormato).html(item.Formato +' - '+item.Impresora));
                });
            }
            catch (x) { alertify.log('ERROR AL CARGAR LOS FORMATOS'); }

        },
        complete: function () {

        },
        error: function (response) {
            console.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });
    return true;

}

function F_VerUltimoPrecio_Buscar(CodNeumatico, CodProducto) {
    var Contenedor = '#cphCuerpo_';
    var CodNeumaticoAlm = '';

    $('#MainContent_lbCodProducto').val(CodNeumatico);
    $('#MainContent_lbCodNeumatico').val(CodProducto);

    try {
        var objParams = {
            Filtro_CodProducto: CodProducto,
            Filtro_CodTipoOperacion: '1',
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_Top: 5
        }

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_VerUltimoPrecio_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            $('#MainContent_lbCodProducto').val(CodProducto);
            $('#MainContent_lbCodNeumatico').val(CodNeumatico);
            F_Update_Division_HTML('div_grvConsultaUltimosPrecios', result.split('~')[2]);

            if (str_resultado_operacion == "1") {
            }

//            else
//                toastr.warning('no se encontraron datos');

            $('#MainContent_txtArticuloAgregar').focus();

            return false;

        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
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

$(document).on("change", "select[id $= 'MainContent_ddlTipoDoc']", function () { 
    f_TipoDocCambio();
});

$(document).on("change", "select[id $= 'MainContent_ddlDestino']", function () { 
        if ($('#MainContent_ddlTipoDoc').val()=='7')  
        {
             $('#MainContent_ddlPartida').val($('#MainContent_ddlDestino').val());   
             F_Serie($('#MainContent_ddlTipoDoc').val());        
        }
});

$(document).on("change", "select[id $= 'MainContent_ddlTipoDocConsulta']", function () {    
        F_Buscar();
});

$(document).on("change", "select[id $= 'MainContent_ddlMotivoInterno']",function () { 
    F_MotivoInterno_Cambio();
    });

$(document).on("change", "select[id $= 'MainContent_ddlPartida']",function () { 
        if ($('#MainContent_ddlTipoDoc').val()=='11')  
        {
            if ($('#MainContent_ddlMotivoInterno').val()=='2')  
            {
                 $('#MainContent_ddlDestino').val($('#MainContent_ddlPartida').val());
                 $('#MainContent_ddlDestino').prop('disabled',true);
            }
        }
        else
        {
             $('#MainContent_ddlDestino').prop('disabled',false);
        }
     
        F_Serie($('#MainContent_ddlTipoDoc').val());             
    });

$(document).on("change", "select[id $= 'MainContent_ddlDestino']",function () { 
     if ($('#MainContent_ddlTipoDoc').val()=='7')  
        F_Serie($('#MainContent_ddlTipoDoc').val());             
    });

$(document).on("change", "select[id $= 'MainContent_ddlTipoDocVentas']",function () {
     F_CambioSerie_TipoDoc();
} );

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

function F_Controles_Inicializar() {
    F_Inicializar_Parametros();

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodAlmacenFisico: 3,
                Filtro_CodTipoDoc: 1,
                Filtro_FlagNotaSalida:1,
                Filtro_CodCargo: 6,
                Filtro_CodEstado: 1
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
                        F_Update_Division_HTML('div_MotivoTrabajo', result.split('~')[2]);
                        F_Update_Division_HTML('div_serie', result.split('~')[3]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[4]);
                        F_Update_Division_HTML('div_igv', result.split('~')[5]);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        F_Update_Division_HTML('div_Partida', result.split('~')[10]);
                        F_Update_Division_HTML('div_Destino', result.split('~')[11]);
                        F_Update_Division_HTML('div_MotivoInterno', result.split('~')[12]);
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[13]);
                        F_Update_Division_HTML('div_TipoDoc', result.split('~')[14]);
                        F_Update_Division_HTML('div_TipoDocConsulta', result.split('~')[15]);
                        F_Update_Division_HTML('div_SerieDocVentas', result.split('~')[16]);
                        F_Update_Division_HTML('div_EmpleadoConsulta', result.split('~')[17]);
                        F_Update_Division_HTML('div_TipoDocumento', result.split('~')[18]);
                        GridArticulosInicializado = result.split('~')[19];
                        $('#MainContent_ddlDestino').val(result.split('~')[20]);
                        $('#MainContent_txtNumero').val(result.split('~')[7]);
                        $('#MainContent_txtPartida').val(result.split('~')[8]);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlMotivoTrabajo').val(7);
                        $('#MainContent_lblTC').text(result.split('~')[6]);  
                        $('#MainContent_ddlMotivoInterno').val(1);                  
                        $('#hfCodFacturaAnterior').val('0');            
                        $('#MainContent_ddlSerieDocVentas').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocVentas').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpleadoConsulta').css('background', '#FFFFE0');
                        $('#MainContent_txtHastaVentas').css('background', '#FFFFE0');
                        $('#MainContent_txtDesdeVentas').css('background', '#FFFFE0');
                        $('#MainContent_txtNumeroDocVentas').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlMotivoTrabajo').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlPartida').css('background', '#FFFFE0');
                        $('#MainContent_ddlDestino').css('background', '#FFFFE0');
                        $('#MainContent_ddlMotivoInterno').css('background', '#FFFFE0');
                        $('#MainContent_txtObservacion').val('');
                        $('#MainContent_txtResponsable').val('');
                        $('#MainContent_txtObservacion').css('background', '#FFFFE0');
                        $('#MainContent_txtResponsable').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDocumento').css('background', '#FFFFE0');
                        $('#MainContent_ddlDestino').prop('disabled', true);
                        $('#MainContent_chkImportacion').prop('checked', true);
                        $('#lblCantidadRegistro').text('0');
                        //F_LimpiarCampos();
                        F_Inicializar_Combo_AlmacenesExternos();
                        F_FormatosImpresion2();
                        if (P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES == "1" | P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA == "1") {
                            F_Inicializar_Tabla_Almacenes_Stocks();
                        }
                        $('.ccsestilo').css('background', '#FFFFE0');     
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                  }
            );

    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }
    
}

function F_Inicializar_Parametros() {

    P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES = "1";
    P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA = "1";

    var Parametros = F_ParametrosPagina('', CodigoMenu, CodigoInterno);
    $.each(Parametros, function (index, item) {

        switch (item.Parametro) {
            case "P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES":
                P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES = item.Valor;
                break;
            case "P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA":
                P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA = item.Valor;
                break;
        };

    });


    return true;
}

function F_Inicializar_Combo_AlmacenesExternos() {

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'NotaIngresoSalida.aspx/F_Inicializar_Combo_Almacenes_Stocks_NET',
        dataType: "json",
        //data: JSON.stringify({ 'CodAlterno': objParams }),
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {
                $.each(data.rows, function (index, item) {
                    $("#MainContent_ddlAlmacen").append(new Option(item.Empresa + " - " + item.DscAlmacen , item.CodAlmacenRemoto + '~' + item.ConexionNombre));
                });
            }
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });


    return true;
}

function f_TipoDocCambio() {
        if ($('#MainContent_ddlTipoDoc').val()=='7')  
        {
             $('#MainContent_ddlDestino').val($('#MainContent_ddlPartida').val());             
             $('#MainContent_ddlMotivoInterno').val(3);
             $('#MainContent_ddlPartida').prop('disabled',true);
             $('#MainContent_ddlMotivoInterno').prop('disabled',true);
             $('#MainContent_ddlDestino').prop('disabled',false);
        }
        else
        {
             $('#MainContent_ddlPartida').val(3);
             $('#MainContent_ddlDestino').val(1);
             $('#MainContent_ddlMotivoInterno').val(1);
             $('#MainContent_ddlPartida').prop('disabled',false);
             $('#MainContent_ddlDestino').prop('disabled',false);
             $('#MainContent_ddlMotivoInterno').prop('disabled',false);
        }             

        F_Serie($('#MainContent_ddlTipoDoc').val());
return true;
}

function F_MotivoInterno_Cambio() {
         if ($('#MainContent_ddlMotivoInterno').val()=='2')  
        {
             $('#MainContent_ddlDestino').val($('#MainContent_ddlPartida').val());
             $('#MainContent_ddlDestino').prop('disabled',true);
        }
        else
        {
             $('#MainContent_ddlPartida').val(3);
             $('#MainContent_ddlDestino').val(1);
             $('#MainContent_ddlDestino').prop('disabled',false);
        }              
return true;
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
                Filtro_FlagProductosConStock: ($('#MainContent_chkProductosConStock').is(':checked'))? 1 : 0,
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
                         $('.ccsestilo').css('background', '#FFFFE0');

                        ctrlPosActual = '#MainContent_grvConsultaArticulo_imgAgregar_0';
                        ctrlPosActualBuffer = ctrlPosActual;
                        $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
                        $(ctrlPosActual).focus();

                        if (str_mensaje_operacion=='No se encontraron registros')
                        toastr.warning(str_mensaje_operacion);
                        
                    }
                    else {

                        toastr.warning(str_mensaje_operacion);

                    }
              }
            );

    } catch (mierror) {
          MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

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

               case "13":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),75));
                
                       break;

            case "14":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),90));
   
                       break;
     }

     
    }
     catch (mierror) 
     {
        toastr.warning("Error detectado: " + mierror);
     }

}

function F_Obtener_Guia_AlmacenExterno() {



    if (AgregandoProducto === true)
        return true;

    try {    
                

    var CodAlmacenRemoto    = $("#MainContent_ddlAlmacen").val().split('~')[0];
    var ConexionNombre      = $("#MainContent_ddlAlmacen").val().split('~')[1];




            var objParams = {
                Filtro_CodAlmacenRemoto: CodAlmacenRemoto,
                Filtro_ConexionNombre: ConexionNombre, 
                Filtro_CodTipoDoc: $('#MainContent_ddlTipoDocumento').val(),
                Filtro_SerieDoc: $('#MainContent_txtSerie').val(),
                Filtro_NumeroDoc: $('#MainContent_txtNumero').val(),
                Filtro_FechaEmision: $('#MainContent_txtEmision').val(),
                Filtro_Vencimiento: $('#MainContent_txtEmision').val(),
                Filtro_CodCliente: 119,
                Filtro_CodFormaPago: 1,
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_TipoCambio: $('#MainContent_lblTC').text(),
                Filtro_SubTotal: 0,
                Filtro_CodProforma: 0,
                Filtro_Igv: 0,
                Filtro_Total: 0,
                Filtro_CodTraslado: 0,
                Filtro_Descuento: 0,
                Filtro_TasaIgv: 1.18,
                Filtro_TasaIgvDscto: 0,
                Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                Filtro_CodAlmacenFisicoDesde: $('#MainContent_ddlPartida').val(),
                Filtro_CodAlmacenFisicoHasta: $('#MainContent_ddlDestino').val(),
                Filtro_FlagFormulario: 1
            };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_AgregarTemporal_GuiaExterna_NET(arg, function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2]=='Los Producto(s) se han agregado con exito')
                        toastr.warning('Los Producto(s) se han agregado con exito');
                      $('#hfCodProductoAgregar').val('0');
                    $('#hfCostoAgregar').val('0');
                    $('#hfCodUmAgregar').val('0');
                    $('#MainContent_txtCodigoProductoAgregar').val('');
                    $('#MainContent_txtStockAgregar').val('');
                    $('#MainContent_txtUMAgregar').val('');
                    $('#MainContent_txtPrecioDisplay').val('0.00');
                    $('#MainContent_ddlPrecio').empty();
                    $('#MainContent_txtArticuloAgregar').val('');
                    $('#MainContent_txtCantidad').val('');
                    $("#hfMenorPrecioAgregar").val(0);


                    if (result.split('~')[11] === "0") {
                        toastr.warning("EL PROVEEDOR NO FUE ENCONTRADO EN ESTA BASE DE DATOS, AGREGUELO MANUALMENTE");

                        $('.ccsestilo').css('background', '#FFFFE0');     
                        //F_LimpiarGrillaConsulta();
                        $('#MainContent_txtArticulo').focus();

                    } else {

                        $('#hfCodCtaCte').val(result.split('~')[11]);
                        $('#hfProveedor').val(result.split('~')[12]);
                        $('#MainContent_txtNroRuc').val(result.split('~')[10]);
                        $('#MainContent_txtProveedor').val(result.split('~')[12]);
                        F_BuscarDireccionesCliente();

                        $('.ccsestilo').css('background', '#FFFFE0');     
                        //F_LimpiarGrillaConsulta();
                        $('#MainContent_txtArticulo').focus();                    
                    }


                    $('#hfRemoto').val(1);





                }
                else 
                {
                    MostrarEspera(false);
                    toastr.warning(result.split('~')[2]);
                    return false;
                }

                return true;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            
        }




return true;
};

function F_ValidarAgregar(){
try 
        {
        var chkSi='';
        var chkDel='';
        var txtcantidad_grilla='';
        var txtprecio_grilla='';
        var cadena = "Ingrese los sgtes. campos: ";
        var lblcodproducto_grilla='';
        var hfCodArticulo='';
        var lblProducto='';
        var x=0;

        if ($("#MainContent_txtArticuloAgregar").val() == '')
            cadena = cadena + "CAMPO DESCRIPCION ARTICULO <p></p> ";

        if ($("#MainContent_txtCantidad").val() == '')
            cadena = cadena + "CAMPO CANTIDAD <p></p> ";

        if (isNaN($("#MainContent_txtCantidad").val()))
        {
            $("#MainContent_txtCantidad").val(1);
            $("#MainContent_txtCantidad").focus();
            $("#MainContent_txtCantidad").select();
            cadena = cadena + "CAMPO CANTIDAD <p></p> ";
        }

//        if ($("#MainContent_txtPrecioDisplay").val() == '')
//            cadena = cadena + "CAMPO PRECIO ARTICULO <p></p> ";
        $("#MainContent_txtPrecioDisplay").val('0');

        if (isNaN($("#MainContent_txtPrecioDisplay").val()))
        {
            $("#MainContent_txtPrecioDisplay").val('0.00');
            $("#MainContent_txtPrecioDisplay").focus();
            $("#MainContent_txtPrecioDisplay").select();
            cadena = cadena + "CAMPO PRECIO <p></p> ";
        }

//        if (UsuarioIniciado_PermisoCambioPrecios === '0') {
//            if (Number($("#MainContent_txtPrecioDisplay").val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($("#hfMenorPrecioAgregar").val()) > 0 & PermisoCambio == false)
//            {
//                $("#MainContent_txtUsuarioPrecio").val('');
//                $("#MainContent_txtContraseñaPrecio").val('');
//                $("#MainContent_txtUsuarioPrecio").prop('disabled', false);
//                $("#MainContent_txtContraseñaPrecio").prop('disabled', false);
//                $("#MainContent_btnVerificar").prop('disabled', false);
//                $('#divClavePrecio').dialog('open');
//                return false;
//            }
//        }
        
        //PermisoCambio = false;

                if (cadena != "Ingrese los sgtes. campos: ")
                   {
                      toastr.warning(cadena);
                      return false;
                   } 
                   else
                   {
                    cadena="Los sgtes. productos se encuentran agregados : ";

                                 $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                                   chkDel = '#' + this.id;
                                   hfCodArticulo = chkDel.replace('chkEliminar', 'hfCodArticulo');
                                   lblProducto = chkDel.replace('chkEliminar', 'lblProducto');
                                    
                                    if ($('#hfCodProductoAgregar').val()==$(hfCodArticulo).val())
                                    {
                                        cadena= cadena + "\n"  + $('#MainContent_txtArticuloAgregar').val();
                                        F_TablaDown();
                                    }                         
                                  });
                   }    
                                 
                   if (cadena != "Los sgtes. productos se encuentran agregados : ") 
                   {toastr.warning(cadena);
                   return false;}
                   else
                   {
                   return true;
                   }
        }
        
        catch (e) 
        {
            toastr.warning("Error Detectado: " + e);
        }
}

var AgregandoProducto = false;
function F_AgregarTemporal(){
    if (AgregandoProducto === true)
        return true;

    try {    
        var lblcodproducto_grilla='';
        var lblcodunidadventa_grilla='';
        var lblcosto_grilla='';
        var chkSi='';
        var txtcantidad_grilla='';
        var lblPrecio1='';
        var txtdscto_grilla='';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla='';
        var hfcosto_grilla='';
        var lblProducto = '';
        var hfcodunidadventa = '';
        var Contenedor = '#MainContent_';
        var tasaigv;
        var FlagIgv = 0;


        //agregado agutierrez
        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }    

        var objDetalle = {
        CodArticulo: $('#hfCodProductoAgregar').val(),
        Descripcion: $('#MainContent_txtArticuloAgregar').val().replace("&", "&amp;"),
        Cantidad: $('#MainContent_txtCantidad').val(),

        Precio: 0,
        PrecioDscto: 0,
        Costo: 0,
        CodUm: $('#hfCodUmAgregar').val(),
        CodDetalle: 0,
        Acuenta: 0,
        CodTipoDoc:0

        };                                               
        arrDetalle.push(objDetalle);

                var objParams = {
                                        Filtro_CodTipoDoc: "2",
                                        Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtEmision').val(),
                                        Filtro_CodCliente: 119,
                                        Filtro_CodFormaPago: 1,
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_SubTotal: 0,
                                        Filtro_CodProforma: 0,
                                        Filtro_Igv: 0,
                                        Filtro_Total: 0,
                                        Filtro_CodTraslado: 0,
                                        Filtro_Descuento: 0,
                                        Filtro_TasaIgv: 1.18,
                                        Filtro_TasaIgvDscto: 0,
                                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                        Filtro_CodAlmacenFisicoDesde: $('#MainContent_ddlPartida').val(),
                                        Filtro_CodAlmacenFisicoHasta: $('#MainContent_ddlDestino').val(),
                                        Filtro_FlagFormulario: 1,
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_AgregarTemporal_NET(arg, function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2]=='Los Producto(s) se han agregado con exito')
                        toastr.warning('Los Producto(s) se han agregado con exito');
                      $('#hfCodProductoAgregar').val('0');
                    $('#hfCostoAgregar').val('0');
                    $('#hfCodUmAgregar').val('0');
                    $('#MainContent_txtCodigoProductoAgregar').val('');
                    $('#MainContent_txtStockAgregar').val('');
                    $('#MainContent_txtUMAgregar').val('');
                    $('#MainContent_txtPrecioDisplay').val('0.00');
                    $('#MainContent_ddlPrecio').empty();
                    $('#MainContent_txtArticuloAgregar').val('');
                    $('#MainContent_txtCantidad').val('');
                    $("#hfMenorPrecioAgregar").val(0);
                    $('.ccsestilo').css('background', '#FFFFE0');     
                    //F_LimpiarGrillaConsulta();
                    $('#MainContent_txtArticulo').focus();
                    
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblProducto"));
                }
                else 
                {
                    MostrarEspera(false);
                    toastr.warning(result.split('~')[2]);
                    return false;
                }

                return true;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            
        }
}

function F_LimpiarGrillaConsulta() {
    $('#MainContent_grvConsultaArticulo').empty();
    F_Update_Division_HTML('div_grvConsultaArticulo', GridArticulosInicializado);                            
    $('.ccsestilo').css('background', '#FFFFE0');      
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_txtArticulo').focus();
return true;
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
    $(Cuerpo + 'txtMonto').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgv').val((Total*parseFloat($(Cuerpo + 'ddligv').val())).toFixed(2));
    $(Cuerpo + 'txtSubTotal').val((Total/(1+parseFloat($(Cuerpo + 'ddligv').val()))).toFixed(2));
    
}

function F_EliminarTemporal(){
  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var hfCodDetalle='';        
               
                $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').not("#MainContent_chkAll").each(function () {
                    chkSi = '#' + this.id;
                    hfCodDetalle = chkSi.replace('chkEliminar', 'hfCodDetalle');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {                       
                        CodDetalle: $(hfCodDetalle).val()
                        };                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=1.18;
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

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtMonto').val(result.split('~')[6]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    $('.ccsestilo').css('background', '#FFFFE0');  
                    if (result.split('~')[2]=='Se han eliminado los productos correctamente.')
                    toastr.success('Se han eliminado los productos correctamente.');
                }
                else 
                {
                    toastr.warning(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
        }
}

function F_ValidarEliminar(){

 try 
        {
        var chkSi='';
        var x=0;

                $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                               
                     if ($(chkSi).is(':checked')) 
                        x=1;
                        
               });

               if(x==0)
               {
               toastr.warning("Seleccione un articulo para eliminar");
               return false;
               }
               else
               {return true;}
               
        }
        
        catch (e) 
        {

            toastr.warning("Error Detectado: " + e);
        }
}

function F_ValidarGrabarDocumento(){
    try 
        {

        var Cuerpo='#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:'; 
                
        if ($(Cuerpo + 'lblTC').text()=='0')
            Cadena=Cadena + '<p></p>' + 'Ingrese el Tipo de Cambio del dia';

        if ($(Cuerpo + 'txtEmision').val()=='')
            Cadena=Cadena + '<p></p>' + 'Fecha de Emision';

            if ($(Cuerpo + 'txtSerie').val()=='')
            Cadena=Cadena + '<p></p>' + 'Serie';

            if ($(Cuerpo + 'txtNumero').val()=='' | $(Cuerpo + 'txtNumero').val()=='00000000')
            Cadena=Cadena + '<p></p>' + 'Numero';

        if ($('#hfCodCtaCte').val() == '0')
            Cadena=Cadena + '<p></p>' + 'Proveedor';

        if ($('#MainContent_ddlDestino').val() == null)
            Cadena = Cadena + '<p></p>' + 'Entrada';

        if ($(Cuerpo + 'txtObservacion').val()=='')
            Cadena=Cadena + '<p></p>' + 'Observacion';

            if ($(Cuerpo + 'txtSerie').val()=='0250' | $(Cuerpo + 'txtSerie').val()=='0211' | $(Cuerpo + 'txtSerie').val()=='0173')
            Cadena=Cadena + '<p></p>' + 'SERIE NO VALIDA';

        var CantidadProductos = 0;
        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            var chkDel = '#' + this.id; var hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
            if ($(hfcodarticulodetalle_grilla).val() != "")
             CantidadProductos++;
        });

        if (CantidadProductos === 0)
            Cadena=Cadena + '<p></p>' + 'DEBE AGREGAR PRODUCTOS';

        if (Cadena != 'Ingresar los sgtes. Datos:')
        {toastr.warning(Cadena);
        return false;}
        return true;
        }        
    catch (e) 
        {
            toastr.warning("Error Detectado: " + e);
        }
}

function F_GrabarDocumento(){
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try 
        {
        var Contenedor = '#MainContent_';
        var CodTipoOperacion = 0;

        switch($('#MainContent_ddlMotivoTrabajo').val()) {
                case '1':
                  CodTipoOperacion=11;
                  break;
                case '2':
                  CodTipoOperacion=10;
                  break;
                   case '7':
                  CodTipoOperacion=11;
                  break;
                case '9':
                  CodTipoOperacion=3;
                  break;
                default:
                  CodTipoOperacion=19;
        }

        var CodAlmacenRemoto    = $("#MainContent_ddlAlmacen").val().split('~')[0];
        var ConexionNombre      = $("#MainContent_ddlAlmacen").val().split('~')[1];
        if ($('#hfRemoto').val() === "0") {
            CodAlmacenRemoto    = "";
            ConexionNombre      = "";            
        }

                    CodAlmacenRemoto    = "";
            ConexionNombre      = "";  

                var objParams = {
                                    Filtro_SerieDoc: $("#MainContent_txtSerie").val(),
                                    Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                    Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                    Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
                                    Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                    Filtro_CodAlmacen: $('#MainContent_ddlDestino').val(),                             
                                    Filtro_Observacion: $('#MainContent_txtObservacion').val(),
                                    Filtro_CodTipoDoc: $('#MainContent_ddlTipoDocumento').val(),
                                    Filtro_CodTipoOperacion: CodTipoOperacion,
                                    Filtro_CodMotivoTraslado: $('#MainContent_ddlMotivoTrabajo').val(),
                                    Filtro_CodFacturaAnterior: $('#hfCodFacturaAnterior').val(),
                                    Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                    Filtro_CodDireccion: $('#MainContent_ddlDireccion').val(),
                                    Filtro_CodAlmacenRemoto: CodAlmacenRemoto,
                                    Filtro_ConexionNombre: ConexionNombre,
                                    Filtro_CodTipoFormato: $('#MainContent_ddlFormatoImpresion').val()
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
                  
                    if (str_mensaje_operacion=='Se Grabo Correctamente')
                    {
                         toastr.success('Se grabo correctamente');
                         $('#MainContent_txtNumero').val(result.split('~')[3]);
                         if ($('#MainContent_chkImpresion').is(':checked') | $('#MainContent_chkImpresionTicket').is(':checked')) 
                         {
                            if ($('#MainContent_chkImpresion').is(':checked')) {
                            //var p1 = ''; var ti = 'TK'; //LA CURVA
                                F_ImprimirDocumento(result.split('~')[2],0);
                            }
                         }
                         F_Nuevo();
                    }
                    else
                    {
                        toastr.warning(str_mensaje_operacion);
                        return false;
                    }
                   
                 }
                else 
                {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            return false;
        }
}

function F_AgregarArticuloFromDsc(ControlID) {
    ControlID = ControlID.replace('lblProducto', 'imgAgregar');
    F_AgregarArticulo(ControlID, 1);
return true;
}

function F_AgregarArticulo(ControlID, DirectoBoton) {
    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var ddlprecio_grilla = '';
    var hfArticulo_grilla = '';
    var hfPrecio1_grilla = '';
    var hfPrecio2_grilla = '';
    var hfPrecio3_grilla = '';
    var lblCodigoProducto_grilla = '';
    var lblStock_grilla = '';
    var lblUM_grilla = '';
    var lblMoneda_grilla = '';
    var lblCodProducto_grilla = '';
    var lblCosto_grilla = '';
    var lblCodUm_grilla = '';
    var boolEstado = false;
    var imgAgregar_grilla = '';
    var cadena = 'Ingrese los sgtes. campos: '

    imgAgregar_grilla = '#' + ControlID;
    ctrlPosActual = imgAgregar_grilla;
    txtprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtPrecioLibre');
    ddlprecio_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlPrecio');
    txtcant_grilla = imgAgregar_grilla.replace('imgAgregar', 'txtCantidad');
    ddlLista_grilla = imgAgregar_grilla.replace('imgAgregar', 'ddlLista');
    hfArticulo_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblProducto');
    hfPrecio1_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio1');
    hfPrecio2_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio2');
    hfPrecio3_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblPrecio3');
    lblCodigoProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hlkCodNeumaticoGv');
    lblStock_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblstock');
    lblUM_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblUM');
    lblMoneda_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfMoneda');
    lblCosto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcosto');
    lblCodUm_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcodunidadventa');

    lblCodProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblcodproducto');

    $('#hfCodProductoAgregar').val($(lblCodProducto_grilla).val());
    $('#hfCostoAgregar').val($(lblCosto_grilla).val());
    $('#hfCodUmAgregar').val($(lblCodUm_grilla).val());
    $('#MainContent_txtCodigoProductoAgregar').val($(lblCodigoProducto_grilla).text());
    $('#MainContent_txtUMAgregar').val($(lblUM_grilla).text());
    $('#MainContent_txtStockAgregar').val($(lblStock_grilla).text());
    $('#MainContent_lblMonedaAgregar').text($(lblMoneda_grilla).val());
    

    $('#MainContent_txtArticuloAgregar').val($(hfArticulo_grilla).text());
    $('#MainContent_txtCantidad').val();
    $('#MainContent_txtPrecioDisplay').val($(hfPrecio1_grilla).val());
    $("#hfMenorPrecioAgregar").val(0);

    $("#MainContent_ddlPrecio").empty();

    if ($(hfPrecio1_grilla).val() != '')
    {
        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio1_grilla).val()).html($(hfPrecio1_grilla).val()));
        $("#hfMenorPrecioAgregar").val($(hfPrecio1_grilla).val());
    }

    if ($(hfPrecio2_grilla).val() != '0.00') {
        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio2_grilla).val()).html($(hfPrecio2_grilla).val()));

        if (Number($(hfPrecio2_grilla).val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($(hfPrecio2_grilla).val()) > 0)
            $("#hfMenorPrecioAgregar").val($(hfPrecio2_grilla).val());
    }

    if ($(hfPrecio3_grilla).val() != '0.00') {
        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio3_grilla).val()).html($(hfPrecio3_grilla).val()));

        if (Number($(hfPrecio3_grilla).val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($(hfPrecio3_grilla).val()) > 0)
            $("#hfMenorPrecioAgregar").val($(hfPrecio3_grilla).val());
        }

    $('#MainContent_chkServicios').prop('checked', false);
    $('#MainContent_txtArticuloAgregar').focus();
    //F_VerUltimoPrecio_Buscar($('#MainContent_txtCodigoProductoAgregar').val(), $('#hfCodProductoAgregar').val());
    F_Consultar_Almacenes_Stocks(ControlID);
    if (DirectoBoton === 1)
        F_TablaClick(ControlID);
    return false;
}

function F_Nuevo()
{
       $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
       $('.Jq-ui-dtp').datepicker('setDate', new Date());
       $('#MainContent_ddlMoneda').val('1');
       $('#MainContent_ddlMotivoTrabajo').val('7');
       $('#hfCodigoTemporal').val('0');
       $('#hfCodCtaCte').val('0');
       $('#MainContent_txtProveedor').val('');
       $('#MainContent_txtSubTotal').val('0.00');
       $('#MainContent_txtIgv').val('0.00');
       $('#MainContent_txtTotal').val('0.00');
       $('#MainContent_txtDestino').val('');
       $('#MainContent_txtProveedor').focus();
       $('#MainContent_ddlMotivoInterno').val(1);
       $('#MainContent_ddlTipoDocumento').val(4);
       $('#MainContent_txtObservacion').val('');
       $('#MainContent_txtResponsable').val('');
       $('#MainContent_txtSerie').val('');
       $('#MainContent_txtNumero').val('');
       $('#hfCodFacturaAnterior').val('0');
       $('#hfRemoto').val(0);
       $('#MainContent_ddlDireccion').empty();
       $('#lblCantidadRegistro').text('0');
       $('#MainContent_chkImportacion').prop('checked', true);
       try 
        {
              var objParams = {
                                        Filtro_CodSerie: '4'
                                        
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
                  F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);                            
                  //$('#MainContent_txtNumero').val(result.split('~')[3]);
                  //F_Serie(11);
                  $('.ccsestilo').css('background', '#FFFFE0');        
                }
                else 
                {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {

            toastr.warning("Error Detectado: " + e);
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
              var chkserie='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';
               if ($('#MainContent_chkserie').is(':checked'))
              chkserie='1';
              
              var objParams = {
                                        Filtro_SerieDoc: $('#MainContent_txtserieconsulta').val(),
                                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                        Filtro_ChkNumero: chkNumero,
                                        Filtro_ChkFecha: chkFecha,
                                        Filtro_chkserie: chkserie,
                                        Filtro_ChkCliente: chkCliente,
                                        Filtro_CodTipoOperacion: 0,
                                        Filtro_CodTipoDoc: 7,
                                        Filtro_CodTipoDocSust: $('#MainContent_ddlTipoDocConsulta').val()                                        
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
                    $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblNumero')); 
                    $('#MainContent_grvConsulta .detallesart').each(function () {
                        var lblNumero = '#' + this.id;
                        var hfAutomatico = lblNumero.replace("lblNumero", "hfAutomatico");
                        var lblEstado = lblNumero.replace("lblNumero", "lblEstado");
                        
                        var imgAutomatico = lblNumero.replace("lblNumero", "imgAutomatico");
                        if($(hfAutomatico).val()==1){
                            $(imgAutomatico).attr("src","../Asset/images/gcircle.png");
                        }else{
                            $(imgAutomatico).attr("src","../Asset/images/rcircle.png");
                        }

                        if ($(lblEstado).text() === 'ANULADO') {
                            $(lblEstado).css("color", "black");
                        } else if ($(lblEstado).text() === 'PENDIENTE') {
                            $(lblEstado).css("color", "red");
                        } else if ($(lblEstado).text() === 'CONFIRMADO') {
                            $(lblEstado).css("color", "green");
                        } else {
                            $(lblEstado).css("color", "BlueViolet");
                        }
                    });
                    if (str_mensaje_operacion!='')                        
                    toastr.warning(str_mensaje_operacion);
                  
                }
                else 
                {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
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

function F_AnularRegistro() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
    
    if(!confirm("ESTA SEGURO DE ANULAR LA NOTA DE INGRESO "  + " : " + $(lblNumero).text() + "\nDE : " +  $('#hfClienteAnulacion').val()))
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
                          Filtro_Codigo: $('#hfCodDocumentoVentaAnulacion').val(),
                          Filtro_Serie: '',
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_CodTipoOperacion: 0,
                          Filtro_CodTipoDoc: 7,
                          Filtro_CodTipoDocSust: $('#MainContent_ddlTipoDocConsulta').val(),
                          Filtro_ObservacionAnulacion:$("#MainContent_txtObservacionAnulacion").val()    
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
     MostrarEspera(true);
    F_AnularRegistro_Net(arg, function (result) {
                    F_Buscar();
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
         MostrarEspera(false);
        if (str_mensaje_operacion == "SE ANULO CORRECTAMENTE") {
                //F_Update_Division_HTML('div_consulta', result.split('~')[2]);      
                
                toastr.warning(result.split('~')[1]);
                 $('#div_Anulacion').dialog('close');
        }
        else {
             toastr.warning(result.split('~')[1]);
             return false;
        }

        return false;
    });

            }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            return false;
        }

 
}

function F_ConfirmarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 2000703, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
    var imgID = Fila.id;
    var lblCodMarcaGv = '#' + imgID.replace('imgConfirmar', 'hfCodigo');
    var lblEstado = '#' + imgID.replace('imgConfirmar', 'lblEstado');
    var lblNumero = '#' + imgID.replace('imgConfirmar', 'lblNumero');
    var lblCliente = '#' + imgID.replace('imgConfirmar', 'lblCliente');
    var hfTipoDocumento = '#' + imgID.replace('imgConfirmar', 'hfTipoDocumento');    
    if ($(lblEstado).text()=='ANULADO')
    {
        toastr.warning("LA NOTA SE ENCUENTRA ANULADA");
        return false;
    }
    if ($(lblEstado).text()=='CONFIRMADO')
    {
        toastr.warning("LA NOTA YA SE ENCUENTRA CONFIRMADA");
        return false;
    }

   
    if(!confirm("ESTA SEGURO DE CONFIRMAR LA NOTA DE INGRESO "  + " : " + $(lblNumero).text() + "\nDE : " +  $(lblCliente).text()))
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
                          Filtro_Codigo: $(lblCodMarcaGv).val(),
                          Filtro_Serie: '',
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_CodTipoOperacion: 0,
                          Filtro_CodTipoDoc: 7,
                          Filtro_CodTipoDocSust: $('#MainContent_ddlTipoDocConsulta').val()    
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
     MostrarEspera(true);
    F_ConfirmarRegistro_Net(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
         MostrarEspera(false);
        if (str_mensaje_operacion == "SE CONFIRMO CORRECTAMENTE") {
                //F_Update_Division_HTML('div_consulta', result.split('~')[2]);      
                F_Buscar();
                toastr.warning(result.split('~')[1]);
        }
        else {
             toastr.warning(result.split('~')[1]);
             return false;
        }

        return false;
    });

            }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            return false;
        }

 
}

function getContentTab(){
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
                {$('#MainContent_lblTC').text(result.split('~')[2]);
                    $('#MainContent_lblTCOC').text(result.split('~')[2]);}
                    
                else 
                    toastr.warning(result.split('~')[1]);
                
                return false;

                });
        }
        
        catch (e) 
        {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            return false;
        }

}

function F_Mostrar_Correlativo(CodDoc) {

    var arg;

    try {
        var objParams = {
            Filtro_CodAlmacenFisico: $('#MainContent_ddlPartida').val(),
            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerie option:selected").text()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Correlativo_NET
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
                       $('#MainContent_txtNumero').val(result.split('~')[2]);    
                       
                       //programacion para cuando se quiere que l numero correlativo sea el mismo de la nota que se esta editando.
                       //como se va a anular la anterior, esta se bloquea para que agarre un nuevo numero
                       if ($('#hfNumeroHidden').val() != "") {
                            $('#MainContent_txtNumero').val($('#hfNumeroHidden').val());    
                            $('#hfNumeroHidden').val('');                                           
                       }

                    }
                    else
                        toastr.warning(str_mensaje_operacion);
                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function F_MostrarTotales(){

var lblimporte_grilla='';
var chkDel='';
var Total=0;
var Igv=0;
var Subtotal=0;
     $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
             chkDel = '#' + this.id;
             if ($(chkDel).is(':checked'))
             {
             lblimporte_grilla = chkDel.replace('chkEliminar', 'lblimporte');
             txtCantidadEntregada = chkDel.replace('chkEliminar', 'txtCantidadEntregada');
             lblprecio = chkDel.replace('chkEliminar', 'lblprecio');
             Total+=parseFloat($(lblprecio).text() * $(txtCantidadEntregada).val());
             $(lblimporte_grilla).text($(lblprecio).text() * $(txtCantidadEntregada).val());
             }
     });
     var Cuerpo='#MainContent_'
    $(Cuerpo + 'txtTotalOC').val(Total.toFixed(2));
    $(Cuerpo + 'txtMontoOC').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgvOC').val((Total/(1+parseFloat( $("#MainContent_ddlIgv option:selected").text())) * parseFloat( $("#MainContent_ddlIgv option:selected").text())).toFixed(2));
    $(Cuerpo + 'txtSubTotalOC').val((Total/(1+parseFloat( $("#MainContent_ddlIgv option:selected").text()))).toFixed(2));
    
}

function F_ImprimirGuia(Codigo) {
   
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '200';


    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImprimirProforma(Codigo) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '203';

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_Imprimir(Fila) {

    var imgID = Fila.id;
    var lblID = '#' + imgID.replace('imgImprimir', 'hfCodigo');
    var lblEstado = '#' + imgID.replace('imgImprimir', 'lblEstado');
    var hfTipoDocumento = '#' + imgID.replace('imgImprimir', 'hfTipoDocumento');
   
    if ($(lblEstado).text()=='ANULADO')
    {
        toastr.warning("La " + $(hfTipoDocumento).val()  + " se encuentra anulada");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '103';

    rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblID).val() + '&' ;
    rptURL = rptURL + 'NombreTabla=' + '' + '&';
    rptURL = rptURL + 'NombreArchivo=' + '' + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_Imprimir2(Codigo) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '215';


    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ActualizarPrecio(Fila) {
    try {
        var txtPrecio = '#' + Fila;
        var lblcoddetalle = txtPrecio.replace('txtPrecio', 'lblcoddetalle');
        var hfPrecio = txtPrecio.replace('txtPrecio', 'hfPrecio');
        var hfCantidad = txtPrecio.replace('txtPrecio', 'hfCantidad');
        var txtCantidad = txtPrecio.replace('txtPrecio', 'txtCantidad');
        var lblproducto = txtCantidad.replace('txtCantidad', 'lblproducto');
        var lblAcuenta = txtPrecio.replace('txtPrecio', 'lblAcuenta');

        
        if (parseFloat($(txtPrecio).val()) == parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val()) == parseFloat($(hfCantidad).val())) {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
        }

        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_Precio: 0,
            Filtro_Cantidad: $(txtCantidad).val(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_CodDetDocumentoVenta: $(lblcoddetalle).text(),
            Filtro_Descripcion: $(lblproducto).text(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_Flag: 0,
            Filtro_CodAlmacenFisicoDesde: $('#MainContent_ddlPartida').val(),
            Filtro_CodAlmacenFisicoHasta: $('#MainContent_ddlDestino').val(),
            Filtro_FlagFormulario: 1,
            Filtro_Descuento: 0,
            Filtro_SolicitudDescuento: 0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarPrecio_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtAcuentaNV').val('0.00');
                }
                else {
                    $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                    $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                    $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                    $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                }
                if ($('#MainContent_ddlFormaPago').val() == 1)
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                toastr.warning(result.split('~')[1]);
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

function F_ActualizarCantidad(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, '') === "0") 
{
        var txtCantidad = '#' + Fila;
        var hfCantidad = txtCantidad.replace('txtCantidad', 'hfCantidad');
         $(txtCantidad).val(parseFloat($(hfCantidad).val()).toFixed(2));
        return false;
}

    try {
        var txtCantidad = '#' + Fila;
        var hfCodDetalle = txtCantidad.replace('txtCantidad', 'hfCodDetalle');
        var hfPrecio = txtCantidad.replace('txtCantidad', 'hfPrecio');
        var hfCantidad = txtCantidad.replace('txtCantidad', 'hfCantidad');
        var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');
        var lblProducto = txtCantidad.replace('txtCantidad', 'lblProducto');
        var hfCodDetalleOC = txtCantidad.replace('txtCantidad', 'hfCodDetalleOC');
        var lblAcuenta = txtCantidad.replace('txtCantidad', 'lblAcuenta');
        var Flag = 0;
        Flag = 1

        if (parseFloat($(txtPrecio).val()) == parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val()) == parseFloat($(hfCantidad).val())) {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
        }

        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_Precio: 0,
            Filtro_Cantidad: $(txtCantidad).val(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_Descripcion: $(lblProducto).text(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetalle).val(),           
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_Flag: Flag,
            Filtro_CodAlmacenFisicoDesde: $('#MainContent_ddlPartida').val(),
            Filtro_CodAlmacenFisicoHasta: $('#MainContent_ddlDestino').val(),
            Filtro_FlagFormulario: 1
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarPrecio_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtAcuentaNV').val('0.00');
                }
                else {
                    $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                    $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                    $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                    $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                }

                if ($('#MainContent_ddlFormaPago').val() == 1)
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                toastr.warning(result.split('~')[1]);
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

function F_FacturacionOC() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingresar los sgtes. Datos: <br> <p></p>";

        if ($(Contenedor + 'txtProveedor').val() == "" || $('#hfCodCtaCte').val() == 0)
            Mensaje = Mensaje + "\n" + "Proveedor";

        if ($(Contenedor + 'lblTC').text() == "0")
            Mensaje = Mensaje + "\n" + "Tipo de Cambio";

        if (Mensaje != "Ingresar los sgtes. Datos: <br> <p></p>") {
            toastr.warning(Mensaje);
            return false;
        }

        try {
            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionOC_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#divFacturacionOC').dialog({
                        resizable: false,
                        modal: true,
                        title: "Facturacion Orden de Compra",
                        title_html: true,
                        height: 500,
                        width: 890,
                        autoOpen: false
                    });
                    F_Update_Division_HTML('div_DetalleOC', result.split('~')[2]);

                    if (str_mensaje_operacion != "")
                        toastr.warning(str_mensaje_operacion);
                    else
                        $('#divFacturacionOC').dialog('open');

                    return false;

                }

                else
                    toastr.warning(result.split('~')[1]);

                return false;

            });
        }

        catch (e) {
            MostrarEspera(false);
            toastr.warning("Error Detectado: " + e);
            return false;
        }
    }

function F_ValidarStockGrilla(ControlID) {
    var txtCantidad = '#' + ControlID;
    var chkOK = txtCantidad.replace('txtCantidad', 'chkOK');
    var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');
    var txtDescuento = txtCantidad.replace('txtCantidad', 'txtDescuento');

    if ($(txtCantidad).val() == '')
        return false;

    if (F_ValidarAgregar() == false) {
        $(txtCantidad).val('');
        $(txtPrecio).val('');
        $(txtDescuento).val('');
        $(chkOK).prop('checked', false);
        return false;
    }

    var Stock = 0;
    var lblChala1 = txtCantidad.replace('txtCantidad', 'lblstock');
    var lblChala2 = txtCantidad.replace('txtCantidad', 'lblChala2');
    
    Stock = $(lblChala1).text();

    boolEstado = $(chkOK).is(':checked');

    if (boolEstado && parseFloat($(txtCantidad).val()) > parseFloat(Stock)) {
            toastr.warning("Stock insuficiente");
            $(txtCantidad).val('');
            return false;
        }

    F_AgregarTemporal();
    F_LimpiarGrillaConsulta();
    $('#MainContent_txtArticulo').focus();
    return false;
}

function F_Serie(CodTipoDoc) {
    var arg;

    try {
        var objParams =
            {                
                Filtro_CodAlmacenFisico: $('#MainContent_ddlPartida').val(),
                Filtro_CodTipoDoc: CodTipoDoc,
                Filtro_FlagNotaSalida:1
            };
            
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Serie_NET
            (
                arg,
                function (result) {
                    MostrarEspera(false);
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                         
                    if (str_resultado_operacion == "1") 
                    {                       
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        
                        //utilidad de reemplazo de nc
                        if ($('#hfSerieHidden').val() != "")
                        {
                            $('#MainContent_ddlSerie option:selected').text($('#hfSerieHidden').val());
                            $('#hfSerieHidden').val('');
                        }

                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');                     
                        F_Mostrar_Correlativo(CodTipoDoc);                  
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                  }
            );
    } catch (mierror) {
          MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
    }
}

function F_SerieConsulta() {
    var arg;

    try {
        var objParams =
            {                
                Filtro_CodAlmacenFisico: 0,
                Filtro_CodTipoDoc: $('#MainContent_ddlTipoDocConsulta').val(),
                Filtro_FlagNotaSalida:1
            };
            
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_SerieConsulta_NET
            (
                arg,
                function (result) {
                    MostrarEspera(false);
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                         
                    if (str_resultado_operacion == "1") 
                    {                       
                        //F_Update_Division_HTML('div_serieconsulta', result.split('~')[2]);
//                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');   
//                          $('#MainContent_ddlSerieConsulta').val($('#MainContent_ddlSerie').val());       
                          //F_Buscar();          
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                  }
            );
    } catch (mierror) {
          MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
    }
}
 
function F_BuscarDireccionesCliente() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCliente_AutoComplete',
        data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_ddlDireccion').empty();
//                $('#MainContent_ddlDestino').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_ddlDireccion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
//                    $('#MainContent_ddlDestino').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
            }
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0) {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return false;
}

function F_FacturacionVentas() {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos:";

    if ($(Contenedor + 'ddlTipoDocVentas').val() ==null)
        Mensaje = Mensaje + "<p></p>" + "Tipo Doc";

    if ($(Contenedor + 'ddlSerieDocVentas').val() ==null)
        Mensaje = Mensaje + "<p></p>" + "Serie";

   if ($(Contenedor + 'chkNumeroVentas').is(':checked') && $.trim($('#MainContent_txtNumeroDocVentas').val())=='') {
        Mensaje = Mensaje + "<p></p>" + "Numero";
    }        

    if (Mensaje != "Ingrese los sgtes datos:") {
        toastr.warning(Mensaje);
        return false;
    }

    var chkNumero='0';
    var chkFecha='0';
    
    if ($(Contenedor + 'chkNumeroVentas').is(':checked'))
        chkNumero='1';
    
    if ($(Contenedor + 'chkFechaVentas').is(':checked'))
        chkFecha='1';
    
    try {
        var objParams = {
            Filtro_CodTipoDoc:  $(Contenedor + 'ddlTipoDocVentas').val(),
            Filtro_SerieDoc:    $("#MainContent_ddlSerieDocVentas option:selected").text(),
            Filtro_Numero:   $(Contenedor + 'txtNumeroDocVentas').val(),
            Filtro_Desde:       $(Contenedor + 'txtDesdeVentas').val(),
            Filtro_Hasta:       $(Contenedor + 'txtHastaVentas').val(),
            Filtro_ChkNumero:   chkNumero,
            Filtro_ChkFecha:    chkFecha,
            Filtro_CodVendedor: $(Contenedor + 'ddlEmpleadoConsulta').val()          
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Ventas_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_Ventas', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');
                return false;
            }
            else
                toastr.warning(result.split('~')[1]);
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarVentas() {
    if (!F_ValidarAgregarVentas())
    return false;
          
    F_AgregarTemporalVentas();
    F_LimpiarGrillaConsultaVentas();
      
    return false;
}

function F_ValidarAgregarVentas() {
    try {
        var cadena = "Ingrese los sgtes. campos: ";
        var chkSi = '';
        var lblCodigo = '';
        var txtCantidadEntregada = '';
        var txtPrecioVenta = '';
        var x = 0;

        $('#MainContent_grvVentas .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            txtPrecioVenta = chkSi.replace('chkEliminar', 'txtPrecioVenta');
            lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                if ($(txtCantidadEntregada).val() == '')
                    cadena = cadena + "<p></p>" + "Cantidad para el Codigo " + $(lblCodigo).text();

                if ($(txtPrecioVenta).val() == '')
                    cadena = cadena + "<p></p>" + "Precio para el Codigo " + $(lblCodigo).text();
                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            toastr.warning(cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);

    }
}

function F_AgregarTemporalVentas() {
    try {

        var hfCodArticulo = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfCodUndMedida = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var hfFechaAnexo = '';
        var Contenedor = '#MainContent_';
        var tasaigv =1;
        var hfCodTipoDoc = '';
        if ($('#MainContent_chkConIgvMaestro').is(':checked'))
             tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);      

        $('#MainContent_grvVentas .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodArticulo = chkSi.replace('chkEliminar', 'hfCodArticulo');
            hfCodUndMedida = chkSi.replace('chkEliminar', 'hfCodUndMedida');           
            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            txtPrecioVenta = chkSi.replace('chkEliminar', 'txtPrecioVenta');
            hfCodDetalle = chkSi.replace('chkEliminar', 'hfCodDetalle');
            hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
            lblNumero = chkSi.replace('chkEliminar', 'lblNumero');
            lblProducto = chkSi.replace('chkEliminar', 'lblProducto');
            hfFechaAnexo = chkSi.replace('chkEliminar', 'hfFechaAnexo');
            hfCodTipoDoc = chkSi.replace('chkEliminar', 'hfCodTipoDoc');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodArticulo: $(hfCodArticulo).val(),
                    Cantidad: $(txtCantidadEntregada).val(),
                    Precio: (parseFloat($(txtPrecioVenta).val()))  / parseFloat(tasaigv),
                    PrecioDscto: (parseFloat($(txtPrecioVenta).val()))  / parseFloat(tasaigv) * (1-(parseFloat(0) / 100)),
                    Costo: $(hfCostoUnitario).val(),
                    CodUm: $(hfCodUndMedida).val(),
                    CostoUnitario: $(hfCostoUnitario).val(),
                    Dscto: 0,
                    CodDetalle: $(hfCodDetalle).val(),
                    OC: $(lblNumero).text(),
                    Descripcion: $(lblProducto).text().replace("&", "&amp;"),
                    CodTipoDoc: $(hfCodTipoDoc).val(),
                    Acuenta: 0,
                    Fecha: $(hfFechaAnexo).val()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var objParams = {
            Filtro_CodTipoDoc: 5,
            Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
            Filtro_CodCliente: $('#hfCodCtaCte').val(),
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
            Filtro_CodProforma: "0",
            Filtro_Igv: $(Contenedor + 'txtIgv').val(),
            Filtro_Total: $(Contenedor + 'txtTotal').val(),
            Filtro_CodGuia: "1",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: tasaigv,
            Filtro_TasaIgvDscto:parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1) ,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_FlagIgv: 1
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(result.split('~')[5]);
                $('#MainContent_txtMonto').val(result.split('~')[5]);
                $('#MainContent_txtIgv').val(result.split('~')[6]);
                $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#divFacturacionOC').dialog('close');

                if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                
                $('#MainContent_ddlFormaPago').val('11');

                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    toastr.warning('Los Producto(s) se han agregado con exito');
            }
            else {
                MostrarEspera(false);
                toastr.warning(result.split('~')[2]);

            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);

    }
}

function F_LimpiarGrillaConsultaVentas() {
    var chkSi = '';
    var txtCantidadEntregada = '';
    var txtPrecioVenta = '';

    $('#MainContent_grvVentas .chkDelete :checkbox').each(function () {
        chkSi = '#' + this.id;
        txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
        txtPrecioVenta = chkSi.replace('chkEliminar', 'txtPrecioVenta');
       
        $(txtPrecioVenta).prop('disabled', true);
        $(txtCantidadEntregada).prop('disabled', true);
        $(txtPrecioVenta).val('');
        $(txtCantidadEntregada).val('');
        $(chkSi).prop('checked', false);
    });
}

function F_ValidarCheck_Ventas(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtPrecioVenta = '';
    var boolEstado = false;
    var chkok_grilla='';
                   
            chkok_grilla = '#' + ControlID;
            txtCantidadEntregada = chkok_grilla.replace('chkEliminar', 'txtCantidadEntregada');
            txtPrecioVenta = chkok_grilla.replace('chkEliminar', 'txtPrecioVenta');
            lblCantidad = chkok_grilla.replace('chkEliminar', 'lblCantidad');
                 
            boolEstado = $(chkok_grilla).is(':checked');
            if (boolEstado)
            {               
                $(txtCantidadEntregada).prop('disabled', false);
                $(txtPrecioVenta).prop('disabled', false);
                $(txtCantidadEntregada).val($(lblCantidad).text());
                $(txtCantidadEntregada).focus();
            }
            else
            {
                $(txtCantidadEntregada).val('');
                $(txtCantidadEntregada).prop('disabled', true);
                $(txtPrecioVenta).prop('disabled', true);
            }           
        
    return true;
}

function F_ValidarStockGrillaVentas(ControlID) {
   
    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidadEntregada', 'chkEliminar');
    lblstock = txtcantidad_Grilla.replace('txtCantidadEntregada', 'lblCantidad');

    
    boolEstado = $(chkok_grilla).is(':checked');

    if (boolEstado &&  parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            toastr.warning("Stock insuficiente");
            $(txtcantidad_Grilla).val($(lblstock).text());
            return false;
    }
    if ($(txtcantidad_Grilla).val()=='')
        $(txtcantidad_Grilla).val($(lblstock).text());
    
    if (boolEstado==false)
     $(txtcantidad_Grilla).val($(lblstock).text());


    return true;
}

function F_CambioSerie_TipoDoc() {
if (!F_SesionRedireccionar(AppSession)) return false;

    var arg;

    try {
        var objParams =
            {                
                Filtro_CodDoc: $("#MainContent_ddlTipoDocVentas").val()
            };

            
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Series_Documentos_NET
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
                        F_Update_Division_HTML('div_SerieDocVentas', result.split('~')[2]);                                 
                        $('#MainContent_ddlSerieDocVentas').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');                        
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function F_ReemplazarDocumento(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            var imgID = Fila.id;
            var hfCodigo = '#' + imgID.replace('imgReemplazar', 'hfCodigo');
            var lblEstado = '#' + imgID.replace('imgReemplazar', 'lblEstado');
            var hfCodTipoDoc = '#' + imgID.replace('imgReemplazar', 'hfCodTipoDoc');
             var hfAutomatico = '#' + imgID.replace('imgReemplazar', 'hfAutomatico');
             var hfCodProforma = "#"+imgID.replace("imgReemplazar","hfCodProforma");
             var lblNumero = "#"+imgID.replace("imgReemplazar","lblNumero");
            
            if (($(hfCodTipoDoc).val()==10 || $(hfCodTipoDoc).val()==4) & ($(lblEstado).text() == 'FACTURADO' || $(lblEstado).text() == 'ANULADO' || $(lblEstado).text() == 'CONFIRMADO'))
            {
                toastr.warning('EL DOCUMENTO DEBE ESTAR ENVIADO O PENDIENTE');
                return false;
            }
            
            if($(hfCodProforma).val()!=''){
                toastr.warning("ESTA NOTA DE INGRESO SOLO PUEDE SER MODIFICADA POR EL VENDEDOR YA QUE ESTA ASOCIADA A UNA COTIZACION");
                return false;
            }    

             if($(lblNumero).text().substring(0, 4)=='0173' | $(lblNumero).text().substring(0, 4)=='0211' | $(lblNumero).text().substring(0, 4)=='0250'){
                toastr.warning("NO SE PUEDE MODIFICAR LOS INGRESOS INTERNOS");
                return false;
            }   


            var objParams = {
                Filtro_CodMovimiento: $(hfCodigo).val(),
                Filtro_CodTipoDoc: $(hfCodTipoDoc).val(),
                Filtro_TasaIgv: 1
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_ReemplazarFactura_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#hfCodCtaCte').val(result.split('~')[10]);
                    
                    F_BuscarDireccionesCliente();

                    $('#hfCodigoTemporal').val(result.split('~')[2]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[3]);
                    $('#hfCodFacturaAnterior').val(result.split('~')[4]);

                    $('#MainContent_txtEmision').val(result.split('~')[8]);
                    $('#MainContent_txtSerie').val(result.split('~')[5]);
                    $('#MainContent_txtNumero').val(result.split('~')[6]);
                    $('#MainContent_ddlTipoDocumento').val(result.split('~')[7]);
                    $('#MainContent_txtProveedor').val(result.split('~')[9]);
                    $('#MainContent_ddlDireccion').val(result.split('~')[11]);
                    $('#MainContent_ddlDestino').val(result.split('~')[12]);
                    $('#MainContent_txtObservacion').val(result.split('~')[13]);
                    $('#MainContent_ddlMotivoTrabajo').val(result.split('~')[15]);  
                    
                    $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo",'lblProducto'));                  

                    $('.ccsestilo').css('background', '#FFFFE0');
                    $("#divTabs").tabs("option", "active", $("#liRegistro").index());
                }
                else {
                    alert(result.split('~')[1]);
                    return false;
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

function F_LimpiarCampos() {
    //Bloqueo de campos
    //$('#MainContent_txtProveedor').prop('disabled', true); //lo desbloquee porque no era logico, en todo alvarado esta desbloqueado
            
    //Valores por Defecto
    $('#hfCodCtaCte').val(0);
    $('#MainContent_txtNroRuc').val('');
    $('#hfNroRuc').val('');
    $('#MainContent_txtProveedor').val('');
    $('#hfCliente').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDistrito').val('');
    $('#hfCodDireccion').val(0);
    $('#hfCodDepartamento').val(0);
    $('#hfCodProvincia').val(0);
    $('#hfCodDistrito').val(0);
    $('#hfDistrito').val('');
    $('#hfDireccion').val('');
    F_Update_Division_HTML('div_grvConsultaArticulo', GridArticulosInicializado);
    //F_Update_Division_HTML('div_grvDetalleArticulo',  GridDetalleDocumento);
    $('#MainContent_txtNroRuc').focus();
    
    
    return true;
}

function F_Inicializar_Tabla_Almacenes_Stocks() {

        $("#divConsultaArticulo").dialog({
            resizable: false,
            modal: true,
            title: "Consulta de Productos",
            title_html: true,
            height: 600,
            width: 1250,
            autoOpen: false
        });

    if (Number(P_MOSTRAR_PANEL_DERECHO_STOCK_OTROS_ALMACENES) + Number(P_MOSTRAR_PANEL_DERECHO_ULTIMA_VENTA))
        $('#tdPanelStocks').css('display', 'block');

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
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });

return true;
}

function F_Consultar_Almacenes_Stocks(CodigoProducto) {
    var Marca = $("#" + CodigoProducto.replace("imgAgregar", "hfMarca")).val();
    var CodProductoAzure = $("#" + CodigoProducto.replace("imgAgregar", "hfCodProductoAzure")).val();
    var CodigoInterno = $("#" + CodigoProducto.replace("imgAgregar", "hfCodigoInterno")).val();
    var CodProductoAzure = $("#" + CodigoProducto.replace("imgAgregar", "lblcodproducto")).val();

    $('#tbStocksAlmacenes .td-tdsel').each(function () {
        trControl = this.id; var len = trControl.length; var tdControl = "#td" + trControl.substring(2, len);
        $(tdControl).text("");
        $(tdControl).append('<img class="cssimgAlmacen" style="width:8px" src="../Asset/images/loading.gif" />');
        
    });

//    $('.cssimgAlmacen').each(function() {
//        $(this).css('display', 'block');
//    });
//    

    if (CodProductoAzure.toString() === "")
        CodProductoAzure = 0;

    F_Consulta_Stock(CodProductoAzure, CodigoInterno);

    return true;

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


function F_Consulta_Stock(CodigoProducto, CodigoInterno) {

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'NotaIngresoSalida.aspx/F_Consulta_Stock_Azure_NET',
        dataType: "json",
        data: "{'CodProductoAzure':'" + CodigoProducto  + "','CodigoInterno':'" + CodigoInterno + "'}",
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {
                $('.cssimgAlmacen').each(function() {
                    $(this).css('display', 'none');
                });
                $.each(data.rows, function (index, item) {

                    if (item.ConsultadoSN === '0')
                        $('#td' + item.Clave).text('N/A');
                    else
                        $('#td' + item.Clave).text(item.Stock);
                });
            }
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
        
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });
return true;
}

function F_Stock(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_StockAlmacenes(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_StockAlmacenes(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsultaArticulo_pnlOrdersKardex_0';
                var Col = Fila.split('_')[3];
                var CodProducto = $('#' + Fila.replace('pnlOrdersKardex', 'lblcodproducto')).val();      
                var grvNombre = 'MainContent_grvConsultaArticulo_grvDetalleKardex_' + Col;
                Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

                if ($(Hfgv).val() === "1")
                {
                    $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                    $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                }
                else 
                {                                                                                                                                                                                                                        {
                        var objParams = 
                        {                          
                            Filtro_CodProducto: CodProducto,
                             Filtro_grvNombre: grvNombre                       
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        //MostrarEspera(true);
                        $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                        F_StockAlmacenes_NET(arg, function (result) {
                
                        $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                        //MostrarEspera(false);

                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                            $(Hfgv).val('1');
                        }
                        else
                        {
                            toastr.warning(str_mensaje_operacion);
                        }
                        return false;
                        });        
                }
                }
        }
        catch (e) 
        {
              MostrarEspera(false);
            toastr.warning("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}

var CtlgvProducto;
var HfgvProducto;

function imgMasProducto_Click(Control) {
    CtlgvProducto = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_ProductoDetalle(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_ProductoDetalle(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsultaArticulo_pnlProductos_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlProductos', 'lblcodproducto')).val();           
                var grvNombre = 'MainContent_grvConsultaArticulo_grvDetalleProducto_' + Col;
                HfgvProducto = '#' + Fila.replace('pnlProductos', 'hfDetalleCargado');

                if ($(HfgvProducto).val() === "1")
                {
                    $(CtlgvProducto).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvProducto).next().html() + '</td></tr>');
                    $(CtlgvProducto).attr('src', '../Asset/images/minus.gif');
                }
                else 
                {                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,                        
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        $(CtlgvProducto).attr('src', '../Asset/images/loading.gif');
                        F_ProductoDetalle_NET(arg, function (result) {
                
                        $(CtlgvProducto).attr('src', '../Asset/images/minus.gif');
                  
                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(CtlgvProducto).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvProducto).next().html() + '</td></tr>');
                            $(HfgvProducto).val('1');
                        }
                        else
                        {
                            toastr.warning(str_mensaje_operacion);
                        }
                        return false;
                        });        
                }
                }
        }
        catch (e) 
        {
              MostrarEspera(false);
            toastr.warning("ERROR DETECTADO: " + e);
            return false;
        }

        return true;

}

function F_ImprimirFacturaPDF(Fila) {
        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodTipoArchivo = '5';
        var CodMenu = 101;
        var CodNotaIngreso = $("#" + Fila.id.replace("imgPdf", "hfCodigo")).val();        
        var CodTipoFormato = ($('#MainContent_ddlFormatoImpresion2').val()==null)?0:$('#MainContent_ddlFormatoImpresion2').val();
        var NombreTabla = '';
        var NombreArchivo = '';        
        ArchivoRPT = "";
        rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'Codigo=' + CodNotaIngreso + '&';
        rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';        
        rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
        rptURL = rptURL + "CodTipoFormato="+CodTipoFormato+'&';        

        window.open(rptURL, "PopUpRpt", Params);
        
        return false;
}
function F_ImprimirDocumento2(Fila){
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgImprimir', 'hfCodigo');    
    var CodTipoFormato =  ($('#MainContent_ddlFormatoImpresion2').val()==null)?0:$('#MainContent_ddlFormatoImpresion2').val(); // POR DEFECTO A4
    F_ImprimirDocumento($(lblCodigo).val(),CodTipoFormato);
}
function F_ImprimirDocumento(CodDocumentoVenta,CodTipoFormato) {
        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodMenu = 104;
        var NombreTabla = '';
        var NombreArchivo = '';
        rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'Codigo=' + CodDocumentoVenta + '&';
        rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
        rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
        rptURL = rptURL + 'CodTipoFormato=' + CodTipoFormato + '&';

        window.open(rptURL, "PopUpRpt", Params);

        return false;
}

var CtlgvObservacion;
var HfgvObservacion;
function imgMasObservacion_Click(Control) {
    CtlgvObservacion = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_Observacion(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_Observacion(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleObservacion_' + Col;
        HfgvObservacion = '#' + Fila.replace('pnlOrdersObservacion', 'hfDetalleCargadoObservacion');

        if ($(HfgvObservacion).val() === "1") {
            $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
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
                F_Observacion_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
                        $(HfgvObservacion).val('1');
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

// DETALLE OBSERVACION
var CtlgvAuditoria;
var HfgvAuditoria;
function imgMasAuditoria_Click(Control) {
    CtlgvAuditoria = Control;
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
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleAuditoria_' + Col;
        HfgvAuditoria = '#' + Fila.replace('pnlOrdersAuditoria', 'hfDetalleCargadoAuditoria');

        if ($(HfgvAuditoria).val() == "1") {
                    $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
                    $(CtlgvAuditoria).attr('src', '../Asset/images/minus.gif');
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
                $(CtlgvAuditoria).attr('src', '../Asset/images/loading.gif');
                F_Auditoria_NET(arg, function (result) {
                $(CtlgvAuditoria).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
                        $(HfgvAuditoria).val('1');
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

var lblNumero;
function F_AnularPopUP(Fila) {
if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
        lblNumero = '#' + imgID.replace('imgAnularDocumento', 'lblNumero');
        var lblCliente = '#' + imgID.replace('imgAnularDocumento', 'lblCliente');
        var hfTipoDocumento = '#' + imgID.replace('imgAnularDocumento', 'hfTipoDocumento');
        var hfAutomatico = "#" + imgID.replace('imgAnularDocumento','hfAutomatico');   
        var hfCodProforma = "#"+imgID.replace("imgAnularDocumento","hfCodProforma");

        if ($(lblEstado).text()=='ANULADO')
        {
            toastr.warning("LA NOTA DE INGRESO SE ENCUENTRA ANULADA");
            return false;
        }      
         
        if ($(lblEstado).text()=='CONFIRMADO')
        {
            toastr.warning("LA NOTA DE INGRESO SE ENCUENTRA CONFIRMADO");
            return false;
        }  

        $('#hfCodDocumentoVentaAnulacion').val($(hfCodigo).val());
        $('#hfClienteAnulacion').val($(lblCliente).text());    
        $('#MainContent_txtObservacionAnulacion').val('');

        $('#div_Anulacion').dialog({
               resizable: false,
               modal: true,
               title: "Eliminacion de Nota de Ingreso",
               title_html: true,
               height: 190,
               width: 470,
               autoOpen: false
           });          
        $('#div_Anulacion').dialog('open');
}

function checkAll(objRef) {
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvDetalleArticulo input:checkbox').prop('checked', true);
    else
        $('#MainContent_grvDetalleArticulo input:checkbox').prop('checked', false);
}

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
    var imgID = Fila.id;
    var hfCodigo = '#' + imgID.replace('imgEliminarDocumento', 'hfCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblNumero = '#' + imgID.replace('imgEliminarDocumento', 'lblNumero');
    var lblCliente = '#' + imgID.replace('imgEliminarDocumento', 'lblCliente');
  
        if ($(lblEstado).text()=='CONFIRMADO')
        {
            toastr.warning("LA NOTA DE INGRESO SE ENCUENTRA CONFIRMADO");
            return false;
        }  

    if(!confirm("ESTA SEGURO DE ELIMINAR LA NOTA DE INGRESO : " + $(lblNumero).text() + "\n" + "DEL PROVEEDOR : " +  $(lblCliente).text()))
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
                          Filtro_Codigo: $(hfCodigo).val(),
                          Filtro_Serie: '',
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_CodTipoOperacion: 0,
                          Filtro_CodTipoDoc: 7,
                          Filtro_CodTipoDocSust: $('#MainContent_ddlTipoDocConsulta').val()
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
     MostrarEspera(true);
    F_EliminarRegistro_Net(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
         MostrarEspera(false);
        if (str_mensaje_operacion == "SE ELIMINO CORRECTAMENTE") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);    
                 $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblNumero'));   
     toastr.warning(result.split('~')[1]);
        }
        else {
             toastr.warning(result.split('~')[1]);
        }

        return false;
    });

            }
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

 
}

function F_Abrir(Fila) {
    if (F_PermisoOpcion(CodigoMenu, 2000706, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgAbrir', 'hfCodigo');
        var lblNumero =  '#' + imgID.replace('imgAbrir', 'lblNumero');
        var lblEstado = '#' + imgID.replace('imgAbrir', 'lblEstado');
           
        if ($(lblEstado).text() != "CONFIRMADO") {
            toastr.warning('NO SE PUEDE DESCONFIRMAR LA NOTA INGRESO');
            return false;
        }

        if (!confirm("ESTA SEGURO DESCONFIRMAR LA NOTA INGRESO"))
            return false;

        try {
            var Contenedor = '#MainContent_';
            var objParams = {
                Filtro_CodMovimiento: $(hfCodigo).val()             
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_Abrir_NET(arg, function (result) {

                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {
                    if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                        toastr.warning('Se grabo correctamente');
                        F_Buscar();               
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                        return false;
                    }
                }
                else {
                    toastr.warning(result.split('~')[1]);
                    return false;
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
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}