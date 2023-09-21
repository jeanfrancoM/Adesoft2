﻿var AppSession = "../Ventas/RegistroCotizacionesUnitario.aspx";

var CodigoMenu = 4000;
var CodigoInterno = 1;

//---------------------------- 
var CodigoEmpresa =3; //1 Vensertec //2Lubricentro
var ValidarStock = 1; //1 Si valida //0 No Valida
// Lista de Impresoras impresion masiva
var ImpresorasNotaPedido = ['IMPRESORAFACTURAELECTRONICA', 'Otra Impresora'];
//----------------------------
var PedidosCargados = true;
var P_VALIDASTOCK;
var P_VALIDASTOCK_MONTO_MINIMO; 
var P_UNIDADES_ENTEROS;

//control de posicion de agregar productos
var TipoCliente = '';
var GridDetalleFTInicializado = '';
var GridArticulosInicializado = '';
var CargandoFormulario = true;
var ValorModificacion = 0;
var VariablePrecioFlag = 0;
var ContadorPrecioMinimo = 0;
$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    F_FuncionesBotones();

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }
////   hEcho por Adrian
    $('#MainContent_txtNroRuc').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete_Alvarado',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
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
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[14],
                            D1:item.split(',')[19],
                            D2:item.split(',')[20],
                            D3:item.split(',')[21]
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
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.label);
            $('#MainContent_txtCliente').val(i.item.label);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#MainContent_txtDireccion').val(i.item.Direccion);
            $('#hfDireccion').val(i.item.Direccion);
            $('#MainContent_txtDistrito').val(i.item.Distrito.trim());
            $('#hfCodDireccion').val('0');
            $('#hfCodDireccionDefecto').val(i.item.CodDireccion);
            $('#hfCodDepartamento').val(i.item.CodDepartamento);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);            
            $('#MainContent_lblD1').text(i.item.D1);
            $('#MainContent_lblD2').text(i.item.D2);
            $('#MainContent_lblD3').text(i.item.D3);
            $('#hfDistrito').val(i.item.Distrito.trim());
            $('#txtSaldoCreditoFavor').text("");
            $('#hfSaldoCreditoFavor').val("0.00");
            $('#hfFlagRuc').val("1");
            F_BuscarDireccionesCliente();
            //validacion de precioexclusivo echo por joel
            if (F_ValidarPrecioExclusivo()){
           
             $('#hfCodigoTemporal').val('0');
            $('#hfCodDocumentoVenta').val('0');
            $('#hfCodFacturaAnterior').val('0');
            $('#MainContent_ChkCodigo').prop('checked', true);
            F_Update_Division_HTML('div_grvDetalleArticulo', GridDetalleFTInicializado);
            F_Update_Division_HTML('div_grvArticulosPedido', GridDetalleFTInicializado);
            $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
            $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
            $('.ccsestilo').css('background', '#FFFFE0'); 
            }

        },
        complete: function () {
            $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
            $('#MainContent_txtCliente').focus();
        },
        minLength: 3
    });
  
    $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
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
            $('#hfCodDepartamento').val(i.item.val);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
            $('#hfDistrito').val(i.item.label);
            F_BuscarDireccionPorDefecto();
        },
        minLength: 3
    });

    $('#MainContent_txtArticuloPedido').autocomplete({
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
                            Moneda: item.split(',')[4],
                            CodProducto: item.split(',')[5]
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
            $('#hfCodArticuloPedido').val(i.item.CodProducto);
            $('#MainContent_txtCantidadArticulo').val(i.item.Stock);
            $('#MainContent_txtCantidad173Ped').val(0);
            $('#MainContent_txtCantidad250Ped').val(0);
            $('#MainContent_txtCantidadABCPed').val(0);
                        

        },
        minLength: 3
    });

    $("#MainContent_txtDistrito").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtDistrito").val() != $("#hfDistrito").val() & $("#hfCodDistrito").val() != '0')
        {
            $("#MainContent_txtDistrito").val('');
            $("#hfDistrito").val('');
            $("#hfCodDistrito").val('0');
            $("#MainContent_txtDireccion").val('');
            $("#hfCodDireccion").val('0');
            $("#hfDireccion").val('');
        }
            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();

            if ( Index ==-1 ) {} else {
                if ($("#MainContent_txtCliente").val() === '---NUEVO CLIENTE---')
                return true;
            $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
            $('#hfCliente').val($('#MainContent_txtNroRuc').val());
            }
    });
    
    $("#MainContent_chkPedido").click(function(){
        if($(this).is(":checked")){
            $("#MainContent_ddlAlmacenesExternos").prop("disabled",false);
        }else{
            $("#MainContent_ddlAlmacenesExternos").prop("disabled",true);
        }
    })

    $("#MainContent_txtNroRuc").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtNroRuc").val() != $("#hfNroRuc").val() & $("#hfCodCtaCte").val() != '0')
        {
            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();

            if ( Index ==-1 ) {} else {
                if (Cliente.split('-')[0].trim() === "55555555555")
                return true;}

                if ((Index==9 || Index == 12) && $('#hfFlagRuc').val()=="1")
                return false;

                var nroruc = $("#MainContent_txtNroRuc").val();
                F_LimpiarCamposCliente();
                $("#MainContent_txtNroRuc").val(nroruc);
                $("#MainContent_txtNroRuc").focus();
        }
    });

    $("#MainContent_txtCliente").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtCliente").val() != $("#hfCliente").val() & $("#hfCodCtaCte").val() != '0' & $("#MainContent_txtCliente").val() === '---NUEVO CLIENTE---')
        {
            if ($("#MainContent_txtNroRuc").val() != '11111111')
            {
                alertify.log('NO SE PUEDE MODIFICAR CLIENTES REGISTRADOS');
                $("#MainContent_txtCliente").val($("#hfCliente").val());
                return true;
            }
        }
    });

    $("#MainContent_txtDireccion").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtDireccion").val() != $("#hfDireccion").val() & $("#hfCodDireccion").val() != '0')
        {
            $("#hfCodDireccion").val('0');
        }

            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();

            if ( Index ==-1 ) {} else {
                if ($("#MainContent_txtCliente").val() === '---NUEVO CLIENTE---')
                return true;
            $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
            $('#hfCliente').val($('#MainContent_txtNroRuc').val());
            }
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

    F_Controles_Inicializar();

    $('#MainContent_btnBuscarArticulo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;


        if ($("#MainContent_chkServicios").is(':checked')) 
            return false;

        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val() == "")
                return false
            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
                cadena = cadena + "<p></p>" + "Articulo (Minimo 2 Caracteres)"

            if ($('#MainContent_ddlMoneda option').size() == 0)
            { cadena = cadena + "<p></p>" + "Moneda"; }
            else {
                if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "<p></p>" + "Moneda";
            }

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

    $("#MainContent_chkServicios").click(function () {
        if ($(this).is(':checked')) {
            $('#hfCodProductoAgregar').val('0');
            $('#hfCostoAgregar').val('0');
            $('#hfCodUmAgregar').val('0');
            $('#MainContent_txtCodigoProductoAgregar').val('');
            $('#MainContent_txtStockAgregar').val('');
            $('#MainContent_txtUMAgregar').val('');
            $('#MainContent_txtPrecioDisplay').val('0.00');
            $('#MainContent_ddlPrecio').empty();
            $('#MainContent_txtArticuloAgregar').val('');
            
            $('#MainContent_txtExclusivo').val('');
            $('#MainContent_txtCantidad').val('1');
            $('#MainContent_txtArticuloAgregar').focus();
        }
    });

    $('#MainContent_btnAgregarProducto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, 4000101, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try 
        {
                $('#MainContent_txtArticulo').val('');
                $('#MainContent_chkServicios').prop('checked',false);
                $('#MainContent_chkNotaPedido').prop('checked',false);
                $('#MainContent_txtCodigoProductoAgregar').val('');
                $('#MainContent_txtStockAgregar').val('');
                $('#MainContent_txtUMAgregar').val('');
                $('#MainContent_chkServicios').val('');
                $('#MainContent_txtArticuloAgregar').val('');
                $('#MainContent_txtCantidad').val('');
                $('#MainContent_txtPrecioDisplay').val('');
                $('#MainContent_ddlPrecio').empty();

                $("#MainContent_txtCantidadABC").val('');                                                   
                $("#MainContent_txtCantidad250").val('');                                                   
                $("#MainContent_txtCantidad173").val(''); 
                
                                                                 
                $("#MainContent_txtExclusivo").val('');                     


                $('#MainContent_txtClienteDropTop').val($('#MainContent_txtCliente').val());

                F_LimpiarGrillaConsulta();    

                $('#divConsultaArticulo').dialog('open');
                $('#MainContent_txtArticulo').focus();
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });  
    
    $('#MainContent_btnAplicarDescuento').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try 
        {
            //valida que el descuento sea valido
            if ($.isNumeric($('#MainContent_txtDescuento').val()))
            {
                var Dcto = $('#MainContent_txtDescuento').val();
                if (Dcto > 0 & Dcto < 100)
                {
                    $('#MainContent_txtDescuento').val('0.00');
                    $('#MainContent_grvDetalleArticulo :checkbox').each(function () {
                        chkSi = this.id;
                        F_ActualizarPrecio(chkSi.replace('chkEliminar','txtPrecio'), Dcto);
                    });
                }
                else
                {
                    alertify.log('AGREGE UN PORCENTAJE DE DESCUENTO VALIDO');
                    $('#MainContent_txtDescuento').val('0.00');
                    $('#MainContent_txtDescuento').focus();
                }
            }
            else
            {
                alertify.log('INGRESE UN PORCENTAJE DE DESCUENTO VALIDO');
                $('#MainContent_txtDescuento').val('0.00');
                $('#MainContent_txtDescuento').focus();
            }
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregar').click(function () {
     if (!F_SesionRedireccionar(AppSession)) return false;


        try {
            if (!F_ValidarAgregar())
                    return false;

            if (!$("#MainContent_chkServicios").is(':checked')) 
              F_AgregarTemporal();
            else 
              F_AgregarTemporalServicio();

            F_LimpiarGrillaConsulta();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });
        
    $('#MainContent_btnAgregarPedido').click(function () {
     if (!F_SesionRedireccionar(AppSession)) return false;


        try {                        
            F_AgregarTemporalPedido();                        
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnCancelar').click(function () {
     if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            $(FilaActualizarValidaPermiso).val(PrecioActualizarValidarPermiso);
            $('#divClavePrecio').dialog('close');
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnVerificar').click(function () {
     if (!F_SesionRedireccionar(AppSession)) return false;
     
        try {
            F_VerificarUsuario();
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });
   
    $('#MainContent_btnEliminar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, 4000104, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarEliminar())
                return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LOS PRODUCTOS SELECCIONADOS"))
                F_EliminarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminarPedido').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEliminarPedido())
                return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LOS PRODUCTOS SELECCIONADOS"))
                F_EliminarTemporalPedido();

            return false;
        }

        catch (e) {

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

            if (confirm("ESTA SEGURO DE GRABAR LA COTIZACION"))
            F_GrabarDocumento();

            return false;
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }     
    });
        
    $('#MainContent_btnActualizar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_ActualizarDetalle();
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
        }        
        catch (e) 
        {
            alertify.log("Error Detectado: " + e);
        }
      return false;
        });

         //anular
    $('#MainContent_btnAnular').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if ($.trim($('#MainContent_txtObservacionAnulacion').val()) == '') {
                alertify.log("INGRESAR LA OBSERVACION");
                return false;
            }
            F_AnularRegistro();
            return false;
        }
        catch (e) {
//            toastr.warning("Error Detectado: " + e);
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

    $('#MainContent_btnFacturarCotizacion').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            //F_FacturacionCotizacion();
            F_AgregarTemporalCTxNumero();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarTop').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_VerUltimoPrecio_Buscar($('#MainContent_txtCodigoProductoAgregar').val(), $('#hfCodProductoAgregar').val());
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });

    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();

    $('#MainContent_txtCliente').blur(function () {
        try 
        {
            if ($('#MainContent_txtCliente').val()=='')
            return false

            var Index= $('#MainContent_txtCliente').val().indexOf('-');
            var Cliente = $('#MainContent_txtCliente').val();
            if ( Index ==-1 ) {} else {
                if ($("#MainContent_txtCliente").val() != '---NUEVO CLIENTE---')
                {
//                    Cliente=Cliente.substr(Cliente.length - (Cliente.length -(Index+2)));
                }
            }
            $('#MainContent_txtCliente').val(Cliente);
            $('#hfCliente').val($('#MainContent_txtCliente').val());
            return false;
              
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;
    });
    
    $('#MainContent_txtNumero').blur(function () {
        var n = 7; 
        if ($("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'F' || $("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'B') n = 8;
        var id = '00000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - n));
        return false;
    });

    $("#MainContent_chkImpresionTicket").change(function () {
        if (this.checked) 
          $('#MainContent_chkImpresion').prop('checked', false);          
    });

    $("#MainContent_chkImpresion").change(function () {
        if (this.checked)           
          $('#MainContent_chkImpresionTicket').prop('checked', false);      
    });

    $("#divClavePrecio").dialog({
        resizable: false,
        modal: true,
        title: "Usuario Autorizado",
        title_html: true,
        height: 200,
        width: 350,
        autoOpen: false,
        closeOnEscape: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }
    });

    $("#divConsultaArticulo").dialog({
        resizable: false,
        modal: true,
        title: "Consulta de Productos",
        title_html: true,
        height: 600,
        width: 1250,
        autoOpen: false
    });

    //cambio de minorista a calle y viceversa
    var x='';
    $('#MainContent_txtNroRuc').blur(function () {
        try 
        {
        var Categoria=$('#hfCodCategoria').val();
        if(localStorage.getItem('Valor1')===null){
        if((localStorage.getItem('Valor1')===null) && $('#hfCodCategoria').val()=='2'){
        localStorage.setItem('Valor1','Minorista');
         x = localStorage.getItem('Valor1'); 
        }
        if((localStorage.getItem('Valor1')===null) && $('#hfCodCategoria').val()=='1'){
        localStorage.setItem('Valor1','Calle');
         x = localStorage.getItem('Valor1'); 
        }
        }else{
        if( $('#hfCodCategoria').val()=='1'){
        localStorage.setItem('Valor1','Calle');
        
          if(localStorage.getItem('Valor1')!=x && $('#lblCantidadRegistro').text()!="0"){
           localStorage.setItem('Valor1','Calle');
                 alertify.log('SE CAMBIA A CALLE');
                 F_NuevoCLiente();
                 x = localStorage.getItem('Valor1'); 
                  localStorage.clear();       
                } 
        }
        
        if($('#hfCodCategoria').val()=='2' ){
         localStorage.setItem('Valor1','Minorista');
         
          if(localStorage.getItem('Valor1')!=x && $('#lblCantidadRegistro').text()!="0"){
           localStorage.setItem('Valor1','Minorista');
                 alertify.log('SE CAMBIA A MINORISTA'); 
                 F_NuevoCLiente();
                 x = localStorage.getItem('Valor1');     
                  localStorage.clear();   
                }
        }
         
        }
         
   
        }
        catch (e){

            alertify.log("Error Detectado: " + e);
        }

        
        return false;
    });
    

     F_Derecha();

     F_InicializarCajaTexto();         
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

function F_DireccionDisplayUp()
{
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
function F_DireccionDisplayDown()
{
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

function F_BuscarDireccionPorDefecto() {
if (!F_SesionRedireccionar(AppSession)) return false;
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistrito_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#hfCodDireccion').val(data.d[0].split(',')[0]);
                    $('#MainContent_txtDireccion').val(data.d[0].split(',')[1]);
                    $('#hfDireccion').val(data.d[0].split(',')[1]);
                    $('#MainContent_txtCorreo').val(data.d[0].split(',')[5]);
                    if ($('#hfCodCtaCte').val() == 29)
                    {
                        $('#hfCodDistrito').val(data.d[0].split(',')[2]);
                        $('#hfCodProvincia').val(data.d[0].split(',')[3]);
                        $('#hfCodDepartamento').val(data.d[0].split(',')[4]);
                    }
                }
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

//ENZO
function F_BuscarDireccionesCliente() {
$('#td_loading').css('display', 'block');
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_ddlDireccion').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_ddlDireccion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
                if (data.rows.length > 0) {
                    if ($('#hfCodDireccionDefecto').val() != '0') {
                        $('#MainContent_ddlDireccion').val($('#hfCodDireccionDefecto').val());
                    }
                    $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                    if ($('#MainContent_txtDireccion').val() == "")
                    {
                        $('#MainContent_ddlDireccion').val($("#MainContent_ddlDireccion option:first").val());
                        $('#hfCodDireccion').val($("#MainContent_ddlDireccion option:first").val());          
                        $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                    }
                    $('#hfCodDireccion').val($("#MainContent_ddlDireccion").val());
                }
            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            $('#td_loading').css('display', 'none');
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }
            $('#td_loading').css('display', 'none');
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_BuscarDistrito() {
if (!F_SesionRedireccionar(AppSession)) return false;
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDistrito_ListarXCodDistrito',
        //data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        data: "{'CodDistrito':'" + $('#hfCodDistrito').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#MainContent_txtDistrito').val(data.d[0].split(',')[3]);
                }
        },
        complete: function () {
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

$().ready(function () {

    $(document).everyTime(600000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });


});

$(document).on("change", "select[id $= 'MainContent_ddlSerie']",function () {
    F_CambioSerie();
 });

$(document).on("change", "select[id $= 'MainContent_ddlSerieConsulta']", function () {
     F_Buscar();
 });

$(document).on("change", "select[id $= 'MainContent_ddlFormaPago']",function () {
     $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
     F_FormaPago($("#MainContent_ddlFormaPago").val());
} );

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']",function () {
F_ACTUALIZAR_MONTO_MONEDA();
} );

$(document).on("change", "select[id $= 'MainContent_ddlPrecio']",function () {
    $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").text());
} );

function F_EliminarTodos() {
    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';
        var tasaigv = 1;
        var FlagIgv = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblcoddetalle');
                var objDetalle = {
                    CodDetalle: $(lblcoddetalle_grilla).text()
                };
                arrDetalle.push(objDetalle);
        });

        var Contenedor = '#MainContent_';

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }      

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_FlagIgv: FlagIgv,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
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
                    $('#MainContent_txtAcuentaNV').val('0.00');
                    $('#MainContent_txtAcuenta').val('0.00');
                    $('#MainContent_chkConIgvMaestro').prop('disabled',false);
                    $('#MainContent_chkSinIgvMaestro').prop('disabled',false);
                }
                else {
                    $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                    $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                    $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                    $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                }

                if ($('#MainContent_ddlFormaPago').val() == 1 | $('#MainContent_ddlFormaPago').val() == 6 | $('#MainContent_ddlFormaPago').val() == 15)
                    $('#MainContent_txtAcuenta').val(parseFloat(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val())).toFixed(2));
                else
                    $('#MainContent_txtAcuenta').val('0.00');

                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                if ($("#MainContent_chkTransferenciaGratuita").is(':checked')) {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                }
                else
                    F_MostrarTotales();
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

$(document).on("change", "select[id $= 'MainContent_ddlDireccion']",function () {
     $('#MainContent_txtDireccion').val($('#MainContent_ddlDireccion option:selected').text());
     $('#hfCodDireccion').val($('#MainContent_ddlDireccion option:selected').val());
} );

//cambio de tipo de documento
//function F_CambioTipo2() {
//if (!F_SesionRedireccionar(AppSession)) return false;
//    $("#hfCodTipoDoc2").val($("#MainContent_ddlTipoDoc2").val());
//    F_CambioSerie_TipoDoc2();
//    return false;
//}

function F_CambioSerie_TipoDoc() {
if (!F_SesionRedireccionar(AppSession)) return false;

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val()
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
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[4]);

                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');

                        $('.ccsestilo').css('background', '#FFFFE0');
                        

                            if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                                   $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                            else
                                   $('#MainContent_txtAcuenta').val('0.00');
                        F_CambioSerie();
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

function F_CambioSerie_TipoDoc2() {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc2").val()
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
                        //$('#MainContent_ddlSerieConsulta').val(61);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[4]);
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_Buscar();
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

function F_ValidaRucDni() {
if (!F_SesionRedireccionar(AppSession)) return false;
  
    if ($('#MainContent_txtNroRuc').val().length > 0)
    {
        if ($('#MainContent_txtNroRuc').val().trim() === $('#hfNroRuc').val().trim() & 
            $('#MainContent_txtCliente').val().trim() === $('#hfCliente').val().trim() & 
            $('#MainContent_txtNroRuc').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRuc').val();
    $('#hfCodCtaCte').val('0');
    

    if ($('#MainContent_txtNroRuc').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRuc').val()) | !ValidarRuc($('#MainContent_txtNroRuc').val()))
        {
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroRuc').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCte').val() != '0') 
            return true;

        $('#MainContent_txtCliente').val('');
        $('#hfCliente').val('');

        //DNI
        if ($('#MainContent_txtNroRuc').val().length == 8)
        {
            if ($('#MainContent_ddlTipoDoc').val() === '1') {
                $('#MainContent_txtNroRuc').val('');
                $('#MainContent_txtNroRuc').focus();
                return true;
            }

            var NroRuc = $('#MainContent_txtNroRuc').val();
            F_BuscarDatosPorRucDni($('#MainContent_txtNroRuc').val());
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRuc').val().length == 11 & $('#MainContent_txtNroRuc').val() != '55555555555')
            {
                $('#MainContent_txtCliente').focus();
                F_BuscarPadronSunat();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRuc').val() == '1')
                {
                    $('#MainContent_txtNroRuc').val('11111111');
                    $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());
                    F_BuscarDatosPorRucDni('11111111');
                    return true;
                }
                else
                {
//                    if ( Index ==-1 ) {} else {
                    alertify.log('NRO. RUC/DNI INVALIDO'); 
                    $('#MainContent_txtNroRuc').val('');
                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').focus();
//                    }
                    return true;
                }
            }
        }
    }
    else
    {
        if ($('#MainContent_txtNroRuc').val() != $('#hfNroRuc').val())
        {
            F_LimpiarCampos();
            return true;
        }
    }
   return false;
}
var API = ""
var ubigeo="";
var ConsultandoPadron = false;
function F_BuscarPadronSunat() {

    if (ConsultandoPadron == true)
        return true;

    ConsultandoPadron = true;

        $('#td_loading').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRuc').val();
        F_LimpiarCampos();
        $('#MainContent_txtNroRuc').val(NroRuc);
         if (API == "") {
         $('#hfCodDepartamento').val("");
         $('#hfCodProvincia').val("");
         $('#hfCodDistrito').val("");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat_Alvarado',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRuc').val() +"','CodTipoCtaCte':'1'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                ConsultandoPadron = false;
                var data = dbObject.d;
                try {
                // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    $('#td_loading').css('display', 'none');
                    $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                    $('#hfCliente').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                    $('#hfNroRuc').val(data[0].split(',')[8]);
                    $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                    $('#hfCliente').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                    $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                    $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                    $('#hfCodDireccion').val('0');
                    $('#hfCodDepartamento').val(data[0].split(',')[5]);
                    $('#hfCodProvincia').val(data[0].split(',')[6]);
                    $('#hfCodDistrito').val(data[0].split(',')[7]);
                    $('#hfDistrito').val(data[0].split(',')[4]);
                    $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
                    $('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));
                    $('#hfCodDireccionDefecto').val(data[0].split(',')[14]);
                    $('#MainContent_lblD1').text(data[0].split(',')[17]);
                    $('#MainContent_lblD2').text(data[0].split(',')[18]);
                    $('#MainContent_lblD3').text(data[0].split(',')[19]);

                    $('#MainContent_lblD1Articulo').text(data[0].split(',')[17]);
                    $('#MainContent_lblD2Articulo').text(data[0].split(',')[18]);
                    $('#MainContent_lblD3Articulo').text(data[0].split(',')[19]);

                    if ($('#MainContent_txtCliente').val().trim().length > 0 & $('#hfCodDepartamento').val() === "0")
                    { alertify.error('ESPECIFIQUE LA DIRECCION Y DISTRITO, PORQUE SUNAT NO ESTA PROVEYENDO ESTA INFORMACION'); }

                    F_BuscarDireccionesCliente();
                    //F_BuscarDireccionPorDefecto();
                    }else{
                     API = "Usuario No Encontrado";
                        console.log(API);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunat();
                       
                    }
                }
                catch (x) { 
                    //alertify.log(x);
                    alertify.log('Por alguna razon el cliente no fue encontrado');
                    $('#td_loading').css('display', 'none');
                }
            },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
 }; 
  if (API == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRuc').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                API = "";
                $('#td_loading').css('display', 'none');
                    $('#MainContent_txtCliente').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercial').val(dbObject.razonSocial); //razon social
                    ubigeo=dbObject.ubigeo;
                    if (ubigeo==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccion').val(direccion.replace(distrito, ""));
                     $('#MainContent_txtDestino').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistrito').val(distrito);
                    $('#hfDistrito').val(distrito);
//                    $('#hfUbigeo').val(dbObject.ubigeo);
                    $('#hfNroRuc').val(dbObject.ruc);
                    $('#hfCliente').val(dbObject.razonSocial);
                    F_BuscarDireccionNuevo();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                 if(response.responseText!=''){
                alertify.log(response.responseText);
                }else{
                alertify.log('Verificar conexión');
                $('#td_loading').css('display', 'none');
                }

            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });
    }


return true;
}

var ConsultandoCliente = false;
function F_BuscarDatosPorRucDni(RucDni) {

    if (ConsultandoCliente == true)
        return true;

    ConsultandoCliente = true;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarClientesPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                ConsultandoCliente = false;
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                            $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                            $('#hfCliente').val($('#MainContent_txtCliente').val()); //razon social
                            $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                            $('#hfNroRuc').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                            $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                            $('#hfCodDireccion').val('0');
                            $('#hfCodDepartamento').val(data[0].split(',')[5]);
                            $('#hfCodProvincia').val(data[0].split(',')[6]);
                            $('#hfCodDistrito').val(data[0].split(',')[7]);
                            $('#hfDistrito').val(data[0].split(',')[4]);
                            
                            try { 
                            $('#txtSaldoCreditoFavor').text(data[0].split(',')[9]);
                            $('#hfSaldoCreditoFavor').val(data[0].split(',')[9].replace("S/", "").replace(" ", ""));} 
                            catch (e) { 
                            $('#txtSaldoCreditoFavor').text("0.00");
                            $('#hfSaldoCreditoFavor').val("0.00"); }
                            
                            
                            if ($('#MainContent_txtNroRuc').val() === '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                            }
                            F_BuscarDireccionPorDefecto(); 
                            return true;
                    }
                    catch (x) { alertify.log(x); }
                }
                else
                {
                    var NroRuc = $('#MainContent_txtNroRuc').val();
//                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').val(NroRuc);
                    if ($('#MainContent_txtNroRuc').val().length == 8)
                    {
                            $("#hfCodCtaCte").val('0');
                            if ($('#MainContent_txtNroRuc').val() != '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                                $('#MainContent_txtCliente').val('---NUEVO CLIENTE---');
                                }
                            $('#MainContent_txtCliente').select();
                    }
                    return true;
                }
            },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });



return true;
}

function F_LimpiarCampos() {
if (!F_SesionRedireccionar(AppSession)) return false;
    //Tipo de CtaCte a filtrar
    $('#hfCodTipoCliente').val('0')
    $('#MainContent_txtCliente').prop('readonly', true);
    //Valores por Defecto
    $('#hfCodCtaCte').val('0');
    $('#hfCodDireccion').val('0');
    $('#MainContent_txtNroRuc').val('');
    $('#hfNroRuc').val('');
    $('#MainContent_txtCliente').val('');
    $('#hfCliente').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtDistrito').val('');
    $('#hfCodDepartamento').val('0');
    $('#hfCodProvincia').val('0');
    $('#hfCodDistrito').val('0');
    $('#hfDistrito').val('');
    $('#hfDireccion').val('');
    $('#MainContent_ddlMoneda').val(1);
    $('#MainContent_txtCorreo').val('');
    $('#MainContent_txtNroOperacion').val('');
    $('#MainContent_txtCelular').val('');
    $('#MainContent_txtGratuito').val('0.00');
    $('#MainContent_txtTotal').val('0.00');
    $('#MainContent_txtSubTotal').val('0.00');
    $('#MainContent_txtIgv').val('0.00');
}

function F_LimpiarCamposCliente() {
if (!F_SesionRedireccionar(AppSession)) return false;
    //Tipo de CtaCte a filtrar
    $('#hfCodTipoCliente').val('0')

    //Valores por Defecto
    $('#hfCodCtaCte').val('0');
    $('#hfCodDireccion').val('0');
    $('#MainContent_txtNroRuc').val('');
    $('#hfNroRuc').val('');
    $('#MainContent_txtCliente').val('');
    $('#hfCliente').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtDistrito').val('');
    $('#hfCodDepartamento').val('0');
    $('#hfCodProvincia').val('0');
    $('#hfCodDistrito').val('0');
    $('#hfDistrito').val('');
    $('#hfDireccion').val('');
    $('#hfFlagRuc').val('0');
    $('#MainContent_txtCorreo').val('');
    $('#MainContent_txtNroOperacion').val('');
    $('#MainContent_txtCelular').val('');

    $('#txtSaldoCreditoFavor').text("0.00");
    $('#hfSaldoCreditoFavor').val("0.00");

}

function F_CambioSerie()
{
            F_Mostrar_CorrelativoVarios(15);

}

function F_Controles_Inicializar() {
    F_Inicializar_Parametros();

    if (P_UNIDADES_ENTEROS == "1")
        $('#MainContent_txtCantidad').ForceNumericOnly();

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: 15,
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
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        F_Update_Division_HTML('div_formapago', result.split('~')[3]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[4]);
                        $('#MainContent_lblTC').text(result.split('~')[5]);
                        $('#MainContent_txtNumero').val(result.split('~')[6]);
                        F_Update_Division_HTML('div_igv', result.split('~')[7]);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[8]);
                        $('#hfCodUsuario').val(result.split('~')[9]);
                        $('#hfCodSede').val(result.split('~')[10]);
                        F_Update_Division_HTML('div_Estado', result.split('~')[11]);
                        GridDetalleFTInicializado = result.split('~')[12];
                        F_Update_Division_HTML('div_Vendedor', result.split('~')[14]);
                        F_Update_Division_HTML('div_EmpleadoConsulta', result.split('~')[16]);
                        GridArticulosInicializado = result.split('~')[15];
                        F_Update_Division_HTML('div_Gratuito', result.split('~')[17]);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlFormaPago').val(1);
                        $('#MainContent_ddlVendedor').val(result.split('~')[13]);
                        $('#MainContent_ddlEmpleadoConsulta').val(result.split('~')[13]);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlVendedor').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpleadoConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlGratuito').css('background', '#FFFFE0');
                        $('#MainContent_txtObservacion').css('background', '#FFFFE0');
                        $('#MainContent_txtExclusivo').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        //$("#MainContent_ddlAlmacenesExternos").css('background', '#FFFFE0');
                        /*$("#MainContent_chkPedido").css('margin-left', '0px');
                        $('label[for=MainContent_chkPedido]').css("margin-right","1px");*/

                        $("#MainContent_txtCantidad173").css('background', '#FFFFE0');
                        $("#MainContent_txtCantidad250").css('background', '#FFFFE0');
                        $("#MainContent_txtCantidadABC").css('background', '#FFFFE0');                        
                        $("#MainContent_txtCantidad250").css('margin-left', '8px');
                        $("#CamposPedido").find('input').not("#MainContent_btnAgregarPedido").css('background', '#FFFFE0');                        
                        $("#hfIdAlmacen").val(result.split('~')[18]);

                        $("#MainContent_txtObservacionAnulacion").css('background', '#FFFFE0');     



                        F_Nuevo();
                        F_ListarAlmacenesExternos();
                        F_Inicializar_Tabla_Almacenes_Stocks();
                        F_VerificarUsuarioIniciado_PermisoCambioPrecios();                        
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }

                    $('#toolbar-options').toolbar({
                    	content: '#toolbar-options',
                    	position: 'bottom'
                    });
                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);
    }
}

function F_Inicializar_Parametros() {
    P_CodMoneda_Inicial = "1";
    P_CodMoneda_LineaCredito_Inicial = "1";
    P_CantidadPlacas = "1";
    P_VALIDASTOCK = "1";
    P_VALIDASTOCK_MONTO_MINIMO = "0"; 
    P_UNIDADES_ENTEROS = "1";
        
var Parametros = F_ParametrosPagina('', CodigoMenu, CodigoInterno);
$.each(Parametros, function (index, item) {

    switch(item.Parametro) {
        case "P_CODMONEDA" :
            P_CodMoneda_Inicial = item.Valor;
            break;
        case "P_CODMONEDA_LINEACREDITO" :
            P_CodMoneda_LineaCredito_Inicial = item.Valor;
            break;
        case "P_CANTIDADPLACAS" :
            P_CantidadPlacas = item.Valor;
            break;

        case "P_VALIDASTOCK" :
            P_VALIDASTOCK = item.Valor;
            break;
        case "P_VALIDASTOCK_MONTO_MINIMO" :
            P_VALIDASTOCK_MONTO_MINIMO = item.Valor;
            break;
        case "P_UNIDADES_ENTEROS" :
            P_UNIDADES_ENTEROS = item.Valor;
            break;

    };

});


return true;
}

function F_Mostrar_Correlativo(CodDoc) {

    var arg;

    try {
        var SerieDoc = '';
            SerieDoc=$("#MainContent_ddlSerie option:selected").text();

        var objParams = {
                        Filtro_CodDoc: CodDoc,
                        Filtro_SerieDoc: SerieDoc
                            };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        F_Mostrar_Correlativo_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion == "1") 
                        $('#MainContent_txtNumero').val(result.split('~')[2]);
                    else 
                        alertify.log(str_mensaje_operacion);
                   

                        if (CargandoFormulario == false) {
                            sleep(5000);
                            $('#div_NumeroDocumento').dialog('close');
                         }
                         CargandoFormulario = false;

                   
                    return false ;
                
                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Mostrar_CorrelativoVarios(CodDoc) {



    var arg;

    try {
        var SerieDoc = $("#MainContent_ddlSerie option:selected").text();

        var objParams = {
            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: SerieDoc
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

                    if (str_resultado_operacion == "1") {
                        if($('#hfCodFacturaAnterior').val() != '0')
                        {
                            $('#MainContent_txtNumero').val($('#hfNumeroAnterior').val());
                            return false;
                        }
                            $('#MainContent_txtNumero').val(result.split('~')[2]);
                        }
                    else {
                        alertify.log(str_mensaje_operacion);
                        }
                    return false ;
                
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
    var chkNotaPedido = 0;
    var chkServicio = 0;
    try {
        if ($('#MainContent_chkServicios').is(':checked'))
            chkServicio = 1;

        if ($('#MainContent_chkNotaPedido').is(':checked'))
            chkNotaPedido = 1;
        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Servicio: chkServicio,
                Filtro_NotaPedido: chkNotaPedido,
                Filtro_Cliente:$('#hfCodCtaCte').val()
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

                        if (str_mensaje_operacion != '')
                            alertify.log(str_mensaje_operacion);
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

        if ($("#MainContent_chkServicios").is(':checked')) 
            return false;

    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidad', 'chkOK');
    lblstock = txtcantidad_Grilla.replace('txtCantidad', 'lblstock');

    if ($(txtcantidad_Grilla).val() == '')
        return false;

    boolEstado = $(chkok_grilla).is(':checked');

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if (boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            alertify.log("STOCK INSUFICIENTE");
            $(txtcantidad_Grilla).val('');
            $(chkok_grilla).prop('checked', false);
            return false;
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text()) & $('#MainContent_ddlTipoDoc').val() != '15') {
            alertify.log("STOCK INSUFICIENTE");
            if (parseFloat($(lblstock).text()) == 0) {
                $(txtcantidad_Grilla).val('');
                $(chkok_grilla).prop('checked', false);
            }
            return false;
        }
    }

    if (!F_ValidarAgregar())
        return false;

    F_AgregarTemporal();
    return false;
}

function F_AgregarArticuloGrilla(ControlID) {

        if ($("#MainContent_chkServicios").is(':checked')) 
            return false;

    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidad', 'chkOK');
    lblstock = txtcantidad_Grilla.replace('txtCantidad', 'lblstock');

    if ($(txtcantidad_Grilla).val() == '')
        return false;

    boolEstado = $(chkok_grilla).is(':checked');

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if (boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            alertify.log("STOCK INSUFICIENTE");
            $(txtcantidad_Grilla).val('');
            $(chkok_grilla).prop('checked', false);
            return false;
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && boolEstado && parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text()) & $('#MainContent_ddlTipoDoc').val() != '15') {
            alertify.log("STOCK INSUFICIENTE");
            if (parseFloat($(lblstock).text()) == 0) {
                $(txtcantidad_Grilla).val('');
                $(chkok_grilla).prop('checked', false);
            }
            return false;
        }
    }

    if (!F_ValidarAgregar())
        return false;

    F_AgregarTemporal();
    return false;
}

function F_ValidarDescuento(ControlID) {

        var txtDescuento = '#' + ControlID;
        var chkOK = txtDescuento.replace('txtDescuento', 'chkOK');
        var txtPrecio = txtDescuento.replace('txtDescuento', 'txtPrecio');

        if (!$(chkOK).is(':checked'))
            return false;

        if ($(txtDescuento).val() == "") {
            $(txtDescuento).val("");
            return false;
        }

        var hfDescuento = txtDescuento.replace('txtDescuento', 'hfDescuento');
        if (parseFloat($(txtDescuento).val()) > parseFloat($(hfDescuento).val())) {
            alertify.log("Descuento no permitido");
            $(txtDescuento).val("");
            return false;
        }
        var lblPrecioSoles = txtDescuento.replace('txtDescuento', 'lblPrecioSoles');
        var lblPrecioDolares = txtDescuento.replace('txtDescuento', 'lblPrecioDolares');
        var hfCodFamilia = txtDescuento.replace('txtDescuento', 'hfCodFamilia');
        var hfCostoProductoSoles = txtDescuento.replace('txtDescuento', 'hfCostoProductoSoles');
        var hfCostoProductoDolares = txtDescuento.replace('txtDescuento', 'hfCostoProductoDolares');
        var hfMargen = txtDescuento.replace('txtDescuento', 'hfMargen');

        var Descuento = 0;
        var Costo = 0;

        if ($('#MainContent_ddlMoneda').val() == 1) 
            Costo = $(hfCostoProductoSoles).val();
        else 
            Costo = $(hfCostoProductoDolares).val();

        Descuento =(parseFloat($(hfMargen).val()) - (parseFloat($(txtDescuento).val()) / 100))+1;
        Costo = (((Costo * Descuento) * 2).toFixed(0)) / 2;
        $(txtPrecio).val(Costo.toFixed(2));
      
        return true;
    }

function F_ValidarCheck(ControlID) {

        if ($("#MainContent_chkServicios").is(':checked')) 
            return false;

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var ddlprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';
    var cadena = 'Ingrese los sgtes. campos: '

    chkok_grilla = '#' + ControlID;
    txtprecio_grilla = chkok_grilla.replace('chkOK', 'txtPrecioLibre');
    ddlprecio_grilla = chkok_grilla.replace('chkOK', 'ddlPrecio');
    txtcant_grilla = chkok_grilla.replace('chkOK', 'txtCantidad');
    ddlLista_grilla = chkok_grilla.replace('chkOK', 'ddlLista');

    boolEstado = $(chkok_grilla).is(':checked');
    if (boolEstado) {
        $(txtcant_grilla).prop('disabled', false);
        $(txtprecio_grilla).prop('disabled', false);
        $(ddlprecio_grilla).prop('disabled', false);
        
        var i = 0;
        if ($(txtprecio_grilla).val() == "") {
            $(ddlprecio_grilla).focus();
            i = 1
        }

        if (i == 0 && $(txtcant_grilla).val() == "")
        { $(ddlprecio_grilla).focus(); }

        F_Consultar_Almacenes_Stocks(ControlID);
    }
    else {
        $(txtcant_grilla).val('');
        $(txtcant_grilla).prop('disabled', true);
        $(txtprecio_grilla).prop('disabled', true);
        $(ddlprecio_grilla).prop('disabled', true);
    }
    return false;
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
    lblexclusivo_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfexclusivo');
    
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
    $('#MainContent_txtCantidad').val(1);
    $("#MainContent_txtCantidad173").val(0);
    $("#MainContent_txtCantidad250").val(0);
    $("#MainContent_txtCantidadABC").val(0);
    $('#MainContent_txtPrecioDisplay').val($(hfPrecio1_grilla).val());
    $("#hfMenorPrecioAgregar").val(0);
    $('#MainContent_txtExclusivo').val($(lblexclusivo_grilla).val());

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

//    if ($(hfPrecio3_grilla).val() != '0.00') {
//        $("#MainContent_ddlPrecio").append($("<option></option>").val($(hfPrecio3_grilla).val()).html($(hfPrecio3_grilla).val()));

//        if (Number($(hfPrecio3_grilla).val()) < Number($("#hfMenorPrecioAgregar").val()) & Number($(hfPrecio3_grilla).val()) > 0)
//            $("#hfMenorPrecioAgregar").val($(hfPrecio3_grilla).val());
//        }

    $('#MainContent_chkServicios').prop('checked', false);

    F_VerUltimoPrecio_Buscar($('#MainContent_txtCodigoProductoAgregar').val(), $('#hfCodProductoAgregar').val());
    F_Consultar_Almacenes_Stocks(ControlID);
    if (DirectoBoton === 1)
        F_TablaClick(ControlID);


//        if ((parseFloat($('#MainContent_lblD1Articulo').text())+parseFloat($('#MainContent_lblD2Articulo').text())+parseFloat($('#MainContent_lblD3Articulo').text()))!=0){
//        var D1=parseFloat($('#MainContent_lblD1Articulo').text())
//        var D2=parseFloat($('#MainContent_lblD2Articulo').text())
//        var D3=parseFloat($('#MainContent_lblD3Articulo').text())
//        var EX =0

//         EX=$("#hfMenorPrecioAgregar").val()-($("#hfMenorPrecioAgregar").val()*(1-(1-D1/100)*(1-D2/100)*(1-D3/100)))
         
//         if ($("#MainContent_txtExclusivo").val()!="0.00"){
//          $("#MainContent_txtPrecioDisplay").val($(lblexclusivo_grilla).val());
//        }



    return false;
}

function F_FormaPago(CodFormaPago){ 
 var arg;
    try 
    {
             if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
             else
                    $('#MainContent_txtAcuenta').val('0.00');

     switch (CodFormaPago)
     {
            case "1":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "3":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),30));
                       break;
            case "4":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),15));
                       break;
            case "6":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "8":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),45));
                       break;
            case "9":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),60));
                       break;
            case "10":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "11":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),7));
                       break;
            case "12":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "13":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),75));
                       break;
            case "14":
               $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),90));
               break;
            case "15":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
     }
    }
     catch (mierror) 
     {
        alertify.log("Error detectado: " + mierror);
     }

}

var PermisoCambio = false;
var Permisoctrlsel = "";
function F_ValidarAgregar(ctrlsel){
    Permisoctrlsel = ctrlsel;
if ($("#MainContent_chkServicios").is(':checked'))
return true;

 try 
        {
        var chkSi='';
        var chkDel='';
        var txtcantidad_grilla='';
        var txtprecio_grilla='';
        var cadena = "Ingrese los sgtes. campos:  <p></p> ";
        var lblcodproducto_grilla='';
        var hfcodarticulodetalle_grilla='';
        var lbldscproducto_grilla='';
        var x=0;
        var PrecioFinal = 0;

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

        if ($("#MainContent_txtPrecioDisplay").val() == '')
            cadena = cadena + "CAMPO PRECIO ARTICULO <p></p> ";

        if (isNaN($("#MainContent_txtPrecioDisplay").val()))
        {
            $("#MainContent_txtPrecioDisplay").val('0.00');
            $("#MainContent_txtPrecioDisplay").focus();
            $("#MainContent_txtPrecioDisplay").select();
            cadena = cadena + "CAMPO PRECIO <p></p> ";
        }

        PrecioFinal = $("#hfMenorPrecioAgregar").val();

        if (parseFloat($("#MainContent_txtExclusivo").val())>0)
            PrecioFinal=$("#MainContent_txtExclusivo").val();

        // VALIDA EL PRECIO MINIMO COMENTADO POR ENZO EL 25/05/2022
//        if (UsuarioIniciado_PermisoCambioPrecios === '0') {
//            if (Number($("#MainContent_txtPrecioDisplay").val()) < Number(PrecioFinal) & 
//                    Number(PrecioFinal) > 0 & 
//                        PermisoCambio == false &
//                            F_VerificarTipoCliente() == false)
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

      if (F_PermisoOpcion_SinAviso(CodigoMenu, 4000103, '') == 0 & parseFloat($('#hfCostoAgregar').val())>parseFloat($('#MainContent_txtPrecioDisplay').val()))
             cadena = cadena + "COSTO POR DEBAJO DEL PRECIO <p></p> ";
        
        PermisoCambio = false;
                if (cadena != "Ingrese los sgtes. campos:  <p></p> ")
                   {
                      alertify.log(cadena);
                      return false;
                   } 
                   else
                   {
                    cadena="Los sgtes. productos se encuentran agregados : ";
//                    $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
//                    chkSi = '#' + this.id;
//                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
//               
//                         if ($(chkSi).is(':checked')) 
//                            {
                                 $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                                   chkDel = '#' + this.id;
                                   hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
                                   lbldscproducto_grilla = chkDel.replace('chkEliminar', 'lblproducto');
                                    
                                    if ($('#hfCodProductoAgregar').val()==$(hfcodarticulodetalle_grilla).val())
                                    {
                                        cadena= cadena + "\n"  + $('#MainContent_txtArticuloAgregar').val();
                                        F_TablaDown();
                                    }
                         
                                  });
//                            }
//                    });
                   }    
                                 
                   if (cadena != "Los sgtes. productos se encuentran agregados : ") 
                   {alertify.log(cadena);
                   return false;}
                   else
                   {
                   return true;
                   }
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

//False: debe de pedir permiso para el cambio de contraseña
//True: el tipo de cliente se le puede cambiar el precio sin permiso
function F_VerificarTipoCliente () {
    var Respuesta = false; //por defecto si no ha especificado cliente, se debe de pedir permiso para cambio de contraseña
    var rpt = 0;
if ($("#MainContent_txtNroRuc").val() != "") {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_ValidarClienteCambioPrecio',
        data: "{'NroRuc':'" + $('#MainContent_txtNroRuc').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.Resultado === 1)
                    Respuesta = true;
                    rpt = data.Resultado;
            }
            catch (x) { alertify.log('ERROR AL BUSCAR LA VALIDACION POR CLIENTE MAYORISTA/MINORISTA'); }
        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    }
return Respuesta;
}

var UsuarioIniciado_PermisoCambioPrecios = '0';

function F_VerificarUsuarioIniciado_PermisoCambioPrecios() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroCotizaciones.aspx/F_Usuario_ObtenerXCodUsuario_NET',
        data: "{'CodUsuario':'" + $('#hfCodUsuario').val() + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;



            try {

                if (data.MsgError === "") 
                {

                    //busco si el usuario con el cual metieron la clave
                    //tiene habilitado la FUNCION 777003 que es el AUTORIZAR PRECIO MINIMO
                    //OJO: es importante que saber que en COTIZACION: 777003, y FACTURACION: 777002
                    var TienePermiso = '0';
                    $.each(data.UsuariosPermisos, function (index, item) {
                        if (item.CodigoInterno === 777003 & item.CodigoMenu === 4000)
                            UsuarioIniciado_PermisoCambioPrecios = '1';
                    });
                }
            }
            catch (x) { alertify.log('ERROR AL CARGAR LOS MENUES'); }

        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });


return true;
}

function F_VerificarUsuario () {

    if ($("#MainContent_txtUsuarioPrecio").val().trim() === "" | $("#MainContent_txtContraseñaPrecio").val().trim() === "")
        return false;

                        if ($.trim($('#MainContent_txtObservacionPrecio').val()).length<10)
                {
                 toastr.warning("INGRESAR LA OBSERVACION (MINIMO 10 CARACTERES)");
                  return false;
                }

    $("#MainContent_txtUsuarioPrecio").prop('disabled', true);
    $("#MainContent_txtContraseñaPrecio").prop('disabled', true);
    $("#MainContent_btnVerificar").prop('disabled', true);
        
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroCotizaciones.aspx/F_Usuario_ObtenerXNombreUsuario_NET',
        data: "{'NombreUsuario':'" + $('#MainContent_txtUsuarioPrecio').val() + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $("#MainContent_txtUsuarioPrecio").prop('disabled', false);
                $("#MainContent_txtContraseñaPrecio").prop('disabled', false);
                $("#MainContent_btnVerificar").prop('disabled', false);

                if (data.MsgError === "") 
                {

                    //busco si el usuario con el cual metieron la clave
                    //tiene habilitado la FUNCION 777003 que es el AUTORIZAR PRECIO MINIMO
                    //OJO: es importante que saber que en COTIZACION: 777003, y FACTURACION: 777002
                    var TienePermiso = '0';
                    $.each(data.UsuariosPermisos, function (index, item) {
                        if (item.CodigoInterno === 777003 & item.CodigoMenu === 4000)
                            TienePermiso = '1';
                    });

                    if (TienePermiso === '1')
                    {
                        if (data.ClavePrecio.trim() === $("#MainContent_txtContraseñaPrecio").val().trim()) 
                        {
                            PermisoCambio = true;
                            if (FilaActualizarValidaPermiso != '') {
                                F_ActualizarPrecio(FilaActualizarValidaPermiso.replace('#', ''));
                                }
                            else
                                $('#MainContent_btnGrabar').click();
                        } else {
                            if (data.ClavePrecio.trim() === "")
                            {
                            if (FilaActualizarValidaPermiso != '')
                                $(FilaActualizarValidaPermiso).val(PrecioActualizarValidarPermiso);
                                alertify.log('NO POSEE CLAVE PARA CAMBIO DE PRECIO');   
                            }
                            else {
                            if (FilaActualizarValidaPermiso != '')
                                $(FilaActualizarValidaPermiso).val(PrecioActualizarValidarPermiso);
                                alertify.log('CLAVE INCORRECTA');  
                            }
                           
                        }
                    }
                    else
                    {
                        if (FilaActualizarValidaPermiso != '')
                            $(FilaActualizarValidaPermiso).val(PrecioActualizarValidarPermiso);
                        alertify.log('USUARIO SIN PERMISO PARA AUTORIZAR CAMBIOS DE PRECIOS');
                    }
                        $('#divClavePrecio').dialog('close');
                    } else {
                        if (FilaActualizarValidaPermiso != '')
                            $(FilaActualizarValidaPermiso).val(PrecioActualizarValidarPermiso);
                        alertify.log('USUARIO NO VALIDO')                
                    }
            }
            catch (x) { alertify.log('ERROR AL CARGAR LOS MENUES'); }
        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });


return true;
}

var AgregandoProducto = false;

function F_AgregarTemporalPedido(){
    if ($("#MainContent_txtCantidadABCPed").val() ==0 && $("#MainContent_txtCantidad173Ped").val()==0 && $("#MainContent_txtCantidad250Ped").val()==0){
        alertify.log("LAS TRES CANTIDADES NO PUEDEN SER 0 A LA VEZ");
        return false;
    }
    var arrDetalle = new Array();
    var objDetalle = {
       CodArticulo: $('#hfCodArticuloPedido').val(),
       CantidadABC: $("#MainContent_txtCantidadABCPed").val(),            
       Cantidad173: $("#MainContent_txtCantidad173Ped").val(),            
       Cantidad250: $("#MainContent_txtCantidad250Ped").val()

    };
    arrDetalle.push(objDetalle);
    var objParams = {
     Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
     Filtro_CodFacturaAnterior: $("#hfCodFacturaAnterior").val(),
     Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
     Filtro_FlagReemplazo:0
    };      

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
     AgregandoProducto = true;
     F_AgregarTemporalPedido_NET(arg, function (result) {
        AgregandoProducto = false;
        var str_resultado_operacion = result.split('~')[0];
        var str_mensaje_operacion = result.split('~')[2];

        if (str_resultado_operacion == "1") {
            $('#hfCodArticuloPedido').val('')
            $("#MainContent_txtCantidadABCPed").val('');
            $("#MainContent_txtCantidad173Ped").val('');
            $("#MainContent_txtCantidad250Ped").val('');
            $("#MainContent_txtArticuloPedido").val('');
            $("#MainContent_txtCantidadArticulo").val('');
            F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[4]); //Llenando grilla de pedidos
            $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
            $('.ccsestilo').css('background', '#FFFFE0');
            F_BloquearCantidadGrilla("grvDetallePedido");   
            alertify.log(str_mensaje_operacion);
            return false; 
        }else{
             alertify.log(result.split('~')[2]);
        }
        return false;
     });
}

function F_AgregarTemporal() {
    if (AgregandoProducto === true)
        return true;
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
        var lblProducto = "";
        var tasaigv = 1;
        var FlagIgv = 0;
        var precioex = 0 ;
        var Precio2 = 0;
            
        //agregado agutierrez
        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }    
        
        if (parseFloat($('#MainContent_txtExclusivo').val())!=0){
        Precio2=$('#MainContent_txtExclusivo').val();
        }else{
       // Precio2=$("#hfMenorPrecioAgregar").val();
       Precio2=0;
        }
        precioex =$('#MainContent_txtPrecioDisplay').val();
                
        //ctrlPosActual = chkSi; //asigno el control actual donde se volvera a posicionar
        var objDetalle = {
        CodArticulo: $('#hfCodProductoAgregar').val(),
        Cantidad: $('#MainContent_txtCantidad').val(),
        Precio: precioex/ tasaigv,
        PrecioDscto: precioex / tasaigv,
        Precio2: Precio2 / tasaigv,
        Costo: $('#hfCostoAgregar').val(),
        CodUm: $('#hfCodUmAgregar').val(),
        Descripcion: $('#MainContent_txtArticuloAgregar').val(),
        CodDetalle: 0,
        Acuenta: 0,        
        CodTipoDoc: 0,
        Filtro_FlagIgv: FlagIgv,
        Filtro_Flag: 0,
        Filtro_TasaIgv: tasaigv,
        Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
        CantidadABC: $("#MainContent_txtCantidadABC").val(),            
        Cantidad173: $("#MainContent_txtCantidad173").val(),            
        Cantidad250: $("#MainContent_txtCantidad250").val()
        };
        arrDetalle.push(objDetalle);


        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodTipoDoc: 1,
            Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
            Filtro_CodCliente: $(Contenedor + 'hfCodCtaCte').val(),
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
            Filtro_CodProforma: 0,
            Filtro_Igv: $(Contenedor + 'txtIgv').val(),
            Filtro_Total: $(Contenedor + 'txtTotal').val(),
            Filtro_CodGuia: 0,
            Filtro_Descuento: 0,
            Filtro_FlagIgv: FlagIgv,
            Filtro_TasaIgv: tasaigv,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),                        
            Filtro_Servicio: chkServicio,
            Filtro_NotaPedido: chkNotaPedido,
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodFacturaAnterior: $("#hfCodFacturaAnterior").val(),
            Filtro_FlagReemplazo:0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        //MostrarEspera(true);
        AgregandoProducto = true;
        F_AgregarTemporal_NET(arg, function (result) {
        AgregandoProducto = false;

            //MostrarEspera(false);

            var str_resultado_operacion = result.split('~')[0];
            var str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(result.split('~')[5]);
                $('#MainContent_txtIgv').val(result.split('~')[6]);
                $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15" | $('#MainContent_ddlFormaPago').val() == "10")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                
                F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[10]); //Llenando grilla de pedidos
               // $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
                $('.ccsestilo').css('background', '#FFFFE0');
                F_BloquearCantidadGrilla("grvDetallePedido");                
                F_LimpiarGrillaConsulta();                
                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito');
                $('#MainContent_chkDescripcion').focus();
                F_MostrarTotales();                
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
                $('#MainContent_txtExclusivo').val('');
                $('#MainContent_txtCantidadABC').val('');
                $('#MainContent_txtCantidad173').val('');
                $('#MainContent_txtCantidad250').val('');
                $("#hfMenorPrecioAgregar").val(0);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                F_TablaDown(); 
                F_ValidarPrecioMinimoRojo();
                return false;
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

function F_AgregarTemporalServicio() {
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
        var lblProducto = "";
        var tasaigv = 1;
        var FlagIgv = 0;
   
        var Agregado = false;     
        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
        chkDel = '#' + this.id;
        hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
        lbldscproducto_grilla = chkDel.replace('chkEliminar', 'txtDescripcion');
                                    
            if ($(lbldscproducto_grilla).val().toUpperCase()==$("#MainContent_txtArticuloAgregar").val().toUpperCase())
                Agregado = true;
                         
        });

        if (Agregado == true)
        {
            alertify.log('EL PRODUCTO YA SE ENCUENTRA AGREGADO');
            $("#MainContent_txtArticuloAgregar").focus();
            return false;
        }

        if (isNaN($("#MainContent_txtCantidad").val()) == true)
        {
            alertify.log('CANTIDAD NO VALIDA');
            $("#MainContent_txtCantidad").val('1');
            $("#MainContent_txtCantidad").focus();
            return false;
        } 
        if (isNaN($("#MainContent_txtPrecioDisplay").val()) == true)
        {
            alertify.log('PRECIO NO VALIDO');
            $("#MainContent_txtPrecioDisplay").val('0.00');
            $("#MainContent_txtPrecioDisplay").focus();
            return false;        
        } 
        if (Number($("#MainContent_txtCantidad").val()) <= 0)
        {
            alertify.log('CANTIDAD NO VALIDA');
            $("#MainContent_txtCantidad").val('1');
            $("#MainContent_txtCantidad").focus();
            return false;
        } 
        if (Number($("#MainContent_txtPrecioDisplay").val()) <= 0)
        {
            alertify.log('PRECIO NO VALIDO');
            $("#MainContent_txtPrecioDisplay").val('1');
            $("#MainContent_txtPrecioDisplay").focus();
            return false;        
        } 


        //agregado agutierrez
        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }            

        var objDetalle = {
        CodArticulo: '',
        Cantidad: $("#MainContent_txtCantidad").val(),
        Precio: $("#MainContent_txtPrecioDisplay").val() / tasaigv,
        PrecioDscto: $("#MainContent_txtPrecioDisplay").val() / tasaigv,
        Precio2: 0,
        Costo: 0,
        CodUm: 22,
        Descripcion: $("#MainContent_txtArticuloAgregar").val().toUpperCase(),
        CodDetalle: 0,
        Acuenta: 0,
        CodTipoDoc: 0,
        Filtro_FlagIgv: FlagIgv,
        Filtro_Flag: 0,
        Filtro_TasaIgv: tasaigv,
        Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1)   ,
         CantidadABC: 0,            
        Cantidad173: 0,            
        Cantidad250: 0
        };
        arrDetalle.push(objDetalle);

        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodTipoDoc: 1,
            Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
            Filtro_CodCliente: $(Contenedor + 'hfCodCtaCte').val(),
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
            Filtro_CodProforma: 0,
            Filtro_Igv: $(Contenedor + 'txtIgv').val(),
            Filtro_Total: $(Contenedor + 'txtTotal').val(),
            Filtro_CodGuia: 0,
            Filtro_Descuento: 0,
            Filtro_FlagIgv: FlagIgv,
            Filtro_TasaIgv: tasaigv,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_Servicio: chkServicio,
            Filtro_NotaPedido: chkNotaPedido,
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        //MostrarEspera(true);

        F_AgregarTemporal_NET(arg, function (result) {

            //MostrarEspera(false);

            var str_resultado_operacion = result.split('~')[0];
            var str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(result.split('~')[5]);
                $('#MainContent_txtIgv').val(result.split('~')[6]);
                $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));

                if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);               
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));                
                $('.ccsestilo').css('background', '#FFFFE0');
                F_LimpiarGrillaConsulta();
                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito');

                if ($("#MainContent_chkTransferenciaGratuita").is(':checked')) {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                }
                else
                    F_MostrarTotales();

                $('#hfCodProductoAgregar').val('0');
                $('#hfCostoAgregar').val('0');
                $('#hfCodUmAgregar').val('0');
                $('#MainContent_txtCodigoProductoAgregar').val('');
                $('#MainContent_txtStockAgregar').val('');
                $('#MainContent_txtUMAgregar').val('');
                $('#MainContent_txtPrecioDisplay').val('0.00');
                $('#MainContent_ddlPrecio').empty();
                $('#MainContent_txtArticuloAgregar').val('');
                $('#MainContent_txtCantidad').val('1');
                $('#MainContent_txtArticuloAgregar').focus();
                $("#hfMenorPrecioAgregar").val(0);
                //$('#MainContent_txtArticulo').focus();

                return false;
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

function F_LimpiarGrillaConsulta() {
    $('#MainContent_grvConsultaArticulo').empty();
    F_Update_Division_HTML('div_grvConsultaArticulo', GridArticulosInicializado);                            
    $('.ccsestilo').css('background', '#FFFFE0');  
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_txtArticulo').focus();
return false;
}

function F_MostrarTotales() {
    var lblimporte = '';
    var hfCodGratuito = '';
    var chkDel = '';
    var Total = 0;
    var Igv = 0;
    var Subtotal = 0;
    var Gratuito = 0;
    var Cuerpo = '#MainContent_';
    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
        chkDel = '#' + this.id;
        lblimporte = chkDel.replace('chkEliminar', 'lblimporte');
        hfCodGratuito = chkDel.replace('chkEliminar', 'hfCodGratuito');
        Total += parseFloat($(lblimporte).text());
    });

    if(isNaN(Total))
      Total = 0;



    if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
        $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
        $(Cuerpo + 'txtIgv').val((Total / (1 + parseFloat($("#MainContent_ddlIgv option:selected").text())) * parseFloat($("#MainContent_ddlIgv option:selected").text())).toFixed(2));
        $(Cuerpo + 'txtSubTotal').val((Total / (1 + parseFloat($("#MainContent_ddlIgv option:selected").text()))).toFixed(2));
    }
    else {
        $(Cuerpo + 'txtTotal').val((Total * (1 + parseFloat($("#MainContent_ddlIgv option:selected").text()))).toFixed(2));
        $(Cuerpo + 'txtIgv').val((Total * parseFloat($("#MainContent_ddlIgv option:selected").text())).toFixed(2));
        $(Cuerpo + 'txtSubTotal').val(Total.toFixed(2));
    }

     if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "5" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "10" |  $('#MainContent_ddlFormaPago').val() == "15")
         $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
}

function F_EliminarTemporal() {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacEliminar
    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var hfCodDetalle  = '';
        var tasaigv = 1;
        var FlagIgv = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodDetalle = chkSi.replace('chkEliminar', 'hfCodDetalle');
            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodDetalle: $(hfCodDetalle).val()
                };
                arrDetalle.push(objDetalle);
            }
        });

        var Contenedor = '#MainContent_';

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }      

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodFacturaAnterior: $("#hfCodFacturaAnterior").val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_FlagIgv: FlagIgv,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
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
                    $('#MainContent_txtAcuentaNV').val('0.00');
                    $('#MainContent_txtAcuenta').val('0.00');
                    $('#MainContent_chkConIgvMaestro').prop('disabled',false);
                    $('#MainContent_chkSinIgvMaestro').prop('disabled',false);
                }
                else {
                    $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                    $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                    $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                    $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                }

                if ($('#MainContent_ddlFormaPago').val() == 1 | $('#MainContent_ddlFormaPago').val() == 6 | $('#MainContent_ddlFormaPago').val() == 15)
                    $('#MainContent_txtAcuenta').val(parseFloat(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val())).toFixed(2));
                else
                    $('#MainContent_txtAcuenta').val('0.00');

                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[10]); //Llenando grilla de pedidos
                $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos

                $('.ccsestilo').css('background', '#FFFFE0');
                if ($("#MainContent_chkTransferenciaGratuita").is(':checked')) {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                }
                else
                    F_MostrarTotales();
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

function F_EliminarTemporalPedido() {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacEliminar
    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var hfCodPedido  = '';
        var tasaigv = 1;
        var FlagIgv = 0;

        $('#MainContent_grvDetallePedido .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodPedido = chkSi.replace('chkEliminar', 'hfCodPedido');
            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodPedido: $(hfCodPedido).val()
                };
                arrDetalle.push(objDetalle);
            }
        });

        var Contenedor = '#MainContent_';        

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),            
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_CodFacturaAnterior: $("#hfCodFacturaAnterior").val(),
            Filtro_FlagReemplazo:0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
         F_EliminarTemporalPedido_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);                
                F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[4]); //Llenando grilla de pedidos
                $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
                $('.ccsestilo').css('background', '#FFFFE0');
                F_BloquearCantidadGrilla("grvDetallePedido");
                if (result.split('~')[2] == 'Se han eliminado los productos del pedido correctamente.')
                    alertify.log(result.split('~')[2]);
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

function F_ValidarEliminarPedido() {

    try {
        var chkSi = '';
        var x = 0;

        $('#MainContent_grvDetallePedido .chkDelete :checkbox').each(function () {
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

function F_ValidarGrabarDocumento(){
    try 
        {        
            var Cuerpo='#MainContent_';
            var Cadena = 'Ingresar los sgtes. Datos:'; 
            var txtPrecio = '';
            var hfP1 = '';
            var chkDel = '';
            var C=0;

             if ($(Cuerpo + 'txtCliente').val()=='' && $('#hfCodCtaCte').val()==0 && $("#MainContent_ddlTipoDoc").val() == 1)
                    Cadena=Cadena + '<p></p>' + 'Cliente';
        
             if ($(Cuerpo + 'lblTC').text()=='0')
                    Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

             if ($(Cuerpo + 'ddlVendedor').text()==null)
                    Cadena=Cadena + '<p></p>' + 'El Usuario No es Vendedor';

             if ($(Cuerpo + 'ddlVendedor').val()==null)
                    Cadena=Cadena + '<p></p>' + 'Vendedor';
                    
             if ($(Cuerpo + 'txtEmision').val()=='' & $("#MainContent_ddlTipoDoc").val() != '5')
                    Cadena=Cadena + '<p></p>' + 'Fecha de Emision';            

             if (!ValidarRuc($(Cuerpo + 'txtNroRuc').val()) & $(Cuerpo + 'txtNroRuc').val() != '55555555555')
                    Cadena = Cadena + "<p></p>" + "Ruc Invalido"; 
         
             if ($('#hfCodCtaCte').val()==0 && $('#hfCodDistrito').val()==0)
                    Cadena=Cadena + '<p></p>' + 'Distrito';

             if ($('#hfCodCtaCte').val()==0 && $(Cuerpo + 'txtDireccion').val()=='')
                    Cadena=Cadena + '<p></p>' + 'Direccion';
         
             if ($(Cuerpo + 'txtTotal').val()=='0.00')
                    Cadena=Cadena + '<p></p>' + 'No ha ingresado ningun producto';
                    
             if (!F_ValidarCorreo($(Cuerpo + 'txtCorreo').val()))
                    Cadena = Cadena + '<p></p>' + 'Correo';

             if (Cadena != 'Ingresar los sgtes. Datos:')
             {   
                 alertify.log(Cadena.toUpperCase());
                 return false;
             }   
             else
             {
                      
                     if (F_ValidarPrecioRecorrido()==0)
                     return true;
             }

     
        }        
    catch (e) 
        {
            alertify.log("Error Detectado: " + e);
            return false;
        }
}

function F_GrabarDocumento(){
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
  try 
        {
        var FlagIgv='1';
        var FlagCodigo='0';
        var Contenedor = '#MainContent_';
        var Index= $('#MainContent_txtCliente').val().indexOf('-');
        var Cliente = $('#MainContent_txtCliente').val();
        if ( Index ==-1 ) {} else {
            if ($("#MainContent_txtCliente").val() != '---NUEVO CLIENTE---') {
//                Cliente=Cliente.substr(Cliente.length - (Cliente.length -(Index+2)));
                }
            }
        var RazonSocial = Cliente;
        var CodTipoCliente = 0;
        var NroDni = '';
        var NroRuc = '';
        var Serie =  $("#MainContent_ddlSerie option:selected").text();
        var Numero = $(Contenedor + 'txtNumero').val();
        var UsuarioPermiso = '';
        var ClavePermiso = '';
        var ObservacionPermiso='';

        if (ContadorPrecioMinimo==0 && PermisoCambio == true)
        {
                UsuarioPermiso =     $("#MainContent_txtUsuarioPrecio").val();
                ClavePermiso =       $("#MainContent_txtContraseñaPrecio").val();
                ObservacionPermiso = $("#MainContent_txtObservacionPrecio").val();
        }

        if ($(Contenedor + 'chkSinIgvMaestro').prop('checked') === true)
                FlagIgv='0';

                 if ($(Contenedor + 'ChkCodigo').prop('checked') === true)
                FlagCodigo='1';

        if ($(Contenedor + 'ddlFormaPago').val()==12)
                FlagLetra='1';

        NroDni = $('#MainContent_txtNroRuc').val();
        NroRuc = $('#MainContent_txtNroRuc').val();

        if (NroDni.length == 11)
            NroDni = '';

        if (NroRuc.length == 8)
            NroRuc = '';

        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        var flagCSIgv = 0; if ($('#MainContent_chkConIgvMaestro').is(':checked')) {flagCSIgv = 1; };
        var FlagComisionable = 0; if ($('#MainContent_chkComisionable').is(':checked')) {FlagComisionable = 1; };

        var objParams = {
            Filtro_CodTipoDoc: 15,
            Filtro_SerieDoc: $('#MainContent_ddlSerie option:selected').text(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),

            Filtro_CodCliente: $('#hfCodCtaCte').val(),
            //Filtro_CodEstado: 6,
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_Codigo:FlagCodigo,
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
            Filtro_Igv: $(Contenedor + 'txtIgv').val(),
            Filtro_Total: $(Contenedor + 'txtTotal').val(),
            Filtro_Gratuito: 0,                            
            Filtro_CodProforma: $('#hfCodProforma').val(),
            Filtro_CodGuia: "0",
            Filtro_Descuento: "0",

            Filtro_FlagGuia:0,
            Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),
            Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
            Filtro_FechaTraslado: $(Contenedor + 'txtEmision').val(),
            Filtro_Destino: $(Contenedor + 'txtDestino').val(),

            Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
            Filtro_TasaIgv: tasaigv,

            Filtro_NotaPedido: 0,
            Filtro_CodSerie: $(Contenedor + 'ddlSerie').val(),
            Filtro_Cliente: Cliente,
            Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
            Filtro_CodTipoOperacion: 1,
            Filtro_CodTipoCliente:  CodTipoCliente,
            Filtro_CodClaseCliente: 2,
            Filtro_CodTransportista: $('#hfCodTransportista').val(),
            Filtro_CodDepartamento: $('#hfCodDepartamento').val(),
            Filtro_CodProvincia: $('#hfCodProvincia').val(),
            Filtro_CodDistrito: $('#hfCodDistrito').val(),
            Filtro_ApePaterno: '',
            Filtro_ApeMaterno: '',
            Filtro_Nombres: '',
            Filtro_RazonSocial: RazonSocial,
            Filtro_NroDni: NroDni, 
            Filtro_NroRuc: NroRuc, 
            Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
                                        
            Filtro_Acuenta: $(Contenedor + 'txtAcuenta').val(),
            Filtro_AcuentaNV: $(Contenedor + 'txtAcuentaNV').val(),
            //Filtro_FlagNV: FlagNV,
            Filtro_FlagCSIgv: flagCSIgv,
            Filtro_CodDireccion: $('#hfCodDireccion').val(),
            Filtro_Observacion:$(Contenedor + 'txtObservacion').val(),

            Filtro_Transportista: $(Contenedor + 'txtTransportista').val(),
            Filtro_Marca: $(Contenedor + 'txtMarcaGuia').val(),
            Filtro_Licencia: $(Contenedor + 'txtLicenciaGuia').val(),
            Filtro_NuBultos: $(Contenedor + 'txtNuBultos').val(),
            Filtro_Peso: $(Contenedor + 'txtPeso').val(),
            Filtro_CodDireccionTransportista: $('#hfCodDireccionTransportista').val(),
            Filtro_DireccionTrans: $('#MainContent_txtDireccionTransportista').val(),
            Filtro_FlagIgv: FlagIgv,
            Filtro_Placa:$(Contenedor + 'txtPlaca').val(),
            Filtro_KM:$(Contenedor + 'txtKM').val(),
            Filtro_PlacaTraslado:$(Contenedor + 'txtPlacaTraslado').val(),
            Filtro_SerieOC: '',
            Filtro_NumeroOC: '',
            Filtro_Partida:$('#hfPartida').val(),
            Filtro_CodNotaVenta: $('#hfCodNotaVenta').val(),
            Filtro_DireccionCompleta:  $(Contenedor + 'txtDireccion').val() + ' ' + $(Contenedor + 'txtDistrito').val() ,
            Filtro_FlagRetencion:0,
            Filtro_FlagLetra:0,
            Filtro_Atencion: $(Contenedor + 'txtAtencion').val(),
            Filtro_Referencia: '',
            Filtro_CodTraslado: 0,
            Filtro_CodFacturaAnterior: $('#hfCodFacturaAnterior').val(),
            Filtro_Correo: $('#MainContent_txtCorreo').val(),
            Filtro_Celular: $('#MainContent_txtCelular').val(),
            Filtro_NroOperacion: $('#MainContent_txtNroOperacion').val(),
            Filtro_CodVendedor: $('#MainContent_ddlVendedor').val(),
            Filtro_FlagComisionable: FlagComisionable,
            Filtro_UsuarioPermiso: UsuarioPermiso,
            Filtro_ClavePermiso: ClavePermiso,
            Filtro_ObservacionPermiso: ObservacionPermiso
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
                        alertify.log('Se Grabo Correctamente');                        
                        //F_ImprimirCotizacion_Despacho(result.split('~')[2]);                       
                        F_MostrarNumero(result.split('~')[3]);
                        F_Nuevo();                   
                    }
                    else
                    {
                        alertify.log(result.split('~')[1]);
                        return false;                    
                    }                  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                    return false;
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
            F_LimpiarCampos();
            ValorModificacion=0;
            $('#MainContent_ddlTipoImpresion').val('IMP');
            $('#MainContent_chkImpresion').prop('checked', false);
            $('#MainContent_chkImpresionTicket').prop('checked', true);
            $('#MainContent_chkComisionable').prop('checked', false);   
            $('#hfCodigoTemporal').val('0');
            $('#hfCodDocumentoVenta').val('0');
            $('#hfCodFacturaAnterior').val('0');
            $('#hfFlagRuc').val('0');
            $('#hfSaldoCreditoFavor').val("0.00");
            $('#txtSaldoCreditoFavor').text("S/ 0.00");
            $('#MainContent_ChkCodigo').prop('checked', true);
            F_Update_Division_HTML('div_grvDetalleArticulo', GridDetalleFTInicializado);
            F_Update_Division_HTML('div_grvArticulosPedido', GridDetalleFTInicializado);
            $("#MainContent_lblNumRegistros").text('0'); //Numerando grilla de pedidos
            $('#lblCantidadRegistro').text('0');
            $('.ccsestilo').css('background', '#FFFFE0'); 
            $('#MainContent_txtNroRuc').focus();
            $('#MainContent_txtObservacion').val('');
            $('#MainContent_txtPlaca').val('');
            $('#MainContent_txtKM').val('');
            PermisoCambio=false;
            $('#MainContent_lblD1').text('');
            $('#MainContent_lblD2').text('');
            $('#MainContent_lblD3').text('');
            $('#MainContent_txtTotal').val('0.00');
            $('#MainContent_lblD1Articulo').text('');
            $('#MainContent_lblD2Articulo').text('');
            $('#MainContent_lblD3Articulo').text('');
            $('#MainContent_txtSubTotal').val('0.00');
            $('#MainContent_txtIgv').val('0.00');
            $('#MainContent_txtTotal').val('0.00');
            F_Mostrar_Correlativo(15);                     
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
                                Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                                Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                Filtro_Desde: $('#MainContent_txtDesde').val(),
                                Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                Filtro_CodTipoDoc: 15,
                                Filtro_ChkNumero: chkNumero,
                                Filtro_ChkFecha: chkFecha,
                                Filtro_ChkCliente: chkCliente,
                                Filtro_CodEstado: $('#MainContent_ddlEstado').val(),
                                Filtro_CodEmpleado: $('#MainContent_ddlEmpleadoConsulta').val()
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
                    $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero')); 
                    
                    if (str_mensaje_operacion!='')                           
                    alertify.log(str_mensaje_operacion);                  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                $('#toolbar-options').toolbar({
	content: '#toolbar-options',
	position: 'bottom'
});
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
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

 try 
        {
       
    
        if ($('#hfEstado').val() == "ANULADO") {
            alertify.log("LA FACTURA SE ENCUENTRA ANULADA");
            return false;
        }

        if ($('#hfEstado').val() == "FACTURADO") {
            alertify.log("LAS COTIZACIONES FACTURADAS NO SE PUEDEN ANULAR");
            return false;
        }


    if(!confirm("ESTA SEGURO DE ANULAR LA COTIZACION : " + $('#hfNumeroAnulacion').text() + "\n" + "DEL CLIENTE : " +  $('#hfcliente_grilla').text()))
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
                          Filtro_Codigo:  $('#hfCodigo').val(),
                          Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: $(hfcodtipodoc_grilla).val(),
                          Filtro_CodEstado: $("#MainContent_ddlEstado").val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ObservacionAnulacion: $('#MainContent_txtObservacionAnulacion').val(),
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
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero'));  
                alertify.log(result.split('~')[1]);
                $('#div_Anulacion').dialog('close');
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

function F_ActivarVenta(Fila) {
 try 
        {
       var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgActivarVenta', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgActivarVenta', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgActivarVenta', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgActivarVenta', 'lblcliente');
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgActivarVenta', 'hfCodTipoDoc');
    var hfFlagVisibleFacturacion_grilla = '#' + imgID.replace('imgActivarVenta', 'hfFlagVisibleFacturacion');


    if ($(lblEstado).text() == "ANULADO") {
        alertify.log("LA FACTURA SE ENCUENTRA ANULADA");
        return false;
    }

    var dscVisible = "ACTIVAR";
    if ($(hfFlagVisibleFacturacion_grilla).val() == 1)
        dscVisible = "DESACTIVAR";

    if(!confirm("ESTA SEGURO DE " + dscVisible +  " LA COTIZACION " + " : " + $(lblnumero_grilla).text() + "\n" + "DEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                          Filtro_Codigo: $(lblCodigo).val(),
                          Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: $(hfcodtipodoc_grilla).val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente
    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);
    F_ActivarVenta_Net(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
        MostrarEspera(false);
        if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);     
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero'));  
                //alertify.log(result.split('~')[1]);
        }
        else {
             //alertify.log(result.split('~')[1]);
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
    $('#MainContent_txtDesde').val($('#MainContent_txtHasta').val());
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

function F_MostrarNumero(Texto) {

        $('#div_NumeroDocumento').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });
        
        $('#MainContent_lblNumeroDocumento').text(Number(Texto));
        $('.alert div.ui-dialog-titlebar').hide();
        $('#div_NumeroDocumento').dialog('open');
    return true;
}

function sleep(milliseconds) {
  var start = new Date().getTime();
  for (var i = 0; i < 1e7; i++) {
    if ((new Date().getTime() - start) > milliseconds){
      break;
    }
  }
}

function F_ImprimirGuia(Fila) {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgImprimir', 'hfCodTraslado');
    var lblEstado = '#' + imgID.replace('imgImprimir', 'lblestado');
   
    if ($(lblEstado).text()=='Anulado(a)')
    {
        alertify.log("La factura se encuentra anulada");
        return false;
    }

    if ($(lblCodigo).val()=='0')
    {
        alertify.log("La factura no tiene guia adjunta");
        return false;
    }

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
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImprimirFactura(Codigo) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '201';

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function ImprimirFacturaDetalle(Fila) {

    if ($('#' + Fila.id.replace('imgPdf', 'hfCodTipoDoc')).val() == '15')
    {
        F_VisualizarCotizacion('', Fila, 'imgPdf');
        return false;
    }

    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgPdf', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgPdf', 'lblestado');
    var hfTipoDoc = '#' + imgID.replace('imgPdf', 'hfCodTipoDoc');
    var TipoDoc = $(hfTipoDoc).val();

    var lblNumero = '#' + imgID.replace('imgPdf', 'lblnumero');
    var nrodoc = $(lblNumero).text();
    if (nrodoc.substr(0, 1) == '0') return false;


    if ($(lblEstado).text() == 'ANULADO') {
        alertify.log("La factura se encuentra anulada");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '4';
    var CodTipoArchivo2 = TipoDoc;
    var CodMenu = '201';



    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'CodTipoArchivo2=' + CodTipoArchivo2 + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&';
    rptURL = rptURL + 'Impresora=' + ImpresoraPDF + '&';
    rptURL = rptURL + 'NroCopias=' + NroCopiasPDF + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_VisualizarCotizacion(codigo,Fila,rplc,TI) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '4';
   var CodEstado = '0';
   var codigocot = 0;
   var TipoImp = 'PDF'; if (TI != undefined) TipoImp = TI;
   if (Fila!="")
   {
    CodTipoArchivo = '2';
    var imgID = Fila.id;
    if (rplc == undefined) {rplc = 'imgPdf2'; CodTipoArchivo = '1';}
    if (rplc == '') rplc = 'imgPdf';
    var lblID = '#' + imgID.replace(rplc, 'lblCodigo')
    codigocot = $(lblID).val();
    }
    else
    {
    codigocot = codigo;CodTipoArchivo = '2';
    TipoImp = 'IMP';
    }

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Codigo=' + codigocot + '&';
    rptURL = rptURL + 'CodSede=' + $('#hfCodSede').val() + '&';
    rptURL = rptURL + 'SerieDoc=' + '001' + '&';
    rptURL = rptURL + 'CodTipoDoc=' + 15 + '&';
    rptURL = rptURL + 'TipoImpresion=' + TipoImp + '&';


    window.open(rptURL, "PopUpRpt", Params);

    return false;
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

function F_VerUltimoPrecio(HlkControlID) {
return false;
    var Contenedor = '#cphCuerpo_';
    var CodNeumatico = '';
    var CodNeumaticoAlm = '';

    CodNeumatico = $('#' + HlkControlID).text();
    CodProducto = $('#' + HlkControlID.replace('hlkCodNeumaticoGv', 'lblcodproducto')).text();

    F_VerUltimoPrecio_Buscar(CodNeumatico, CodProducto);
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
//                alertify.log('no se encontraron datos');

            $('#MainContent_txtArticuloAgregar').focus();

            return false;

        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_LimpiarGrillaConsultaOC() {
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

function F_ValidarDevolucion(Mensaje) {
        try {
            var chkSi = '';
            var x = 0;

            $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;

                if ($(chkSi).is(':checked'))
                    x = 1;
            });

           
            if (x == 0) {
                alertify.log(Mensaje);
                return false;
            }
            else
            { return true; }

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }
    }

function F_Devolucion(){
 try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                    hfCodArticulo = chkSi.replace('chkEliminar', 'hfCodArticulo');
                    hfCodUndMedida = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                    hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                    hfSerieDoc = chkSi.replace('chkEliminar', 'hfSerieDoc');
                    lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
                    hfNumeroDoc = chkSi.replace('chkEliminar', 'hfNumeroDoc');
                    txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodDetalle: $(lblCodDetalle).text(),
                        CodArticulo: $(hfCodArticulo).val(),
                        CodUndMedida: $(hfCodUndMedida).val(),
                        SerieDoc: $(hfSerieDoc).val(),
                        NumeroDoc: $(hfNumeroDoc).val(),
                        Costo: $(lblPrecio).text(),
                        Cantidad: $(txtCantidadEntregada).val(),
                        CostoUnitario: $(hfCostoUnitario).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                var objParams = {
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                      
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Devolucion_NET(arg, function (result) {

                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    F_Update_Division_HTML('div_DetalleOC', result.split('~')[2]);
                    if (result.split('~')[2]=='Se grabo correctamente')
                    alertify.log('Se grabo correctamente');
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

function F_ValidarCheck_OC(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla='';
                   
            chkok_grilla = '#' + ControlID;
            txtCantidadEntregada = chkok_grilla.replace('chkEliminar', 'txtCantidadEntregada');
            lblCantidad = chkok_grilla.replace('chkEliminar', 'lblCantidad');
                 
            boolEstado = $(chkok_grilla).is(':checked');
            if (boolEstado)
            {
               
                $(txtCantidadEntregada).prop('disabled', false);
                $(txtCantidadEntregada).val($(lblCantidad).text());
                $(txtCantidadEntregada).focus();
            }
            else
            {
                $(txtCantidadEntregada).val('');
                $(txtCantidadEntregada).prop('disabled', true);
            }
            
        
    return true;
}

function F_ValidarStockGrillaOC(ControlID) {


    
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
            alertify.log("Stock insuficiente");
            $(txtcantidad_Grilla).val($(lblstock).text());
            F_MostrarTotales();
            return false;
    }
    if ($(txtcantidad_Grilla).val()=='')
        $(txtcantidad_Grilla).val($(lblstock).text());
    
    if (boolEstado==false)
     $(txtcantidad_Grilla).val($(lblstock).text());


    return true;
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length < 11) {
            if (valor.length == 8)
                return true;
//            suma = 0
//            for (i = 0; i < valor.length - 1; i++) {

//                if (i == 0) suma += (digito * 2)
//                else suma += (digito * (valor.length - i))
//            }
//            resto = suma % 11;
//            if (resto == 1) resto = 11;
//            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
//                return true
//            }
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

function F_FacturacionCotizacion() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtCodCotizacion').val() == "")
            Mensaje = Mensaje + "\n" + "Numero Cotizacion";
  
        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }
        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);


        try {
            var objParams = {
                Filtro_CodProforma: $(Contenedor + 'txtCodCotizacion').val(),
                Filtro_TasaIgv: tasaigv,
                Filtro_NotaPedido: '0'
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionCotizacion_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_mensaje_operacion == "")
                {
                   $('#hfCodigoTemporal').val(result.split('~')[2]);
                   $('#hfCodCtaCte').val(result.split('~')[3]);
                   $('#MainContent_ddlMoneda').val(result.split('~')[4]);
                   $('#MainContent_txtSubTotal').val(result.split('~')[5]);
                   $('#MainContent_txtIgv').val(result.split('~')[6]);
                   $('#MainContent_txtTotal').val(result.split('~')[7]);
                   $('#hfCodDepartamento').val(result.split('~')[8]);
                   $('#hfCodProvincia').val(result.split('~')[9]);
                   $('#hfCodDistrito').val(result.split('~')[10]);
                   $('#MainContent_txtDireccion').val(result.split('~')[11]);
                   $('#MainContent_txtNroRuc').val(result.split('~')[12]);
                   $('#MainContent_txtDistrito').val(result.split('~')[13]);
                   $('#MainContent_txtCliente').val(result.split('~')[14]);
                   $('#hfCliente').val(result.split('~')[14]);
                   F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[15]);
                   $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                   $('#MainContent_ddlFormaPago').val('1');
                   $('#hfCodProforma').val($(Contenedor + 'txtCodCotizacion').val());
                   $('#div_FacturarCotizacion').dialog('close');
                   return false;
                }
                else
                { 
                    alertify.log(str_mensaje_operacion);
                    return false;

                }
             });
        }

        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    }

function F_FacturacionGuia() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtProveedor').val() == "" || $('#hfCodCtaCte').val() == 0)
            Mensaje = Mensaje + "\n" + "Proveedor";

        if ($(Contenedor + 'lblTC').text() == "0")
            Mensaje = Mensaje + "\n" + "Tipo de Cambio";

        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }

        try {
            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMotivoTraslado: 9
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionGuia_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#div_FacturacionGuia').dialog({
                        resizable: false,
                        modal: true,
                        title: "Facturacion Guia",
                        title_html: true,
                        height: 500,
                        width: 890,
                        autoOpen: false
                    });
                    F_Update_Division_HTML('div_GrillaFacturacionGuia', result.split('~')[2]);

                    if (str_mensaje_operacion != "")
                        alertify.log(str_mensaje_operacion);
                    else
                        $('#div_FacturacionGuia').dialog('open');

                    return false;

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

function F_ValidarDevolucionGuia(Mensaje) {
        try {
            var chkSi = '';
            var x = 0;

            $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;

                if ($(chkSi).is(':checked'))
                    x = 1;
            });

           
            if (x == 0) {
                alertify.log(Mensaje);
                return false;
            }
            else
            { return true; }

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }
    }

function F_DevolucionGuia(){
 try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                    hfCodArticulo = chkSi.replace('chkEliminar', 'hfCodArticulo');
                    hfCodUndMedida = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                    hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                    hfSerieDoc = chkSi.replace('chkEliminar', 'hfSerieDoc');
                    lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
                    hfNumeroDoc = chkSi.replace('chkEliminar', 'hfNumeroDoc');
                    txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodDetalle: $(lblCodDetalle).text(),
                        CodArticulo: $(hfCodArticulo).val(),
                        CodUndMedida: $(hfCodUndMedida).val(),
                        SerieDoc: $(hfSerieDoc).val(),
                        NumeroDoc: $(hfNumeroDoc).val(),
                        Costo: $(lblPrecio).text(),
                        Cantidad: $(txtCantidadEntregada).val(),
                        CostoUnitario: $(hfCostoUnitario).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                var objParams = {
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_CodMotivoTraslado: 9
                                      
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_DevolucionGuia_NET(arg, function (result) {

                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    F_Update_Division_HTML('div_GrillaFacturacionGuia', result.split('~')[3]);
                    if (result.split('~')[2]=='Se grabo correctamente')
                    alertify.log('Se grabo correctamente');
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

function F_AgregarTemporalGuia() {
        try {

            var lblcodproducto_grilla = '';
            var lblcodunidadventa_grilla = '';
            var lblNumero = '';
            var lblcosto_grilla = '';
            var chkSi = '';
            var txtcantidad_grilla = '';
            var txtprecio_grilla = '';
            var txtdscto_grilla = '';
            var arrDetalle = new Array();
            var hfcodunidadventa_grilla = '';
            var hfcosto_grilla = '';
            var Contenedor = '#MainContent_';

            $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
                lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                lblcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtprecio_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                lblNumero = chkSi.replace('chkEliminar', 'lblNumero');

                if ($(chkSi).is(':checked')) {
                    var objDetalle = {
                        CodArticulo: $(lblcodproducto_grilla).val(),
                        Cantidad: $(txtcantidad_grilla).val(),
                        Precio: $(txtprecio_grilla).text(),
                        Costo: $(hfcosto_grilla).text(),
                        CodUm: $(hfcodunidadventa_grilla).val(),
                        CostoUnitario: $(hfCostoUnitario).val(),
                        Dscto: 0,
                        CodDetalle: $(lblCodDetalle).text(),
                        OC: $(lblNumero).text()
                    };

                    arrDetalle.push(objDetalle);
                }
            });

            var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                  
            var objParams = {
                Filtro_CodTipoDoc: "1",
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
                Filtro_CodTraslado: "0",
                Filtro_Descuento: "0",
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_TasaIgvDscto: tasaigv,
                Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
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
                    $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                    
                    if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                        alertify.log('Los Producto(s) se han agregado con exito');
                }
                else {
                    MostrarEspera(false);
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

function F_FacturaNotaVenta() {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";

    if ($(Contenedor + 'txtCodNotaVenta').val() == "")
        Mensaje = Mensaje + "\n" + "Codigo (ID)";

    if (Mensaje != "Ingrese los sgtes datos: ") {
        alertify.log(Mensaje);
        return false;
    }
    var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

    try {
        var objParams = {
            Filtro_CodDocumentoVenta: $(Contenedor + 'txtCodNotaVenta').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: '0'
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionNotaVenta_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[2]);
                $('#hfCodCtaCte').val(result.split('~')[3]);
                $('#MainContent_ddlMoneda').val(result.split('~')[4]);
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtCliente').val(result.split('~')[8]);
                $('#hfCliente').val(result.split('~')[8]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[9]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('#hfCodNotaVenta').val($(Contenedor + 'txtCodNotaVenta').val());
                $('#div_FacturacionNotaVenta').dialog('close');
                return false;
            }
            else {
                alertify.log(str_mensaje_operacion);
                return false;

            }
        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

var FilaActualizarValidaPermiso = '';
var PrecioActualizarValidarPermiso = '';

function F_ActualizarPrecio(Fila) {
    try {
        var txtPrecio = '#' + Fila;
        var hfCodDetalle = txtPrecio.replace('txtPrecio', 'hfCodDetalle');
        var hfPrecio = txtPrecio.replace('txtPrecio', 'hfPrecio');
        var hfP1 = txtPrecio.replace('txtPrecio', 'hfP1');
        var hfP2 = txtPrecio.replace('txtPrecio', 'hfP2');
        var hfP3 = txtPrecio.replace('txtPrecio', 'hfP3');
        var hfCantidad = txtPrecio.replace('txtPrecio', 'hfCantidad');
        var txtCantidad = txtPrecio.replace('txtPrecio', 'txtCantidad');
        var txtDescripcion = txtPrecio.replace('txtPrecio', 'txtDescripcion');
        var lblAcuenta = txtPrecio.replace('txtPrecio', 'lblAcuenta');
        var hfExclusivo = txtPrecio.replace('txtPrecio', 'hfExclusivo');
        var hfCodDetalleOC = txtPrecio.replace('txtPrecio', 'hfCodDetalleOC');
        var FlagIgv = 0;
        FilaActualizarValidaPermiso = "#" + Fila;
        PrecioActualizarValidarPermiso = $(hfPrecio).val();
        var PrecioLimite = parseFloat($(hfP1).val());
        var FlagPrecio = 0;

        if (parseFloat($(hfP2).val())>0)
        PrecioLimite = parseFloat($(hfP2).val());

          if (parseFloat($(hfP3).val())>0)
        PrecioLimite = parseFloat($(hfP3).val());

        if (parseFloat($(hfExclusivo).val())>0)
            PrecioLimite = $(hfExclusivo).val();

            if ((parseFloat($(txtPrecio).val()) < parseFloat($(hfP1).val()) & parseFloat($(txtPrecio).val()) < parseFloat($(hfPrecio).val())) & parseInt($(hfCodDetalleOC).val())>0)
            FlagPrecio=1;
//        if (parseFloat($(lblAcuenta).text()) != 0) {
//            $(txtPrecio).val(parseFloat($(hfPrecio).val()).toFixed(2));
//            return false;
//        }

//        if (UsuarioIniciado_PermisoCambioPrecios === '0') {
//            if (Number($(txtPrecio).val()) < Number(PrecioLimite) & Number(PrecioLimite) > 0 & PermisoCambio == false &
//                            F_VerificarTipoCliente() == false)
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

        PermisoCambio = false;
        FilaActualizarValidaPermiso = '';
        PrecioActualizarValidarPermiso = '';

        if (parseFloat($(txtPrecio).val()) == parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val()) == parseFloat($(hfCantidad).val())) {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
        }

        var tasaigv = 1;

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            FlagIgv = 1;
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        }            

        var objParams = {
            Filtro_Precio: $(txtPrecio).val() / tasaigv,
            Filtro_Precio2: $(hfExclusivo).val() / tasaigv,
            Filtro_Cantidad: $(txtCantidad).val(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetalle).val(),
            Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
            Filtro_Descripcion: $(txtDescripcion).val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_FlagIgv: FlagIgv,
            Filtro_Flag: 0,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1)   
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
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                if ($("#MainContent_chkTransferenciaGratuita").is(':checked')) {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                }
                else
                    F_MostrarTotales();
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                alertify.log(result.split('~')[1]);
            }
            if(FlagPrecio==1)
                  $(hfCodDetalleOC).val(0);

             F_ValidarPrecioMinimoRojo();

            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_ActualizarCantidad(Fila) {
    try {
        var txtCantidad = '#' + Fila;
        var hfCodDetalle = txtCantidad.replace('txtCantidad', 'hfCodDetalle');
        var hfPrecio = txtCantidad.replace('txtCantidad', 'hfPrecio');
        var hfCantidad = txtCantidad.replace('txtCantidad', 'hfCantidad');
        var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');
        var txtDescripcion = txtCantidad.replace('txtCantidad', 'txtDescripcion');
        var hfCodDetalleOC = txtCantidad.replace('txtCantidad', 'hfCodDetalleOC');
        var lblAcuenta = txtCantidad.replace('txtCantidad', 'lblAcuenta');
        var Flag = 0;
        var FlagIgv = 0;

//        if (parseFloat($(lblAcuenta).text()) != 0) {
//            $(txtCantidad).val(parseFloat($(hfCantidad).val()).toFixed(2));
//            return false;
//        }

        if ($(hfCodDetalleOC).val() == 0)
            Flag = 1

        if (parseFloat($(txtPrecio).val()) == parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val()) == parseFloat($(hfCantidad).val())) {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
        }

        var tasaigv = 1;

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            FlagIgv = 1;
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        } 

        var objParams = {
            Filtro_Precio: $(txtPrecio).val() / tasaigv,
            Filtro_Cantidad: $(txtCantidad).val(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_Descripcion: $(txtDescripcion).val(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetalle).val(),
            Filtro_Descripcion: $(txtDescripcion).val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_FlagIgv: FlagIgv,
            Filtro_Flag: Flag,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1)     
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

                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                if ($("#MainContent_chkTransferenciaGratuita").is(':checked')) {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                }
                else
                    F_MostrarTotales();
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
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

function F_ActualizarCantidadPedido(Fila) {
    try {
        var fila = '#' + Fila;
        var txtCantidad173="";
        var txtCantidad250="";
        var txtCantidadABC="";
        var hfCantidad173="";
        var hfCantidadABC="";
        var hfCantidad250="";
        var hfCodPedido="";
        
        if(fila.split("_")[2]=="txtCantidadPed173"){
           txtCantidad173=fila;
           txtCantidad250=fila.replace("txtCantidadPed173","txtCantidadPed250")      
           txtCantidadABC=fila.replace("txtCantidadPed173","txtCantidadPedABC")      
           hfCodPedido = fila.replace('txtCantidadPed173', 'hfCodPedido');        
           hfCantidad173 = fila.replace('txtCantidadPed173', 'hfCantidad173');        
           hfCantidadABC = fila.replace('txtCantidadPed173', 'hfCantidadABC');
           hfCantidad250 = fila.replace('txtCantidadPed173', 'hfCantidad250');
                  
        }else if(fila.split("_")[2]=="txtCantidadPed250"){
           txtCantidad250=fila;
           txtCantidad173=fila.replace("txtCantidadPed250","txtCantidadPed173")      
           txtCantidadABC=fila.replace("txtCantidadPed250","txtCantidadPedABC")      
           hfCodPedido = fila.replace('txtCantidadPed250', 'hfCodPedido');        
           hfCantidad173 = fila.replace('txtCantidadPed250', 'hfCantidad173');        
           hfCantidadABC = fila.replace('txtCantidadPed250', 'hfCantidadABC');
           hfCantidad250 = fila.replace('txtCantidadPed250', 'hfCantidad250');
        }else{
           txtCantidadABC=fila;
           txtCantidad173=fila.replace("txtCantidadPedABC","txtCantidadPed173")      
           txtCantidad250=fila.replace("txtCantidadPedABC","txtCantidadPed250")      
           hfCodPedido = fila.replace('txtCantidadPedABC', 'hfCodPedido');        
           hfCantidad173 = fila.replace('txtCantidadPedABC', 'hfCantidad173');        
           hfCantidadABC = fila.replace('txtCantidadPedABC', 'hfCantidadABC');
           hfCantidad250 = fila.replace('txtCantidadPedABC', 'hfCantidad250');
        }
       
        if ($(txtCantidad173).val()==$(hfCantidad173).val() && $(txtCantidad250).val()==$(hfCantidad250).val() && $(txtCantidadABC).val()==$(hfCantidadABC).val()) {            
            return false;
        }
        

        var objParams = {          
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(), 
            Filtro_CodDetPedido: $(hfCodPedido).val(),
            Filtro_Cantidad173: $(txtCantidad173).val(),                                    
            Filtro_Cantidad250:$(txtCantidad250).val(),
            Filtro_CantidadABC:$(txtCantidadABC).val(),
            FlagReemplazo:0            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarPrecioPedido_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);

            if (str_mensaje_operacion == "") {                

                F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[4]); //Llenando grilla de pedidos
                $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
                $('.ccsestilo').css('background', '#FFFFE0');            
                F_BloquearCantidadGrilla("grvDetallePedido");    
            }
            else {
                F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[4]); //Llenando grilla de pedidos
                $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
                $('.ccsestilo').css('background', '#FFFFE0');
                F_BloquearCantidadGrilla("grvDetallePedido");                
            }
            alertify.log(result.split("~")[2]);
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_PrecioMoneda(HlkControlID) {

     var   CodProducto = $('#' + HlkControlID.replace('hlkMoneda', 'lblcodproducto')).text();
     var   CodMoneda = 2;
     if ($('#MainContent_ddlMoneda').val()==2)
     CodMoneda = 1

        try {
            var objParams = {
                Filtro_CodProducto: CodProducto,
                Filtro_CodMoneda: CodMoneda,
                Filtro_Fecha : $('#MainContent_txtEmision').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_PrecioMoneda_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                {
                        $('#div_VerPrecio').dialog({
                                resizable: false,
                                modal: true,
                                title: "Ver Precios",
                                title_html: true,
                                height: 120,
                                width: 350,
                                autoOpen: false
                        });
                        F_Update_Division_HTML('div_PrecioMoneda', result.split('~')[2]); 
                        $('#div_VerPrecio').dialog('open');
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

function F_EliminarRegistro(Fila) {
 try 
        {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblcliente');    
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgEliminarDocumento', 'hfCodTipoDoc');

    if ($(hfcodtipodoc_grilla).val() == '5')
    {   F_EliminarRegistroOC(Fila);
        return true;
    }

    if ($(hfcodtipodoc_grilla).val() == '16')
    {   F_EliminarRegistroNV(Fila);
        return true;
    }

//    if ($(hfcodtipodoc_grilla).val() == '15')
//    {   
//        return true;
//    }

    if ($(lblEstado).text() == "CANCELADO TOTAL") {
        alertify.log("ESTA FACTURA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA FACTURA");
        return false;
    }

    if(!confirm("ESTA SEGURO DE ELIMINAR LA "  + $("#MainContent_ddlTipoDoc2 option:selected").text() + " : " + $(lblnumero_grilla).text() + "\n" + "DEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                          Filtro_Codigo: $(lblCodigo).val(),
                          Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: $(hfcodtipodoc_grilla).val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente
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
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);   
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero'));    
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

function F_EliminarRegistroOC(Fila) {
 try 
        {
    var imgID = Fila.id;
    var lblCodMarcaGv = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblcliente');
    
         if ($(lblEstado).text()=="FACTURADO") 
    {alertify.log ("LA ORDEN DE COMPRA VENTA SE ENCUENTRA FACTURADO,PRIMERO ELIMINE LA COBRANZA");
    return false;}

      if ($(lblEstado).text()=="CANCELADO PARCIAL") 
    {alertify.log ("LA ORDEN DE COMPRA VENTA SE ENCUENTRA CANCELADO PARCIAL,PRIMERO ELIMINE LA COBRANZA");
    return false;}

      if ($(lblEstado).text()=="CANC. TOTAL (F)") 
    {alertify.log ("LA ORDEN DE COMPRA VENTA SE ENCUENTRA CANC. TOTAL(F),PRIMERO ELIMINE LA COBRANZA");
    return false;}

       if ($(lblEstado).text()=="CANC. PAR (F)") 
    {alertify.log ("LA ORDEN DE COMPRA VENTA SE ENCUENTRA CANC. TOTAL(F),PRIMERO ELIMINE LA COBRANZA");
    return false;}

      if ($(lblEstado).text()=="CANCELADO TOTAL") 
    {alertify.log ("LA ORDEN DE COMPRA VENTA SE ENCUENTRA CANCELADO TOTAL,PRIMERO ELIMINE LA COBRANZA");
    return false;}

    if(!confirm("ESTA SEGURO DE ELIMINAR LA ORDEN DE COMPRA VENTA : " + $(lblnumero_grilla).text() + "\nDEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                          Filtro_Serie: 'TODOS',
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: 5,
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_CodEstado: $('#MainContent_ddlEstado').val()
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
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);      
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero')); 
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

function F_EliminarRegistroNV(Fila) {
 try 
        {

        var imgID = Fila.id;      
        var lblCodMarcaGv = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
        var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
        var lblnumero_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblnumero');
        var lblcliente_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblcliente');

        if ($(lblEstado).text() == "CANC. PARCIAL (B)") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA PARCIAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

        if ($(lblEstado).text() == "CANC. TOTAL (B)") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

         if ($(lblEstado).text() == "CANC. PARCIAL (F)") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA PARCIAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

        if ($(lblEstado).text() == "CANC. TOTAL (F)") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

                 if ($(lblEstado).text() == "CANCELADO PARCIAL") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA PARCIAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

        if ($(lblEstado).text() == "CANCELADO TOTAL") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA TOTAL; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

        if ($(lblEstado).text() == "FACTURADO") {
            alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA FACTURADA; PRIMERO ELIMINE LA FACTURA Y LUEGO ELIMINE LA NOTA DE VENTA");
            return false;
        }

        if(!confirm("ESTA SEGURO DE ELIMINAR LA NOTA DE VENTA : " + $(lblnumero_grilla).text() + "\n" + "DEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                          Filtro_Serie: $("#MainContent_ddlSerie option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: 16,
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_CodEstado: $("#MainContent_ddlEstado").val()
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
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);  
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero'));     
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

function F_ValidarPrecioGrilla(ControlID) {

//            var txtprecio_Grilla = '';
//            var lblprecio_grilla = '';
//            var txtcant_grilla = '';
//            var txtprecio_grilla = '';
//            var boolEstado = false;
//             chkok_grilla='';

            var txtPrecio = '#' + ControlID;
//            chkok_grilla = txtPrecio.replace('txtPrecio', 'chkOK');
//            lblprecio_grilla = txtPrecio.replace('txtPrecio', 'lblPrecio1');
//            boolEstado = $(chkok_grilla).is(':checked');
                
              if($(txtPrecio).val()=='')
              return false;

//            if ($('#hfCodUsuario').val()!='5' && boolEstado && parseFloat($(txtprecio_Grilla).val())< parseFloat($(lblprecio_grilla).val()))
//            {alertify.log("Precio por debajo del minimo");
//            $(txtprecio_Grilla).val('');
//              return false;
//             }

    return false;
}

function F_ImprimirCotizacionGrilla(Fila) {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgDSP', 'lblCodigo');
    var Codigo = $(lblCodigo).val();
    F_ImprimirCotizacion(Codigo);
return false;
}

function F_ImprimirCotizacion(Codigo) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '204';
    var Impresora = 'Microsoft Print to PDF';
    var Formato = 'rptCotizacion.rpt';
    var NroCopias = 1;

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
    rptURL = rptURL + 'Impresora=' + Impresora + '&' ;
    rptURL = rptURL + 'Formato=' + Formato + '&' ;
    rptURL = rptURL + 'NroCopias=' + NroCopias + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImprimirDocumento(codigo,Fila,rplc,TipoImp,TipoDoc) {
    var nrodoc = '';
    if (codigo == undefined) {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace(rplc, 'lblCodigo');
        var lblNumero = '#' + imgID.replace(rplc, 'lblnumero');
        var hfTipoDoc = '#' + imgID.replace(rplc, 'hfCodTipoDoc');
        codigo = $(lblCodigo).val();
        nrodoc = $(lblNumero).text();
        TipoDoc = $(hfTipoDoc).val();
    }
    else {
        nrodoc = $("#MainContent_ddlSerie option:selected").text()
    }


    //VALIDACONES PRE IMPRESION
    if (nrodoc.substr(0, 1) == 'F' || nrodoc.substr(0, 1) == 'B')
    {
        switch (TipoImp) {
            case 'PDF':  
                break;
            case 'IMP':
                break;
            case 'TK':
                break;
        }
    }
    else
    {
        switch (TipoImp) {
            case 'PDF':  
                break;
            case 'IMP':
                break;
            case 'TK':
                break;
        }    
    }

        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodMenu = '2001';

        rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'CodDocumentoVenta=' + codigo + '&';
        rptURL = rptURL + 'SerieDoc=' + nrodoc.substr(0, 4) + '&';
        rptURL = rptURL + 'CodTipoDoc=' + TipoDoc + '&';
        rptURL = rptURL + 'TipoImpresion=' + TipoImp + '&';
        rptURL = rptURL + 'NombreArchivo=' + '' + '&';

        window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImprimirDocumentoTicket(Fila, codigo, nrodoc) {

    var CodDocumentoVenta = 0;
    var CodEmpresa = 3;
    var SerieDoc = '';
    var CodTipoDoc = 15;
    var Nro = '';
    var Vendedor = '';
    var Monto = '';
    var Moneda = '';
    var NroOperacion = '';


    if (codigo == '') {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgTK', 'lblCodigo');
        var lblNumero = '#' + imgID.replace('imgTK', 'lblnumero');
        var lblVendedor = '#' + imgID.replace('imgTK', 'lblVendedor');
        var lblTotal = '#' + imgID.replace('imgTK', 'lblTotal');
        var lblMoneda = '#' + imgID.replace('imgTK', 'lblMoneda');
        var hfNroOperacion = '#' + imgID.replace('imgTK', 'hfNroOperacion');
        codigo = $(lblCodigo).val();
        nrodoc = $(lblNumero).text();

        SerieDoc = nrodoc.split('-')[0];
        Nro = nrodoc.split('-')[1];
        Vendedor = $(lblVendedor).text();
        Monto = $(lblTotal).text();
        Moneda = $(lblMoneda).text();
        NroOperacion = $(hfNroOperacion).val();
    }
    else {
        SerieDoc = $("#MainContent_ddlSerie option:selected").text();
        Nro = codigo;
        Vendedor = '';
        Monto = $("#MainContent_txtTotal").val();
        Moneda = $("#MainContent_ddlMoneda option:selected").text();
        NroOperacion = $("#MainContent_txtNroOperacion").val();
    }

        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodMenu = '2003';

        rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'CodDocumentoVenta=' + 0 + '&';
        rptURL = rptURL + 'SerieDoc=' + SerieDoc + '&';
        rptURL = rptURL + 'CodTipoDoc=' + 15 + '&';
        rptURL = rptURL + 'TipoImpresion=' + 'TK' + '&';
        rptURL = rptURL + 'Numero=' + Nro + '&';
        rptURL = rptURL + 'Monto=' + Monto + '&';
        rptURL = rptURL + 'Moneda=' + Moneda + '&';
        rptURL = rptURL + 'Vendedor=' + Vendedor + '&';
        rptURL = rptURL + 'NroOperacion=' + NroOperacion + '&';



        window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ReenvioMail(Fila) {
    var ID = Fila.id;
    var lblCodigo = '#' + ID.replace('imgMail', 'lblCodigo');

        try {
            var objParams = {
                Filtro_Codigo: $(lblCodigo).val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ReenvioMail_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                    alertify.log(str_mensaje_operacion);
                else
                    alertify.log(str_mensaje_operacion);

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;
}

function F_ImpresionPedidos() {
    if ($('#MainContent_ddlEstado').val() == "14" || $('#MainContent_ddlEstado').val() == "3") {
        alertify.log("SELECCIONE AL MENOS UNA NOTA DE PEDIDO");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width) + ', height=' + (screen.height) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var CodMenu = 2002;
    var CodTipoArchivo = 0;
    var chkSi = '';
    var arrDetalle = new Array();
    var lblID = '';
    var i = 0;
    var cn = 0;
    $('#MainContent_grvConsulta .chkDelete :checkbox').each(function () {
        chkSi = '#' + this.id;
        lblID = chkSi.replace('chkEliminar', 'lblCodigo');

        var lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');
        var lblNumero = chkSi.replace('chkEliminar', 'lblnumero');
        var hfTipoDoc = chkSi.replace('chkEliminar', 'hfCodTipoDoc');
        codigo = $(lblCodigo).val();
        nrodoc = $(lblNumero).text();
        TipoDoc = $(hfTipoDoc).val();

        if ((TipoDoc == '1' & nrodoc.substr(0,1) == 'F') | (TipoDoc == '2' & nrodoc.substr(0,1) == 'B'))
        {
            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodDocumentoVenta: $(lblID).val(),
                    NumeroFactura: nrodoc,
                    TipoDocumento: TipoDoc,
                    SerieDoc: nrodoc.substr(0, 4)
                };
                arrDetalle.push(objDetalle);
                i += 1;
            }
        } else
        {
            cn++;
        }



    });

    if (cn++ == 0)
    {
        if (i == 0) {
            alertify.log("SELECCIONE AL MENOS UNA NOTA DE PEDIDO");
            return false;
        }

        var XmlDetalle = Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle);

        rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
        rptURL = rptURL + 'Impresora=' + $("#MainContent_ddlImpresoraNotaPedido").val() + '&';
        rptURL = rptURL + 'CodSede=' + $('#hfCodSede').val() + '&';
        rptURL = rptURL + 'TipoImpresion=' + 'IMP' + '&';
        rptURL = rptURL + 'XmlDetalle=' + XmlDetalle + '&';

        window.open(rptURL, "PopUpRpt", Params);
    }
    else
    {
        alertify.log('SOLO SE PUEDEN ENVIAR DOCUMENTOS ELECTRONICOS FACTURAS Y BOLETAS');
    }
    return false;
}

function F_ValidarCheckSinIgvMaestro(ControlID) {
    var chkok_grilla = '#' + ControlID;
    var chkSi = '';
    var hfCodTipoDoc = '';
    var FlagNV = 0;

    if ($(chkok_grilla).is(':checked')) {
        $('#MainContent_chkConIgvMaestro').prop('checked', false);
        $('#MainContent_chKConIgv').prop('checked', false);
        $('#MainContent_chkSinIgv').prop('checked', true);
    }
    else {
              
                   
            $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodTipoDoc = chkSi.replace('chkEliminar', 'hfCodTipoDoc');


        });

        $('#MainContent_chkConIgvMaestro').prop('checked', true);
        $('#MainContent_chKConIgv').prop('checked', true);
        $('#MainContent_chkSinIgv').prop('checked', false);
    }
    F_ActualizarDetalle();
}

function F_ValidarCheckConIgvMaestro(ControlID) {
    var chkok_grilla = '#' + ControlID;
    var chkSi = '';
    var hfCodTipoDoc = '';
    var FlagNV = 0;

    if ($(chkok_grilla).is(':checked')) {
        $('#MainContent_chkSinIgvMaestro').prop('checked', false);
        $('#MainContent_chkSinIgv').prop('checked', false);
        $('#MainContent_chKConIgv').prop('checked', true);
    }
    else {
        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;
                hfCodTipoDoc = chkSi.replace('chkEliminar', 'hfCodTipoDoc');

                if ($(hfCodTipoDoc).val() == 16 || $(hfCodTipoDoc).val() == 5) {
                    $('#MainContent_chkConIgvMaestro').prop('checked', true);
                    $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                    return false;
                }
        }); 

        $('#MainContent_chkSinIgvMaestro').prop('checked', true);
        $('#MainContent_chkSinIgv').prop('checked', true);
        $('#MainContent_chKConIgv').prop('checked', false);
    }
    F_ActualizarDetalle();
}

function F_ActualizarDetalle(){
  try 
        {
        if($('#MainContent_txtTotal').val()=='0.00')
        return;

        var FlagIgv = 0;
        var Contenedor = '#MainContent_';    
        var tasaigv = 1;

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) { 
             tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
             FlagIgv = 1;         
        }                   
                var objParams = {
                                  Filtro_CodDocumentoVenta: $('#hfCodigoTemporal').val(),
                                  Filtro_Tasa: tasaigv,
                                  Filtro_TasaIgv: tasaigv,
                                  Filtro_FlagIgv: FlagIgv,
                                  Filtro_TasaIgvDscto:parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                                  Filtro_CodMoneda:$("#MainContent_ddlMoneda").val()                                 
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_ActualizarDetalle_NET(arg, function (result) {
                
                  MostrarEspera(false);

                   var str_resultado_operacion = result.split('~')[0];
                   var str_mensaje_operacion = result.split('~')[1];

                  if (str_mensaje_operacion == "Se Grabo Correctamente")
                   {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                    {
                         $('#MainContent_txtTotal').val('0.00');
                         $('#MainContent_txtAcuenta').val('0.00');
                         $('#MainContent_txtIgv').val('0.00');
                         $('#MainContent_txtSubTotal').val('0.00');
                         $('#MainContent_txtDsctoTotal').val('0.00');
                         $('#MainContent_txtMonto').val('0.00');
                    }
                    else
                    {
                         $('#MainContent_txtTotal').val(result.split('~')[5]);
                         $('#MainContent_txtAcuenta').val(result.split('~')[5]);
                         $('#MainContent_txtIgv').val(result.split('~')[6]);
                         $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                         $('#MainContent_txtMonto').val(result.split('~')[5]);
                         $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    }                   
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                     $('.ccsestilo').css('background', '#FFFFE0');
                   }
                else 
                {
                     F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                      $('.ccsestilo').css('background', '#FFFFE0');
                     alertify.log(result.split('~')[1]);
                }

                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

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

function F_AbrirPanelNV() {

  try {
        var objParams = {
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Inicializar_GrillaVacia_DetalleNV_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#divFacturacionNV').dialog({
                    resizable: false,
                    modal: true,
                    title: "Facturacion Nota de Venta",
                    title_html: true,
                    height: 500,
                    width: 1000,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_DetalleNV', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

                $('#divFacturacionNV').dialog('open');

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

function F_FacturacionNV(Desde, Hasta) {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";
    var NumeroDoc = "";

    if ($(Contenedor + 'lblTC').text() == "0")
        Mensaje = Mensaje + "<p></p>" + "Tipo de Cambio";

    if ($('#MainContent_chkNotaVenta').is(':checked'))
        NumeroDoc = $(Contenedor + 'txtNumeroNotaVenta').val();
    else
        NumeroDoc = "";

//    if (!$('#MainContent_chkConIgvMaestro').is(':checked')) {
//        Mensaje = Mensaje + "<p></p>" + "Con Igv debe estar chequeado";
//    }   


    try {
        var objParams = {
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_Desde: Desde,
            Filtro_Hasta: Hasta,
            Filtro_NumeroDoc: NumeroDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerieNV option:selected").text()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionNV_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

//                $('#divFacturacionNV').dialog({
//                    resizable: false,
//                    modal: true,
//                    title: "Facturacion Nota de Venta",
//                    title_html: true,
//                    height: 500,
//                    width: 1000,
//                    autoOpen: false
//                });
                F_Update_Division_HTML('div_DetalleNV', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

//                $('#divFacturacionNV').dialog('open');

                if (str_mensaje_operacion != "")
                    alertify.log(str_mensaje_operacion);
                else
                    $('#divFacturacionNV').dialog('open');

                return false;
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

function F_ValidarAgregarNV() {
    try {
        var cadena = "Ingrese los sgtes. campos: ";
        var chkSi = '';
        var lblCodigo = '';
        var txtCantidadEntregada = '';
        var x = 0;

        $('#MainContent_grvDetalleNV .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                if ($(txtCantidadEntregada).val() == '')
                    cadena = cadena + "<p></p>" + "Cantidad para el Codigo " + $(lblCodigo).text();
                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else
            return true;
    }
    catch (e) {
        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporalNV() {
    try {
        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var lblAcuenta = '';
        var hfFechaAnexo = '';
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $('#MainContent_grvDetalleNV .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
            lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
            txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
            lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
            hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
            lblNumero = chkSi.replace('chkEliminar', 'lblNumero');
            lblProducto = chkSi.replace('chkEliminar', 'lblProducto');
            lblAcuenta = chkSi.replace('chkEliminar', 'lblAcuenta');
            hfFechaAnexo = chkSi.replace('chkEliminar', 'hfFechaAnexo');

            if ($(chkSi).is(':checked')) {
                var acuenta = $(lblAcuenta).text(); if ($(lblAcuenta).text() == '') acuenta = '0';
                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).val(),
                    Cantidad: $(txtcantidad_grilla).val(),
                    Precio: $(lblPrecio).text() / tasaigv,
                    PrecioDscto: $(lblPrecio).text() / tasaigv,
                    Costo: $(hfcosto_grilla).text(),
                    CodUm: $(hfcodunidadventa_grilla).val(),
                    CostoUnitario: $(hfCostoUnitario).val(),
                    Dscto: 0,
                    CodDetalle: $(lblCodDetalle).text(),
                    OC: $(lblNumero).text(),
                    Descripcion: $(lblProducto).text(),
                    Acuenta: acuenta,
                    CodTipoDoc: 16,
                    Fecha: $(hfFechaAnexo).val()
                };
                arrDetalle.push(objDetalle);
            }
        });

        var objParams = {
            Filtro_CodTipoDoc: 16,
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
            Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_TasaIgvDscto: tasaigv,
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
            if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));

                            if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);
               // $('#divFacturacionNV').dialog('close');
            }
            else {
                MostrarEspera(false);
                alertify.log(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_AbrirPanelCT() {

  try {
        var objParams = {
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Inicializar_GrillaVacia_DetalleCT_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#divFacturacionCT').dialog({
                    resizable: false,
                    modal: true,
                    title: "Facturacion Cotizaciones",
                    title_html: true,
                    height: 500,
                    width: 1000,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_DetalleCT', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

                $('#divFacturacionCT').dialog('open');

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

function F_FacturacionCT(Desde, Hasta) {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";
    var NumeroDoc = "";

    if ($(Contenedor + 'lblTC').text() == "0")
        Mensaje = Mensaje + "<p></p>" + "Tipo de Cambio";

    if ($('#MainContent_chkCotizacion').is(':checked'))
        NumeroDoc = $(Contenedor + 'txtCotizacion').val();
    else
        NumeroDoc = "";

//    if (!$('#MainContent_chkConIgvMaestro').is(':checked')) {
//        Mensaje = Mensaje + "<p></p>" + "Con Igv debe estar chequeado";
//    }   


    try {
        var objParams = {
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_Desde: Desde,
            Filtro_Hasta: Hasta,
            Filtro_NumeroDoc: NumeroDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerieCT option:selected").text()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionCT_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

//                $('#divFacturacionCT').dialog({
//                    resizable: false,
//                    modal: true,
//                    title: "Facturacion Nota de Venta",
//                    title_html: true,
//                    height: 500,
//                    width: 1000,
//                    autoOpen: false
//                });
                F_Update_Division_HTML('div_DetalleCT', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

//                $('#divFacturacionCT').dialog('open');

                if (str_mensaje_operacion != "")
                    alertify.log(str_mensaje_operacion);
                else
                    $('#divFacturacionCT').dialog('open');

                return false;
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

function F_AgregarTemporalCT() {
    try {
        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var lblAcuenta = '';
        var hfFechaAnexo = '';
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $('#MainContent_grvDetalleCT .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
            lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
            txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
            lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
            hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
            lblNumero = chkSi.replace('chkEliminar', 'lblNumero');
            lblProducto = chkSi.replace('chkEliminar', 'lblProducto');
            lblAcuenta = chkSi.replace('chkEliminar', 'lblAcuenta');
            hfFechaAnexo = chkSi.replace('chkEliminar', 'hfFechaAnexo');

            if ($(chkSi).is(':checked')) {
                var acuenta = $(lblAcuenta).text(); if ($(lblAcuenta).text() == '') acuenta = '0';
                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).val(),
                    Cantidad: $(txtcantidad_grilla).val(),
                    Precio: $(lblPrecio).text() / tasaigv,
                    PrecioDscto: $(lblPrecio).text() / tasaigv,
                    Costo: $(hfcosto_grilla).text(),
                    CodUm: $(hfcodunidadventa_grilla).val(),
                    CostoUnitario: $(hfCostoUnitario).val(),
                    Dscto: 0,
                    CodDetalle: $(lblCodDetalle).text(),
                    OC: $(lblNumero).text(),
                    Descripcion: $(lblProducto).text(),
                    Acuenta: acuenta,
                    CodTipoDoc: 15,
                    Fecha: $(hfFechaAnexo).val()
                };
                arrDetalle.push(objDetalle);
            }
        });

        var objParams = {
            Filtro_CodTipoDoc: 16,
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
            Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_TasaIgvDscto: tasaigv,
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
            if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));

                          if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                    $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);
               // $('#divFacturacionCT').dialog('close');
            }
            else {
                MostrarEspera(false);
                alertify.log(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporalCTxNumero() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtCodCotizacion').val() == "")
            Mensaje = Mensaje + "\n" + "Numero Cotizacion";
  
        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }

            var id='0000000' + $(Contenedor + 'txtCodCotizacion').val();
            var numero = '001-' + id.substr(id.length - 7);

        var CodProforma = 0;
        var NroLista = 0;
        arrCotizaciones.forEach(function(element) {
        if (element["Nro"] == numero) {
            CodProforma = element["CodProforma"];
            NroLista = element["Indice"]; }
        });

        if (CodProforma > 0)
            F_AgregarTemporalCTxID(CodProforma, NroLista);
        else
            alertify.log("COTIZACION " +  $(Contenedor + 'txtCodCotizacion').val() + "NO ENCONTRADA");

return true;
}

function F_AgregarTemporalCTxID(CodProforma, NroLista) {

    try {

        var nro = $("#COTIZACION_SERIE_" + NroLista).val() + '-' + $("#COTIZACION_NUMERO_" + NroLista).val();

        if (!confirm("AGREGAR LA COTIZACION " + nro))
            return false;

        MostrarEspera(true);

        var arrDetalle = new Array();
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $.ajax({
            async: false,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: 'RegistroCotizaciones.aspx/F_Listar_Detalle_Proforma_NET',
            dataType: "json",
            data: "{'CodProforma':'" + CodProforma + "'}",
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;
                try {
                    //Array de Items
                    $.each(data.rows, function (index, item) {
                        var objDetalle = {
                            CodArticulo: item.CodArticulo,
                            Cantidad: item.Cantidad,
                            Precio: item.Precio / tasaigv,
                            PrecioDscto: item.Precio / tasaigv,
                            Costo: 0,
                            CodUm: item.CodUnidadMedida,
                            CostoUnitario: 0,
                            Dscto: 0,
                            CodDetalle: item.CodDetalleProforma,
                            OC: '',
                            Descripcion: item.Descripcion,
                            Acuenta: 0,
                            CodTipoDoc: 15,
                            Fecha: ''
                        };
                        arrDetalle.push(objDetalle);



                    });

                    var objParams = {
                        Filtro_CodTipoDoc: 15,
                        Filtro_SerieDoc: $("#COTIZACION_SERIE_" + NroLista).val(),
                        Filtro_NumeroDoc: $("#COTIZACION_NUMERO_" + NroLista).val(),
                        Filtro_FechaEmision: $("#COTIZACION_EMISION_" + NroLista).val(),
                        Filtro_Vencimiento: $("#COTIZACION_VENCIMIENTO_" + NroLista).val(),
                        Filtro_CodCliente: $("#COTIZACION_CODCTACTE_" + NroLista).val(),
                        Filtro_CodFormaPago: $("#COTIZACION_CODFORMAPAGO_" + NroLista).val(),
                        Filtro_CodMoneda: $("#COTIZACION_CODMONEDA_" + NroLista).val(),
                        Filtro_TipoCambio: $("#COTIZACION_TC_" + NroLista).val(),
                        Filtro_SubTotal: $("#COTIZACION_SUBTOTAL_" + NroLista).val(),
                        Filtro_CodProforma: "0",
                        Filtro_Igv: $("#COTIZACION_IGV_" + NroLista).val(),
                        Filtro_Total: $("#COTIZACION_TOTAL_" + NroLista).val(),
                        Filtro_CodGuia: "0",
                        Filtro_Descuento: "0",
                        Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                        Filtro_TasaIgvDscto: tasaigv,
                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                        Filtro_FlagIgv: 1
                    };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                F_AgregarTemporal_NET(arg, function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                        $('#hfCodigoTemporal').val(result.split('~')[3]);
                        $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                        $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                        $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                        $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));

                                    if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "15")
                            $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                        $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                        $('.ccsestilo').css('background', '#FFFFE0');
                        $('#hfNotaPedido').val(result.split('~')[9]);
                            if ($('#hfNotaPedido').val() == '5')
                                $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                                else $('#hfCodCtaCteNP').val(0);

                                $('#MainContent_txtCodCotizacion').val('');
                        // $('#divFacturacionCT').dialog('close');
                    }
                    else {
                        MostrarEspera(false);
                        alertify.log(result.split('~')[1]);
                    }
                    return false;
                });
                
                
                }
                catch (x) { alertify.log(x); }
                MostrarEspera(false);
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });

    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarAgregarCT() {
    try {
        var cadena = "Ingrese los sgtes. campos: ";
        var chkSi = '';
        var lblCodigo = '';
        var txtCantidadEntregada = '';
        var x = 0;

        $('#MainContent_grvDetalleCT .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                if ($(txtCantidadEntregada).val() == '')
                    cadena = cadena + "<p></p>" + "Cantidad para el Codigo " + $(lblCodigo).text();
                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else
            return true;
    }
    catch (e) {
        alertify.log("Error Detectado: " + e);
    }
}

function F_ActualizarDescripcion(Fila) {
    try {
        var txtDescripcion = '#' + Fila;
        var Clave = "";
        var hfCodDetalle = txtDescripcion.replace('txtDescripcion', 'hfCodDetalle');
        var hfPrecio = txtDescripcion.replace('txtDescripcion', 'hfPrecio');
        var hfCantidad = txtDescripcion.replace('txtDescripcion', 'hfCantidad');
        var txtPrecio = txtDescripcion.replace('txtDescripcion', 'txtPrecio');
        var txtClaveGrilla = txtDescripcion.replace('txtDescripcion', 'txtClaveGrilla');
        var hfDescripcion = txtDescripcion.replace('txtDescripcion', 'hfDescripcion');
        var txtCantidad = txtDescripcion.replace('txtDescripcion', 'txtCantidad');
        var tasaigv = 1;
        var FlagIgv = 0;

        if ($(txtDescripcion).val().trim() == "" || $(txtDescripcion).val() == $(hfDescripcion).val()) {
            $(txtDescripcion).val($(hfDescripcion).val());
            return false;
        }

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            FlagIgv = 1;
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        } 

        var objParams = {
            Filtro_Precio: $(txtPrecio).val() / tasaigv,
            Filtro_Cantidad: $(txtCantidad).val(),
            Filtro_Descripcion: $(txtDescripcion).val(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetalle).val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_Flag: 0,
            Filtro_FlagIgv: FlagIgv,
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1)     
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
                }
                else {
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                }
                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
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

function F_VisualizarRegistro(Fila) {
    return false;
    var imgID = Fila.id;
    var Cuerpo = '#MainContent_';
    var lblcodigo = '#' + imgID.replace('lblProducto', 'lblcodproducto');

    var hlblCodigoProducto = '#' + imgID.replace('lblProducto', 'hlkCodNeumaticoGv'); $(Cuerpo + 'txtCodigoVisualizacion').val($(hlblCodigoProducto).text());
    var hlblCodigo = '#' + imgID.replace('lblProducto', 'hfCodigoAlternativo'); $(Cuerpo + 'txtCodigo2Visualizacion').val($(hlblCodigo).val());
    var hlblProducto = '#' + imgID.replace('lblProducto', 'lblProducto'); $(Cuerpo + 'txtDescripcionVisualizacion').val($(hlblProducto).text());
    var hlblMedida = '#' + imgID.replace('lblProducto', 'hfMedida'); $(Cuerpo + 'txtMedidaVisualizacion').val($(hlblMedida).val());

    var hlblPais = '#' + imgID.replace('lblProducto', 'lblPrecio1'); $(Cuerpo + 'txtPaisVisualizacion').val($(hlblPais).text());
    var hlblMarca = '#' + imgID.replace('lblProducto', 'hfMarca'); $(Cuerpo + 'txtMarcaVisualizacion').val($(hlblMarca).val());
    var hlblModelo = '#' + imgID.replace('lblProducto', 'hfModelo'); $(Cuerpo + 'txtModeloVisualizacion').val($(hlblModelo).val());
    var hlblPosicion = '#' + imgID.replace('lblProducto', 'hfPosicion'); $(Cuerpo + 'txtPosicionVisualizacion').val($(hlblPosicion).val());
    var hlblAño = '#' + imgID.replace('lblProducto', 'hfAnio'); $(Cuerpo + 'txtAnovisualizacion').val($(hlblAño).val());
                                                                                                                


    
    var str_id = $(lblcodigo).text(); if (str_id == "") { str_id = 0; };
    var arrImg = new Array();
    var carga = 0;
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: "../Digitalizacion/FileDocDB.ashx?IdFile=" + str_id + "&Flag=1&tipo=1" + "&otro=" + Math.round(Math.random()) * 100,
        success: function (data) {
            MostrarEspera(true);
            try
            {
                var obj = $.parseJSON(data);
                $.each(obj, function (index, item) {
                    arrImg.push(item.img);
                });
                F_ArmarListaImagenes(arrImg);
            } catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function () {
            alertify.log('Ha ocurrido un error interno, por favor intentelo nuevamente.');
        }
    });
}

function F_ArmarListaImagenes(arrImg) {
    var lu = $('#luImagenes'); lu.empty();
    
    //imagenes dinamicas por cuadricula
    var med_li = ""; var med_img = "";
    switch (arrImg.length) {
        case 1: med_li = "width:900px; height:450px"; med_img = "max-width:850px; max-height:450px;"; break;
        case 2: med_li = "width:450px; height:450px"; med_img = "max-width:450px; max-height:450px;"; break;
        case 3: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 4: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 5: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 6: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 7: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 8: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 9: med_li = "width:225px; height:135px"; med_img = "max-width:175px; max-height:135px;"; break;
        case 10: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 11: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 12: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        default: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
    }

    $.each(arrImg, function (key, value) {

        var fmt =   ' <li class="li-float" style="' + med_li + '"> ' +
                    '     <a href=' + value + '  ' +
                    '         target="_blank" ' +
                    '         rel="nofollow"  ' +
                    '         style="background-image: url(' + value + ');"> ' +
                    '         <img src="' + value + '" class="li-img" style="' + med_img +' margin: 0 auto" alt="Imagen 1"/> ' +
                    '      </a> ' +
                    ' </li> ';
        lu.append(fmt)
    });

    $("#divVisualizarImagen").dialog({
        resizable: false,
        modal: true,
        title: "Visualización del Artículo",
        title_html: true,
        width: 1100,
        height: 650,
        autoOpen: false
    });

    $('#divVisualizarImagen').dialog('open');
}

function F_ReemplazarDocumento(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            var imgID = Fila.id;
            var lblcodigo = '#' + imgID.replace('imgReemplazar', 'lblCodigo');
            var lblEstado = '#' + imgID.replace('imgReemplazar', 'lblEstado');
            var lblTipoDoc = '#' + imgID.replace('imgReemplazar', 'hfCodTipoDoc');
            
            if ($(lblTipoDoc).val() == '5' | $(lblTipoDoc).val() == '16' | $(lblTipoDoc).val() == '15')
            {} else
            {
                alertify.log('SOLO SE PUEDEN MODIFICAR ORDENES DE COMPRA, NOTAS DE VENTA Y COTIZACIONES');
                return false;
            }

            if ($(lblEstado).text() != 'PENDIENTE')
            {
                alertify.log('EL DOCUMENTO DEBE ESTAR PENDIENTE');
                return false;
            }



            var objParams = {
                Filtro_CodNotaIngresoCab: $(lblcodigo).val(),
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_NotaPedido: 0,
                Filtro_CodTipoDoc: $(lblTipoDoc).val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_ReemplazarFactura_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#MainContent_ddlTipoDoc').val($(lblTipoDoc).val());
                    $('#MainContent_ddlTipoDoc').prop('disabled', true);
                    $('#hfCodFacturaAnterior').val(result.split('~')[18]);
                    $('#hfNumeroAnterior').val(result.split('~')[26]);
//                    F_CambioTipo();

                    $('#hfCodigoTemporal').val(result.split('~')[2]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[3]);
                    $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                    $('#MainContent_txtTotal').val(result.split('~')[4]);
                    $('#MainContent_txtIgv').val(result.split('~')[5]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[6]);
                    $('#MainContent_txtAcuentaNV').val(result.split('~')[7]);
                    $('#MainContent_txtNroRuc').val(result.split('~')[8]);
                    $('#MainContent_txtCliente').val(result.split('~')[9]);
                    $('#MainContent_ddlMoneda').val(result.split('~')[10]);
                    $('#MainContent_txtDistrito').val(result.split('~')[11]);
                    $('#MainContent_txtDireccion').val(result.split('~')[12]);
                    $('#MainContent_ddlFormaPago').val(result.split('~')[13]);
                    $('#hfCodCtaCte').val(result.split('~')[14]);
                    $('#hfCodDepartamento').val(result.split('~')[15]);
                    $('#hfCodProvincia').val(result.split('~')[16]);
                    $('#hfCodDistrito').val(result.split('~')[17]);
                    $('#MainContent_txtNumeroGuia').val(result.split('~')[23]);
                    $('#MainContent_txtDestino').val(result.split('~')[24]);
                    $('#MainContent_txtFechaTraslado').val(result.split('~')[25]);
                    $('#MainContent_txtNumero').val(result.split('~')[26]);
                    $('#MainContent_txtSerieOC').val(result.split('~')[30]);
                    $('#MainContent_ddlSerie').val(result.split('~')[30]);
                    $('#MainContent_txtEmision').val(result.split('~')[28]);
                    $('#MainContent_txtVencimiento').val(result.split('~')[29]);
                    $('#hfCodTransportista').val(result.split('~')[19]);
                    $('#MainContent_txtTransportista').val(result.split('~')[20]);
                    $('#MainContent_txtLicenciaGuia').val(result.split('~')[22]);
                    $('#MainContent_txtMarcaGuia').val(result.split('~')[31]);
                    $('#MainContent_txtDireccionTransportista').val(result.split('~')[32]);
                    $('#MainContent_txtNuBultos').val(result.split('~')[33]);
                    $('#MainContent_txtPeso').val(result.split('~')[34]);
                    $('#MainContent_txtPlacaTraslado').val(result.split('~')[35]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $("#divTabs").tabs("option", "active", $("#liRegistro").index());
                    $('#MainContent_txtNumero').val(result.split('~')[26]);
                    $('#MainContent_ddlSerie').text(result.split('~')[30]);
                    F_ValidarPrecioMinimoRojo();              
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

var cotFlagIgv = '';
function F_ReemplazarDocumento2(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";

    var imgID = Fila.id;
    var lblcodigo = '#' + imgID.replace('imgReemplazar', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgReemplazar', 'lblEstado');
    var lblTipoDoc = '#' + imgID.replace('imgReemplazar', 'hfCodTipoDoc');
            
    if ($(lblTipoDoc).val() == '5' | $(lblTipoDoc).val() == '16' | $(lblTipoDoc).val() == '15')
    {} else
    {
    alertify.log('SOLO SE PUEDEN MODIFICAR ORDENES DE COMPRA, NOTAS DE VENTA Y COTIZACIONES');
    return false;
    }

    if ($(lblEstado).text() != 'PENDIENTE')
    {
    alertify.log('EL DOCUMENTO DEBE ESTAR PENDIENTE');
    return false;
    }

    $('#hfCodFacturaAnterior').val($(lblcodigo).val());
    $('#hfCodigoTemporal').val(0);
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFacturaMultiple.aspx/F_ObtenerCotizacion_PorID_Net',
        dataType: "json",
        data: "{'CodCotizacion':'" + $(lblcodigo).val()  + "'}",
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {
                    var arrDetalle = new Array();
                    var Contenedor = '#MainContent_';
                                        var tasaigv =1;
                    var FlagIgv = data.FlagIgv ;

                    if (Number(FlagIgv)==1)
                    tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                    if (data.FlagComisionable==1)
                        $('#MainContent_chkComisionable').prop('checked', true);   
                    else
                        $('#MainContent_chkComisionable').prop('checked', false);   
                                              
                    //Array de Items
                    $.each(data.lProformaDet, function (index, item) {
                        var objDetalle = {
                            CodArticulo: item.CodArticulo,
                            Cantidad: item.Cantidad,
                            Precio: item.ValorVenta / tasaigv,
                            PrecioDscto: item.ValorVenta / tasaigv,
                            Precio2: item.Precio2 / tasaigv,
                            Costo: 0,
                            CodUm: item.CodUnidadMedida,
                            CostoUnitario: 0,
                            Dscto: 0,
                            CodDetalle: 0,
                            OC: '',
                            Descripcion: item.Descripcion,
                            Acuenta: 0,
                            CodTipoDoc: 0,
                            Observacion:item.Observacion,
                            Fecha: '',
                            Cantidad173:item.Cantidad173,
                            Cantidad250:item.Cantidad250,
                            CantidadABC:item.CantidadABC
                        };
                        arrDetalle.push(objDetalle);
                    });

                    var objParams = {
                        Filtro_CodTipoDoc: 15,
                        Filtro_SerieDoc: data.Serie,
                        Filtro_NumeroDoc: data.Numero,
                        Filtro_FechaEmision: data.EmisionStr,
                        Filtro_Vencimiento: data.VencimientoStr,
                        Filtro_CodCliente: data.CodCtaCte,
                        Filtro_CodFormaPago: data.CodFormaPago,
                        Filtro_CodMoneda: data.CodMoneda,
                        Filtro_TipoCambio: data.TipoCambio,
                        Filtro_SubTotal: data.SubTotal,
                        Filtro_CodProforma: data.CodProforma,
                        Filtro_Igv: data.Igv,
                        Filtro_Total: data.Total,
                        Filtro_CodGuia: "0",
                        Filtro_Descuento: "0",
                        Filtro_TasaIgv: tasaigv,
                        Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                        Filtro_FlagIgv: data.FlagIgv,
                        Filtro_CodFacturaAnterior: $("#hfCodFacturaAnterior").val(),
                        Filtro_FlagReemplazo:1
                    };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                F_AgregarTemporal_NET(arg, function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                        
                        $('#MainContent_chkConIgvMaestro').prop('checked', false);
                        $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                        if (FlagIgv == 0)                           
                            $('#MainContent_chkSinIgvMaestro').prop('checked', true);                       
                        else
                            $('#MainContent_chkConIgvMaestro').prop('checked', true);   
                          if (data.FlagConCodigo==0)
                            $('#MainContent_ChkCodigo').prop('checked', false);
                        else
                            $('#MainContent_ChkCodigo').prop('checked', true);     
                        
                        $('#hfCodigoTemporal').val(result.split('~')[3]);
                        $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                        $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                        $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                        $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                        
                        if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "10" |  $('#MainContent_ddlFormaPago').val() == "15")
                            $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                        $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                        $('#MainContent_ddlMoneda').val(data.CodMoneda);
                        $('#MainContent_txtNroRuc').val(data.NroRuc);
                        $('#hfNroRuc').val(data.NroRuc);
                        $('#MainContent_txtCliente').val(data.Cliente);
                        $('#MainContent_txtObservacion').val(data.Observacion);
                        $('#hfCliente').val(data.Cliente);
                        F_Update_Division_HTML('div_grvArticulosPedido', result.split('~')[10]); //Llenando grilla de pedidos
                        $("#MainContent_lblNumRegistros").text(F_Numerar_Grilla("grvDetallePedido", "lblCodigoProducto")); //Numerando grilla de pedidos
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_BloquearCantidadGrilla("grvDetallePedido");
                        $('#hfCodCtaCte').val(data.CodCtaCte);
                        $('#hfCodDepartamento').val(data.CodDepartamento);
                        $('#hfCodProvincia').val(data.CodProvincia);
                        $('#hfCodDistrito').val(data.CodDistrito);
                        $('#MainContent_txtDistrito').val(data.Distrito);
                        $('#MainContent_txtDireccion').val(data.Direccion);
                        $('#MainContent_txtNroOperacion').val(data.NroOperacion);
                        $('#MainContent_ddlVendedor').val(data.CodEmpleado);
                        $('#MainContent_txtPlaca').val(data.Placa);
                        $('#MainContent_txtKM').val(data.KM);
                        $('#hfCodDireccionDefecto').val(data.CodDireccion);

                        $('#MainContent_txtNumero').val(data.Numero);
                        
                        $('.ccsestilo').css('background', '#FFFFE0');
                        $('#hfNotaPedido').val(result.split('~')[9]);
                            if ($('#hfNotaPedido').val() == '5')
                                $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                                else $('#hfCodCtaCteNP').val(0);

                        F_BuscarDireccionesCliente();

                        $("#divTabs").tabs("option", "active", $("#liRegistro").index());
                    }
                    else {
                        MostrarEspera(false);
                        alertify.log(result.split('~')[1]);
                    }
                    return false;
                });
                }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });

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
        url: 'RegistroFacturaMultiple.aspx/F_Inicializar_Tabla_Almacenes_Stocks_NET',
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

function F_Consultar_Almacenes_Stocks(CodigoProducto) {
    var Marca = $("#" + CodigoProducto.replace("imgAgregar", "hfMarca")).val();
    var CodProductoAzure = $("#" + CodigoProducto.replace("imgAgregar", "hfCodProductoAzure")).val();
    var CodigoInterno = $("#" + CodigoProducto.replace("imgAgregar", "hfCodigoInterno")).val();


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
  
var Ctlgv;
var Hfgv;

function imgMas_Click(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalle(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function imgMasNI_Click(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalleNI(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsulta_pnlOrders_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlOrders', 'lblCodigo')).val();
                var CodTipoDoc = $('#' + Fila.replace('pnlOrders', 'hfCodTipoDoc')).val();
                var grvNombre = 'MainContent_grvConsulta_grvDetalle_' + Col;
                Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

                if ($(Hfgv).val() === "1")
                {
                    $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                    $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                }
                else 
                {
                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: CodTipoDoc,
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        //MostrarEspera(true);
                        $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                        F_LlenarGridDetalle_NET(arg, function (result) {
                
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
                            alertify.log(str_mensaje_operacion);
                        }

                        return false;

                        });
        
                }

                }

        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}

function F_LlenarGridDetalleNI(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsulta_pnlOrders_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlOrdersNI', 'lblCodigo')).val();
                var CodTipoDoc = $('#' + Fila.replace('pnlOrdersNI', 'hfCodTipoDoc')).val();
                var grvNombre = 'MainContent_grvConsulta_grvDetalleNI_' + Col;
                Hfgv = '#' + Fila.replace('pnlOrdersNI', 'hfDetalleCargadoNI');

                if ($(Hfgv).val() === "1")
                {
                    $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                    $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                }
                else 
                {
                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: CodTipoDoc,
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        //MostrarEspera(true);
                        $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                        F_LlenarGridDetalleNI_NET(arg, function (result) {
                
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
                            alertify.log(str_mensaje_operacion);
                        }

                        return false;

                        });
        
                }

                }

        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}

function F_ImprimirCotizacion_Despacho(Codigo) {
    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '208';

    rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_Kardex(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_KardexDetalle(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_KardexDetalle(Fila){
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
                            Filtro_Desde: '01/08/2019',
                            Filtro_Hasta: '01/08/2019',
                            Filtro_CodProducto: CodProducto,
                            Filtro_CodCtaCte:   0,
                            Filtro_CodTipoOperacion: 1,
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        //MostrarEspera(true);
                        $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                        F_KardexDetalle_NET(arg, function (result) {
                
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
                            alertify.log(str_mensaje_operacion);
                        }
                        return false;
                        });        
                }
                }
        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

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
                            alertify.log(str_mensaje_operacion);
                        }
                        return false;
                        });        
                }
                }
        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}

function F_ACTUALIZAR_MONTO_MONEDA() {
        var tasaigv = 1;
        var FlagIgv = 0;

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            FlagIgv = 1;
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        } 
    try {
        var objParams = {
            Filtro_CodMoneda:  $('#MainContent_ddlMoneda').val(),
            Filtro_TipoCambio: $('#MainContent_lblTC').text(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),          
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_FlagIgv: FlagIgv, 
            Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1)     
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ACTUALIZAR_MONTO_MONEDA_Net(arg, function (result) {

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

                $('#hfNotaPedido').val(result.split('~')[9]);
                 if ($('#hfNotaPedido').val() == '5')
                        $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                        else $('#hfCodCtaCteNP').val(0);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                F_MostrarTotales();
            }
            else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                F_MostrarTotales();
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

function F_VistaPreliminar(Fila) {

if (F_PermisoOpcion(CodigoMenu, 4000102, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
  var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgPdf2', 'lblCodigo');
        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var CodMenu = '209';
        var NombreArchivo = 'Web_Reporte_Ventas_rptCotizacion_ABC.rpt';
        var NombreTabla = 'Electronica';

        rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'Codigo=' + $(lblCodigo).val()  + '&';
        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
        rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
        rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';

        window.open(rptURL, "PopUpRpt", Params);

    return false;
}

///   INICIO BLOQUE DE DUEDAS DE CLIENTES

// AQUI EMPIEZA ARMAR LA GRILLA CON LOS CAMPOS DEL ALMACEN EXTERNOS Y EL PROPIO

$(document).ready(function () {
    F_Armar_Cuadricula_Almacenes_Clientes_Deudas();
});

var AlmacenesDeudasClientes;
function F_Armar_Cuadricula_Almacenes_Clientes_Deudas() {

    //limpio la tabla
    $("#table_almacenes_deudas > tbody").html("");
    
       
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/DeudasConsultaAPI.asmx/F_ListadoAlmacenes_Consulta_Deudas',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            AlmacenesDeudasClientes = dbObject.d;
            try {
            
            $.each(AlmacenesDeudasClientes, function (index, item) {
                    $("#table_almacenes_deudas > tbody").append("<tr><td style='width: 170px; padding-left: 5px'>" + item.almacen +  "</td><td style='width: 70px; text-align:right; padding-right:5px'> <label id='" + item.conexionAlmacen + "' style='font-weight: bold;'> S/. 0.00 </label></td> <td style='width:11px'><img id='img" + item.conexionAlmacen + "' src='../Asset/images/progress.gif' style='width:10px; height:10px; display:none'></td> </tr>");
            });

            }
            catch (x) { alertify.log('ERROR AL ARMAR DATA DE DEUDA CLIENTE'); }
        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });


return true;
}

//AQUI TERMINA ARMAR LA GRILLA CON LOS CAMPOS DEL ALMACEN EXTERNOS Y EL PROPIO

var TotalDeuda = 0;
function F_Buscar_Deudas_Clientes() {

    $("#div_table_almacenes").css('display', 'block');
TotalDeuda = 0;

    $.each(AlmacenesDeudasClientes, function (index, item) {

            $("#img" + item.conexionAlmacen).css('display', 'block') ;
            $("#" + item.conexionAlmacen).text("Buscando...");

            AlmacenesDeudasClientes[index].estado = "Consultando";
            AlmacenesDeudasClientes[index].deudas = null;


            var deudasConsultar = {};
            deudasConsultar["sede"] = item.conexionAlmacen;
            deudasConsultar["NroRuc"] = $("#MainContent_txtNroRuc").val();
            deudasConsultar["urlWAPI"] = item.conexionAPI;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/DeudasConsultaAPI.asmx/F_ConsultarDeudas_PorAlmacen',
                data: Sys.Serialization.JavaScriptSerializer.serialize(deudasConsultar),
                dataType: "json",
                async: true,
                success: function (dbObject) {
                    var data = dbObject.d;
                    try {
                        if (data.nroRuc = $("#MainContent_txtNroRuc").val()) {
                                if (data.mensaje === "OK") {

                                $("#" + data.sede).text( "S./ " +  data.totalDeudaSoles );
                                $("#img" + data.sede).css('display', 'none') ;

                                TotalDeuda = TotalDeuda + data.totalDeudaSoles ;
                                $("#txtSaldoCreditoFavor").text( "S./ " + TotalDeuda.toFixed(2) );


                                $.each(AlmacenesDeudasClientes, function (index, item) {

                                    if (item.conexionAlmacen === data.sede) {
                                        AlmacenesDeudasClientes[index].estado = "OK";
                                        AlmacenesDeudasClientes[index].deudas = data;                            
                                    }
            
                                });

                                } else {
                                    $("#" + data.sede).text( "Error");
                                    $("#img" + data.sede).css('display', 'none') ;                        

                                $.each(AlmacenesDeudasClientes, function (index, item) {

                                    if (item.conexionAlmacen === data.sede) {
                                        AlmacenesDeudasClientes[index].estado = "ERROR";
                                        AlmacenesDeudasClientes[index].deudas = data;                            
                                    }
            
                                });
                                }
                        }
            
            
                    }
                    catch (x) { alertify.log('ERROR AL ARMAR DATA DE DEUDA CLIENTE'); }
                },
                complete: function () {
            
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
    });

    //$('#div_table_almacenes').css('display', 'none');

return true;
}

function F_MostrarDetalle_DeudaCliente() {

    $("#MainContent_grvDetalleDeudas > tbody").html("");

    var Cabecera = '<tr>' + 
        '   <th scope="col">Almacen</th> ' + 
        '   <th scope="col">Nro. Documento</th> ' + 
        '   <th scope="col">Ruc</th> ' + 
        '   <th scope="col">Razon Social</th> ' + 
        '   <th scope="col">Emision</th>' +
        '   <th scope="col">Vencimiento</th>' +
        '   <th scope="col">Retraso</th>' +
        '   <th scope="col">Deuda</th>' +
        '   <th scope="col">Vendedor</th>' +
        '</tr>';
    $("#MainContent_grvDetalleDeudas > tbody").append(Cabecera);


    $.each(AlmacenesDeudasClientes, function (index, item) {

        if (item.estado === "OK") {
            if (item.deudas.mensaje === "OK") {
        
                var td01 = "<td>" + item.almacen + "</td>"; 

                $.each(item.deudas.documentos, function (index, item2) {

         
                var td02 = "<td style='text-align:center'>" + item2.nroDocumento + "</td>"; //NroDocumento
                var td03 = "<td style='text-align:center'>" + item2.nroRuc + "</td>"; //Ruc
                var td04 = "<td style='text-align:left'>" + item2.razonSocial + "</td>"; //RazonSocial
                var td05 = "<td style='text-align:center'>" + item2.emision + "</td>"; //Emision
                var td06 = "<td style='text-align:center'>" + item2.vencimiento + "</td>"; //Vencimiento
                var td07 = "<td style='text-align:center'>" + item2.retraso + "</td>"; //Retraso
                var td08 = "<td style='text-align:right'>" + item2.montoDeudaSoles.toFixed(2) + "</td>"; //MontoDeudaSoles
                var td09 = "<td style='text-align:left'>" + item2.vendedor + "</td>"; //Vendedor


                var detalle = "<tr>" + td01 + td02 + td03 + td04 + td05 + td06 + td07 + td08 + td09 + "</tr>";

                $("#MainContent_grvDetalleDeudas > tbody").append(detalle);        
        
                
            });
            }
        }



    });





    $('#div_DetalleDeudasPopUp').dialog({
        resizable: false,
        modal: true,
        title: "Detalle de deudas",
        title_html: true,
        height: 400,
        width: 1100,
        autoOpen: false
    });

    $('#div_DetalleDeudasPopUp').dialog('open');


return false;
}

///   FIN BLOQUE DE DUEDAS DE CLIENTES

function F_Gratuito(Fila) {
if (F_PermisoOpcion(CodigoMenu, 4000206, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        var Contenedor = '#MainContent_';

        $("#div_Mantenimiento").dialog({
            resizable: false,
            modal: true,
            title: "Edicion Registro",
            title_html: true,
            height: 200,
            width: 500,
            autoOpen: false
        });

        $(Contenedor + 'txtCodigoEdicion').val('');
        $(Contenedor + 'txtProductoEdicion').val('');
        
        var hfCodDetalle = '#' + Fila.replace('lblCodigo', 'hfCodDetalle');
        var txtDescripcion = '#' + Fila.replace('lblCodigo', 'txtDescripcion');
        var hfCodGratuito = '#' + Fila.replace('lblCodigo', 'hfCodGratuito');
        var Fila2 = '#' + Fila ;
        $('#hfCodDetalle').val($(hfCodDetalle).val());
        $(Contenedor + 'txtCodigoEdicion').val($(Fila2).text());
        $(Contenedor + 'txtProductoEdicion').val($(txtDescripcion).val());
        $(Contenedor + 'ddlGratuito').val($(hfCodGratuito).val());
     
        $('#div_Mantenimiento').dialog('open');
        return false;
    }
    catch (e) 
    {
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EditarGratuito() {
    try {
        var chkSi = '';
        var arrDetalle = new Array();  
        var Contenedor = '#MainContent_';
        var tasaigv = 1;

        if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            FlagIgv = 1;
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        } 

        var objParams = {         
            Filtro_CodGratuito: $(Contenedor + 'ddlGratuito').val(),
            Filtro_CodDetDocumentoVenta: $('#hfCodDetalle').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EditarGratuito_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);              
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                 F_MostrarTotales();
                $('.ccsestilo').css('background', '#FFFFE0');
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

function F_InicializarCajaTexto()
{
    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();

    $("#MainContent_txtCodCotizacion").ForceNumericOnly();

    $('#MainContent_txtCodCotizacion').css('background', '#FFFFE0');

    $('#MainContent_txtCliente').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtNroRuc').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');
    
    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca2').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca3').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca4').css('background', '#FFFFE0');

    $('#MainContent_txtKM').css('background', '#FFFFE0');

    $('#MainContent_txtPlacaTraslado').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuia').css('background', '#FFFFE0');

    $('#MainContent_txtFechaTraslado').css('background', '#FFFFE0');

    $('#MainContent_txtDestino').css('background', '#FFFFE0');

    $('#MainContent_txtDescuento').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtSerieOC').css('background', '#FFFFE0');
    
    $('#MainContent_txtNumeroOC').css('background', '#FFFFE0');

    $("#MainContent_txtSerieOC").ForceNumericOnly();

    $("#MainContent_txtNumeroOC").ForceNumericOnly();

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtAcuenta').css('background', '#FFFFE0');

    $('#MainContent_txtAcuentaNV').css('background', '#FFFFE0');

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtUltimoPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtMonedaPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtFechaPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtCantidadPrecio').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoDoc2').css('background', '#FFFFE0');
    
    $('#MainContent_ddlTipoImpresion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion2').css('background', '#FFFFE0');   

    $('#MainContent_txtTransportista').css('background', '#FFFFE0');   
    
    $('#MainContent_txtDireccionTransportista').css('background', '#FFFFE0');   

    $('#MainContent_txtMarcaGuia').css('background', '#FFFFE0');   

    $('#MainContent_txtLicenciaGuia').css('background', '#FFFFE0');   

    $('#MainContent_txtNuBultos').css('background', '#FFFFE0');   

    $('#MainContent_txtPeso').css('background', '#FFFFE0');   

    $('#MainContent_txtNumeroNotaVenta').css('background', '#FFFFE0');   

    $('#MainContent_txtDesdeNV').css('background', '#FFFFE0');   
    
    $('#MainContent_txtHastaNV').css('background', '#FFFFE0');   

    $('#MainContent_txtCotizacion').css('background', '#FFFFE0');   

    $('#MainContent_txtDesdeCT').css('background', '#FFFFE0');   
    
    $('#MainContent_txtHastaCT').css('background', '#FFFFE0');   

    $('#MainContent_txtCodigoVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo2Visualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtMedidaVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtPaisVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtPosicionVisualizacion').css('background', '#FFFFE0');

    $('#MainContent_txtAnovisualizacion').css('background', '#FFFFE0');

    $('#MainContent_ddlDropTop').css('background', '#FFFFE0');

    $('#MainContent_ddlEstado').css('background', '#FFFFE0');

    $('#MainContent_txtCantidadServicio').css('background', '#FFFFE0');

    $('#MainContent_txtPrecioServicio').css('background', '#FFFFE0');

    $('#txtSaldoCreditoFavor').css('background', '#FFFFE0');

    $('#MainContent_txtCorreo').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtCelular').css('background', '#FFFFE0');
    
    $('#MainContent_txtArticuloAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');
    
    $('#MainContent_txtPrecioDisplay').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProductoAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtUMAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtStockAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtClienteDropTop').css('background', '#FFFFE0');

    $("#MainContent_txtUsuarioPrecio").css('background', '#FFFFE0');

    $("#MainContent_txtContraseñaPrecio").css('background', '#FFFFE0');

    $("#MainContent_txtGratuito").css('background', '#FFFFE0');

    $("#MainContent_txtObservacionPrecio").css('background', '#FFFFE0');

    return false ;
}

//Joel
//api sunat
//esta funcion buscar la direccion con el ubigeo que se consigue con el api,esta funcion se encuentra en servicios
function F_BuscarDireccionNuevo() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Direccion_Buscar', 
        data: "{'Ubigeo':'" + ubigeo + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfCodDepartamento').val(data[0].split(',')[0]);
            $('#hfCodProvincia').val(data[0].split(',')[1]);
            $('#hfCodDistrito').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegion').val() == '' | $('#hfProvincia').val() == '') && $('#hfDistrito').val() == '') {
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
// esta funcion se encarga de busca la url y el token del api para la busque en la parte de padronsunat
function F_API_RUC_Buscar() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_API_RUC_Buscar',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfurlapisunat').val(data[0].split(',')[0]);
            $('#hftokenapisunat').val(data[0].split(',')[1]);
            
            return true;

        },
        complete: function () {
         
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
//limpia los campos
function F_LimpiarCampos() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $('#MainContent_txtNroRuc').val('');
    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtNombreComercial').val('');
    $('#hfCodCtaCte').val('0');
    $('#hfRegion').val('0');
    $('#hfProvincia').val('0');
    $('#hfDistrito').val('0');

//    $('#hftokenapisunat').val('');
//    $('#hfurlapisunat').val('');
    

    return true;
}

//FINAL

function checkAll(objRef) {
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvDetalleArticulo input:checkbox').prop('checked', true);
    else
        $('#MainContent_grvDetalleArticulo input:checkbox').prop('checked', false);
}

function F_CheckAllPedido(objRef) {
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvDetallePedido input:checkbox').prop('checked', true);
    else
        $('#MainContent_grvDetallePedido input:checkbox').prop('checked', false);
}

// DETALLE OBSERVACION
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
        var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'lblCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleObservacion_' + Col;
        HfgvObservacion = '#' + Fila.replace('pnlOrdersObservacion', 'grvDetalleObservacion');

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

function F_AnularPopUP(Fila) {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
      var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoDoc');
    
        if ($(lblEstado).text() == "ANULADO") {
            alertify.log("LA FACTURA SE ENCUENTRA ANULADA");
            return false;
        }

        if ($(lblEstado).text() == "FACTURADO") {
            alertify.log("LAS COTIZACIONES FACTURADAS NO SE PUEDEN ANULAR");
            return false;
        }

    $('#hfCodigo').val($(lblCodigo).val());
    $('#hfEstado').val($(lblEstado).text());
    $('#hfNumeroAnulacion').text($(lblnumero_grilla).text());
    $('#MainContent_txtObservacionAnulacion').val('');
    $('#hfcliente_grilla').text($(lblcliente_grilla).text());
    $('#hfcodtipodoc_grilla').val($(hfcodtipodoc_grilla).val());
    $('#div_Anulacion').dialog({
        resizable: false,
        modal: true,
        title: "Anulacion de CoTIZACION",
        title_html: true,
        height: 190,
        width: 470,
        autoOpen: false
    });
    $('#div_Anulacion').dialog('open');
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
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'lblCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleAuditoria_' + Col;
        HfgvAuditoria = '#' + Fila.replace('pnlOrdersAuditoria', 'hfDetalleCargadoAuditoria');

        if ($(HfgvAuditoria).val() === "1") {
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

function F_ListarAlmacenesExternos(){
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_ListarAlmacenesExternos',    
        dataType: "json",
        async: false,
         success: function (dbObject) {
            var data = dbObject.d;            
            for (var i = 0; i < data.length; i++) {
                $("#MainContent_ddlAlmacenesExternos").append(new Option(data[i].DBDataBase, data[i].CodAlmacen));                
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

function F_VerDetallePedido(){    
    if (parseInt($('#hfCodFacturaAnterior').val())>0)
    {
    toastr.error('NO SE PUEDE MODIFICAR LOS PEDIDOS');
    return false;
    }
    
    $("#div_grvArticulosPedidoCab").dialog({
        resizable: false,
        modal: true,
        title: "Articulos del pedido",
        title_html: true,
        height: 500,
        width: 1100,
        autoOpen: false
    });

    $('#div_grvArticulosPedidoCab').dialog('open');
}

function F_AnularNIPopUP(fila){
    try {

        var imgID = "#"+fila.id;
        var CodProforma = imgID.replace('imgAnularNI', 'lblCodigo');
        var hfCodUsuarioC = imgID.replace("imgAnularNI","hfCodUsuario");
        if($(hfCodUsuarioC).val()!=$("#hfCodUsuario").val()){
            toastr.warning("SOLO EL USUARIO QUE REGISTRO LA COTIZACION PUEDE ELIMINAR LAS NOTAS DE INGRESO ASOCIADAS");
            return false;
        }
        var objParams = {
            Filtro_CodProforma: $(CodProforma).val()
        };
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        F_LlenarGridDetalleNICab_NET(arg, function(result){
            var str_resultado_operacion = result.split('~')[0];
            var str_mensaje_operacion = result.split('~')[1];

            if(str_resultado_operacion==="0"){
                if(str_mensaje_operacion===""){
                    F_Update_Division_HTML("div_grvNotaIngreso",result.split('~')[2]);
                    $("#divNotaIngreso").dialog({
                        resizable: false,
                        modal: true,
                        title: "Nota de Ingreso Asociadas",
                        title_html: true,
                        height: 140,
                        width: 820,
                        autoOpen: false            
                    });
                    $("#divNotaIngreso").dialog("open");
                    $(".notIng").css('background', '#FFFFE0');                    
                }else{
                    toastr.warning(str_mensaje_operacion);
                }
                
            }else{
                toastr.warning(str_mensaje_operacion);
            }
            return false;
        });

    } catch (e) {
        MostrarEspera(false);
        toastr.warning("ERROR DETECTADO: " + e);
        return false;
    }
    
}

function F_AnularNotaIngreso(fila){
    var imgID = "#"+fila.id;
    var hfCodNotaIngreso = imgID.replace("imgAnularIngreso","hfCodNotaIngreso");
    var txtObservacion = imgID.replace("imgAnularIngreso","txtObsNI");
    var lblNumero = imgID.replace("imgAnularIngreso","lblNroNotaIngreso");
    if($(txtObservacion).val().length<10){
        toastr.warning("OBSERVACION: MIN 10 CARACTERES")
        return false;
    }

    var objParams={};
    objParams["CodNotaIngreso"]=Number($(hfCodNotaIngreso).val());
    objParams["Observacion"]=$(txtObservacion).val();
    
    if(confirm("ESTA SEGURO DE ANULAR ESTA NOTA DE INGRESO "+$(lblNumero).text())){
        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroCotizaciones.aspx/P_AnularNotaIngreso',
        data: JSON.stringify(objParams),
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                if (data.MsgError === "SE ANULO CORRECTAMENTE") {
                    toastr.success(data.MsgError);
                    $("#divNotaIngreso").dialog('close');                      
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
    }else{
        return false;
    }
    



}

function F_BloquearCantidadGrilla(grilla){
    var Contenedor="#MainContent_"+grilla;
    $(Contenedor+" .detallesart").each(function(){
        var lblCodigo = "#"+this.id;
        var txtCantidad173= lblCodigo.replace("lblCodigoProducto","txtCantidadPed173");
        var txtCantidad250=lblCodigo.replace("lblCodigoProducto","txtCantidadPed250");
        var txtCantidadABC=lblCodigo.replace("lblCodigoProducto","txtCantidadPedABC");
        if($("#hfIdAlmacen").val()==1){
           $(txtCantidad173).prop('disabled',true);            
        }else if($("#hfIdAlmacen").val()==5){
           $(txtCantidadABC).prop('disabled',true);             
        }else if ($("#hfIdAlmacen").val()==7){
           $(txtCantidad250).prop('disabled',true);              
        }else{
           $(txtCantidad250).prop('disabled',true);               
           $(txtCantidadABC).prop('disabled',true);             
           $(txtCantidad173).prop('disabled',true);            
        }
    })
              
}

function F_VerPDF(fila1){    
    var fila = fila1.id;
    var hfCodNotas = "#"+fila.replace('imgPdf3','hfCodNotaIngresos');
    
    var array =$(hfCodNotas).val().split(",");
    array = array.filter(e => String(e).trim());
        
    if (array.length>0){
      var json={
        Codigos:$(hfCodNotas).val(),
        CodTipoDoc:25
      }
      $.ajax({
        type:"POST",
        contentType:"application/json; charset=UTF-8",
        url:"../Servicios/PDF.asmx/F_Facturas_Pedido_Lote2_PDF",
        data:JSON.stringify(json),
        dataType:"json",
        async:true,
        success:function(data){
             if (data.d === "")
                    toastr.error("no se pudo descargar los documentos");

                var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';

                window.open(data.d, 'PopUpRpt', Params);
                //window.open(data.d, '_blank');
                MostrarEspera(false);
        },
        error: function (response) {
                alertify.log(response.responseText);
                MostrarEspera(false);
        },
        failure: function (response) {
                alertify.log(response.responseText);
                MostrarEspera(false);
        }
    });

    MostrarEspera(true);
    return false;
    }else {
        alertify.log("La cotizacion no tiene nota de ingresos asociadas activas");
    }
  
}

function F_ValidarPrecioExclusivo() {
    try {
        var chkSi = '';
        var txtPrecio = '';
        var Valor = false;


  
        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            txtPrecio = chkSi.replace('chkEliminar', 'txtPrecio');
            hfExclusivo = chkSi.replace('chkEliminar', 'hfExclusivo');
            hfP1 = chkSi.replace('chkEliminar', 'hfP1');
               //if (parseFloat($(txtPrecio).val())<parseFloat($(hfP1).val()) &  parseFloat($(hfExclusivo).val()) > 0)
               if (parseFloat($(hfExclusivo).val()) > 0)
                   Valor=true;
         });

//         if ($('#hfCodFacturaAnterior').val()>0 & ValorModificacion == 0)
//         {
//         ValorModificacion=1;
//         Valor = false;
//         }
         

        return Valor;
    }
    catch (e) {
        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarPrecioMinimoRojo()
{
$('#MainContent_grvDetalleArticulo .ccsestilo').each(function () {
                        var txtPrecio = '#' + this.id;
                        var lblCodigo = txtPrecio.replace("txtPrecio", "lblCodigo");
                        var txtDescripcion = txtPrecio.replace("txtPrecio", "txtDescripcion");
                        var txtCantidad = txtPrecio.replace("txtPrecio", "txtCantidad");
                        var hfP1 = txtPrecio.replace("txtPrecio", "hfP1");
                        var hfP2 = txtPrecio.replace('txtPrecio', 'hfP2');
                        var hfP3 = txtPrecio.replace('txtPrecio', 'hfP3');
                        var hfExclusivo = txtPrecio.replace('txtPrecio', 'hfExclusivo');
                        var lblimporte = txtPrecio.replace("txtPrecio", "lblimporte");
                        var PrecioLimite = parseFloat($(hfP1).val());
               
                        if (parseFloat($(hfP2).val())>0)
                            PrecioLimite = parseFloat($(hfP2).val());

                        if (parseFloat($(hfP3).val())>0)
                            PrecioLimite = parseFloat($(hfP3).val());

                        if (parseFloat($(hfExclusivo).val())>0)
                            PrecioLimite = $(hfExclusivo).val();
                        
                        if (parseFloat($(txtPrecio).val()) < PrecioLimite) {
                            $(txtPrecio).css("color", "red");
                            $(lblCodigo).css("color", "red");
                            $(txtDescripcion).css("color", "red");
                            $(txtCantidad).css("color", "red");
                            $(lblimporte).css("color", "red");
                        } else {
                            $(txtPrecio).css("color", "blue");
                            $(lblCodigo).css("color", "blue");
                            $(txtDescripcion).css("color", "blue");
                            $(txtCantidad).css("color", "blue");
                            $(lblimporte).css("color", "blue");
                        }
                    });
                    return false;
}

function F_ValidarPrecioRecorrido(){
var Variable = true;
var C = 0;
var Flag = 0;
ContadorPrecioMinimo=0;
 $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
               chkDel = '#' + this.id;
               txtPrecio = chkDel.replace('chkEliminar', 'txtPrecio');
               hfP1 = chkDel.replace('chkEliminar', 'hfP1');
               hfP2 = chkDel.replace('chkEliminar', 'hfP2');
               hfP3 = chkDel.replace('chkEliminar', 'hfP3');
               hfCodDetalleOC = chkDel.replace('chkEliminar', 'hfCodDetalleOC');
               hfPrecio = chkDel.replace('chkEliminar', 'hfPrecio');
               hfExclusivo = chkDel.replace('chkEliminar', 'hfExclusivo');

               var PrecioLimite = parseFloat($(hfP1).val());               

        if (parseFloat($(hfP2).val())>0)
        PrecioLimite = parseFloat($(hfP2).val());

          if (parseFloat($(hfP3).val())>0)
        PrecioLimite = parseFloat($(hfP3).val());

        if (parseFloat($(hfExclusivo).val())>0)
            PrecioLimite = $(hfExclusivo).val();

               if ($(hfCodDetalleOC).val()==0)
               {                     
                     if (parseFloat($(txtPrecio).val()) < PrecioLimite & PrecioLimite > 0 & C==0)
                     {
                          if (UsuarioIniciado_PermisoCambioPrecios === '0' & PermisoCambio == false &  F_VerificarTipoCliente() == false) 
                          {
                               $("#MainContent_txtUsuarioPrecio").val('');
                               $("#MainContent_txtContraseñaPrecio").val('');
                               $("#MainContent_txtObservacionPrecio").val('');
                               $("#MainContent_txtUsuarioPrecio").prop('disabled', false);
                               $("#MainContent_txtContraseñaPrecio").prop('disabled', false);
                               $("#MainContent_btnVerificar").prop('disabled', false);
                               C+=1;
                               ContadorPrecioMinimo = 1;
                               $('#divClavePrecio').dialog('open');
                               return false;
                          }
                     }
               }
               else
               {
                     if (parseFloat($(txtPrecio).val()) < PrecioLimite)
                            Flag = 1;
                    
                     if (parseFloat($(txtPrecio).val()) < PrecioLimite & PrecioLimite > 0 & Flag == 0  & C==0)
                     {
                          if (UsuarioIniciado_PermisoCambioPrecios === '0' & PermisoCambio == false &  F_VerificarTipoCliente() == false) 
                          {
                               $("#MainContent_txtUsuarioPrecio").val('');
                               $("#MainContent_txtContraseñaPrecio").val('');
                               $("#MainContent_txtObservacionPrecio").val('');
                               $("#MainContent_txtUsuarioPrecio").prop('disabled', false);
                               $("#MainContent_txtContraseñaPrecio").prop('disabled', false);
                               $("#MainContent_btnVerificar").prop('disabled', false);
                               C+=1;
                               ContadorPrecioMinimo = 1;
                               $('#divClavePrecio').dialog('open');
                               return false;
                          }
                     }
               }               
          });

          return C;
}

// DETALLE OBSERVACION
var CtlgvPermisoObservacion;
var HfgvPermisoObservacion;
function imgMasPermisoObservacion_Click(Control) {
    CtlgvPermisoObservacion = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_PermisoObservacion(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_PermisoObservacion(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlPermisoObservacion', 'lblCodigo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvPermisoObservacion_' + Col;
        HfgvPermisoObservacion = '#' + Fila.replace('pnlPermisoObservacion', 'grvPermisoObservacion');

        if ($(HfgvPermisoObservacion).val() === "1") {
            $(CtlgvPermisoObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvPermisoObservacion).next().html() + '</td></tr>');
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
                F_PermisoObservacion_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);
                       
                        $(CtlgvPermisoObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvPermisoObservacion).next().html() + '</td></tr>');
                        $(HfgvPermisoObservacion).val('1');
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